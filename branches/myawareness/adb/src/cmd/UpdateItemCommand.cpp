#include <sstream>
#include <Configuration.h>
#include <DbUtil.h>
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

        sout << "UPDATE [" << Configuration::TABLE_DESCRIPTIONS << "] ";
        sout << "SET ";
        sout << "[" << Configuration::COLUMN_NAME << "] = " << DbUtil::toParameter(item.getName()) << ", ";
        sout << "[" << Configuration::COLUMN_TRANSACTION << "] = " << item.getLastTransactionId() << " ";
        sout << "WHERE [" << Configuration::COLUMN_ID << "] = " << item.getId() << ";" << endl;

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
