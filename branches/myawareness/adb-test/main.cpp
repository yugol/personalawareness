#include "test.h"
#include <cstdio>

using namespace adb;

char testDatabase[] = "test.db";
char disposableDatabase[] = "disposable.db";

void generateTestDatabase()
{
    DatabaseConnection::openDatabase(testDatabase);
    DatabaseConnection::deleteDatabase();

    Account acc;
    acc.setType(Account::ACCOUNT);
    acc.setName("account");
    Account deb;
    deb.setType(Account::DEBT);
    deb.setName("debt");
    Account cre;
    cre.setType(Account::CREDIT);
    cre.setName("credit");

    DatabaseConnection::instance()->insertUpdate(&acc);
    DatabaseConnection::instance()->insertUpdate(&deb);
    DatabaseConnection::instance()->insertUpdate(&cre);

    Item i1;
    i1.setName("in");
    Item i2;
    i2.setName("out");

    DatabaseConnection::instance()->insertUpdate(&i1);
    DatabaseConnection::instance()->insertUpdate(&i2);

    Transaction tr1;
    tr1.setDate("00010101");
    tr1.setValue(100);
    tr1.setFromId(3);
    tr1.setToId(1);
    tr1.setItemId(1);
    Transaction tr2;
    tr2.setDate("00020202");
    tr2.setValue(10);
    tr2.setFromId(1);
    tr2.setToId(2);
    tr2.setItemId(2);
    tr2.setDescription("no more");

    DatabaseConnection::instance()->insertUpdate(&tr1);
    DatabaseConnection::instance()->insertUpdate(&tr2);
}

int main()
{
    TestResult tr;

    try {

        string defaultPath = Configuration::instance()->getLastDatabasePath();

        ::generateTestDatabase();

        TestRegistry::runAllTests(tr);

        DatabaseConnection::openDatabase(testDatabase);
        // DatabaseConnection::closeDatabase();
        DatabaseConnection::deleteDatabase();

        Configuration::instance()->setLastDatabasePath(defaultPath.c_str());

    } catch (const exception& ex) {

        cerr << ex.what() << endl;
        return -1;

    } catch (...) {

        cerr << "some exception was thrown" << endl;
        return -1;

    }

    return tr.getFailureCount();
}
