#include <algorithm>
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

void Controller::reportException(const std::exception& ex, const wxString& hint)
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
    char currencyBuf[UiUtil::CURRENCY_BUFFER_LENGTH];
    char dateBuf[UiUtil::DATE_BUFFER_LENGTH];
    char itemBuf[UiUtil::NAME_BUFFER_LENGTH];

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

        UiUtil::formatCurrency(currencyBuf, t.getValue());
        UiUtil::formatDate(dateBuf, t.getDate());

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
            "</table>", id, dateBuf, why->getName().c_str(), currencyBuf, from->getFullName().c_str(), to->getFullName().c_str());

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

    char itemBuf[UiUtil::NAME_BUFFER_LENGTH];
    UiUtil::formatString(itemBuf, name);

    return DatabaseConnection::instance()->getItem(itemBuf);
}

int Controller::getItemId(const wxString& name)
{
    const Item* item = getItemByName(name);
    if (0 == item) {
        Item newItem;
        char itemBuf[UiUtil::NAME_BUFFER_LENGTH];
        UiUtil::formatString(itemBuf, name);
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
