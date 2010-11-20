#include <cmath>
#include <sstream>
#include <ReportData.h>
#include <UiUtil.h>
#include <ReportWindow.h>

using namespace std;

void ReportWindow::buildHistogramReport(const ReportData& data)
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
            if (::fabs(entry.value) > referenceValue_) {
                referenceValue_ = ::fabs(entry.value);
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
        for (double v = 0.5; v < len; ++v) {
            html << HORIZONTAL_BAR_UNIT;
        }
        html << "</td>";

        html << "</tr>";
    }

    html << "<tr><td colspan='4'>&nbsp;</td></tr>";
    html << "<tr><td colspan='4' bgcolor='" << DARK_BACKGROUND << "'>&nbsp</td></tr>";
    html << "<tr><td colspan='4'>&nbsp;</td></tr>";
    html << "</table></div><div align='center'><a href='close'>Close</a></div></html>";

    setHtml(html.rdbuf()->str());
}
