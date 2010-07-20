#ifdef WX_PRECOMP
#include "wx_pch.h"
#endif

#ifdef __BORLANDC__
#pragma hdrstop
#endif //__BORLANDC__
#include <wx/notebook.h>
#include <MainWindow.h>
#include <Controller.h>

//helper functions
enum wxbuildinfoformat {
	short_f, long_f
};

wxString wxbuildinfo(wxbuildinfoformat format)
{
	wxString wxbuild(wxVERSION_STRING);

	if (format == long_f) {
#if defined(__WXMSW__)
		wxbuild << _T("-Windows");
#elif defined(__WXMAC__)
		wxbuild << _T("-Mac");
#elif defined(__UNIX__)
		wxbuild << _T("-Linux");
#endif

#if wxUSE_UNICODE
		wxbuild << _T("-Unicode build");
#else
		wxbuild << _T("-ANSI build");
#endif // wxUSE_UNICODE
	}

	return wxbuild;
}

const int MainWindow::EMPTY_BORDER = 5;

const long MainWindow::ID_SEL_VIEW = wxNewId();
const long MainWindow::ID_SEL_INTERVAL = wxNewId();
const long MainWindow::ID_SEL_FROM = wxNewId();
const long MainWindow::ID_SEL_TO = wxNewId();
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

const wxColour MainWindow::errCol_(255, 0, 255);
BEGIN_EVENT_TABLE(MainWindow, wxFrame)

EVT_CLOSE(MainWindow::onClose)

EVT_MENU(ID_MENU_OPEN, MainWindow::onOpen)
EVT_MENU(ID_MENU_EXPORT, MainWindow::onExport)
EVT_MENU(ID_MENU_IMPORT, MainWindow::onImport)
EVT_MENU(ID_MENU_EXIT, MainWindow::onQuit)
EVT_MENU(ID_MENU_ABOUT, MainWindow::onAbout)

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

static wxMenuBar* mbar = 0;
static wxMenu* fileMenu = 0;
static wxMenu* editMenu = 0;
static wxMenu* helpMenu = 0;
static wxNotebook* financialPages = 0;

