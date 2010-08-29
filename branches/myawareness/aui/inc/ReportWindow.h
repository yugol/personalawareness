#ifndef REPORTWINDOW_H_
#define REPORTWINDOW_H_

#include <wx/dialog.h>

//class wxSizeEvent;
class wxHtmlWindow;
namespace adb {
    class ReportData;
}

class ReportWindow: public wxDialog {
public:
    ReportWindow(wxWindow* parent);
    virtual ~ReportWindow();

    void render(const adb::ReportData& data);

private:
    wxHtmlWindow* htmlWindow_;

    void onSize(wxSizeEvent& event);

DECLARE_EVENT_TABLE()
};

#endif /* REPORTWINDOW_H_ */
