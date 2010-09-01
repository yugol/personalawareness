#include <MainWindow.h>
#include <Controller.h>
#include <Application.h>

// TBD+: alternate background colors in lists
// TBD+: Ctrl+Enter in tr edit value commits transaction
// TBD+: select transaction clears transaction editor errors
// TBD: change background color in pie reports table header
// TBD: accoutns items edit dialogs
// TBD: compact transaction list view
// TBD-: properties
// TBD-: internationalization
// TBD-: About dialog
// TBD: insert transaction focuses on item
// TBD: investigate auto-completion of the item's last transaction
// TBD: reports as frames not as dialogs
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
