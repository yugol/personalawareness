#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <vector>
#include <MainWindowBase.h>

class wxSimpleHtmlListBox;
class AutocompleteWindow;
class Item;
class Account;
class Transaction;
class SelectionParameters;
class ReversibleDatabaseCommand;

class MainWindow: public MainWindowBase {
public:
    MainWindow(wxWindow* parent);

    void setNetWorth(double val);
    void setSelectionInterval(int choice);
    void refreshSelectionInterval();
    void setSelectionDefaultInterval();
    void setSelectionCustomInterval();
    void setStatusMessage(const wxString& message);

    void setDatabaseOpenedView(bool opened);
    void setUndoRedoView(const ReversibleDatabaseCommand* undo, const ReversibleDatabaseCommand* redo);
    void scrollTransactionListAtEnd();

    void populateAccounts(const std::vector<std::pair<const Account*, double> >& statement);
    void populateCreditingBudgets(const std::vector<const Account*>& budgets);
    void populateDebitingBudgets(const std::vector<const Account*>& budgets);
    void populateItems(const std::vector<const Item*>& items);
    void populateTransactions(const wxArrayString& items);

    int getTransactionSourceIndexById(int id);
    int getTransactionDestinationIndexById(int id);
    void getTransactionSelectionParameters(SelectionParameters* parameters);

    void reportMessage(const wxString& message, const wxString& title = wxEmptyString);

protected:
    void onClose(wxCloseEvent& event);

    void onOpen(wxCommandEvent& event);
    void onExport(wxCommandEvent& event);
    void onImport(wxCommandEvent& event);
    void onQuit(wxCommandEvent& event);
    void onUndo(wxCommandEvent& event);
    void onRedo(wxCommandEvent& event);
    void onAccounts(wxCommandEvent& event);
    void onItems(wxCommandEvent& event);
    void onPreferences(wxCommandEvent& event);
    void onAbout(wxCommandEvent& event);

    void onSelectionViewButton(wxCommandEvent& event);
    void onSelectionIntervalChoice(wxCommandEvent& event);
    void onSelectionFirstDateChanged(wxDateEvent& event);
    void onSelectionLastDateChanged(wxDateEvent& event);
    void onSelectionAccountChoice(wxCommandEvent& event);
    void onSelectionPatternText(wxCommandEvent& event);
    void onReports(wxCommandEvent& event);

    void onTransactionViewButton(wxCommandEvent& event);
    void onTransactionDateChanged(wxDateEvent& event);
    void onTransactionItemKeyDown(wxKeyEvent& event);
    void onTransactionItemText(wxCommandEvent& event);
    void onTransactionValueText(wxCommandEvent& event);
    void onTransactionSourceChoice(wxCommandEvent& event);
    void onTransactionDestinationChoice(wxCommandEvent& event);
    void onTransactionCommentText(wxCommandEvent& event);

    void onDeleteTransaction(wxCommandEvent& event);
    void onNewTransaction(wxCommandEvent& event);
    void onAcceptTransaction(wxCommandEvent& event);

private:
    enum {
        SELECTION_INTERVAL_ALL = 0,
        SELECTION_INTERVAL_LASTDAY,
        SELECTION_INTERVAL_LASTMONTH,
        SELECTION_INTERVAL_LASTQUARTER,
        SELECTION_INTERVAL_LASTYEAR,
        SELECTION_INTERVAL_PREVYEAR,
        SELECTION_INTERVAL_ONEDAY,
        SELECTION_INTERVAL_CUSTOM
    };

    enum {
        ID_REPORT_EXPENSES_PIE, ID_REPORT_EXPENSES_MONTHLY, ID_REPORT_INCOME_PIE, ID_REPORT_INCOME_MONTHLY
    };

    wxFont normalFont_;
    wxFont boldFont_;

    wxSimpleHtmlListBox* transactionsList_;
    AutocompleteWindow* trItemAutocompletion_;
    bool processTransactionEditEvents_;

    void fitAccountsPage();
    void fitTransactionsPage();
    void showSelectionPanel(bool visible);
    void showTransactionPanel(bool visible);
    void populateSelectionIntervals();
    int getSelectedTransactionId();
    void selectTransaction(int transactionId, bool isAutocomplete = false);
    bool readValidateRefreshTransaction(Transaction* transaction = 0);

    void onExpensesPie(wxCommandEvent& event);
    void onExpensesMonthly(wxCommandEvent& event);
    void onIncomePie(wxCommandEvent& event);
    void onIncomeMonthly(wxCommandEvent& event);
    void onTransactionSelected(wxCommandEvent& event);

};

#endif // MAINWINDOW_H
