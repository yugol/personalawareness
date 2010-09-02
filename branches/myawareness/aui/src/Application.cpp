#include <MainWindow.h>
#include <Controller.h>
#include <Application.h>

// TBD+: accounts edit dialog
// TBD+: update search in transaction item combo when Ctrl + Space
// TBD: refresh main window only when closing edit dialogs
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
