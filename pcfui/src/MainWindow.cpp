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

    accountList_->InsertColumn(0, wxT("Name"), wxLIST_FORMAT_LEFT, 200);
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

void MainWindow::populateSelectionIntervals()
{
    selIntervalChoice_->Append(wxT("All"), reinterpret_cast<void*> (SELECTION_INTERVAL_ALL));
    selIntervalChoice_->Append(wxT("Today"), reinterpret_cast<void*> (SELECTION_INTERVAL_TODAY));
    selIntervalChoice_->Append(wxT("Last month"), reinterpret_cast<void*> (SELECTION_INTERVAL_LASTMONTH));
    selIntervalChoice_->Append(wxT("Last quarter"), reinterpret_cast<void*> (SELECTION_INTERVAL_LASTQUARTER));
    selIntervalChoice_->Append(wxT("Last year"), reinterpret_cast<void*> (SELECTION_INTERVAL_LASTYEAR));
    selIntervalChoice_->Append(wxT("Previous year"), reinterpret_cast<void*> (SELECTION_INTERVAL_PREVYEAR));
    selIntervalChoice_->Append(wxT("Custom"), reinterpret_cast<void*> (SELECTION_INTERVAL_CUSTOM));
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

void MainWindow::setDatabaseOpenedView(bool opened)
{
    mainMenu_->EnableTop(1, opened);
    exportSqlMenuItem_->Enable(opened);
    importSqlMenuItem_->Enable(opened);
    financialPages_->Show(opened);
    selectTransaction(0);
}

void MainWindow::scrollTransactionListAtEnd()
{
    transactionsList_->ScrollToLine(transactionsList_->GetLineCount());
}

void MainWindow::setSelectionInterval(int choice)
{
    wxDateTime firstDate;
    wxDateTime lastDate;
    int year, month;

    Transaction lastTransaction;
    Controller::instance()->selectLastTransaction(&lastTransaction);
    if (lastTransaction.getId() == 0) {
        lastDate = wxDateTime::Today();
    } else {
        UiUtil::adbDate2wxDate(lastDate, lastTransaction.getDate());
    }

    switch (choice) {
        case SELECTION_INTERVAL_ALL:
            firstDate.SetDay(1);
            firstDate.SetMonth(wxDateTime::Jan);
            firstDate.SetYear(1900);
            break;
        case SELECTION_INTERVAL_TODAY:
            firstDate = wxDateTime::Today();
            lastDate = wxDateTime::Today();
            break;
        case SELECTION_INTERVAL_LASTMONTH:
            firstDate = lastDate;
            firstDate.SetDay(1);
            break;
        case SELECTION_INTERVAL_LASTQUARTER:
            year = lastDate.GetYear();
            month = lastDate.GetMonth() - 2;
            if (month < wxDateTime::Jan) {
                --year;
                month = wxDateTime::Inv_Month - ::abs(month);
            }
            firstDate.SetDay(1);
            firstDate.SetMonth(static_cast<wxDateTime::Month> (month));
            firstDate.SetYear(year);
            break;
        case SELECTION_INTERVAL_LASTYEAR:
            firstDate = lastDate;
            firstDate.SetDay(1);
            firstDate.SetMonth(wxDateTime::Jan);
            break;
        case SELECTION_INTERVAL_PREVYEAR:
            year = lastDate.GetYear() - 1;
            firstDate.SetDay(1);
            firstDate.SetMonth(wxDateTime::Jan);
            firstDate.SetYear(year);
            lastDate.SetDay(31);
            lastDate.SetMonth(wxDateTime::Dec);
            lastDate.SetYear(year);
            break;
        default:
            return;
    }

    selFirstDatePicker_->SetValue(firstDate);
    selLastDatePicker_->SetValue(lastDate);
}

void MainWindow::setSelectionStartInterval()
{
    for (unsigned int choice = 0; choice < selIntervalChoice_->GetCount(); ++choice) {
        int data = reinterpret_cast<int> (selIntervalChoice_->GetClientData(choice));
        if (SELECTION_INTERVAL_LASTQUARTER == data) {
            selIntervalChoice_->Select(choice);
            setSelectionInterval(choice);
            break;
        }
    }
}

void MainWindow::setSelectionCustomInterval()
{
    for (unsigned int i = 0; i < selIntervalChoice_->GetCount(); ++i) {
        int data = reinterpret_cast<int> (selIntervalChoice_->GetClientData(i));
        if (SELECTION_INTERVAL_CUSTOM == data) {
            selIntervalChoice_->Select(i);
            break;
        }
    }
}

void MainWindow::reportMessage(const wxString& message, const wxString& title)
{
    wxMessageBox(message, title, wxOK | wxCENTRE, this);
}

void MainWindow::onOpen(wxCommandEvent &event)
{
    wxFileDialog* dlg = new wxFileDialog(this, wxT("Open database"), wxEmptyString, wxEmptyString, wxT("Database files (*.db)|*.db|All files (*.*)|*.*"));
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

    wxFileDialog* dlg = new wxFileDialog(this, wxT("Export database"), wxEmptyString, name, wxT("*.sql"), wxFD_SAVE | wxFD_OVERWRITE_PROMPT);
    if (wxID_OK == dlg->ShowModal()) {
        name = dlg->GetPath();
        Controller::instance()->dumpDatabase(name);
    }
    dlg->Destroy();
}

void MainWindow::onImport(wxCommandEvent& event)
{
    wxMessageDialog msgDlg(this, wxT("This operation will completely erase the current database.\nAre you sure you want to continue?"), wxT("Import database"), wxYES | wxNO_DEFAULT);

    if (wxID_YES == msgDlg.ShowModal()) {
        wxString path;

        wxFileDialog* dlg = new wxFileDialog(this, wxT("Import database"), wxEmptyString, wxEmptyString, wxT("*.sql"), wxFD_OPEN | wxFD_FILE_MUST_EXIST);
        if (wxID_OK == dlg->ShowModal()) {
            path = dlg->GetPath();
        }
        dlg->Destroy();

        if (path.size() > 0) {
            Controller::instance()->loadDatabase(path);
        }
    }

    msgDlg.Destroy();
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
    // TBD: update transactions
}

void MainWindow::onTransactionViewButton(wxCommandEvent& event)
{
    showTransactionPanel(!transactionPanel_->IsShown());
    // TBD: update transactions
}
