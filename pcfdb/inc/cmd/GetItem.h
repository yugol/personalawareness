#ifndef GETITEM_H_
#define GETITEM_H_

#include <DatabaseCommand.h>

class Item;

class GetItem: public DatabaseCommand {
public:
    GetItem(sqlite3* database, Item* item);

    virtual void execute();

protected:
    virtual void buildSqlCommand();
    virtual sqlite3_callback getCallbackFunction();
    virtual void* getCallbackParameter();

private:
    Item* item_;
};

#endif /* GETITEM_H_ */
