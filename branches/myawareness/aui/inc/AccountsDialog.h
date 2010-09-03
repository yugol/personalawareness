#ifndef ACCOUNTSDIALOG_H_
#define ACCOUNTSDIALOG_H_

#include <wx/dialog.h>

class wxStaticText;
class wxListCtrl;
class wxComboBox;
class wxChoice;
class wxButton;
class wxTextCtrl;
class wxListEvent;
namespace adb {
    class Account;
}

class AccountsDialog: public wxDialog {
public:
    AccountsDialog(wxWindow* parent, wxWindowID id = wxID_ANY, const wxString& title = wxT("Edit accounts"), const wxPoint& pos = wxDefaultPosition, const wxSize& size = wxSize(540, 405), long style =
            wxDEFAULT_DIALOG_STYLE);
    virtual ~AccountsDialog();

private:
    bool dirty_;
    long selectedListItemId_;
    const adb::Account* selectedAccount_;
    bool processEditEvents_;

    wxStaticText* listLabel_;
    wxListCtrl* accountList_;
    wxStaticText* nameLabel_;
    wxTextCtrl* nameText_;
    wxStaticText* typeLabel_;
    wxChoice* typeChoice_;
    wxStaticText* groupLabel_;
    wxComboBox* groupCombo_;
    wxStaticText* valueLabel_;
    wxTextCtrl* valueText_;
    wxStaticText* descriptionLabel_;
    wxTextCtrl* descriptionText_;
    wxButton* insertButton_;
    wxButton* updateButton_;
    wxButton* deleteButton_;
    wxButton* newButton_;
    wxButton* closeButton_;

    void refreshAccountList(int selectedAccountId = 0);
    void selectAccount(long selectedListItemId = -1);
    bool readValidateRefresh(adb::Account* account = 0);

    void onCloseDialog(wxCloseEvent& event);
    void onInitDialog(wxInitDialogEvent& event);
    void onSelectAccount(wxListEvent& event);
    void onNameText(wxCommandEvent& event);
    void onTypeChange(wxCommandEvent& event);
    void onGroupText(wxCommandEvent& event);
    void onValueText(wxCommandEvent& event);
    void onDescriptionText(wxCommandEvent& event);
    void onInsert(wxCommandEvent& event);
    void onUpdate(wxCommandEvent& event);
    void onDelete(wxCommandEvent& event);
    void onNew(wxCommandEvent& event);
    void onClose(wxCommandEvent& event);
};

#endif /* ACCOUNTSDIALOG_H_ */
