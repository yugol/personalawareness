/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 05/09/2008
 * Time: 13:43
 * 
 */
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    public partial class FormManageTransactions : Form
    {
        // TODO: cash last accounts into application
        // FIXME: Ficat de pui (new product) solved as old Ficat
        
        DalTransferLocation selectedTransferLocation = null;
        string reasonSelectionPattern = null;
        IQueryable<DalTransaction> transactions = null;

        public FormManageTransactions()
        {
            InitializeComponent();
            
            fromCombo.DropDownHeight = 250;
            toCombo.DropDownHeight = 250;
            
            timeIntervalSelectorControl.Interval = Intervals.THIS_QUARTER;
            selectPanelNormalHeight = selectPanel.Height;
            editPanelNormalHeight = editPanel.Height;
            transactionsView.SelectedIndexChanged += new EventHandler(TransactionsViewSelectedIndexChanged);
            timeIntervalSelectorControl.TimeIntervalChanged += new DatabaseChangedHandler(ReadTransactions);
            EditMode = EditModes.NEW;
        }
        
        void ReadTransferLocations()
        {
            fromCombo.Items.Clear();
            toCombo.Items.Clear();

            IQueryable<DalAccount> accounts = DbUtil.GetAccounts();
            IQueryable<DalBudgetCategory> budgetCategories = DbUtil.GetBudgetCategories();
            IQueryable<DalBudgetCategory> incomes = budgetCategories.Where(bc => bc.IsIncome);
            IQueryable<DalBudgetCategory> expenses = budgetCategories.Where(bc => !bc.IsIncome);
            
            fromCombo.Items.Add("---Accounts---");
            foreach (DalTransferLocation item in accounts)
            {
                fromCombo.Items.Add(item);
            }
            fromCombo.Items.Add("");
            fromCombo.Items.Add("---Budget categories---");
            foreach (DalBudgetCategory item in incomes)
            {
                fromCombo.Items.Add(item);
            }

            toCombo.Items.Add("---Accounts---");
            foreach (DalTransferLocation item in accounts)
            {
                toCombo.Items.Add(item);
            }
            toCombo.Items.Add("");
            toCombo.Items.Add("---Budget categories---");
            foreach (DalBudgetCategory item in expenses)
            {
                toCombo.Items.Add(item);
            }
            
            transferLocationSelectionCombo.Items.Clear();
            transferLocationSelectionCombo.Items.Add("(All)");
            foreach (DalBudgetCategory item in expenses)
            {
                transferLocationSelectionCombo.Items.Add(item);
            }
            foreach (DalBudgetCategory item in incomes)
            {
                transferLocationSelectionCombo.Items.Add(item);
            }
            foreach (DalTransferLocation item in accounts)
            {
                transferLocationSelectionCombo.Items.Add(item);
            }
        }
        
        void ReadTransactionReasons()
        {
            reasonCombo.Items.Clear();
            IQueryable<DalReason> reasons = DbUtil.GetTransferReasons();
            foreach (DalReason reason in reasons)
            {
                reasonCombo.Items.Add(reason);
            }
        }
        
        void ReadTransactions()
        {
            transactions = DbUtil.GetTransactions(timeIntervalSelectorControl.First, timeIntervalSelectorControl.Last);
            if (selectedTransferLocation != null)
            {
                transactions = transactions.Where(t => (t.FromId == selectedTransferLocation.Id) || (t.ToId == selectedTransferLocation.Id));
            }
            if (reasonSelectionPattern != null)
            {
                transactions = transactions.Where(t => t.Reason.Name.Contains(reasonSelectionPattern));
            }
            
            transactionsView.SetData(transactions);
            
            reportsButton.Enabled = transactions.Count() > 0;
        }
        
        void FormManageTransactionsShown(object sender, EventArgs e)
        {
            ReadTransferLocations();
            ReadTransactionReasons();
            ReadTransactions();
        }
        
    }
}