#include <sstream>
#include <Configuration.h>
#include <cmd/PurgeDatabaseCommand.h>

using namespace std;

namespace adb {

    PurgeDatabaseCommand::PurgeDatabaseCommand(sqlite3* database) :
        DatabaseCommand(database)
    {
    }

    void PurgeDatabaseCommand::buildSqlCommand()
    {
        ostringstream sout;

        sout << "DELETE FROM [" << Configuration::TABLE_TRANSACTIONS << "] ";
        sout << "WHERE [" << Configuration::COLUMN_DELETED << "] NOT NULL;" << endl;

        sout << "DELETE FROM [" << Configuration::TABLE_DESCRIPTIONS << "] ";
        sout << "WHERE [" << Configuration::COLUMN_DELETED << "] NOT NULL;" << endl;

        sout << "DELETE FROM [" << Configuration::TABLE_ACCOUNTS << "] ";
        sout << "WHERE [" << Configuration::COLUMN_DELETED << "] NOT NULL;" << endl;

        sql_ = sout.rdbuf()->str();
    }

} // namespace adb