MainWindow::MainWindow(wxFrame *frame, const wxString& title) :
	wxFrame(frame, -1, title)
{
#if wxUSE_MENUS
	// create a menu bar
	mbar = new wxMenuBar();

	fileMenu = new wxMenu(_T(""));
	fileMenu->Append(ID_MENU_OPEN, _("&Open..."), _("Open database"));
	fileMenu->AppendSeparator();
	fileMenu->Append(ID_MENU_EXPORT, _("&Export..."), _("Export database to SQL script"));
	fileMenu->Append(ID_MENU_IMPORT, _("&Import..."), _("Import database from SQL script"));
	fileMenu->AppendSeparator();
	fileMenu->Append(ID_MENU_EXIT, _("E&xit\tAlt-F4"), _("Exit the application"));
	mbar->Append(fileMenu, _("&File"));

	editMenu = new wxMenu(_T(""));
	editMenu->Append(ID_MENU_UNDO, _("&Undo\tCtrl-Z"), _("Undo the last action"));
	editMenu->Append(ID_MENU_REDO, _("&Redo\tCtrl-Y"), _("Redo the last action"));
	editMenu->AppendSeparator();
	editMenu->Append(ID_MENU_ACCOUNTS, _("Accounts/Bugets..."), _("Edit accounts and budget categories"));
	editMenu->Append(ID_MENU_PREFERENCES, _("Preferences..."), _("Edit preferences"));
	mbar->Append(editMenu, _("&Edit"));

	helpMenu = new wxMenu(_T(""));
	helpMenu->Append(ID_MENU_ABOUT, _("&About\tF1"), _("Show info about this application"));
	mbar->Append(helpMenu, _("&Help"));

	SetMenuBar(mbar);
#endif // wxUSE_MENUS
	// formatting

	normalFont_ = wxSystemSettings::GetFont(wxSYS_DEFAULT_GUI_FONT);
	boldFont_ = wxSystemSettings::GetFont(wxSYS_DEFAULT_GUI_FONT);
	boldFont_.SetWeight(wxBOLD);
	wxSize viewButtonSize(12, 12);

	// create a tool bar

	toolBar_ = this->CreateToolBar(wxTB_HORIZONTAL | wxTB_NOICONS | wxTB_TEXT, wxID_ANY);
	toolBar_->AddTool(ID_MENU_OPEN, wxT("Open"), wxNullBitmap, wxNullBitmap, wxITEM_NORMAL, wxEmptyString,
			wxEmptyString);
	toolBar_->AddSeparator();
	toolBar_->AddTool(ID_MENU_UNDO, wxT("Undo"), wxNullBitmap, wxNullBitmap, wxITEM_NORMAL, wxEmptyString,
			wxEmptyString);
	toolBar_->AddTool(ID_MENU_REDO, wxT("Redo"), wxNullBitmap, wxNullBitmap, wxITEM_NORMAL, wxEmptyString,
			wxEmptyString);
	toolBar_->Realize();

	// main tabs

	financialPages = new wxNotebook(this, wxNewId());
	accPage_ = new wxPanel(financialPages, wxNewId());
	trPage_ = new wxPanel(financialPages, wxNewId());
	financialPages->AddPage(accPage_, _("Accounts"));
	financialPages->AddPage(trPage_, _("Transactions"));

	// accounts_ page

	accList_ = new wxListCtrl(accPage_, wxNewId(), wxDefaultPosition, wxSize(100, 100), wxLC_REPORT | wxLC_HRULES
			| wxVSCROLL | wxBORDER_SUNKEN);
	accList_->InsertColumn(0, _("Name"), wxLIST_FORMAT_LEFT, 200);
	accList_->InsertColumn(1, _("Balance"), wxLIST_FORMAT_RIGHT, 150);

	netWorthLabel_ = new wxStaticText(accPage_, wxNewId(), _(""));
	netWorthLabel_->SetFont(boldFont_);

	wxBoxSizer* labelSizer = new wxBoxSizer(wxHORIZONTAL);
	labelSizer->Add(0, 0, 1);
	labelSizer->Add(netWorthLabel_, 0, wxALL | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);

	accSizer_ = new wxBoxSizer(wxVERTICAL);
	accSizer_->Add(accList_, 1, wxTOP | wxLEFT | wxRIGHT | wxEXPAND | wxALIGN_CENTER_HORIZONTAL
			| wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	accSizer_->Add(labelSizer, 0, wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	accPage_->SetSizer(accSizer_);
	fitAccountsPage();

	// transactions page

	// - selection
	selViewButton_ = new wxButton(trPage_, ID_SEL_VIEW, _("+"), wxDefaultPosition, viewButtonSize);

	selPanel_ = new wxPanel(trPage_, wxNewId());

	selIntervalChoice_ = new wxChoice(selPanel_, ID_SEL_INTERVAL);
	selIntervalChoice_->SetToolTip(_("Select time interval"));

	selFromDatePicker_ = new wxDatePickerCtrl(selPanel_, ID_SEL_FROM, wxDefaultDateTime, wxDefaultPosition,
			wxDefaultSize, wxDP_DEFAULT | wxDP_SHOWCENTURY);
	selFromDatePicker_->SetToolTip(_("\'From\' date"));

	wxStaticText* selTowards = new wxStaticText(selPanel_, wxNewId(), _(">>"));

	selToDatePicker_ = new wxDatePickerCtrl(selPanel_, ID_SEL_TO, wxDefaultDateTime, wxDefaultPosition, wxDefaultSize,
			wxDP_DEFAULT | wxDP_SHOWCENTURY);
	selToDatePicker_->SetToolTip(_("\'To\' date"));

	selAccountChoice_ = new wxChoice(selPanel_, ID_SEL_ACCOUNT);
	selAccountChoice_->SetToolTip(_("Select account"));

	selPatternText_ = new wxTextCtrl(selPanel_, ID_SEL_PATTERN);
	selPatternText_->SetToolTip(_("Select description"));

	selReportsButton_ = new wxButton(selPanel_, ID_SEL_REPORTS, _("Reports"));

	// - transactions list
	transactionsList_ = new wxSimpleHtmlListBox(trPage_, ID_TRS_LIST);

	// - transaction
	trViewButton_ = new wxButton(trPage_, ID_TR_VIEW, _("-"), wxDefaultPosition, viewButtonSize);

	trPanel_ = new wxPanel(trPage_, wxNewId());

	trDatePicker_ = new wxDatePickerCtrl(trPanel_, ID_TR_DATE, wxDefaultDateTime, wxDefaultPosition, wxDefaultSize,
			wxDP_DEFAULT | wxDP_SHOWCENTURY);
	trDatePicker_->SetToolTip(_("Transaction date"));

	trItemCombo_ = new wxComboBox(trPanel_, ID_TR_ITEM);
	trItemCombo_->SetToolTip(_("Transaction description"));

	trValueText_ = new wxTextCtrl(trPanel_, ID_TR_VALUE);
	trValueText_->SetToolTip(_("Transaction value\n(numeric value)"));

	trSourceChoice_ = new wxChoice(trPanel_, ID_TR_SOURCE);
	trSourceChoice_->SetToolTip(_("Transaction source"));

	wxStaticText* trTowards = new wxStaticText(trPanel_, wxNewId(), _(">>"));

	trDestinationChoice_ = new wxChoice(trPanel_, ID_TR_DESTINATION);
	trDestinationChoice_->SetToolTip(_("Transaction destination"));

	trCommentText_ = new wxTextCtrl(trPanel_, ID_TR_COMMENT);
	trCommentText_->SetToolTip(_("Transaction comment\n(optional)"));

	trDeleteButton_ = new wxButton(trPanel_, ID_TR_DELETE, _("Delete"));

	trNewButton_ = new wxButton(trPanel_, ID_TR_NEW, _("New"));

	trAcceptButton_ = new wxButton(trPanel_, ID_TR_ACCEPT, _("Accept"));

	wxBoxSizer* selSizerUp = new wxBoxSizer(wxHORIZONTAL);
	selSizerUp->Add(selIntervalChoice_, 1, wxALL | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	selSizerUp->Add(selFromDatePicker_, 1, wxALL | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	selSizerUp->Add(selTowards, 0, wxTOP | wxBOTTOM | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	selSizerUp->Add(selToDatePicker_, 1, wxALL | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);

	wxBoxSizer* selSizerDown = new wxBoxSizer(wxHORIZONTAL);
	selSizerDown->Add(selAccountChoice_, 1, wxBOTTOM | wxLEFT | wxRIGHT | wxALIGN_CENTER_HORIZONTAL
			| wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	selSizerDown->Add(selPatternText_, 1, wxBOTTOM | wxLEFT | wxRIGHT | wxALIGN_CENTER_HORIZONTAL
			| wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);

	wxBoxSizer* selSizer2 = new wxBoxSizer(wxVERTICAL);
	selSizer2->Add(selSizerUp, 0, wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	selSizer2->Add(selSizerDown, 0, wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);

	wxBoxSizer* selSizer = new wxBoxSizer(wxHORIZONTAL);
	selSizer->Add(selSizer2, 1, wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	selSizer->Add(selReportsButton_, 0, wxALL | wxALIGN_TOP | wxALIGN_CENTER_HORIZONTAL, EMPTY_BORDER);
	selPanel_->SetSizer(selSizer);
	selSizer->Fit(selPanel_);
	selSizer->SetSizeHints(selPanel_);

	wxBoxSizer* trSizerUp = new wxBoxSizer(wxHORIZONTAL);
	trSizerUp->Add(trDatePicker_, 1, wxALL | wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	trSizerUp->Add(trItemCombo_, 2, wxALL | wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	trSizerUp->Add(trValueText_, 1, wxALL | wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);

	wxBoxSizer* trSizerMiddle = new wxBoxSizer(wxHORIZONTAL);
	trSizerMiddle->Add(trSourceChoice_, 2, wxBOTTOM | wxLEFT | wxRIGHT | wxALIGN_CENTER_HORIZONTAL
			| wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	trSizerMiddle->Add(trTowards, 0, wxBOTTOM | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	trSizerMiddle->Add(trDestinationChoice_, 2, wxBOTTOM | wxLEFT | wxRIGHT | wxALIGN_CENTER_HORIZONTAL
			| wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	trSizerMiddle->Add(trCommentText_, 3, wxBOTTOM | wxLEFT | wxRIGHT | wxALIGN_CENTER_HORIZONTAL
			| wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);

	wxBoxSizer* trSizerBottom = new wxBoxSizer(wxHORIZONTAL);
	trSizerBottom->Add(trDeleteButton_, 0, wxBOTTOM | wxLEFT | wxRIGHT | wxALIGN_CENTER_HORIZONTAL
			| wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	trSizerBottom->Add(-1, -1, 1, wxBOTTOM | wxLEFT | wxRIGHT | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	trSizerBottom->Add(trNewButton_, 0, wxBOTTOM | wxLEFT | wxRIGHT | wxALIGN_CENTER_HORIZONTAL
			| wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	trSizerBottom->Add(trAcceptButton_, 0, wxBOTTOM | wxLEFT | wxRIGHT | wxALIGN_CENTER_HORIZONTAL
			| wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);

	wxBoxSizer* trSizer = new wxBoxSizer(wxVERTICAL);
	trSizer->Add(trSizerUp, 0, wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	trSizer->Add(trSizerMiddle, 0, wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	trSizer->Add(trSizerBottom, 0, wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	trPanel_->SetSizer(trSizer);
	trSizer->SetSizeHints(trPanel_);

	wxBoxSizer* trsTopSizer = new wxBoxSizer(wxHORIZONTAL);
	trsTopSizer->Add(selViewButton_, 0, wxTOP | wxLEFT | wxBOTTOM | wxALIGN_LEFT | wxALIGN_TOP, EMPTY_BORDER);
	trsTopSizer->Add(selPanel_, 1, wxLEFT | wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);

	wxBoxSizer* trsBottomSizer = new wxBoxSizer(wxHORIZONTAL);
	trsBottomSizer->Add(trViewButton_, 0, wxTOP | wxLEFT | wxBOTTOM | wxALIGN_LEFT | wxALIGN_TOP, EMPTY_BORDER);
	trsBottomSizer->Add(trPanel_, 1, wxLEFT | wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);

	trsSizer_ = new wxBoxSizer(wxVERTICAL);
	trsSizer_->Add(trsTopSizer, 0, wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	trsSizer_->Add(transactionsList_, 1, wxLEFT | wxRIGHT | wxEXPAND | wxALIGN_CENTER_HORIZONTAL
			| wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	trsSizer_->Add(trsBottomSizer, 0, wxEXPAND | wxALIGN_CENTER_HORIZONTAL | wxALIGN_CENTER_VERTICAL, EMPTY_BORDER);
	trPage_->SetSizer(trsSizer_);
	trsSizer_->Fit(trPage_);
	trsSizer_->SetSizeHints(trPage_);

#if wxUSE_STATUSBAR
	// create a status bar with some information about the used wxWidgets version
	CreateStatusBar(2);
	SetStatusText(_("Ready"), 0);
	SetStatusText(wxbuildinfo(short_f), 1);
#endif // wxUSE_STATUSBAR
	showSelectionPanel(false);
	showTransactionPanel(true);

	trItemCombo_->Connect(wxEVT_KEY_DOWN, wxKeyEventHandler(MainWindow::onTransactionItemKeyDown), NULL, this);
}

MainWindow::~MainWindow()
{
}

void MainWindow::setDatabaseEnvironment(bool opened)
{
	fileMenu->Enable(ID_MENU_EXPORT, opened);
	fileMenu->Enable(ID_MENU_IMPORT, opened);
	mbar->EnableTop(1, opened);
	editMenu->Enable(ID_MENU_UNDO, false);
	editMenu->Enable(ID_MENU_REDO, false);

	toolBar_->EnableTool(ID_MENU_UNDO, false);
	toolBar_->EnableTool(ID_MENU_REDO, false);

	financialPages->Show(opened);

	setInsertTransactionEnv();
}

void MainWindow::fitAccountsPage()
{
	accSizer_->Fit(accPage_);
	accSizer_->SetSizeHints(accPage_);
}

void MainWindow::fitTransactionsPage()
{
	trsSizer_->Fit(trPage_);
	trsSizer_->SetSizeHints(trPage_);
}

void MainWindow::showSelectionPanel(bool visible)
{
	if (visible) {
		selViewButton_->SetLabel(_("-"));
	} else {
		selViewButton_->SetLabel(_("+"));
	}
	selPanel_->Show(visible);
	fitTransactionsPage();
}

void MainWindow::showTransactionPanel(bool visible)
{
	if (visible) {
		trViewButton_->SetLabel(_("-"));
	} else {
		trViewButton_->SetLabel(_("+"));
	}
	trPanel_->Show(visible);
	fitTransactionsPage();
}

void MainWindow::setInsertTransactionEnv()
{
	transactionId_ = 0;
	transactionsList_->SetSelection(wxNOT_FOUND);
	transactionsList_->ScrollToLine(transactionsList_->GetLineCount());
	transactionToView(0);
	trDeleteButton_->Hide();
	trNewButton_->Hide();
	trAcceptButton_->Disable();
	trAcceptButton_->SetLabel(_("Add"));
}

void MainWindow::setUpdateTransactionEnv(bool dirty)
{
	setTransactionDirty(dirty);
	trDeleteButton_->Show();
	trNewButton_->Show();
	trAcceptButton_->SetLabel(_("Update"));
}

void MainWindow::setTransactionDirty(bool dirty)
{
	transactionDirty_ = dirty;
	trAcceptButton_->Enable(transactionDirty_);
	if (transactionDirty_) {
		checkItem();
	}
}

void MainWindow::checkItem()
{
	int nChars = trItemCombo_->GetValue().Trim(true).Trim(false).size();
	if (nChars > 0) {
		trAcceptButton_->Enable();
	} else {
		trAcceptButton_->Disable();
	}
}

void MainWindow::onOpen(wxCommandEvent &event)
{
	wxString path;

	wxFileDialog* dlg = new wxFileDialog(0, _("Open database"), _T(""), _T(""), _T("*.db"));
	if (wxID_OK == dlg->ShowModal()) {
		path = dlg->GetPath();
	}
	delete dlg;

	if (path.size() > 0) {
		controller_->openDatabase(&path);
	}
}

void MainWindow::onQuit(wxCommandEvent &event)
{
	controller_->exitApplication();
}

void MainWindow::onAbout(wxCommandEvent &event)
{
	wxString msg = wxbuildinfo(long_f);
	wxMessageBox(msg, _("Welcome to..."));
}

void MainWindow::onClose(wxCloseEvent &event)
{
	controller_->exitApplication();
}

void MainWindow::onExport(wxCommandEvent& event)
{
	wxString path;

	wxFileDialog* dlg = new wxFileDialog(0, _("Export database"), _T(""), _T(""), _T("*.sql"));
	if (wxID_OK == dlg->ShowModal()) {
		path = dlg->GetPath();
	}
	delete dlg;

	if (path.size() > 0) {
		controller_->dumpDatabase(path);
	}
}

void MainWindow::onImport(wxCommandEvent& event)
{
	wxMessageDialog msgDlg(this,
			_T("This operation will completely erase\nthe current database.\nAre you sure you want to continue?"),
			_T("Database export"), wxYES | wxNO_DEFAULT);

	if (wxID_YES == msgDlg.ShowModal()) {
		wxString path;

		wxFileDialog* dlg = new wxFileDialog(0, _("Import database"), _T(""), _T(""), _T("*.sql"), wxFD_OPEN
				| wxFD_FILE_MUST_EXIST);
		if (wxID_OK == dlg->ShowModal()) {
			path = dlg->GetPath();
		}
		delete dlg;

		if (path.size() > 0) {
			controller_->loadDatabase(path);
		}
	}

	msgDlg.Destroy();
}

void MainWindow::onSelectionViewButton(wxCommandEvent& event)
{
	showSelectionPanel(!selPanel_->IsShown());
}

void MainWindow::onTransactionViewButton(wxCommandEvent& event)
{
	showTransactionPanel(!trPanel_->IsShown());
}

