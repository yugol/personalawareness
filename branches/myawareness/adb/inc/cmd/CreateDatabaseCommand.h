#ifndef CREATEDATABASECOMMAND_H_
#define CREATEDATABASECOMMAND_H_

#include <cmd/DatabaseCommand.h>

namespace adb {

class CreateDatabaseCommand: public DatabaseCommand {
public:
	CreateDatabaseCommand(sqlite3* database);
	virtual ~CreateDatabaseCommand();

protected:
	virtual void buildSqlCommand();

};

}

#endif /* CREATEDATABASECOMMAND_H_ */
