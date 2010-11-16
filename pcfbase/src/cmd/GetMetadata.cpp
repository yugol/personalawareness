#include <Exception.h>
#include <BaseUtil.h>
#include <cmd/GetMetadata.h>

GetMetadata::GetMetadata(sqlite3* database) :
    DatabaseCommand(database), tableCount_(0)
{
}

void GetMetadata::buildSqlCommand()
{
}

void GetMetadata::execute()
{
    tableCount_ = 0;

    sqlite3_stmt* stmt = 0;
    const char* zSql = "SELECT * FROM sqlite_master WHERE type='table';";
    int rc = ::sqlite3_prepare_v2(database_, zSql, 1000, &stmt, NULL);
    if (SQLITE_OK != rc) {
        ::sqlite3_finalize(stmt);
        return;
    }

    while (true) {
        rc = ::sqlite3_step(stmt);
        if (SQLITE_ROW == rc) {
            ++tableCount_;
        } else if (SQLITE_DONE == rc) {
            break;
        } else {
            ::sqlite3_finalize(stmt);
            THROW(BaseUtil::EMSG_SQL_ERROR);
        }
    }
}

