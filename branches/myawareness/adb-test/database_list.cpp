#include "test.h"

TEST( transactions, list )
{
	DatabaseConnection database_(testDatabase);

	vector<int> sel;
	database_.selectTransactions(&sel, 0);

	vector<int>::iterator it;
	for (it = sel.begin(); it != sel.end(); ++it) {
		int id_ = *it;
		Transaction t(id_);
		database_.getTransaction(&t);
		const Item* item_ = database_.getItem(t.getItemId());
		Account* from_ = database_.getAccount(t.getFromId());
		Account* to_ = database_.getAccount(t.getToId());
		cout << id_ << " " << item_->getName() << " : " << from_->getName() << " -> " << to_->getName() << endl;
	}
}

TEST( items , list )
{
	DatabaseConnection dbc(testDatabase);

	for (int id_ = 1; id_ <= dbc.getItemCount(); ++id_) {
		const Item* item_ = dbc.getItem(id_);
		cout << id_ << " " << item_->getName() << endl;
	}
}

TEST( accounts, list )
{
	DatabaseConnection dbc(testDatabase);

	for (int id_ = 1; id_ <= dbc.getAccountCount(); ++id_) {
		Account* acc = dbc.getAccount(id_);
		cout << id_ << " " << acc->getName() << endl;
	}
}
