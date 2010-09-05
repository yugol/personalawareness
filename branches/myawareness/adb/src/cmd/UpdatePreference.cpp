#include <sstream>
#include <Configuration.h>
#include <DbUtil.h>
#include <cmd/UpdatePreference.h>

using namespace std;

namespace adb {
    void UpdatePreference::buildSqlCommand(ostream& out, const string& name, const string& value)
    {
        out << "UPDATE [" << Configuration::TABLE_PREFERENCES << "] ";

        out << "SET ";
        out << "[" << Configuration::COLUMN_VALUE << "] = " << DbUtil::toDbParameter(value) << " ";

        out << "WHERE [" << Configuration::COLUMN_NAME << "] = " << DbUtil::toDbParameter(name) << ";" << endl;
    }

    UpdatePreference::UpdatePreference(sqlite3* database, const char* name, const char* value) :
        DatabaseCommand(database)
    {
        DbUtil::charPtrToString(name_, name);
        DbUtil::charPtrToString(value_, value);
    }

    UpdatePreference::~UpdatePreference()
    {
    }

    void UpdatePreference::buildSqlCommand()
    {
        ostringstream sout;
        buildSqlCommand(sout, name_, value_);
        sql_ = sout.rdbuf()->str();
    }

}
