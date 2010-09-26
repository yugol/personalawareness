#ifndef ITEMSDIALOG_H_
#define ITEMSDIALOG_H_

#include "ItemsDialogBase.h"

class ItemsDialog: public ItemsDialogBase {
public:
    ItemsDialog(wxWindow* parent);
    virtual ~ItemsDialog();

protected:

    void onCloseDialog(wxCloseEvent& event);
    void onInitDialog(wxInitDialogEvent& event);
    void onPatternText(wxCommandEvent& event);
    void onItemSelected(wxListEvent& event);
    void onRename(wxCommandEvent& event);
    void onDelete(wxCommandEvent& event);
    void onClose(wxCommandEvent& event);

private:
    bool processEvents_;
    bool dirty_;
    long selectedListItemId_;
    const Item* selectedItem_;

    void selectItem(long selectedId);
    void refreshItemList(int itemId);
};

#endif /* ITEMSDIALOG_H_ */
