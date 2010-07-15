#include <cstdio>
#include <cstdlib>
#include <DatabaseConnection.h>
#include "util.h"

using namespace std;

namespace adb {

int readTransactionIntoVector(void *param, int colCount, char **values, char **names)
{
	vector<int>* sel = reinterpret_cast<vector<int>*> (param);
	sel->push_back(::atoi(values[0]));
	return 0;
}

int readTransaction(void *param, int colCount, char **values, char **names)
{
	Transaction* t = reinterpret_cast<Transaction*> (param);
	t->setDate(values[0]);
	t->setValue(::atof(values[1]));
	t->setFromId(::atoi(values[2]));
	t->setToId(::atoi(values[3]));
	t->setItemId(::atoi(values[4]));
	t->setDescription(values[5]);
	return 0;
}

void DatabaseConnection::addUpdate(Transaction *tr)
{
	char stmt[STATEMENT_LEN];
	char dateBuf[DATE_LEN];
	char descBuf[DESCRIPTION_LEN];

	tr->getDate()->sprintf(stmt);
	formatStringForDatabase(dateBuf, stmt);
	formatStringForDatabase(descBuf, tr->getDescription());

	int id = tr->getId();

	if (0 == id) {
		::sprintf(stmt, "INSERT INTO transactions ([date], val, [from], [to], item, [desc]) VALUES (%s, %f, %d, %d, %d, %s);\n", dateBuf, tr->getValue(), tr->getFromId(), tr->getToId(), tr->getItemId(),
				descBuf);
		// printf(stmt);
		if (SQLITE_OK != ::sqlite3_exec(database_, stmt, NULL, NULL, NULL)) {
			throw new string("error inserting transaction");
		}
		tr->setId(::sqlite3_last_insert_rowid(database_));
	} else if (0 < id) {
		::sprintf(stmt, "UPDATE transactions SET [date]=%s, val=%f, [from]=%d, [to]=%d, item=%d, [desc]=%s WHERE id=%d;\n", dateBuf, tr->getValue(), tr->getFromId(), tr->getToId(), tr->getItemId(),
				descBuf, id);
		// printf(stmt);
		if (SQLITE_OK != ::sqlite3_exec(database_, stmt, NULL, NULL, NULL)) {
			throw new string("error updating transaction");
		}
	}
}

void DatabaseConnection::delTransaction(int id)
{
	char stmt[STATEMENT_LEN];
	::sprintf(stmt, "DELETE FROM transactions WHERE id=%d;\n", id);
	// printf(stmt);
	if (SQLITE_OK != ::sqlite3_exec(database_, stmt, NULL, NULL, NULL)) {
		throw new string("error deleting transaction");
	}
}

void DatabaseConnection::selectTransactions(std::vector<int>* sel, SelectionParameters* params)
{
	char stmt[STATEMENT_LEN];
	::sprintf(stmt, "SELECT id FROM transactions;\n");
	// printf(stmt);
	if (SQLITE_OK != ::sqlite3_exec(database_, stmt, readTransactionIntoVector, sel, NULL)) {
		throw new string("error selecting transactions");
	}
}

void DatabaseConnection::getTransaction(Transaction* t)
{
	char stmt[STATEMENT_LEN];
	::sprintf(stmt, "SELECT [date], val, [from], [to], item, [desc] FROM transactions WHERE id = %d;\n", t->getId());
	// printf(stmt);
	if (SQLITE_OK != ::sqlite3_exec(database_, stmt, readTransaction, t, NULL)) {
		throw new string("error selecting transaction");
	}
}

} // namespace adb
