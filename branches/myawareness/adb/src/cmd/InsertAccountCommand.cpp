#include <sstream>
#include <Exception.h>
#include <Configuration.h>
#include <DbUtil.h>
#include <cmd/DeleteAccountCommand.h>
#include <cmd/UpdateAccountCommand.h>
#include <cmd/InsertAccountCommand.h>

using namespace std;

namespace adb {

    InsertAccountCommand::InsertAccountCommand(sqlite3* database, const Account& account) :
        ReversibleDatabaseCommand(database), account_(account)
    {
        account_.validate();
    }

    void InsertAccountCommand::buildSqlCommand()
    {
        ostringstream sout;

        sout << "INSERT INTO [" << Configuration::TABLE_ACCOUNTS << "] ( ";
        sout << "[" << Configuration::COLUMN_TYPE << "], ";
        sout << "[" << Configuration::COLUMN_BALANCE << "], ";
        sout << "[" << Configuration::COLUMN_NAME << "], ";
        sout << "[" << Configuration::COLUMN_GROUP << "], ";
        sout << "[" << Configuration::COLUMN_COMMENT << "] ) ";
        sout << "VALUES ( ";
        sout << account_.getType() << ", ";
        sout << account_.getInitialValue() << ", ";
        sout << DbUtil::toDbParameter(account_.getName()) << ", ";
        sout << DbUtil::toDbParameter(account_.getGroup()) << ", ";
        sout << DbUtil::toDbParameter(account_.getDescription()) << " );" << endl;

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
