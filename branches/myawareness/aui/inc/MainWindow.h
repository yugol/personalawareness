#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <vector>
#include <wx/frame.h>

class wxPanel;
class wxBoxSizer;
class wxListCtrl;
class wxStaticText;
class wxButton;
class wxChoice;
class wxDatePickerCtrl;
class wxTextCtrl;
class wxSimpleHtmlListBox;
class wxComboBox;
class wxDateEvent;
class wxNotebook;
namespace adb {
    class Item;
    class Account;
    class Transaction;
    class SelectionParameters;
}

class MainWindow: public wxFrame {
public:
    MainWindow(wxFrame *frame, const wxString& title);

    void setNetWorth(double val);
    void setSelectionInterval(int choice);
    void setSelectionStartInterval();
    void setSelectionCustomInterval();
    void setStatusMessage(const wxString& message);

    void setDatabaseOpenedView(bool opened);
    void setUndoRedoView(bool undo, bool redo);
    void scrollTransactionListAtEnd();

    void populateAccounts(const std::vector<std::pair<adb::Account*, double> >& statement);
    void populateCreditingBudgets(const std::vector<adb::Account*>& budgets);
    void populateDebitingBudgets(const std::vector<adb::Account*>& budgets);
    void populateItems(const std::vector<const adb::Item*>& items);
    void populateTransactions(const wxArrayString& items);

    int getItemIndexById(int id);
    int getSourceIndexById(int id);
    int getDestinationIndexById(int id);
    void getTransactionSelectionParameters(adb::SelectionParameters* parameters);

    void transactionToView(const adb::Transaction* t, bool complete);

    void uiReport(const wxString& message, const wxString& title = wxEmptyString);

private:
    enum {
        SELECTION_INTERVAL_ALL = 0,
        SELECTION_INTERVAL_TODAY,
        SELECTION_INTERVAL_THISMONTH,
        SELECTION_INTERVAL_THISQUARTER,
        SELECTION_INTERVAL_THISYEAR,
        SELECTION_INTERVAL_LASTYEAR,
        SELECTION_INTERVAL_CUSTOM
    };

    static const int EMPTY_BORDER_SIZE;
    wxFont normalFont_;
    wxFont boldFont_;
    wxColour errorHighlight_;

    int selectedTransactionId_;
    bool selectedTransactionDirty_;

    void fitAccountsPage();
    void fitTransactionsPage();

    void showSelectionPanel(bool visible);
    void showTransactionPanel(bool visible);

    void updateSelectedTransactionId();

    void setInsertTransactionView();
    void setUpdateTransactionView(bool dirty = false);

    void checkItem();
    void setTransactionDirty(bool dirty = true);
    void populateSelectionIntervals();
    void clearTransactionErrorHighlight();
    void acceptTransaction();

    // controls

    enum {
        ID_MENU_OPEN = 1000, ID_MENU_EXPORT, ID_MENU_IMPORT, ID_MENU_EXIT, ID_MENU_UNDO, ID_MENU_REDO, ID_MENU_ACCOUNTS, ID_MENU_PREFERENCES, ID_MENU_ABOUT,

        ID_REPORT_EXPENSES_PIE, ID_REPORT_EXPENSES_MONTHLY, ID_REPORT_INCOME_PIE, ID_REPORT_INCOME_MONTHLY
    };

    static const long ID_SEL_VIEW;
    static const long ID_SEL_INTERVAL;
    static const long ID_SEL_FIRST;
    static const long ID_SEL_LAST;
    static const long ID_SEL_ACCOUNT;
    static const long ID_SEL_PATTERN;
    static const long ID_SEL_REPORTS;

    static const long ID_TRS_LIST;

    static const long ID_TR_VIEW;
    static const long ID_TR_DATE;
    static const long ID_TR_ITEM;
    static const long ID_TR_VALUE;
    static const long ID_TR_SOURCE;
    static const long ID_TR_DESTINATION;
    static const long ID_TR_COMMENT;
    static const long ID_TR_DELETE;
    static const long ID_TR_NEW;
    static const long ID_TR_ACCEPT;

    wxMenuBar* menuBar_;
    wxMenu* fileMenu_;
    wxMenu* editMenu_;
    wxMenu* helpMenu_;

    wxNotebook* financialPages_;
    wxPanel* accountsPage_;
    wxBoxSizer* accountsSizer_;
    wxPanel* transactionsPage_;
    wxBoxSizer* transactionsSizer_;

    wxListCtrl *accountList_;
    wxStaticText* netWorthLabel_;

    wxButton* selViewButton_;
    wxPanel* selPanel_;
    wxChoice* selIntervalChoice_;
    wxDatePickerCtrl* selFirstDatePicker_;
    wxDatePickerCtrl* selLastDatePicker_;
    wxChoice* selAccountChoice_;
    wxTextCtrl* selPatternText_;

    wxButton* reportsButton_;

    wxSimpleHtmlListBox* transactionsList_;

    wxButton* trViewButton_;
    wxPanel* trPanel_;
    wxDatePickerCtrl* trDatePicker_;
    wxComboBox* trItemCombo_;
    wxTextCtrl* trValueText_;
    wxChoice* trSourceChoice_;
    wxChoice* trDestinationChoice_;
    wxTextCtrl* trCommentText_;
    wxButton* trDeleteButton_;
    wxButton* trNewButton_;
    wxButton* trAcceptButton_;

    // events

    void onOpen(wxCommandEvent& event);
    void onExport(wxCommandEvent& event);
    void onImport(wxCommandEvent& event);
    void onQuit(wxCommandEvent& event);
    void onUndo(wxCommandEvent& event);
    void onRedo(wxCommandEvent& event);
    void onAbout(wxCommandEvent& event);
    void onClose(wxCloseEvent& event);

    void onExpensesPie(wxCommandEvent& event);
    void onExpensesMonthly(wxCommandEvent& event);
    void onIncomePie(wxCommandEvent& event);
    void onIncomeMonthly(wxCommandEvent& event);

    void onSelectionViewButton(wxCommandEvent& event);

    void onSelectionIntervalChoice(wxCommandEvent& event);
    void onSelectionFirstDateChanged(wxDateEvent& event);
    void onSelectionLastDateChanged(wxDateEvent& event);
    void onSelectionAccountChoice(wxCommandEvent& event);
    void onReports(wxCommandEvent& event);

    void onTransactionViewButton(wxCommandEvent& event);

    void onTransactionSelected(wxCommandEvent& event);
    void onTransactionDateChanged(wxDateEvent& event);
    void onTransactionItemKeyDown(wxKeyEvent& event);
    void onTransactionItemText(wxCommandEvent& event);
    void onTransactionValueKeyDown(wxKeyEvent& event);
    void onTransactionValueText(wxCommandEvent& event);
    void onTransactionSourceChoice(wxCommandEvent& event);
    void onTransactionDestinationChoice(wxCommandEvent& event);
    void onTransactionCommentText(wxCommandEvent& event);

    void onNewTransaction(wxCommandEvent& event);
    void onDeleteTransaction(wxCommandEvent& event);
    void onAcceptTransaction(wxCommandEvent& event);

DECLARE_EVENT_TABLE()
};

#endif // MAINWINDOW_H
