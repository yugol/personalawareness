#include <cstdlib>
#include <sstream>
#include <Exception.h>
#include <Configuration.h>
#include <Item.h>
#include <cmd/GetLastTransaction.h>
#include <cmd/GetItem.h>

using namespace std;

GetItem::GetItem(sqlite3* database, Item* item) :
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

sqlite3_callback GetItem::getCallbackFunction()
{
    return readItem;
}

void* GetItem::getCallbackParameter()
{
    return item_;
}

void GetItem::buildSqlCommand()
{
    ostringstream sout;

    sout << "SELECT ";
    sout << "[" << Configuration::COLUMN_ID << "], ";
    sout << "[" << Configuration::COLUMN_NAME << "], ";
    sout << "[" << Configuration::COLUMN_TRANSACTION << "] ";
    sout << "FROM [" << Configuration::TABLE_ITEMS << "] ";
    sout << "WHERE [" << Configuration::COLUMN_ID << "] = " << item_->getId() << ";" << endl;

    sql_ = sout.rdbuf()->str();
}

void GetItem::execute()
{
    buildSqlCommand();
    int tempId = item_->getId();
    item_->setId(0);
    DatabaseCommand::execute();
    if (tempId != item_->getId()) {
        item_->setId(tempId);
        THROW(Exception::EMSG_NO_RECORD);
    }
    if (item_->getLastTransactionId() == 0) {
        GetLastTransaction cmd(database_, item_);
        cmd.execute();
        item_->setLastTransactionId(cmd.getId());
    }
}

