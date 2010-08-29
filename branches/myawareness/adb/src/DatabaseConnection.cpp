#include <cstdio>
#include <Configuration.h>
#include <Exception.h>
#include <DbUtil.h>
#include <cmd/ReversibleDatabaseCommand.h>
#include <DatabaseConnection.h>

using namespace std;

namespace adb {

    DatabaseConnection* DatabaseConnection::instance_ = 0;

    DatabaseConnection* DatabaseConnection::instance()
    {
        if (0 == instance_) {
            openDatabase(Configuration::instance()->getLastDatabasePath().c_str());
        }
        return instance_;
    }

    void DatabaseConnection::openDatabase(const char* databasePath)
    {
        DatabaseConnection* tmpInstance = 0;
        try {
            tmpInstance = new DatabaseConnection(databasePath);
            if (0 != instance_) {
                if (instance_->getDatabaseFile() == databasePath) {
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
        if (0 == instance_) {
            THROW(Exception::NO_DATABASE_MESSAGE);
        }
        delete instance_;
        instance_ = 0;
    }

    void DatabaseConnection::deleteDatabase()
    {
        if (0 == instance_) {
            THROW(Exception::NO_DATABASE_MESSAGE);
        }
        string databasePath = instance_->getDatabaseFile();
        closeDatabase();
        if (0 != ::remove(databasePath.c_str())) {
            THROW("error deleting database");
        }
    }

    void DatabaseConnection::exportDatabase(std::ostream& out)
    {
        if (0 == instance_) {
            THROW(Exception::NO_DATABASE_MESSAGE);
        }
        instance_->dumpSql(out);
    }

    void DatabaseConnection::importDatabase(std::istream& in, LoadSqlCommand* callback)
    {
        if (0 == instance_) {
            THROW(Exception::NO_DATABASE_MESSAGE);
        }
        string databasePath = instance_->getDatabaseFile();
        deleteDatabase();
        openDatabase(databasePath.c_str());
        instance_->loadSql(in, callback);
    }

    DatabaseConnection::DatabaseConnection(const char* file) :
        databaseFile_(file), database_(0)
    {
        DbUtil::trimSpaces(databaseFile_);
        if (databaseFile_.size() <= 0) {
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
        if (::sqlite3_open_v2(databaseFile_.c_str(), &database_, SQLITE_OPEN_READWRITE | SQLITE_OPEN_CREATE, NULL)) {
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
                // printf("%s\n", sqlite3_column_text(stmt, 1));
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
        // TODO: compact identical transactions in each day
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
