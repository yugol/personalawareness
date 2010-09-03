#include <MainWindow.h>
#include <Controller.h>
#include <Application.h>

// TBD+: update search in transaction item combo when Ctrl + Space
// TBD-: rename 'item' to 'description' in UI
// TBD: readValidateRefresh for items
// TBD: readValidateRefresh for accounts
// TBD: handle all errors in Window and not in controller
// TBD: color values in transaction list (red, blue, black)
// TBD: when selecting an item / account disable delete if it is used
// TBD: select transactions according to item name pattern
// TBD: use properties from Configuration
// TBD-: properties table in database
// TBD-: compact transaction list view
// TBD-: internationalization
// TBD-: About dialog
// TBD-: insert transaction focuses on item
// TBD-: time ticker

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
