#ifndef DATABASECONNECTION_H
#define DATABASECONNECTION_H

#include <string>
#include <vector>
#include <map>
#include <istream>
#include <ostream>
#include <sqlite3.h>
#include <Exception.h>
#include <Configuration.h>
#include <Account.h>
#include <Item.h>
#include <Transaction.h>
#include <SelectionParameters.h>
#include <UndoManager.h>

namespace adb {

class LoadSqlCommand;

class DatabaseConnection {
public:
	enum ErrCodes {
		OK = 0, STATEMENT_ERROR, EMPTY_DATABASE, WRONG_DATABASE
	};

	static DatabaseConnection* instance();
	static void openDatabase(const char* databasePath);
	static void closeDatabase();
	static void deleteDatabase();
	static void exportDatabase(std::ostream& out);
	static void importDatabase(std::istream& in, LoadSqlCommand* callback);

	~DatabaseConnection();

	const std::string& getDatabaseFile() const;

	void addUpdate(Account *acc);
	void delAccount(int id);
	Account* getAccount(int id) const;
	void getAccounts(std::vector<int>* sel) const;
	void getBudgetCategories(std::vector<int>* sel) const;
	void getCreditingBudgets(std::vector<int>* sel) const;
	void getDebitingBudgets(std::vector<int>* sel) const;
	double getBalance(Account *acc) const;
	int getAccountCount() const;

	void addUpdate(Item *item);
	void delItem(int id);
	const Item* getItem(int id) const;
	const Item* getItem(const char* name) const;
	void getItems(std::vector<int>* sel) const;
	int getItemCount() const;

	void addUpdate(Transaction* tr);
	void delTransaction(int id);
	void getTransaction(Transaction* t) const;
	void selectTransactions(std::vector<int>* sel, SelectionParameters* params) const;

private:
	static DatabaseConnection* instance_;

	std::string databaseFile_;
	sqlite3* database_;
	UndoManager commandManager_;
	mutable std::vector<Account> accounts_;
	mutable std::map<int, Item> items_;

	DatabaseConnection(const char* databasePath);
	DatabaseConnection(const DatabaseConnection &);
	void operator=(const DatabaseConnection &);

	void openConnection();
	int checkConnection();
	void closeConnection();
	int createNewDatabase();

	void cashAccounts() const;
	void cashItems() const;

	void dumpSql(std::ostream& out) const;
	void loadSql(std::istream& in, LoadSqlCommand* callback);
};

inline const std::string& DatabaseConnection::getDatabaseFile() const
{
	return databaseFile_;
}

} // namespace adb

#endif // DATABASECONNECTION_H
