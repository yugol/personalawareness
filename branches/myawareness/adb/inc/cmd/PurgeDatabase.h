#ifndef PURGEDATABASE_H_
#define PURGEDATABASE_H_

#include <DatabaseCommand.h>

class PurgeDatabase: public DatabaseCommand {
public:
    PurgeDatabase(sqlite3* database);

protected:
    virtual void buildSqlCommand();
};

#endif /* PURGEDATABASE_H_ */
