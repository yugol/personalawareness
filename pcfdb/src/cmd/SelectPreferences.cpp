#include <utility>
#include <sstream>
#include <Configuration.h>
#include <DbUtil.h>
#include <cmd/SelectPreferences.h>

using namespace std;

SelectPreferences::SelectPreferences(sqlite3* database) :
    DatabaseCommand(database)
{
}

SelectPreferences::~SelectPreferences()
{
}

static int readNameValuePair(void *param, int colCount, char **values, char **names)
{
    map<const string, const string>* nvpair = reinterpret_cast<map<const string, const string>*> (param);

    string name;
    DbUtil::charPtrToString(name, values[0]);

    string value;
    DbUtil::charPtrToString(value, values[1]);

    nvpair->insert(pair<string, string> (name, value));

    return 0;
}

sqlite3_callback SelectPreferences::getCallbackFunction()
{
    return readNameValuePair;
}

void* SelectPreferences::getCallbackParameter()
{
    return &preferences_;
}

void SelectPreferences::buildSqlCommand()
{
    ostringstream sout;

    sout << "SELECT [" << Configuration::COLUMN_NAME << "], ";
    sout << "[" << Configuration::COLUMN_VALUE << "] ";
    sout << "FROM [" << Configuration::TABLE_PREFERENCES << "];" << endl;

    sql_ = sout.rdbuf()->str();
}
