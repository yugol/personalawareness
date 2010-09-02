#include <vector>
#include <wx/sizer.h>
#include <wx/stattext.h>
#include <wx/textctrl.h>
#include <wx/listctrl.h>
#include <wx/button.h>
#include <wx/textdlg.h>
#include <wx/msgdlg.h>
#include <Item.h>
#include <UiUtil.h>
#include <Controller.h>
#include <ItemsDialog.h>

using namespace std;
using namespace adb;

ItemsDialog::ItemsDialog(wxWindow* parent, wxWindowID id, const wxString& title, const wxPoint& pos, const wxSize& size, long style) :
    wxDialog(parent, id, title, pos, size, style)
{
    this->SetSizeHints(wxDefaultSize, wxDefaultSize);

    wxFlexGridSizer* mainSizer;
    mainSizer = new wxFlexGridSizer(2, 2, 0, 0);
    mainSizer->AddGrowableCol(0);
    mainSizer->AddGrowableRow(1);
    mainSizer->SetFlexibleDirection(wxBOTH);
    mainSizer->SetNonFlexibleGrowMode(wxFLEX_GROWMODE_SPECIFIED);

    wxBoxSizer* patternSizer;
    patternSizer = new wxBoxSizer(wxHORIZONTAL);

    patternLabel_ = new wxStaticText(this, wxID_ANY, wxT("Search item:"), wxDefaultPosition, wxDefaultSize, 0);
    patternLabel_->Wrap(-1);
    patternSizer->Add(patternLabel_, 0, wxALIGN_CENTER_VERTICAL | wxALL, 5);

    patternText_ = new wxTextCtrl(this, wxID_ANY, wxEmptyString, wxDefaultPosition, wxDefaultSize, 0);
    patternSizer->Add(patternText_, 1, wxALIGN_CENTER_VERTICAL | wxALL | wxEXPAND, 5);

    mainSizer->Add(patternSizer, 1, wxEXPAND, 5);

    wxBoxSizer* emptySizer;
    emptySizer = new wxBoxSizer(wxVERTICAL);

    mainSizer->Add(emptySizer, 1, wxEXPAND, 5);

    itemList_ = new wxListCtrl(this, wxID_ANY, wxDefaultPosition, wxDefaultSize, wxLC_HRULES | wxLC_NO_HEADER | wxLC_REPORT | wxLC_SINGLE_SEL);
    mainSizer->Add(itemList_, 1, wxALL | wxEXPAND, 5);

    wxBoxSizer* buttonSizer;
    buttonSizer = new wxBoxSizer(wxVERTICAL);

    renameButton_ = new wxButton(this, wxID_ANY, wxT("&Rename"), wxDefaultPosition, wxDefaultSize, 0);
    buttonSizer->Add(renameButton_, 0, wxALL, 5);

    deleteButton_ = new wxButton(this, wxID_ANY, wxT("&Delete"), wxDefaultPosition, wxDefaultSize, 0);
    buttonSizer->Add(deleteButton_, 0, wxALL, 5);

    buttonSizer->Add(0, 0, 1, wxEXPAND, 5);

    closeButton_ = new wxButton(this, wxID_ANY, wxT("&Close"), wxDefaultPosition, wxDefaultSize, 0);
    buttonSizer->Add(closeButton_, 0, wxALL, 5);

    mainSizer->Add(buttonSizer, 1, wxEXPAND, 5);

    this->SetSizer(mainSizer);
    this->Layout();

    // Connect Events
    this->Connect(wxEVT_CLOSE_WINDOW, wxCloseEventHandler(ItemsDialog::onCloseDialog));
    this->Connect(wxEVT_INIT_DIALOG, wxInitDialogEventHandler(ItemsDialog::onInitDialog));
    patternText_->Connect(wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler(ItemsDialog::onPatternText), NULL, this);
    itemList_->Connect(wxEVT_COMMAND_LIST_ITEM_SELECTED, wxListEventHandler(ItemsDialog::onItemSelected), NULL, this);
    renameButton_->Connect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(ItemsDialog::onRename), NULL, this);
    deleteButton_->Connect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(ItemsDialog::onDelete), NULL, this);
    closeButton_->Connect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(ItemsDialog::onClose), NULL, this);
}

ItemsDialog::~ItemsDialog()
{
    // Disconnect Events
    this->Disconnect(wxEVT_CLOSE_WINDOW, wxCloseEventHandler(ItemsDialog::onCloseDialog));
    this->Disconnect(wxEVT_INIT_DIALOG, wxInitDialogEventHandler(ItemsDialog::onInitDialog));
    patternText_->Disconnect(wxEVT_COMMAND_TEXT_UPDATED, wxCommandEventHandler(ItemsDialog::onPatternText), NULL, this);
    itemList_->Disconnect(wxEVT_COMMAND_LIST_ITEM_SELECTED, wxListEventHandler(ItemsDialog::onItemSelected), NULL, this);
    renameButton_->Disconnect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(ItemsDialog::onRename), NULL, this);
    deleteButton_->Disconnect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(ItemsDialog::onDelete), NULL, this);
    closeButton_->Disconnect(wxEVT_COMMAND_BUTTON_CLICKED, wxCommandEventHandler(ItemsDialog::onClose), NULL, this);
}

