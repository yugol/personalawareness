#ifndef CONTROLLER_H
#define CONTROLLER_H

#include <DatabaseConnection.h>

class MainWindow;
class wxString;

class Controller {
public:
	static const int CURRENCY_BUF_LEN = 50;
	static const int DATE_BUF_LEN = 20;
	static const int ITEM_BUF_LEN = 1000;

	Controller();
	~Controller();

	void setMainWindow(MainWindow* wnd);

	void formatCurrency(char* buf, double val);
	void formatDate(char* buf, const adb::Date* date);
	void formatString(char* buf, const wxString& str);

	void start();

	void newDatabase(wxString& path);
	void openDatabase(wxString& path);
	void dumpDatabase(wxString& path);
	void loadDatabase(wxString& path);
	int getItemId(const wxString& name);
	void acceptTransaction(adb::Transaction* transaction);

	void updateAccounts();
	void updateItems();
	void updateTransactions();

	void editTransaction(int id);

	void exitApplication();

protected:

private:
	MainWindow* mainWindow_;
	adb::DatabaseConnection* databaseConnection_;

	void closeDatabase();
};

#endif // CONTROLLER_H
