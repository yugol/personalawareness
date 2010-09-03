#include <wx/dateevt.h>
#include <wx/textctrl.h>
#include <wx/menu.h>
#include <wx/settings.h>
#include <wx/panel.h>
#include <wx/listctrl.h>
#include <wx/stattext.h>
#include <wx/button.h>
#include <wx/choice.h>
#include <wx/datectrl.h>
#include <wx/htmllbox.h>
#include <wx/combobox.h>
#include <wx/sizer.h>
#include <wx/notebook.h>
#include <AutocompletionWindow.h>
#include <Controller.h>
#include <MainWindow.h>

const int MainWindow::EMPTY_BORDER_SIZE = 5;

const long MainWindow::ID_SEL_VIEW = wxNewId();
const long MainWindow::ID_SEL_INTERVAL = wxNewId();
const long MainWindow::ID_SEL_FIRST = wxNewId();
const long MainWindow::ID_SEL_LAST = wxNewId();
const long MainWindow::ID_SEL_ACCOUNT = wxNewId();
const long MainWindow::ID_SEL_PATTERN = wxNewId();
const long MainWindow::ID_SEL_REPORTS = wxNewId();

const long MainWindow::ID_TRS_LIST = wxNewId();

const long MainWindow::ID_TR_VIEW = wxNewId();
const long MainWindow::ID_TR_DATE = wxNewId();
const long MainWindow::ID_TR_ITEM = wxNewId();
const long MainWindow::ID_TR_VALUE = wxNewId();
const long MainWindow::ID_TR_SOURCE = wxNewId();
const long MainWindow::ID_TR_DESTINATION = wxNewId();
const long MainWindow::ID_TR_COMMENT = wxNewId();
const long MainWindow::ID_TR_DELETE = wxNewId();
const long MainWindow::ID_TR_NEW = wxNewId();
const long MainWindow::ID_TR_ACCEPT = wxNewId();
//
BEGIN_EVENT_TABLE(MainWindow, wxFrame)

EVT_CLOSE(MainWindow::onClose)

EVT_MENU(ID_MENU_OPEN, MainWindow::onOpen)
EVT_MENU(ID_MENU_EXPORT, MainWindow::onExport)
EVT_MENU(ID_MENU_IMPORT, MainWindow::onImport)
EVT_MENU(ID_MENU_EXIT, MainWindow::onQuit)
EVT_MENU(ID_MENU_UNDO, MainWindow::onUndo)
EVT_MENU(ID_MENU_REDO, MainWindow::onRedo)
EVT_MENU(ID_MENU_ACCOUNTS, MainWindow::onAccounts)
EVT_MENU(ID_MENU_ITEMS, MainWindow::onItems)
EVT_MENU(ID_MENU_PREFERENCES, MainWindow::onPreferences)
EVT_MENU(ID_MENU_ABOUT, MainWindow::onAbout)

EVT_CHOICE(MainWindow::ID_SEL_INTERVAL, MainWindow::onSelectionIntervalChoice)
EVT_DATE_CHANGED(MainWindow::ID_SEL_FIRST, MainWindow::onSelectionFirstDateChanged)
EVT_DATE_CHANGED(MainWindow::ID_SEL_LAST, MainWindow::onSelectionLastDateChanged)
EVT_CHOICE(MainWindow::ID_SEL_ACCOUNT, MainWindow::onSelectionAccountChoice)
EVT_BUTTON(MainWindow::ID_SEL_REPORTS, MainWindow::onReports)

EVT_LISTBOX(MainWindow::ID_TRS_LIST, MainWindow::onTransactionSelected)

EVT_DATE_CHANGED(MainWindow::ID_TR_DATE, MainWindow::onTransactionDateChanged)
EVT_TEXT(MainWindow::ID_TR_ITEM, MainWindow::onTransactionItemText)
EVT_TEXT(MainWindow::ID_TR_VALUE, MainWindow::onTransactionValueText)
EVT_CHOICE(MainWindow::ID_TR_SOURCE, MainWindow::onTransactionSourceChoice)
EVT_CHOICE(MainWindow::ID_TR_DESTINATION, MainWindow::onTransactionDestinationChoice)
EVT_TEXT(MainWindow::ID_TR_COMMENT, MainWindow::onTransactionCommentText)

