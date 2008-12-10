/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 31/08/2008
 * Time: 18:09
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
    public partial class FormEditBudgetCategories : Form {
        public FormEditBudgetCategories(){
            InitializeComponent();
            ReadBudgetCategories();

            noteControl.NoteAdded += new NoteHandler(NoteUpdated);
            noteControl.NoteTextChanged += new NoteHandler(NoteUpdated);
            noteControl.NoteRemoved += new NoteHandler(NoteUpdated);
        }

        void ReadBudgetCategories(){
            categoriesList.Items.Clear();

            IQueryable<DalBudgetCategory> categories = DbUtil.GetBudgetCategories();

            foreach (DalBudgetCategory category in categories){
                categoriesList.Items.Add(category);
            }

            EditControlsEnabled(false);
            ClearEditBoxes();
            if (categoriesList.Items.Count > 0){
                categoriesList.SelectedIndex = 0;
            }
        }

        void CategoriesListSelectedIndexChanged(object sender, EventArgs e){
            if (categoriesList.SelectedItem is DalBudgetCategory){
                DalBudgetCategory bc = (DalBudgetCategory) categoriesList.SelectedItem;
                nameBox.Text = bc.Name;
                incomeButton.Checked = bc.IsIncome;
                expenseButton.Checked = !bc.IsIncome;
                if (DbUtil.IsTransferLocationUsed(bc)) {
                    incomeButton.Visible = bc.IsIncome;
                    expenseButton.Visible = !bc.IsIncome;
                } else {
                    incomeButton.Visible = true;
                    expenseButton.Visible = true;
                }
                noteControl.Note = bc.Note;
                EditControlsEnabled(true);
            } else {
                EditControlsEnabled(false);
                ClearEditBoxes();
            }
        }

        void EditControlsEnabled(bool val){
            nameLabel.Enabled = val;
            nameBox.Enabled = val;
            incomeButton.Enabled = val;
            expenseButton.Enabled = val;
            deleteButton.Enabled = val;
            updateButton.Enabled = false;
            noteControl.Enabled = val;
        }

        void ClearEditBoxes(){
            nameBox.Text = "";
            incomeButton.Checked = false;
            expenseButton.Checked = false;
        }

        void NewButtonClick(object sender, EventArgs e){
            DalBudgetCategory bc = new DalBudgetCategory() {
                Name = "_New Budget Category", IsIncome = false
            };
            DbUtil.InsertTransferLocation(bc, noteControl.Note);
            ReadBudgetCategories();
            categoriesList.SelectedItem = bc;
            nameBox.Focus();
        }

        void UpdateButtonClick(object sender, EventArgs e){
            DalBudgetCategory bc = (DalBudgetCategory) categoriesList.SelectedItem;
            bc.Name = nameBox.Text;
            bc.IsIncome = incomeButton.Checked;
            DbUtil.UpdateTransferLocation(bc, noteControl.Note);
            ReadBudgetCategories();
        }

        void DeleteButtonClick(object sender, EventArgs e){
            try {
                DbUtil.DeleteTransferLocation((DalBudgetCategory) categoriesList.SelectedItem);
            } catch (Exception err) {
                MessageBox.Show("Could not delete budget category:\n" + err.Message,
                                "Delete budget category",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ReadBudgetCategories();
            }
        }

        void NameBoxTextChanged(object sender, EventArgs e){
            updateButton.Enabled = true;
        }

        void IncomeButtonCheckedChanged(object sender, EventArgs e){
            updateButton.Enabled = true;
        }

        void ExpenseButtonCheckedChanged(object sender, EventArgs e){
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
    }
}
