#include <iostream>
#include <sstream>
#include <Exception.h>
#include <BaseUtil.h>
#include <Transaction.h>
#include <cmd/SelectPreferences.h>
#include <cmd/UpdatePreference.h>
#include <cmd/InsertAccount.h>
#include <cmd/InsertItem.h>
#include <cmd/InsertTransaction.h>
#include <DatabaseConnection.h>

using namespace std;

void DatabaseConnection::exportSql(ostream& out) const
{
	cashAccounts();
	cashItems();

	// export properties
	writePreferences(database_);
	SelectPreferences prefs(database_);
	prefs.execute();
	map<const string, const string>::iterator it;
	for (it = prefs.begin(); it != prefs.end(); ++it) {
		UpdatePreference::buildSqlCommand(out, it->first, it->second);
	}

	// export accounts
	int accountNo = 0;
	map<int, int> accountIds;
	vector<Account>::iterator iAccounts;
	for (iAccounts = accounts_.begin(); iAccounts != accounts_.end(); ++iAccounts) {
		accountIds[iAccounts->getId()] = ++accountNo;
		InsertAccount::buildReverseSqlCommand(out, *iAccounts);
	}

	// export items
	int itemNo = 0;
	map<int, int> itemIds;
	map<int, Item>::iterator iItems;
	for (iItems = items_.begin(); iItems != items_.end(); ++iItems) {
		Item* item = &(iItems->second);
		itemIds[item->getId()] = ++itemNo;
		InsertItem::buildSqlCommand(out, *item);
	}

	// export transactions
	vector<int> allTransactions;
	selectTransactions(&allTransactions, 0);
	vector<int>::iterator iTransactions;
	for (iTransactions = allTransactions.begin(); iTransactions != allTransactions.end(); ++iTransactions) {
		Transaction transaction(*iTransactions);
		getTransaction(&transaction);
		transaction.setSourceId(accountIds[transaction.getSourceId()]);
		transaction.setDestinationId(accountIds[transaction.getDestinationId()]);
		transaction.setItemId(itemIds[transaction.getItemId()]);
		InsertTransaction::buildSqlCommand(out, transaction);
	}
}

void DatabaseConnection::importSql(istream& in)
{
	char statement[Configuration::LINE_BUFFER_LENGTH];

	if (SQLITE_OK != ::sqlite3_exec(database_, "BEGIN;", NULL, NULL, NULL)) {
		string errMessage(BaseUtil::EMSG_SQL_ERROR);
		errMessage.append(": ");
		errMessage.append(::sqlite3_errmsg(database_));
		THROW(errMessage.c_str());
	}

	int lineNo = 0;
	while (in.getline(statement, Configuration::LINE_BUFFER_LENGTH)) {
		++lineNo;
		if (SQLITE_OK != ::sqlite3_exec(database_, statement, NULL, NULL, NULL)) {

			ostringstream msgOut;
			msgOut << BaseUtil::EMSG_SQL_ERROR << ": ";
			msgOut << ::sqlite3_errmsg(database_) << " at line no. " << lineNo;

			if (SQLITE_OK != ::sqlite3_exec(database_, "ROLLBACK;", NULL, NULL, NULL)) {
				string errMessage(BaseUtil::EMSG_SQL_ERROR);
				errMessage.append(": ");
				errMessage.append(::sqlite3_errmsg(database_));
				THROW(errMessage.c_str());
			}

			THROW(msgOut.rdbuf()->str().c_str());
		}
	}

	if (SQLITE_OK != ::sqlite3_exec(database_, "COMMIT;", NULL, NULL, NULL)) {
		string errMessage(BaseUtil::EMSG_SQL_ERROR);
		errMessage.append(": ");
		errMessage.append(::sqlite3_errmsg(database_));
		THROW(errMessage.c_str());
	}
}

