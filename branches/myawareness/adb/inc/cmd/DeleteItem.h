#ifndef DELETEITEM_H_
#define DELETEITEM_H_

#include <Item.h>
#include <ReversibleDatabaseCommand.h>

namespace adb {

    class DeleteItem: public ReversibleDatabaseCommand {
    public:
        DeleteItem(sqlite3* database, int id);

        virtual std::string getDescription() const;

    protected:
        virtual void buildSqlCommand();
        virtual void buildReverseSqlCommand();

    private:
        Item item_;
    };

} // namespace adb

#endif /* DELETEITEM_H_ */
