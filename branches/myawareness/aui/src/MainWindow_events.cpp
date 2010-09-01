#include <wx/filedlg.h>
#include <wx/msgdlg.h>
#include <wx/panel.h>
#include <Controller.h>
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

void MainWindow::onOpen(wxCommandEvent &event)
{
    wxFileDialog* dlg = new wxFileDialog(this, _("Open database"), _T(""), _T(""), _T("Database files (*.db)|*.db|All files (*.*)|*.*"));
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

    wxFileDialog* dlg = new wxFileDialog(this, _("Export database"), _T(""), name, _T("*.sql"), wxFD_SAVE | wxFD_OVERWRITE_PROMPT);
    if (wxID_OK == dlg->ShowModal()) {
        name = dlg->GetPath();
        Controller::instance()->dumpDatabase(name);
    }
    dlg->Destroy();
}

void MainWindow::onImport(wxCommandEvent& event)
{
    wxMessageDialog msgDlg(this, _T("This operation will completely erase the current database.\nAre you sure you want to continue?"), _T("Import database"), wxYES | wxNO_DEFAULT);

    if (wxID_YES == msgDlg.ShowModal()) {
        wxString path;

        wxFileDialog* dlg = new wxFileDialog(this, _("Import database"), _T(""), _T(""), _T("*.sql"), wxFD_OPEN | wxFD_FILE_MUST_EXIST);
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

void MainWindow::onAbout(wxCommandEvent &event)
{
    wxString msg = wxbuildinfo(long_f);
    wxMessageBox(msg, _("Welcome to..."));
}

void MainWindow::onSelectionViewButton(wxCommandEvent& event)
{
    showSelectionPanel(!selPanel_->IsShown());
    if (selPanel_->IsShown()) {
        showTransactionPanel(false);
    }
}

void MainWindow::onTransactionViewButton(wxCommandEvent& event)
{
    showTransactionPanel(!trPanel_->IsShown());
}

