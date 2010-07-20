#ifndef DATABASECOMMAND_H_
#define DATABASECOMMAND_H_

#include <sqlite3.h>
#include <cmd/Command.h>

namespace adb {

class DatabaseCommand: public Command {
public:
	DatabaseCommand(sqlite3* database);

	virtual void execute();
	const char* getSqlCommand();

protected:
	std::string sql_;

	virtual void buildSqlCommand() = 0;

private:
	sqlite3* database_;
};

}

#endif /* DATABASECOMMAND_H_ */
