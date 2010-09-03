#include <sstream>
#include <Account.h>
#include <Configuration.h>
#include <cmd/GetAccountCreditCommand.h>

using namespace std;

namespace adb {

    GetAccountCreditCommand::GetAccountCreditCommand(sqlite3* database, const Account* account) :
        DatabaseCommand(database), account_(account), credit_(0)
    {
    }

    void GetAccountCreditCommand::buildSqlCommand()
    {
        ostringstream sout;

        sout << "SELECT SUM([" << Configuration::VAL_COLUMN_NAME << "]) ";
        sout << "FROM [" << Configuration::TRANSACTIONS_TABLE_NAME << "] ";
        sout << "WHERE [" << Configuration::TO_COLUMN_NAME << "] = " << account_->getId() << ";" << endl;

        sql_ = sout.rdbuf()->str();
    }

    sqlite3_callback GetAccountCreditCommand::getCallbackFunction()
    {
        return DatabaseCommand::readDouble;
    }

    void* GetAccountCreditCommand::getCallbackParameter()
    {
        return &credit_;
    }

    void GetAccountCreditCommand::execute()
    {
        if (account_->getType() == Account::ACCOUNT) {
            DatabaseCommand::execute();
        }
    }

} // namespac eadb
