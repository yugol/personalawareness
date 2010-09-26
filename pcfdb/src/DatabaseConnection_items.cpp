#include <cstring>
#include <Exception.h>
#include <cmd/SelectItems.h>
#include <cmd/GetItem.h>
#include <cmd/InsertItem.h>
#include <cmd/UpdateItem.h>
#include <cmd/DeleteItem.h>
#include <DatabaseConnection.h>

using namespace std;

void DatabaseConnection::insertUpdate(Item *item)
{
    invalidateItems();
    ReversibleDatabaseCommand* cmd = 0;
    try {
        if (0 == item->getId()) {
            cmd = new InsertItem(database_, *item);
            cmd->execute();
            item->setId(static_cast<InsertItem*> (cmd)->getItem().getId());
        } else {
            cmd = new UpdateItem(database_, *item);
            cmd->execute();
        }
        undoBuffer_.add(cmd);
    } catch (const Exception& ex) {
        delete cmd;
        RETHROW(ex);
    }
}

void DatabaseConnection::selectItems(vector<int>* selection, SelectionParameters* parameters) const
{
    SelectItems(database_, selection, parameters).execute();
}

bool DatabaseConnection::isItemInUse(int id) const
{
    return isItemInUse(database_, id);
}

void DatabaseConnection::getItem(Item* item) const
{
    GetItem(database_, item).execute();
}

void DatabaseConnection::deleteItem(int id)
{
    invalidateItems();
    ReversibleDatabaseCommand* cmd = 0;
    try {
        cmd = new DeleteItem(database_, id);
        cmd->execute();
        undoBuffer_.add(cmd);
    } catch (const Exception& ex) {
        delete cmd;
        RETHROW(ex);
    }
}

void DatabaseConnection::cashItems() const
{
    if (items_.size() > 0) {
        return;
    }

    vector<int> selection;
    SelectItems selectCmd(database_, &selection, 0);
    selectCmd.execute();

    invalidateItems();
    vector<int>::iterator it;
    for (it = selection.begin(); it != selection.end(); ++it) {
        int id = (*it);
        items_[id] = Item(id);
        GetItem getCmd(database_, &items_[id]);
        getCmd.execute();
    }
}

int DatabaseConnection::getItemCount() const
{
    cashItems();
    return items_.size();
}

const Item* DatabaseConnection::getItem(int id) const
{
    cashItems();
    return &(items_[id]);
}

const Item* DatabaseConnection::getItem(const char* name) const
{
    cashItems();
    map<int, Item>::iterator it;
    for (it = items_.begin(); it != items_.end(); ++it) {
        const char* itemName = it->second.getName().c_str();
        int cmp = ::strcmp(itemName, name);
        if (0 == cmp) {
            return &(it->second);
        }
    }
    return 0;
}

