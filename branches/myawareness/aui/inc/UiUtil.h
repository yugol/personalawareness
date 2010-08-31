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
    static const char *MONTH_NAMES[];

    static void adbDate2wxDate(wxDateTime* to, const adb::Date* from);

    static std::ostream& streamCurrency(std::ostream& out, double val);
    static std::ostream& streamPercent(std::ostream& out, double val);
    static std::ostream& streamDate(std::ostream& out, const adb::Date& date);

    static void appendStdString(wxString& to, const std::string& what);
    static void appendWxString(std::string& to, const wxString& what);
    static void appendCurrency(wxString& to, double val);
};

#endif /* UIUTIL_H_ */
