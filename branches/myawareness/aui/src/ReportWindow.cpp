#include <algorithm>
#include <ReportWindow.h>
#include <wx/sizer.h>
#include <wx/html/htmlwin.h>

using namespace std;

std::vector<ReportWindow*> ReportWindow::instances_;
//
BEGIN_EVENT_TABLE(ReportWindow, wxDialog)

EVT_CLOSE(ReportWindow::onClose)

END_EVENT_TABLE()

ReportWindow::ReportWindow(const wxString& title, const wxSize& size, const wxPoint& pos) :
    wxDialog(0, wxID_ANY, title, pos, size, wxCAPTION | wxTHICK_FRAME | wxRESIZE_BORDER | wxMINIMIZE_BOX | wxMAXIMIZE_BOX | wxCLOSE_BOX)
{
    wxBoxSizer* sizer;
    sizer = new wxBoxSizer(wxVERTICAL);

    htmlWindow_ = new wxHtmlWindow(this, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxHW_SCROLLBAR_AUTO);
    sizer->Add(htmlWindow_, 1, wxTOP, 3);

    SetSizer(sizer);
    Layout();
    sizer->Fit(this);

    instances_.push_back(this);
}

ReportWindow::~ReportWindow()
{
    // TODO Auto-generated destructor stub
}

void ReportWindow::onClose(wxCloseEvent& event)
{
    instances_.erase(remove(instances_.begin(), instances_.end(), this), instances_.end());
    Destroy();
}

void ReportWindow::destroyInstances()
{
    vector<ReportWindow*>::iterator it;
    for (it = instances_.begin(); it != instances_.end(); ++it) {
        (*it)->Destroy();
    }
}

