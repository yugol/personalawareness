#include <algorithm>
#include <sstream>
#include <wx/sizer.h>
#include <wx/html/htmlwin.h>
#include <ReportData.h>
#include <UiUtil.h>
#include <ReportWindow.h>

using namespace std;

int ReportWindow::MAX_HISTOGRAM_BAR_LEN = 80;
char ReportWindow::HORIZONTAL_BAR_UNIT[] = ":";
char ReportWindow::DARK_BACKGROUND[] = "PaleTurquoise";
char ReportWindow::BACKGROUND[] = "AliceBlue";
char ReportWindow::LIGHT_BACKGROUND[] = "White";
const long ReportWindow::ID_HTML_WINDOW = wxNewId();
//
BEGIN_EVENT_TABLE(ReportWindow, wxFrame)

EVT_SIZE(ReportWindow::onSize)

EVT_HTML_CELL_CLICKED(ReportWindow::ID_HTML_WINDOW, ReportWindow::onCellClick)

END_EVENT_TABLE()

ReportWindow::ReportWindow(wxWindow* parent) :
    wxFrame(parent, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, wxDEFAULT_FRAME_STYLE)
{
    wxBoxSizer* sizer;
    sizer = new wxBoxSizer(wxVERTICAL);

    htmlWindow_ = new wxHtmlWindow(this, ID_HTML_WINDOW, wxDefaultPosition, wxDefaultSize, wxHW_SCROLLBAR_AUTO);
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

void ReportWindow::onCellClick(wxHtmlCellEvent& event)
{
    wxHtmlLinkInfo* link = event.GetCell()->GetLink();
    if (0 != link) {
        wxString cmd = link->GetHref();
        if (cmd == wxT("close")) {
            Destroy();
        } else if (cmd == wxT("order_by_value")) {
            switch (lastOrdering_) {
                case ASC:
                    sort(data_.begin(), data_.end(), Entry::byValueDesc);
                    lastOrdering_ = DESC;
                    break;
                case DESC:
                    sort(data_.begin(), data_.end(), Entry::byValueAsc);
                    lastOrdering_ = ASC;
                    break;
            }
            renderPieReport();
        } else if (cmd == wxT("order_by_name")) {
            switch (lastOrdering_) {
                case ASC:
                    sort(data_.begin(), data_.end(), Entry::byNameDesc);
                    lastOrdering_ = DESC;
                    break;
                case DESC:
                    sort(data_.begin(), data_.end(), Entry::byNameAsc);
                    lastOrdering_ = ASC;
                    break;
            }
            renderPieReport();
        }
    }
}

void ReportWindow::render(const ReportData& data)
{
    ostringstream title;

    switch (data.getFlowDirection()) {
        case ReportData::EXPENSES:
            title << "Expenses";
            break;
        case ReportData::INCOME:
            title << "Income";
            break;
        default:
            title << "???";
    }

    switch (data.getChartType()) {
        case ReportData::PIE:
            buildPieReport(data);
            renderPieReport();
            break;
        case ReportData::MONTHLY:
            buildHistogramReport(data);
            renderHistogramReport();
            title << " monthly ";
            break;
        default:
            title << " ??? ";
    }

    title << " (";
    title << UiUtil::MONTH_NAMES[data.getParameters().getFirstDate().getMonth() - 1];
    title << " ";
    title << data.getParameters().getFirstDate().getYear();
    title << " - ";
    title << UiUtil::MONTH_NAMES[data.getParameters().getLastDate().getMonth() - 1];
    title << " ";
    title << data.getParameters().getLastDate().getYear();
    title << ")";

    wxString wxtitle;
    UiUtil::appendStdString(wxtitle, title.rdbuf()->str());
    SetTitle(wxtitle);
}

void ReportWindow::setHtml(const std::string& html)
{
    wxString wxhtml;
    UiUtil::appendStdString(wxhtml, html);
    htmlWindow_->SetPage(wxhtml);

}

