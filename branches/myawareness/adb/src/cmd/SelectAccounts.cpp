#include <sstream>
#include <Configuration.h>
#include <cmd/SelectAccounts.h>

using namespace std;

namespace adb {

    SelectAccounts::SelectAccounts(sqlite3* database, vector<int>* selection, const SelectionParameters* parameters) :
        SelectCommand(database, selection, parameters)
    {
    }

    void SelectAccounts::buildSqlCommand()
    {
        ostringstream sout;

        sout << "SELECT [" << Configuration::COLUMN_ID << "] ";
        sout << "FROM [" << Configuration::TABLE_ACCOUNTS << "] ";
        sout << "WHERE [" << Configuration::COLUMN_DELETED << "] IS NULL ";
        sout << "ORDER BY ";
        sout << "[" << Configuration::COLUMN_TYPE << "] DESC, ";
        sout << "[" << Configuration::COLUMN_GROUP << "] ASC, ";
        sout << "[" << Configuration::COLUMN_NAME << "] ASC;" << endl;

        sql_ = sout.rdbuf()->str();
    }

} // namespace adb
