#include <sstream>
#include <Exception.h>
#include <Configuration.h>
#include <DbUtil.h>
#include <cmd/DeleteAccount.h>
#include <cmd/UpdateAccount.h>
#include <cmd/InsertAccount.h>

using namespace std;

void InsertAccount::buildReverseSqlCommand(std::ostream& out, const Account& account)
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
    out << DbUtil::toDbParameter(account.getComment()) << " );" << endl;
}

InsertAccount::InsertAccount(sqlite3* database, const Account& account) :
    ReversibleDatabaseCommand(database), account_(account)
{
    account_.validate();
}

void InsertAccount::buildSqlCommand()
{
    ostringstream sout;
    buildReverseSqlCommand(sout, account_);
    sql_ = sout.rdbuf()->str();
}

void InsertAccount::buildReverseSqlCommand()
{
}

void InsertAccount::execute()
{
    if (0 == account_.getId()) {
        DatabaseCommand::execute();
        account_.setId(::sqlite3_last_insert_rowid(database_));
    } else {
        DeleteAccount deleteCmd(database_, account_.getId());
        deleteCmd.unexecute();
        UpdateAccount updateCmd(database_, account_);
        updateCmd.execute();
    }
}

void InsertAccount::unexecute()
{
    DeleteAccount cmd(database_, account_.getId());
    cmd.execute();
}

string InsertAccount::getDescription() const
{
    return "insert account";
}

