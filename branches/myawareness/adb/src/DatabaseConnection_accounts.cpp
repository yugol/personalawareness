#include <cstdio>
#include <cstdlib>
#include <cstring>
#include <climits>
#include <DatabaseConnection.h>
#include "util.h"

using namespace std;

namespace adb {

int readAccount(void *param, int colCount, char **values, char **names)
{
	vector<Account> &accounts = *reinterpret_cast<vector<Account>*> (param);
	accounts.push_back(Account(atoi(values[0]), atoi(values[1]), values[2], values[3], atof(values[4]), values[5]));
	return 0;
}

static int readDouble(void *param, int colCount, char **values, char **names)
{
	double* val = reinterpret_cast<double*> (param);
	*val = ::atof(values[0]);
	return 0;
}

void DatabaseConnection::addUpdate(Account *acc)
{
	accounts_.clear();

	char stmt[STATEMENT_LEN];
	char nameBuf[NAME_LEN];
	char groupBuf[NAME_LEN];
	char descBuf[DESCRIPTION_LEN];

	adb::formatStringForDatabase(nameBuf, acc->getName());
	adb::formatStringForDatabase(groupBuf, acc->getGroup());
	adb::formatStringForDatabase(descBuf, acc->getDescription());

	int id = acc->getId();

	if (0 == id) {
		::sprintf(stmt, "INSERT INTO accounts (type, ival, name, [group], [desc]) VALUES (%d, %f, %s, %s, %s);\n", acc->getType(), acc->getInitialValue(), nameBuf, groupBuf, descBuf);
		// printf(stmt);
		if (SQLITE_OK != ::sqlite3_exec(database_, stmt, NULL, NULL, NULL)) {
			throw Exception("error inserting account");
		}
		acc->setId(::sqlite3_last_insert_rowid(database_));
	} else if (0 < id) {
		::sprintf(stmt, "UPDATE accounts SET type=%d, ival=%f, name=%s, [group]=%s, [desc]=%s WHERE id=%d;\n", acc->getType(), acc->getInitialValue(), nameBuf, groupBuf, descBuf, id);
		// printf(stmt);
		if (SQLITE_OK != ::sqlite3_exec(database_, stmt, NULL, NULL, NULL)) {
			throw Exception("error updating account");
		}
	}
}

void DatabaseConnection::delAccount(int id)
{
	accounts_.clear();
	char stmt[STATEMENT_LEN];
	::sprintf(stmt, "DELETE FROM accounts WHERE id=%d;\n", id);
	// printf(stmt);
	if (SQLITE_OK != ::sqlite3_exec(database_, stmt, NULL, NULL, NULL)) {
		throw Exception("error deleting account");
	}
}

void DatabaseConnection::cashAccounts() const
{
	if (accounts_.size() > 0) {
		return;
	}
	char stmt[] = "SELECT id, type, name, [group], ival, [desc] FROM accounts ORDER BY type DESC, [group] ASC, name ASC;\n";
	// printf(stmt);
	if (SQLITE_OK != ::sqlite3_exec(database_, stmt, readAccount, &accounts_, NULL)) {
		throw Exception("error selecting account");
	}
}

Account* DatabaseConnection::getAccount(int id) const
{
	cashAccounts();
	vector<Account>::iterator it;
	for (it = accounts_.begin(); it != accounts_.end(); ++it) {
		if (id == it->getId()) {
			return &(*it);
		}
	}
	return 0;
}

double DatabaseConnection::getBalance(Account *acc) const
{
	if (acc->getType() != Account::ACCOUNT) {
		return 0;
	}

	char stmt[STATEMENT_LEN];
	double credit = 0;
	double debit = 0;
	int id = acc->getId();
	// printf("Ival %f\n", acc->getInitialValue());

	::sprintf(stmt, "SELECT sum(val) as credit FROM transactions WHERE [to] = %d;\n", id);
	// printf(stmt);
	if (SQLITE_OK != ::sqlite3_exec(database_, stmt, readDouble, &credit, NULL)) {
		throw Exception("error getting credit");
	}
	// printf("Credit %f\n", CREDIT);

	::sprintf(stmt, "SELECT sum(val) as credit FROM transactions WHERE [from] = %d;\n", id);
	// printf(stmt);
	if (SQLITE_OK != ::sqlite3_exec(database_, stmt, readDouble, &debit, NULL)) {
		throw Exception("error getting debit");
	}
	// printf("Debit %f\n", debit);

	return (acc->getInitialValue() + credit - debit);
}

void DatabaseConnection::getAccounts(std::vector<int>* sel) const
{
	cashAccounts();
	vector<Account>::iterator it;
	for (it = accounts_.begin(); it != accounts_.end(); ++it) {
		if (Account::ACCOUNT == it->getType()) {
			sel->push_back(it->getId());
		}
	}
}

void DatabaseConnection::getBudgetCategories(std::vector<int>* sel) const
{
	cashAccounts();
	vector<Account>::iterator it;
	for (it = accounts_.begin(); it != accounts_.end(); ++it) {
		if (Account::ACCOUNT != it->getType()) {
			sel->push_back(it->getId());
		}
	}
}

void DatabaseConnection::getCreditingBudgets(std::vector<int>* sel) const
{
	cashAccounts();
	vector<Account>::iterator it;
	for (it = accounts_.begin(); it != accounts_.end(); ++it) {
		if (Account::CREDIT == it->getType()) {
			sel->push_back(it->getId());
		}
	}
}

void DatabaseConnection::getDebitingBudgets(std::vector<int>* sel) const
{
	cashAccounts();
	vector<Account>::iterator it;
	for (it = accounts_.begin(); it != accounts_.end(); ++it) {
		if (Account::DEBT == it->getType()) {
			sel->push_back(it->getId());
		}
	}
}

int DatabaseConnection::getAccountCount() const
{
	cashAccounts();
	return accounts_.size();
}

} // namespace adb

