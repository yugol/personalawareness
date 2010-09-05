#include <sstream>
#include <Account.h>
#include <Configuration.h>
#include <cmd/GetAccountDebitCommand.h>

using namespace std;

namespace adb {

    GetAccountDebitCommand::GetAccountDebitCommand(sqlite3* database, const Account* account) :
        DatabaseCommand(database), account_(account), debit_(0)
    {
    }
    void GetAccountDebitCommand::buildSqlCommand()
    {
        ostringstream sout;

        sout << "SELECT SUM([" << Configuration::COLUMN_VALUE << "]) ";
        sout << "FROM [" << Configuration::TABLE_TRANSACTIONS << "] ";
        sout << "WHERE [" << Configuration::COLUMN_SOURCE << "] = " << account_->getId() << ";" << endl;

        sql_ = sout.rdbuf()->str();
    }

    sqlite3_callback GetAccountDebitCommand::getCallbackFunction()
    {
        return DatabaseCommand::readDouble;
    }

    void* GetAccountDebitCommand::getCallbackParameter()
    {
        return &debit_;
    }

    void GetAccountDebitCommand::execute()
    {
        if (account_->getType() == Account::ACCOUNT) {
            DatabaseCommand::execute();
        }
    }

} // namespac eadb
