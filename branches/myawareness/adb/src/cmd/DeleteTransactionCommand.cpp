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

        sout << "UPDATE [" << Configuration::TABLE_TRANSACTIONS << "] ";
        sout << "SET [" << Configuration::COLUMN_DELETED << "] = '*' ";
        sout << "WHERE [" << Configuration::COLUMN_ID << "] = " << transaction_.getId() << ";" << endl;

        sql_ = sout.rdbuf()->str();
    }

    void DeleteTransactionCommand::buildReverseSqlCommand()
    {
        ostringstream sout;

        sout << "UPDATE [" << Configuration::TABLE_TRANSACTIONS << "] ";
        sout << "SET [" << Configuration::COLUMN_DELETED << "] = NULL ";
        sout << "WHERE [" << Configuration::COLUMN_ID << "] = " << transaction_.getId() << ";" << endl;

        reverseSql_ = sout.rdbuf()->str();
    }

//TBD: also update the item

} // namespac eadb
