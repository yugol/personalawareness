/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 31/08/2008
 * Time: 18:09
 * 
 */
using System;
using System.Linq;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    public partial class FormEditBudgetCategories : Form
    {
        // TODO: budget categories types (Income / Expense) cannot be changed once that a transaction using it exists
        
        public FormEditBudgetCategories()
        {
            InitializeComponent();
            ReadBudgetCategories();
        }
        
        void ReadBudgetCategories()
        {
            categoriesList.Items.Clear();

            IQueryable<DalBudgetCategory> categories = DbUtil.GetBudgetCategories();

            foreach(DalBudgetCategory category in categories)
            {
                categoriesList.Items.Add(category);
            }
            
            EditControlsEnabled(false);
            ClearEditBoxes();
            if (categoriesList.Items.Count > 0)
            {
                categoriesList.SelectedIndex = 0;
            }
        }
        
        void CategoriesListSelectedIndexChanged(object sender, EventArgs e)
        {
            if (categoriesList.SelectedItem is DalBudgetCategory)
            {
                DalBudgetCategory bc = (DalBudgetCategory) categoriesList.SelectedItem;
                nameBox.Text = bc.Name;
                incomeButton.Checked = bc.IsIncome;
                expenseButton.Checked = !bc.IsIncome;
                EditControlsEnabled(true);
            }
            else
            {
                EditControlsEnabled(false);
                ClearEditBoxes();
            }
        }
        
        void EditControlsEnabled(bool val)
        {
            nameLabel.Enabled = val;
            nameBox.Enabled = val;
            incomeButton.Enabled = val;
            expenseButton.Enabled = val;
            deleteButton.Enabled = val;
            updateButton.Enabled = false;
        }
        
        void ClearEditBoxes()
        {
            nameBox.Text = "";
            incomeButton.Checked = false;
            expenseButton.Checked = false;
        }
        
        void NewButtonClick(object sender, EventArgs e)
        {
            DalBudgetCategory bc = new DalBudgetCategory() {Name = "_New Budget Category", IsIncome = false};
            DbUtil.InsertTransferLocation(bc);
            ReadBudgetCategories();
            categoriesList.SelectedItem = bc;
            nameBox.Focus();
        }
        
        void UpdateButtonClick(object sender, EventArgs e)
        {
            DalBudgetCategory bc = (DalBudgetCategory) categoriesList.SelectedItem;
            bc.Name = nameBox.Text;
            bc.IsIncome = incomeButton.Checked;
            DbUtil.UpdateTransferLocation(bc);
            ReadBudgetCategories();
        }

        void DeleteButtonClick(object sender, EventArgs e)
        {
            try
            {
                DbUtil.DeleteTransferLocation((DalBudgetCategory) categoriesList.SelectedItem);
            }
            catch (Exception err)
            {
                MessageBox.Show("Could not delete budget category:\n" + err.Message,
                                "Delete budget category",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ReadBudgetCategories();
            }
        }
        
        void NameBoxTextChanged(object sender, EventArgs e)
        {
            updateButton.Enabled = true;
        }
        
        void IncomeButtonCheckedChanged(object sender, EventArgs e)
        {
            updateButton.Enabled = true;
        }
        
        void ExpenseButtonCheckedChanged(object sender, EventArgs e)
        {
            updateButton.Enabled = true;
        }
        
        void NameBoxValidating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(nameBox.Text))
            {
                e.Cancel = true;
                errorProvider.SetError((Control) sender, "Please enter a name");
            }
            else
            {
                errorProvider.Clear();
            }
        }
    }
}
