#ifndef DATABASECONNECTION_H
#define DATABASECONNECTION_H

#include <string>
#include <vector>
#include <map>
#include <sqlite3.h>
#include "Account.h"
#include "Item.h"
#include "UndoManager.h"

namespace adb {

    class Transaction;
    class SelectionParameters;

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
        static void importDatabase(std::istream& in);
        static bool isOpened();
        static bool isAccountInUse(sqlite3* database, int accountId);
        static bool isItemInUse(sqlite3* database, int itemId);

        ~DatabaseConnection();

        const std::string& getDatabaseLocation() const;

        void insertUpdate(Account* account);
        void deleteAccount(int id);
        void selectAccounts(std::vector<int>* selection, SelectionParameters* parameters) const;
        bool isAccountInUse(int id) const;
        int getAccountCount() const;
        void getAccount(Account* account) const;
        const Account* getAccount(int id) const;
        const Account* getAccount(const char* name) const;
        double getBalance(const Account* account) const;
        void getAccounts(std::vector<int>* sel) const;
        void getBudgetCategories(std::vector<int>* sel) const;
        void getCreditingBudgets(std::vector<int>* sel) const;
        void getDebitingBudgets(std::vector<int>* sel) const;

        void insertUpdate(Item* item);
        void deleteItem(int id);
        void selectItems(std::vector<int>* selection, SelectionParameters* parameters) const;
        bool isItemInUse(int id) const;
        void getItem(Item* item) const;
        int getItemCount() const;
        const Item* getItem(int id) const;
        const Item* getItem(const char* name) const;

        void insertUpdate(Transaction* transaction);
        void deleteTransaction(int id);
        void selectTransactions(std::vector<int>* selection, SelectionParameters* parameters) const;
        void getTransaction(Transaction* transaction) const;

        bool canUndo();
        bool canRedo();
        void undo();
        void redo();

    private:
        static DatabaseConnection* instance_;

        std::string databaseLocation_;
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
        void loadSql(std::istream& in);
    };

    inline const std::string& DatabaseConnection::getDatabaseLocation() const
    {
        return databaseLocation_;
    }

} // namespace adb

#endif // DATABASECONNECTION_H
