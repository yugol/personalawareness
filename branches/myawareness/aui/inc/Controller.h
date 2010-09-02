#ifndef CONTROLLER_H
#define CONTROLLER_H

#include <vector>

class MainWindow;
class wxString;
class wxDateTime;
namespace adb {
    class Item;
    class Transaction;
}

class Controller {
public:
    static Controller* instance();

    ~Controller();

    void initApplication();

    void getDefaultSqlExportName(wxString& name);
    void selectItems(std::vector<const adb::Item*>& items);

    const adb::Item* selectItem(const char* name);
    const adb::Item* selectInsertItem(const char* name);
    void insertUpdateItem(adb::Item* item);
    void deleteItem(int itemId);
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
    void transactionToView(int id, bool complete);

    void updateUndoRedoStatus();
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
