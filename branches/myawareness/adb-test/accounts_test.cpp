#include "test.h"

TEST( Accounts, UndoRedo )
{
    vector<int> sel;

    DatabaseConnection::openDatabase(testDatabase);

    Account accountOne;
    accountOne.setType(Account::ACCOUNT);
    accountOne.setName("account_1");
    DatabaseConnection::instance()->insertUpdate(&accountOne);
    Account accountOnePrime(accountOne.getId());
    DatabaseConnection::instance()->getAccount(&accountOnePrime);
    LONGS_EQUAL( accountOne.getId(), accountOnePrime.getId() );
    CHECK( accountOne.getName() == accountOnePrime.getName() );
    sel.clear();
    DatabaseConnection::instance()->selectAccounts(&sel, 0);
    LONGS_EQUAL(4, sel.size());

    accountOne.setName("account_1_update");
    DatabaseConnection::instance()->insertUpdate(&accountOne);
    DatabaseConnection::instance()->getAccount(&accountOnePrime);
    CHECK( accountOne.getName() == accountOnePrime.getName() );
    sel.clear();
    DatabaseConnection::instance()->selectAccounts(&sel, 0);
    LONGS_EQUAL(4, sel.size());

    DatabaseConnection::instance()->deleteAccount(accountOne.getId());
    sel.clear();
    DatabaseConnection::instance()->selectAccounts(&sel, 0);
    LONGS_EQUAL(3, sel.size());

    DatabaseConnection::instance()->undo();
    sel.clear();
    DatabaseConnection::instance()->selectAccounts(&sel, 0);
    LONGS_EQUAL(4, sel.size());

    DatabaseConnection::instance()->undo();
    sel.clear();
    DatabaseConnection::instance()->selectAccounts(&sel, 0);
    LONGS_EQUAL(4, sel.size());
    DatabaseConnection::instance()->getAccount(&accountOnePrime);
    CHECK( accountOnePrime.getName() == "account_1" );

    DatabaseConnection::instance()->undo();
    sel.clear();
    DatabaseConnection::instance()->selectAccounts(&sel, 0);
    LONGS_EQUAL(3, sel.size());

    DatabaseConnection::instance()->redo();
    sel.clear();
    DatabaseConnection::instance()->selectAccounts(&sel, 0);
    LONGS_EQUAL(4, sel.size());
    DatabaseConnection::instance()->getAccount(&accountOnePrime);
    CHECK( accountOnePrime.getName() == "account_1" );

    DatabaseConnection::instance()->redo();
    sel.clear();
    DatabaseConnection::instance()->selectAccounts(&sel, 0);
    LONGS_EQUAL(4, sel.size());
    DatabaseConnection::instance()->getAccount(&accountOnePrime);
    CHECK( accountOnePrime.getName() == "account_1_update" );

    DatabaseConnection::instance()->redo();
    sel.clear();
    DatabaseConnection::instance()->selectAccounts(&sel, 0);
    LONGS_EQUAL(3, sel.size());
}
