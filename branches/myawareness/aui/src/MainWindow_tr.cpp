#ifdef WX_PRECOMP
#include "wx_pch.h"
#endif

#ifdef __BORLANDC__
#pragma hdrstop
#endif //__BORLANDC__
#include <Transaction.h>
#include <MainWindow.h>
#include <Controller.h>

using namespace adb;

static void Date2wxDate(wxDateTime* wxd, const Date* d)
{
	wxd->SetDay(d->getDay());
	wxd->SetMonth(static_cast<wxDateTime::Month> (d->getMonth() - 1));
	wxd->SetYear(d->getYear());
}

void MainWindow::transactionToView(const Transaction* t)
{
	if (0 != t) {
		wxDateTime trDate;
		Date2wxDate(&trDate, t->getDate());
		trDatePicker_->SetValue(trDate);

		int idx = getItemIndexById(t->getItemId());
		trItemCombo_->SetSelection(idx);

		wxString val;
		val.Printf(_T("%0.2f"), t->getValue());
		trValueText_->SetValue(val);

		idx = getSourceIndexById(t->getFromId());
		trSourceChoice_->SetSelection(idx);

		idx = getDestinationIndexById(t->getToId());
		trDestinationChoice_->SetSelection(idx);

		wxString comment(t->getDescription().c_str(), wxConvLibc);
		trCommentText_->SetValue(comment);

		setUpdateTransactionEnv();
	} else {
		trItemCombo_->SetValue(_T(""));
		trValueText_->SetValue(_T(""));
		trSourceChoice_->SetSelection(0);
		trDestinationChoice_->SetSelection(0);
		trCommentText_->SetValue(_T(""));
	}
}

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
	controller_->editTransaction(transactionId_);
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
	}
}

void MainWindow::onTransactionItemText(wxCommandEvent& event)
{
	setTransactionDirty();
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
	setInsertTransactionEnv();
}

void MainWindow::onDeleteTransaction(wxCommandEvent& event)
{
	setInsertTransactionEnv();
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
		wxString itemName = trItemCombo_->GetValue().Trim(true).Trim(false);
		itemId = controller_->getItemId(itemName);
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
		t.setDescription(trCommentText_->GetValue().fn_str());

		controller_->acceptTransaction(&t);

		setInsertTransactionEnv();
	}
}

