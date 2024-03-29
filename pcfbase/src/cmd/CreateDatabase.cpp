#include <sstream>
#include <Configuration.h>
#include <BaseUtil.h>
#include <cmd/CreateDatabase.h>

using namespace std;

CreateDatabase::CreateDatabase(sqlite3* database) :
	DatabaseCommand(database)
{
}

void CreateDatabase::buildSqlCommand()
{
	ostringstream sout;

	sout << "BEGIN;" << endl;

	sout << "CREATE TABLE [" << Configuration::TABLE_ACCOUNTS << "] (";
	sout << "[" << Configuration::COLUMN_ID << "] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, ";
	sout << "[" << Configuration::COLUMN_DELETED << "] TEXT NULL, ";
	sout << "[" << Configuration::COLUMN_TYPE << "] INTEGER NOT NULL, ";
	sout << "[" << Configuration::COLUMN_NAME << "] TEXT NOT NULL, ";
	sout << "[" << Configuration::COLUMN_GROUP << "] TEXT, ";
	sout << "[" << Configuration::COLUMN_BALANCE << "] REAL NOT NULL DEFAULT (0), ";
	sout << "[" << Configuration::COLUMN_COMMENT << "] TEXT);" << endl;

	sout << "CREATE UNIQUE INDEX [";
	sout << Configuration::TABLE_ACCOUNTS << Configuration::INDEX_MARKER;
	sout << "] on [" << Configuration::TABLE_ACCOUNTS << "] ([";
	sout << Configuration::COLUMN_ID << "] ASC);" << endl;

	sout << "CREATE TABLE [" << Configuration::TABLE_ITEMS << "] (";
	sout << "[" << Configuration::COLUMN_ID << "] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, ";
	sout << "[" << Configuration::COLUMN_DELETED << "] TEXT NULL, ";
	sout << "[" << Configuration::COLUMN_NAME << "] TEXT NOT NULL);" << endl;

	sout << "CREATE UNIQUE INDEX [";
	sout << Configuration::TABLE_ITEMS << Configuration::INDEX_MARKER;
	sout << "] on [" << Configuration::TABLE_ITEMS << "] ([";
	sout << Configuration::COLUMN_ID << "] ASC);" << endl;

	sout << "CREATE TABLE [" << Configuration::TABLE_TRANSACTIONS << "] (";
	sout << "[" << Configuration::COLUMN_ID << "] INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, ";
	sout << "[" << Configuration::COLUMN_DELETED << "] TEXT NULL, ";
	sout << "[" << Configuration::COLUMN_DATE << "] TEXT NOT NULL, ";
	sout << "[" << Configuration::COLUMN_VALUE << "] REAL NOT NULL, ";
	sout << "[" << Configuration::COLUMN_SOURCE << "] INTEGER NOT NULL, ";
	sout << "[" << Configuration::COLUMN_DESTINATION << "] INTEGER NOT NULL, ";
	sout << "[" << Configuration::COLUMN_ITEM << "] INTEGER NOT NULL, ";
	sout << "[" << Configuration::COLUMN_COMMENT << "] TEXT);" << endl;

	sout << "CREATE UNIQUE INDEX [";
	sout << Configuration::TABLE_TRANSACTIONS << Configuration::INDEX_MARKER;
	sout << "] on [" << Configuration::TABLE_TRANSACTIONS << "] ([";
	sout << Configuration::COLUMN_ID << "] ASC);" << endl;

	sout << "CREATE TABLE [" << Configuration::TABLE_PREFERENCES << "] (";
	sout << "[" << Configuration::COLUMN_NAME << "] TEXT NOT NULL, ";
	sout << "[" << Configuration::COLUMN_VALUE << "] TEXT NOT NULL);";

	sout << "INSERT INTO [" << Configuration::TABLE_PREFERENCES << "] ( ";
	sout << "[" << Configuration::COLUMN_NAME << "], ";
	sout << "[" << Configuration::COLUMN_VALUE << "] ) VALUES ( '";
	sout << Configuration::PREF_PROJECT_MARKER << "', ";
	sout << BaseUtil::toDbParameter(Configuration::PROJECT_MARKER) << " );" << endl;

	sout << "INSERT INTO [" << Configuration::TABLE_PREFERENCES << "] ( ";
	sout << "[" << Configuration::COLUMN_NAME << "], ";
	sout << "[" << Configuration::COLUMN_VALUE << "] ) VALUES ( '";
	sout << Configuration::PREF_DATABASE_VERSION << "', ";
	sout << BaseUtil::toDbParameter(Configuration::PROJECT_DATABASE_VERSION) << " );" << endl;

	sout << "INSERT INTO [" << Configuration::TABLE_PREFERENCES << "] ( ";
	sout << "[" << Configuration::COLUMN_NAME << "], ";
	sout << "[" << Configuration::COLUMN_VALUE << "] ) VALUES ( '";
	sout << Configuration::PREF_CURRENCY_SYMBOL << "', ";
	sout << BaseUtil::toDbParameter(Configuration::DEFAULT_CURRENCY_SYMBOL) << " );" << endl;

	sout << "INSERT INTO [" << Configuration::TABLE_PREFERENCES << "] ( ";
	sout << "[" << Configuration::COLUMN_NAME << "], ";
	sout << "[" << Configuration::COLUMN_VALUE << "] ) VALUES ( '";
	sout << Configuration::PREF_PREFIX_CURRENCY << "', '";
	sout << Configuration::DEFAULT_PREFIX_CURRENCY << "' );" << endl;

	sout << "INSERT INTO [" << Configuration::TABLE_PREFERENCES << "] ( ";
	sout << "[" << Configuration::COLUMN_NAME << "], ";
	sout << "[" << Configuration::COLUMN_VALUE << "] ) VALUES ( '";
	sout << Configuration::PREF_COMPACT_TRNSACTIONS << "', '";
	sout << Configuration::DEFAULT_COMPACT_TRNSACTIONS << "' );" << endl;

	sout << "INSERT INTO [" << Configuration::TABLE_PREFERENCES << "] ( ";
	sout << "[" << Configuration::COLUMN_NAME << "], ";
	sout << "[" << Configuration::COLUMN_VALUE << "] ) VALUES ( '";
	sout << Configuration::PREF_COMPARE_ASCII_ONLY << "', '";
	sout << Configuration::DEFAULT_COMPARE_ASCII_ONLY << "' );" << endl;

	sout << "INSERT INTO [" << Configuration::TABLE_PREFERENCES << "] ( ";
	sout << "[" << Configuration::COLUMN_NAME << "], ";
	sout << "[" << Configuration::COLUMN_VALUE << "] ) VALUES ( '";
	sout << Configuration::PREF_HIDE_ZERO_BALANCE_ACCOUNTS << "', '";
	sout << Configuration::DEFAULT_HIDE_ZERO_BALANCE_ACCOUNTS << "' );" << endl;

	sout << "COMMIT;" << endl;

	sql_ = sout.rdbuf()->str();
}

