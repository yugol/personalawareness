/*
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

/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 02/11/2008
 * Time: 19:36
 *
 */
using System;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    partial class ControlTransactions {
        enum EditModes { NEW, UPDATE }

        int editPanelNormalHeight;

        EditModes editMode;
        bool dirty;

        bool Dirty
        {
            get { return dirty; }
            set
            {
                switch (value){
                case true:
                    updateButton.Enabled = true;
                    break;
                case false:
                    errorProvider.Clear();
                    updateButton.Enabled = false;
                    break;
                }
                dirty = value;
            }
        }

        EditModes EditMode
        {
            get { return editMode; }
            set
            {
                switch (value){
                case EditModes.NEW:
                    transactionsView.SelectedTransaction = null;
                    recordButton.Text = "&Record";
                    deleteButton.Enabled = false;
                    ClearEditBoxes();
                    break;
                case EditModes.UPDATE:
                    recordButton.Text = "&New";
                    deleteButton.Enabled = true;
                    break;
                }
                editMode = value;
            }
        }

        public bool EditPanelExpanded
        {
            get { return (editLayoutLabel.ImageIndex == 0); }
            set
            {
                if (value){
                    editLayoutLabel.ImageIndex = 0;
                    editPanel.Height = editPanelNormalHeight;
                    foreach (Control c in editPanel.Controls){
                        c.Visible = true;
                    }
                } else {
                    editLayoutLabel.ImageIndex = 1;
                    editPanel.Height = editLayoutLabel.Height + editLayoutLabel.Margin.Top + 1;
                    foreach (Control c in editPanel.Controls){
                        if (!c.Equals(editLayoutLabel)){
                            c.Visible = false;
                        }
                    }
                }
            }
        }
        
        bool IsTransactionValid(){
            reasonCombo.Focus();
            ammountBox.Focus();
            fromCombo.Focus();
            toCombo.Focus();
            quantityBox.Focus();
            datePicker.Focus();

            string error = "";
            error += errorProvider.GetError(reasonCombo);
            error += errorProvider.GetError(ammountBox);
            error += errorProvider.GetError(fromCombo);
            error += errorProvider.GetError(toCombo);
            error += errorProvider.GetError(quantityBox);

            return string.IsNullOrEmpty(error);
        }

        void ClearEditBoxes(){
            reasonCombo.SelectedItem = null;
            ammountBox.Text = "";
            fromCombo.SelectedItem = null;
            toCombo.SelectedItem = null;
            quantityBox.Text = "0";
            memoBox.Text = null;

            Dirty = false;
        }

        void UiData2Transaction(ref DalTransaction transaction){
            float quantity = float.Parse(quantityBox.Text);
            transaction.When = datePicker.Value.Date;
            if (reasonCombo.SelectedItem != null){
                transaction.Reason = (DalReason) reasonCombo.SelectedItem;
            } else {
                int index = reasonCombo.FindStringExact(reasonCombo.Text);
                if (index >= 0){
                    transaction.Reason = (DalReason) reasonCombo.Items[index];
                } else {
                    // TODO: if quantity != 0 default is DalTrFood
                    DalReason reason = new DalReason() {
                        Name = "_" + reasonCombo.Text
                    };
                    DbUtil.InsertTransactionReason(reason);
                    transaction.Reason = reason;
                }
            }
            transaction.Ammount = decimal.Parse(ammountBox.Text);
            transaction.From = (DalTransferLocation) fromCombo.SelectedItem;
            transaction.To = (DalTransferLocation) toCombo.SelectedItem;
            transaction.Quantity = quantity;
            transaction.Memo = memoBox.Text;
        }

        void TransactionData2Ui(DalTransaction transaction){
            datePicker.Value = transaction.When;
            reasonCombo.SelectedItem = transaction.Reason;
            ammountBox.Text = transaction.Ammount.ToString("0.00");
            fromCombo.SelectedItem = transaction.From;
            toCombo.SelectedItem = transaction.To;
            quantityBox.Text = transaction.Quantity.ToString();
            memoBox.Text = transaction.Memo;

            Dirty = false;
        }

        void TransactionsViewSelectedIndexChanged(object sender, EventArgs e){
            DalTransaction transaction = transactionsView.SelectedTransaction;
            if (transaction != null){
                EditMode = EditModes.UPDATE;
                TransactionData2Ui(transaction);
            } else {
                EditMode = EditModes.NEW;
            }
        }
    }
}
