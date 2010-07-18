#include <fstream>
#include "test.h"
#include "LoadCallback.h"

TEST( basic, DatabaseConnection )
{
	cout << "DatabaseConnection-all" << endl;

	DatabaseConnection::openDatabase(disposableDatabase);
	DatabaseConnection::deleteDatabase();

	Account acc(Account::ACCOUNT, "account");
	Account deb(Account::DEBT, "debt");
	Account cre(Account::CREDIT, "credit");

	DatabaseConnection::instance()->addUpdate(&acc);
	DatabaseConnection::instance()->addUpdate(&acc);
	DatabaseConnection::instance()->addUpdate(&deb);
	DatabaseConnection::instance()->addUpdate(&cre);

	LONGS_EQUAL(1, DatabaseConnection::instance()->getAccount(1)->getType());
	LONGS_EQUAL(0, DatabaseConnection::instance()->getAccount(2)->getType());
	LONGS_EQUAL(2, DatabaseConnection::instance()->getAccount(3)->getType());

	Item i1("in");
	Item i2("out");

	DatabaseConnection::instance()->addUpdate(&i1);
	DatabaseConnection::instance()->addUpdate(&i1);
	DatabaseConnection::instance()->addUpdate(&i2);

	LONGS_EQUAL(1, i1.getId());
	LONGS_EQUAL(2, i2.getId());

	Transaction tr1("00000001", 100, 2, 1, 1, 0);
	Transaction tr2("00000002", 100, 1, 3, 2, "no more");

	DatabaseConnection::instance()->addUpdate(&tr1);
	DatabaseConnection::instance()->addUpdate(&tr1);
	DatabaseConnection::instance()->addUpdate(&tr2);

	vector<int> sel;
	DatabaseConnection::instance()->selectTransactions(&sel, 0);

	LONGS_EQUAL(2, sel.size());

	DatabaseConnection::instance()->delTransaction(tr2.getId());
	DatabaseConnection::instance()->delTransaction(tr1.getId());

	DatabaseConnection::instance()->delItem(i2.getId());
	DatabaseConnection::instance()->delItem(i1.getId());

	DatabaseConnection::instance()->delAccount(cre.getId());
	DatabaseConnection::instance()->delAccount(deb.getId());
	DatabaseConnection::instance()->delAccount(acc.getId());

	DatabaseConnection::deleteDatabase();
}

TEST( getBalance, DatabaseConnection )
{
	cout << "DatabaseConnection-getBalance" << endl;

	DatabaseConnection::openDatabase(testDatabase);

	Account* acc = DatabaseConnection::instance()->getAccount(1);
	LONGS_EQUAL(Account::ACCOUNT, acc->getType());

	double balance = DatabaseConnection::instance()->getBalance(acc);
	LONGS_EQUAL(90, balance);
}

TEST( accounts, DatabaseConnection )
{
	cout << "DatabaseConnection-accounts" << endl;

	DatabaseConnection::openDatabase(testDatabase);
	vector<int> sel;

	DatabaseConnection::instance()->getAccounts(&sel);
	LONGS_EQUAL(1, sel.size());

	sel.clear();
	DatabaseConnection::instance()->getCreditingBudgets(&sel);
	LONGS_EQUAL(1, sel.size());

	sel.clear();
	DatabaseConnection::instance()->getDebitingBudgets(&sel);
	LONGS_EQUAL(1, sel.size());

	sel.clear();
	DatabaseConnection::instance()->getBudgetCategories(&sel);
	LONGS_EQUAL(2, sel.size());
}

TEST( transaction, DatabaseConnection )
{
	cout << "DatabaseConnection-transaction" << endl;

	DatabaseConnection::openDatabase(testDatabase);

	Transaction t(1);
	DatabaseConnection::instance()->getTransaction(&t);

	LONGS_EQUAL(1, t.getId());
	LONGS_EQUAL(100, t.getValue());
	LONGS_EQUAL(3, t.getFromId());
	LONGS_EQUAL(1, t.getToId());
	LONGS_EQUAL(1, t.getItemId());
}

TEST( items, DatabaseConnection )
{
	cout << "DatabaseConnection-items" << endl;

	DatabaseConnection::openDatabase(testDatabase);

	vector<int> sel;
	DatabaseConnection::instance()->getItems(&sel);
	LONGS_EQUAL(2, sel.size());

	const Item* item = DatabaseConnection::instance()->getItem("out");
	CHECK( 0 != item );
	LONGS_EQUAL( 2, item->getId() );
}

TEST( SQL, DatabaseConnection )
{
	cout << "DatabaseConnection-SQL" << endl;

	DatabaseConnection::openDatabase(testDatabase);

	char dumpFile[] = "dump.sql";
	::remove(dumpFile);

	try {

		ofstream fout(dumpFile);
		DatabaseConnection::exportDatabase(fout);
		fout.close();

		ifstream fin(dumpFile);
		DatabaseConnection::openDatabase(disposableDatabase);
		LoadCallback callback;
		DatabaseConnection::importDatabase(fin, &callback);
		fin.close();
		DatabaseConnection::deleteDatabase();

		::remove(dumpFile);

	} catch (const exception& ex) {
		FAIL( ex.what() );
	}
}
