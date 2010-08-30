#include <cstdio>
#include <iomanip>
#include <wx/string.h>
#include <wx/datetime.h>
#include <Date.h>
#include <UiUtil.h>

using namespace adb;
using namespace std;

const char *UiUtil::MONTH_NAMES[] = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

ostream& UiUtil::streamCurrency(ostream& out, double val)
{
    if (-0.01 < val && val < 0) {
        val = 0;
    }

    out.precision(2);
    out << fixed << val << " " << "RON";

    return out;
}

ostream& UiUtil::streamPercent(ostream& out, double val)
{
    out.precision(1);
    out << fixed << val << "%";
    return out;
}

std::ostream& UiUtil::streamDate(std::ostream& out, const adb::Date& date)
{
    out << date.getYear();
    out << '-';
    out.fill('0');
    out.width(2);
    out << date.getMonth();
    out << '-';
    out.fill('0');
    out.width(2);
    out << date.getDay();

    return out;
}

void UiUtil::formatCurrency(char* buf, double val)
{
    if (-0.01 < val && val < 0) {
        val = 0;
    }
    sprintf(buf, "%.2f %s", val, "RON");
}

void UiUtil::formatDate(char* buf, const Date& date)
{
    sprintf(buf, "%04d-%02d-%02d", date.getYear(), date.getMonth(), date.getDay());
}

void UiUtil::formatString(char* buf, const wxString& str)
{
    size_t bufPos = 0;
    for (size_t strPos = 0; strPos < str.size(); ++strPos) {
        wxChar wch = str.GetChar(strPos);
        if (wch < 0x80) {
            buf[bufPos++] = static_cast<char> (wch);
        } else if (wch < 0x800) {
            buf[bufPos++] = static_cast<char> ((wch >> 6) | 192);
            buf[bufPos++] = static_cast<char> ((wch & 63) | 128);
        } else {
            buf[bufPos++] = static_cast<char> ((wch >> 12) | 224);
            buf[bufPos++] = static_cast<char> (((wch & 4095) >> 6) | 128);
            buf[bufPos++] = static_cast<char> ((wch & 63) | 128);
        }
    }
    buf[bufPos] = '\0';
}

void UiUtil::convertDate2wxDate(wxDateTime* wxdate, const Date* date)
{
    wxdate->SetDay(date->getDay());
    wxdate->SetMonth(static_cast<wxDateTime::Month> (date->getMonth() - 1));
    wxdate->SetYear(date->getYear());
}

void UiUtil::cstring2wxString(const std::string& from, wxString& to)
{
    unsigned int byte;

    to.Clear();
    for (size_t i = 0; i < from.size(); ++i) {
        byte = static_cast<unsigned char> (from[i]);

        if (byte < 128) {
            to.Append(static_cast<wxChar> (byte));
        } else {
            unsigned int unic = 0;

            if (byte >= 240) {
                unic = byte & 7;
                unic <<= 6;
                byte = static_cast<unsigned char> (from[++i]) & 63;
                unic += byte;
                unic <<= 6;
                byte = static_cast<unsigned char> (from[++i]) & 63;
                unic += byte;
                unic <<= 6;
                byte = static_cast<unsigned char> (from[++i]) & 63;
                unic += byte;
            } else if (byte >= 224) {
                unic = byte & 15;
                unic <<= 6;
                byte = static_cast<unsigned char> (from[++i]) & 63;
                unic += byte;
                unic <<= 6;
                byte = static_cast<unsigned char> (from[++i]) & 63;
                unic += byte;
            } else if (byte >= 192) {
                unic = byte & 31;
                unic <<= 6;
                byte = static_cast<unsigned char> (from[++i]) & 63;
                unic += byte;
            }

            to.Append(static_cast<wxChar> (unic));
        }
    }
}

