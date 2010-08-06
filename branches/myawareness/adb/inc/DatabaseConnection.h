#ifndef DATABASECONNECTION_H
#define DATABASECONNECTION_H

#include <string>
#include <vector>
#include <map>
#include <istream>
#include <ostream>
#include <sqlite3.h>
#include "Exception.h"
#include "Configuration.h"
#include "Account.h"
#include "Item.h"
#include "Transaction.h"
#include "SelectionParameters.h"
#include "UndoManager.h"

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

	void insertUpdate(Account* account);
	void selectAccounts(std::vector<int>* selection, SelectionParameters* parameters) const;
	void getAccount(Account* account) const;
	void deleteAccount(int id);
	int getAccountCount() const;
	Account* getAccount(int id) const;
	double getBalance(Account* account) const;
	void getAccounts(std::vector<int>* sel) const;
	void getBudgetCategories(std::vector<int>* sel) const;
	void getCreditingBudgets(std::vector<int>* sel) const;
	void getDebitingBudgets(std::vector<int>* sel) const;

	void insertUpdate(Item* item);
	void selectItems(std::vector<int>* selection, SelectionParameters* parameters) const;
	void getItem(Item* item) const;
	void deleteItem(int id);
	int getItemCount() const;
	const Item* getItem(int id) const;
	const Item* getItem(const char* name) const;

	void insertUpdate(Transaction* transaction);
	void selectTransactions(std::vector<int>* selection, SelectionParameters* parameters) const;
	void getTransaction(Transaction* transaction) const;
	void deleteTransaction(int id);

	bool canUndo();
	bool canRedo();
	void undo();
	void redo();

private:
	static DatabaseConnection* instance_;

	std::string databaseFile_;
	sqlite3* database_;
	UndoManager undoManager_;
	mutable std::vector<Account> accounts_;
	mutable std::map<int, Item> items_;

	DatabaseConnection(const char* databasePath);
	DatabaseConnection(const DatabaseConnection&);
	void operator=(const DatabaseConnection&);

	void openConnection();
	int checkConnection();
	void closeConnection();
	int createNewDatabase();
	void purgeDatabase();

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
