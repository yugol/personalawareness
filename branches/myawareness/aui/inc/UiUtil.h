#ifndef UIUTIL_H_
#define UIUTIL_H_

#include <wx/string.h>
#include <ostream>

class wxDateTime;
namespace adb {
    class Date;
    class Item;
}

class UiUtil {
public:
    static const char* MONTH_NAMES[];
    static const int LIST_MARGIN = 20;

    static wxString getApplicationName(const std::string& databaseFile);
    static wxString getUsingStatusMessage(const std::string& databaseFile);
    static wxString makeProperName(wxString rawName);

    static void adbDate2wxDate(wxDateTime* to, const adb::Date* from);

    static std::ostream& streamCurrency(std::ostream& out, double val, bool html = false);
    static std::ostream& streamPercent(std::ostream& out, double val);
    static std::ostream& streamDate(std::ostream& out, const adb::Date& date);
    static std::ostream& streamFile(std::ostream& out, const std::string& pathFileExt);
    static std::ostream& streamExt(std::ostream& out, const std::string& pathFileExt);
    static std::ostream& streamFileExt(std::ostream& out, const std::string& pathFileExt);

    static void appendStdString(wxString& to, const std::string& what);
    static void appendWxString(std::string& to, const wxString& what);
    static void appendCurrency(wxString& to, double val);

    static int compareBeginning(const wxString& a, const wxString& b);
    static bool compareByName(const adb::Item* a, const adb::Item* b);

private:
    static const char APPLICATION_NAME[];

};

#endif /* UIUTIL_H_ */
