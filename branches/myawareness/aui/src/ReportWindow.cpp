#include <cmath>
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

static int MAX_HISTOGRAM_BAR_LEN = 80;
static char HORIZONTAL_BAR_UNIT[] = ":";
static char DARK_BACKGROUND[] = "PaleTurquoise";
static char BACKGROUND[] = "AliceBlue";
static char LIGHT_BACKGROUND[] = "White";

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
    referenceValue_ = 0;

    const vector<double>& dataValues = data.getData();
    for (size_t accId = 0; accId < dataValues.size(); ++accId) {
        double accValue = dataValues[accId];
        if (accValue != 0) {
            Account* acc = DatabaseConnection::instance()->getAccount(accId);
            Entry entry;
            entry.name = acc->getFullName();
            entry.value = accValue;
            referenceValue_ += accValue;
            data_.push_back(entry);
        }
    }

    sort(data_.begin(), data_.end(), Entry::byNameAsc);
    lastOrdering_ = ASC;
}

void ReportWindow::buildHistogramReport(const adb::ReportData& data)
{
    data_.clear();
    referenceValue_ = 0;

    int year = data.getParameters().getLastDate().getYear();
    int month = data.getParameters().getLastDate().getMonth();
    int prevYear = 0;

    const vector<double>& dataValues = data.getData();
    for (size_t monId = dataValues.size(); monId > 0; --monId) {
        Entry entry;
        entry.value = dataValues[monId - 1];

        if (entry.value != 0) {
            if (::abs(entry.value) > referenceValue_) {
                referenceValue_ = ::abs(entry.value);
            }
            if (prevYear != year) {
                prevYear = year;
                ostringstream sout;
                sout << year << "&nbsp;&nbsp;&nbsp;";
                entry.name = sout.rdbuf()->str();
            }
            entry.name.append(UiUtil::MONTH_NAMES[month - 1]);

            data_.push_back(entry);
        }

        --month;
        if (month < 1) {
            month = 12;
            --year;
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

void ReportWindow::renderPieReport()
{
    ostringstream html;

    html << "<html><div align='center'><table bgcolor='" << LIGHT_BACKGROUND << "'>";

    html << "<tr><td colspan='4'>&nbsp;</td></tr>";
    html << "<tr><td colspan='4' bgcolor='" << DARK_BACKGROUND << "'>&nbsp</td></tr>";

    html << "<tr align='center' bgcolor='" << DARK_BACKGROUND << "'>";
    html << "<td><i><a href='order_by_name'>Account</a></i></td>";
    html << "<td><i><a href='order_by_value'>Bar</a></i></td>";
    html << "<td><i><a href='order_by_value'>%</a></i></td>";
    html << "<td><i><a href='order_by_value'>Value</a></i></td>";
    html << "</tr>";

    html << "<tr><td colspan='4'>&nbsp;</td></tr>";

    html << "<tr>";
    html << "<td colspan='3' align='right'><i>Total&nbsp;&nbsp;</i></td>";
    html << "<td align='right'><b>";
    UiUtil::streamCurrency(html, referenceValue_, true);
    html << "</b></td>";
    html << "</tr>";

    html << "<tr><td colspan='4'>&nbsp;</td></tr>";

    for (size_t i = 0; i < data_.size(); ++i) {
        double percent = 100 * data_[i].value / referenceValue_;

        if (0 == i % 2) {
            html << "<tr bgcolor='" << BACKGROUND << "'>";
        } else {
            html << "<tr>";
        }

        html << "<td align='left'>";
        html << data_[i].name;
        html << "</td>";

        html << "<td align='right' bgcolor='" << LIGHT_BACKGROUND << "'>";
        for (double p = 0; p < percent; ++p) {
            html << HORIZONTAL_BAR_UNIT;
        }
        html << "</td>";

        html << "<td align='right' bgcolor='" << LIGHT_BACKGROUND << "'><b>";
        UiUtil::streamPercent(html, percent);
        html << "</b></td>";

        html << "<td align='right'>";
        UiUtil::streamCurrency(html, data_[i].value, html);
        html << "</td>";

        html << "</tr>";
    }

    html << "<tr><td colspan='4'>&nbsp;</td></tr>";
    html << "<tr><td colspan='4' bgcolor='" << DARK_BACKGROUND << "'>&nbsp</td></tr>";
    html << "<tr><td colspan='4'>&nbsp;</td></tr>";
    html << "</table></div><div align='center'><a href='close'>Close</a></div></html>";

    wxString wxhtml;
    UiUtil::appendStdString(wxhtml, html.rdbuf()->str());
    htmlWindow_->SetPage(wxhtml);
}

void ReportWindow::renderHistogramReport()
{
    ostringstream html;

    html << "<html><div align='center'><table bgcolor='" << LIGHT_BACKGROUND << "'>";

    html << "<tr><td colspan='3'>&nbsp;</td></tr>";
    html << "<tr><td colspan='3' bgcolor='" << DARK_BACKGROUND << "'>&nbsp</td></tr>";
    html << "<tr><td colspan='3'>&nbsp;</td></tr>";

    for (size_t i = 0; i < data_.size(); ++i) {
        const Entry& entry = data_[i];

        if (entry.name.size() > 4) {
            html << "<tr bgcolor='" << DARK_BACKGROUND << "'>";
        } else {
            html << "<tr bgcolor='" << BACKGROUND << "'>";
        }

        html << "<td align='right'><i>" << "" << entry.name << "</i></td>";

        html << "<td align='right' bgcolor='" << BACKGROUND << "'>";
        UiUtil::streamCurrency(html, entry.value, true);
        html << "</td>";

        html << "<td align='left' bgcolor='" << LIGHT_BACKGROUND << "'>";
        double len = MAX_HISTOGRAM_BAR_LEN * entry.value / referenceValue_;
        for (double p = 0; p < len; ++p) {
            html << HORIZONTAL_BAR_UNIT;
        }
        html << "</td>";

        html << "</tr>";
    }

    html << "<tr><td colspan='4'>&nbsp;</td></tr>";
    html << "<tr><td colspan='4' bgcolor='" << DARK_BACKGROUND << "'>&nbsp</td></tr>";
    html << "<tr><td colspan='4'>&nbsp;</td></tr>";
    html << "</table></div><div align='center'><a href='close'>Close</a></div></html>";

    wxString wxhtml;
    UiUtil::appendStdString(wxhtml, html.rdbuf()->str());
    htmlWindow_->SetPage(wxhtml);
}
