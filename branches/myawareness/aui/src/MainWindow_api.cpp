#ifdef WX_PRECOMP
#include "wx_pch.h"
#endif

#ifdef __BORLANDC__
#pragma hdrstop
#endif //__BORLANDC__
#include <MainWindow.h>
#include <Controller.h>

using namespace std;
using namespace adb;

void MainWindow::setStatusMessage(const wxString& message)
{
	SetStatusText(message, 0);
}

void MainWindow::setNetWorth(double val)
{
	char currencyBuf[Controller::CURRENCY_BUF_LEN];
	controller_->formatCurrency(currencyBuf, val);
	char itemBuf[Controller::ITEM_BUF_LEN];
	sprintf(itemBuf, "Net worth: %s", currencyBuf);
	wxString item(itemBuf, wxConvLibc);
	netWorthLabel_->SetLabel(item);
	fitAccPage();
}

void MainWindow::populateAccounts(const vector<pair<Account*, double> >& stmt)
{
	char currencyBuf[Controller::CURRENCY_BUF_LEN];
	bool firstGroup = true;
	double groupBalance;
	wxString prevGroup;

	wxListItem item;
	wxListItem groupItem;

	item.SetFont(normalFont_);
	groupItem.SetFont(boldFont_);

	selAccountChoice_->Clear();
	selAccountChoice_->Append(_T("(All)"));
	selAccountChoice_->SetSelection(0);

	accList_->DeleteAllItems();

	trSourceChoice_->Clear();
	trSourceChoice_->Append(_T("-"), reinterpret_cast<void*> (0));
	trSourceChoice_->SetSelection(0);
	trDestinationChoice_->Clear();
	trDestinationChoice_->Append(_T("-"), reinterpret_cast<void*> (0));
	trDestinationChoice_->SetSelection(0);

	vector<pair<Account*, double> >::const_iterator it;
	for (it = stmt.begin(); it != stmt.end(); ++it) {
		Account* acc = it->first;

		wxString fullName(acc->getFullName().c_str(), wxConvLibc);
		int id = acc->getId();
		selAccountChoice_->Append(fullName, reinterpret_cast<void*> (id));
		trSourceChoice_->Append(fullName, reinterpret_cast<void*> (id));
		trDestinationChoice_->Append(fullName, reinterpret_cast<void*> (id));

		wxString group(acc->getGroup().c_str(), wxConvLibc);
		if (group != prevGroup) {
			if (!firstGroup) {
				groupItem.SetColumn(1);
				groupItem.SetAlign(wxLIST_FORMAT_RIGHT);
				controller_->formatCurrency(currencyBuf, groupBalance);
				wxString balance(currencyBuf, wxConvLibc);
				groupItem.SetText(balance);
				accList_->SetItem(groupItem);
			}

			prevGroup = group;
			groupBalance = 0;

			groupItem.SetId(accList_->GetItemCount());
			groupItem.SetColumn(0);
			groupItem.SetAlign(wxLIST_FORMAT_LEFT);
			groupItem.SetText(group.Prepend(_T(" ")));
			accList_->InsertItem(groupItem);

			if (firstGroup) {
				firstGroup = false;
			}
		}

		wxString name(acc->getName().c_str(), wxConvLibc);
		name.Prepend(_T("      "));
		item.SetId(accList_->GetItemCount());
		item.SetColumn(0);
		item.SetAlign(wxLIST_FORMAT_LEFT);
		item.SetText(name);
		accList_->InsertItem(item);

		double balanceVal = it->second;
		groupBalance += balanceVal;
		controller_->formatCurrency(currencyBuf, balanceVal);
		wxString balance(currencyBuf, wxConvLibc);
		item.SetColumn(1);
		item.SetAlign(wxLIST_FORMAT_RIGHT);
		item.SetText(balance);
		accList_->SetItem(item);
	}

	if (!firstGroup) {
		groupItem.SetColumn(1);
		groupItem.SetAlign(wxLIST_FORMAT_RIGHT);
		controller_->formatCurrency(currencyBuf, groupBalance);
		wxString balance(currencyBuf, wxConvLibc);
		groupItem.SetText(balance);
		accList_->SetItem(groupItem);
	}
}

void MainWindow::populateCreditingBudgets(const vector<Account*>& budgets)
{
	vector<Account*>::const_iterator it;
	for (it = budgets.begin(); it != budgets.end(); ++it) {
		Account* acc = *it;
		wxString fullName(acc->getFullName().c_str(), wxConvLibc);
		fullName.Prepend(_T("+ "));
		int id = acc->getId();
		selAccountChoice_->Append(fullName, reinterpret_cast<void*> (id));
		trSourceChoice_->Append(fullName, reinterpret_cast<void*> (id));
	}
}

void MainWindow::populateDebitingBudgets(const vector<Account*>& budgets)
{
	vector<Account*>::const_iterator it;
	for (it = budgets.begin(); it != budgets.end(); ++it) {
		Account* acc = *it;
		wxString fullName(acc->getFullName().c_str(), wxConvLibc);
		fullName.Prepend(_T("- "));
		int id = acc->getId();
		selAccountChoice_->Append(fullName, reinterpret_cast<void*> (id));
		trDestinationChoice_->Append(fullName, reinterpret_cast<void*> (id));
	}
}

void MainWindow::populateItems(const vector<const Item*>& items)
{
	trItemCombo_->Clear();
	vector<const Item*>::const_iterator it;
	for (it = items.begin(); it != items.end(); ++it) {
		const Item* item = *it;
		const char* itemName = item->getName().c_str();
		wxString fullName(itemName, wxConvLibc);
		int id = item->getId();
		trItemCombo_->Append(fullName, reinterpret_cast<void*> (id));
	}
}

void MainWindow::populateTransactions(const wxArrayString& items)
{
	transactionsList_->Clear();
	transactionsList_->Append(items);
}

int MainWindow::getItemIndexById(int id)
{
	for (unsigned int i = 0; i < trItemCombo_->GetCount(); ++i) {
		int tmpId = reinterpret_cast<int> (trItemCombo_->GetClientData(i));
		if (tmpId == id) {
			return i;
		}
	}
	return -1;
}

int MainWindow::getSourceIndexById(int id)
{
	for (unsigned int i = 0; i < trSourceChoice_->GetCount(); ++i) {
		int tmpId = reinterpret_cast<int> (trSourceChoice_->GetClientData(i));
		if (tmpId == id) {
			return i;
		}
	}
	return -1;
}

int MainWindow::getDestinationIndexById(int id)
{
	for (unsigned int i = 0; i < trDestinationChoice_->GetCount(); ++i) {
		int tmpId = reinterpret_cast<int> (trDestinationChoice_->GetClientData(i));
		if (tmpId == id) {
			return i;
		}
	}
	return -1;
}

