#ifndef REPORTWINDOW_H_
#define REPORTWINDOW_H_

#include <string>
#include <vector>
#include <wx/frame.h>

class wxHtmlWindow;
class wxHtmlCellEvent;
class ReportData;

class ReportWindow: public wxFrame {
public:
    ReportWindow(wxWindow* parent);
    virtual ~ReportWindow();

    void render(const ReportData& data);

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
    static int MAX_HISTOGRAM_BAR_LEN;
    static char HORIZONTAL_BAR_UNIT[];
    static char DARK_BACKGROUND[];
    static char BACKGROUND[];
    static char LIGHT_BACKGROUND[];

    wxHtmlWindow* htmlWindow_;
    int lastOrdering_;
    std::vector<Entry> data_;
    double referenceValue_;

    void buildPieReport(const ReportData& data);
    void renderPieReport();

    void buildHistogramReport(const ReportData& data);
    void renderHistogramReport();

    void setHtml(const std::string& html);

    void onSize(wxSizeEvent& event);
    void onCellClick(wxHtmlCellEvent& event);

DECLARE_EVENT_TABLE()
};

#endif /* REPORTWINDOW_H_ */
