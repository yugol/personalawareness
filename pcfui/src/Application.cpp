#include <UiUtil.h>
#include <MainWindow.h>
#include <Controller.h>
#include <Application.h>

// TODO: base|ui: intergrity check (purge undo buffer)

// TODO-: review variable names in code code
// from account -> source account
// to account -> destination account
// dump -> export
// load -> import
// budgets -> accounts
// credit/debit -> income/expenses
// initial value -> start balance
// path/file/fileName -> location pathFileExt convention

// TODO: no import confirmation for new databases

// TODO: REPORTS
// TODO: expenses/income yearly
// TODO: use the same item - show growth
// TODO: drawings
// TODO: mainwindow: net balance > Evolution Report button

// TODO: preferences: security tab
// TODO: preferences: lock database (can be opened by only one process at a time)
// TODO: preferences: password protection

// TODO: add help support
// TODO: write Google site

// TODO: optim: shorten SQL commands (remove spaces)
// TODO: optim: replace const char* with std::string
// TODO: optim: rename item updates only one entry in the list
// TODO: optim: use virtual list for transactions or change only the affected row
// TODO: optim: review refreshes in controller
// TODO: optim: read items in autocompletion only when showing the window for the first time
// TODO: optim: update only visible tabs in UI
// TODO: optim: use a thread to import/export database

// TODO-: compile under Windows

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
	Controller::instance()->initApplication(argc, reinterpret_cast<void**> (argv));
	return true;
}
