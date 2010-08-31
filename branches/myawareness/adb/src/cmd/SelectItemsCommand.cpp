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

        // TODO: order by name case independent

        sout << "SELECT [" << Configuration::ID_COLUMN_NAME << "] ";
        sout << "FROM [" << Configuration::ITEMS_TABLE_NAME << "] ";
        sout << "WHERE [" << Configuration::DEL_COLUMN_NAME << "] IS NULL;" << endl;

        sql_ = sout.rdbuf()->str();
    }

} // namespace adb