EVT_BUTTON(MainWindow::ID_TR_NEW, MainWindow::onNewTransaction)
EVT_BUTTON(MainWindow::ID_TR_DELETE, MainWindow::onDeleteTransaction)
EVT_BUTTON(MainWindow::ID_TR_ACCEPT, MainWindow::onAcceptTransaction)

EVT_BUTTON(MainWindow::ID_SEL_VIEW, MainWindow::onSelectionViewButton)
EVT_BUTTON(MainWindow::ID_TR_VIEW, MainWindow::onTransactionViewButton)

END_EVENT_TABLE()

MainWindow::MainWindow(wxFrame *frame, const wxString& title) :
    wxFrame(frame, -1, title), processTransactionEditEvents_ (false)
{
    // formatting

    errorHighlight_ = wxSystemSettings::GetColour(wxSYS_COLOUR_INFOBK);
    normalFont_ = wxSystemSettings::GetFont(wxSYS_DEFAULT_GUI_FONT);
    boldFont_ = wxSystemSettings::GetFont(wxSYS_DEFAULT_GUI_FONT);
    boldFont_.SetWeight(wxBOLD);

    wxSize viewButtonSize(16, 16);

#if wxUSE_MENUS
    // create a menu bar
    menuBar_ = new wxMenuBar();

    fileMenu_ = new wxMenu(wxEmptyString);
    fileMenu_->Append(ID_MENU_OPEN, wxT("&Open/Create..."), wxT("Open database or create a new one"));
    fileMenu_->AppendSeparator();
    fileMenu_->Append(ID_MENU_EXPORT, wxT("&Export..."), wxT("Export database to SQL script"));
    fileMenu_->Append(ID_MENU_IMPORT, wxT("&Import..."), wxT("Import database from SQL script"));
    fileMenu_->AppendSeparator();
    fileMenu_->Append(ID_MENU_EXIT, wxT("E&xit\tAlt-F4"), wxT("Exit the application"));
    menuBar_->Append(fileMenu_, wxT("Data&base"));

    editMenu_ = new wxMenu(wxEmptyString);
    editMenu_->Append(ID_MENU_UNDO, wxT("&Undo"), wxT("Undo the last action"));
    editMenu_->Append(ID_MENU_REDO, wxT("&Redo"), wxT("Redo the last action"));
    editMenu_->AppendSeparator();
    editMenu_->Append(ID_MENU_ACCOUNTS, wxT("&Accounts..."), wxT("Edit accounts and budget categories"));
    editMenu_->Append(ID_MENU_ITEMS, wxT("&Items..."), wxT("Edit items"));
    editMenu_->AppendSeparator();
    editMenu_->Append(ID_MENU_PREFERENCES, wxT("&Preferences..."), wxT("Edit preferences"));
    menuBar_->Append(editMenu_, wxT("&Edit"));

    helpMenu_ = new wxMenu(wxEmptyString);
    helpMenu_->Append(ID_MENU_ABOUT, wxT("&About\tF1"), wxT("Show info about this application"));
    menuBar_->Append(helpMenu_, wxT("&Help"));

    SetMenuBar(menuBar_);
#endif // wxUSE_MENUS
    // main tabs

    financialPages_ = new wxNotebook(this, wxNewId());
    accountsPage_ = new wxPanel(financialPages_, wxNewId());
    transactionsPage_ = new wxPanel(financialPages_, wxNewId());
    financialPages_->AddPage(accountsPage_, wxT("&Accounts"));
    financialPages_->AddPage(transactionsPage_, wxT("&Transactions"));

    // accounts_ page

    accountList_ = new wxListCtrl(accountsPage_, wxNewId(), wxDefaultPosition, wxSize(100, 100), wxLC_REPORT | wxLC_HRULES | wxVSCROLL | wxBORDER_SUNKEN);
    accountList_->InsertColumn(0, wxT("Name"), wxLIST_FORMAT_LEFT, 200);
    accountList_->InsertColumn(1, wxT("Balance"), wxLIST_FORMAT_RIGHT, 150);

    netWorthLabel_ = new wxStaticText(accountsPage_, wxNewId(), wxEmptyString);
    netWorthLabel_->SetFont(boldFont_);

    wxBoxSizer* labelSizer = new wxBoxSizer(wxHORIZONTAL);
    labelSizer->Add(0, 0, 1);
    labelSizer->Add(netWorthLabel_, 0, wxALL | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);

    accountsSizer_ = new wxBoxSizer(wxVERTICAL);
    accountsSizer_->Add(accountList_, 1, wxTOP | wxLEFT | wxRIGHT | wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    accountsSizer_->Add(labelSizer, 0, wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    accountsPage_->SetSizer(accountsSizer_);
    fitAccountsPage();

    // transactions page

    // - selection
    selViewButton_ = new wxButton(transactionsPage_, ID_SEL_VIEW, wxT("+"), wxDefaultPosition, viewButtonSize);

    selPanel_ = new wxPanel(transactionsPage_, wxNewId());

    selIntervalChoice_ = new wxChoice(selPanel_, ID_SEL_INTERVAL);
    selIntervalChoice_->SetToolTip(wxT("Select time interval"));
    populateSelectionIntervals();

    selFirstDatePicker_ = new wxDatePickerCtrl(selPanel_, ID_SEL_FIRST, wxDefaultDateTime, wxDefaultPosition, wxDefaultSize, wxDP_DEFAULT | wxDP_SHOWCENTURY);
    selFirstDatePicker_->SetToolTip(wxT("\'From\' date"));

    wxStaticText* selTowards = new wxStaticText(selPanel_, wxNewId(), wxT(">>"));

    selLastDatePicker_ = new wxDatePickerCtrl(selPanel_, ID_SEL_LAST, wxDefaultDateTime, wxDefaultPosition, wxDefaultSize, wxDP_DEFAULT | wxDP_SHOWCENTURY);
    selLastDatePicker_->SetToolTip(wxT("\'To\' date"));

    selAccountChoice_ = new wxChoice(selPanel_, ID_SEL_ACCOUNT);
    selAccountChoice_->SetToolTip(wxT("Select account"));

    selPatternText_ = new wxTextCtrl(selPanel_, ID_SEL_PATTERN);
    selPatternText_->SetToolTip(wxT("Select description"));

    reportsButton_ = new wxButton(selPanel_, ID_SEL_REPORTS, wxT("Reports"), wxDefaultPosition, wxDefaultSize, 0);

    // - transactions list
    transactionsList_ = new wxSimpleHtmlListBox(transactionsPage_, ID_TRS_LIST);

    // - transaction
    trViewButton_ = new wxButton(transactionsPage_, ID_TR_VIEW, wxT("-"), wxDefaultPosition, viewButtonSize);

    trPanel_ = new wxPanel(transactionsPage_, wxNewId());

    trDatePicker_ = new wxDatePickerCtrl(trPanel_, ID_TR_DATE, wxDefaultDateTime, wxDefaultPosition, wxDefaultSize, wxDP_DEFAULT | wxDP_SHOWCENTURY);
    trDatePicker_->SetToolTip(wxT("Transaction date"));

    trItemText_ = new wxTextCtrl(trPanel_, ID_TR_ITEM);
    trItemText_->SetToolTip(wxT("Transaction description"));
    trItemAutocompletion_ = new AutocompletionWindow(this, trItemText_);

    trValueText_ = new wxTextCtrl(trPanel_, ID_TR_VALUE);
    trValueText_->SetToolTip(wxT("Transaction value\n(numeric value)"));

    trSourceChoice_ = new wxChoice(trPanel_, ID_TR_SOURCE);
    trSourceChoice_->SetToolTip(wxT("Transaction source"));

    wxStaticText* trTowards = new wxStaticText(trPanel_, wxNewId(), wxT(">>"));

    trDestinationChoice_ = new wxChoice(trPanel_, ID_TR_DESTINATION);
    trDestinationChoice_->SetToolTip(wxT("Transaction destination"));

    trCommentText_ = new wxTextCtrl(trPanel_, ID_TR_COMMENT);
    trCommentText_->SetToolTip(wxT("Transaction comment\n(optional)"));

    trDeleteButton_ = new wxButton(trPanel_, ID_TR_DELETE, wxT("&Delete"));

    trNewButton_ = new wxButton(trPanel_, ID_TR_NEW, wxT("&New"));

    trAcceptButton_ = new wxButton(trPanel_, ID_TR_ACCEPT, wxT("Acce&pt"));

    wxBoxSizer* selSizerUp = new wxBoxSizer(wxHORIZONTAL);
    selSizerUp->Add(selIntervalChoice_, 1, wxALL | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    selSizerUp->Add(selFirstDatePicker_, 1, wxALL | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    selSizerUp->Add(selTowards, 0, wxTOP | wxBOTTOM | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    selSizerUp->Add(selLastDatePicker_, 1, wxALL | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);

    wxBoxSizer* selSizerDown = new wxBoxSizer(wxHORIZONTAL);
    selSizerDown->Add(selAccountChoice_, 1, wxBOTTOM | wxLEFT | wxRIGHT | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    selSizerDown->Add(selPatternText_, 1, wxBOTTOM | wxLEFT | wxRIGHT | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);

    wxBoxSizer* selSizer2 = new wxBoxSizer(wxVERTICAL);
    selSizer2->Add(selSizerUp, 0, wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    selSizer2->Add(selSizerDown, 0, wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);

    wxBoxSizer* selSizer = new wxBoxSizer(wxHORIZONTAL);
    selSizer->Add(selSizer2, 1, wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    selSizer->Add(reportsButton_, 0, wxALL | wxALIGN_TOP | wxALIGN_CENTER_HORIZONTAL, EMPTY_BORDER_SIZE);
    selPanel_->SetSizer(selSizer);
    selSizer->Fit(selPanel_);
    selSizer->SetSizeHints(selPanel_);

    wxBoxSizer* trSizerUp = new wxBoxSizer(wxHORIZONTAL);
    trSizerUp->Add(trDatePicker_, 1, wxALL | wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    trSizerUp->Add(trItemText_, 2, wxALL | wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    trSizerUp->Add(trValueText_, 1, wxALL | wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);

    wxBoxSizer* trSizerMiddle = new wxBoxSizer(wxHORIZONTAL);
    trSizerMiddle->Add(trSourceChoice_, 2, wxBOTTOM | wxLEFT | wxRIGHT | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    trSizerMiddle->Add(trTowards, 0, wxBOTTOM | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    trSizerMiddle->Add(trDestinationChoice_, 2, wxBOTTOM | wxLEFT | wxRIGHT | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    trSizerMiddle->Add(trCommentText_, 3, wxBOTTOM | wxLEFT | wxRIGHT | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);

    wxBoxSizer* trSizerBottom = new wxBoxSizer(wxHORIZONTAL);
    trSizerBottom->Add(trDeleteButton_, 0, wxBOTTOM | wxLEFT | wxRIGHT | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    trSizerBottom->Add(-1, -1, 1, wxBOTTOM | wxLEFT | wxRIGHT | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    trSizerBottom->Add(trNewButton_, 0, wxBOTTOM | wxLEFT | wxRIGHT | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    trSizerBottom->Add(trAcceptButton_, 0, wxBOTTOM | wxLEFT | wxRIGHT | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);

    wxBoxSizer* trSizer = new wxBoxSizer(wxVERTICAL);
    trSizer->Add(trSizerUp, 0, wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    trSizer->Add(trSizerMiddle, 0, wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    trSizer->Add(trSizerBottom, 0, wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    trPanel_->SetSizer(trSizer);
    trSizer->SetSizeHints(trPanel_);

    wxBoxSizer* trsTopSizer = new wxBoxSizer(wxHORIZONTAL);
    trsTopSizer->Add(selViewButton_, 0, wxTOP | wxLEFT | wxBOTTOM | wxALIGN_LEFT | wxALIGN_TOP, EMPTY_BORDER_SIZE);
    trsTopSizer->Add(selPanel_, 1, wxLEFT | wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);

    wxBoxSizer* trsBottomSizer = new wxBoxSizer(wxHORIZONTAL);
    trsBottomSizer->Add(trViewButton_, 0, wxTOP | wxLEFT | wxBOTTOM | wxALIGN_LEFT | wxALIGN_TOP, EMPTY_BORDER_SIZE);
    trsBottomSizer->Add(trPanel_, 1, wxLEFT | wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);

    transactionsSizer_ = new wxBoxSizer(wxVERTICAL);
    transactionsSizer_->Add(trsTopSizer, 0, wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    transactionsSizer_->Add(transactionsList_, 1, wxLEFT | wxRIGHT | wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    transactionsSizer_->Add(trsBottomSizer, 0, wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER_SIZE);
    transactionsPage_->SetSizer(transactionsSizer_);
    transactionsSizer_->Fit(transactionsPage_);
    transactionsSizer_->SetSizeHints(transactionsPage_);

#if wxUSE_STATUSBAR

    CreateStatusBar(2);
    SetStatusText(wxT("Ready"), 0);

#endif // wxUSE_STATUSBAR
    showSelectionPanel(false);
    showTransactionPanel(true);

    trItemText_->Connect(wxEVT_KEY_DOWN, wxKeyEventHandler(MainWindow::onTransactionItemKeyDown), NULL, this);
}

void MainWindow::setTransactionDirty(bool dirty)
{
    selectedTransactionDirty_ = dirty;
    trAcceptButton_->Enable(selectedTransactionDirty_);
    if (selectedTransactionDirty_) {
        checkItem();
    }
}

void MainWindow::fitAccountsPage()
{
    accountsSizer_->Fit(accountsPage_);
    accountsSizer_->SetSizeHints(accountsPage_);
}

void MainWindow::fitTransactionsPage()
{
    transactionsSizer_->Fit(transactionsPage_);
    transactionsSizer_->SetSizeHints(transactionsPage_);
}

void MainWindow::showSelectionPanel(bool visible)
{
    if (visible) {
        selViewButton_->SetLabel(wxT("-"));
    } else {
        selViewButton_->SetLabel(wxT("+"));
    }
    selPanel_->Show(visible);
    fitTransactionsPage();
}

void MainWindow::showTransactionPanel(bool visible)
{
    if (visible) {
        trViewButton_->SetLabel(wxT("-"));
    } else {
        trViewButton_->SetLabel(wxT("+"));
    }
    trPanel_->Show(visible);
    fitTransactionsPage();
}

void MainWindow::setStatusMessage(const wxString& message)
{
    SetStatusText(message, 0);
}

void MainWindow::populateSelectionIntervals()
{
    selIntervalChoice_->Append(wxT("All"), reinterpret_cast<void*> (SELECTION_INTERVAL_ALL));
    selIntervalChoice_->Append(wxT("Today"), reinterpret_cast<void*> (SELECTION_INTERVAL_TODAY));
    selIntervalChoice_->Append(wxT("This month"), reinterpret_cast<void*> (SELECTION_INTERVAL_THISMONTH));
    selIntervalChoice_->Append(wxT("This quarter"), reinterpret_cast<void*> (SELECTION_INTERVAL_THISQUARTER));
    selIntervalChoice_->Append(wxT("This year"), reinterpret_cast<void*> (SELECTION_INTERVAL_THISYEAR));
    selIntervalChoice_->Append(wxT("Last year"), reinterpret_cast<void*> (SELECTION_INTERVAL_LASTYEAR));
    selIntervalChoice_->Append(wxT("Custom"), reinterpret_cast<void*> (SELECTION_INTERVAL_CUSTOM));
}

void MainWindow::setUndoRedoView(bool undo, bool redo)
{
    editMenu_->Enable(ID_MENU_UNDO, undo);
    editMenu_->Enable(ID_MENU_REDO, redo);
}

void MainWindow::setDatabaseOpenedView(bool opened)
{
    menuBar_->EnableTop(1, opened);

    fileMenu_->Enable(ID_MENU_EXPORT, opened);
    fileMenu_->Enable(ID_MENU_IMPORT, opened);

    financialPages_->Show(opened);

    setInsertTransactionView();
}

void MainWindow::scrollTransactionListAtEnd()
{
    transactionsList_->ScrollToLine(transactionsList_->GetLineCount());
}

void MainWindow::setInsertTransactionView()
{
    selectedTransactionId_ = 0;
    transactionsList_->SetSelection(wxNOT_FOUND);
    transactionToView(0, true);
    trDeleteButton_->Hide();
    trNewButton_->Hide();
    trAcceptButton_->Disable();
}

void MainWindow::setUpdateTransactionView(bool dirty)
{
    setTransactionDirty(dirty);
    trDeleteButton_->Show();
    trNewButton_->Show();
}

void MainWindow::clearTransactionErrorHighlight()
{
    trItemText_->SetBackgroundColour(trCommentText_->GetBackgroundColour());
    trValueText_->SetBackgroundColour(trCommentText_->GetBackgroundColour());
    trSourceChoice_->SetBackgroundColour(trCommentText_->GetBackgroundColour());
    trDestinationChoice_->SetBackgroundColour(trCommentText_->GetBackgroundColour());
}
