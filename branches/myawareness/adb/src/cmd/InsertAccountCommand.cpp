#include <sstream>
#include <Exception.h>
#include <Configuration.h>
#include <DbUtil.h>
#include <cmd/DeleteAccountCommand.h>
#include <cmd/UpdateAccountCommand.h>
#include <cmd/InsertAccountCommand.h>

using namespace std;

namespace adb {

    void InsertAccountCommand::buildReverseSqlCommand(std::ostream& out, const Account& account)
    {
        out << "INSERT INTO [" << Configuration::TABLE_ACCOUNTS << "] ( ";
        out << "[" << Configuration::COLUMN_TYPE << "], ";
        out << "[" << Configuration::COLUMN_BALANCE << "], ";
        out << "[" << Configuration::COLUMN_NAME << "], ";
        out << "[" << Configuration::COLUMN_GROUP << "], ";
        out << "[" << Configuration::COLUMN_COMMENT << "] ) ";
        out << "VALUES ( ";
        out << account.getType() << ", ";
        out << account.getInitialValue() << ", ";
        out << DbUtil::toDbParameter(account.getName()) << ", ";
        out << DbUtil::toDbParameter(account.getGroup()) << ", ";
        out << DbUtil::toDbParameter(account.getDescription()) << " );" << endl;
    }

    InsertAccountCommand::InsertAccountCommand(sqlite3* database, const Account& account) :
        ReversibleDatabaseCommand(database), account_(account)
    {
        account_.validate();
    }

    void InsertAccountCommand::buildSqlCommand()
    {
        ostringstream sout;
        buildReverseSqlCommand(sout, account_);
        sql_ = sout.rdbuf()->str();
    }

    void InsertAccountCommand::buildReverseSqlCommand()
    {
    }

    void InsertAccountCommand::execute()
    {
        if (0 == account_.getId()) {
            DatabaseCommand::execute();
            account_.setId(::sqlite3_last_insert_rowid(database_));
        } else {
            DeleteAccountCommand deleteCmd(database_, account_.getId());
            deleteCmd.unexecute();
            UpdateAccountCommand updateCmd(database_, account_);
            updateCmd.execute();
        }
    }

    void InsertAccountCommand::unexecute()
    {
        DeleteAccountCommand cmd(database_, account_.getId());
        cmd.execute();
    }

} // namespace adb
