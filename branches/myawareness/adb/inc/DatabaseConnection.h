#ifndef DATABASECONNECTION_H
#define DATABASECONNECTION_H

#include <string>
#include <vector>
#include <map>
#include <istream>
#include <ostream>
#include <sqlite3.h>
#include <Account.h>
#include <Item.h>
#include <Transaction.h>
#include <SelectionParameters.h>
#include <LoadSqlCallback.h>

namespace adb {

class DatabaseConnection {
public:
	enum ErrCodes {
		OK = 0, STATEMENT_ERROR, EMPTY_DATABASE, WRONG_DATABASE
	};

	DatabaseConnection(const char* file);
	~DatabaseConnection();

	const std::string& getDatabaseFile() const;
	void deleteDatabase();

	void addUpdate(Account *acc);
	void delAccount(int id);
	Account* getAccount(int id);
	void getAccounts(std::vector<int>* sel);
	void getBudgetCategories(std::vector<int>* sel);
	void getCreditingBudgets(std::vector<int>* sel);
	void getDebitingBudgets(std::vector<int>* sel);
	double getBalance(Account *acc);
	int getAccountCount();

	void addUpdate(Item *item);
	void delItem(int id);
	const Item* getItem(int id) const;
	const Item* getItem(const char* name) const;
	void getItems(std::vector<int>* sel) const;
	int getItemCount();

	void addUpdate(Transaction* tr);
	void delTransaction(int id);
	void getTransaction(Transaction* t);
	void selectTransactions(std::vector<int>* sel, SelectionParameters* params);

	void dumpSql(std::ostream& out);
	void loadSql(std::istream& in, LoadSqlCallback* callback);

protected:

private:
	const std::string databaseFile_;
	sqlite3 *database_;
	mutable std::vector<Account> accounts_;
	mutable std::map<int, Item> items_;

	DatabaseConnection(DatabaseConnection &);
	void operator=(DatabaseConnection &);

	void openDatabase();
	void checkConnection();
	int checkDatabase();
	int createNewDatabase();
	void closeDatabase();
	void cashAccounts() const;
	void cashItems()const;
};

inline const std::string& DatabaseConnection::getDatabaseFile() const
{
	return databaseFile_;
}

} // namespace adb

#endif // DATABASECONNECTION_H
