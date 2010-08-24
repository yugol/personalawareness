#include <MainWindow.h>
#include <Controller.h>

//helper functions TODO: remove them
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

void MainWindow::onQuit(wxCommandEvent &event)
{
    controller_->exitApplication();
}

void MainWindow::onAbout(wxCommandEvent &event)
{
    wxString msg = wxbuildinfo(long_f);
    wxMessageBox(msg, _("Welcome to..."));
}

void MainWindow::onSelectionViewButton(wxCommandEvent& event)
{
    showSelectionPanel(!selPanel_->IsShown());
}

void MainWindow::onTransactionViewButton(wxCommandEvent& event)
{
    showTransactionPanel(!trPanel_->IsShown());
}

void MainWindow::onSelectionAccountChoice(wxCommandEvent& event)
{
    controller_->updateTransactions();
}

