#include <algorithm>
#include <vector>
#include <wx/stattext.h>
#include <wx/sizer.h>
#include <wx/listctrl.h>
#include <wx/textctrl.h>
#include <wx/choice.h>
#include <wx/combobox.h>
#include <wx/button.h>
#include <wx/msgdlg.h>
#include <Exception.h>
#include <Account.h>
#include <UiUtil.h>
#include <Controller.h>
#include <AccountsDialog.h>

using namespace std;
using namespace adb;

static const wxString typeTip(wxT("Type cannot be changed when a transaction uses the account"));
static const wxString insertTip(wxT("Account name is already used"));
static const wxString updateTip(wxT("Account is unchanged"));
static const wxString deleteAccountInUseTip(wxT("Account is used in a transaction"));
static const wxString noAccountTip(wxT("No account was selected"));
static const wxString invalidNameTip(wxT("Account name cannot be empty"));
static const wxString invalidValueTip(wxT("Start balance must be a real number or empty"));

AccountsDialog::AccountsDialog(wxWindow* parent, wxWindowID id, const wxString& title, const wxPoint& pos, const wxSize& size, long style) :
    wxDialog(parent, id, title, pos, size, style), processEditEvents_(false)
{
    this->SetSizeHints(wxDefaultSize, wxDefaultSize);

    wxFlexGridSizer* dialogSizer;
    dialogSizer = new wxFlexGridSizer(2, 3, 0, 0);
    dialogSizer->AddGrowableCol(0);
    dialogSizer->AddGrowableRow(1);
    dialogSizer->SetFlexibleDirection(wxBOTH);
    dialogSizer->SetNonFlexibleGrowMode(wxFLEX_GROWMODE_SPECIFIED);

    listLabel_ = new wxStaticText(this, wxID_ANY, wxT("Accounts:"), wxDefaultPosition, wxDefaultSize, 0);
    listLabel_->Wrap(-1);
    dialogSizer->Add(listLabel_, 0, wxALIGN_CENTER_VERTICAL | wxALL, 5);

    wxBoxSizer* dummyMiddleSizer;
    dummyMiddleSizer = new wxBoxSizer(wxVERTICAL);

    dialogSizer->Add(dummyMiddleSizer, 1, wxEXPAND, 5);

    wxBoxSizer* dummyRightSizer;
    dummyRightSizer = new wxBoxSizer(wxVERTICAL);

    dialogSizer->Add(dummyRightSizer, 1, wxEXPAND, 5);

    accountList_ = new wxListCtrl(this, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxLC_HRULES | wxLC_NO_HEADER | wxLC_REPORT | wxLC_SINGLE_SEL);
    dialogSizer->Add(accountList_, 0, wxALL | wxEXPAND, 5);

    wxBoxSizer* middleSizer;
    middleSizer = new wxBoxSizer(wxVERTICAL);

    nameLabel_ = new wxStaticText(this, wxID_ANY, wxT("Account name:"), wxDefaultPosition, wxDefaultSize, 0);
    nameLabel_->Wrap(-1);
    middleSizer->Add(nameLabel_, 0, wxALL, 5);

    nameText_ = new wxTextCtrl(this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0);
    middleSizer->Add(nameText_, 0, wxALL | wxEXPAND, 5);

    typeLabel_ = new wxStaticText(this, wxID_ANY, wxT("Type:"), wxDefaultPosition, wxDefaultSize, 0);
    typeLabel_->Wrap(-1);
    middleSizer->Add(typeLabel_, 0, wxALL, 5);

    wxArrayString typeChoice_Choices;
    typeChoice_ = new wxChoice(this, wxID_ANY, wxDefaultPosition, wxDefaultSize, typeChoice_Choices, 0);
    typeChoice_->SetSelection(0);
    middleSizer->Add(typeChoice_, 0, wxALL | wxEXPAND, 5);

    groupLabel_ = new wxStaticText(this, wxID_ANY, wxT("Group:"), wxDefaultPosition, wxDefaultSize, 0);
    groupLabel_->Wrap(-1);
    middleSizer->Add(groupLabel_, 0, wxALL, 5);

    groupCombo_ = new wxComboBox(this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0, NULL, 0);
    middleSizer->Add(groupCombo_, 0, wxALL | wxEXPAND, 5);

    valueLabel_ = new wxStaticText(this, wxID_ANY, wxT("Start balance:"), wxDefaultPosition, wxDefaultSize, 0);
    valueLabel_->Wrap(-1);
    middleSizer->Add(valueLabel_, 0, wxALL, 5);

    valueText_ = new wxTextCtrl(this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0);
    middleSizer->Add(valueText_, 0, wxALL | wxEXPAND, 5);

    descriptionLabel_ = new wxStaticText(this, wxID_ANY, wxT("Comment:"), wxDefaultPosition, wxDefaultSize, 0);
    descriptionLabel_->Wrap(-1);
    middleSizer->Add(descriptionLabel_, 0, wxALL, 5);

    descriptionText_ = new wxTextCtrl(this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, wxTE_MULTILINE | wxTE_WORDWRAP);
    middleSizer->Add(descriptionText_, 0, wxALL | wxEXPAND, 5);

    dialogSizer->Add(middleSizer, 1, wxEXPAND, 5);

    wxBoxSizer* rightSizer;
    rightSizer = new wxBoxSizer(wxVERTICAL);

    insertButton_ = new wxButton(this, wxID_ANY, wxT("&Insert"), wxDefaultPosition, wxDefaultSize, 0);
    rightSizer->Add(insertButton_, 0, wxALL, 5);

    updateButton_ = new wxButton(this, wxID_ANY, wxT("&Update"), wxDefaultPosition, wxDefaultSize, 0);
    rightSizer->Add(updateButton_, 0, wxALL, 5);

    deleteButton_ = new wxButton(this, wxID_ANY, wxT("&Delete"), wxDefaultPosition, wxDefaultSize, 0);
    rightSizer->Add(deleteButton_, 0, wxALL, 5);

    wxStaticText* dummyLabel = new wxStaticText(this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0);
    rightSizer->Add(dummyLabel, 0, wxALL, 5);

    newButton_ = new wxButton(this, wxID_ANY, wxT("C&lear"), wxDefaultPosition, wxDefaultSize, 0);
    rightSizer->Add(newButton_, 0, wxALL, 5);

    rightSizer->Add(0, 0, 1, wxEXPAND, 5);

    closeButton_ = new wxButton(this, wxID_ANY, wxT("&Close"), wxDefaultPosition, wxDefaultSize, 0);
    rightSizer->Add(closeButton_, 0, wxALL, 5);

    dialogSizer->Add(rightSizer, 1, wxEXPAND, 5);

    this->SetSizer(dialogSizer);
    this->Layout();

    // Connect Events
    this->Connect(wxEVT_CLOSE_WINDOW, wxCloseEventHandler(AccountsDialog::onCloseDialog));
    this->Connect(wxEVT_INIT_DIALOG, wxInitDialogEventHandler(AccountsDialog::onInitDialog));
    accountList_->Connect(wxEVT_COMMAND_LIST_ITEM_SELECTED, wxListEventHandler(AccountsDialog::onSelectAccount), NULL, this);
    nameText_->Connect(wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler(AccountsDialog::onNameText), NULL, this);
    typeChoice_->Connect(wxEVT_COMMAND_CHOICE_SELECTED, wxCommandEventHandler(AccountsDialog::onTypeChange), NULL, this);
    groupCombo_->Connect(wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler(AccountsDialog::onGroupText), NULL, this);
    valueText_->Connect(wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler(AccountsDialog::onValueText), NULL, this);
    descriptionText_->Connect(wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler(AccountsDialog::onDescriptionText), NULL, this);
    insertButton_->Connect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(AccountsDialog::onInsert), NULL, this);
    updateButton_->Connect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(AccountsDialog::onUpdate), NULL, this);
    deleteButton_->Connect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(AccountsDialog::onDelete), NULL, this);
    newButton_->Connect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(AccountsDialog::onNew), NULL, this);
    closeButton_->Connect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(AccountsDialog::onClose), NULL, this);
}

