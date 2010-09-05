#ifndef INSERTITEMCOMMAND_H_
#define INSERTITEMCOMMAND_H_

#include <Item.h>
#include "ReversibleDatabaseCommand.h"

namespace adb {

    class InsertItemCommand: public ReversibleDatabaseCommand {
    public:
        static void buildSqlCommand(std::ostream& out, const Item& item, bool dump);

        InsertItemCommand(sqlite3* database, const Item& item);

        const Item& getItem() const;

        virtual void execute();
        virtual void unexecute();

    protected:
        virtual void buildSqlCommand();
        virtual void buildReverseSqlCommand();

    private:
        Item item_;
    };

    inline const Item& InsertItemCommand::getItem() const
    {
        return item_;
    }

} // namespace adb

#endif /* INSERTITEMCOMMAND_H_ */
