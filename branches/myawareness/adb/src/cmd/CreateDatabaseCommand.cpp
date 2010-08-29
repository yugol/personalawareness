#include <sstream>
#include <Configuration.h>
#include <cmd/CreateDatabaseCommand.h>

using namespace std;

namespace adb {

    CreateDatabaseCommand::CreateDatabaseCommand(sqlite3* database) :
        DatabaseCommand(database)
    {
    }

    void CreateDatabaseCommand::buildSqlCommand()
    {
        ostringstream sout;

        sout << "CREATE TABLE [" << Configuration::ACCOUNTS_TABLE_NAME << "] (";
        sout << "[" << Configuration::ID_COLUMN_NAME << "] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, ";
        sout << "[" << Configuration::DEL_COLUMN_NAME << "] TEXT NULL, ";
        sout << "[" << Configuration::TYPE_COLUMN_NAME << "] INTEGER NOT NULL, ";
        sout << "[" << Configuration::NAME_COLUMN_NAME << "] TEXT NOT NULL, ";
        sout << "[" << Configuration::GROUP_COLUMN_NAME << "] TEXT, ";
        sout << "[" << Configuration::IVAL_COLUMN_NAME << "] REAL NOT NULL DEFAULT (0), ";
        sout << "[" << Configuration::DESC_COLUMN_NAME << "] TEXT);" << endl;

        sout << "CREATE UNIQUE INDEX [";
        sout << Configuration::ACCOUNTS_TABLE_NAME << Configuration::INDEX_SUFFIX;
        sout << "] on [" << Configuration::ACCOUNTS_TABLE_NAME << "] ([";
        sout << Configuration::ID_COLUMN_NAME << "] ASC);" << endl;

        sout << "CREATE TABLE [" << Configuration::ITEMS_TABLE_NAME << "] (";
        sout << "[" << Configuration::ID_COLUMN_NAME << "] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, ";
        sout << "[" << Configuration::DEL_COLUMN_NAME << "] TEXT NULL, ";
        sout << "[" << Configuration::NAME_COLUMN_NAME << "] TEXT NOT NULL, ";
        sout << "[" << Configuration::LASTR_COLUMN_NAME << "] INTEGER);" << endl;

        sout << "CREATE UNIQUE INDEX [";
        sout << Configuration::ITEMS_TABLE_NAME << Configuration::INDEX_SUFFIX;
        sout << "] on [" << Configuration::ITEMS_TABLE_NAME << "] ([";
        sout << Configuration::ID_COLUMN_NAME << "] ASC);" << endl;

        sout << "CREATE TABLE [" << Configuration::TRANSACTIONS_TABLE_NAME << "] (";
        sout << "[" << Configuration::ID_COLUMN_NAME << "] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, ";
        sout << "[" << Configuration::DEL_COLUMN_NAME << "] TEXT NULL, ";
        sout << "[" << Configuration::DATE_COLUMN_NAME << "] TEXT NOT NULL, ";
        sout << "[" << Configuration::VAL_COLUMN_NAME << "] REAL NOT NULL, ";
        sout << "[" << Configuration::FROM_COLUMN_NAME << "] INTEGER NOT NULL, ";
        sout << "[" << Configuration::TO_COLUMN_NAME << "] INTEGER NOT NULL, ";
        sout << "[" << Configuration::ITEM_COLUMN_NAME << "] INTEGER NOT NULL, ";
        sout << "[" << Configuration::DESC_COLUMN_NAME << "] TEXT);" << endl;

        sout << "CREATE UNIQUE INDEX [";
        sout << Configuration::TRANSACTIONS_TABLE_NAME << Configuration::INDEX_SUFFIX;
        sout << "] on [" << Configuration::TRANSACTIONS_TABLE_NAME << "] ([";
        sout << Configuration::ID_COLUMN_NAME << "] ASC);" << endl;

        sql_ = sout.rdbuf()->str();
    }

} // namespac eadb
