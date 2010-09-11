#include <wx/htmllbox.h>
#include <ReversibleDatabaseCommand.h>
#include <UiUtil.h>
#include <AutocompletionWindow.h>
#include <Controller.h>
#include <MainWindow.h>

using namespace adb;

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

    trItemAutocompletion_ = new AutocompletionWindow(this, trItemText_);

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

