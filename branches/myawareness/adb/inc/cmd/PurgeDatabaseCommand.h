#ifndef PURGEDATABASECOMMAND_H_
#define PURGEDATABASECOMMAND_H_

#include "DatabaseCommand.h"

namespace adb {

    class PurgeDatabaseCommand: public DatabaseCommand {
    public:
        PurgeDatabaseCommand(sqlite3* database);

    protected:
        virtual void buildSqlCommand();
    };

} // namespace adb

#endif /* PURGEDATABASECOMMAND_H_ */
