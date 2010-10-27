#include <algorithm>
#include <sstream>
#include <fstream>
#include <wx/file.h>
#include <Exception.h>
#include <Configuration.h>
#include <Transaction.h>
#include <ReversibleDatabaseCommand.h>
#include <DatabaseConnection.h>
#include <UiUtil.h>
#include <Controller.h>
#include <MainWindow.h>
#include <ReportWindow.h>
#include <ReportData.h>

using namespace std;

Controller* Controller::instance_ = 0;

void Controller::reportException(const exception& ex, const wxString& hint)
{
	wxString title(wxT("Error "));
	title.Append(hint);
	wxString errorMessage;
	UiUtil::appendStdString(errorMessage, ex.what());
	mainWindow_->reportMessage(errorMessage, title);
}

Controller* Controller::instance()
{
	return instance_;
}

Controller::Controller(MainWindow* wnd) :
	mainWindow_(wnd)
{
}

Controller::~Controller()
{
}

void Controller::initApplication(int argc, void** argv)
{
	if (argc > 1) {
		wxString pathFileExt(static_cast<wxChar*> (argv[1]));
		openDatabase(&pathFileExt);
	} else if (Configuration::instance()->existsConfigurationFile()) {
		openDatabase(0);
	} else {
		mainWindow_->SetTitle(UiUtil::getApplicationName(""));
		mainWindow_->setStatusMessage(UiUtil::getUsingStatusMessage(""));
	}
}

void Controller::openDatabase(const wxString* location)
{
	try {

		if (0 != location) {
			string pathFileExt;
			UiUtil::appendWxString(pathFileExt, *location);
			if (!wxFile::Exists(location->wc_str())) {
				ostringstream extOut;
				UiUtil::streamExt(extOut, pathFileExt);
				if (extOut.rdbuf()->str() != "cflow") {
					pathFileExt.append(".cflow");
				}
			}
			DatabaseConnection::openDatabase(pathFileExt.c_str());
		} else {
			DatabaseConnection::instance(); // opens default database
		}

		mainWindow_->setSelectionDefaultInterval();
		refreshAll();

	} catch (const exception& ex) {

		if (Configuration::instance()->getLastDatabasePath().size() > 0) {
			reportException(ex, wxT("opening database"));
		}

	}

	// update interface
	if (DatabaseConnection::isOpened()) {
		mainWindow_->SetTitle(UiUtil::getApplicationName(DatabaseConnection::instance()->getDatabaseLocation()));
		mainWindow_->setStatusMessage(UiUtil::getUsingStatusMessage(DatabaseConnection::instance()->getDatabaseLocation()));
	} else {
		mainWindow_->SetTitle(UiUtil::getApplicationName(""));
		mainWindow_->setStatusMessage(UiUtil::getUsingStatusMessage(""));
	}
	refreshUndoRedoStatus();
	mainWindow_->setDatabaseOpenedView(DatabaseConnection::isOpened());
}

void Controller::dumpDatabase(wxString& path)
{
	string stdpath;
	UiUtil::appendWxString(stdpath, path);
	ofstream fout(stdpath.c_str(), ios_base::trunc);

	try {

		DatabaseConnection::exportDatabase(fout);
		mainWindow_->reportMessage(wxT("Operation completed successfully."), wxT("Export database"));

	} catch (const exception& ex) {

		reportException(ex, wxT("exporting database"));

	}
}

void Controller::loadDatabase(wxString& path)
{
	string stdpath;
	UiUtil::appendWxString(stdpath, path);
	ifstream fin(stdpath.c_str());

	try {

		DatabaseConnection::importDatabase(fin);
		openDatabase(0);
		mainWindow_->reportMessage(wxT("Operation completed successfully."), wxT("Import database"));

	} catch (const exception& ex) {

		openDatabase(0);
		reportException(ex, wxT("importing database"));

	}
}

void Controller::getDefaultSqlExportName(wxString& name)
{
	Date today;
	today.setNow();

	ostringstream sout;

	UiUtil::streamFile(sout, DatabaseConnection::instance()->getDatabaseLocation());
	sout << "-";
	sout << today;
	sout << ".sql";

	UiUtil::appendStdString(name, sout.rdbuf()->str());
}

void Controller::getDatabasePath(wxString& path)
{
	ostringstream sout;
	UiUtil::streamPath(sout, DatabaseConnection::instance()->getDatabaseLocation());
	UiUtil::appendStdString(path, sout.rdbuf()->str());
}

void Controller::selectAllAccounts(std::vector<int>& accountIds)
{
	DatabaseConnection::instance()->getCreditingBudgets(&accountIds);
	DatabaseConnection::instance()->getAccounts(&accountIds);
	DatabaseConnection::instance()->getDebitingBudgets(&accountIds);
}

const Account* Controller::selectAccount(const char* name)
{
	if (0 == name || 0 == ::strlen(name)) {
		return 0;
	}
	return DatabaseConnection::instance()->getAccount(name);
}

