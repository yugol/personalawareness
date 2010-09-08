#include <sstream>
#include <Configuration.h>
#include <cmd/PurgeDatabase.h>

using namespace std;

namespace adb {

    PurgeDatabase::PurgeDatabase(sqlite3* database) :
        DatabaseCommand(database)
    {
    }

    void PurgeDatabase::buildSqlCommand()
    {
        ostringstream sout;

        sout << "DELETE FROM [" << Configuration::TABLE_TRANSACTIONS << "] ";
        sout << "WHERE [" << Configuration::COLUMN_DELETED << "] NOT NULL;" << endl;

        sout << "DELETE FROM [" << Configuration::TABLE_ITEMS << "] ";
        sout << "WHERE [" << Configuration::COLUMN_DELETED << "] NOT NULL;" << endl;

        sout << "DELETE FROM [" << Configuration::TABLE_ACCOUNTS << "] ";
        sout << "WHERE [" << Configuration::COLUMN_DELETED << "] NOT NULL;" << endl;

        sql_ = sout.rdbuf()->str();
    }

} // namespace adb
