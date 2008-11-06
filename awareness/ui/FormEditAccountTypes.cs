/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 01/09/2008
 * Time: 14:32
 * 
 */
using System;
using System.Linq;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    public partial class FormEditAccountTypes : Form
    {
        public FormEditAccountTypes()
        {
            InitializeComponent();
            ReadAccountTypes();
        }
        
        void ReadAccountTypes()
        {
            typeList.Items.Clear();
            
            IQueryable<DalAccountType> accountTypes = DbUtil.GetAccountTypes();
            foreach (DalAccountType type in accountTypes)
            {
                typeList.Items.Add(type);
            }
            
            EditControlsEnabled(false);
            ClearEditBoxes();
            if (typeList.Items.Count > 0)
            {
                typeList.SelectedIndex = 0;
            }
        }
        
        void TypeListSelectedIndexChanged(object sender, EventArgs e)
        {
            if (typeList.SelectedItem is DalAccountType)
            {
                DalAccountType at = (DalAccountType) typeList.SelectedItem;
                nameBox.Text = at.Name;
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
            deleteButton.Enabled = val;
            updateButton.Enabled = false;
        }

        void ClearEditBoxes()
        {
            nameBox.Text = "";
        }
        
        void NewButtonClick(object sender, EventArgs e)
        {
            DalAccountType at = new DalAccountType() { Name = "New Account Type" };
            DbUtil.InsertAccountType(at);
    	    ReadAccountTypes();
    	    typeList.SelectedItem = at;
      	    nameBox.Focus();
        }
        
        void UpdateButtonClick(object sender, EventArgs e)
        {
            DalAccountType accountType = (DalAccountType) typeList.SelectedItem;
    	    accountType.Name = nameBox.Text;
    	    DbUtil.UpdateAccountType(accountType);
    	    ReadAccountTypes();
        }
        
        void DeleteButtonClick(object sender, EventArgs e)
        {
            try
            {
                DbUtil.DeleteAccountType((DalAccountType) typeList.SelectedItem);
            }
            catch (Exception err)
            {
                MessageBox.Show("Could not delete account type:\n" + err.Message,
                                "Delete account type", 
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
        	    ReadAccountTypes();                	
            }
        }
        
        void NameBoxTextChanged(object sender, EventArgs e)
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
