#include <sstream>
#include <Configuration.h>
#include <cmd/CleanDatabase.h>

using namespace std;

CleanDatabase::CleanDatabase(sqlite3* database) :
    DatabaseCommand(database)
{
}

void CleanDatabase::buildSqlCommand()
{
    ostringstream sout;

    sout << "BEGIN;" << endl;

    sout << "DROP TABLE [" << Configuration::TABLE_ACCOUNTS << "];";
    sout << "DROP TABLE [" << Configuration::TABLE_ITEMS << "];";
    sout << "DROP TABLE [" << Configuration::TABLE_TRANSACTIONS << "];";
    sout << "DROP TABLE [" << Configuration::TABLE_PREFERENCES << "];";

    sout << "COMMIT;" << endl;

    sql_ = sout.rdbuf()->str();
}
