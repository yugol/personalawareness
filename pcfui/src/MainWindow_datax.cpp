#include <wx/htmllbox.h>
#include <Configuration.h>
#include <Account.h>
#include <Item.h>
#include <Transaction.h>
#include <SelectionParameters.h>
#include <UiUtil.h>
#include <AutocompleteWindow.h>
#include <Controller.h>
#include <MainWindow.h>

using namespace std;

void MainWindow::setNetWorth(double value)
{
	wxString wxworth(wxT("Net balance: "));
	UiUtil::appendCurrency(wxworth, value);
	netBalanceLabel_->SetLabel(wxworth);
	fitAccountsPage();
}

void MainWindow::refreshStatement(const vector<pair<const Account*, double> >& statement, double netWorth)
{
	bool firstGroup = true;
	double groupBalance = 0;
	wxString prevGroup;

	wxListItem item;
	wxListItem groupItem;

	item.SetFont(normalFont_);
	groupItem.SetFont(boldFont_);

	accountList_->DeleteAllItems();

	vector<pair<const Account*, double> >::const_iterator it;
	for (it = statement.begin(); it != statement.end(); ++it) {
		const Account* acc = it->first;

		wxString group;
		UiUtil::appendStdString(group, acc->getGroup());
		if (group != prevGroup) {
			if (!firstGroup) {
				groupItem.SetColumn(1);
				groupItem.SetAlign(wxLIST_FORMAT_RIGHT);
				wxString balance;
				UiUtil::appendCurrency(balance, groupBalance);
				groupItem.SetText(balance);
				accountList_->SetItem(groupItem);
			}

			prevGroup = group;
			groupBalance = 0;

			groupItem.SetId(accountList_->GetItemCount());
			groupItem.SetColumn(0);
			groupItem.SetAlign(wxLIST_FORMAT_LEFT);
			groupItem.SetText(group.Prepend(wxT(" ")));
			accountList_->InsertItem(groupItem);

			if (firstGroup) {
				firstGroup = false;
			}
		}

		wxString name(wxT("      "));
		UiUtil::appendStdString(name, acc->getName());
		item.SetId(accountList_->GetItemCount());
		item.SetColumn(0);
		item.SetAlign(wxLIST_FORMAT_LEFT);
		item.SetText(name);
		accountList_->InsertItem(item);

		double balanceVal = it->second;
		groupBalance += balanceVal;
		wxString balance;
		UiUtil::appendCurrency(balance, balanceVal);
		item.SetColumn(1);
		item.SetAlign(wxLIST_FORMAT_RIGHT);
		item.SetText(balance);
		accountList_->SetItem(item);
	}

	if (!firstGroup) {
		groupItem.SetColumn(1);
		groupItem.SetAlign(wxLIST_FORMAT_RIGHT);
		wxString balance;
		UiUtil::appendCurrency(balance, groupBalance);
		groupItem.SetText(balance);
		accountList_->SetItem(groupItem);
	}

	setNetWorth(netWorth);
}

void MainWindow::populateCashAccounts(const std::vector<const Account*>& accounts)
{
	selAccountChoice_->Clear();
	selAccountChoice_->Append(wxT("(All)"));
	selAccountChoice_->SetSelection(0);

	trSourceChoice_->Clear();
	trSourceChoice_->Append(wxT("- Source account -"), reinterpret_cast<void*> (Configuration::DEFAULT_ID));
	trSourceChoice_->SetSelection(0);

	trDestinationChoice_->Clear();
	trDestinationChoice_->Append(wxT("- Destination account -"), reinterpret_cast<void*> (Configuration::DEFAULT_ID));
	trDestinationChoice_->SetSelection(0);

	vector<const Account*>::const_iterator it;
	for (it = accounts.begin(); it != accounts.end(); ++it) {
		const Account* acc = *it;
		wxString accName;
		UiUtil::appendStdString(accName, acc->getDecoratedName());
		int id = acc->getId();
		selAccountChoice_->Append(accName, reinterpret_cast<void*> (id));
		trSourceChoice_->Append(accName, reinterpret_cast<void*> (id));
		trDestinationChoice_->Append(accName, reinterpret_cast<void*> (id));
	}
}

void MainWindow::appendIncomeAccounts(const vector<const Account*>& accounts)
{
	vector<const Account*>::const_iterator it;
	for (it = accounts.begin(); it != accounts.end(); ++it) {
		const Account* acc = *it;
		wxString accName;
		UiUtil::appendStdString(accName, acc->getDecoratedName());
		int id = acc->getId();
		selAccountChoice_->Append(accName, reinterpret_cast<void*> (id));
		trSourceChoice_->Append(accName, reinterpret_cast<void*> (id));
	}
}

void MainWindow::appendExpensesAcounts(const vector<const Account*>& accounts)
{
	vector<const Account*>::const_iterator it;
	for (it = accounts.begin(); it != accounts.end(); ++it) {
		const Account* acc = *it;
		wxString accName;
		UiUtil::appendStdString(accName, acc->getDecoratedName());
		int id = acc->getId();
		selAccountChoice_->Append(accName, reinterpret_cast<void*> (id));
		trDestinationChoice_->Append(accName, reinterpret_cast<void*> (id));
	}
}

void MainWindow::populateItems(const vector<const Item*>& items)
{
	trItemAutocompletion_->clear();
	vector<const Item*>::const_iterator it;
	for (it = items.begin(); it != items.end(); ++it) {
		const Item* item = *it;
		wxString itemName;
		UiUtil::appendStdString(itemName, item->getName());
		trItemAutocompletion_->append(itemName, item->getId());
	}
}

void MainWindow::populateTransactions(const wxArrayString& entries)
{
	transactionsList_->Clear();
	transactionsList_->Append(entries);
}

void MainWindow::getTransactionSelectionParameters(SelectionParameters* parameters)
{
	int accountId = reinterpret_cast<int> (selAccountChoice_->GetClientData(selAccountChoice_->GetSelection()));
	string pattern;
	UiUtil::appendWxString(pattern, selPatternText_->GetValue());

	parameters->setFirstDate(selFirstDatePicker_->GetValue().GetTicks());
	parameters->setLastDate(selLastDatePicker_->GetValue().GetTicks());
	parameters->setAccountId(accountId);
	parameters->setNamePattern(pattern.c_str());
}