const Account* Controller::selectAccount(int accountId)
{
	return DatabaseConnection::instance()->getAccount(accountId);
}

bool Controller::selectAccountInUse(int accountId)
{
	return DatabaseConnection::instance()->isAccountInUse(accountId);
}

void Controller::insertUpdateAccount(Account* account)
{
	DatabaseConnection::instance()->insertUpdate(account);
	refreshStatement();
	refreshAccounts();
	refreshUndoRedoStatus();
}

void Controller::deleteAccount(int accountId)
{
	DatabaseConnection::instance()->deleteAccount(accountId);
	refreshStatement();
	refreshAccounts();
	refreshUndoRedoStatus();
}

void Controller::selectAllItems(std::vector<const Item*>& items)
{
	vector<int> sel;
	DatabaseConnection::instance()->selectItems(&sel, 0);

	vector<int>::iterator it;
	for (it = sel.begin(); it != sel.end(); ++it) {
		const Item* item = DatabaseConnection::instance()->getItem(*it);
		items.push_back(item);
	}

	sort(items.begin(), items.end(), UiUtil::compareByName);
}

const Item* Controller::selectItem(int itemId)
{
	return DatabaseConnection::instance()->getItem(itemId);
}

const Item* Controller::selectItem(const char* name)
{
	if (0 == name || 0 == ::strlen(name)) {
		return 0;
	}
	return DatabaseConnection::instance()->getItem(name);
}

bool Controller::selectItemInUse(int itemId)
{
	return DatabaseConnection::instance()->isItemInUse(itemId);
}

void Controller::insertUpdateItem(Item* item)
{
	DatabaseConnection::instance()->insertUpdate(item);
	refreshItems();
	refreshUndoRedoStatus();
}

void Controller::deleteItem(int itemId)
{
	DatabaseConnection::instance()->deleteItem(itemId);
	refreshItems();
	refreshUndoRedoStatus();
}

void Controller::selectTransaction(Transaction* transaction, int transactionId)
{
	transaction->setId(transactionId);
	DatabaseConnection::instance()->getTransaction(transaction);
}

void Controller::selectFirstTransaction(Transaction* transaction)
{
	DatabaseConnection::instance()->getFirstTransaction(transaction);
}

void Controller::selectLastTransaction(Transaction* transaction)
{
	DatabaseConnection::instance()->getLastTransaction(transaction);
}

void Controller::insertUpdateTransaction(Transaction* transaction)
{
	DatabaseConnection::instance()->insertUpdate(transaction);
	refreshTransactions();
	refreshStatement();
	refreshUndoRedoStatus();
}

void Controller::deleteTransaction(int transactionId)
{
	DatabaseConnection::instance()->deleteTransaction(transactionId);
	refreshTransactions();
	refreshStatement();
	refreshUndoRedoStatus();
}

void Controller::exitApplication()
{
	if (DatabaseConnection::isOpened()) {
		DatabaseConnection::closeDatabase();
	}
	mainWindow_->Destroy();
}

void Controller::refreshAll()
{
	refreshStatement();
	refreshAccounts();
	refreshItems();
	refreshTransactions();
}

void Controller::refreshStatement()
{
	vector<pair<const Account*, double> > statement;
	double netWorth = 0;

	vector<int> sel;
	DatabaseConnection::instance()->getAccounts(&sel);
	for (vector<int>::const_iterator it = sel.begin(); it != sel.end(); ++it) {
		const Account* acc = DatabaseConnection::instance()->getAccount(*it);

		double balance = DatabaseConnection::instance()->getBalance(acc);
		if (-0.01 < balance && balance < 0.01) {
			balance = 0;
		}

		if (!(Configuration::instance()->isHideZeroBalanceAccounts() && balance == 0)) {
			statement.push_back(make_pair(acc, balance));
			netWorth += balance;
		}
	}

	mainWindow_->refreshStatement(statement, netWorth);
}

void Controller::refreshAccounts()
{
	vector<int>::const_iterator it;

	vector<const Account*> accounts;
	vector<int> sel;
	DatabaseConnection::instance()->getAccounts(&sel);
	for (it = sel.begin(); it != sel.end(); ++it) {
		const Account* acc = DatabaseConnection::instance()->getAccount(*it);
		accounts.push_back(acc);
	}
	mainWindow_->populateCashAccounts(accounts);

	accounts.clear();
	sel.clear();
	DatabaseConnection::instance()->getCreditingBudgets(&sel);
	for (it = sel.begin(); it != sel.end(); ++it) {
		const Account* acc = DatabaseConnection::instance()->getAccount(*it);
		accounts.push_back(acc);
	}
	mainWindow_->appendIncomeAccounts(accounts);

	accounts.clear();
	sel.clear();
	DatabaseConnection::instance()->getDebitingBudgets(&sel);
	for (it = sel.begin(); it != sel.end(); ++it) {
		const Account* acc = DatabaseConnection::instance()->getAccount(*it);
		accounts.push_back(acc);
	}
	mainWindow_->appendExpensesAcounts(accounts);
}

