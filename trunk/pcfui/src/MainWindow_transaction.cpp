#include <string>
#include <wx/msgdlg.h>
#include <wx/htmllbox.h>
#include <Item.h>
#include <Transaction.h>
#include <UiUtil.h>
#include <AutocompleteWindow.h>
#include <Controller.h>
#include <MainWindow.h>

using namespace std;

void MainWindow::onTransactionSelected(wxCommandEvent& event)
{
    selectTransaction(getSelectedTransactionId(), false);
}

void MainWindow::onTransactionDateChanged(wxDateEvent& event)
{
    if (processTransactionEditEvents_) {
        readValidateRefreshTransaction();
    }
}

void MainWindow::onTransactionItemKeyDown(wxKeyEvent& event)
{
    if (processTransactionEditEvents_) {
        int keyCode = event.GetKeyCode();

        if (WXK_SPACE == keyCode && event.ControlDown()) {
            trItemAutocompletion_->show();
            trItemAutocompletion_->select(UiUtil::makeProperName(trItemText_->GetValue()), 0);
        } else {
            event.Skip();
        }
    }
}

void MainWindow::onTransactionItemText(wxCommandEvent& event)
{
    if (processTransactionEditEvents_ && getSelectedTransactionId() == 0) {
        string itemName;
        UiUtil::appendWxString(itemName, UiUtil::makeProperName(trItemText_->GetValue()));
        const Item* item = Controller::instance()->selectItem(itemName.c_str());
        if (0 != item) {
            selectTransaction(item->getLastTransactionId(), true);
        } else {
            selectTransaction(0, true);
        }
    }
}

void MainWindow::onTransactionValueText(wxCommandEvent& event)
{
    if (processTransactionEditEvents_) {
        readValidateRefreshTransaction();
    }
}

void MainWindow::onTransactionSourceChoice(wxCommandEvent& event)
{
    if (processTransactionEditEvents_) {
        readValidateRefreshTransaction();
    }
}

void MainWindow::onTransactionDestinationChoice(wxCommandEvent& event)
{
    if (processTransactionEditEvents_) {
        readValidateRefreshTransaction();
    }
}

void MainWindow::onTransactionCommentText(wxCommandEvent& event)
{
    if (processTransactionEditEvents_) {
        readValidateRefreshTransaction();
    }
}

void MainWindow::onNewTransaction(wxCommandEvent& event)
{
    selectTransaction(0);
}

void MainWindow::onDeleteTransaction(wxCommandEvent& event)
{
    wxMessageDialog* dlg = new wxMessageDialog(this, wxT("Are you sure you want to delete this transaction?"), wxT("Delete transaction"), wxOK | wxCANCEL);
    if (wxID_OK == dlg->ShowModal()) {
        Controller::instance()->deleteTransaction(getSelectedTransactionId());
        selectTransaction(0);
    }
}

void MainWindow::onAcceptTransaction(wxCommandEvent& event)
{
    Transaction transaction;
    if (readValidateRefreshTransaction(&transaction)) {
        if (transaction.getItemId() == 0) {
            string itemName;
            UiUtil::appendWxString(itemName, trItemText_->GetValue());
            Item item;
            item.setName(itemName.c_str());
            Controller::instance()->insertUpdateItem(&item);
            transaction.setItemId(item.getId());
        }
        Controller::instance()->insertUpdateTransaction(&transaction);
    }
    selectTransaction(0);
}

int MainWindow::getSelectedTransactionId()
{
    int idx = transactionsList_->GetSelection();
    if (idx < 0) {
        return 0;
    }

    wxString html = transactionsList_->GetString(idx);
    int first = html.Find(wxChar('@')) + 1;
    int last = html.Find(wxChar('@'), true) - 1;
    wxString idString = html.SubString(first, last);

    long transactionId = 0;
    idString.ToLong(&transactionId);

    return transactionId;
}

int MainWindow::getTransactionSourceIndexById(int id)
{
    for (unsigned int i = 0; i < trSourceChoice_->GetCount(); ++i) {
        int tmpId = reinterpret_cast<int> (trSourceChoice_->GetClientData(i));
        if (tmpId == id) {
            return i;
        }
    }
    return -1;
}

int MainWindow::getTransactionDestinationIndexById(int id)
{
    for (unsigned int i = 0; i < trDestinationChoice_->GetCount(); ++i) {
        int tmpId = reinterpret_cast<int> (trDestinationChoice_->GetClientData(i));
        if (tmpId == id) {
            return i;
        }
    }
    return -1;
}

