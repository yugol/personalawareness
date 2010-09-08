#include <Exception.h>
#include <SelectionParameters.h>
#include <cmd/SelectTransactions.h>
#include <cmd/GetTransaction.h>
#include <cmd/InsertTransaction.h>
#include <cmd/UpdateTransaction.h>
#include <cmd/DeleteTransaction.h>
#include <DatabaseConnection.h>

using namespace std;

namespace adb {

    void DatabaseConnection::insertUpdate(Transaction* transaction)
    {
        ReversibleDatabaseCommand* cmd = 0;
        try {
            if (0 == transaction->getId()) {
                cmd = new InsertTransaction(database_, *transaction);
                cmd->execute();
                transaction->setId(static_cast<InsertTransaction*> (cmd)->getTransaction().getId());
            } else {
                cmd = new UpdateTransaction(database_, *transaction);
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
            cmd = new DeleteTransaction(database_, id);
            cmd->execute();
            undoManager_.add(cmd);
        } catch (const Exception& ex) {
            delete cmd;
            RETHROW(ex);
        }
    }

    void DatabaseConnection::selectTransactions(vector<int>* selection, SelectionParameters* parameters) const
    {
        SelectTransactions(database_, selection, parameters).execute();
    }

    void DatabaseConnection::getTransaction(Transaction* transaction) const
    {
        GetTransaction(database_, transaction).execute();
    }

    void DatabaseConnection::getLastTransaction(Transaction* transaction) const
    {
        SelectionParameters tmpParameters;
        tmpParameters.setLastTransactionOnly(true);
        vector<int> tmpSelection;
        SelectTransactions(database_, &tmpSelection, &tmpParameters).execute();
        if (tmpSelection.size() == 1) {
            transaction->setId(tmpSelection[0]);
            getTransaction(transaction);
        } else {
            transaction->setId(0);
        }
    }

} // namespace adb
