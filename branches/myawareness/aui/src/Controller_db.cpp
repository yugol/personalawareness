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
        } else {
            DatabaseConnection::instance(); // opens default database
        }

        mainWindow_->setSelectionStartInterval();
        updateAll();

    } catch (const exception& ex) {
        reportException(ex, _T("opening database"));
    }

    if (DatabaseConnection::isOpened()) {
        mainWindow_->SetTitle(UiUtil::getApplicationName(DatabaseConnection::instance()->getDatabaseFile()));
        mainWindow_->setStatusMessage(UiUtil::getUsingStatusMessage(DatabaseConnection::instance()->getDatabaseFile()));
    } else {
        mainWindow_->SetTitle(UiUtil::getApplicationName(""));
        mainWindow_->setStatusMessage(UiUtil::getUsingStatusMessage(""));
    }
    mainWindow_->setDatabaseOpenedView(DatabaseConnection::isOpened());
    updateUndoRedoStatus();
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
