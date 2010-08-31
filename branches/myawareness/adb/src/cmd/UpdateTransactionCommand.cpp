#include <sstream>
#include <Configuration.h>
#include <cmd/GetTransactionCommand.h>
#include <cmd/UpdateTransactionCommand.h>

using namespace std;

namespace adb {

    UpdateTransactionCommand::UpdateTransactionCommand(sqlite3* database, const Transaction& transaction) :
        ReversibleDatabaseCommand(database), newTransaction_(transaction)
    {
        newTransaction_.validate();
        previousTransaction_.setId(newTransaction_.getId());
        GetTransactionCommand(database_, &previousTransaction_).execute();
    }

    void UpdateTransactionCommand::buildUpdateTransactionCommand(string& sql, const Transaction& transaction)
    {
        ostringstream sout;

        sout << "UPDATE [" << Configuration::TRANSACTIONS_TABLE_NAME << "] ";
        sout << "SET ";
        sout << "[" << Configuration::DATE_COLUMN_NAME << "] = '" << transaction.getDate() << "', ";
        sout << "[" << Configuration::VAL_COLUMN_NAME << "] = " << transaction.getValue() << ", ";
        sout << "[" << Configuration::FROM_COLUMN_NAME << "] = " << transaction.getFromId() << ", ";
        sout << "[" << Configuration::TO_COLUMN_NAME << "] = " << transaction.getToId() << ", ";
        sout << "[" << Configuration::ITEM_COLUMN_NAME << "] = " << transaction.getItemId() << ", ";
        sout << "[" << Configuration::DESC_COLUMN_NAME << "] = " << toParameter(transaction.getDescription()) << " ";
        sout << "WHERE [" << Configuration::ID_COLUMN_NAME << "] = " << transaction.getId() << ";" << endl;

        sql = sout.rdbuf()->str();
    }

    void UpdateTransactionCommand::buildSqlCommand()
    {
        buildUpdateTransactionCommand(sql_, newTransaction_);
    }

    void UpdateTransactionCommand::buildReverseSqlCommand()
    {
        buildUpdateTransactionCommand(reverseSql_, previousTransaction_);
    }

// TBD: also update the item

} // namespac adb
