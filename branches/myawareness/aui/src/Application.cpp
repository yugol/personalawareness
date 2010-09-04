#include <MainWindow.h>
#include <Controller.h>
#include <Application.h>

// TBD+: select transactions according to item name pattern

// TBD: properties dialog
// TBD: count versions system
// TBD: About dialog
// TBD: create an icon
// TBD: time ticker

// TBD: REPORTS

// TBD: optim: rename description updates only the entry in the list
// TBD: optim: use virtual list for transactions or change only the affected row
// TBD: optim: review refreshes in controller
// TBD: optim: read descriptions in autocompletion only when showing the window for the first time
// TBD: optim: update only visible tabs in UI

// TBD: review undo/redo
// TBD: undo/redo buffer

// TBD: handle all errors in Window and not in controller
// TBD: get rid of magic numbers

// TBD-: csv import/export
// TBD-: MySQL & other DBMS compatible sql dump

// TBD-: properties table in database

// TBD-: rename 'item' to 'description' in UI
// TBD-: internationalization
// TBD-: rename code

// TBD: compile under Windows

// TBD: write help
// TBD: update Google code
// TBD: write Google site

IMPLEMENT_APP(Application)

bool Application::OnInit()
{
    MainWindow* aFrame = new MainWindow(0L, wxT(">-- TA DA --<"));
    Controller::instance_ = new Controller(aFrame);
    aFrame->SetSize(700, 525);
    aFrame->Show();
    aFrame->setDatabaseOpenedView(false);
    Controller::instance()->initApplication();
    return true;
}
