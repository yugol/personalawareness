#ifndef DATABASECOMMAND_H_
#define DATABASECOMMAND_H_

#include <string>
#include <ostream>
#include <sqlite3.h>
#include <Command.h>

class DatabaseCommand: public Command {
public:
    DatabaseCommand(sqlite3* database);
    virtual ~DatabaseCommand();

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

#endif /* DATABASECOMMAND_H_ */
