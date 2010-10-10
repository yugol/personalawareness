#include <sstream>
#include <Configuration.h>
#include <BaseUtil.h>
#include <cmd/GetAccount.h>
#include <cmd/UpdateAccount.h>

using namespace std;

UpdateAccount::UpdateAccount(sqlite3* database, const Account& account) :
    ReversibleDatabaseCommand(database), newAccount_(account)
{
    newAccount_.validate();
    previousAccount_.setId(newAccount_.getId());
    GetAccount(database_, &previousAccount_).execute();
}

void UpdateAccount::buildUpdateAccountSqlCommand(string& sql, const Account& account)
{
    ostringstream sout;

    sout << "UPDATE [" << Configuration::TABLE_ACCOUNTS << "] ";
    sout << "SET ";
    sout << "[" << Configuration::COLUMN_TYPE << "] = " << account.getType() << ", ";
    sout << "[" << Configuration::COLUMN_BALANCE << "] = " << account.getInitialValue() << ", ";
    sout << "[" << Configuration::COLUMN_NAME << "] = " << BaseUtil::toDbParameter(account.getName()) << ", ";
    sout << "[" << Configuration::COLUMN_GROUP << "] = " << BaseUtil::toDbParameter(account.getGroup()) << ", ";
    sout << "[" << Configuration::COLUMN_COMMENT << "] = " << BaseUtil::toDbParameter(account.getComment()) << " ";
    sout << "WHERE [" << Configuration::COLUMN_ID << "] = " << account.getId() << ";" << endl;

    sql = sout.rdbuf()->str();
}

void UpdateAccount::buildSqlCommand()
{
    buildUpdateAccountSqlCommand(sql_, newAccount_);
}

void UpdateAccount::buildReverseSqlCommand()
{
    buildUpdateAccountSqlCommand(reverseSql_, previousAccount_);
}

string UpdateAccount::getDescription() const
{
    return "update account";
}

