#include <sstream>
#include <Configuration.h>
#include <Exception.h>
#include <DatabaseConnection.h>
#include <cmd/GetAccount.h>
#include <cmd/DeleteAccount.h>

using namespace std;

DeleteAccount::DeleteAccount(sqlite3* database, int id) :
    ReversibleDatabaseCommand(database), account_(id)
{
    if (DatabaseConnection::isAccountInUse(database_, id)) {
        THROW(Exception::EMSG_RECORD_IN_USE);
    }
    GetAccount(database_, &account_).execute();
}

void DeleteAccount::buildSqlCommand()
{
    ostringstream sout;

    sout << "UPDATE [" << Configuration::TABLE_ACCOUNTS << "] ";
    sout << "SET [" << Configuration::COLUMN_DELETED << "] = '*' ";
    sout << "WHERE [" << Configuration::COLUMN_ID << "] = " << account_.getId() << ";" << endl;

    sql_ = sout.rdbuf()->str();
}

void DeleteAccount::buildReverseSqlCommand()
{
    ostringstream sout;

    sout << "UPDATE [" << Configuration::TABLE_ACCOUNTS << "] ";
    sout << "SET [" << Configuration::COLUMN_DELETED << "] = NULL ";
    sout << "WHERE [" << Configuration::COLUMN_ID << "] = " << account_.getId() << ";" << endl;

    reverseSql_ = sout.rdbuf()->str();
}

string DeleteAccount::getDescription() const
{
    return "delete account";
}

