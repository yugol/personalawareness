#include <MainWindow.h>
#include <Controller.h>
#include <Application.h>

// TBD+: 'Delete' transaction buton action
// TBD+: ensure database extension is .db when saving
// TBD+: ensure export extension is .sql when saving + provide default name
// TBD: properties
// TBD: accoutns items edit dialogs
// TBD: compact transaction list view
// TBD: undo/redo
// TBD-: internationalization
// TBD: About dialog
// TBD: select transaction clears transaction editor errors
// TBD: alternate background colors in lists
// TBD+: move transaction list at ent when changing date in selection
// TBD: Ctrl+Enter in tr edit value commits transaction
// TBD: insert transaction focuses on item
// TBD: investigate auto-completion of the item's last transaction
// TBD: change background color in pie reports table header
// TBD: reports ass frames not as dialogs

IMPLEMENT_APP(Application)

bool Application::OnInit()
{
    MainWindow* aFrame = new MainWindow(0L, _("My Awareness"));
    Controller::instance_ = new Controller(aFrame);
    aFrame->SetSize(700, 525);
    aFrame->Show();
    aFrame->setDatabaseEnvironment(false);
    Controller::instance()->start();
    return true;
}
