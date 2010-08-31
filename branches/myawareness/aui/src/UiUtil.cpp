#include <sstream>
#include <wx/string.h>
#include <wx/datetime.h>
#include <Date.h>
#include <UiUtil.h>

using namespace adb;
using namespace std;

const char *UiUtil::MONTH_NAMES[] = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

void UiUtil::appendWxString(string& to, const wxString& what)
{
    for (size_t strPos = 0; strPos < what.size(); ++strPos) {
        wxChar wch = what.GetChar(strPos);
        if (wch < 0x80) {
            to.append(1, static_cast<char> (wch));
        } else if (wch < 0x800) {
            to.append(1, static_cast<char> ((wch >> 6) | 192));
            to.append(1, static_cast<char> ((wch & 63) | 128));
        } else {
            to.append(1, static_cast<char> ((wch >> 12) | 224));
            to.append(1, static_cast<char> (((wch & 4095) >> 6) | 128));
            to.append(1, static_cast<char> ((wch & 63) | 128));
        }
    }
}

void UiUtil::adbDate2wxDate(wxDateTime* wxdate, const Date* date)
{
    wxdate->SetDay(date->getDay());
    wxdate->SetMonth(static_cast<wxDateTime::Month> (date->getMonth() - 1));
    wxdate->SetYear(date->getYear());
}

void UiUtil::appendStdString(wxString& to, const string& what)
{
    unsigned int byte;

    for (size_t i = 0; i < what.size(); ++i) {
        byte = static_cast<unsigned char> (what[i]);

        if (byte < 128) {
            to.Append(static_cast<wxChar> (byte));
        } else {
            unsigned int unic = 0;

            if (byte >= 240) {
                unic = byte & 7;
                unic <<= 6;
                byte = static_cast<unsigned char> (what[++i]) & 63;
                unic += byte;
                unic <<= 6;
                byte = static_cast<unsigned char> (what[++i]) & 63;
                unic += byte;
                unic <<= 6;
                byte = static_cast<unsigned char> (what[++i]) & 63;
                unic += byte;
            } else if (byte >= 224) {
                unic = byte & 15;
                unic <<= 6;
                byte = static_cast<unsigned char> (what[++i]) & 63;
                unic += byte;
                unic <<= 6;
                byte = static_cast<unsigned char> (what[++i]) & 63;
                unic += byte;
            } else if (byte >= 192) {
                unic = byte & 31;
                unic <<= 6;
                byte = static_cast<unsigned char> (what[++i]) & 63;
                unic += byte;
            }

            to.Append(static_cast<wxChar> (unic));
        }
    }
}

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

ostream& UiUtil::streamDate(ostream& out, const adb::Date& date)
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

void UiUtil::appendCurrency(wxString& to, double val)
{
    ostringstream sout;
    streamCurrency(sout, val);
    appendStdString(to, sout.rdbuf()->str());
}

