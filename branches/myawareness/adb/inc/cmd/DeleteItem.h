#ifndef DELETEITEM_H_
#define DELETEITEM_H_

#include <Item.h>
#include <ReversibleDatabaseCommand.h>

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

#endif /* DELETEITEM_H_ */
