#ifndef AUTOCOMPLEWINDOW_H_
#define AUTOCOMPLEWINDOW_H_

#include <AutocompleteWindowBase.h>

class wxTextCtrl;
class wxListBox;

class AutocompleteWindow: public AutocompleteWindowBase {
public:
    AutocompleteWindow(wxWindow* parent, wxTextCtrl* handler);
    virtual ~AutocompleteWindow();

    void show();
    void hide();
    void clear();
    void append(const wxString& name, int id);
    void select(const wxString& hint, int direction);

private:
    wxTextCtrl* handler_;

    void onKillFocus(wxFocusEvent& event);
    void onKeyDown(wxKeyEvent& event);
};

#endif /* AUTOCOMPLETEWINDOW_H_ */
