#include <MainWindow.h>
#include <Controller.h>
#include <Application.h>

// TBD+: readValidateRefresh for transactions
// TBD+: select transactions according to item name pattern
// TBD-: insert transaction focuses on item

// TBD: when selecting an item / account disable delete if it is used
// TBD: readValidateRefresh for items

// TBD: time ticker

// TBD: About dialog

// TBD: handle all errors in Window and not in controller

// TBD: propertied dialog
// TBD-: properties table in database

// TBD-: rename 'item' to 'description' in UI
// TBD-: internationalization

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
