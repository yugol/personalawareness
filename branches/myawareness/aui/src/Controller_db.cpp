#ifdef WX_PRECOMP
#include "wx_pch.h"
#endif

#ifdef __BORLANDC__
#pragma hdrstop
#endif //__BORLANDC__
#include <fstream>
#include <wx/msgdlg.h>
#include <Controller.h>
#include <MainWindow.h>

using namespace std;
using namespace adb;

void Controller::openDatabase(const wxString* path)
{
    try {

        if (0 != path) {
            DatabaseConnection::openDatabase(path->fn_str());
        }

        updateAccounts();
        updateItems();
        updateTransactions();

        // update status message

        wxString statusMessage(DatabaseConnection::instance()->getDatabaseFile().c_str(), wxConvLibc);
        statusMessage = statusMessage.AfterLast('\\');
        statusMessage = statusMessage.AfterLast('/');
        statusMessage.Prepend(_T("Using: "));
        mainWindow_->setStatusMessage(statusMessage);

        mainWindow_->setDatabaseEnvironment(true);

    } catch (const exception& ex) {
        reportException(ex, _T("opening database"));
    }
}

void Controller::dumpDatabase(wxString& path)
{
    ofstream fout(path.fn_str(), ios_base::trunc);

    DatabaseConnection::exportDatabase(fout);

    wxMessageDialog dlg(mainWindow_, _T("Operation completed successfully."), _T("Database export"), wxOK);
    dlg.ShowModal();
    dlg.Destroy();
}

void Controller::loadDatabase(wxString& path)
{
    ifstream fin(path.fn_str());

    DatabaseConnection::importDatabase(fin, 0);

    wxMessageDialog dlg(mainWindow_, _T("Operation completed successfully."), _T("Database import"), wxOK);
    dlg.ShowModal();
    dlg.Destroy();
}
