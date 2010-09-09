#include <algorithm>
#include <sstream>
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
using namespace adb;

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

void Controller::insertUpdateAccount(adb::Account* account)
{
    DatabaseConnection::instance()->insertUpdate(account);
    refreshAccounts();
    refreshUndoRedoStatus();
}

void Controller::deleteAccount(int accountId)
{
    DatabaseConnection::instance()->deleteAccount(accountId);
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

void Controller::insertUpdateItem(adb::Item* item)
{
    DatabaseConnection::instance()->insertUpdate(item);
    refreshItems();
    refreshUndoRedoStatus();
}

void Controller::deleteItem(int itemId)
{
    try {

        DatabaseConnection::instance()->deleteItem(itemId);
        refreshItems();
        refreshUndoRedoStatus();

    } catch (const exception& ex) {
        if (0 == ::strstr(ex.what(), Exception::RECORD_IN_USE)) {
            reportException(ex, wxT("deleting item"));
        } else {
            throw Exception("Cannot delete item because it is used by a transaction!");
        }
    }
}

void Controller::selectTransaction(Transaction* transaction, int transactionId)
{
    transaction->setId(transactionId);
    DatabaseConnection::instance()->getTransaction(transaction);
}

void Controller::selectLastTransaction(adb::Transaction* transaction)
{
    DatabaseConnection::instance()->getLastTransaction(transaction);
}

void Controller::insertUpdateTransaction(Transaction* transaction)
{
    try {

        DatabaseConnection::instance()->insertUpdate(transaction);
        refreshTransactions();
        refreshAccounts();
        refreshUndoRedoStatus();

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
        refreshUndoRedoStatus();

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
            item << "<td colspan='2'align='right'><small><i><font color='DarkSlateGray'>" << from->getFullName() << " --> " << to->getFullName() << "</font></i></small>&nbsp;</td>";
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

