#include <sstream>
#include <Configuration.h>
#include <BaseUtil.h>
#include <Exception.h>
#include <DatabaseConnection.h>
#include <cmd/GetItem.h>
#include <cmd/DeleteItem.h>

using namespace std;

DeleteItem::DeleteItem(sqlite3* database, int id) :
    ReversibleDatabaseCommand(database), item_(id)
{
    if (DatabaseConnection::isItemInUse(database_, id)) {
        THROW(BaseUtil::EMSG_RECORD_IN_USE);
    }
    GetItem(database_, &item_).execute();
}

void DeleteItem::buildSqlCommand()
{
    ostringstream sout;

    sout << "UPDATE [" << Configuration::TABLE_ITEMS << "] ";
    sout << "SET [" << Configuration::COLUMN_DELETED << "] = '*' ";
    sout << "WHERE [" << Configuration::COLUMN_ID << "] = " << item_.getId() << ";" << endl;

    sql_ = sout.rdbuf()->str();
}

void DeleteItem::buildReverseSqlCommand()
{
    ostringstream sout;

    sout << "UPDATE [" << Configuration::TABLE_ITEMS << "] ";
    sout << "SET [" << Configuration::COLUMN_DELETED << "] = NULL ";
    sout << "WHERE [" << Configuration::COLUMN_ID << "] = " << item_.getId() << ";" << endl;

    reverseSql_ = sout.rdbuf()->str();
}

string DeleteItem::getDescription() const
{
    return "delete item";
}