void ItemsDialog::onCloseDialog(wxCloseEvent& event)
{
    // TBD: refresh main window only when closing edit dialogs
    event.Skip();
}

void ItemsDialog::onInitDialog(wxInitDialogEvent& event)
{
    selectedListItemId_ = -1;
    patternText_->SetFocus();
    itemList_->InsertColumn(0, wxT(""), wxLIST_FORMAT_LEFT, itemList_->GetSize().GetWidth() - UiUtil::LIST_MARGIN);
    refreshItemList(0);
}

void ItemsDialog::onPatternText(wxCommandEvent& event)
{
    long selectedListItemId = -1;

    if (event.GetString().Len() > 0) {
        long listItemId = -1;
        while (true) {

            listItemId = itemList_->GetNextItem(listItemId);
            if (listItemId < 0) {
                break;
            }

            int match = UiUtil::compareBeginning(event.GetString(), itemList_ ->GetItemText(listItemId));

            if (match > 0) {
                selectedListItemId = listItemId;
            } else if (match == 0) {
                selectedListItemId = listItemId;
                break;
            } else {
                break;
            }
        }
    }

    selectItem(selectedListItemId);
}

void ItemsDialog::onItemSelected(wxListEvent& event)
{
    selectedListItemId_ = event.GetIndex();
    renameButton_->Enable(true);
    deleteButton_->Enable(true);
}

void ItemsDialog::onRename(wxCommandEvent& event)
{
    wxString prevName = itemList_->GetItemText(selectedListItemId_);
    wxTextEntryDialog* dlg = new wxTextEntryDialog(this, wxT("New name:"), wxT("Rename item"), prevName);
    if (wxID_OK == dlg->ShowModal()) {
        wxString newName = dlg->GetValue();
        if (newName != prevName) {
            int itemId = itemList_->GetItemData(selectedListItemId_);
            string itemName;
            UiUtil::appendWxString(itemName, newName);
            Item item;
            item.setId(itemId);
            item.setName(itemName.c_str());
            Controller::instance()->insertUpdateItem(&item);
            refreshItemList(itemId);
        }
    }
    dlg->Destroy();
}

void ItemsDialog::onDelete(wxCommandEvent& event)
{
    wxString msg(wxT("Are you sure you want to delete item\n'"));
    msg.Append(itemList_->GetItemText(selectedListItemId_));
    msg.Append(wxT("'?"));
    wxMessageDialog* dlg = new wxMessageDialog(this, msg, wxT("Delete item"), wxOK | wxCANCEL);
    if (wxID_OK == dlg->ShowModal()) {
        int itemId = itemList_->GetItemData(selectedListItemId_);
        try {
            Controller::instance()->deleteItem(itemId);
            refreshItemList(0);
        } catch (const exception& ex) {
            Controller::instance()->reportException(ex, wxT("deleting item"));
        }
    }
    dlg->Destroy();
}

void ItemsDialog::onClose(wxCommandEvent& event)
{
    Close();
}

void ItemsDialog::refreshItemList(int selectedItemId)
{
    itemList_->DeleteAllItems();
    long selectedListItemId = -1;

    wxListItem listItem;
    listItem.SetColumn(0);
    listItem.SetAlign(wxLIST_FORMAT_LEFT);

    vector<const Item*> items;
    Controller::instance()->selectAllItems(items);
    vector<const Item*>::const_iterator it;
    for (it = items.begin(); it != items.end(); ++it) {
        const Item* item = *it;
        int itemId = item->getId();
        wxString itemName;
        UiUtil::appendStdString(itemName, item->getName());

        listItem.SetId(itemList_->GetItemCount());
        listItem.SetText(itemName);
        listItem.SetData(itemId);
        itemList_->InsertItem(listItem);

        if (itemId == selectedItemId) {
            selectedListItemId = listItem.GetId();
        }
    }

    selectItem(selectedListItemId);
}

void ItemsDialog::selectItem(long listItemId)
{
    wxRect rect;

    if (listItemId >= 0) {

        itemList_->SetItemState(listItemId, wxLIST_STATE_SELECTED, wxLIST_STATE_SELECTED);

        itemList_->GetItemRect(listItemId, rect);
        itemList_->ScrollList(rect.x, rect.y);

        selectedListItemId_ = listItemId;

    } else {

        listItemId = -1;
        while (true) {
            listItemId = itemList_->GetNextItem(listItemId);
            if (listItemId < 0) {
                break;
            }
            itemList_->SetItemState(listItemId, wxLIST_STATE_DONTCARE, wxLIST_STATE_SELECTED);
        }

        renameButton_->Enable(false);
        deleteButton_->Enable(false);

        itemList_->GetItemRect(0, rect);
        itemList_->ScrollList(rect.x, rect.y);

        selectedListItemId_ = -1;
    }
}
