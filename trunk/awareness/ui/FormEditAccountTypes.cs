/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 01/09/2008
 * Time: 14:32
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
    public partial class FormEditAccountTypes : Form {
        public FormEditAccountTypes(){
            InitializeComponent();
            ReadAccountTypes();

            noteControl.NoteAdded += new NoteHandler(NoteUpdated);
            noteControl.NoteTextChanged += new NoteHandler(NoteUpdated);
            noteControl.NoteRemoved += new NoteHandler(NoteUpdated);
        }

        void ReadAccountTypes(){
            typeList.Items.Clear();

            IQueryable<DalAccountType> accountTypes = DbUtil.GetAccountTypes();
            foreach (DalAccountType type in accountTypes){
                typeList.Items.Add(type);
            }

            EditControlsEnabled(false);
            ClearEditBoxes();
            if (typeList.Items.Count > 0){
                typeList.SelectedIndex = 0;
            }
        }

        void TypeListSelectedIndexChanged(object sender, EventArgs e){
            if (typeList.SelectedItem is DalAccountType){
                DalAccountType at = (DalAccountType) typeList.SelectedItem;
                nameBox.Text = at.Name;
                noteControl.Note = at.Note;
                EditControlsEnabled(true);
            } else {
                EditControlsEnabled(false);
                ClearEditBoxes();
            }
        }

        void EditControlsEnabled(bool val){
            nameLabel.Enabled = val;
            nameBox.Enabled = val;
            deleteButton.Enabled = val;
            updateButton.Enabled = false;
            noteControl.Enabled = val;
        }

        void ClearEditBoxes(){
            nameBox.Text = "";
        }

        void NewButtonClick(object sender, EventArgs e){
            DalAccountType at = new DalAccountType() {
                Name = "New Account Type"
            };
            DbUtil.InsertAccountType(at, noteControl.Note);
            ReadAccountTypes();
            typeList.SelectedItem = at;
            nameBox.Focus();
        }

        void UpdateButtonClick(object sender, EventArgs e){
            DalAccountType accountType = (DalAccountType) typeList.SelectedItem;
            accountType.Name = nameBox.Text;
            DbUtil.UpdateAccountType(accountType, noteControl.Note);
            ReadAccountTypes();
        }

        void DeleteButtonClick(object sender, EventArgs e){
            try {
                DbUtil.DeleteAccountType((DalAccountType) typeList.SelectedItem);
            } catch (Exception err)  {
                MessageBox.Show("Could not delete account type:\n" + err.Message,
                                "Delete account type",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ReadAccountTypes();
            }
        }

        void NameBoxTextChanged(object sender, EventArgs e){
            updateButton.Enabled = true;
        }

        void NameBoxValidating(object sender, System.ComponentModel.CancelEventArgs e){
            if (string.IsNullOrEmpty(nameBox.Text)){
                e.Cancel = true;
                errorProvider.SetError((Control) sender, "Please enter a name");
            } else {
                errorProvider.Clear();
            }
        }

        void NoteUpdated(object sender, DalNote note) {
            updateButton.Enabled = true;
        }
    }
}
