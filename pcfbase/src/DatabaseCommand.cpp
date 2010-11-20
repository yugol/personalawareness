#include <cstdlib>
#include <Exception.h>
#include <BaseUtil.h>
#include <DatabaseCommand.h>

using namespace std;

DatabaseCommand::DatabaseCommand(sqlite3* database) :
    database_(database)
{
}

DatabaseCommand::~DatabaseCommand()
{
}

int DatabaseCommand::readDouble(void* param, int colCount, char** values, char** names)
{
    double* val = reinterpret_cast<double*> (param);
    if (0 == values[0]) {
        *val = 0;
    } else {
        *val = ::atof(values[0]);
    }
    return 0;
}

const char* DatabaseCommand::getSqlCommand()
{
    if (sql_.size() <= 0) {
        buildSqlCommand();
    }
    if (sql_.size() <= 0) {
        THROW(BaseUtil::EMSG_SQL_ERROR);
    }
    return sql_.c_str();
}

sqlite3_callback DatabaseCommand::getCallbackFunction()
{
    return NULL;
}

void* DatabaseCommand::getCallbackParameter()
{
    return NULL;
}

void DatabaseCommand::execute()
{
    int err = ::sqlite3_exec(database_, getSqlCommand(), getCallbackFunction(), getCallbackParameter(), NULL);
    if (SQLITE_OK != err) {
        string errMessage(BaseUtil::EMSG_SQL_ERROR);
        errMessage.append(": ");
        errMessage.append(::sqlite3_errmsg(database_));
        THROW(errMessage.c_str());
    }
}

