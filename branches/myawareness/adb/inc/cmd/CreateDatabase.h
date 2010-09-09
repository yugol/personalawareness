#ifndef CREATEDATABASE_H_
#define CREATEDATABASE_H_

#include <DatabaseCommand.h>

namespace adb {

    class CreateDatabase: public DatabaseCommand {
    public:
        CreateDatabase(sqlite3* database);

    protected:
        virtual void buildSqlCommand();
    };

} // namespace adb

#endif /* CREATEDATABASE_H_ */
