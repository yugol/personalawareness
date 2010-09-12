#ifndef GETLASTTRANSACTION_H_
#define GETLASTTRANSACTION_H_

#include <DatabaseCommand.h>

class Item;

class GetLastTransaction: public DatabaseCommand {
public:
    GetLastTransaction(sqlite3* database, Item* item);

    int getId() const;

    virtual void execute();

protected:
    virtual void buildSqlCommand();

private:
    Item* item_;
    int id_;
};

inline int GetLastTransaction::getId() const
{
    return id_;
}

#endif /* GETLASTTRANSACTION_H_ */
