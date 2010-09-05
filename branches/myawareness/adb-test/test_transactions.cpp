#include <Transaction.h>
#include <DatabaseConnection.h>
#include "_test.h"

TEST( Transactions, UndoRedo )
{
	vector<int> sel;

	DatabaseConnection::openDatabase(testDatabase);

	Transaction t;
	t.setDate("00030303");
    t.setValue(1);
    t.setFromId(3);
    t.setToId(2);
    t.setItemId(1);
	DatabaseConnection::instance()->insertUpdate(&t);
	sel.clear();
	DatabaseConnection::instance()->selectTransactions(&sel, 0);
	LONGS_EQUAL(3, sel.size());

	t.setValue(2);
	DatabaseConnection::instance()->insertUpdate(&t);
	sel.clear();
	DatabaseConnection::instance()->selectTransactions(&sel, 0);
	LONGS_EQUAL(3, sel.size());

	DatabaseConnection::instance()->deleteTransaction(t.getId());
	sel.clear();
	DatabaseConnection::instance()->selectTransactions(&sel, 0);
	LONGS_EQUAL(2, sel.size());

	DatabaseConnection::instance()->undo();
	sel.clear();
	DatabaseConnection::instance()->selectTransactions(&sel, 0);
	LONGS_EQUAL(3, sel.size());
	DatabaseConnection::instance()->getTransaction(&t);
	LONGS_EQUAL(2, t.getValue());

	DatabaseConnection::instance()->undo();
	sel.clear();
	DatabaseConnection::instance()->selectTransactions(&sel, 0);
	LONGS_EQUAL(3, sel.size());
	DatabaseConnection::instance()->getTransaction(&t);
	LONGS_EQUAL(1, t.getValue());

	DatabaseConnection::instance()->undo();
	sel.clear();
	DatabaseConnection::instance()->selectTransactions(&sel, 0);
	LONGS_EQUAL(2, sel.size());

	DatabaseConnection::instance()->redo();
	sel.clear();
	DatabaseConnection::instance()->selectTransactions(&sel, 0);
	LONGS_EQUAL(3, sel.size());
	DatabaseConnection::instance()->getTransaction(&t);
	LONGS_EQUAL(1, t.getValue());

	DatabaseConnection::instance()->redo();
	sel.clear();
	DatabaseConnection::instance()->selectTransactions(&sel, 0);
	LONGS_EQUAL(3, sel.size());
	DatabaseConnection::instance()->getTransaction(&t);
	LONGS_EQUAL(2, t.getValue());

	DatabaseConnection::instance()->redo();
	sel.clear();
	DatabaseConnection::instance()->selectTransactions(&sel, 0);
	LONGS_EQUAL(2, sel.size());
}
