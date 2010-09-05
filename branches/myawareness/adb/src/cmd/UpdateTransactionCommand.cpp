#include <sstream>
#include <Configuration.h>
#include <DbUtil.h>
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

        sout << "UPDATE [" << Configuration::TABLE_TRANSACTIONS << "] ";
        sout << "SET ";
        sout << "[" << Configuration::COLUMN_DATE << "] = '" << transaction.getDate() << "', ";
        sout << "[" << Configuration::COLUMN_VALUE << "] = " << transaction.getValue() << ", ";
        sout << "[" << Configuration::COLUMN_SOURCE << "] = " << transaction.getFromId() << ", ";
        sout << "[" << Configuration::COLUMN_DESTINATION << "] = " << transaction.getToId() << ", ";
        sout << "[" << Configuration::COLUMN_DESCRIPTION << "] = " << transaction.getItemId() << ", ";
        sout << "[" << Configuration::COLUMN_COMMENT << "] = " << DbUtil::toDbParameter(transaction.getDescription()) << " ";
        sout << "WHERE [" << Configuration::COLUMN_ID << "] = " << transaction.getId() << ";" << endl;

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
