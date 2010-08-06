#include "test.h"

TEST( Items, UndoRedo )
{
	vector<int> sel;

	DatabaseConnection::openDatabase(testDatabase);

	Item itemOne;
	itemOne.setName("item_1");
	DatabaseConnection::instance()->insertUpdate(&itemOne);
	Item itemOnePrime(itemOne.getId());
	DatabaseConnection::instance()->getItem(&itemOnePrime);
	LONGS_EQUAL( itemOne.getId(), itemOnePrime.getId() );
	CHECK( itemOne.getName() == itemOnePrime.getName() );
	LONGS_EQUAL( itemOne.getLastTransactionId(), itemOnePrime.getLastTransactionId() );
	sel.clear();
	DatabaseConnection::instance()->selectItems(&sel, 0);
	LONGS_EQUAL(3, sel.size());

	itemOne.setName("item_1_updated");
	DatabaseConnection::instance()->insertUpdate(&itemOne);
	DatabaseConnection::instance()->getItem(&itemOnePrime);
	CHECK( itemOne.getName() == itemOnePrime.getName() );
	sel.clear();
	DatabaseConnection::instance()->selectItems(&sel, 0);
	LONGS_EQUAL(3, sel.size());

	DatabaseConnection::instance()->deleteItem(itemOne.getId());
	sel.clear();
	DatabaseConnection::instance()->selectItems(&sel, 0);
	LONGS_EQUAL(2, sel.size());

	DatabaseConnection::instance()->undo();
	sel.clear();
	DatabaseConnection::instance()->selectItems(&sel, 0);
	LONGS_EQUAL(3, sel.size());
	DatabaseConnection::instance()->getItem(&itemOnePrime);
	CHECK( itemOnePrime.getName() == "item_1_updated" );

	DatabaseConnection::instance()->undo();
	sel.clear();
	DatabaseConnection::instance()->selectItems(&sel, 0);
	LONGS_EQUAL(3, sel.size());
	DatabaseConnection::instance()->getItem(&itemOnePrime);
	CHECK( itemOnePrime.getName() == "item_1" );

	DatabaseConnection::instance()->undo();
	sel.clear();
	DatabaseConnection::instance()->selectItems(&sel, 0);
	LONGS_EQUAL(2, sel.size());

	DatabaseConnection::instance()->redo();
	sel.clear();
	DatabaseConnection::instance()->selectItems(&sel, 0);
	LONGS_EQUAL(3, sel.size());
	DatabaseConnection::instance()->getItem(&itemOnePrime);
	CHECK( itemOnePrime.getName() == "item_1" );

	DatabaseConnection::instance()->redo();
	sel.clear();
	DatabaseConnection::instance()->selectItems(&sel, 0);
	LONGS_EQUAL(3, sel.size());
	DatabaseConnection::instance()->getItem(&itemOnePrime);
	CHECK( itemOnePrime.getName() == "item_1_updated" );

	DatabaseConnection::instance()->redo();
	sel.clear();
	DatabaseConnection::instance()->selectItems(&sel, 0);
	LONGS_EQUAL(2, sel.size());
}
