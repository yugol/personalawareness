#include <sstream>
#include <wx/sizer.h>
#include <wx/html/htmlwin.h>
#include <UiUtil.h>
#include <ReportData.h>
#include <ReportWindow.h>

using namespace std;
using namespace adb;
//
BEGIN_EVENT_TABLE(ReportWindow, wxDialog)

EVT_SIZE(ReportWindow::onSize)

END_EVENT_TABLE()

ReportWindow::ReportWindow(wxWindow* parent) :
    wxDialog(parent, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, wxCAPTION | wxTHICK_FRAME | wxRESIZE_BORDER | wxMINIMIZE_BOX | wxMAXIMIZE_BOX | wxCLOSE_BOX)
{
    wxBoxSizer* sizer;
    sizer = new wxBoxSizer(wxVERTICAL);

    htmlWindow_ = new wxHtmlWindow(this, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxHW_SCROLLBAR_AUTO);
    sizer->Add(htmlWindow_, 1);

    SetSizer(sizer);
    Layout();
    sizer->Fit(this);
}

ReportWindow::~ReportWindow()
{
}

void ReportWindow::onSize(wxSizeEvent& event)
{
    htmlWindow_->SetSize(GetClientSize());
}

void ReportWindow::render(const ReportData& data)
{
    ostringstream sout;

    sout << "<html>";
    sout << "Content";
    sout << "</html>";

    wxString wxhtml;
    UiUtil::string2wxString(sout.rdbuf()->str().c_str(), wxhtml);
    htmlWindow_->SetPage(wxhtml);

    wxString title;
    switch (data.getFlowDirection()) {
        case ReportData::EXPENSES:
            title.Append(_("Expenses"));
            break;
        case ReportData::INCOME:
            title.Append(_("Income"));
            break;
        default:
            title.Append(_("???"));
    }
    switch (data.getChartType()) {
        case ReportData::PIE:
            break;
        case ReportData::MONTHLY:
            title.Append(_(" monthly"));
            break;
        default:
            title.Append(_(" ???"));
    }
    SetTitle(title);
}

