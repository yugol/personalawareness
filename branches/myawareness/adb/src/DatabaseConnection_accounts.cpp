#include <cmd/SelectAccountsCommand.h>
#include <cmd/GetAccountCommand.h>
#include <cmd/InsertAccountCommand.h>
#include <cmd/UpdateAccountCommand.h>
#include <cmd/DeleteAccountCommand.h>
#include <cmd/GetAccountBalanceCommand.h>
#include <DatabaseConnection.h>

using namespace std;

namespace adb {

void DatabaseConnection::insertUpdate(Account *account)
{
	accounts_.clear();
	ReversibleDatabaseCommand* cmd = 0;
	try {
		if (0 == account->getId()) {
			cmd = new InsertAccountCommand(database_, *account);
			cmd->execute();
			account->setId(static_cast<InsertAccountCommand*> (cmd)->getAccount().getId());
		} else {
			cmd = new UpdateAccountCommand(database_, *account);
			cmd->execute();
		}
		undoManager_.add(cmd);
	} catch (const Exception& ex) {
		delete cmd;
		RETHROW(ex);
	}
}

void DatabaseConnection::selectAccounts(std::vector<int>* selection, SelectionParameters* parameters) const
{
	SelectAccountsCommand(database_, selection, parameters).execute();
}

void DatabaseConnection::getAccount(Account* account) const
{
	GetAccountCommand(database_, account).execute();
}

void DatabaseConnection::deleteAccount(int id)
{
	accounts_.clear();
	ReversibleDatabaseCommand* cmd = 0;
	try {
		cmd = new DeleteAccountCommand(database_, id);
		cmd->execute();
		undoManager_.add(cmd);
	} catch (const Exception& ex) {
		delete cmd;
		RETHROW(ex);
	}
}

void DatabaseConnection::cashAccounts() const
{
	if (accounts_.size() > 0) {
		return;
	}

	vector<int> selection;
	SelectAccountsCommand selectCmd(database_, &selection, 0);
	selectCmd.execute();

	accounts_.clear();
	vector<int>::iterator it;
	for (it = selection.begin(); it != selection.end(); ++it) {
		int id = (*it);
		accounts_.push_back(Account(id));
		GetAccountCommand getCmd(database_, &accounts_[accounts_.size() - 1]);
		getCmd.execute();
	}
}

Account* DatabaseConnection::getAccount(int id) const
{
	cashAccounts();
	vector<Account>::iterator it;
	for (it = accounts_.begin(); it != accounts_.end(); ++it) {
		if (id == it->getId()) {
			return &(*it);
		}
	}
	return 0;
}

double DatabaseConnection::getBalance(Account* account) const
{
	GetAccountBalanceCommand cmd(database_, account);
	cmd.execute();
	return cmd.getBalance();
}

void DatabaseConnection::getAccounts(std::vector<int>* sel) const
{
	cashAccounts();
	vector<Account>::iterator it;
	for (it = accounts_.begin(); it != accounts_.end(); ++it) {
		if (Account::ACCOUNT == it->getType()) {
			sel->push_back(it->getId());
		}
	}
}

void DatabaseConnection::getBudgetCategories(std::vector<int>* sel) const
{
	cashAccounts();
	vector<Account>::iterator it;
	for (it = accounts_.begin(); it != accounts_.end(); ++it) {
		if (Account::ACCOUNT != it->getType()) {
			sel->push_back(it->getId());
		}
	}
}

void DatabaseConnection::getCreditingBudgets(std::vector<int>* sel) const
{
	cashAccounts();
	vector<Account>::iterator it;
	for (it = accounts_.begin(); it != accounts_.end(); ++it) {
		if (Account::CREDIT == it->getType()) {
			sel->push_back(it->getId());
		}
	}
}

void DatabaseConnection::getDebitingBudgets(std::vector<int>* sel) const
{
	cashAccounts();
	vector<Account>::iterator it;
	for (it = accounts_.begin(); it != accounts_.end(); ++it) {
		if (Account::DEBT == it->getType()) {
			sel->push_back(it->getId());
		}
	}
}

int DatabaseConnection::getAccountCount() const
{
	cashAccounts();
	return accounts_.size();
}

} // namespace adb
