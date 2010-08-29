#include <cstdlib>
#include <sstream>
#include <Exception.h>
#include <Configuration.h>
#include <Account.h>
#include <cmd/GetAccountCommand.h>

using namespace std;

namespace adb {

    GetAccountCommand::GetAccountCommand(sqlite3* database, Account* account) :
        DatabaseCommand(database), account_(account)
    {
    }

    static int readAccount(void *param, int colCount, char **values, char **names)
    {
        Account* account = reinterpret_cast<Account*> (param);

        account->setId(::atoi(values[0]));
        account->setType(static_cast<Account::Type> (::atoi(values[1])));
        account->setName(values[2]);
        account->setGroup(values[3]);
        account->setInitialValue(::atof(values[4]));
        account->setDescription(values[5]);

        return 0;
    }

    sqlite3_callback GetAccountCommand::getCallbackFunction()
    {
        return readAccount;
    }

    void* GetAccountCommand::getCallbackParameter()
    {
        return account_;
    }

    void GetAccountCommand::buildSqlCommand()
    {
        ostringstream sout;

        sout << "SELECT ";
        sout << "[" << Configuration::ID_COLUMN_NAME << "], ";
        sout << "[" << Configuration::TYPE_COLUMN_NAME << "], ";
        sout << "[" << Configuration::NAME_COLUMN_NAME << "], ";
        sout << "[" << Configuration::GROUP_COLUMN_NAME << "], ";
        sout << "[" << Configuration::IVAL_COLUMN_NAME << "], ";
        sout << "[" << Configuration::DESC_COLUMN_NAME << "] ";
        sout << "FROM [" << Configuration::ACCOUNTS_TABLE_NAME << "] ";
        sout << "WHERE [" << Configuration::ID_COLUMN_NAME << "] = " << account_->getId() << ";" << endl;

        sql_ = sout.rdbuf()->str();
    }

    void GetAccountCommand::execute()
    {
        buildSqlCommand();
        int tempId = account_->getId();
        account_->setId(0);
        DatabaseCommand::execute();
        if (tempId != account_->getId()) {
            account_->setId(tempId);
            THROW(Exception::NO_RECORD_MESSAGE);
        }
    }

} // namespace std
