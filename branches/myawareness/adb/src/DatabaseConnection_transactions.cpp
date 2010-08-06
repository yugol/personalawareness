#include <cmd/SelectTransactionsCommand.h>
#include <cmd/GetTransactionCommand.h>
#include <cmd/InsertTransactionCommand.h>
#include <cmd/UpdateTransactionCommand.h>
#include <cmd/DeleteTransactionCommand.h>
#include <DatabaseConnection.h>

using namespace std;

namespace adb {

void DatabaseConnection::selectTransactions(std::vector<int>* selection, SelectionParameters* parameters) const
{
	SelectTransactionsCommand(database_, selection, parameters).execute();
}

void DatabaseConnection::getTransaction(Transaction* transaction) const
{
	GetTransactionCommand(database_, transaction).execute();
}

void DatabaseConnection::insertUpdate(Transaction* transaction)
{
	ReversibleDatabaseCommand* cmd = 0;
	try {
		if (0 == transaction->getId()) {
			cmd = new InsertTransactionCommand(database_, *transaction);
	        cmd->execute();
            transaction->setId(static_cast<InsertTransactionCommand*> (cmd)->getTransaction().getId());
		} else {
			cmd = new UpdateTransactionCommand(database_, *transaction);
	        cmd->execute();
		}
		undoManager_.add(cmd);
	} catch (const Exception& ex) {
		delete cmd;
		RETHROW(ex);
	}
}

void DatabaseConnection::deleteTransaction(int id)
{
	ReversibleDatabaseCommand* cmd = 0;
	try {
		cmd = new DeleteTransactionCommand(database_, id);
		cmd->execute();
		undoManager_.add(cmd);
	} catch (const Exception& ex) {
		delete cmd;
		RETHROW(ex);
	}
}

} // namespace adb
