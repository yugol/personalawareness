#include <wx/filedlg.h>
#include <wx/msgdlg.h>
#include <wx/panel.h>
#include <Controller.h>
#include <AccountsDialog.h>
#include <ItemsDialog.h>
#include <PreferencesDialog.h>
#include <AboutDialog.h>
#include <MainWindow.h>

//helper functions TBD-: remove them
enum wxbuildinfoformat {
    short_f, long_f
};

wxString wxbuildinfo(wxbuildinfoformat format)
{
    wxString wxbuild(wxVERSION_STRING);

    if (format == long_f) {
#if defined(__WXMSW__)
        wxbuild << wxT("-Windows");
#elif defined(__WXMAC__)
        wxbuild << wxT("-Mac");
#elif defined(__UNIX__)
        wxbuild << wxT("-Linux");
#endif

#if wxUSE_UNICODE
        wxbuild << wxT("-Unicode build");
#else
        wxbuild << wxT("-ANSI build");
#endif // wxUSE_UNICODE
    }

    return wxbuild;
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
}

void MainWindow::onTransactionViewButton(wxCommandEvent& event)
{
    showTransactionPanel(!transactionPanel_->IsShown());
}

