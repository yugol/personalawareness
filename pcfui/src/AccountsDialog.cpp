#include <algorithm>
#include <vector>
#include <wx/msgdlg.h>
#include <Exception.h>
#include <Account.h>
#include <UiUtil.h>
#include <Controller.h>
#include <AccountsDialog.h>

using namespace std;

static const wxString typeTip(wxT("Type cannot be changed when a transaction uses the account"));
static const wxString insertTip(wxT("Account name is already used"));
static const wxString updateTip(wxT("Account is unchanged"));
static const wxString deleteAccountInUseTip(wxT("Account is used in a transaction"));
static const wxString noAccountTip(wxT("No account was selected"));
static const wxString invalidNameTip(wxT("Account name cannot be empty"));
static const wxString invalidValueTip(wxT("Start balance must be a real number or empty"));

AccountsDialog::AccountsDialog(wxWindow* parent) :
    AccountsDialogBase(parent), processEvents_(false)
{
    typeChoice_->Insert(wxT("Cash"), 0, reinterpret_cast<void*> (Account::ACCOUNT));
    typeChoice_->Insert(wxT("Income"), 1, reinterpret_cast<void*> (Account::INCOME));
    typeChoice_->Insert(wxT("Expenses"), 2, reinterpret_cast<void*> (Account::EXPENSES));

    accountList_->InsertColumn(0, wxEmptyString, wxLIST_FORMAT_LEFT, accountList_->GetSize().GetWidth() - UiUtil::LIST_MARGIN);
}

AccountsDialog::~AccountsDialog()
{
}

void AccountsDialog::onCloseDialog(wxCloseEvent& event)
{
    if (dirty_) {
        Controller::instance()->refreshTransactions();
    }
    event.Skip();
}

void AccountsDialog::onInitDialog(wxInitDialogEvent& event)
{
    dirty_ = false;
    refreshAccountList();
}

void AccountsDialog::onSelectAccount(wxListEvent& event)
{
    if (processEvents_) {
        selectAccount(event.GetIndex());
    }
}

void AccountsDialog::onNameText(wxCommandEvent& event)
{
    if (processEvents_) {
        readValidateRefresh();
    }
}

void AccountsDialog::onTypeChange(wxCommandEvent& event)
{
    if (processEvents_) {
        int type = reinterpret_cast<int> (typeChoice_->GetClientData(typeChoice_->GetSelection()));
        if (type != Account::ACCOUNT) {
            groupCombo_->SetValue(wxEmptyString);
            valueText_->SetValue(wxEmptyString);
        }
        readValidateRefresh();
    }
}

void AccountsDialog::onGroupText(wxCommandEvent& event)
{
    if (processEvents_) {
        readValidateRefresh();
    }
}

void AccountsDialog::onValueText(wxCommandEvent& event)
{
    if (processEvents_) {
        readValidateRefresh();
    }
}

void AccountsDialog::onCommentText(wxCommandEvent& event)
{
    if (processEvents_) {
        readValidateRefresh();
    }
}

void AccountsDialog::onInsert(wxCommandEvent& event)
{
    try {
        Account account;
        if (!readValidateRefresh(&account)) {
            throw Exception("Invalid account data");
        }
        Controller::instance()->insertUpdateAccount(&account);
        dirty_ = true;
        refreshAccountList(account.getId());
    } catch (const exception& ex) {
        Controller::instance()->reportException(ex, wxT("inserting account"));
    }
}

void AccountsDialog::onUpdate(wxCommandEvent& event)
{
    try {
        if (selectedAccount_ == 0) {
            throw Exception("No account is selected");
        }
        Account account;
        if (!readValidateRefresh(&account)) {
            throw Exception("Invalid account data");
        }
        account.setId(selectedAccount_->getId());
        Controller::instance()->insertUpdateAccount(&account);
        dirty_ = true;
        refreshAccountList(account.getId());
    } catch (const exception& ex) {
        Controller::instance()->reportException(ex, wxT("updating account"));
    }
}

