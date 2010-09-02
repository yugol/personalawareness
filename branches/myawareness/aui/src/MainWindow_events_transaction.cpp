#include <string>
#include <wx/combobox.h>
#include <wx/datectrl.h>
#include <wx/choice.h>
#include <wx/button.h>
#include <wx/msgdlg.h>
#include <Item.h>
#include <Transaction.h>
#include <UiUtil.h>
#include <Controller.h>
#include <MainWindow.h>

using namespace adb;
using namespace std;

void MainWindow::onTransactionSelected(wxCommandEvent& event)
{
    updateSelectedTransactionId();
    Controller::instance()->transactionToView(selectedTransactionId_, true);
}

void MainWindow::onTransactionDateChanged(wxDateEvent& event)
{
    setTransactionDirty();
}

void MainWindow::onTransactionItemKeyDown(wxKeyEvent& event)
{
    int keyCode = event.GetKeyCode();
    int idx = trItemCombo_->GetSelection();

    if (WXK_UP == keyCode) {
        --idx;
        if (idx < 0) {
            idx = 0;
        }
    } else if (WXK_DOWN == keyCode) {
        ++idx;
        if (static_cast<unsigned int> (idx) >= trItemCombo_->GetCount()) {
            idx = trItemCombo_->GetCount() - 1;
        }
    } else if (WXK_SPACE == keyCode && event.ControlDown()) {
        wxString text = trItemCombo_->GetValue();
        for (unsigned int i = 0; i < trItemCombo_->GetCount(); ++i) {
            wxString itemString = trItemCombo_->GetString(i);
            int cmp = itemString.CmpNoCase(text);
            if (0 <= cmp) {
                idx = i;
                break;
            }
        }
    } else {
        event.Skip();
        idx = -1;
    }

    if (idx >= 0) {
        trItemCombo_->SetSelection(idx);
        trItemCombo_->SetInsertionPoint(trItemCombo_->GetValue().size());
        wxCommandEvent dummy;
        onTransactionItemText(dummy);
    }
}

void MainWindow::onTransactionItemText(wxCommandEvent& event)
{
    setTransactionDirty();

    string itemName;
    UiUtil::appendWxString(itemName, trItemCombo_->GetValue());
    const Item* item = Controller::instance()->selectItem(itemName.c_str());
    if (0 != item) {
        Controller::instance()->transactionToView(item->getLastTransactionId(), false);
    } else {
        transactionToView(0, false);
    }
}

void MainWindow::onTransactionValueKeyDown(wxKeyEvent& event)
{
    if (trAcceptButton_->IsEnabled() && event.ControlDown()) {
        int keyCode = event.GetKeyCode();
        if (WXK_RETURN == keyCode || WXK_SPACE == keyCode) {
            acceptTransaction();
            return;
        }
    }
    event.Skip();
}

void MainWindow::onTransactionValueText(wxCommandEvent& event)
{
    setTransactionDirty();
}

void MainWindow::onTransactionSourceChoice(wxCommandEvent& event)
{
    setTransactionDirty();
}

void MainWindow::onTransactionDestinationChoice(wxCommandEvent& event)
{
    setTransactionDirty();
}

void MainWindow::onTransactionCommentText(wxCommandEvent& event)
{
    setTransactionDirty();
}

void MainWindow::onNewTransaction(wxCommandEvent& event)
{
    setInsertTransactionView();
}

void MainWindow::onDeleteTransaction(wxCommandEvent& event)
{
    wxMessageDialog* dlg = new wxMessageDialog(this, wxT("Are you sure you want to delete this transaction?"), wxT("Delete transaction"), wxOK | wxCANCEL);
    if (wxID_OK == dlg->ShowModal()) {
        Controller::instance()->deleteTransaction(selectedTransactionId_);
        setInsertTransactionView();
    }
}

void MainWindow::onAcceptTransaction(wxCommandEvent& event)
{
    acceptTransaction();
}

void MainWindow::acceptTransaction()
{
    clearTransactionErrorHighlight();
    bool isValid = true;

    time_t when = trDatePicker_->GetValue().GetTicks();

    double val;
    if (!trValueText_->GetValue().ToDouble(&val)) {
        isValid = false;
        trValueText_->SetBackgroundColour(errorHighlight_);
    }

    int fromId = reinterpret_cast<int> (trSourceChoice_->GetClientData(trSourceChoice_->GetSelection()));
    if (0 == fromId) {
        isValid = false;
        trSourceChoice_->SetBackgroundColour(errorHighlight_);
    }

    int toId = reinterpret_cast<int> (trDestinationChoice_->GetClientData(trDestinationChoice_->GetSelection()));
    if (0 == toId) {
        isValid = false;
        trDestinationChoice_->SetBackgroundColour(errorHighlight_);
    }

    if (fromId == toId) {
        isValid = false;
        trSourceChoice_->SetBackgroundColour(errorHighlight_);
        trDestinationChoice_->SetBackgroundColour(errorHighlight_);
    }

    int itemId = 0;
    if (isValid) {
        string itemName;
        UiUtil::appendWxString(itemName, trItemCombo_->GetValue());
        const Item* item = Controller::instance()->selectInsertItem(itemName.c_str());
        if (0 != item) {
            itemId = item->getId();
        }
        if (0 == item) {
            isValid = false;
            trItemCombo_->SetValue(wxT(""));
            trItemCombo_->SetBackgroundColour(errorHighlight_);
            checkItem();
        }
    }

    if (isValid) {
        Transaction t(selectedTransactionId_);
        t.setDate(when);
        t.setItemId(itemId);
        t.setValue(val);
        t.setFromId(fromId);
        t.setToId(toId);
        string description;
        UiUtil::appendWxString(description, trCommentText_->GetValue());
        t.setDescription(description.c_str());

        Controller::instance()->insertUpdateTransaction(&t);

        setInsertTransactionView();
    }
}

