#ifndef CONTROLLER_H
#define CONTROLLER_H

#include <DatabaseConnection.h>

class MainWindow;
class wxString;

class Controller {
public:
	static const int CURRENCY_BUFFER_LENGTH = 50;
	static const int DATE_BUFFER_LENGTH = 20;
	static const int NAME_BUFFER_LENGTH = 1000;

	Controller();
	~Controller();

	void setMainWindow(MainWindow* wnd);

	void formatCurrency(char* buf, double val);
	void formatDate(char* buf, const adb::Date& date);
	void formatString(char* buf, const wxString& str);

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

	void reportException(const std::exception& ex, const wxString& hint = _T(""));
	void exitApplication();

protected:

private:
	MainWindow* mainWindow_;
};

#endif // CONTROLLER_H
