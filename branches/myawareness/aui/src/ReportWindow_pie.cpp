#include <sstream>
#include <algorithm>
#include <Account.h>
#include <DatabaseConnection.h>
#include <ReportData.h>
#include <UiUtil.h>
#include <ReportWindow.h>

using namespace std;

void ReportWindow::buildPieReport(const ReportData& data)
{
    data_.clear();
    referenceValue_ = 0;

    const vector<double>& dataValues = data.getData();
    for (size_t accId = 0; accId < dataValues.size(); ++accId) {
        double accValue = dataValues[accId];
        if (accValue != 0) {
            const Account* acc = DatabaseConnection::instance()->getAccount(accId);
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

void ReportWindow::renderPieReport()
{
    ostringstream html;

    html << "<html><div align='center'><table bgcolor='" << LIGHT_BACKGROUND << "'>";

    html << "<tr><td colspan='4'>&nbsp;</td></tr>";
    html << "<tr><td colspan='4' bgcolor='" << DARK_BACKGROUND << "'>&nbsp</td></tr>";

    html << "<tr align='center' bgcolor='" << BACKGROUND << "'>";
    html << "<td><i><a href='order_by_name'>Account</a></i></td>";
    html << "<td><i><a href='order_by_value'>Bar</a></i></td>";
    html << "<td><i><a href='order_by_value'>%</a></i></td>";
    html << "<td><i><a href='order_by_value'>Value</a></i></td>";
    html << "</tr>";

    html << "<tr><td colspan='4'>&nbsp;</td></tr>";

    html << "<tr>";
    html << "<td colspan='3' align='right'><i><font size='+1'>Total&nbsp;&nbsp;</font></i></td>";
    html << "<td align='right'><b><font size='+1'>";
    UiUtil::streamCurrency(html, referenceValue_, true);
    html << "</font></b></td>";
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
        for (double v = 0.5; v < percent; ++v) {
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

    setHtml(html.rdbuf()->str());
}

