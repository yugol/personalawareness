#ifndef GETITEMCOMMAND_H_
#define GETITEMCOMMAND_H_

#include "DatabaseCommand.h"

namespace adb {

    class Item;

    class GetItemCommand: public DatabaseCommand {
    public:
        GetItemCommand(sqlite3* database, Item* item);

        virtual void execute();

    protected:
        virtual void buildSqlCommand();
        virtual sqlite3_callback getCallbackFunction();
        virtual void* getCallbackParameter();

    private:
        Item* item_;
    };

} // namespace adb

#endif /* GETITEMCOMMAND_H_ */
