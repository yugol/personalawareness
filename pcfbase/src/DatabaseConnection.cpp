#include <Configuration.h>
#include <Exception.h>
#include <BaseUtil.h>
#include <ReversibleDatabaseCommand.h>
#include <cmd/GetMetadata.h>
#include <cmd/CreateDatabase.h>
#include <cmd/CleanDatabase.h>
#include <cmd/SelectPreferences.h>
#include <cmd/PurgeDatabase.h>
#include <DatabaseConnection.h>

using namespace std;

DatabaseConnection::DatabaseConnection(const char* location) :
    database_(0)
{
    BaseUtil::charPtrToString(databaseLocation_, location);
    BaseUtil::trimSpaces(databaseLocation_);
    if (databaseLocation_.size() <= 0) {
        THROW("invalid file name");
    }
    try {
        openConnection();
    } catch (const exception& ex) {
        RETHROW(ex);
    }
}

DatabaseConnection::~DatabaseConnection()
{
    try {
        closeConnection(true);
    } catch (const exception& ex) {
        RETHROW(ex);
    }
}

void DatabaseConnection::openConnection()
{
    if (::sqlite3_open_v2(databaseLocation_.c_str(), &database_, SQLITE_OPEN_READWRITE
            | SQLITE_OPEN_CREATE, NULL)) {
        closeConnection(false);
        THROW(BaseUtil::EMSG_WRONG_DATABASE);
    }

    try {
        GetMetadata metadata(database_);
        metadata.execute();
        if (metadata.isEmpty()) {
            createDatabase();
        } else {
            SelectPreferences prefs(database_);
            prefs.execute();

            if (prefs[Configuration::PREF_PROJECT_MARKER] != Configuration::PROJECT_MARKER) {
                closeConnection(false);
                THROW(BaseUtil::EMSG_INCOMPATIBLE_DATABASE);
            }

            readPreferences(prefs);
        }
    } catch (const exception& ex) {
        closeConnection(false);
        RETHROW(ex);
    }
}

void DatabaseConnection::closeConnection(bool purge)
{
    try {
        undoBuffer_.reset();
        if (database_ != 0) {
            GetMetadata metadata(database_);
            metadata.execute();
            if (!metadata.isEmpty()) {
                if (purge) {
                    purgeDatabase();
                }
                writePreferences(database_);
            }
            ::sqlite3_close(database_);
            database_ = 0;
        }
    } catch (const exception& ex) {
        RETHROW(ex);
    }
}

void DatabaseConnection::createDatabase()
{
    try {
        CreateDatabase cmd(database_);
        cmd.execute();
    } catch (const exception& ex) {
        RETHROW(ex);
    }
}

/**
 * deletes records marked as deleted
 */
void DatabaseConnection::purgeDatabase()
{
    try {
        PurgeDatabase cmd(database_);
        cmd.execute();
    } catch (const exception& ex) {
        RETHROW(ex);
    }
}

void DatabaseConnection::cleanDatabase()
{
    try {
        undoBuffer_.reset();
        if (database_ != 0) {
            CleanDatabase cmd(database_);
            cmd.execute();
        }
    } catch (const exception& ex) {
        RETHROW(ex);
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

void DatabaseConnection::check(OptimizationReport* report)
{
    cashItems();
    map<int, Item>::const_iterator it = items_.begin();
    while (it != items_.end()) {
        int itemId = it->first;
        if (!isItemInUse(itemId)) {
            report->addUnusedItemId(itemId);
        }
        ++it;
    }
}

void DatabaseConnection::optimize(const OptimizationReport* report)
{
    if (report->isRemoveUnusedItems()) {
        for (size_t i = 0; i < report->getUnusedItemsCount(); ++i) {
            deleteItem(report->getUnusedItemId(i));
        }
    }
}

