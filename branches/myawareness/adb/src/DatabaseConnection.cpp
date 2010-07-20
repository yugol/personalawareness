#include <cstdio>
#include <DatabaseConnection.h>
#include <util.h>

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
			closeDatabase();
		}
		instance_ = tmpInstance;
		Configuration::instance()->setLastDatabasePath(databasePath);
	} catch (const exception& ex) {
		delete tmpInstance;
		throw Exception(ex.what());
	}
}

void DatabaseConnection::closeDatabase()
{
	if (0 == instance_) {
		throw Exception("no opened database");
	}
	delete instance_;
	instance_ = 0;
}

void DatabaseConnection::deleteDatabase()
{
	if (0 == instance_) {
		throw Exception("no opened database");
	}
	string databasePath = instance_->getDatabaseFile();
	closeDatabase();
	if (0 != ::remove(databasePath.c_str())) {
		throw Exception("error deleting database");
	}
}

void DatabaseConnection::exportDatabase(std::ostream& out)
{
	if (0 == instance_) {
		throw Exception("no opened database");
	}
	instance_->dumpSql(out);
}

void DatabaseConnection::importDatabase(std::istream& in, LoadSqlCommand* callback)
{
	if (0 == instance_) {
		throw Exception("no opened database");
	}
	string databasePath = instance_->getDatabaseFile();
	deleteDatabase();
	openDatabase(databasePath.c_str());
	instance_->loadSql(in, callback);
}

DatabaseConnection::DatabaseConnection(const char* file) :
	databaseFile_(file), database_(0)
{
	trimSpaces(databaseFile_);
	if (databaseFile_.size() <= 0) {
		throw Exception("invalid file name");
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
		throw Exception("can't read database");
	}

	switch (checkConnection()) {
	case OK:
		break;

	case EMPTY_DATABASE:
		if (OK != createNewDatabase()) {
			throw Exception("error creating database");
		}
		break;

	default:
		closeConnection();
		throw Exception("error reading database");
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
	::sqlite3_close(database_);
	database_ = 0;
}

} // namespace adb
