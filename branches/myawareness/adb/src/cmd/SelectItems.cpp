#include <sstream>
#include <Configuration.h>
#include <cmd/SelectItems.h>

using namespace std;

namespace adb {

    SelectItems::SelectItems(sqlite3* database, vector<int>* selection, const SelectionParameters* parameters) :
        SelectCommand(database, selection, parameters)
    {
    }

    void SelectItems::buildSqlCommand()
    {
        ostringstream sout;

        sout << "SELECT [" << Configuration::COLUMN_ID << "] ";
        sout << "FROM [" << Configuration::TABLE_ITEMS << "] ";
        sout << "WHERE [" << Configuration::COLUMN_DELETED << "] IS NULL;" << endl;

        sql_ = sout.rdbuf()->str();
    }

} // namespace adb
