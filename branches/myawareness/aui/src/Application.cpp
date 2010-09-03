#include <MainWindow.h>
#include <Controller.h>
#include <Application.h>

// TBD+: select transactions according to item name pattern

// TBD: readValidateRefreshTransaction for items
// TBD: when selecting an item / account disable delete if it is used

// TBD: properties dialog
// TBD: count versions system
// TBD: About dialog
// TBD: create an icon
// TBD: time ticker

// TBD: review undo/redo

// TBD: handle all errors in Window and not in controller
// TBD: get rid of magic numbers

// TBD: csv import/export
// TBD: MySQL & other DBMS compatible sql dump

// TBD-: properties table in database

// TBD-: rename 'item' to 'description' in UI
// TBD-: internationalization
// TBD-: rename code

// TBD: compile under Windows

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
