#ifndef CONTROLLER_H
#define CONTROLLER_H

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
    static void reportException(const std::exception& ex, const wxString& hint);

    ~Controller();

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

    void showReport(int chartType, int cashFlowDirection);

    void exitApplication();

protected:

private:
    static Controller* instance_;

    MainWindow* mainWindow_;

    Controller(MainWindow* wnd);
    Controller(Controller&);
    void operator=(Controller&);

    friend class Application;
};

#endif // CONTROLLER_H
