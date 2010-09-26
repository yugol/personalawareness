#include <Configuration.h>
#include <DatabaseConnection.h>
#include "_test.h"

TEST ( preferences, Configuration )
{
    DatabaseConnection::openDatabase(testDatabase);
    CHECK( Configuration::instance()->getCurrencySymbol() == "RON" );
    CHECK( Configuration::instance()->isCompareAsciiOnly() );
}
