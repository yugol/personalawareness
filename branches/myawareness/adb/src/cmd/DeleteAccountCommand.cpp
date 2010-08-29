#include <sstream>
#include <Configuration.h>
#include <cmd/GetAccountCommand.h>
#include <cmd/DeleteAccountCommand.h>

using namespace std;

namespace adb {

    DeleteAccountCommand::DeleteAccountCommand(sqlite3* database, int id) :
        ReversibleDatabaseCommand(database), account_(id)
    {
        // TODO: account in use
        GetAccountCommand(database_, &account_).execute();
    }

    void DeleteAccountCommand::buildSqlCommand()
    {
        ostringstream sout;

        sout << "UPDATE [" << Configuration::ACCOUNTS_TABLE_NAME << "] ";
        sout << "SET [" << Configuration::DEL_COLUMN_NAME << "] = '*' ";
        sout << "WHERE [" << Configuration::ID_COLUMN_NAME << "] = " << account_.getId() << ";" << endl;

        sql_ = sout.rdbuf()->str();
    }

    void DeleteAccountCommand::buildReverseSqlCommand()
    {
        ostringstream sout;

        sout << "UPDATE [" << Configuration::ACCOUNTS_TABLE_NAME << "] ";
        sout << "SET [" << Configuration::DEL_COLUMN_NAME << "] = NULL ";
        sout << "WHERE [" << Configuration::ID_COLUMN_NAME << "] = " << account_.getId() << ";" << endl;

        reverseSql_ = sout.rdbuf()->str();
    }

} // namespace adb