void Controller::refreshItems()
{
	vector<const Item*> items;
	selectAllItems(items);
	mainWindow_->populateItems(items);
}

void Controller::refreshTransactions()
{
	mainWindow_->refreshSelectionInterval();

	vector<int> sel;
	SelectionParameters parameters;
	mainWindow_->getTransactionSelectionParameters(&parameters);
	DatabaseConnection::instance()->selectTransactions(&sel, &parameters);

	wxArrayString items;
	vector<int>::iterator it;
	for (it = sel.begin(); it != sel.end(); ++it) {
		int id = *it;
		Transaction t(id);
		DatabaseConnection::instance()->getTransaction(&t);
		const Item* why = DatabaseConnection::instance()->getItem(t.getItemId());
		const Account* from = DatabaseConnection::instance()->getAccount(t.getFromId());
		const Account* to = DatabaseConnection::instance()->getAccount(t.getToId());

		ostringstream item;

		item << "<table id='@" << id << "@' width='";
		item << ((Configuration::instance()->isCompactTransactions()) ? ("80%") : ("90%"));
		item << "' border='0' cellpadding='0' cellspacing='0'>";

		item << "<tr>";
		item << "<td align='left' width='12%'><tt>&nbsp;";
		UiUtil::streamDate(item, t.getDate());
		item << "&nbsp;</tt></td>";
		item << "<td align='left'><b>&nbsp;&nbsp;" << why->getName() << "&nbsp;&nbsp;</b></td>";
		item << "<td align='right' width='20%'>&nbsp;";

		if (to->getType() == Account::DEBT) {
			item << "<font color='red'>";
			UiUtil::streamCurrency(item, t.getValue(), true);
			item << "</font>";
		} else if (from->getType() == Account::CREDIT) {
			item << "<font color='blue'>";
			UiUtil::streamCurrency(item, t.getValue(), true);
			item << "</font>";
		} else {
			UiUtil::streamCurrency(item, t.getValue(), true);
		}

		item << "&nbsp;</td>";
		item << "</tr>";

		if (!Configuration::instance()->isCompactTransactions()) {
			item << "<tr>";
			item << "<td colspan='2'align='right'><small><i><font color='DarkSlateGray'>" << from->getFullName() << " --> " << to->getFullName()
					<< "</font></i></small>&nbsp;</td>";
			item << "</tr>";
		}

		item << "</table>";

		wxString wxitem;
		UiUtil::appendStdString(wxitem, item.rdbuf()->str());
		items.Add(wxitem);
	}

	mainWindow_->populateTransactions(items);
	mainWindow_->scrollTransactionListAtEnd();
}

void Controller::showReport(int chartType, int cashFlowDirection)
{
	SelectionParameters parameters;
	mainWindow_->getTransactionSelectionParameters(&parameters);
	ReportData data(chartType, cashFlowDirection, parameters);
	data.acquire();

	ReportWindow* report = new ReportWindow(mainWindow_);
	switch (chartType) {
		case ReportData::MONTHLY:
			report->SetSize(580, 600);
			break;
		default:
			report->SetSize(640, 480);
			break;
	}
	report->render(data);
	report->Show();
}

void Controller::refreshUndoRedoStatus()
{
	const ReversibleDatabaseCommand* undo = 0;
	const ReversibleDatabaseCommand* redo = 0;
	if (DatabaseConnection::isOpened()) {
		undo = DatabaseConnection::instance()->getUndo();
		redo = DatabaseConnection::instance()->getRedo();
	}
	mainWindow_->setUndoRedoView(undo, redo);
}

void Controller::undo()
{
	DatabaseConnection::instance()->undo();
	refreshAll();
	refreshUndoRedoStatus();
}

void Controller::redo()
{
	DatabaseConnection::instance()->redo();
	refreshAll();
	refreshUndoRedoStatus();
}

bool Controller::isDatabaseEmpty()
{
	int accountCount = DatabaseConnection::instance()->getAccountCount();
	int itemCount = DatabaseConnection::instance()->getItemCount();
	return ((accountCount + itemCount) == 0);
}

void Controller::getDatabaseReport(wxString& report)
{
	ostringstream rout;

	if (DatabaseConnection::isOpened()) {
		rout << "Database file (schema version " << Configuration::PROJECT_DATABASE_VERSION << "):" << endl;
		rout << DatabaseConnection::instance()->getDatabaseLocation() << endl;
		rout << endl;

		rout << "Statistics:" << endl;
		rout << "  " << DatabaseConnection::instance()->getAccountCount() << " accounts" << endl;
		rout << "  " << DatabaseConnection::instance()->getItemCount() << " items" << endl;
		vector<int> sel;
		DatabaseConnection::instance()->selectTransactions(&sel, 0);
		rout << "  " << sel.size() << " transactions" << endl;
	} else {
		rout << "Please open/create a database to see the statistics." << endl;
	}

	UiUtil::appendStdString(report, rout.rdbuf()->str());
}

