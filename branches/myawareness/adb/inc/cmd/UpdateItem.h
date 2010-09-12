#ifndef UPDATEITEM_H_
#define UPDATEITEM_H_

#include <Item.h>
#include <ReversibleDatabaseCommand.h>

class UpdateItem: public ReversibleDatabaseCommand {
public:
    UpdateItem(sqlite3* database, const Item& item);

    virtual std::string getDescription() const;

protected:
    virtual void buildSqlCommand();
    virtual void buildReverseSqlCommand();

private:
    Item newItem_;
    Item previousItem_;

    void buildUpdateItemSqlCommand(std::string& sql, const Item& item);
};

#endif /* UPDATEITEM_H_ */
