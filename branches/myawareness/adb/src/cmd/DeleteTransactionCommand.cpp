#include <sstream>
#include <Configuration.h>
#include <cmd/GetTransactionCommand.h>
#include <cmd/DeleteTransactionCommand.h>

using namespace std;

namespace adb {

    DeleteTransactionCommand::DeleteTransactionCommand(sqlite3* database, int id) :
        ReversibleDatabaseCommand(database), transaction_(id)
    {
        GetTransactionCommand(database_, &transaction_).execute();
    }

    void DeleteTransactionCommand::buildSqlCommand()
    {
        ostringstream sout;

        sout << "UPDATE [" << Configuration::TRANSACTIONS_TABLE_NAME << "] ";
        sout << "SET [" << Configuration::DEL_COLUMN_NAME << "] = '*' ";
        sout << "WHERE [" << Configuration::ID_COLUMN_NAME << "] = " << transaction_.getId() << ";" << endl;

        sql_ = sout.rdbuf()->str();
    }

    void DeleteTransactionCommand::buildReverseSqlCommand()
    {
        ostringstream sout;

        sout << "UPDATE [" << Configuration::TRANSACTIONS_TABLE_NAME << "] ";
        sout << "SET [" << Configuration::DEL_COLUMN_NAME << "] = NULL ";
        sout << "WHERE [" << Configuration::ID_COLUMN_NAME << "] = " << transaction_.getId() << ";" << endl;

        reverseSql_ = sout.rdbuf()->str();
    }

//TODO: also update the item

} // namespac eadb