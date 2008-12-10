/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 01/09/2008
 * Time: 16:58
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
using System.Linq;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    public partial class FormEditAccounts : Form {
        IQueryable<DalAccountType> accountTypes = null;
        DatabaseChangedHandler dataContextChangedDelegete = null;

        public FormEditAccounts(){
            InitializeComponent();
            dataContextChangedDelegete = new DatabaseChangedHandler(ReadAccountTypes);
            DbUtil.DataContextChanged += dataContextChangedDelegete;

            noteControl.NoteAdded += new NoteHandler(NoteUpdated);
            noteControl.NoteTextChanged += new NoteHandler(NoteUpdated);
            noteControl.NoteRemoved += new NoteHandler(NoteUpdated);
        }

        void FormEditAccountsLoad(object sender, EventArgs e){
            ReadAccountTypes();
            ReadAccounts();
        }

        void ReadAccountTypes(){
            typeCombo.Items.Clear();
            accountTypes = DbUtil.GetAccountTypes();
            if (accountTypes.Count() <= 0){
                throw new ApplicationException("No account types defined!");
            }
            foreach (DalAccountType at in accountTypes){
                typeCombo.Items.Add(at);
            }
            typeCombo.SelectedIndex = 0;
        }

        void ReadAccounts(){
            accountsView.Nodes.Clear();

            IQueryable<DalAccount> accounts = DbUtil.GetAccounts();

            TreeNode firstAccountNode = null;
            foreach (DalAccountType accountType in accountTypes){
                TreeNode typeNode = null;
                foreach (DalAccount account in accounts){
                    if (account.AccountTypeId == accountType.Id){
                        if (typeNode == null){
                            typeNode = new TreeNode(accountType.Name);
                            typeNode.Tag = accountType;
                            accountsView.Nodes.Add(typeNode);
                        }
                        TreeNode accountNode = new TreeNode(account.Name);
                        accountNode.Tag = account;
                        typeNode.Nodes.Add(accountNode);
                        if (firstAccountNode == null){
                            firstAccountNode = accountNode;
                        }
                    }
                }
            }
            accountsView.ExpandAll();

            EditControlsEnabled(false);
            ClearEditBoxes();
            if (firstAccountNode != null){
                accountsView.SelectedNode = firstAccountNode;
                UpdateUi();
            }
        }

        void UpdateUi(){
            if (accountsView.SelectedNode != null&&accountsView.SelectedNode.Tag is DalAccount){
                DalAccount a = (DalAccount) accountsView.SelectedNode.Tag;
                nameBox.Text = a.Name;
                typeCombo.SelectedItem = a.AccountType;
                startingBalanceBox.Text = a.StartingBalance.ToString("0.00");
                noteControl.Note = a.Note;
                EditControlsEnabled(true);
            } else {
                ClearEditBoxes();
                if (accountsView.SelectedNode != null&&accountsView.SelectedNode.Tag is DalAccountType){
                    DalAccountType at = (DalAccountType) accountsView.SelectedNode.Tag;
                    typeCombo.SelectedItem = at;
                }
                EditControlsEnabled(false);
            }
        }

        void EditControlsEnabled(bool val){
            nameLabel.Enabled = val;
            nameBox.Enabled = val;
            typeLabel.Enabled = val;
            typeCombo.Enabled = val;
            startingBalanceLabel.Enabled = val;
            startingBalanceBox.Enabled = val;
            deleteButton.Enabled = val;
            updateButton.Enabled = false;
            noteControl.Enabled = val;
        }

        void ClearEditBoxes(){
            nameBox.Text = "";
            startingBalanceBox.Text = "";
        }

        void NewButtonClick(object sender, EventArgs e){
            DalAccount account = new DalAccount() {
                Name = "_New Account", StartingBalance = 0m, AccountType = (DalAccountType) typeCombo.SelectedItem
            };
            DbUtil.InsertTransferLocation(account, noteControl.Note);
            ReadAccounts();
            SelectNodeWithTag(account);
            UpdateUi();
            nameBox.Focus();
        }

        void SelectNodeWithTag(DalAccount account){
            foreach (TreeNode typeNode in accountsView.Nodes){
                foreach (TreeNode accountNode in typeNode.Nodes){
                    if (accountNode.Tag.Equals(account)){
                        accountsView.SelectedNode = accountNode;
                        return;
                    }
                }
            }
        }

        void UpdateButtonClick(object sender, EventArgs e){
            DalAccount account = (DalAccount) accountsView.SelectedNode.Tag;
            account.Name = nameBox.Text;
            account.AccountType = (DalAccountType) typeCombo.SelectedItem;
            account.StartingBalance = decimal.Parse(startingBalanceBox.Text);
            DbUtil.UpdateTransferLocation(account, noteControl.Note);
            ReadAccounts();
        }

        void DeleteButtonClick(object sender, EventArgs e){
            try {
                DbUtil.DeleteTransferLocation((DalAccount) accountsView.SelectedNode.Tag);
            } catch (Exception err) {
                MessageBox.Show("Could not delete account:\n" + err.Message,
                                "Delete account",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                ReadAccountTypes();
            }
            finally
            {
                ReadAccounts();
            }
        }

        void NameBoxTextChanged(object sender, EventArgs e){
            updateButton.Enabled = true;
        }

        void TypeComboSelectedIndexChanged(object sender, EventArgs e){
            updateButton.Enabled = true;
        }

        void StartingBalanceBoxTextChanged(object sender, EventArgs e){
            updateButton.Enabled = true;
        }

        void NoteUpdated(object sender, DalNote note) {
            updateButton.Enabled = true;
        }

        void NameBoxValidating(object sender, System.ComponentModel.CancelEventArgs e){
            if (string.IsNullOrEmpty(nameBox.Text.Trim())){
                e.Cancel = true;
                errorProvider.SetError((Control) sender, "Please enter a name");
            } else {
                errorProvider.Clear();
            }
        }

        void StartingBalanceBoxValidating(object sender, System.ComponentModel.CancelEventArgs e){
            try {
                errorProvider.Clear();
                decimal.Parse(startingBalanceBox.Text);
            } catch (Exception) {
                e.Cancel = true;
                errorProvider.SetError((Control) sender, "Please enter a decimal value");
            }
        }

        void FormEditAccountsFormClosed(object sender, FormClosedEventArgs e){
            DbUtil.DataContextChanged -= dataContextChangedDelegete;
        }

        void AccountsViewAfterSelect(object sender, TreeViewEventArgs e){
            UpdateUi();
        }
    }
}
