#ifndef CONTROLLER_H
#define CONTROLLER_H

#include <vector>

class MainWindow;
class wxString;
class wxDateTime;
namespace adb {
    class Account;
    class Item;
    class Transaction;
}

class Controller {
public:
    static Controller* instance();

    ~Controller();

    void initApplication();

    void getDefaultSqlExportName(wxString& name);

    void selectAllAccounts(std::vector<int>& accountIds);
    const adb::Account* selectAccount(int accountId);
    const adb::Account* selectAccount(const char* name);
    bool selectAccountInUse(int accountId);
    void insertUpdateAccount(adb::Account* account);
    void deleteAccount(int accountId);

    void selectAllItems(std::vector<const adb::Item*>& items);
    const adb::Item* selectItem(int itemId);
    const adb::Item* selectItem(const char* name);
    bool selectItemInUse(int itemId);
    void insertUpdateItem(adb::Item* item);
    void deleteItem(int itemId);

    void selectTransaction(adb::Transaction* transaction, int transactionId);
    void selectLastTransaction(adb::Transaction* transaction);
    void insertUpdateTransaction(adb::Transaction* transaction);
    void deleteTransaction(int transactionId);

    void exitApplication();

    void openDatabase(const wxString* path);
    void dumpDatabase(wxString& path);
    void loadDatabase(wxString& path);

    void refreshAccounts();
    void refreshItems();
    void refreshTransactions();
    void refreshAll();

    void refreshUndoRedoStatus();
    void undo();
    void redo();

    void reportException(const std::exception& ex, const wxString& hint);
    void showReport(int chartType, int cashFlowDirection);

private:
    static Controller* instance_;

    MainWindow* mainWindow_;

    Controller(MainWindow* wnd);
    Controller(Controller&);
    void operator=(Controller&);

    friend class Application;
};

#endif // CONTROLLER_H