void AccountsDialog::onDelete(wxCommandEvent& event)
{
    try {
        if (selectedAccount_ == 0) {
            throw Exception("No account is selected");
        }

        wxString msg(wxT("Are you sure you want to delete the account\n'"));
        UiUtil::appendStdString(msg, selectedAccount_->getDecoratedName());
        msg.Append(wxT("'?"));

        wxMessageDialog* dlg = new wxMessageDialog(this, msg, wxT("Delete account"), wxOK | wxCANCEL);
        if (wxID_OK == dlg->ShowModal()) {
            Controller::instance()->deleteAccount(selectedAccount_->getId());
            dirty_ = true;
            refreshAccountList();
        }
        dlg->Destroy();
    } catch (const exception& ex) {
        Controller::instance()->reportException(ex, wxT("deleting account"));
    }
}

void AccountsDialog::onClear(wxCommandEvent& event)
{
    selectAccount();
}

void AccountsDialog::onClose(wxCommandEvent& event)
{
    Close();
    Destroy();
}

void AccountsDialog::refreshAccountList(int selectedAccountId)
{
    groupCombo_->Clear();
    accountList_->DeleteAllItems();
    long selectedListItemId = -1;

    wxListItem listItem;
    listItem.SetColumn(0);
    listItem.SetAlign(wxLIST_FORMAT_LEFT);

    vector<wxString> groupNames;
    vector<int> accIds;
    Controller::instance()->selectAllAccounts(accIds);
    vector<int>::iterator it;
    for (it = accIds.begin(); it != accIds.end(); ++it) {
        int accId = *it;
        const Account* acc = Controller::instance()->selectAccount(accId);
        wxString accName;
        UiUtil::appendStdString(accName, acc->getDecoratedName());

        listItem.SetId(accountList_->GetItemCount());
        listItem.SetText(accName);
        listItem.SetData(accId);
        accountList_->InsertItem(listItem);

        if (accId == selectedAccountId) {
            selectedListItemId = listItem.GetId();
        }

        if (acc->getGroup().size() > 0) {
            wxString groupName;
            UiUtil::appendStdString(groupName, acc->getGroup());
            if (find(groupNames.begin(), groupNames.end(), groupName) == groupNames.end()) {
                groupNames.push_back(groupName);
            }
        }
    }

    if (groupNames.size() > 0) {
        vector<wxString>::iterator it;
        for (it = groupNames.begin(); it != groupNames.end(); ++it) {
            groupCombo_->Append(*it);
        }
    }

    selectAccount(selectedListItemId);
}

void AccountsDialog::selectAccount(long listItemId)
{
    processEvents_ = false;

    nameText_->SetValue(wxEmptyString);

    typeChoice_->Select(0);
    typeChoice_->SetToolTip(0);
    typeChoice_->Enable(true);

    groupCombo_->SetValue(wxEmptyString);

    valueText_->SetValue(wxEmptyString);

    commentText_->SetValue(wxEmptyString);

    deleteButton_->Enable(false);
    deleteButton_->SetToolTip(0);

    if (listItemId >= 0) {
        selectedListItemId_ = listItemId;
        selectedAccount_ = Controller::instance()->selectAccount(accountList_->GetItemData(selectedListItemId_));
        bool accInUse = Controller::instance()->selectAccountInUse(selectedAccount_->getId());

        accountList_->SetItemState(listItemId, wxLIST_STATE_SELECTED, wxLIST_STATE_SELECTED);
        accountList_->EnsureVisible(selectedListItemId_);

        wxString accName;
        UiUtil::appendStdString(accName, selectedAccount_->getName());
        nameText_->SetValue(accName);

        int accType = selectedAccount_->getType();
        for (unsigned int choice = 0; choice < typeChoice_->GetCount(); ++choice) {
            int type = reinterpret_cast<int> (typeChoice_->GetClientData(choice));
            if (type == accType) {
                typeChoice_->SetSelection(choice);
                if (accInUse) {
                    typeChoice_->Enable(false);
                    typeChoice_->SetToolTip(typeTip);
                }
                break;
            }
        }
        typeLabel_->Enable(true);

        if (accType == Account::ACCOUNT) {
            wxString groupName;
            UiUtil::appendStdString(groupName, selectedAccount_->getGroup());
            groupCombo_->SetValue(groupName);

            wxString accValue;
            accValue.Printf(wxT("%0.2f"), selectedAccount_->getStartBalance());
            valueText_->SetValue(accValue);
        }

        wxString accDesc;
        UiUtil::appendStdString(accDesc, selectedAccount_->getComment());
        commentText_->SetValue(accDesc);

        deleteButton_->Enable(!accInUse);
        if (accInUse) {
            deleteButton_->SetToolTip(deleteAccountInUseTip);
        }

    } else {
        selectedListItemId_ = -1;
        selectedAccount_ = 0;

        listItemId = -1;
        while (true) {
            listItemId = accountList_->GetNextItem(listItemId);
            if (listItemId < 0) {
                break;
            }
            accountList_->SetItemState(listItemId, wxLIST_STATE_DONTCARE, wxLIST_STATE_SELECTED);
        }
        accountList_->EnsureVisible(selectedListItemId_);

        deleteButton_->SetToolTip(noAccountTip);
    }

    readValidateRefresh();

    processEvents_ = true;
}

