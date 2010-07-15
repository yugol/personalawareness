#include "test.h"
#include <cstdio>

using namespace adb;

char testDatabase[] = "test.db";

void generateTestDatabase()
{
	::remove(testDatabase);

	DatabaseConnection db(testDatabase);

	Account acc(Account::ACCOUNT, "account");
	Account deb(Account::DEBT, "debt");
	Account cre(Account::CREDIT, "credit");

	db.addUpdate(&acc);
	db.addUpdate(&deb);
	db.addUpdate(&cre);

	Item i1("in");
	Item i2("out");

	db.addUpdate(&i1);
	db.addUpdate(&i2);

	Transaction tr1("00000001", 100, 3, 1, 1, 0);
	Transaction tr2("00000002", 10, 1, 2, 2, "no more");

	db.addUpdate(&tr1);
	db.addUpdate(&tr2);
}

int main()
{
	::generateTestDatabase();

	TestResult tr;
	TestRegistry::runAllTests(tr);

	::remove(testDatabase);

	return 0;
}
