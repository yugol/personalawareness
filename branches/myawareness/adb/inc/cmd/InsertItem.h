#ifndef INSERTITEM_H_
#define INSERTITEM_H_

#include <Item.h>
#include <ReversibleDatabaseCommand.h>

namespace adb {

    class InsertItem: public ReversibleDatabaseCommand {
    public:
        static void buildSqlCommand(std::ostream& out, const Item& item, bool dump);

        InsertItem(sqlite3* database, const Item& item);

        const Item& getItem() const;

        virtual void execute();
        virtual void unexecute();

        virtual std::string getDescription() const;

    protected:
        virtual void buildSqlCommand();
        virtual void buildReverseSqlCommand();

    private:
        Item item_;
    };

    inline const Item& InsertItem::getItem() const
    {
        return item_;
    }

} // namespace adb

#endif /* INSERTITEM_H_ */
