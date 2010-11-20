#include <UiUtil.h>
#include <MainWindow.h>
#include <Controller.h>
#include <Application.h>

// TODO: disable optimisations when no database is opened

// TODO: compile under Windows

// TODO: use parentheses in expression parser
// TODO: remove duplicate items
// TODO: merge same item transactions in the same day

// TODO: optim: shorten SQL commands (remove some spaces)
// TODO: optim: use EMSG_ strings for all error messages
// TODO: optim: replace const char* with std::string
// TODO: optim: read items in auto-completion only when showing the window for the first time

// TODO: REPORTS
// TODO: titles in reports
// TODO: expenses/income yearly
// TODO: use the same item - show growth
// TODO: drawings
// TODO: mainwindow: net balance > Evolution Report button

// TODO: open database in only one instance of the application
// TODO: preferences: security tab
// TODO: preferences: lock database (can be opened by only one process at a time)
// TODO: preferences: password protection

// TODO: add help support
// TODO: write Google site

// TODO: optim: use a thread to import/export database
// TODO: optim: review refreshes in controller
// TODO: optim: update only visible tabs in UI
// TODO: optim: rename item updates only one entry in the list
// TODO: optim: use virtual list for transactions or change only the affected row

// TODO-: csv import/export

// TODO-: internationalization support

IMPLEMENT_APP(Application)

bool Application::OnInit()
{
    MainWindow* aFrame = new MainWindow(0);
    Controller::instance_ = new Controller(aFrame);
    aFrame->SetSize(700, 525);
    aFrame->Show();
    aFrame->setDatabaseOpenedView(false);
    Controller::instance()->initApplication(argc, argv);
    return true;
}
