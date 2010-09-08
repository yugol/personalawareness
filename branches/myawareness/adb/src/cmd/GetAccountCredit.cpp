#include <sstream>
#include <Account.h>
#include <Configuration.h>
#include <cmd/GetAccountCredit.h>

using namespace std;

namespace adb {

    GetAccountCredit::GetAccountCredit(sqlite3* database, const Account* account) :
        DatabaseCommand(database), account_(account), credit_(0)
    {
    }

    void GetAccountCredit::buildSqlCommand()
    {
        ostringstream sout;

        sout << "SELECT SUM([" << Configuration::COLUMN_VALUE << "]) ";
        sout << "FROM [" << Configuration::TABLE_TRANSACTIONS << "] ";
        sout << "WHERE [" << Configuration::COLUMN_DESTINATION << "] = " << account_->getId() << ";" << endl;

        sql_ = sout.rdbuf()->str();
    }

    sqlite3_callback GetAccountCredit::getCallbackFunction()
    {
        return DatabaseCommand::readDouble;
    }

    void* GetAccountCredit::getCallbackParameter()
    {
        return &credit_;
    }

    void GetAccountCredit::execute()
    {
        if (account_->getType() == Account::ACCOUNT) {
            DatabaseCommand::execute();
        }
    }

} // namespac eadb
