#include <cstdio>
#include <DatabaseConnection.h>
#include <cmd/LoadSqlCommand.h>
#include <cmd/CreateDatabaseCommand.h>
#include <util.h>

using namespace std;

namespace adb {

int DatabaseConnection::createNewDatabase()
{
	CreateDatabaseCommand cmd(database_);
	cmd.execute();
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

void DatabaseConnection::loadSql(std::istream& in, LoadSqlCommand* callback)
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
			callback->setLineNo(lineNo);
			callback->execute();
		}
	}
}

} // namespace adb
