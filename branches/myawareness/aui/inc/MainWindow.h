#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <utility>
#include <vector>
#include <wx/wx.h>
#include <wx/sizer.h>
#include <wx/toolbar.h>
#include <wx/listctrl.h>
#include <wx/stattext.h>
#include <wx/datectrl.h>
#include <wx/dateevt.h>
#include <wx/htmllbox.h>
#include <Account.h>
#include <Transaction.h>
#include <Item.h>
#include <SelectionParameters.h>

class Controller;

class MainWindow: public wxFrame {
public:
    MainWindow(wxFrame *frame, const wxString& title);

    void setController(Controller* controller);
    void setDatabaseEnvironment(bool opened);
    void setStatusMessage(const wxString& message);
    void setNetWorth(double val);
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

    static const int EMPTY_BORDER;
    wxFont normalFont_;
    wxFont boldFont_;
    static const wxColour errCol_;

    Controller* controller_;

    int transactionId_;
    bool transactionDirty_;

    void fitAccountsPage();
    void fitTransactionsPage();
    void showSelectionPanel(bool visible);
    void showTransactionPanel(bool visible);
    void setInsertTransactionEnv();
    void setUpdateTransactionEnv(bool dirty = false);
    void setTransactionDirty(bool dirty = true);
    void checkItem();
    void populateSelectionIntervals();

    // controls

    enum {
        ID_MENU_OPEN = 1000, ID_MENU_EXPORT, ID_MENU_IMPORT, ID_MENU_EXIT, ID_MENU_UNDO, ID_MENU_REDO, ID_MENU_ACCOUNTS, ID_MENU_PREFERENCES, ID_MENU_ABOUT
    };

    static const long ID_SEL_VIEW;
    static const long ID_SEL_INTERVAL;
    static const long ID_SEL_FROM;
    static const long ID_SEL_TO;
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

    wxPanel* accPage_;
    wxBoxSizer* accSizer_;
    wxPanel* trPage_;
    wxBoxSizer* trsSizer_;

    wxListCtrl *accList_;
    wxStaticText* netWorthLabel_;

    wxButton* selViewButton_;
    wxPanel* selPanel_;
    wxChoice* selIntervalChoice_;
    wxDatePickerCtrl* selFirstDatePicker_;
    wxDatePickerCtrl* selLastDatePicker_;
    wxChoice* selAccountChoice_;
    wxTextCtrl* selPatternText_;
    wxButton* selReportsButton_;

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
    void onAbout(wxCommandEvent& event);
    void onClose(wxCloseEvent& event);

    void onSelectionViewButton(wxCommandEvent& event);

    void onSelectionIntervalChoice(wxCommandEvent& event);
    void onSelectionAccountChoice(wxCommandEvent& event);

    void onTransactionViewButton(wxCommandEvent& event);

    void onTransactionSelected(wxCommandEvent& event);
    void onTransactionDateChanged(wxDateEvent& event);
    void onTransactionItemKeyDown(wxKeyEvent& event);
    void onTransactionItemText(wxCommandEvent& event);
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
