#ifndef PURGEDATABASE_H_
#define PURGEDATABASE_H_

#include "DatabaseCommand.h"

namespace adb {

    class PurgeDatabase: public DatabaseCommand {
    public:
        PurgeDatabase(sqlite3* database);

    protected:
        virtual void buildSqlCommand();
    };

} // namespace adb

#endif /* PURGEDATABASE_H_ */
