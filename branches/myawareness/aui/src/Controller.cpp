#include <algorithm>
#include <sstream>
#include <wx/msgdlg.h>
#include <Transaction.h>
#include <UiUtil.h>
#include <Controller.h>
#include <MainWindow.h>
#include <DatabaseConnection.h>
#include <ReportWindow.h>
#include <ReportData.h>

using namespace std;
using namespace adb;

Controller* Controller::instance_ = 0;

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

void Controller::start()
{
    if (Configuration::instance()->existsConfigurationFile()) {
        openDatabase(0);
    }
}

void Controller::reportException(const exception& ex, const wxString& hint)
{
    wxString title(_T("Error "));
    title.Append(hint);
    wxString message(ex.what(), wxConvLibc);
    wxMessageDialog dlg(mainWindow_, message, title, wxOK);
    dlg.ShowModal();
    dlg.Destroy();
}

void Controller::exitApplication()
{
    DatabaseConnection::closeDatabase();
    mainWindow_->Destroy();
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

    vector<int> sel;
    SelectionParameters parameters;
    mainWindow_->getTransactionSelectionParameters(&parameters);
    DatabaseConnection::instance()->selectTransactions(&sel, &parameters);

    vector<int>::iterator it;
    for (it = sel.begin(); it != sel.end(); ++it) {
        int id = *it;
        Transaction t(id);
        DatabaseConnection::instance()->getTransaction(&t);
        const Item* why = DatabaseConnection::instance()->getItem(t.getItemId());
        Account* from = DatabaseConnection::instance()->getAccount(t.getFromId());
        Account* to = DatabaseConnection::instance()->getAccount(t.getToId());

        ostringstream item;

        item << "<table id='@" << id << "@' width='90%' border='0' cellpadding='0' cellspacing='0'>";
        item << "<tr>";
        item << "<td align='left' width='12%'>&nbsp;";
        UiUtil::streamDate(item, t.getDate());
        item << "&nbsp;</td>";
        item << "<td align='left'><b>" << why->getName() << "</b></td>";
        item << "<td align='right' width='20%'>&nbsp;";
        UiUtil::streamCurrency(item, t.getValue());
        item << "&nbsp;</td>";
        item << "</tr>";
        item << "<tr><td />";
        item << "<td align='right'><small><i>" << from->getFullName() << " --> " << to->getFullName() << "</i></small>&nbsp;</td>";
        item << "<td /></tr>";
        item << "</table>";

        wxString wxitem;
        UiUtil::appendStdString(wxitem, item.rdbuf()->str());
        items.Add(wxitem);
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
    string stdname;
    UiUtil::appendWxString(stdname, name);
    return DatabaseConnection::instance()->getItem(stdname.c_str());
}

int Controller::getItemId(const wxString& name)
{
    const Item* item = getItemByName(name);
    if (0 == item) {
        Item newItem;
        string stdname;
        UiUtil::appendWxString(stdname, name);
        newItem.setName(stdname.c_str());

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
    try {

        DatabaseConnection::instance()->insertUpdate(transaction);
        updateTransactions();
        updateAccounts();

    } catch (const exception& ex) {
        reportException(ex, _T("accepting transaction"));
    }
}

void Controller::showReport(int chartType, int cashFlowDirection)
{
    SelectionParameters parameters;
    mainWindow_->getTransactionSelectionParameters(&parameters);
    ReportData data(chartType, cashFlowDirection, parameters);
    data.acquire();

    ReportWindow* report = new ReportWindow(mainWindow_);
    report->SetSize(640, 480);
    report->render(data);
    report->Show();
}
