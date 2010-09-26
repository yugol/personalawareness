#include <vector>
#include <wx/textdlg.h>
#include <wx/msgdlg.h>
#include <Item.h>
#include <UiUtil.h>
#include <Controller.h>
#include <ItemsDialog.h>

using namespace std;

ItemsDialog::ItemsDialog(wxWindow* parent) :
    ItemsDialogBase(parent), processEvents_(false)
{
    itemList_->InsertColumn(0, wxEmptyString, wxLIST_FORMAT_LEFT, itemList_->GetSize().GetWidth() - UiUtil::LIST_MARGIN);
}

ItemsDialog::~ItemsDialog()
{
}

void ItemsDialog::onCloseDialog(wxCloseEvent& event)
{
    if (dirty_) {
        Controller::instance()->refreshTransactions();
    }
    event.Skip();
}

void ItemsDialog::onInitDialog(wxInitDialogEvent& event)
{
    dirty_ = false;
    selectedListItemId_ = -1;
    patternText_->SetFocus();
    refreshItemList(0);
}

void ItemsDialog::onItemSelected(wxListEvent& event)
{
    if (processEvents_) {
        selectItem(event.GetIndex());
    }
}

void ItemsDialog::onPatternText(wxCommandEvent& event)
{
    if (processEvents_) {
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
}

void ItemsDialog::onRename(wxCommandEvent& event)
{
    wxString previousName = itemList_->GetItemText(selectedListItemId_);

    wxTextEntryDialog* dlg = new wxTextEntryDialog(this, wxT("New name:"), wxT("Rename item"), previousName);
    if (wxID_OK == dlg->ShowModal()) {

        wxString newName = UiUtil::makeProperName(dlg->GetValue());
        if (newName.Len() <= 0) {
            wxMessageBox(wxT("Item name cannot be empty"), wxT("Renaming item"));
        } else {
            if (newName != previousName) {
                string name;
                UiUtil::appendWxString(name, newName);
                const Item* tmp = Controller::instance()->selectItem(name.c_str());
                if (tmp != 0) {
                    wxString msg(wxT("The name '"));
                    msg.Append(newName);
                    msg.Append(wxT("'\nis already used by another item"));
                    wxMessageBox(msg, wxT("Renaming item"));
                } else {
                    Item item;
                    item.setId(selectedItem_->getId());
                    item.setName(name.c_str());
                    Controller::instance()->insertUpdateItem(&item);
                    dirty_ = true;
                    refreshItemList(item.getId());
                }
            }
        }
    }
    dlg->Destroy();
}

void ItemsDialog::onDelete(wxCommandEvent& event)
{
    wxString msg(wxT("Are you sure you want to delete the item\n'"));
    msg.Append(itemList_->GetItemText(selectedListItemId_));
    msg.Append(wxT("'?"));

    wxMessageDialog* dlg = new wxMessageDialog(this, msg, wxT("Delete item"), wxOK | wxCANCEL);
    if (wxID_OK == dlg->ShowModal()) {
        Controller::instance()->deleteItem(selectedItem_->getId());
        dirty_ = true;
        refreshItemList(0);
        patternText_->SetFocus();
    }
    dlg->Destroy();
}

void ItemsDialog::onClose(wxCommandEvent& event)
{
    Close();
    Destroy();
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
    processEvents_ = false;

    renameButton_->Enable(false);

    deleteButton_->Enable(false);
    deleteButton_->SetToolTip(0);

    if (listItemId >= 0) {
        selectedListItemId_ = listItemId;
        selectedItem_ = Controller::instance()->selectItem(itemList_->GetItemData(selectedListItemId_));
        bool itemInUse = Controller::instance()->selectItemInUse(selectedItem_->getId());

        itemList_->SetItemState(listItemId, wxLIST_STATE_SELECTED, wxLIST_STATE_SELECTED);
        itemList_->EnsureVisible(listItemId);

        renameButton_->Enable(true);

        if (itemInUse) {
            deleteButton_->SetToolTip(wxT("Item is used in a transaction"));
        } else {
            deleteButton_->Enable(true);
        }
    } else {
        listItemId = -1;
        while (true) {
            listItemId = itemList_->GetNextItem(listItemId);
            if (listItemId < 0) {
                break;
            }
            itemList_->SetItemState(listItemId, wxLIST_STATE_DONTCARE, wxLIST_STATE_SELECTED);
        }
        selectedListItemId_ = -1;

        patternText_->SetValue(wxEmptyString);

        itemList_->EnsureVisible(0);
    }

    processEvents_ = true;
}
