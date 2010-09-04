#include <cstdio>
#include <Configuration.h>
#include <Exception.h>
#include <SelectionParameters.h>
#include <DbUtil.h>
#include <cmd/ReversibleDatabaseCommand.h>
#include <cmd/SelectTransactionsCommand.h>
#include <DatabaseConnection.h>

using namespace std;

namespace adb {

    bool DatabaseConnection::isAccountInUse(sqlite3* database, int accountId)
    {
        SelectionParameters parameters;
        parameters.setAccountId(accountId);
        parameters.setLastTransactionOnly(true); // TBD-: optim: not to sort transactions
        vector<int> selection;
        SelectTransactionsCommand(database, &selection, &parameters).execute();
        return selection.size() > 0;

    }

    bool DatabaseConnection::isItemInUse(sqlite3* database, int itemId)
    {
        SelectionParameters parameters;
        parameters.setItemId(itemId);
        parameters.setLastTransactionOnly(true); // TBD-: optim: not to sort transactions
        vector<int> selection;
        SelectTransactionsCommand(database, &selection, &parameters).execute();
        return selection.size() > 0;
    }

    DatabaseConnection* DatabaseConnection::instance_ = 0;

    bool DatabaseConnection::isOpened()
    {
        return 0 != instance_;
    }

    DatabaseConnection* DatabaseConnection::instance()
    {
        if (!isOpened()) {
            openDatabase(Configuration::instance()->getLastDatabasePath().c_str());
        }
        return instance_;
    }

    void DatabaseConnection::openDatabase(const char* databasePath)
    {
        DatabaseConnection* tmpInstance = 0;
        try {
            tmpInstance = new DatabaseConnection(databasePath);
            if (isOpened()) {
                if (instance_->getDatabaseLocation() == databasePath) {
                    return;
                }
                closeDatabase();
            }
            instance_ = tmpInstance;
            Configuration::instance()->setLastDatabasePath(databasePath);
        } catch (const exception& ex) {
            delete tmpInstance;
            RETHROW(ex);
        }
    }

    void DatabaseConnection::closeDatabase()
    {
        if (!isOpened()) {
            THROW(Exception::NO_DATABASE_MESSAGE);
        }
        delete instance_;
        instance_ = 0;
    }

    void DatabaseConnection::deleteDatabase()
    {
        if (!isOpened()) {
            THROW(Exception::NO_DATABASE_MESSAGE);
        }
        string databasePath = instance_->getDatabaseLocation();
        closeDatabase();
        if (0 != ::remove(databasePath.c_str())) {
            THROW("error deleting database");
        }
    }

    void DatabaseConnection::exportDatabase(ostream& out)
    {
        if (!isOpened()) {
            THROW(Exception::NO_DATABASE_MESSAGE);
        }
        instance_->dumpSql(out);
    }

    void DatabaseConnection::importDatabase(istream& in)
    {
        if (!isOpened()) {
            THROW(Exception::NO_DATABASE_MESSAGE);
        }
        string databasePath = instance_->getDatabaseLocation();
        deleteDatabase();
        openDatabase(databasePath.c_str());
        instance_->loadSql(in);
    }

    DatabaseConnection::DatabaseConnection(const char* file) :
        databaseLocation_(file), database_(0)
    {
        DbUtil::trimSpaces(databaseLocation_);
        if (databaseLocation_.size() <= 0) {
            THROW("invalid file name");
        }
        openConnection();
    }

    DatabaseConnection::~DatabaseConnection()
    {
        closeConnection();
    }

    void DatabaseConnection::openConnection()
    {
        if (::sqlite3_open_v2(databaseLocation_.c_str(), &database_, SQLITE_OPEN_READWRITE | SQLITE_OPEN_CREATE, NULL)) {
            closeConnection();
            THROW("can't read database");
        }

        switch (checkConnection()) {
            case OK:
                break;

            case EMPTY_DATABASE:
                if (OK != createNewDatabase()) {
                    THROW("error creating database");
                }
                break;

            default:
                closeConnection();
                THROW("error reading database");
        }
    }

    int DatabaseConnection::checkConnection()
    {
        const char* zSql = "SELECT * FROM sqlite_master WHERE type='table';";
        sqlite3_stmt* stmt = 0;

        int rc = ::sqlite3_prepare_v2(database_, zSql, 1000, &stmt, NULL);
        if (SQLITE_OK != rc) {
            ::sqlite3_finalize(stmt);
            return EMPTY_DATABASE;
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
                return STATEMENT_ERROR;
            }
        }

        if (0 == tableCount) {
            return EMPTY_DATABASE;
        }

        return OK;
    }

    void DatabaseConnection::closeConnection()
    {
        // TBD-: compact identical transactions in each day
        purgeDatabase();
        ::sqlite3_close(database_);
        database_ = 0;
    }

    void DatabaseConnection::undo()
    {
        ReversibleDatabaseCommand* cmd = undoManager_.undo();
        cmd->unexecute();
    }

    void DatabaseConnection::redo()
    {
        ReversibleDatabaseCommand* cmd = undoManager_.redo();
        cmd->execute();
    }

    bool DatabaseConnection::canUndo()
    {
        return undoManager_.canUndo();
    }

    bool DatabaseConnection::canRedo()
    {
        return undoManager_.canRedo();
    }

} // namespace adb
