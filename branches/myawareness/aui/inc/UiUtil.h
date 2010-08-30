#ifndef UIUTIL_H_
#define UIUTIL_H_

#include <ostream>

class wxString;
class wxDateTime;
namespace adb {
    class Date;
}

class UiUtil {
public:
    static const int CURRENCY_BUFFER_LENGTH = 50;
    static const int DATE_BUFFER_LENGTH = 20;
    static const int NAME_BUFFER_LENGTH = 1000;
    static const char *MONTH_NAMES[];

    static std::ostream& streamCurrency(std::ostream& out, double val);
    static std::ostream& streamPercent(std::ostream& out, double val);
    static std::ostream& streamDate(std::ostream& out, const adb::Date& date);

    static void formatCurrency(char* buf, double val);
    static void formatDate(char* buf, const adb::Date& date);
    static void formatString(char* buf, const wxString& str);
    static void convertDate2wxDate(wxDateTime* wxdate, const adb::Date* date);
    static void cstring2wxString(const std::string& from, wxString& to);
};

#endif /* UIUTIL_H_ */
