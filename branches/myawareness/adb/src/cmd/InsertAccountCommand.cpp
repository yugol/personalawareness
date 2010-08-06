#include <sstream>
#include <Exception.h>
#include <Configuration.h>
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

	sout << "INSERT INTO [" << Configuration::ACCOUNTS_TABLE_NAME << "] ( ";
	sout << "[" << Configuration::TYPE_COLUMN_NAME << "], ";
	sout << "[" << Configuration::IVAL_COLUMN_NAME << "], ";
	sout << "[" << Configuration::NAME_COLUMN_NAME << "], ";
	sout << "[" << Configuration::GROUP_COLUMN_NAME << "], ";
	sout << "[" << Configuration::DESC_COLUMN_NAME << "] ) ";
	sout << "VALUES ( ";
	sout << account_.getType() << ", ";
	sout << account_.getInitialValue() << ", ";
	sout << toParameter(account_.getName()) << ", ";
	sout << toParameter(account_.getGroup()) << ", ";
	sout << toParameter(account_.getDescription()) << " );" << endl;

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
