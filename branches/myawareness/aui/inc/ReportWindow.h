#ifndef REPORTWINDOW_H_
#define REPORTWINDOW_H_

#include <string>
#include <vector>
#include <wx/dialog.h>

class wxHtmlWindow;
class wxHtmlCellEvent;
namespace adb {
    class ReportData;
}

class ReportWindow: public wxDialog {
public:
    ReportWindow(wxWindow* parent);
    virtual ~ReportWindow();

    void render(const adb::ReportData& data);

private:
    struct Entry {
        std::string name;
        double value;

        static bool byNameAsc(const Entry& e1, const Entry& e2)
        {
            return (e1.name < e2.name);
        }

        static bool byValueAsc(const Entry& e1, const Entry& e2)
        {
            return (e1.value < e2.value);
        }

        static bool byNameDesc(const Entry& e1, const Entry& e2)
        {
            return !byNameAsc(e1, e2);
        }

        static bool byValueDesc(const Entry& e1, const Entry& e2)
        {
            return !byValueAsc(e1, e2);
        }
    };

    enum {
        ASC, DESC
    };

    static const long ID_HTML_WINDOW;

    wxHtmlWindow* htmlWindow_;
    int lastOrdering_;
    std::vector<Entry> data_;
    double referenceValue_;

    void buildPieReport(const adb::ReportData& data);
    void renderPieReport();

    void buildHistogramReport(const adb::ReportData& data);
    void renderHistogramReport();

    void onSize(wxSizeEvent& event);
    void onCellClick(wxHtmlCellEvent& event);

DECLARE_EVENT_TABLE()
};

#endif /* REPORTWINDOW_H_ */
