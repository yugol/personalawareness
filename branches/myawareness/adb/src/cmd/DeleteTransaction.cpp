#include <sstream>
#include <Configuration.h>
#include <cmd/GetTransaction.h>
#include <cmd/DeleteTransaction.h>

using namespace std;

namespace adb {

    DeleteTransaction::DeleteTransaction(sqlite3* database, int id) :
        ReversibleDatabaseCommand(database), transaction_(id)
    {
        GetTransaction(database_, &transaction_).execute();
    }

    void DeleteTransaction::buildSqlCommand()
    {
        ostringstream sout;

        sout << "UPDATE [" << Configuration::TABLE_TRANSACTIONS << "] ";
        sout << "SET [" << Configuration::COLUMN_DELETED << "] = '*' ";
        sout << "WHERE [" << Configuration::COLUMN_ID << "] = " << transaction_.getId() << ";" << endl;

        sql_ = sout.rdbuf()->str();
    }

    void DeleteTransaction::buildReverseSqlCommand()
    {
        ostringstream sout;

        sout << "UPDATE [" << Configuration::TABLE_TRANSACTIONS << "] ";
        sout << "SET [" << Configuration::COLUMN_DELETED << "] = NULL ";
        sout << "WHERE [" << Configuration::COLUMN_ID << "] = " << transaction_.getId() << ";" << endl;

        reverseSql_ = sout.rdbuf()->str();
    }

    string DeleteTransaction::getDescription() const
    {
        return "delete transaction";
    }

//TBD: also update the item

} // namespac eadb
