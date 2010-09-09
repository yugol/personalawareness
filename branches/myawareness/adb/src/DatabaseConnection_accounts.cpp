#include <cstring>
#include <Exception.h>
#include <cmd/SelectAccounts.h>
#include <cmd/GetAccount.h>
#include <cmd/InsertAccount.h>
#include <cmd/UpdateAccount.h>
#include <cmd/DeleteAccount.h>
#include <cmd/GetAccountBalance.h>
#include <DatabaseConnection.h>

using namespace std;

namespace adb {

    void DatabaseConnection::insertUpdate(Account *account)
    {
        accounts_.clear();
        ReversibleDatabaseCommand* cmd = 0;
        try {
            if (0 == account->getId()) {
                cmd = new InsertAccount(database_, *account);
                cmd->execute();
                account->setId(static_cast<InsertAccount*> (cmd)->getAccount().getId());
            } else {
                cmd = new UpdateAccount(database_, *account);
                cmd->execute();
            }
            undoBuffer_.add(cmd);
        } catch (const Exception& ex) {
            delete cmd;
            RETHROW(ex);
        }
    }

    void DatabaseConnection::selectAccounts(vector<int>* selection, SelectionParameters* parameters) const
    {
        SelectAccounts(database_, selection, parameters).execute();
    }

    void DatabaseConnection::getAccount(Account* account) const
    {
        GetAccount(database_, account).execute();
    }

    bool DatabaseConnection::isAccountInUse(int id) const
    {
        return isAccountInUse(database_, id);
    }

    void DatabaseConnection::deleteAccount(int id)
    {
        accounts_.clear();
        ReversibleDatabaseCommand* cmd = 0;
        try {
            cmd = new DeleteAccount(database_, id);
            cmd->execute();
            undoBuffer_.add(cmd);
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
        SelectAccounts selectCmd(database_, &selection, 0);
        selectCmd.execute();

        accounts_.clear();
        vector<int>::iterator it;
        for (it = selection.begin(); it != selection.end(); ++it) {
            int id = (*it);
            accounts_.push_back(Account(id));
            GetAccount getCmd(database_, &accounts_[accounts_.size() - 1]);
            getCmd.execute();
        }
    }

    const Account* DatabaseConnection::getAccount(int id) const
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

    const Account* DatabaseConnection::getAccount(const char* name) const
    {
        cashAccounts();
        std::vector<Account>::iterator it;
        for (it = accounts_.begin(); it != accounts_.end(); ++it) {
            const char* accName = it->getName().c_str();
            int cmp = ::strcmp(accName, name);
            if (0 == cmp) {
                return &(*it);
            }
        }
        return 0;
    }

    double DatabaseConnection::getBalance(const Account* acc) const
    {
        GetAccountBalance cmd(database_, acc);
        cmd.execute();
        return cmd.getBalance();
    }

    void DatabaseConnection::getAccounts(vector<int>* sel) const
    {
        cashAccounts();
        vector<Account>::iterator it;
        for (it = accounts_.begin(); it != accounts_.end(); ++it) {
            if (Account::ACCOUNT == it->getType()) {
                sel->push_back(it->getId());
            }
        }
    }

    void DatabaseConnection::getBudgetCategories(vector<int>* sel) const
    {
        cashAccounts();
        vector<Account>::iterator it;
        for (it = accounts_.begin(); it != accounts_.end(); ++it) {
            if (Account::ACCOUNT != it->getType()) {
                sel->push_back(it->getId());
            }
        }
    }

    void DatabaseConnection::getCreditingBudgets(vector<int>* sel) const
    {
        cashAccounts();
        vector<Account>::iterator it;
        for (it = accounts_.begin(); it != accounts_.end(); ++it) {
            if (Account::CREDIT == it->getType()) {
                sel->push_back(it->getId());
            }
        }
    }

    void DatabaseConnection::getDebitingBudgets(vector<int>* sel) const
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
