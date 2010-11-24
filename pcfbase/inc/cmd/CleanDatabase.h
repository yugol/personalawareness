#ifndef CLEANDATABASE_H_
#define CLEANDATABASE_H_

#include <DatabaseCommand.h>

class CleanDatabase: public DatabaseCommand {
public:
    CleanDatabase(sqlite3* database);

protected:
    virtual void buildSqlCommand();
};

#endif /* CLEANDATABASE_H_ */
