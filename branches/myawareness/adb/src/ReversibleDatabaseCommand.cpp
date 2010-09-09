#include <Exception.h>
#include <ReversibleDatabaseCommand.h>

namespace adb {

    ReversibleDatabaseCommand::ReversibleDatabaseCommand(sqlite3* database) :
        DatabaseCommand(database)
    {
    }

    const char* ReversibleDatabaseCommand::getReverseSqlCommand()
    {
        if (reverseSql_.size() <= 0) {
            buildReverseSqlCommand();
        }
        if (reverseSql_.size() <= 0) {
            THROW(Exception::SQL_ERROR_MESSAGE);
        }
        return reverseSql_.c_str();
    }

    void ReversibleDatabaseCommand::unexecute()
    {
        if (SQLITE_OK != ::sqlite3_exec(database_, getReverseSqlCommand(), NULL, NULL, NULL)) {
            THROW(Exception::SQL_ERROR_MESSAGE);
        }
    }

} // namespac eadb
