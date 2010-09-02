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
#include <Account.h>
#include <UiUtil.h>
#include <Controller.h>
#include <AccountsDialog.h>

using namespace std;
using namespace adb;

AccountsDialog::AccountsDialog(wxWindow* parent, wxWindowID id, const wxString& title, const wxPoint& pos, const wxSize& size, long style) :
    wxDialog(parent, id, title, pos, size, style)
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

    groupCombo_ = new wxComboBox(this, wxID_ANY, wxT(""), wxDefaultPosition, wxDefaultSize, 0, NULL, 0);
    middleSizer->Add(groupCombo_, 0, wxALL | wxEXPAND, 5);

    valueLabel_ = new wxStaticText(this, wxID_ANY, wxT("Start balance:"), wxDefaultPosition, wxDefaultSize, 0);
    valueLabel_->Wrap(-1);
    middleSizer->Add(valueLabel_, 0, wxALL, 5);

    valueText_ = new wxTextCtrl(this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0);
    middleSizer->Add(valueText_, 0, wxALL | wxEXPAND, 5);

    descriptionLabel_ = new wxStaticText(this, wxID_ANY, wxT("Description:"), wxDefaultPosition, wxDefaultSize, 0);
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
    typeChoice_->Connect(wxEVT_COMMAND_CHOICE_SELECTED, wxCommandEventHandler(AccountsDialog::onTypeChange), NULL, this);
    insertButton_->Connect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(AccountsDialog::onInsert), NULL, this);
    updateButton_->Connect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(AccountsDialog::onUpdate), NULL, this);
    deleteButton_->Connect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(AccountsDialog::onDelete), NULL, this);
    closeButton_->Connect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(AccountsDialog::onClose), NULL, this);
}

AccountsDialog::~AccountsDialog()
{
    // Disconnect Events
    this->Disconnect(wxEVT_CLOSE_WINDOW, wxCloseEventHandler(AccountsDialog::onCloseDialog));
    this->Disconnect(wxEVT_INIT_DIALOG, wxInitDialogEventHandler(AccountsDialog::onInitDialog));
    accountList_->Disconnect(wxEVT_COMMAND_LIST_ITEM_SELECTED, wxListEventHandler(AccountsDialog::onSelectAccount), NULL, this);
    typeChoice_->Disconnect(wxEVT_COMMAND_CHOICE_SELECTED, wxCommandEventHandler(AccountsDialog::onTypeChange), NULL, this);
    insertButton_->Disconnect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(AccountsDialog::onInsert), NULL, this);
    updateButton_->Disconnect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(AccountsDialog::onUpdate), NULL, this);
    deleteButton_->Disconnect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(AccountsDialog::onDelete), NULL, this);
    closeButton_->Disconnect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(AccountsDialog::onClose), NULL, this);
}

void AccountsDialog::onCloseDialog(wxCloseEvent& event)
{
    // TBD: refresh main window only when closing edit dialog
    event.Skip();
}

void AccountsDialog::onInitDialog(wxInitDialogEvent& event)
{
    dirty_ = false;

    typeChoice_->Insert(wxT("Money"), 0, reinterpret_cast<void*> (Account::ACCOUNT));
    typeChoice_->Insert(wxT("Income"), 1, reinterpret_cast<void*> (Account::CREDIT));
    typeChoice_->Insert(wxT("Expenses"), 2, reinterpret_cast<void*> (Account::DEBT));

    accountList_->InsertColumn(0, wxT(""), wxLIST_FORMAT_LEFT, accountList_->GetSize().GetWidth() - UiUtil::LIST_MARGIN);
    refreshAccountList(0);
}

void AccountsDialog::onSelectAccount(wxListEvent& event)
{
    // if (processEvents_) {
    selectAccount(event.GetIndex());
    //}
}

void AccountsDialog::onTypeChange(wxCommandEvent& event)
{

}

void AccountsDialog::onInsert(wxCommandEvent& event)
{

}

void AccountsDialog::onUpdate(wxCommandEvent& event)
{

}

void AccountsDialog::onDelete(wxCommandEvent& event)
{

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

        if (accId == selectedListItemId) {
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
    nameLabel_->Enable(false);
    nameText_->SetValue(wxT(""));
    nameText_->Enable(false);

    typeLabel_->Enable(false);
    typeChoice_->Select(0);
    typeChoice_->SetToolTip(wxT(""));
    typeChoice_->Enable(false);

    groupLabel_->Enable(false);
    groupCombo_->SetValue(wxT(""));
    groupCombo_->Enable(false);

    valueLabel_->Enable(false);
    valueText_->SetValue(wxT(""));
    valueText_->Enable(false);

    descriptionLabel_->Enable(false);
    descriptionText_->SetValue(wxT(""));
    descriptionText_->Enable(false);

    insertButton_->Enable(false);
    insertButton_->SetToolTip(wxT(""));

    updateButton_->Enable(false);
    updateButton_->SetToolTip(wxT(""));

    deleteButton_->Enable(false);
    deleteButton_->SetToolTip(wxT(""));

    if (listItemId >= 0) {
        selectedListItemId_ = listItemId;

        accountList_->SetItemState(listItemId, wxLIST_STATE_SELECTED, wxLIST_STATE_SELECTED);
        accountList_->EnsureVisible(selectedListItemId_);

        const Account* acc = Controller::instance()->selectAccount(accountList_->GetItemData(selectedListItemId_));
        bool accInUse = Controller::instance()->selectAccountInUse(acc->getId());

        wxString accName;
        UiUtil::appendStdString(accName, acc->getName());
        nameText_->SetValue(accName);
        nameText_->Enable(true);
        nameLabel_->Enable(true);

        int accType = acc->getType();
        for (unsigned int choice = 0; choice < typeChoice_->GetCount(); ++choice) {
            int type = reinterpret_cast<int> (typeChoice_->GetClientData(choice));
            if (type == accType) {
                typeChoice_->SetSelection(choice);
                typeChoice_->Enable(!accInUse);
                if (accInUse) {
                    typeChoice_->SetToolTip(wxT("Cannot change type when a transaction uses the account"));
                }
                break;
            }
        }
        typeLabel_->Enable(true);

        if (accType == Account::ACCOUNT) {
            wxString groupName;
            UiUtil::appendStdString(groupName, acc->getGroup());
            groupCombo_->SetValue(groupName);
            groupCombo_->Enable(true);
            groupLabel_->Enable(true);

            wxString accValue;
            accValue.Printf(wxT("%0.2f"), acc->getInitialValue());
            valueText_->SetValue(accValue);
            valueText_->Enable(true);
            valueLabel_->Enable(true);
        }

        wxString accDesc;
        UiUtil::appendStdString(accDesc, acc->getDescription());
        descriptionText_->SetValue(accDesc);
        descriptionText_->Enable(true);
        descriptionLabel_->Enable(true);

        insertButton_->SetToolTip(wxT("No two accounts can have the same name"));

        updateButton_->SetToolTip(wxT("No changes were made to the account"));

        deleteButton_->Enable(!accInUse);
        if (accInUse) {
            deleteButton_->SetToolTip(wxT("Cannot delete the account when it is used in a transaction"));
        }

    } else {
        selectedListItemId_ = -1;

        listItemId = -1;
        while (true) {
            listItemId = accountList_->GetNextItem(listItemId);
            if (listItemId < 0) {
                break;
            }
            accountList_->SetItemState(listItemId, wxLIST_STATE_DONTCARE, wxLIST_STATE_SELECTED);
        }
        accountList_->EnsureVisible(selectedListItemId_);
    }
}

