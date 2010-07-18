#include "test.h"
#include <cstdio>

using namespace adb;

char testDatabase[] = "test.db";
char disposableDatabase[] = "disposable.db";

void generateTestDatabase()
{
	DatabaseConnection::openDatabase(testDatabase);
	DatabaseConnection::deleteDatabase();

	Account acc(Account::ACCOUNT, "account");
	Account deb(Account::DEBT, "debt");
	Account cre(Account::CREDIT, "credit");

	DatabaseConnection::instance()->addUpdate(&acc);
	DatabaseConnection::instance()->addUpdate(&deb);
	DatabaseConnection::instance()->addUpdate(&cre);

	Item i1("in");
	Item i2("out");

	DatabaseConnection::instance()->addUpdate(&i1);
	DatabaseConnection::instance()->addUpdate(&i2);

	Transaction tr1("00000001", 100, 3, 1, 1, 0);
	Transaction tr2("00000002", 10, 1, 2, 2, "no more");

	DatabaseConnection::instance()->addUpdate(&tr1);
	DatabaseConnection::instance()->addUpdate(&tr2);
}

int main()
{
	string defaultPath = Configuration::instance()->getLastDatabasePath();

	::generateTestDatabase();

	TestResult tr;
	TestRegistry::runAllTests(tr);

	DatabaseConnection::openDatabase(testDatabase);
	DatabaseConnection::deleteDatabase();

	Configuration::instance()->setLastDatabasePath(defaultPath.c_str());

	return 0;
}
