#include <algorithm>
#include <sstream>
#include <Exception.h>
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

void Controller::reportException(const exception& ex, const wxString& hint)
{
    wxString title(wxT("Error "));
    title.Append(hint);
    wxString errorMessage;
    UiUtil::appendStdString(errorMessage, ex.what());
    mainWindow_->uiReport(errorMessage, title);
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

void Controller::initApplication()
{
    if (Configuration::instance()->existsConfigurationFile()) {
        openDatabase(0);
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

void Controller::selectAllAccounts(std::vector<int>& accountIds)
{
    DatabaseConnection::instance()->getCreditingBudgets(&accountIds);
    DatabaseConnection::instance()->getAccounts(&accountIds);
    DatabaseConnection::instance()->getDebitingBudgets(&accountIds);
}

const adb::Account* Controller::selectAccount(const char* name)
{
    if (0 == name || 0 == ::strlen(name)) {
        return 0;
    }
    return DatabaseConnection::instance()->getAccount(name);
}

const adb::Account* Controller::selectAccount(int accountId)
{
    return DatabaseConnection::instance()->getAccount(accountId);
}

bool Controller::selectAccountInUse(int accountId)
{
    return DatabaseConnection::instance()->isAccountInUse(accountId);
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

const adb::Item* Controller::selectItem(const char* name)
{
    if (0 == name || 0 == ::strlen(name)) {
        return 0;
    }
    return DatabaseConnection::instance()->getItem(name);
}

const adb::Item* Controller::selectInsertItem(const char* name)
{
    if (0 == name || 0 == ::strlen(name)) {
        return 0;
    }

    const Item* item = DatabaseConnection::instance()->getItem(name);
    if (0 == item) {
        Item newItem;
        newItem.setName(name);
        insertUpdateItem(&newItem);
    }

    return DatabaseConnection::instance()->getItem(name);
}

void Controller::insertUpdateItem(adb::Item* item)
{
    try {

        int tempId = item->getId();
        DatabaseConnection::instance()->insertUpdate(item);
        refreshItems();
        if (tempId != Configuration::DEFAULT_ID) {
            refreshTransactions();
        }
        updateUndoRedoStatus();

    } catch (const exception& ex) {
        reportException(ex, wxT("inserting or updating item"));
    }
}

void Controller::deleteItem(int itemId)
{
    try {

        DatabaseConnection::instance()->deleteItem(itemId);
        refreshItems();
        updateUndoRedoStatus();

    } catch (const exception& ex) {
        if (0 == ::strstr(ex.what(), Exception::RECORD_IN_USE)) {
            reportException(ex, wxT("deleting item"));
        } else {
            throw Exception("Cannot delete item because it is used by a transaction!");
        }
    }
}

void Controller::insertUpdateTransaction(Transaction* transaction)
{
    try {

        DatabaseConnection::instance()->insertUpdate(transaction);
        refreshTransactions();
        refreshAccounts();
        updateUndoRedoStatus();

    } catch (const exception& ex) {
        reportException(ex, wxT("inserting or updating transaction"));
    }
}

void Controller::deleteTransaction(int transactionId)
{
    try {

        DatabaseConnection::instance()->deleteTransaction(transactionId);
        refreshTransactions();
        refreshAccounts();
        updateUndoRedoStatus();

    } catch (const exception& ex) {
        reportException(ex, wxT("deleting transaction"));
    }
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
    refreshAccounts();
    refreshItems();
    refreshTransactions();
}

void Controller::refreshAccounts()
{
    vector<pair<const Account*, double> > statement;
    vector<const Account*> budgets;
    vector<int> sel;
    vector<int>::const_iterator it;

    DatabaseConnection::instance()->getAccounts(&sel);
    double netWorth = 0;
    for (it = sel.begin(); it != sel.end(); ++it) {
        const Account* acc = DatabaseConnection::instance()->getAccount(*it);
        double balance = DatabaseConnection::instance()->getBalance(acc);
        statement.push_back(make_pair(acc, balance));
        netWorth += balance;
    }
    mainWindow_->populateAccounts(statement);
    mainWindow_->setNetWorth(netWorth);

    sel.clear();
    DatabaseConnection::instance()->getCreditingBudgets(&sel);
    for (it = sel.begin(); it != sel.end(); ++it) {
        const Account* acc = DatabaseConnection::instance()->getAccount(*it);
        budgets.push_back(acc);
    }
    mainWindow_->populateCreditingBudgets(budgets);

    sel.clear();
    budgets.clear();
    DatabaseConnection::instance()->getDebitingBudgets(&sel);
    for (it = sel.begin(); it != sel.end(); ++it) {
        const Account* acc = DatabaseConnection::instance()->getAccount(*it);
        budgets.push_back(acc);
    }
    mainWindow_->populateDebitingBudgets(budgets);
}

void Controller::refreshItems()
{
    vector<const Item*> items;
    selectAllItems(items);
    mainWindow_->populateItems(items);
}

void Controller::refreshTransactions()
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
        const Account* from = DatabaseConnection::instance()->getAccount(t.getFromId());
        const Account* to = DatabaseConnection::instance()->getAccount(t.getToId());

        ostringstream item;

        item << "<table id='@" << id << "@' width='90%' border='0' cellpadding='0' cellspacing='0'>";

        item << "<tr>";
        item << "<td align='left' width='12%'><tt>&nbsp;";
        UiUtil::streamDate(item, t.getDate());
        item << "&nbsp;</tt></td>";
        item << "<td align='left'><b>&nbsp;&nbsp;" << why->getName() << "&nbsp;&nbsp;</b></td>";
        item << "<td align='right' width='20%'>&nbsp;";
        UiUtil::streamCurrency(item, t.getValue(), true);
        item << "&nbsp;</td>";
        item << "</tr>";

        item << "<tr>";
        item << "<td colspan='2'align='right'><small><i>" << from->getFullName() << " --> " << to->getFullName() << "</i></small>&nbsp;</td>";
        item << "</tr>";

        item << "</table>";

        wxString wxitem;
        UiUtil::appendStdString(wxitem, item.rdbuf()->str());
        items.Add(wxitem);
    }

    mainWindow_->populateTransactions(items);
    mainWindow_->scrollTransactionListAtEnd();
}

void Controller::transactionToView(int id, bool complete)
{
    Transaction t(id);
    DatabaseConnection::instance()->getTransaction(&t);
    mainWindow_->transactionToView(&t, complete);
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

void Controller::updateUndoRedoStatus()
{
    bool undo = false;
    bool redo = false;
    if (DatabaseConnection::isOpened()) {
        undo = DatabaseConnection::instance()->canUndo();
        redo = DatabaseConnection::instance()->canRedo();
    }
    mainWindow_->setUndoRedoView(undo, redo);
}

void Controller::undo()
{
    DatabaseConnection::instance()->undo();
    refreshAll();
    updateUndoRedoStatus();
}

void Controller::redo()
{
    DatabaseConnection::instance()->redo();
    refreshAll();
    updateUndoRedoStatus();
}

