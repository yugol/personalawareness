#ifndef DATABASECOMMAND_H_
#define DATABASECOMMAND_H_

#include <string>
#include <ostream>
#include <sqlite3.h>
#include <Command.h>

namespace adb {

class DatabaseCommand: public Command {
public:
	// TODO: use toParameter for all strings
	static const std::string toParameter(const std::string& str);

	DatabaseCommand(sqlite3* database);

	virtual void execute();

protected:
	static int readDouble(void* param, int colCount, char** values, char** names);

	std::string sql_;
	sqlite3* database_;

	const char* getSqlCommand();
	virtual void buildSqlCommand() = 0;
	virtual sqlite3_callback getCallbackFunction();
	virtual void* getCallbackParameter();
};

}

#endif /* DATABASECOMMAND_H_ */
