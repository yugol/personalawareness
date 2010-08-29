#ifndef GETLASTTRANSACTIONCOMMAND_H_
#define GETLASTTRANSACTIONCOMMAND_H_

#include "DatabaseCommand.h"

namespace adb {

    class Item;

    class GetLastTransactionCommand: public DatabaseCommand {
    public:
        GetLastTransactionCommand(sqlite3* database, Item* item);

        int getId() const;

        virtual void execute();

    protected:
        virtual void buildSqlCommand();

    private:
        Item* item_;
        int id_;
    };

    inline int GetLastTransactionCommand::getId() const
    {
        return id_;
    }

} // namespace adb

#endif /* GETLASTTRANSACTIONCOMMAND_H_ */
