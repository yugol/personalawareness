#include <sstream>
#include <Configuration.h>
#include <cmd/GetItemCommand.h>
#include <cmd/UpdateItemCommand.h>

using namespace std;

namespace adb {

    UpdateItemCommand::UpdateItemCommand(sqlite3* database, const Item& item) :
        ReversibleDatabaseCommand(database), newItem_(item)
    {
        newItem_.validate();
        previousItem_.setId(newItem_.getId());
        GetItemCommand(database_, &previousItem_).execute();
    }

    void UpdateItemCommand::buildUpdateItemSqlCommand(string& sql, const Item& item)
    {
        ostringstream sout;

        sout << "UPDATE [" << Configuration::ITEMS_TABLE_NAME << "] ";
        sout << "SET ";
        sout << "[" << Configuration::NAME_COLUMN_NAME << "] = " << toParameter(item.getName()) << ", ";
        sout << "[" << Configuration::LASTR_COLUMN_NAME << "] = " << item.getLastTransactionId() << " ";
        sout << "WHERE [" << Configuration::ID_COLUMN_NAME << "] = " << item.getId() << ";" << endl;

        sql = sout.rdbuf()->str();
    }

    void UpdateItemCommand::buildSqlCommand()
    {
        buildUpdateItemSqlCommand(sql_, newItem_);
    }

    void UpdateItemCommand::buildReverseSqlCommand()
    {
        buildUpdateItemSqlCommand(reverseSql_, previousItem_);
    }

} // namespace adb
