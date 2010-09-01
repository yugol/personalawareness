#include <MainWindow.h>
#include <Controller.h>
#include <Application.h>

// TBD: accoutns items edit dialogs
// TBD-: properties
// TBD-: compact transaction list view
// TBD-: internationalization
// TBD-: About dialog
// TBD: insert transaction focuses on item
// TBD: investigate auto-completion of the item's last transaction
// TBD: time ticker

IMPLEMENT_APP(Application)

bool Application::OnInit()
{
    MainWindow* aFrame = new MainWindow(0L, _(">-- TA DA --<"));
    Controller::instance_ = new Controller(aFrame);
    aFrame->SetSize(700, 525);
    aFrame->Show();
    aFrame->setDatabaseOpenedView(false);
    Controller::instance()->start();
    return true;
}
