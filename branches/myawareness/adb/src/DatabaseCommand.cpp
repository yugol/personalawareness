#include <cstdlib>
// #include <iostream>
// #include <fstream>
#include <Exception.h>
#include <DatabaseCommand.h>

using namespace std;

namespace adb {

    DatabaseCommand::DatabaseCommand(sqlite3* database) :
        database_(database)
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
            THROW(Exception::SQL_ERROR_MESSAGE);
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
        // ofstream fout("sql.log", ios::app);
        // cout << getSqlCommand();

        int err = ::sqlite3_exec(database_, getSqlCommand(), getCallbackFunction(), getCallbackParameter(), NULL);
        if (SQLITE_OK != err) {
            string errMessage(Exception::SQL_ERROR_MESSAGE);
            errMessage.append(": ");
            errMessage.append(::sqlite3_errmsg(database_));
            THROW(errMessage.c_str());
        }
    }

} // namespac eadb
