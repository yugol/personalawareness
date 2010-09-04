#include <cstring>
#include <Exception.h>
#include <cmd/SelectItemsCommand.h>
#include <cmd/GetItemCommand.h>
#include <cmd/InsertItemCommand.h>
#include <cmd/UpdateItemCommand.h>
#include <cmd/DeleteItemCommand.h>
#include <DatabaseConnection.h>

using namespace std;

namespace adb {

    void DatabaseConnection::insertUpdate(Item *item)
    {
        items_.clear();
        ReversibleDatabaseCommand* cmd = 0;
        try {
            if (0 == item->getId()) {
                cmd = new InsertItemCommand(database_, *item);
                cmd->execute();
                item->setId(static_cast<InsertItemCommand*> (cmd)->getItem().getId());
            } else {
                cmd = new UpdateItemCommand(database_, *item);
                cmd->execute();
            }
            undoManager_.add(cmd);
        } catch (const Exception& ex) {
            delete cmd;
            RETHROW(ex);
        }
    }

    void DatabaseConnection::selectItems(vector<int>* selection, SelectionParameters* parameters) const
    {
        SelectItemsCommand(database_, selection, parameters).execute();
    }

    bool DatabaseConnection::isItemInUse(int id) const
    {
        return isItemInUse(database_, id);
    }

    void DatabaseConnection::getItem(Item* item) const
    {
        GetItemCommand(database_, item).execute();
    }

    void DatabaseConnection::deleteItem(int id)
    {
        items_.clear();
        ReversibleDatabaseCommand* cmd = 0;
        try {
            cmd = new DeleteItemCommand(database_, id);
            cmd->execute();
            undoManager_.add(cmd);
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
        SelectItemsCommand selectCmd(database_, &selection, 0);
        selectCmd.execute();

        items_.clear();
        vector<int>::iterator it;
        for (it = selection.begin(); it != selection.end(); ++it) {
            int id = (*it);
            items_[id] = Item(id);
            GetItemCommand getCmd(database_, &items_[id]);
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

} // namespace adb
