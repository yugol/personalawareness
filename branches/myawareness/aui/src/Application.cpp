#include <MainWindow.h>
#include <Controller.h>
#include <Application.h>

// TBD+: hystogram reports
// TBD+: delete transaction buton
// TBD: properties
// TBD: accoutns items edit dialogs
// TBD: compact transaction list view


IMPLEMENT_APP(Application)

bool Application::OnInit()
{
    MainWindow* aFrame = new MainWindow(0L, _("Personal Awareness"));
    Controller::instance_ = new Controller(aFrame);
    aFrame->SetSize(800, 600);
    aFrame->Show();
    aFrame->setDatabaseEnvironment(false);
    Controller::instance()->start();
    return true;
}
