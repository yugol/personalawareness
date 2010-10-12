#include <fstream>
#include <iostream>
#include <Exception.h>
#include <BaseUtil.h>
#include <Transaction.h>
#include <DatabaseConnection.h>
#include "_test.h"

TEST( GetBalance, DatabaseConnection )
{
	DatabaseConnection::openDatabase(testDatabase);

	const Account* acc = DatabaseConnection::instance()->getAccount(1);
	LONGS_EQUAL(Account::ACCOUNT, acc->getType());

	double balance = DatabaseConnection::instance()->getBalance(acc);
	LONGS_EQUAL(90, balance);
}

TEST( Accounts, DatabaseConnection )
{
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

TEST( Transaction, DatabaseConnection )
{
	DatabaseConnection::openDatabase(testDatabase);

	Transaction t(1);
	DatabaseConnection::instance()->getTransaction(&t);

	LONGS_EQUAL(1, t.getId());
	LONGS_EQUAL(100, t.getValue());
	LONGS_EQUAL(3, t.getFromId());
	LONGS_EQUAL(1, t.getToId());
	LONGS_EQUAL(1, t.getItemId());

	try {
		Transaction nt(100);
		DatabaseConnection::instance()->getTransaction(&nt);
		FAIL(BaseUtil::EMSG_NO_RECORD);
	} catch (const Exception& ex) {
	}
}

TEST( Items, DatabaseConnection )
{
	DatabaseConnection::openDatabase(testDatabase);

	vector<int> sel;
	DatabaseConnection::instance()->selectItems(&sel, 0);
	LONGS_EQUAL(2, sel.size());

	const Item* item = DatabaseConnection::instance()->getItem("out");
	CHECK( 0 != item );
	LONGS_EQUAL( 2, item->getId() );
	LONGS_EQUAL( 2, item->getLastTransactionId() );
}

TEST( Sql, DatabaseConnection )
{
	DatabaseConnection::openDatabase(testDatabase);

	char dumpFile[] = "dump.sql";
	::remove(dumpFile);

	try {

		ofstream fout(dumpFile);
		DatabaseConnection::exportDatabase(fout);
		fout.close();

		ifstream fin(dumpFile);
		DatabaseConnection::openDatabase(disposableDatabase);
		DatabaseConnection::importDatabase(fin);
		fin.close();
		DatabaseConnection::deleteDatabase();

		::remove(dumpFile);

	} catch (const exception& ex) {
		FAIL( ex.what() );
	}
}