bool AccountsDialog::readValidateRefresh(Account* account)
{
    insertButton_->SetToolTip(0);
    updateButton_->SetToolTip(0);
    bool dirty = false;

    // account name

    string name;
    UiUtil::appendWxString(name, UiUtil::makeProperName(nameText_->GetValue()));
    if (name.size() <= 0) {
        updateButton_->Enable(false);
        updateButton_->SetToolTip(invalidNameTip);

        insertButton_->Enable(false);
        insertButton_->SetToolTip(invalidNameTip);

        return false;
    }
    if (account != 0) {
        account->setName(name.c_str());
    }
    if (selectedAccount_ != 0) {
        if (name != selectedAccount_->getName()) {
            dirty = true;
        }
    }
    const Account* tmpAcc = Controller::instance()->selectAccount(name.c_str());
    if (tmpAcc == 0) {
        insertButton_->Enable(true);
        insertButton_->SetToolTip(0);
    } else {
        insertButton_->Enable(false);
        insertButton_->SetToolTip(insertTip);
    }

    // account type

    int type = reinterpret_cast<int> (typeChoice_->GetClientData(typeChoice_->GetSelection()));
    if (type == Account::ACCOUNT) {
        groupLabel_->Enable(true);
        groupCombo_->Enable(true);

        valueLabel_->Enable(true);
        valueText_->Enable(true);
    } else {
        groupLabel_->Enable(false);
        groupCombo_->Enable(false);

        valueLabel_->Enable(false);
        valueText_->Enable(false);
    }
    if (account != 0) {
        account->setType(static_cast<Account::Type> (type));
    }
    if (selectedAccount_ != 0) {
        if (type != selectedAccount_->getType()) {
            dirty = true;
        }
    }

    // account group

    string group;
    UiUtil::appendWxString(group, groupCombo_->GetValue());
    if (account != 0) {
        account->setGroup(group.c_str());
    }
    if (selectedAccount_ != 0) {
        if (group != selectedAccount_->getGroup()) {
            dirty = true;
        }
    }

    // account start balance

    double value = 0;
    if ((valueText_->GetValue().Len() > 0) && (!valueText_->GetValue().ToDouble(&value))) {
        updateButton_->Enable(false);
        updateButton_->SetToolTip(invalidValueTip);

        insertButton_->Enable(false);
        insertButton_->SetToolTip(invalidValueTip);

        return false;
    }
    if (account != 0) {
        account->setStartBalance(value);
    }
    if (selectedAccount_ != 0) {
        if (value != selectedAccount_->getStartBalance()) {
            dirty = true;
        }
    }

    // account comment

    string comment;
    UiUtil::appendWxString(comment, commentText_->GetValue());
    if (account != 0) {
        account->setComment(comment.c_str());
    }
    if (selectedAccount_ != 0) {
        if (comment != selectedAccount_->getComment()) {
            dirty = true;
        }
    }

    if (dirty) {
        updateButton_->Enable(true);
        updateButton_->SetToolTip(0);
    } else {
        updateButton_->Enable(false);
        if (selectedAccount_ != 0) {
            updateButton_->SetToolTip(updateTip);
        } else {
            updateButton_->SetToolTip(noAccountTip);
        }
    }
    return true;
}

