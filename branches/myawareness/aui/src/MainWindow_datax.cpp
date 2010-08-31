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
    char currencyBuf[UiUtil::CURRENCY_BUFFER_LENGTH];
    UiUtil::formatCurrency(currencyBuf, val);
    char itemBuf[UiUtil::NAME_BUFFER_LENGTH];
    sprintf(itemBuf, "Net worth: %s", currencyBuf);
    wxString item(itemBuf, wxConvLibc);
    netWorthLabel_->SetLabel(item);
    fitAccountsPage();
}

void MainWindow::populateAccounts(const vector<pair<Account*, double> >& stmt)
{
    char currencyBuf[UiUtil::CURRENCY_BUFFER_LENGTH];
    bool firstGroup = true;
    double groupBalance = 0;
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
    trSourceChoice_->Append(_T("-"), reinterpret_cast<void*> (Configuration::DEFAULT_ID));
    trSourceChoice_->SetSelection(0);
    trDestinationChoice_->Clear();
    trDestinationChoice_->Append(_T("-"), reinterpret_cast<void*> (Configuration::DEFAULT_ID));
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
                UiUtil::formatCurrency(currencyBuf, groupBalance);
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
        UiUtil::formatCurrency(currencyBuf, balanceVal);
        wxString balance(currencyBuf, wxConvLibc);
        item.SetColumn(1);
        item.SetAlign(wxLIST_FORMAT_RIGHT);
        item.SetText(balance);
        accList_->SetItem(item);
    }

    if (!firstGroup) {
        groupItem.SetColumn(1);
        groupItem.SetAlign(wxLIST_FORMAT_RIGHT);
        UiUtil::formatCurrency(currencyBuf, groupBalance);
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
        fullName.Prepend(_T("[+] "));
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
        fullName.Prepend(_T("[-] "));
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

void MainWindow::transactionToView(const Transaction* t, bool complete)
{
    if (0 != t) {
        if (complete) {
            wxDateTime trDate;
            UiUtil::convertDate2wxDate(&trDate, &(t->getDate()));
            trDatePicker_->SetValue(trDate);
        }

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

        if (complete) {
            setUpdateTransactionEnv();
        }
    } else {
        if (complete) {
            trItemCombo_->SetValue(_T(""));
        }
        trValueText_->SetValue(_T(""));
        trSourceChoice_->SetSelection(0);
        trDestinationChoice_->SetSelection(0);
        trCommentText_->SetValue(_T(""));
    }
}

void MainWindow::getTransactionSelectionParameters(adb::SelectionParameters* parameters)
{
    parameters->setFirstDate(selFirstDatePicker_->GetValue().GetTicks());
    parameters->setLastDate(selLastDatePicker_->GetValue().GetTicks());
    int accountId = reinterpret_cast<int> (selAccountChoice_->GetClientData(selAccountChoice_->GetSelection()));
    parameters->setAccountId(accountId);
    char patternBuf[UiUtil::NAME_BUFFER_LENGTH];
    UiUtil::formatString(patternBuf, selPatternText_->GetValue());
}

