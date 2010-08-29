#include <sstream>
#include <Account.h>
#include <Configuration.h>
#include <cmd/GetAccountDebitCommand.h>

using namespace std;

namespace adb {

    GetAccountDebitCommand::GetAccountDebitCommand(sqlite3* database, Account* account) :
        DatabaseCommand(database), account_(account), debit_(0)
    {
    }
    void GetAccountDebitCommand::buildSqlCommand()
    {
        ostringstream sout;

        sout << "SELECT SUM([" << Configuration::VAL_COLUMN_NAME << "]) ";
        sout << "FROM [" << Configuration::TRANSACTIONS_TABLE_NAME << "] ";
        sout << "WHERE [" << Configuration::FROM_COLUMN_NAME << "] = " << account_->getId() << ";" << endl;

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
