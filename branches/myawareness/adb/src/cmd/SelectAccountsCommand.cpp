#include <sstream>
#include <Configuration.h>
#include <cmd/SelectAccountsCommand.h>

using namespace std;

namespace adb {

    SelectAccountsCommand::SelectAccountsCommand(sqlite3* database, std::vector<int>* selection, const SelectionParameters* parameters) :
        SelectCommand(database, selection, parameters)
    {
    }

    void SelectAccountsCommand::buildSqlCommand()
    {
        ostringstream sout;

        sout << "SELECT [" << Configuration::ID_COLUMN_NAME << "] ";
        sout << "FROM [" << Configuration::ACCOUNTS_TABLE_NAME << "] ";
        sout << "WHERE [" << Configuration::DEL_COLUMN_NAME << "] IS NULL ";
        sout << "ORDER BY ";
        sout << "[" << Configuration::TYPE_COLUMN_NAME << "] DESC, ";
        sout << "[" << Configuration::GROUP_COLUMN_NAME << "] ASC, ";
        sout << "[" << Configuration::NAME_COLUMN_NAME << "] ASC;" << endl;

        sql_ = sout.rdbuf()->str();
    }

} // namespace adb
