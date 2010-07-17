#include <cstdio>
#include <DatabaseConnection.h>

using namespace std;

namespace adb {

DatabaseConnection::DatabaseConnection(const char* file) :
	databaseFile_(file), database_(0)
{
	openDatabase();
}

DatabaseConnection::~DatabaseConnection()
{
	closeDatabase();
}

void DatabaseConnection::openDatabase()
{
	if (::sqlite3_open_v2(databaseFile_.c_str(), &database_, SQLITE_OPEN_READWRITE | SQLITE_OPEN_CREATE, NULL)) {
		closeDatabase();
		throw new string("can't read database");
	}

	switch (checkDatabase()) {
	case OK:
		break;

	case EMPTY_DATABASE:
		if (OK != createNewDatabase()) {
			throw new string("error creating database");
		}
		break;

	default:
		closeDatabase();
		throw new string("error reading database");
	}
}

void DatabaseConnection::checkConnection()
{
	if (0 == database_) {
		throw new string("no connection");
	}
}

int DatabaseConnection::checkDatabase()
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

void DatabaseConnection::closeDatabase()
{
	::sqlite3_close(database_);
	database_ = 0;
}

void DatabaseConnection::deleteDatabase()
{
	checkConnection();
	closeDatabase();
	if (0 != ::remove(databaseFile_.c_str())) {
		throw new string("error deleting database");
	}
}

} // namespace adb