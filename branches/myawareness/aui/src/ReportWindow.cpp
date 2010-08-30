#include <algorithm>
#include <sstream>
#include <wx/sizer.h>
#include <wx/html/htmlwin.h>
#include <Account.h>
#include <ReportData.h>
#include <DatabaseConnection.h>
#include <UiUtil.h>
#include <ReportWindow.h>

#include <wx/msgdlg.h>

using namespace std;
using namespace adb;

const long ReportWindow::ID_HTML_WINDOW = wxNewId();
//
BEGIN_EVENT_TABLE(ReportWindow, wxDialog)

EVT_SIZE(ReportWindow::onSize)

EVT_HTML_CELL_CLICKED(ReportWindow::ID_HTML_WINDOW, ReportWindow::onCellClick)

END_EVENT_TABLE()

ReportWindow::ReportWindow(wxWindow* parent) :
    wxDialog(parent, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, wxCAPTION | wxTHICK_FRAME | wxRESIZE_BORDER | wxMINIMIZE_BOX | wxMAXIMIZE_BOX | wxCLOSE_BOX)
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
        if (cmd == _T("close")) {
            Destroy();
        } else if (cmd == _T("order_by_value")) {
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
        } else if (cmd == _T("order_by_name")) {
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

void ReportWindow::buildPieReport(const ReportData& data)
{
    data_.clear();
    totalValue_ = 0;

    const vector<double>& dataValues = data.getData();
    for (size_t accId = 0; accId < dataValues.size(); ++accId) {
        double accValue = dataValues[accId];
        if (accValue != 0) {
            Account* acc = DatabaseConnection::instance()->getAccount(accId);
            Entry entry;
            entry.name = acc->getFullName();
            entry.value = accValue;
            totalValue_ += accValue;
            data_.push_back(entry);
        }
    }

    sort(data_.begin(), data_.end(), Entry::byNameAsc);
    lastOrdering_ = ASC;
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
    UiUtil::cstring2wxString(title.rdbuf()->str(), wxtitle);
    SetTitle(wxtitle);
}

void ReportWindow::renderPieReport()
{
    ostringstream html;

    html << "<html><div align='center'><table>";
    html << "<tr><td colspan='4'>&nbsp;</td></tr>";
    html << "<tr><td colspan='4' bgcolor='PaleTurquoise'>&nbsp</td></tr>";

    html << "<tr align='center' bgcolor='PaleTurquoise'>";
    html << "<td><i><a href='order_by_name'>Account</a></i></td>";
    html << "<td><i><a href='order_by_value'>Bar</a></i></td>";
    html << "<td><i><a href='order_by_value'>%</a></i></td>";
    html << "<td><i><a href='order_by_value'>Value</a></i></td>";
    html << "</tr>";

    html << "<tr><td colspan='4'>&nbsp;</td></tr>";

    html << "<tr>";
    html << "<td colspan='3' align='right'><i>Total&nbsp;&nbsp;</i></td>";
    html << "<td align='right'><b>";
    UiUtil::streamCurrency(html, totalValue_);
    html << "</b></td>";
    html << "</tr>";

    html << "<tr><td colspan='4'>&nbsp;</td></tr>";

    for (size_t i = 0; i < data_.size(); ++i) {
        double percent = 100 * data_[i].value / totalValue_;

        if (0 == i % 2) {
            html << "<tr bgcolor='AliceBlue'>";
        } else {
            html << "<tr bgcolor='White'>";
        }

        html << "<td align='left'>";
        html << data_[i].name;
        html << "</td>";

        html << "<td align='right' bgcolor='White'>";
        for (double p = 0; p < percent; ++p) {
            html << ":";
        }
        html << "</td>";

        html << "<td align='right' bgcolor='White'><b>";
        UiUtil::streamPercent(html, percent);
        html << "</b></td>";

        html << "<td align='right'>";
        UiUtil::streamCurrency(html, data_[i].value);
        html << "</td>";

        html << "</tr>";
    }

    html << "<tr><td colspan='4'>&nbsp;</td></tr>";
    html << "<tr><td colspan='4' bgcolor='PaleTurquoise'>&nbsp</td></tr>";
    html << "<tr><td colspan='4'>&nbsp;</td></tr>";
    html << "</table></div><div align='center'><a href='close'>Close</a></div></html>";

    wxString wxhtml;
    UiUtil::cstring2wxString(html.rdbuf()->str(), wxhtml);
    htmlWindow_->SetPage(wxhtml);
}