AccountsDialog::~AccountsDialog()
{
    // Disconnect Events
    this->Disconnect(wxEVT_CLOSE_WINDOW, wxCloseEventHandler(AccountsDialog::onCloseDialog));
    this->Disconnect(wxEVT_INIT_DIALOG, wxInitDialogEventHandler(AccountsDialog::onInitDialog));
    accountList_->Disconnect(wxEVT_COMMAND_LIST_ITEM_SELECTED, wxListEventHandler(AccountsDialog::onSelectAccount), NULL, this);
    nameText_->Disconnect(wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler(AccountsDialog::onNameText), NULL, this);
    typeChoice_->Disconnect(wxEVT_COMMAND_CHOICE_SELECTED, wxCommandEventHandler(AccountsDialog::onTypeChange), NULL, this);
    groupCombo_->Disconnect(wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler(AccountsDialog::onGroupText), NULL, this);
    valueText_->Disconnect(wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler(AccountsDialog::onValueText), NULL, this);
    descriptionText_->Disconnect(wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler(AccountsDialog::onDescriptionText), NULL, this);
    insertButton_->Disconnect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(AccountsDialog::onInsert), NULL, this);
    updateButton_->Disconnect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(AccountsDialog::onUpdate), NULL, this);
    deleteButton_->Disconnect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(AccountsDialog::onDelete), NULL, this);
    newButton_->Disconnect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(AccountsDialog::onNew), NULL, this);
    closeButton_->Disconnect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(AccountsDialog::onClose), NULL, this);
}

