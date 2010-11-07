#include <sstream>
#include <Account.h>
#include <Configuration.h>
#include <cmd/GetAccountIncome.h>

using namespace std;

GetAccountIncome::GetAccountIncome(sqlite3* database, const Account* account) :
    DatabaseCommand(database), account_(account), balance_(0)
{
}

void GetAccountIncome::buildSqlCommand()
{
    ostringstream sout;

    sout << "SELECT SUM([" << Configuration::COLUMN_VALUE << "]) ";
    sout << "FROM [" << Configuration::TABLE_TRANSACTIONS << "] ";
    sout << "WHERE [" << Configuration::COLUMN_DESTINATION << "] = " << account_->getId() << ";" << endl;

    sql_ = sout.rdbuf()->str();
}

sqlite3_callback GetAccountIncome::getCallbackFunction()
{
    return DatabaseCommand::readDouble;
}

void* GetAccountIncome::getCallbackParameter()
{
    return &balance_;
}

void GetAccountIncome::execute()
{
    if (account_->getType() == Account::ACCOUNT) {
        DatabaseCommand::execute();
    }
}

