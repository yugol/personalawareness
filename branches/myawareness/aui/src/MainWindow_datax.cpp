#include <wx/stattext.h>
#include <wx/listctrl.h>
#include <wx/choice.h>
#include <wx/combobox.h>
#include <wx/htmllbox.h>
#include <wx/datectrl.h>
#include <Configuration.h>
#include <Account.h>
#include <Item.h>
#include <Transaction.h>
#include <SelectionParameters.h>
#include <UiUtil.h>
#include <MainWindow.h>

using namespace std;
using namespace adb;

void MainWindow::setNetWorth(double val)
{
    wxString wxworth(wxT("Net worth: "));
    UiUtil::appendCurrency(wxworth, val);
    netWorthLabel_->SetLabel(wxworth);
    fitAccountsPage();
}

void MainWindow::populateAccounts(const vector<pair<Account*, double> >& stmt)
{
    bool firstGroup = true;
    double groupBalance = 0;
    wxString prevGroup;

    wxListItem item;
    wxListItem groupItem;

    item.SetFont(normalFont_);
    groupItem.SetFont(boldFont_);

    selAccountChoice_->Clear();
    selAccountChoice_->Append(wxT("(All)"));
    selAccountChoice_->SetSelection(0);

    accountList_->DeleteAllItems();

    trSourceChoice_->Clear();
    trSourceChoice_->Append(wxT("-"), reinterpret_cast<void*> (Configuration::DEFAULT_ID));
    trSourceChoice_->SetSelection(0);
    trDestinationChoice_->Clear();
    trDestinationChoice_->Append(wxT("-"), reinterpret_cast<void*> (Configuration::DEFAULT_ID));
    trDestinationChoice_->SetSelection(0);

    vector<pair<Account*, double> >::const_iterator it;
    for (it = stmt.begin(); it != stmt.end(); ++it) {
        Account* acc = it->first;

        wxString fullName;
        UiUtil::appendStdString(fullName, acc->getFullName());
        int id = acc->getId();
        selAccountChoice_->Append(fullName, reinterpret_cast<void*> (id));
        trSourceChoice_->Append(fullName, reinterpret_cast<void*> (id));
        trDestinationChoice_->Append(fullName, reinterpret_cast<void*> (id));

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
}

void MainWindow::populateCreditingBudgets(const vector<Account*>& budgets)
{
    vector<Account*>::const_iterator it;
    for (it = budgets.begin(); it != budgets.end(); ++it) {
        Account* acc = *it;
        wxString accName;
        UiUtil::appendStdString(accName, acc->getDecoratedName());
        int id = acc->getId();
        selAccountChoice_->Append(accName, reinterpret_cast<void*> (id));
        trSourceChoice_->Append(accName, reinterpret_cast<void*> (id));
    }
}

void MainWindow::populateDebitingBudgets(const vector<Account*>& budgets)
{
    vector<Account*>::const_iterator it;
    for (it = budgets.begin(); it != budgets.end(); ++it) {
        Account* acc = *it;
        wxString accName;
        UiUtil::appendStdString(accName, acc->getDecoratedName());
        int id = acc->getId();
        selAccountChoice_->Append(accName, reinterpret_cast<void*> (id));
        trDestinationChoice_->Append(accName, reinterpret_cast<void*> (id));
    }
}

void MainWindow::populateItems(const vector<const Item*>& items)
{
    trItemCombo_->Clear();
    vector<const Item*>::const_iterator it;
    for (it = items.begin(); it != items.end(); ++it) {
        const Item* item = *it;
        wxString fullName;
        UiUtil::appendStdString(fullName, item->getName());
        int id = item->getId();
        trItemCombo_->Append(fullName, reinterpret_cast<void*> (id));
    }
}

void MainWindow::populateTransactions(const wxArrayString& items)
{
    transactionsList_->Clear();
    transactionsList_->Append(items);
}

void MainWindow::transactionToView(const Transaction* t, bool complete)
{
    if (0 != t) {
        if (complete) {
            wxDateTime trDate;
            UiUtil::adbDate2wxDate(&trDate, &(t->getDate()));
            trDatePicker_->SetValue(trDate);
        }

        int idx = getItemIndexById(t->getItemId());
        trItemCombo_->SetSelection(idx);

        wxString val;
        val.Printf(wxT("%0.2f"), t->getValue());
        trValueText_->SetValue(val);

        idx = getSourceIndexById(t->getFromId());
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
            trItemCombo_->SetValue(wxT(""));
        }
        trValueText_->SetValue(wxT(""));
        trSourceChoice_->SetSelection(0);
        trDestinationChoice_->SetSelection(0);
        trCommentText_->SetValue(wxT(""));
    }

    clearTransactionErrorHighlight();
}

void MainWindow::getTransactionSelectionParameters(adb::SelectionParameters* parameters)
{
    parameters->setFirstDate(selFirstDatePicker_->GetValue().GetTicks());
    parameters->setLastDate(selLastDatePicker_->GetValue().GetTicks());
    int accountId = reinterpret_cast<int> (selAccountChoice_->GetClientData(selAccountChoice_->GetSelection()));
    parameters->setAccountId(accountId);
    string pattern;
    UiUtil::appendWxString(pattern, selPatternText_->GetValue());
    parameters->setNamePattern(pattern.c_str());
}

