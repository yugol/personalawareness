#include <cstdio>
#include <wx/wx.h>
#include <Controller.h>

using namespace adb;

void Controller::formatCurrency(char* buf, double val)
{
    if (-0.01 < val && val < 0) {
        val = 0;
    }
    sprintf(buf, "%.2f %s", val, "RON");
}

void Controller::formatDate(char* buf, const Date& date)
{
    sprintf(buf, "%04d-%02d-%02d", date.getYear(), date.getMonth(), date.getDay());
}

void Controller::formatString(char* buf, const wxString& str)
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

void Controller::convertDate2wxDate(wxDateTime* wxdate, const Date* date)
{
    wxdate->SetDay(date->getDay());
    wxdate->SetMonth(static_cast<wxDateTime::Month> (date->getMonth() - 1));
    wxdate->SetYear(date->getYear());
}
