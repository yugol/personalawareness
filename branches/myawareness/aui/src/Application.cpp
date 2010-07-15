#ifdef WX_PRECOMP
#include "wx_pch.h"
#endif

#ifdef __BORLANDC__
#pragma hdrstop
#endif //__BORLANDC__

#include <Application.h>
#include <MainWindow.h>

IMPLEMENT_APP(Application);

bool Application::OnInit()
{
    MainWindow* aFrame = new MainWindow(0L, _("Personal Awareness"));
    aCtrl_.setMainWindow(aFrame);
    aCtrl_.start();
    aFrame->SetSize(800, 600);
    aFrame->Show();
    aFrame->setDatabaseEnvironment(false);
    return true;
}
