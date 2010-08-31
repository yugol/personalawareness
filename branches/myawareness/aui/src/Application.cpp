#include <MainWindow.h>
#include <Controller.h>
#include <Application.h>

// TBD+: hystogram reports
// TBD+: delete transaction buton
// TBD+: ensure database extension is .db when saving
// TBD+: ensure export extension is .sql when saving + provide default name
// TBD: properties
// TBD: accoutns items edit dialogs
// TBD: compact transaction list view
// TBD: undo/redo
// TBD-: internationalization
// TBD: About dialog
// TBD: select transaction clears transaction editor errors

IMPLEMENT_APP(Application)

bool Application::OnInit()
{
    MainWindow* aFrame = new MainWindow(0L, _("My Awareness"));
    Controller::instance_ = new Controller(aFrame);
    aFrame->SetSize(800, 600);
    aFrame->Show();
    aFrame->setDatabaseEnvironment(false);
    Controller::instance()->start();
    return true;
}
