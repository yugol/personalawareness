#include <Exception.h>
#include <ReversibleDatabaseCommand.h>

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
        THROW(Exception::EMSG_SQL_ERROR);
    }
    return reverseSql_.c_str();
}

void ReversibleDatabaseCommand::unexecute()
{
    if (SQLITE_OK != ::sqlite3_exec(database_, getReverseSqlCommand(), NULL, NULL, NULL)) {
        THROW(Exception::EMSG_SQL_ERROR);
    }
}

