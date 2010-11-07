#include <sstream>
#include <Account.h>
#include <Configuration.h>
#include <cmd/GetAccountExpenses.h>

using namespace std;

GetAccountExpenses::GetAccountExpenses(sqlite3* database, const Account* account) :
    DatabaseCommand(database), account_(account), balance_(0)
{
}
void GetAccountExpenses::buildSqlCommand()
{
    ostringstream sout;

    sout << "SELECT SUM([" << Configuration::COLUMN_VALUE << "]) ";
    sout << "FROM [" << Configuration::TABLE_TRANSACTIONS << "] ";
    sout << "WHERE [" << Configuration::COLUMN_SOURCE << "] = " << account_->getId() << ";" << endl;

    sql_ = sout.rdbuf()->str();
}

sqlite3_callback GetAccountExpenses::getCallbackFunction()
{
    return DatabaseCommand::readDouble;
}

void* GetAccountExpenses::getCallbackParameter()
{
    return &balance_;
}

void GetAccountExpenses::execute()
{
    if (account_->getType() == Account::ACCOUNT) {
        DatabaseCommand::execute();
    }
}

