#include <sstream>
#include <Configuration.h>
#include <cmd/PurgeDatabaseCommand.h>

using namespace std;

namespace adb {

    PurgeDatabaseCommand::PurgeDatabaseCommand(sqlite3* database) :
        DatabaseCommand(database)
    {
    }

    void PurgeDatabaseCommand::buildSqlCommand()
    {
        ostringstream sout;

        sout << "DELETE FROM [" << Configuration::TRANSACTIONS_TABLE_NAME << "] ";
        sout << "WHERE [" << Configuration::DEL_COLUMN_NAME << "] NOT NULL;" << endl;

        sout << "DELETE FROM [" << Configuration::ITEMS_TABLE_NAME << "] ";
        sout << "WHERE [" << Configuration::DEL_COLUMN_NAME << "] NOT NULL;" << endl;

        sout << "DELETE FROM [" << Configuration::ACCOUNTS_TABLE_NAME << "] ";
        sout << "WHERE [" << Configuration::DEL_COLUMN_NAME << "] NOT NULL;" << endl;

        sql_ = sout.rdbuf()->str();
    }

} // namespace adb
