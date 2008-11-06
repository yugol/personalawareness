/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 11/09/2008
 * Time: 11:28
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    public partial class ControlFinances : UserControl
    {
        public ControlFinances()
        {
            InitializeComponent();
            
            DbUtil.DataContextChanged += new DatabaseChangedHandler(UpdateBalances);
            DbUtil.AccountTypesChanged += new DatabaseChangedHandler(UpdateBalances);
            DbUtil.AccountsChanged += new DatabaseChangedHandler(UpdateBalances);
            DbUtil.TransactionsChanged += new DatabaseChangedHandler(UpdateBalances);
        }
        
        void UpdateBalances()
        {
            accountsBalanceView.Items.Clear();

            IDictionary<DalAccountType, decimal> accountTypeBalanceMap = new Dictionary<DalAccountType, decimal>();
            IDictionary<DalAccount, decimal> accountBalanceMap = new Dictionary<DalAccount, decimal>();
            
            IQueryable<DalAccountType> accountTypes = DbUtil.GetAccountTypes();
            foreach (DalAccountType accountType in accountTypes)
            {
                accountTypeBalanceMap[accountType] = 0;
            }
            
            decimal netWorth = 0;
            IQueryable<DalAccount> accounts = DbUtil.GetAccounts();
            foreach (DalAccount account in accounts)
            {
                accountBalanceMap[account] = DbUtil.GetBalance(account);
                accountTypeBalanceMap[account.AccountType] += accountBalanceMap[account];
                netWorth += accountBalanceMap[account];
            }

            bool useAlternateBackground = false;
            foreach (DalAccountType accountType in accountTypes)
            {
                ListViewItem typeNode = new ListViewItem(accountType.Name);
                typeNode.SubItems.Add(UiUtil.FormatCurrency(accountTypeBalanceMap[accountType]));
                typeNode.Font = Configuration.BOLD_FONT;
                typeNode.BackColor = useAlternateBackground ? Configuration.ALTERNATE_BACKGROUND : Configuration.NORMAL_BACKGROUND;
                useAlternateBackground = !useAlternateBackground;
                accountsBalanceView.Items.Add(typeNode);

                foreach (DalAccount account in accounts)
                {
                    if (account.AccountTypeId == accountType.Id)
                    {
                        ListViewItem accountNode = new ListViewItem("      " + account.Name);
                        accountNode.SubItems.Add(UiUtil.FormatCurrency(accountBalanceMap[account]));
                        accountNode.BackColor = useAlternateBackground ? Configuration.ALTERNATE_BACKGROUND : Configuration.NORMAL_BACKGROUND;
                        useAlternateBackground = !useAlternateBackground;
                        accountsBalanceView.Items.Add(accountNode);
                    }
                }
            }

            netWorthValueLabel.Text = UiUtil.FormatCurrency(netWorth);
        }
        
    }
}
