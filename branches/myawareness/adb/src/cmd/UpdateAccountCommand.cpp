#include <sstream>
#include <Configuration.h>
#include <cmd/GetAccountCommand.h>
#include <cmd/UpdateAccountCommand.h>

using namespace std;

namespace adb {

    UpdateAccountCommand::UpdateAccountCommand(sqlite3* database, const Account& account) :
        ReversibleDatabaseCommand(database), newAccount_(account)
    {
        newAccount_.validate();
        previousAccount_.setId(newAccount_.getId());
        GetAccountCommand(database_, &previousAccount_).execute();
    }

    void UpdateAccountCommand::buildUpdateAccountSqlCommand(string& sql, const Account& account)
    {
        ostringstream sout;

        sout << "UPDATE [" << Configuration::ACCOUNTS_TABLE_NAME << "] ";
        sout << "SET ";
        sout << "[" << Configuration::TYPE_COLUMN_NAME << "] = " << account.getType() << ", ";
        sout << "[" << Configuration::IVAL_COLUMN_NAME << "] = " << account.getInitialValue() << ", ";
        sout << "[" << Configuration::NAME_COLUMN_NAME << "] = " << toParameter(account.getName()) << ", ";
        sout << "[" << Configuration::GROUP_COLUMN_NAME << "] = " << toParameter(account.getGroup()) << ", ";
        sout << "[" << Configuration::DESC_COLUMN_NAME << "] = " << toParameter(account.getDescription()) << " ";
        sout << "WHERE [" << Configuration::ID_COLUMN_NAME << "] = " << account.getId() << ";" << endl;

        sql = sout.rdbuf()->str();
    }

    void UpdateAccountCommand::buildSqlCommand()
    {
        buildUpdateAccountSqlCommand(sql_, newAccount_);
    }

    void UpdateAccountCommand::buildReverseSqlCommand()
    {
        buildUpdateAccountSqlCommand(reverseSql_, previousAccount_);
    }

} // namespace adb
