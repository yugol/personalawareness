#ifndef AUTOCOMPLETIONWINDOW_H_
#define AUTOCOMPLETIONWINDOW_H_

#include <wx/frame.h>

class wxListBox;

class AutocompletionWindow: public wxFrame {
public:
    AutocompletionWindow(wxWindow* parent, wxTextCtrl* handler);
    virtual ~AutocompletionWindow();

    void show();
    void hide();
    void clear();
    void append(const wxString& name, int id);
    void select(const wxString& hint, int direction);

private:
    wxTextCtrl* handler_;
    wxListBox* optionList_;

    void onSelectOption(wxCommandEvent& event);
    void onKillFocus(wxFocusEvent& event);
    void onKeyDown(wxKeyEvent& event);
};

#endif /* AUTOCOMPLETIONWINDOW_H_ */
