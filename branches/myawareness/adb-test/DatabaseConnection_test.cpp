#include <fstream>
#include "test.h"
#include "LoadCallback.h"

TEST( basic, DatabaseConnection )
{
	cout << "DatabaseConnection-all" << endl;

	char dbName[] = "disposable.db";
	DatabaseConnection(dbName).deleteDatabase();

	DatabaseConnection db(dbName);

	Account acc(Account::ACCOUNT, "account");
	Account deb(Account::DEBT, "debt");
	Account cre(Account::CREDIT, "credit");

	db.addUpdate(&acc);
	db.addUpdate(&acc);
	db.addUpdate(&deb);
	db.addUpdate(&cre);

	LONGS_EQUAL(1, db.getAccount(1)->getType());
	LONGS_EQUAL(0, db.getAccount(2)->getType());
	LONGS_EQUAL(2, db.getAccount(3)->getType());

	Item i1("in");
	Item i2("out");

	db.addUpdate(&i1);
	db.addUpdate(&i1);
	db.addUpdate(&i2);

	LONGS_EQUAL(1, i1.getId());
	LONGS_EQUAL(2, i2.getId());

	Transaction tr1("00000001", 100, 2, 1, 1, 0);
	Transaction tr2("00000002", 100, 1, 3, 2, "no more");

	db.addUpdate(&tr1);
	db.addUpdate(&tr1);
	db.addUpdate(&tr2);

	vector<int> sel;
	db.selectTransactions(&sel, 0);

	LONGS_EQUAL(2, sel.size());

	db.delTransaction(tr2.getId());
	db.delTransaction(tr1.getId());

	db.delItem(i2.getId());
	db.delItem(i1.getId());

	db.delAccount(cre.getId());
	db.delAccount(deb.getId());
	db.delAccount(acc.getId());

	db.deleteDatabase();
}

TEST( getBalance, DatabaseConnection )
{
	cout << "DatabaseConnection-getBalance" << endl;

	DatabaseConnection database_(testDatabase);

	Account* acc = database_.getAccount(1);
	LONGS_EQUAL(Account::ACCOUNT, acc->getType());

	double balance = database_.getBalance(acc);
	LONGS_EQUAL(90, balance);
}

TEST( accounts, DatabaseConnection )
{
	cout << "DatabaseConnection-accounts" << endl;

	DatabaseConnection dbc(testDatabase);
	vector<int> sel;

	dbc.getAccounts(&sel);
	LONGS_EQUAL(1, sel.size());

	sel.clear();
	dbc.getCreditingBudgets(&sel);
	LONGS_EQUAL(1, sel.size());

	sel.clear();
	dbc.getDebitingBudgets(&sel);
	LONGS_EQUAL(1, sel.size());

	sel.clear();
	dbc.getBudgetCategories(&sel);
	LONGS_EQUAL(2, sel.size());
}

TEST( transaction, DatabaseConnection )
{
	cout << "DatabaseConnection-transaction" << endl;

	DatabaseConnection dbc(testDatabase);

	Transaction t(1);
	dbc.getTransaction(&t);

	LONGS_EQUAL(1, t.getId());
	LONGS_EQUAL(100, t.getValue());
	LONGS_EQUAL(3, t.getFromId());
	LONGS_EQUAL(1, t.getToId());
	LONGS_EQUAL(1, t.getItemId());
}

TEST( items, DatabaseConnection )
{
	cout << "DatabaseConnection-items" << endl;

	DatabaseConnection dc(testDatabase);

	vector<int> sel;
	dc.getItems(&sel);
	LONGS_EQUAL(2, sel.size());

	const Item* item = dc.getItem("out");
	CHECK( 0 != item );
	LONGS_EQUAL( 2, item->getId() );
}

TEST( SQL, DatabaseConnection )
{
	cout << "DatabaseConnection-SQL" << endl;

	DatabaseConnection testDb(testDatabase);

	char dumpFile[] = "dump.sql";
	char tempFile[] = "temp.db";

	::remove(dumpFile);
	::remove(tempFile);

	try {

		ofstream fout(dumpFile);
		testDb.dumpSql(fout);
		fout.close();

		LoadCallback callback;
		DatabaseConnection tempDb(tempFile);
		ifstream fin(dumpFile);
		tempDb.loadSql(fin, &callback);
		fin.close();

		tempDb.deleteDatabase();
		::remove(dumpFile);

	} catch (string* msg) {
		FAIL( msg->c_str() );
	}
}
