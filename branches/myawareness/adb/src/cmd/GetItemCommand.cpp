#include <cstdlib>
#include <sstream>
#include <Exception.h>
#include <Configuration.h>
#include <Item.h>
#include <cmd/GetLastTransactionCommand.h>
#include <cmd/GetItemCommand.h>

using namespace std;

namespace adb {

    GetItemCommand::GetItemCommand(sqlite3* database, Item* item) :
        DatabaseCommand(database), item_(item)
    {
    }

    static int readItem(void *param, int colCount, char **values, char **names)
    {
        Item* item = reinterpret_cast<Item*> (param);

        item->setId(::atoi(values[0]));
        item->setName(values[1]);
        item->setLastTransactionId(values[2] ? ::atoi(values[2]) : 0);

        return 0;
    }

    sqlite3_callback GetItemCommand::getCallbackFunction()
    {
        return readItem;
    }

    void* GetItemCommand::getCallbackParameter()
    {
        return item_;
    }

    void GetItemCommand::buildSqlCommand()
    {
        ostringstream sout;

        sout << "SELECT ";
        sout << "[" << Configuration::ID_COLUMN_NAME << "], ";
        sout << "[" << Configuration::NAME_COLUMN_NAME << "], ";
        sout << "[" << Configuration::LASTR_COLUMN_NAME << "] ";
        sout << "FROM [" << Configuration::ITEMS_TABLE_NAME << "] ";
        sout << "WHERE [" << Configuration::ID_COLUMN_NAME << "] = " << item_->getId() << ";" << endl;

        sql_ = sout.rdbuf()->str();
    }

    void GetItemCommand::execute()
    {
        buildSqlCommand();
        int tempId = item_->getId();
        item_->setId(0);
        DatabaseCommand::execute();
        if (tempId != item_->getId()) {
            item_->setId(tempId);
            THROW(Exception::NO_RECORD_MESSAGE);
        }
        if (item_->getLastTransactionId() == 0) {
            GetLastTransactionCommand cmd(database_, item_);
            cmd.execute();
            item_->setLastTransactionId(cmd.getId());
        }
    }

} // namespace adb
