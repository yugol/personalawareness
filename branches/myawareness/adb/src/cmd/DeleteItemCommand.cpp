#include <sstream>
#include <Configuration.h>
#include <cmd/GetItemCommand.h>
#include <cmd/DeleteItemCommand.h>

using namespace std;

namespace adb {

DeleteItemCommand::DeleteItemCommand(sqlite3* database, int id) :
    ReversibleDatabaseCommand(database), item_(id)
{
    // TODO: item in use
    GetItemCommand(database_, &item_).execute();
}

void DeleteItemCommand::buildSqlCommand()
{
    ostringstream sout;

    sout << "UPDATE [" << Configuration::ITEMS_TABLE_NAME << "] ";
    sout << "SET [" << Configuration::DEL_COLUMN_NAME << "] = '*' ";
    sout << "WHERE [" << Configuration::ID_COLUMN_NAME << "] = " << item_.getId() << ";" << endl;

    sql_ = sout.rdbuf()->str();
}

void DeleteItemCommand::buildReverseSqlCommand()
{
    ostringstream sout;

    sout << "UPDATE [" << Configuration::ITEMS_TABLE_NAME << "] ";
    sout << "SET [" << Configuration::DEL_COLUMN_NAME << "] = NULL ";
    sout << "WHERE [" << Configuration::ID_COLUMN_NAME << "] = " << item_.getId() << ";" << endl;

    reverseSql_ = sout.rdbuf()->str();
}

} // namespace adb
