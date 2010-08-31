#include <fstream>
#include <wx/msgdlg.h>
#include <Controller.h>
#include <MainWindow.h>
#include <DatabaseConnection.h>
#include <UiUtil.h>

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
        mainWindow_->selectStartInterval(); // updates transactions

        // update status message

        wxString statusMessage;
        UiUtil::appendStdString(statusMessage, DatabaseConnection::instance()->getDatabaseFile());
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
