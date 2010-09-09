#include <UiUtil.h>
#include <MainWindow.h>
#include <Controller.h>
#include <Application.h>

// TBD: New button near Accept button when maximizing
// TBD: double click to edit transaction???

// TBD: handle all errors in Window and not in controller
// TBD: get rid of magic numbers

// TBD+: undo after deletng an item looses the name
// TBD: review undo/redo
// TBD: undo/redo buffer
// TBD: undo buffer length in properties

// TBD: REPORTS

// TBD: update Google code
// TBD: add help support
// TBD: write Google site

// TBD: optim: replace const char* with std::string
// TBD: optim: rename item updates only the entry in the list
// TBD: optim: use virtual list for transactions or change only the affected row
// TBD: optim: review refreshes in controller
// TBD: optim: read items in autocompletion only when showing the window for the first time
// TBD: optim: update only visible tabs in UI
// TBD: optim: use a thread to import/export database
// TBD: optim: shorten SQL commands (remove spaces)

// TBD-: internationalization
// TBD-: wxBuilder forms

// TBD-: review variable names in code code
// from account -> source account
// to account -> destination account
// dump -> export
// load -> import
// initial value -> start balance
// path/file/fileName -> location path file ext convention


// TBD-: compile under Windows

// TBD-: export table deletion & creation
// TBD-: csv import/export
// TBD-: MySQL & other DBMS compatible SQL dump


IMPLEMENT_APP(Application)

bool Application::OnInit()
{
    MainWindow* aFrame = new MainWindow(0L, UiUtil::getApplicationName(""));
    Controller::instance_ = new Controller(aFrame);
    aFrame->SetSize(700, 525);
    aFrame->Show();
    aFrame->setDatabaseOpenedView(false);
    Controller::instance()->initApplication();
    return true;
}
