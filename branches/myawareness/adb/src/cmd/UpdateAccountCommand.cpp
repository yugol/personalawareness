#include <sstream>
#include <Configuration.h>
#include <DbUtil.h>
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

        sout << "UPDATE [" << Configuration::TABLE_ACCOUNTS << "] ";
        sout << "SET ";
        sout << "[" << Configuration::COLUMN_TYPE << "] = " << account.getType() << ", ";
        sout << "[" << Configuration::COLUMN_BALANCE << "] = " << account.getInitialValue() << ", ";
        sout << "[" << Configuration::COLUMN_NAME << "] = " << DbUtil::toDbParameter(account.getName()) << ", ";
        sout << "[" << Configuration::COLUMN_GROUP << "] = " << DbUtil::toDbParameter(account.getGroup()) << ", ";
        sout << "[" << Configuration::COLUMN_COMMENT << "] = " << DbUtil::toDbParameter(account.getDescription()) << " ";
        sout << "WHERE [" << Configuration::COLUMN_ID << "] = " << account.getId() << ";" << endl;

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
