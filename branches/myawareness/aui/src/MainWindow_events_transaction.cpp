#include <string>
#include <wx/htmllbox.h>
#include <wx/msgdlg.h>
#include <wx/combobox.h>
#include <wx/datectrl.h>
#include <wx/choice.h>
#include <Item.h>
#include <Transaction.h>
#include <UiUtil.h>
#include <Controller.h>
#include <MainWindow.h>

using namespace adb;
using namespace std;

void MainWindow::onTransactionSelected(wxCommandEvent& event)
{
    int idx = transactionsList_->GetSelection();
    wxString html = transactionsList_->GetString(idx);
    int first = html.Find(wxChar('@')) + 1;
    int last = html.Find(wxChar('@'), true) - 1;
    wxString idString = html.SubString(first, last);
    long id;
    if (!idString.ToLong(&id)) {
        wxMessageBox(_T("Could not read id\n(this should not happen)"));
    }
    transactionId_ = static_cast<int> (id);
    Controller::instance()->transactionToView(transactionId_, true);
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
    const Item* item = Controller::instance()->getItemByName(trItemCombo_->GetValue());
    if (0 != item) {
        Controller::instance()->transactionToView(item->getLastTransactionId(), false);
    } else {
        transactionToView(0, false);
    }
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
    setInsertTransactionView();
}

void MainWindow::onAcceptTransaction(wxCommandEvent& event)
{
    bool isValid = true;

    time_t when = trDatePicker_->GetValue().GetTicks();

    double val;
    if (!trValueText_->GetValue().ToDouble(&val)) {
        isValid = false;
        trValueText_->SetBackgroundColour(errCol_);
    } else {
        trValueText_->SetBackgroundColour(trCommentText_->GetBackgroundColour());
    }

    int fromId = reinterpret_cast<int> (trSourceChoice_->GetClientData(trSourceChoice_->GetSelection()));
    if (0 == fromId) {
        isValid = false;
        trSourceChoice_->SetBackgroundColour(errCol_);
    } else {
        trSourceChoice_->SetBackgroundColour(trCommentText_->GetBackgroundColour());
    }

    int toId = reinterpret_cast<int> (trDestinationChoice_->GetClientData(trDestinationChoice_->GetSelection()));
    if (0 == toId) {
        isValid = false;
        trDestinationChoice_->SetBackgroundColour(errCol_);
    } else {
        trDestinationChoice_->SetBackgroundColour(trCommentText_->GetBackgroundColour());
    }

    int itemId = 0;
    if (isValid) {
        itemId = Controller::instance()->getItemId(trItemCombo_->GetValue());
        if (0 == itemId) {
            isValid = false;
            trItemCombo_->SetBackgroundColour(errCol_);
            trItemCombo_->SetValue(_T(""));
            checkItem();
        } else {
            trItemCombo_->SetBackgroundColour(trCommentText_->GetBackgroundColour());
        }
    }

    if (isValid) {
        Transaction t(transactionId_);
        t.setDate(when);
        t.setItemId(itemId);
        t.setValue(val);
        t.setFromId(fromId);
        t.setToId(toId);
        string comment;
        UiUtil::appendWxString(comment, trCommentText_->GetValue());
        t.setDescription(comment.c_str());

        Controller::instance()->acceptTransaction(&t);

        setInsertTransactionView();
    }
}

