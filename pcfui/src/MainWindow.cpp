#include <wx/htmllbox.h>
#include <wx/msgdlg.h>
#include <wx/filedlg.h>
#include <ReversibleDatabaseCommand.h>
#include <Transaction.h>
#include <UiUtil.h>
#include <AccountsDialog.h>
#include <ItemsDialog.h>
#include <PreferencesDialog.h>
#include <AutocompleteWindow.h>
#include <AboutDialog.h>
#include <Controller.h>
#include <MainWindow.h>

extern const char* RES_SMALL_ICON[];

MainWindow::MainWindow(wxWindow* parent) :
	MainWindowBase(parent), processTransactionEditEvents_(false)
{
	normalFont_ = wxSystemSettings::GetFont(wxSYS_DEFAULT_GUI_FONT);
	boldFont_ = wxSystemSettings::GetFont(wxSYS_DEFAULT_GUI_FONT);
	boldFont_.SetWeight(wxBOLD);

	accountList_->InsertColumn(0, wxT("Account"), wxLIST_FORMAT_LEFT, 200);
	accountList_->InsertColumn(1, wxT("Balance"), wxLIST_FORMAT_RIGHT, 150);

	populateSelectionIntervals();

	transactionsList_ = new wxSimpleHtmlListBox(transactionsPage_, wxID_ANY);
	middleTransactionsSizer_->Add(transactionsList_, 1, wxLEFT | wxRIGHT | wxEXPAND, 5);

	trItemAutocompletion_ = new AutocompleteWindow(this, trItemText_);

	showSelectionPanel(false);
	showTransactionPanel(true);

	wxIcon acorn32(RES_SMALL_ICON);
	SetIcon(acorn32);

	transactionsList_->Connect(wxEVT_COMMAND_LISTBOX_SELECTED, wxCommandEventHandler( MainWindow::onTransactionSelected ), NULL, this);

	SetStatusText(wxT("Ready"), 0);
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
		selectionViewButton_->SetLabel(wxT("-"));
	} else {
		selectionViewButton_->SetLabel(wxT("+"));
	}
	selectionPanel_->Show(visible);
	fitTransactionsPage();
}

void MainWindow::showTransactionPanel(bool visible)
{
	if (visible) {
		transactionsViewButton_->SetLabel(wxT("-"));
	} else {
		transactionsViewButton_->SetLabel(wxT("+"));
	}
	transactionPanel_->Show(visible);
	fitTransactionsPage();
}

void MainWindow::setStatusMessage(const wxString& message)
{
	SetStatusText(message, 0);
}

void MainWindow::setUndoRedoView(const ReversibleDatabaseCommand* undo, const ReversibleDatabaseCommand* redo)
{
	wxString undoMsg(wxT("Undo "));
	wxString redoMsg(wxT("Redo "));

	if (undo) {
		UiUtil::appendStdString(undoMsg, undo->getDescription());
	}
	if (redo) {
		UiUtil::appendStdString(redoMsg, redo->getDescription());
	}

	undoMenuItem_->SetHelp(undoMsg);
	redoMenuItem_->SetHelp(redoMsg);

	undoMenuItem_->Enable(undo);
	redoMenuItem_->Enable(redo);
}

void MainWindow::setDatabaseOpenedView(bool isOpened)
{
	mainMenu_->EnableTop(1, isOpened);
	exportSqlMenuItem_->Enable(isOpened);
	importSqlMenuItem_->Enable(isOpened);
	financialPages_->Show(isOpened);
	selectTransaction(0);
}

void MainWindow::scrollTransactionListAtEnd()
{
	transactionsList_->ScrollToLine(transactionsList_->GetLineCount());
}

void MainWindow::reportMessage(const wxString& message, const wxString& title)
{
	wxMessageBox(message, title, wxOK | wxCENTRE, this);
}

void MainWindow::onOpen(wxCommandEvent &event)
{
	wxFileDialog* dlg = new wxFileDialog(this, wxT("Open database"), wxEmptyString, wxEmptyString,
			wxT("Database files (*.cflow)|*.cflow|All files (*.*)|*.*"));
	if (wxID_OK == dlg->ShowModal()) {
		wxString location = dlg->GetPath();
		Controller::instance()->openDatabase(&location);
	}
	dlg->Destroy();
}

void MainWindow::onClose(wxCloseEvent &event)
{
	Controller::instance()->exitApplication();
}

void MainWindow::onExport(wxCommandEvent& event)
{
	wxString name;
	Controller::instance()->getDefaultSqlExportName(name);
	wxString path;
	Controller::instance()->getDatabasePath(path);

	wxFileDialog* dlg = new wxFileDialog(this, wxT("Export database"), wxEmptyString, name, wxT("*.sql"), wxFD_SAVE | wxFD_OVERWRITE_PROMPT);
	dlg->SetDirectory(path);
	if (wxID_OK == dlg->ShowModal()) {
		name = dlg->GetPath();
		Controller::instance()->dumpDatabase(name);
	}
	dlg->Destroy();
}

void MainWindow::onImport(wxCommandEvent& event)
{
	bool proceed = true;

	if (!Controller::instance()->isDatabaseEmpty()) {
		wxMessageDialog msgDlg(this, wxT("This operation will completely erase the current database.\n"
				"Are you sure you want to continue?"), wxT("Import database"), wxYES | wxNO_DEFAULT);
		proceed = (wxID_YES == msgDlg.ShowModal());
		msgDlg.Destroy();
	}

	if (proceed) {
		wxString path;
		Controller::instance()->getDatabasePath(path);

		wxFileDialog* dlg = new wxFileDialog(this, wxT("Import database"), wxEmptyString, wxEmptyString, wxT("*.sql"), wxFD_OPEN
				| wxFD_FILE_MUST_EXIST);
		dlg->SetDirectory(path);
		proceed = (dlg->ShowModal() == wxID_OK);
		path = dlg->GetPath();
		dlg->Destroy();

		if (proceed) {
			Controller::instance()->loadDatabase(path);
		}
	}
}

void MainWindow::onQuit(wxCommandEvent &event)
{
	Controller::instance()->exitApplication();
}

void MainWindow::onUndo(wxCommandEvent& event)
{
	Controller::instance()->undo();
}

void MainWindow::onRedo(wxCommandEvent& event)
{
	Controller::instance()->redo();
}

void MainWindow::onAccounts(wxCommandEvent& event)
{
	AccountsDialog* dlg = new AccountsDialog(this);
	dlg->ShowModal();
	dlg->Destroy();
}

void MainWindow::onItems(wxCommandEvent& event)
{
	ItemsDialog* dlg = new ItemsDialog(this);
	dlg->ShowModal();
	dlg->Destroy();
}

void MainWindow::onPreferences(wxCommandEvent& event)
{
	PreferencesDialog* dlg = new PreferencesDialog(this);
	if (wxID_OK == dlg->ShowModal()) {
		dlg->updatePreferences();
		Controller::instance()->refreshAll();
	}
	dlg->Destroy();
}

void MainWindow::onAbout(wxCommandEvent &event)
{
	AboutDialog* dlg = new AboutDialog(this);
	dlg->ShowModal();
	dlg->Destroy();
}

void MainWindow::onSelectionViewButton(wxCommandEvent& event)
{
	showSelectionPanel(!selectionPanel_->IsShown());
	showTransactionPanel(!selectionPanel_->IsShown());
}

void MainWindow::onTransactionViewButton(wxCommandEvent& event)
{
	showTransactionPanel(!transactionPanel_->IsShown());
}
