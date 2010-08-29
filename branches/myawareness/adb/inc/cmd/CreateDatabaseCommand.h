#ifndef CREATEDATABASECOMMAND_H_
#define CREATEDATABASECOMMAND_H_

#include "DatabaseCommand.h"

namespace adb {

    class CreateDatabaseCommand: public DatabaseCommand {
    public:
        CreateDatabaseCommand(sqlite3* database);

    protected:
        virtual void buildSqlCommand();
    };

} // namespace adb

#endif /* CREATEDATABASECOMMAND_H_ */
