#include <sstream>
#include <Configuration.h>
#include <cmd/SelectItemsCommand.h>

using namespace std;

namespace adb {

    SelectItemsCommand::SelectItemsCommand(sqlite3* database, vector<int>* selection, const SelectionParameters* parameters) :
        SelectCommand(database, selection, parameters)
    {
    }

    void SelectItemsCommand::buildSqlCommand()
    {
        ostringstream sout;

        sout << "SELECT [" << Configuration::COLUMN_ID << "] ";
        sout << "FROM [" << Configuration::TABLE_DESCRIPTIONS << "] ";
        sout << "WHERE [" << Configuration::COLUMN_DELETED << "] IS NULL;" << endl;

        sql_ = sout.rdbuf()->str();
    }

} // namespace adb
