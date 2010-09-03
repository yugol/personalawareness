#include <string>
#include <wx/combobox.h>
#include <wx/datectrl.h>
#include <wx/choice.h>
#include <wx/button.h>
#include <wx/msgdlg.h>
#include <Item.h>
#include <Transaction.h>
#include <UiUtil.h>
#include <AutocompletionWindow.h>
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
    if (processTransactionEditEvents_) {
        int keyCode = event.GetKeyCode();

        if (WXK_UP == keyCode) {
            trItemAutocompletion_->show();
            trItemAutocompletion_->select(trItemText_->GetValue(), -1);
        } else if (WXK_DOWN == keyCode) {
            trItemAutocompletion_->show();
            trItemAutocompletion_->select(trItemText_->GetValue(), 1);
        } else if (WXK_SPACE == keyCode && event.ControlDown()) {
            trItemAutocompletion_->show();
            trItemAutocompletion_->select(trItemText_->GetValue(), 0);
        } else {
            event.Skip();
        }
    }
}

void MainWindow::onTransactionItemText(wxCommandEvent& event)
{
    setTransactionDirty();
    if (processTransactionEditEvents_) {

        string itemName;
        UiUtil::appendWxString(itemName, trItemText_->GetValue());
        const Item* item = Controller::instance()->selectItem(itemName.c_str());
        if (0 != item) {
            Controller::instance()->transactionToView(item->getLastTransactionId(), false);
        } else {
            transactionToView(0, false);
        }
    }
}

void MainWindow::onTransactionValueText(wxCommandEvent& event)
{
    if (processTransactionEditEvents_) {
        setTransactionDirty();
    }
}

void MainWindow::onTransactionSourceChoice(wxCommandEvent& event)
{
    if (processTransactionEditEvents_) {
        setTransactionDirty();
    }
}

void MainWindow::onTransactionDestinationChoice(wxCommandEvent& event)
{
    if (processTransactionEditEvents_) {
        setTransactionDirty();
    }
}

void MainWindow::onTransactionCommentText(wxCommandEvent& event)
{
    if (processTransactionEditEvents_) {
        setTransactionDirty();
    }
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

void MainWindow::transactionToView(const Transaction* t, bool complete)
{
    processTransactionEditEvents_ = false;

    if (0 != t) {
        if (complete) {
            wxDateTime trDate;
            UiUtil::adbDate2wxDate(&trDate, &(t->getDate()));
            trDatePicker_->SetValue(trDate);
        }

        wxString itemName;
        UiUtil::appendStdString(itemName, Controller::instance()->selectItem(t->getItemId())->getName());
        trItemText_->SetValue(itemName);

        wxString val;
        val.Printf(wxT("%0.2f"), t->getValue());
        trValueText_->SetValue(val);

        int idx = getSourceIndexById(t->getFromId());
        trSourceChoice_->SetSelection(idx);

        idx = getDestinationIndexById(t->getToId());
        trDestinationChoice_->SetSelection(idx);

        wxString comment;
        UiUtil::appendStdString(comment, t->getDescription());
        trCommentText_->SetValue(comment);

        if (complete) {
            setUpdateTransactionView();
        }
    } else {
        if (complete) {
            trItemText_->SetValue(wxEmptyString);
        }
        trValueText_->SetValue(wxEmptyString);
        trSourceChoice_->SetSelection(0);
        trDestinationChoice_->SetSelection(0);
        trCommentText_->SetValue(wxEmptyString);
    }

    clearTransactionErrorHighlight();

    processTransactionEditEvents_ = true;
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
        UiUtil::appendWxString(itemName, trItemText_->GetValue());
        const Item* item = Controller::instance()->selectInsertItem(itemName.c_str());
        if (0 != item) {
            itemId = item->getId();
        }
        if (0 == item) {
            isValid = false;
            trItemText_->SetValue(wxEmptyString);
            trItemText_->SetBackgroundColour(errorHighlight_);
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

