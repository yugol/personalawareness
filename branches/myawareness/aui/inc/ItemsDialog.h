#ifndef ITEMSDIALOG_H_
#define ITEMSDIALOG_H_

#include <wx/dialog.h>

class wxStaticText;
class wxTextCtrl;
class wxListCtrl;
class wxButton;
class wxListEvent;

class ItemsDialog: public wxDialog {
public:
    ItemsDialog(wxWindow* parent, wxWindowID id = wxID_ANY, const wxString& title = wxT("Edit items"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxSize(400, 520), long style =
            wxDEFAULT_DIALOG_STYLE);
    virtual ~ItemsDialog();

private:
    wxStaticText* patternLabel_;
    wxTextCtrl* patternText_;
    wxListCtrl* itemList_;
    wxButton* renameButton_;
    wxButton* deleteButton_;
    wxButton* closeButton_;
    long selectedListItemId_;

    void selectItem(long selectedId);
    void updateItemList(int itemId);

    void onInitDialog(wxInitDialogEvent& event);
    void onPatternText(wxCommandEvent& event);
    void onItemSelected(wxListEvent& event);
    void onRename(wxCommandEvent& event);
    void onDelete(wxCommandEvent& event);
    void onClose(wxCommandEvent& event);

};

#endif /* ITEMSDIALOG_H_ */
