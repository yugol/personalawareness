#include <sstream>
#include <fstream>
#include <wx/file.h>
#include <Controller.h>
#include <MainWindow.h>
#include <DatabaseConnection.h>
#include <UiUtil.h>

using namespace std;
using namespace adb;

void Controller::openDatabase(const wxString* location)
{
    try {

        if (0 != location) {
            string pathFileExt;
            UiUtil::appendWxString(pathFileExt, *location);
            if (!wxFile::Exists(location->wc_str())) {
                ostringstream ext;
                UiUtil::streamFileExt(ext, pathFileExt);
                if (ext.rdbuf()->str() != "db") {
                    pathFileExt.append(".db");
                }
            }
            DatabaseConnection::openDatabase(pathFileExt.c_str());
        } else {
            DatabaseConnection::instance(); // opens default database
        }

        mainWindow_->setSelectionStartInterval();
        refreshAll();

    } catch (const exception& ex) {

        reportException(ex, wxT("opening database"));

    }

    // update interface
    if (DatabaseConnection::isOpened()) {
        mainWindow_->SetTitle(UiUtil::getApplicationName(DatabaseConnection::instance()->getDatabaseLocation()));
        mainWindow_->setStatusMessage(UiUtil::getUsingStatusMessage(DatabaseConnection::instance()->getDatabaseLocation()));
    } else {
        mainWindow_->SetTitle(UiUtil::getApplicationName(""));
        mainWindow_->setStatusMessage(UiUtil::getUsingStatusMessage(""));
    }
    refreshUndoRedoStatus();
    mainWindow_->setDatabaseOpenedView(DatabaseConnection::isOpened());
}

void Controller::dumpDatabase(wxString& path)
{
    string stdpath;
    UiUtil::appendWxString(stdpath, path);
    ofstream fout(stdpath.c_str(), ios_base::trunc);

    try {

        DatabaseConnection::exportDatabase(fout);
        mainWindow_->uiReport(wxT("Operation completed successfully."), wxT("Export database"));

    } catch (const exception& ex) {

        reportException(ex, wxT("exporting database"));

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
        mainWindow_->uiReport(wxT("Operation completed successfully."), wxT("Import database"));

    } catch (const exception& ex) {

        openDatabase(0);
        reportException(ex, wxT("importing database"));

    }
}