void MainWindow::selectTransaction(int transactionId, bool isAutocomplete)
{
    processTransactionEditEvents_ = false;

    Transaction transaction;
    if (transactionId != 0) {
        Controller::instance()->selectTransaction(&transaction, transactionId);
    }

    trDeleteButton_->Show(false);
    trNewButton_->Show(false);

    if (transaction.getId() == 0) {
        transactionsList_->SetSelection(wxNOT_FOUND);
        if (!isAutocomplete) {
            trItemText_->SetValue(wxEmptyString);
        }
        trValueText_->SetValue(wxEmptyString);
        trSourceChoice_->SetSelection(0);
        trDestinationChoice_->SetSelection(0);
        trCommentText_->SetValue(wxEmptyString);
    } else {
        if (!isAutocomplete) {
            wxDateTime trDate;
            UiUtil::adbDate2wxDate(trDate, transaction.getDate());
            trDatePicker_->SetValue(trDate);
        }

        wxString itemName;
        UiUtil::appendStdString(itemName, Controller::instance()->selectItem(transaction.getItemId())->getName());
        trItemText_->SetValue(itemName);

        wxString value;
        value.Printf(wxT("%0.2f"), transaction.getValue());
        trValueText_->SetValue(value);

        int idx = getTransactionSourceIndexById(transaction.getFromId());
        trSourceChoice_->SetSelection(idx);

        idx = getTransactionDestinationIndexById(transaction.getToId());
        trDestinationChoice_->SetSelection(idx);

        wxString comment;
        UiUtil::appendStdString(comment, transaction.getComment());
        trCommentText_->SetValue(comment);

        if (!isAutocomplete) {
            trDeleteButton_->Show(true);
            trNewButton_->Show(true);
        }
    }

    readValidateRefreshTransaction();

    trItemText_->SetFocus();

    processTransactionEditEvents_ = true;
}

bool MainWindow::readValidateRefreshTransaction(Transaction* transaction)
{
    // transaction id

    if (transaction != 0) {
        transaction->setId(getSelectedTransactionId());
    }

    // transaction date

    if (transaction != 0) {
        time_t when = trDatePicker_->GetValue().GetTicks();
        transaction->setDate(when);
    }

    // transaction item

    string itemName;
    UiUtil::appendWxString(itemName, UiUtil::makeProperName(trItemText_->GetValue()));
    if (itemName.size() <= 0) {
        trAcceptButton_->Enable(false);
        trAcceptButton_->SetToolTip(wxT("Item name cannot be empty"));
        return false;
    }
    if (transaction != 0) {
        const Item* item = Controller::instance()->selectItem(itemName.c_str());
        if (0 != item) {
            transaction->setItemId(item->getId());
        } else {
            transaction->setItemId(0);
        }
    }

    // transaction value

    double value = 0;
    trValueText_->GetValue().ToDouble(&value);
    if (value == 0) {
        trAcceptButton_->Enable(false);
        trAcceptButton_->SetToolTip(wxT("Value must be a real non zero number"));
        return false;
    }
    if (transaction != 0) {
        transaction->setValue(value);
    }

    // transaction source

    int fromId = reinterpret_cast<int> (trSourceChoice_->GetClientData(trSourceChoice_->GetSelection()));
    if (fromId == 0) {
        trAcceptButton_->Enable(false);
        trAcceptButton_->SetToolTip(wxT("Source account must be specified"));
        return false;
    }
    if (transaction != 0) {
        transaction->setFromId(fromId);
    }

    // transaction destination

    int toId = reinterpret_cast<int> (trDestinationChoice_->GetClientData(trDestinationChoice_->GetSelection()));
    if (toId == 0) {
        trAcceptButton_->Enable(false);
        trAcceptButton_->SetToolTip(wxT("Destination account must be specified"));
        return false;
    }
    if (transaction != 0) {
        transaction->setToId(toId);
    }

    // source - destination relation

    if (fromId == toId) {
        trAcceptButton_->Enable(false);
        trAcceptButton_->SetToolTip(wxT("Destination account and Source account must be different"));
        return false;
    }

    // transaction comment

    string comment;
    UiUtil::appendWxString(comment, trCommentText_->GetValue());
    if (transaction != 0) {
        transaction->setComment(comment.c_str());
    }

    // finalizing
    trAcceptButton_->Enable(true);
    trAcceptButton_->SetToolTip(0);
    return true;
}

