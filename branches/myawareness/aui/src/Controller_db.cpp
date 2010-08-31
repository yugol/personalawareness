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
            string stdpath;
            UiUtil::appendWxString(stdpath, *path);
            DatabaseConnection::openDatabase(stdpath.c_str());
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
    string stdpath;
    UiUtil::appendWxString(stdpath, path);
    ofstream fout(stdpath.c_str(), ios_base::trunc);

    try {

        DatabaseConnection::exportDatabase(fout);
        wxMessageBox(_T("Operation completed successfully."), _T("Export database"), wxOK);

    } catch (const exception& ex) {
        reportException(ex, _T("exporting database"));
    }
}

void Controller::loadDatabase(wxString& path)
{
    string stdpath;
    UiUtil::appendWxString(stdpath, path);
    ifstream fin(stdpath.c_str());

    try {

        DatabaseConnection::importDatabase(fin);
        openDatabase(0);
        wxMessageBox(_T("Operation completed successfully."), _T("Import database"), wxOK);

    } catch (const exception& ex) {

        openDatabase(0);
        reportException(ex, _T("importing database"));

    }
}
