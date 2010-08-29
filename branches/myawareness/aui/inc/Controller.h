#ifndef CONTROLLER_H
#define CONTROLLER_H

class MainWindow;
class wxString;
class wxDateTime;
namespace adb {
    class Item;
    class Transaction;
    class ReportData;
}

class Controller {
public:
    Controller();
    ~Controller();

    void setMainWindow(MainWindow* wnd);

    void start();

    void openDatabase(const wxString* path);
    void dumpDatabase(wxString& path);
    void loadDatabase(wxString& path);

    const adb::Item* getItemByName(const wxString& name);
    int getItemId(const wxString& name);
    void acceptTransaction(adb::Transaction* transaction);

    void updateAccounts();
    void updateItems();
    void updateTransactions();

    void transactionToView(int id, bool complete);

    void showReport(adb::ReportData* data);

    void reportException(const std::exception& ex, const wxString& hint);
    void exitApplication();

protected:

private:
    MainWindow* mainWindow_;
};

#endif // CONTROLLER_H
