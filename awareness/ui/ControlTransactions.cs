/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 02/11/2008
 * Time: 19:30
 *
 *
 * Copyright (c) 2008 Iulian GORIAC
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

using Awareness.DB;

// TODO: in update mode don't use cashed values for transfer reason

namespace Awareness.UI
{
    public partial class ControlTransactions : UserControl {
        bool readTransferLocationsBit = true;
        bool readTransactionReasonsBit = true;
        bool readTransactionsBit = true;
        bool isDisplayed = false;

        public bool IsDisplayed {
            get { return isDisplayed; }
            set {
                isDisplayed = value;
                ReadTransferLocations();
                ReadTransactionReasons();
                ReadTransactions();
            }
        }

        DalTransferLocation selectedTransferLocation = null;
        string reasonSelectionPattern = null;
        IQueryable<DalTransaction> transactions = null;

        public ControlTransactions(){
            InitializeComponent();

            Util.SetMinMaxDatesAndShortFormatFor(datePicker);
            
            fromCombo.DropDownHeight = 250;
            toCombo.DropDownHeight = 250;

            timeIntervalSelectorControl.Interval = ETimeIntervals.THIS_QUARTER;
            selectPanelNormalHeight = selectPanel.Height;
            editPanelNormalHeight = editPanel.Height;
            EditMode = EEditModes.NEW;
            quantityInput.SetToolTip(toolTips.GetToolTip(quantityInput));

            transactionsView.SelectedIndexChanged += new EventHandler(TransactionsViewSelectedIndexChanged);
            timeIntervalSelectorControl.TimeIntervalChanged += new TimeIntervalChangedHandler(RequestReadTransactions);

            DBUtil.DataContextChanged += new DatabaseChangedHandler(RequestReadTransferLocations);
            DBUtil.DataContextChanged += new DatabaseChangedHandler(RequestReadTransactionReasons);
            DBUtil.DataContextChanged += new DatabaseChangedHandler(RequestReadTransactions);
            DBUtil.TransactionReasonsChanged += new DatabaseChangedHandler(RequestReadTransactionReasons);
            DBUtil.TransactionReasonsChanged += new DatabaseChangedHandler(RequestReadTransactions);
            DBUtil.TransferLocationsChanged += new DatabaseChangedHandler(RequestReadTransferLocations);
            DBUtil.TransferLocationsChanged += new DatabaseChangedHandler(RequestReadTransactions);
            DBUtil.PropertiesChanged += new DatabaseChangedHandler(RequestReadTransactions);
        }

        void RequestReadTransferLocations(){
            readTransferLocationsBit = true;
            ReadTransferLocations();
        }

        void ReadTransferLocations(){
            if (isDisplayed&&readTransferLocationsBit){
                fromCombo.Items.Clear();
                toCombo.Items.Clear();

                IQueryable<DalAccount> accounts = DBUtil.GetAccounts();
                IQueryable<DalBudgetCategory> budgetCategories = DBUtil.GetBudgetCategories();
                IQueryable<DalBudgetCategory> incomes = budgetCategories.Where(bc => bc.IsIncome);
                IQueryable<DalBudgetCategory> expenses = budgetCategories.Where(bc => !bc.IsIncome);

                fromCombo.Items.Add("---Accounts---");
                foreach (DalTransferLocation item in accounts){
                    fromCombo.Items.Add(item);
                }
                fromCombo.Items.Add("");
                fromCombo.Items.Add("---Budget categories---");
                foreach (DalBudgetCategory item in incomes){
                    fromCombo.Items.Add(item);
                }

                toCombo.Items.Add("---Accounts---");
                foreach (DalTransferLocation item in accounts){
                    toCombo.Items.Add(item);
                }
                toCombo.Items.Add("");
                toCombo.Items.Add("---Budget categories---");
                foreach (DalBudgetCategory item in expenses){
                    toCombo.Items.Add(item);
                }

                transferLocationSelectionCombo.Items.Clear();
                transferLocationSelectionCombo.Items.Add("(All)");
                foreach (DalBudgetCategory item in expenses){
                    transferLocationSelectionCombo.Items.Add(item);
                }
                foreach (DalBudgetCategory item in incomes){
                    transferLocationSelectionCombo.Items.Add(item);
                }
                foreach (DalTransferLocation item in accounts){
                    transferLocationSelectionCombo.Items.Add(item);
                }
                readTransferLocationsBit = false;
                //MessageBox.Show("TransferLocations updated");
            }
        }

        void RequestReadTransactionReasons(){
            readTransactionReasonsBit = true;
            ReadTransactionReasons();
        }

        void ReadTransactionReasons(){
            if (isDisplayed&&readTransactionReasonsBit){
                reasonCombo.Items.Clear();
                IQueryable<DalReason> reasons = DBUtil.GetTransferReasons();
                foreach (DalReason reason in reasons){
                    reasonCombo.Items.Add(reason);
                }
                readTransactionReasonsBit = false;
                //MessageBox.Show("TransactionReasons updated");
            }
        }

        void RequestReadTransactions(){
            readTransactionsBit = true;
            ReadTransactions();
        }

        void ReadTransactions(){
            if (isDisplayed&&readTransactionsBit){
                transactions = DBUtil.GetTransactions(timeIntervalSelectorControl.First, timeIntervalSelectorControl.Last);
                if (selectedTransferLocation != null){
                    transactions = transactions.Where(t => (t.FromId == selectedTransferLocation.Id)||(t.ToId == selectedTransferLocation.Id));
                }
                if (reasonSelectionPattern != null){
                    transactions = transactions.Where(t => t.Reason.Name.Contains(reasonSelectionPattern));
                }

                transactionsView.SetData(transactions);
                transactionsView.EnsureLastItemIsVisible();

                reportsButton.Enabled = transactions.Count() > 0;
                readTransactionsBit = false;
                //MessageBox.Show("Transactions updated");
            }
        }

        public void ShowAllTransactionsForAccount(DalAccount account) {
            foreach (object obj in transferLocationSelectionCombo.Items){
                if (obj is DalTransferLocation&&((DalTransferLocation) obj).Id == account.Id){
                    transferLocationSelectionCombo.SelectedItem = obj;
                }
            }
            timeIntervalSelectorControl.Interval = ETimeIntervals.ALL;
            RequestReadTransactions();
        }
    }
}
