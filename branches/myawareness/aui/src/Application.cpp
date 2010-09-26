#include <UiUtil.h>
#include <MainWindow.h>
#include <Controller.h>
#include <Application.h>

// TBD: save last modification date in database
// TBD: About gives DB statistics
// TBD: Application icon
// TBD: configuration file name is .awareness.cfg
// TBD: export database folder defaults to database path
// TBD+: instead of tool tips use statusbar and colors
// TBD: Accounts menu item help string -> Edit accounts
// TBD-: Ctrl + Enter accepts transaction (if acceptable)
// TBD: transaction selection period Today -> Last day
// TBD: transaction selection period remove previous year
// TBD: transaction selection perios -> One day simplify selection of a day
// TBD: autocomplete window when no selection select last item
// TBD: preferences: hide 0 balance accounts
// TBD: about window: title Wercome to... -> This is ...

// TBD: REPORTS
// TBD: expenses/income yearly
// TBD: use the same item - show growth
// TBD: drawings

// TBD: update Google code
// TBD: add help support
// TBD: write Google site

// TBD: optim: replace const char* with std::string
// TBD: optim: rename item updates only one entry in the list
// TBD: optim: use virtual list for transactions or change only the affected row
// TBD: optim: review refreshes in controller
// TBD: optim: read items in autocompletion only when showing the window for the first time
// TBD: optim: update only visible tabs in UI
// TBD: optim: use a thread to import/export database
// TBD: optim: shorten SQL commands (remove spaces)

// TBD-: review variable names in code code
// from account -> source account
// to account -> destination account
// dump -> export
// load -> import
// initial value -> start balance
// path/file/fileName -> location path file ext convention

// TBD-: compile under Windows

// TBD-: csv import/export
// TBD-: export table deletion & creation
// TBD-: MySQL & other DBMS compatible SQL dump

// TBD-: internationalization support

IMPLEMENT_APP(Application)

bool Application::OnInit()
{
    MainWindow* aFrame = new MainWindow(0);
    Controller::instance_ = new Controller(aFrame);
    aFrame->SetSize(700, 525);
    aFrame->Show();
    aFrame->setDatabaseOpenedView(false);
    Controller::instance()->initApplication();
    return true;
}
