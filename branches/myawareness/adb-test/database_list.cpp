#include <iostream>
#include <Transaction.h>
#include <DatabaseConnection.h>
#include "test.h"

SKIPTEST( transactions, list )
{
    DatabaseConnection::openDatabase(testDatabase);

    vector<int> sel;
    DatabaseConnection::instance()->selectTransactions(&sel, 0);

    vector<int>::iterator it;
    for (it = sel.begin(); it != sel.end(); ++it) {
        int id_ = *it;
        Transaction t(id_);
        DatabaseConnection::instance()->getTransaction(&t);
        const Item* item_ = DatabaseConnection::instance()->getItem(t.getItemId());
        Account* from_ = DatabaseConnection::instance()->getAccount(t.getFromId());
        Account* to_ = DatabaseConnection::instance()->getAccount(t.getToId());
        cout << id_ << " " << item_->getName() << " : " << from_->getName() << " -> " << to_->getName() << endl;
    }
}

SKIPTEST( items , list )
{
    DatabaseConnection::openDatabase(testDatabase);

    for (int id_ = 1; id_ <= DatabaseConnection::instance()->getItemCount(); ++id_) {
        const Item* item_ = DatabaseConnection::instance()->getItem(id_);
        cout << id_ << " " << item_->getName() << endl;
    }
}

SKIPTEST( accounts, list )
{
    DatabaseConnection::openDatabase(testDatabase);

    for (int id_ = 1; id_ <= DatabaseConnection::instance()->getAccountCount(); ++id_) {
        Account* acc = DatabaseConnection::instance()->getAccount(id_);
        cout << id_ << " " << acc->getName() << endl;
    }
}
