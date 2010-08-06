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

Controller::Controller()
{
}

Controller::~Controller()
{
}

void Controller::setMainWindow(MainWindow* wnd)
{
    mainWindow_ = wnd;
    mainWindow_->setController(this);
}

void Controller::start()
{
    if (Configuration::instance()->existsConfigurationFile()) {
        openDatabase(0);
    }
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
    DatabaseConnection::closeDatabase();
    mainWindow_->Destroy();
}

void Controller::openDatabase(const wxString* path)
{
    try {

        if (0 != path) {
            DatabaseConnection::openDatabase(path->fn_str());
        }

        updateAccounts();
        updateItems();
        updateTransactions();

        // update status message

        wxString statusMessage(DatabaseConnection::instance()->getDatabaseFile().c_str(), wxConvLibc);
        statusMessage = statusMessage.AfterLast('\\');
        statusMessage = statusMessage.AfterLast('/');
        statusMessage.Prepend(_T("Using: "));
        mainWindow_->setStatusMessage(statusMessage);

        mainWindow_->setDatabaseEnvironment(true);

    } catch (const exception& ex) {
        wxString msg(ex.what(), wxConvLibc);
        wxMessageDialog dlg(mainWindow_, msg, _T("Error opening database"), wxOK);
        dlg.ShowModal();
        dlg.Destroy();
    }
}

void Controller::updateAccounts()
{
    vector<pair<Account*, double> > statement;
    vector<Account*> budgets;
    vector<int> sel;
    vector<int>::iterator it;

    DatabaseConnection::instance()->getAccounts(&sel);
    double netWorth = 0;
    for (it = sel.begin(); it != sel.end(); ++it) {
        Account* acc = DatabaseConnection::instance()->getAccount(*it);
        double balance = DatabaseConnection::instance()->getBalance(acc);
        statement.push_back(make_pair(acc, balance));
        netWorth += balance;
    }
    mainWindow_->populateAccounts(statement);
    mainWindow_->setNetWorth(netWorth);

    sel.clear();
    DatabaseConnection::instance()->getCreditingBudgets(&sel);
    for (it = sel.begin(); it != sel.end(); ++it) {
        Account* acc = DatabaseConnection::instance()->getAccount(*it);
        budgets.push_back(acc);
    }
    mainWindow_->populateCreditingBudgets(budgets);

    sel.clear();
    budgets.clear();
    DatabaseConnection::instance()->getDebitingBudgets(&sel);
    for (it = sel.begin(); it != sel.end(); ++it) {
        Account* acc = DatabaseConnection::instance()->getAccount(*it);
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
    DatabaseConnection::instance()->selectItems(&sel, 0);
    for (it = sel.begin(); it != sel.end(); ++it) {
        const Item* item = DatabaseConnection::instance()->getItem(*it);
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
    DatabaseConnection::instance()->selectTransactions(&sel, 0);

    vector<int>::iterator it;
    for (it = sel.begin(); it != sel.end(); ++it) {
        int id = *it;
        Transaction t(id);
        DatabaseConnection::instance()->getTransaction(&t);
        const Item* why = DatabaseConnection::instance()->getItem(t.getItemId());
        Account* from = DatabaseConnection::instance()->getAccount(t.getFromId());
        Account* to = DatabaseConnection::instance()->getAccount(t.getToId());

        formatCurrency(currencyBuf, t.getValue());
        formatDate(dateBuf, t.getDate());

        // TODO: use C++ I/O
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

void Controller::transactionToView(int id, bool complete)
{
    Transaction t(id);
    DatabaseConnection::instance()->getTransaction(&t);
    mainWindow_->transactionToView(&t, complete);
}

const Item* Controller::getItemByName(const wxString& name)
{
    if (name.size() <= 0) {
        return 0;
    }

    char itemBuf[ITEM_BUF_LEN];
    formatString(itemBuf, name);

    return DatabaseConnection::instance()->getItem(itemBuf);
}

int Controller::getItemId(const wxString& name)
{
    const Item* item = getItemByName(name);
    if (0 == item) {
        Item newItem;
        char itemBuf[ITEM_BUF_LEN];
        formatString(itemBuf, name);
        newItem.setName(itemBuf);

        DatabaseConnection::instance()->insertUpdate(&newItem);
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
    DatabaseConnection::instance()->insertUpdate(transaction);
    updateTransactions();
    updateAccounts();
}

void Controller::dumpDatabase(wxString& path)
{
    ofstream fout(path.fn_str(), ios_base::trunc);

    DatabaseConnection::exportDatabase(fout);

    wxMessageDialog dlg(mainWindow_, _T("Operation completed successfully."), _T("Database export"), wxOK);
    dlg.ShowModal();
    dlg.Destroy();
}

void Controller::loadDatabase(wxString& path)
{
    ifstream fin(path.fn_str());

    DatabaseConnection::importDatabase(fin, 0);

    wxMessageDialog dlg(mainWindow_, _T("Operation completed successfully."), _T("Database import"), wxOK);
    dlg.ShowModal();
    dlg.Destroy();
}
