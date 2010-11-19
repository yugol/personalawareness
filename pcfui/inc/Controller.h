#ifndef CONTROLLER_H
#define CONTROLLER_H

#include <vector>
#include <wx/wxchar.h>

class MainWindow;
class wxString;
class wxDateTime;
class Account;
class Item;
class Transaction;

class Controller {
public:
	static Controller* instance();

	~Controller();

	void initApplication(int argc, wxChar** argv);

	void getDefaultSqlExportName(wxString& name);
	void getDatabaseLocation(wxString& location);
	bool isDatabaseEmpty();
	void getDatabaseReport(wxString& report);
	void optimizeDatabase();

	void selectAllAccounts(std::vector<int>& accountIds);
	const Account* selectAccount(int accountId);
	const Account* selectAccount(const char* name);
	bool selectAccountInUse(int accountId);
	void insertUpdateAccount(Account* account);
	void deleteAccount(int accountId);

	void selectAllItems(std::vector<const Item*>& items);
	const Item* selectItem(int itemId);
	const Item* selectItem(const char* name);
	bool selectItemInUse(int itemId);
	void insertUpdateItem(Item* item);
	void deleteItem(int itemId);

	void selectTransaction(Transaction* transaction, int transactionId);
	void selectFirstTransaction(Transaction* transaction);
	void selectLastTransaction(Transaction* transaction);
	void insertUpdateTransaction(Transaction* transaction);
	void deleteTransaction(int transactionId);

	void exitApplication();

	void openDatabase(const wxString* location);
	void exportSql(wxString& pathFileExt);
	void importSql(wxString& pathFileExt);

	void refreshStatement();
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
