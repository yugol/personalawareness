#include <sstream>
#include <Configuration.h>
#include <DbUtil.h>
#include <cmd/GetItem.h>
#include <cmd/UpdateItem.h>

using namespace std;

namespace adb {

    UpdateItem::UpdateItem(sqlite3* database, const Item& item) :
        ReversibleDatabaseCommand(database), newItem_(item)
    {
        newItem_.validate();
        previousItem_.setId(newItem_.getId());
        GetItem(database_, &previousItem_).execute();
    }

    void UpdateItem::buildUpdateItemSqlCommand(string& sql, const Item& item)
    {
        ostringstream sout;

        sout << "UPDATE [" << Configuration::TABLE_ITEMS << "] ";
        sout << "SET ";
        sout << "[" << Configuration::COLUMN_NAME << "] = " << DbUtil::toDbParameter(item.getName()) << ", ";
        sout << "[" << Configuration::COLUMN_TRANSACTION << "] = " << item.getLastTransactionId() << " ";
        sout << "WHERE [" << Configuration::COLUMN_ID << "] = " << item.getId() << ";" << endl;

        sql = sout.rdbuf()->str();
    }

    void UpdateItem::buildSqlCommand()
    {
        buildUpdateItemSqlCommand(sql_, newItem_);
    }

    void UpdateItem::buildReverseSqlCommand()
    {
        buildUpdateItemSqlCommand(reverseSql_, previousItem_);
    }

} // namespace adb
