#ifdef WX_PRECOMP
#include "wx_pch.h"
#endif

#ifdef __BORLANDC__
#pragma hdrstop
#endif //__BORLANDC__
#include <cstdio>
#include <cstring>
#include <utility>
#include <algorithm>
#include <fstream>
#include <wx/msgdlg.h>
#include <Controller.h>
#include <MainWindow.h>

using namespace std;
using namespace adb;

Controller::Controller() :
	databaseConnection_(0)
{
	//ctor
}

Controller::~Controller()
{
	closeDatabase();
}

void Controller::setMainWindow(MainWindow* wnd)
{
	mainWindow_ = wnd;
	mainWindow_->setController(this);
}

void Controller::start()
{
}

void Controller::formatCurrency(char* buf, double val)
{
	if (-0.01 < val && val < 0) {
		val = 0;
	}
	sprintf(buf, "%.2f %s", val, "RON");
}

void Controller::formatDate(char* buf, const Date* date)
{
	sprintf(buf, "%04d-%02d-%02d", date->getYear(), date->getMonth(), date->getDay());
}

void Controller::formatString(char* buf, const wxString& str)
{
	size_t bufPos = 0;
	for (size_t strPos = 0; strPos < str.size(); ++strPos) {
		wxChar wch = str.GetChar(strPos);
		if (wch < 0x80) {
			buf[bufPos++] = static_cast<char> (wch);
		} else if (wch < 0x800) {
			buf[bufPos++] = static_cast<char> ((wch >> 6) | 192);
			buf[bufPos++] = static_cast<char> ((wch & 63) | 128);
		} else {
			buf[bufPos++] = static_cast<char> ((wch >> 12) | 224);
			buf[bufPos++] = static_cast<char> (((wch & 4095) >> 6) | 128);
			buf[bufPos++] = static_cast<char> ((wch & 63) | 128);
		}
	}
	buf[bufPos] = '\0';
}

void Controller::exitApplication()
{
	closeDatabase();
	mainWindow_->Destroy();
}

void Controller::newDatabase(wxString& path)
{
	try {
		if (path.AfterLast('.') != _T("db")) {
			path.Append(_T(".db"));
		}
		{
			DatabaseConnection temp(path.fn_str());
		}
		openDatabase(path);
	} catch (string* err) {
		wxString msg(err->c_str(), wxConvLibc);
		wxMessageDialog dlg(mainWindow_, msg, _T("Error creating database"), wxOK);
		dlg.ShowModal();
		dlg.Destroy();
	}
}

void Controller::openDatabase(wxString& path)
{
	DatabaseConnection* tmpDb = 0;

	try {
		tmpDb = new DatabaseConnection(path.fn_str());
		closeDatabase();
		databaseConnection_ = tmpDb;

		updateAccounts();
		updateItems();
		updateTransactions();

		// update status message
		wxString dbFile = path.AfterLast('\\');
		dbFile = dbFile.AfterLast('/');
		wxString msg(_T("Using: "));
		msg.Append(dbFile);
		mainWindow_->setStatusMessage(msg);

		mainWindow_->setDatabaseEnvironment(true);
	} catch (string* err) {
		wxString msg(err->c_str(), wxConvLibc);
		wxMessageDialog dlg(mainWindow_, msg, _T("Error opening database"), wxOK);
		dlg.ShowModal();
		dlg.Destroy();
	}
}

void Controller::closeDatabase()
{
	if (0 != databaseConnection_) {
		delete databaseConnection_;
		databaseConnection_ = 0;
	}
}

void Controller::updateAccounts()
{
	vector<pair<Account*, double> > statement;
	vector<Account*> budgets;
	vector<int> sel;
	vector<int>::iterator it;

	databaseConnection_->getAccounts(&sel);
	double netWorth = 0;
	for (it = sel.begin(); it != sel.end(); ++it) {
		Account* acc = databaseConnection_->getAccount(*it);
		double balance = databaseConnection_->getBalance(acc);
		statement.push_back(make_pair(acc, balance));
		netWorth += balance;
	}
	mainWindow_->populateAccounts(statement);
	mainWindow_->setNetWorth(netWorth);

	sel.clear();
	databaseConnection_->getCreditingBudgets(&sel);
	for (it = sel.begin(); it != sel.end(); ++it) {
		Account* acc = databaseConnection_->getAccount(*it);
		budgets.push_back(acc);
	}
	mainWindow_->populateCreditingBudgets(budgets);

	sel.clear();
	budgets.clear();
	databaseConnection_->getDebitingBudgets(&sel);
	for (it = sel.begin(); it != sel.end(); ++it) {
		Account* acc = databaseConnection_->getAccount(*it);
		budgets.push_back(acc);
	}
	mainWindow_->populateDebitingBudgets(budgets);
}

