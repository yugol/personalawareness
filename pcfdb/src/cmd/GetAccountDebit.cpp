#include <sstream>
#include <Account.h>
#include <Configuration.h>
#include <cmd/GetAccountDebit.h>

using namespace std;

GetAccountDebit::GetAccountDebit(sqlite3* database, const Account* account) :
    DatabaseCommand(database), account_(account), debit_(0)
{
}
void GetAccountDebit::buildSqlCommand()
{
    ostringstream sout;

    sout << "SELECT SUM([" << Configuration::COLUMN_VALUE << "]) ";
    sout << "FROM [" << Configuration::TABLE_TRANSACTIONS << "] ";
    sout << "WHERE [" << Configuration::COLUMN_SOURCE << "] = " << account_->getId() << ";" << endl;

    sql_ = sout.rdbuf()->str();
}

sqlite3_callback GetAccountDebit::getCallbackFunction()
{
    return DatabaseCommand::readDouble;
}

void* GetAccountDebit::getCallbackParameter()
{
    return &debit_;
}

void GetAccountDebit::execute()
{
    if (account_->getType() == Account::ACCOUNT) {
        DatabaseCommand::execute();
    }
}

