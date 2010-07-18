#include <cstdio>
#include <DatabaseConnection.h>
#include "util.h"

using namespace std;

namespace adb {

int DatabaseConnection::createNewDatabase()
{
	char stmt[10000];

	// ACCOUNTS TABLE

	::sprintf(
			stmt,
			"CREATE TABLE 'accounts' (\n\
                    'id' INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,\n\
                    'type' INTEGER NOT NULL,\n\
                    'name' TEXT NOT NULL,\n\
                    'group' TEXT,\n\
                    'ival' REAL NOT NULL DEFAULT (0),\n\
                    'desc' TEXT\n\
                    );\n");

	// printf(stmt);

	if (SQLITE_OK != ::sqlite3_exec(database_, stmt, NULL, NULL, NULL)) {
		throw Exception("error creating accounts table");
	}

	::sprintf(stmt, "CREATE UNIQUE INDEX 'accounts_index' on accounts (id ASC);\n");

	// printf(stmt);

	if (SQLITE_OK != ::sqlite3_exec(database_, stmt, NULL, NULL, NULL)) {
		throw Exception("error creating accounts index");
	}

	// ITEMS TABLE

	::sprintf(
			stmt,
			"CREATE TABLE 'items' (\n\
                    'id' INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL,\n\
                    'name' TEXT NOT NULL\n\
                    );\n");

	// printf(stmt);

	if (SQLITE_OK != ::sqlite3_exec(database_, stmt, NULL, NULL, NULL)) {
		throw Exception("error creating items table");
	}

	::sprintf(stmt, "CREATE UNIQUE INDEX 'items_index' on items (id ASC);\n");

	// printf(stmt);

	if (SQLITE_OK != ::sqlite3_exec(database_, stmt, NULL, NULL, NULL)) {
		throw Exception("error creating items index");
	}

	// TRANSACTIONS TABLE

	::sprintf(
			stmt,
			"CREATE TABLE 'transactions' (\n\
                    'id' INTEGER PRIMARY KEY NOT NULL,\n\
                    'date' TEXT NOT NULL,\n\
                    'val' REAL NOT NULL,\n\
                    'from' INTEGER NOT NULL,\n\
                    'to' INTEGER NOT NULL,\n\
                    'item' INTEGER NOT NULL,\n\
                    'desc' TEXT\n\
                    );\n");

	// printf(stmt);

	if (SQLITE_OK != ::sqlite3_exec(database_, stmt, NULL, NULL, NULL)) {
		throw Exception("error creating transactions table");
	}

	::sprintf(stmt, "CREATE UNIQUE INDEX 'transactions_index' on transactions (id ASC);\n");

	// printf(stmt);

	if (SQLITE_OK != ::sqlite3_exec(database_, stmt, NULL, NULL, NULL)) {
		throw Exception("error creating transactions index");
	}

	return OK;
}

static void writeStringOrNull(ostream& out, const string& str)
{
	if (str.size() > 0) {
		out << "'" << str << "'";
	} else {
		out << "NULL";
	}
}

void DatabaseConnection::dumpSql(ostream& out) const
{
	cashAccounts();
	cashItems();

	// dump accounts
	map<int, int> accountIds;
	int accountNo = 0;

	vector<Account>::iterator iAccounts;
	for (iAccounts = accounts_.begin(); iAccounts != accounts_.end(); ++iAccounts) {
		accountIds[iAccounts->getId()] = ++accountNo;

		out << "INSERT INTO accounts (type, ival, name, [group], [desc]) VALUES ( ";
		out << iAccounts->getType();
		out << ", ";
		out << iAccounts->getInitialValue();
		out << ", ";
		writeStringOrNull(out, iAccounts->getName());
		out << ", ";
		writeStringOrNull(out, iAccounts->getGroup());
		out << ", ";
		writeStringOrNull(out, iAccounts->getDescription());
		out << " );" << endl;
	}

	// dump items
	map<int, int> itemIds;
	int itemNo = 0;

	map<int, Item>::iterator iItems;
	for (iItems = items_.begin(); iItems != items_.end(); ++iItems) {
		Item* item = &(iItems->second);
		itemIds[item->getId()] = ++itemNo;

		out << "INSERT INTO items (name) VALUES ( ";
		writeStringOrNull(out, item->getName());
		out << " );" << endl;
	}

	// dump transactions
	vector<int> allTransactions;
	selectTransactions(&allTransactions, 0);
	char dateBuf[DATE_LEN];

	vector<int>::iterator iTransactions;
	for (iTransactions = allTransactions.begin(); iTransactions != allTransactions.end(); ++iTransactions) {
		Transaction transaction(*iTransactions);
		getTransaction(&transaction);

		out << "INSERT INTO transactions ([date], val, [from], [to], item, [desc]) VALUES ( ";
		transaction.getDate()->sprintf(dateBuf);
		out << "'" << dateBuf << "'";
		out << ", ";
		out << transaction.getValue();
		out << ", ";
		out << accountIds[transaction.getFromId()];
		out << ", ";
		out << accountIds[transaction.getToId()];
		out << ", ";
		out << itemIds[transaction.getItemId()];
		out << ", ";
		writeStringOrNull(out, transaction.getDescription());
		out << " );" << endl;
	}
}

void DatabaseConnection::loadSql(std::istream& in, LoadSqlCallback* callback)
{
	char statement[STATEMENT_LEN];

	int lineNo = 0;
	while (in.getline(statement, STATEMENT_LEN)) {
		++lineNo;
		if (SQLITE_OK != ::sqlite3_exec(database_, statement, NULL, NULL, NULL)) {
			::sprintf(statement, "error loading from SQL script: line %d", lineNo);
			throw Exception(statement);
		}
		if (0 != callback) {
			callback->execute(lineNo);
		}
	}
}

} // namespace adb
