#ifndef CREATEDATABASE_H_
#define CREATEDATABASE_H_

#include <DatabaseCommand.h>

class CreateDatabase: public DatabaseCommand {
public:
    CreateDatabase(sqlite3* database);

protected:
    virtual void buildSqlCommand();
};

#endif /* CREATEDATABASE_H_ */