void AccountsDialog::onCloseDialog(wxCloseEvent& event)
{
    if (dirty_) {
        Controller::instance()->refreshTransactions();
        Controller::instance()->refreshUndoRedoStatus();
    }
    event.Skip();
}

void AccountsDialog::onInitDialog(wxInitDialogEvent& event)
{
    dirty_ = false;

    typeChoice_->Insert(wxT("Cash"), 0, reinterpret_cast<void*> (Account::ACCOUNT));
    typeChoice_->Insert(wxT("Income"), 1, reinterpret_cast<void*> (Account::CREDIT));
    typeChoice_->Insert(wxT("Expenses"), 2, reinterpret_cast<void*> (Account::DEBT));

    accountList_->InsertColumn(0, wxEmptyString, wxLIST_FORMAT_LEFT, accountList_->GetSize().GetWidth() - UiUtil::LIST_MARGIN);
    refreshAccountList();
}

void AccountsDialog::onSelectAccount(wxListEvent& event)
{
    selectAccount(event.GetIndex());
}

void AccountsDialog::onNameText(wxCommandEvent& event)
{
    if (processEditEvents_) {
        readValidateRefresh();
    }
}

void AccountsDialog::onTypeChange(wxCommandEvent& event)
{
    if (processEditEvents_) {
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
    if (processEditEvents_) {
        readValidateRefresh();
    }
}

void AccountsDialog::onValueText(wxCommandEvent& event)
{
    if (processEditEvents_) {
        readValidateRefresh();
    }
}

void AccountsDialog::onDescriptionText(wxCommandEvent& event)
{
    if (processEditEvents_) {
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
        Controller::instance()->deleteAccount(selectedAccount_->getId());
        dirty_ = true;
        refreshAccountList();
    } catch (const exception& ex) {
        Controller::instance()->reportException(ex, wxT("deleting account"));
    }
}

void AccountsDialog::onNew(wxCommandEvent& event)
{
    selectAccount();
}

void AccountsDialog::onClose(wxCommandEvent& event)
{
    Close();
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
    processEditEvents_ = false;

    nameText_->SetValue(wxEmptyString);

    typeChoice_->Select(0);
    typeChoice_->SetToolTip(0);
    typeChoice_->Enable(true);

    groupCombo_->SetValue(wxEmptyString);

    valueText_->SetValue(wxEmptyString);

    descriptionText_->SetValue(wxEmptyString);

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
            accValue.Printf(wxT("%0.2f"), selectedAccount_->getInitialValue());
            valueText_->SetValue(accValue);
        }

        wxString accDesc;
        UiUtil::appendStdString(accDesc, selectedAccount_->getDescription());
        descriptionText_->SetValue(accDesc);

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

    processEditEvents_ = true;
}

bool AccountsDialog::readValidateRefresh(Account* account)
{
    insertButton_->SetToolTip(0);
    updateButton_->SetToolTip(0);
    bool dirty = false;

    // account name

    string name;
    UiUtil::appendWxString(name, nameText_->GetValue());
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
        account->setInitialValue(value);
    }
    if (selectedAccount_ != 0) {
        if (value != selectedAccount_->getInitialValue()) {
            dirty = true;
        }
    }

    // account description

    string description;
    UiUtil::appendWxString(description, descriptionText_->GetValue());
    if (account != 0) {
        account->setDescription(description.c_str());
    }
    if (selectedAccount_ != 0) {
        if (description != selectedAccount_->getDescription()) {
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

