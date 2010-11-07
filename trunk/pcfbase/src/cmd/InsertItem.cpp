#include <sstream>
#include <Exception.h>
#include <Configuration.h>
#include <BaseUtil.h>
#include <cmd/DeleteItem.h>
#include <cmd/UpdateItem.h>
#include <cmd/InsertItem.h>

using namespace std;

void InsertItem::buildSqlCommand(ostream& out, const Item& item)
{
	out << "INSERT INTO [" << Configuration::TABLE_ITEMS << "] ( ";
	out << "[" << Configuration::COLUMN_NAME << "]";
	out << " ) VALUES ( ";
	out << BaseUtil::toDbParameter(item.getName());
	out << " );" << endl;
}

InsertItem::InsertItem(sqlite3* database, const Item& item) :
	ReversibleDatabaseCommand(database), item_(item)
{
	item_.validate();
}

void InsertItem::buildSqlCommand()
{
	ostringstream sout;
	buildSqlCommand(sout, item_);
	sql_ = sout.rdbuf()->str();
}

void InsertItem::buildReverseSqlCommand()
{
}

void InsertItem::execute()
{
	if (0 == item_.getId()) {
		DatabaseCommand::execute();
		item_.setId(::sqlite3_last_insert_rowid(database_));
	} else {
		DeleteItem deleteCmd(database_, item_.getId());
		deleteCmd.unexecute();
		UpdateItem updateCmd(database_, item_);
		updateCmd.execute();
	}
}

void InsertItem::unexecute()
{
	DeleteItem cmd(database_, item_.getId());
	cmd.execute();
}

string InsertItem::getDescription() const
{
	return "insert item";
}

