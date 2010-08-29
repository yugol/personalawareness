#ifndef DELETEITEMCOMMAND_H_
#define DELETEITEMCOMMAND_H_

#include <Item.h>
#include "ReversibleDatabaseCommand.h"

namespace adb {

    class DeleteItemCommand: public ReversibleDatabaseCommand {
    public:
        DeleteItemCommand(sqlite3* database, int id);

    protected:
        virtual void buildSqlCommand();
        virtual void buildReverseSqlCommand();

    private:
        Item item_;
    };

} // namespace adb

#endif /* DELETEITEMCOMMAND_H_ */
