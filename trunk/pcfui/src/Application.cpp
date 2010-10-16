#include <UiUtil.h>
#include <MainWindow.h>
#include <Controller.h>
#include <Application.h>

// TBD: branza -> branzeturi

// TBD: base: automatically delete unused items at export

// TBD: ui: change default extension to .cflow
// TBD: ui: open command-line database parameter

// TBD-: evaluation result in status bar ?

// TBD-: review variable names in code code
// from account -> source account
// to account -> destination account
// dump -> export
// load -> import
// budgets -> accounts
// credit/debit -> income/expenses
// initial value -> start balance
// path/file/fileName -> location pathFileExt convention

// TBD: no import confirmation for new databases

// TBD: REPORTS
// TBD: expenses/income yearly
// TBD: use the same item - show growth
// TBD: drawings
// TBD: mainwindow: net balance > Evolution Report button

// TBD: preferences: security tab
// TBD: preferences: lock database (can be opened by only one process at a time)
// TBD: preferences: password protection

// TBD: add help support
// TBD: write Google site

// TBD: optim: shorten SQL commands (remove spaces)
// TBD: optim: replace const char* with std::string
// TBD: optim: rename item updates only one entry in the list
// TBD: optim: use virtual list for transactions or change only the affected row
// TBD: optim: review refreshes in controller
// TBD: optim: read items in autocompletion only when showing the window for the first time
// TBD: optim: update only visible tabs in UI
// TBD: optim: use a thread to import/export database

// TBD: preferences: application tab
// TBD: properties: format file
// TBD: properties: remember last X used databases
// TBD: properties: automatically open last used database

// TBD-: compile under Windows

// TBD-: csv import/export

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
