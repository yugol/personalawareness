#ifndef REPORTWINDOW_H_
#define REPORTWINDOW_H_

#include <vector>
#include <wx/dialog.h>

class wxHtmlWindow;

class ReportWindow: public wxDialog {
public:
    static void destroyInstances();

    ReportWindow(const wxString& title = wxEmptyString, const wxSize& size = wxDefaultSize, const wxPoint& pos = wxDefaultPosition);
    virtual ~ReportWindow();

private:
    static std::vector<ReportWindow*> instances_;

    wxHtmlWindow* htmlWindow_;

    void onClose(wxCloseEvent& event);

DECLARE_EVENT_TABLE()
};

#endif /* REPORTWINDOW_H_ */
