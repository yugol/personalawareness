#ifndef ACCOUNTSDIALOG_H_
#define ACCOUNTSDIALOG_H_

#include <AccountsDialogBase.h>

namespace adb {
    class Account;
}

class AccountsDialog: public AccountsDialogBase {
public:
    AccountsDialog(wxWindow* parent);
    virtual ~AccountsDialog();

protected:
    void onCloseDialog(wxCloseEvent& event);
    void onInitDialog(wxInitDialogEvent& event);
    void onSelectAccount(wxListEvent& event);
    void onNameText(wxCommandEvent& event);
    void onTypeChange(wxCommandEvent& event);
    void onGroupText(wxCommandEvent& event);
    void onValueText(wxCommandEvent& event);
    void onCommentText(wxCommandEvent& event);
    void onInsert(wxCommandEvent& event);
    void onUpdate(wxCommandEvent& event);
    void onDelete(wxCommandEvent& event);
    void onClear(wxCommandEvent& event);
    void onClose(wxCommandEvent& event);

private:
    bool processEvents_;
    bool dirty_;
    long selectedListItemId_;
    const adb::Account* selectedAccount_;

    void refreshAccountList(int selectedAccountId = 0);
    void selectAccount(long selectedListItemId = -1);
    bool readValidateRefresh(adb::Account* account = 0);
};

#endif /* ACCOUNTSDIALOG_H_ */
