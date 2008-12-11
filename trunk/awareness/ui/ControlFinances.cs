/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 11/09/2008
 * Time: 11:28
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Awareness.DB;

namespace Awareness.UI
{
    public delegate void AccountDoubleClickHandler(DalAccount account);

    public partial class ControlFinances : UserControl {
        bool updateBalancesBit = true;
        bool isDisplayed = false;

        public event AccountDoubleClickHandler AccountDoubleClick;

        public bool IsDisplayed {
            get { return isDisplayed; }
            set {
                isDisplayed = value;
                UpdateBalances();
            }
        }

        public ControlFinances(){
            InitializeComponent();

            DBUtil.DataContextChanged += new DatabaseChangedHandler(RequestUpdateBalances);
            DBUtil.AccountTypesChanged += new DatabaseChangedHandler(RequestUpdateBalances);
            DBUtil.AccountsChanged += new DatabaseChangedHandler(RequestUpdateBalances);
            DBUtil.TransactionsChanged += new DatabaseChangedHandler(RequestUpdateBalances);
            DBUtil.PropertiesChanged += new DatabaseChangedHandler(RequestUpdateBalances);
        }

        void RequestUpdateBalances() {
            updateBalancesBit = true;
            UpdateBalances();
        }

        void UpdateBalances(){
            if (isDisplayed&&updateBalancesBit){
                accountsBalanceView.Items.Clear();

                IDictionary<DalAccountType, decimal> accountTypeBalanceMap = new Dictionary<DalAccountType, decimal>();
                IDictionary<DalAccount, decimal> accountBalanceMap = new Dictionary<DalAccount, decimal>();

                IQueryable<DalAccountType> accountTypes = DBUtil.GetAccountTypes();
                foreach (DalAccountType accountType in accountTypes){
                    accountTypeBalanceMap[accountType] = 0;
                }

                decimal netWorth = 0;
                IQueryable<DalAccount> accounts = DBUtil.GetAccounts();
                foreach (DalAccount account in accounts){
                    accountBalanceMap[account] = DBUtil.GetBalance(account);
                    accountTypeBalanceMap[account.AccountType] += accountBalanceMap[account];
                    netWorth += accountBalanceMap[account];
                }

                bool useAlternateBackground = false;
                foreach (DalAccountType accountType in accountTypes){
                    ListViewItem typeNode = new ListViewItem(accountType.Name);
                    typeNode.SubItems.Add(Util.FormatCurrency(accountTypeBalanceMap[accountType]));
                    typeNode.Font = Configuration.BOLD_FONT;
                    typeNode.BackColor = useAlternateBackground ? Configuration.ALTERNATE_BACKGROUND : Configuration.NORMAL_BACKGROUND;
                    useAlternateBackground = !useAlternateBackground;
                    accountsBalanceView.Items.Add(typeNode);

                    foreach (DalAccount account in accounts){
                        if (account.AccountTypeId == accountType.Id){
                            ListViewItem accountNode = new ListViewItem("      " + account.Name);
                            accountNode.SubItems.Add(Util.FormatCurrency(accountBalanceMap[account]));
                            accountNode.BackColor = useAlternateBackground ? Configuration.ALTERNATE_BACKGROUND : Configuration.NORMAL_BACKGROUND;
                            useAlternateBackground = !useAlternateBackground;
                            accountNode.Tag = account;
                            accountsBalanceView.Items.Add(accountNode);
                        }
                    }
                }
                netWorthValueLabel.Text = Util.FormatCurrency(netWorth);
                updateBalancesBit = false;
            }
        }

        void AccountsBalanceViewDoubleClick(object sender, EventArgs e){
            if (accountsBalanceView.SelectedItems.Count > 0){
                if (accountsBalanceView.SelectedItems[0].Tag is DalAccount){
                    DalAccount account = (DalAccount) accountsBalanceView.SelectedItems[0].Tag;
                    if (AccountDoubleClick != null){
                        AccountDoubleClick(account);
                    }
                }
            }
        }
    }
}
