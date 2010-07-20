#include <Exception.h>
#include <cmd/DatabaseCommand.h>

namespace adb {

DatabaseCommand::DatabaseCommand(sqlite3* database) :
	database_(database)
{
}

const char* DatabaseCommand::getSqlCommand()
{
	if (sql_.size() <= 0) {
		buildSqlCommand();
	}
	if (sql_.size() <= 0) {
		throw Exception("empty SQL command");
	}
	return sql_.c_str();
}

void DatabaseCommand::execute()
{
	if (SQLITE_OK != ::sqlite3_exec(database_, getSqlCommand(), NULL, NULL, NULL)) {
		throw Exception("error executing SQL command");
	}
}

}