static bool itemPtrComparer(const Item* a, const Item* b)
{
	return a->getName() < b->getName();
}

void Controller::updateItems()
{
	vector<const Item*> items;
	vector<int> sel;
	vector<int>::iterator it;
	databaseConnection_->getItems(&sel);
	for (it = sel.begin(); it != sel.end(); ++it) {
		const Item* item = databaseConnection_->getItem(*it);
		items.push_back(item);
	}
	sort(items.begin(), items.end(), ::itemPtrComparer);
	mainWindow_->populateItems(items);
}

void Controller::updateTransactions()
{
	wxArrayString items;
	char currencyBuf[CURRENCY_BUF_LEN];
	char dateBuf[DATE_BUF_LEN];
	char itemBuf[ITEM_BUF_LEN];

	vector<int> sel;
	databaseConnection_->selectTransactions(&sel, 0);

	vector<int>::iterator it;
	for (it = sel.begin(); it != sel.end(); ++it) {
		int id = *it;
		Transaction t(id);
		databaseConnection_->getTransaction(&t);
		const Item* why = databaseConnection_->getItem(t.getItemId());
		Account* from = databaseConnection_->getAccount(t.getFromId());
		Account* to = databaseConnection_->getAccount(t.getToId());

		formatCurrency(currencyBuf, t.getValue());
		formatDate(dateBuf, t.getDate());

		sprintf(itemBuf, "<table id='@%d@' width='90%%' border='0' cellpadding='0' cellspacing='0'>"
			"<tr>"
			"<td align='left' width='12%%'>&nbsp;%s&nbsp;</td>"
			"<td align='left'><b>%s</b></td>"
			"<td align='right' width='20%%'>&nbsp;%s&nbsp;</td>"
			"</tr>"
			"<tr><td />"
			"<td align='right'><small><i>%s --> %s</i></small>&nbsp;</td>"
			"<td /></tr>"
			"</table>", id, dateBuf, why->getName().c_str(), currencyBuf, from->getFullName().c_str(),
				to->getFullName().c_str());

		wxString item(itemBuf, wxConvLibc);
		items.Add(item);
	}

	mainWindow_->populateTransactions(items);
}

void Controller::editTransaction(int id)
{
	Transaction t(id);
	databaseConnection_->getTransaction(&t);
	mainWindow_->transactionToView(&t);
}

int Controller::getItemId(const wxString& name)
{
	if (name.size() <= 0) {
		return 0;
	}

	char itemBuf[ITEM_BUF_LEN];
	formatString(itemBuf, name);

	const Item* item = databaseConnection_->getItem(itemBuf);
	if (0 == item) {
		Item newItem(itemBuf);
		databaseConnection_->addUpdate(&newItem);
		updateItems();
		item = &newItem;
	}

	if (0 != item) {
		return item->getId();
	}
	return 0;
}

void Controller::acceptTransaction(Transaction* transaction)
{
	databaseConnection_->addUpdate(transaction);
	updateTransactions();
	updateAccounts();
}

void Controller::dumpDatabase(wxString& path)
{
	ofstream fout(path.fn_str(), ios_base::trunc);

	databaseConnection_->dumpSql(fout);

	wxMessageDialog dlg(mainWindow_, _T("Operation completed successfully."), _T("Database export"), wxOK);
	dlg.ShowModal();
	dlg.Destroy();
}

void Controller::loadDatabase(wxString& path)
{
	ifstream fin(path.fn_str());

	databaseConnection_->loadSql(fin, 0);

	wxMessageDialog dlg(mainWindow_, _T("Operation completed successfully."), _T("Database import"), wxOK);
	dlg.ShowModal();
	dlg.Destroy();
}
