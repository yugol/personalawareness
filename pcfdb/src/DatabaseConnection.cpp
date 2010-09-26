#include <Configuration.h>
#include <Exception.h>
#include <DbUtil.h>
#include <ReversibleDatabaseCommand.h>
#include <cmd/CreateDatabase.h>
#include <cmd/SelectPreferences.h>
#include <cmd/PurgeDatabase.h>
#include <DatabaseConnection.h>

using namespace std;

DatabaseConnection::DatabaseConnection(const char* location) :
    database_(0)
{
    DbUtil::charPtrToString(databaseLocation_, location);
    DbUtil::trimSpaces(databaseLocation_);
    if (databaseLocation_.size() <= 0) {
        THROW("invalid file name");
    }
    openConnection();
}

DatabaseConnection::~DatabaseConnection()
{
    closeConnection(true);
}

void DatabaseConnection::openConnection()
{
    if (::sqlite3_open_v2(databaseLocation_.c_str(), &database_, SQLITE_OPEN_READWRITE | SQLITE_OPEN_CREATE, NULL)) {
        closeConnection(false);
        THROW("can't read database");
    }

    int tableCount = getTableCount();

    if (tableCount == 0) {
        createNewDatabase();
    } else if (tableCount > 0) {
        SelectPreferences prefs(database_);
        prefs.execute();

        if (prefs[Configuration::PREF_PROJECT_MARKER] != Configuration::PROJECT_MARKER) {
            closeConnection(false);
            THROW("the database is not supported by this version of the application");
        }

        // TBD: check database version

        readPreferences(prefs);
    } else {
        closeConnection(false);
        THROW("error reading database");
    }
}

void DatabaseConnection::createNewDatabase()
{
    CreateDatabase(database_).execute();
}

void DatabaseConnection::purgeDatabase()
{
    PurgeDatabase(database_).execute(); // TBD-: - optional via preferences
    // TBD-: remove unused items - optional via preferences
    // TBD-: compact identical transactions in each day - optional via preferences
}

int DatabaseConnection::getTableCount()
{
    // TBD-: use a command

    sqlite3_stmt* stmt = 0;
    const char* zSql = "SELECT * FROM sqlite_master WHERE type='table';";
    int rc = ::sqlite3_prepare_v2(database_, zSql, 1000, &stmt, NULL);
    if (SQLITE_OK != rc) {
        ::sqlite3_finalize(stmt);
        return 0;
    }

    int tableCount = 0;
    while (true) {
        rc = ::sqlite3_step(stmt);
        if (SQLITE_ROW == rc) {
            ++tableCount;
        } else if (SQLITE_DONE == rc) {
            break;
        } else {
            ::sqlite3_finalize(stmt);
            return -1;
        }
    }
    return tableCount;
}

void DatabaseConnection::closeConnection(bool purge)
{
    undoBuffer_.reset();
    if (database_ != 0) {
        if (purge) {
            purgeDatabase();
        }
        writePreferences(database_);
        ::sqlite3_close(database_);
        database_ = 0;
    }
}

void DatabaseConnection::invalidateAccounts() const
{
    accounts_.clear();
}

void DatabaseConnection::invalidateItems() const
{
    items_.clear();
}

void DatabaseConnection::invalidateCash() const
{
    invalidateAccounts();
    invalidateItems();
}

void DatabaseConnection::undo()
{
    undoBuffer_.undo();
    invalidateCash();
}

void DatabaseConnection::redo()
{
    undoBuffer_.redo();
    invalidateCash();
}

const ReversibleDatabaseCommand* DatabaseConnection::getUndo()
{
    return undoBuffer_.getUndo();
}

const ReversibleDatabaseCommand* DatabaseConnection::getRedo()
{
    return undoBuffer_.getRedo();
}
