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
using System.ComponentModel;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    partial class ControlTransactions {
        #region Layout

        int editPanelNormalHeight;

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

        void EditLayoutLabelClick(object sender, EventArgs e){
            EditPanelExpanded = !EditPanelExpanded;
        }

        #endregion

        #region Dirty flag

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

        #endregion

        #region Edit mode

        enum EEditModes { NEW, UPDATE }

        EEditModes editMode;

        EEditModes EditMode
        {
            get { return editMode; }
            set
            {
                switch (value) {
                case EEditModes.NEW:
                    transactionsView.SelectedTransaction = null;
                    recordButton.Text = "&Record";
                    deleteButton.Enabled = false;
                    ClearEditBoxes();
                    break;
                case EEditModes.UPDATE:
                    recordButton.Text = "&New";
                    deleteButton.Enabled = true;
                    break;
                }
                editMode = value;
            }
        }

        #endregion

        #region Edit events

        void DatePickerValueChanged(object sender, EventArgs e){
            if (EditMode == EEditModes.UPDATE){
                Dirty = true;
            }
        }

        void ReasonComboTextChanged(object sender, EventArgs e){
            if (EditMode == EEditModes.UPDATE){
                Dirty = true;
            }
        }

        void FromComboSelectedIndexChanged(object sender, EventArgs e){
            if (fromCombo.SelectedItem is DalTransferLocation){
                if (EditMode == EEditModes.UPDATE){
                    Dirty = true;
                }
            } else {
                fromCombo.SelectedItem = null;
            }
        }

        void ToComboSelectedIndexChanged(object sender, EventArgs e){
            if (toCombo.SelectedItem is DalTransferLocation){
                if (EditMode == EEditModes.UPDATE){
                    Dirty = true;
                }
            } else {
                toCombo.SelectedItem = null;
            }
        }

        void QuantityInputValueChanged(object sender, EventArgs e){
            if (EditMode == EEditModes.UPDATE){
                Dirty = true;
            }
        }

        void MemoBoxTextChanged(object sender, EventArgs e){
            if (EditMode == EEditModes.UPDATE){
                Dirty = true;
            }
        }

        void AmmountBoxTextChanged(object sender, EventArgs e){
            if (EditMode == EEditModes.UPDATE){
                Dirty = true;
            }
        }

        void NoteControlNoteAdded(object sender, DalNote note){
            if (EditMode == EEditModes.UPDATE){
                Dirty = true;
            }
        }

        void NoteControlNoteRemoved(object sender, DalNote note){
            if (EditMode == EEditModes.UPDATE){
                Dirty = true;
            }
        }

        void NoteControlNoteTextChanged(object sender, DalNote note){
            if (EditMode == EEditModes.UPDATE){
                Dirty = true;
            }
        }

        #endregion

        #region Validation

        private bool performValidation = false;

        bool IsTransactionValid(){
            performValidation = true;

            reasonCombo.Focus();
            ammountBox.Focus();
            fromCombo.Focus();
            toCombo.Focus();
            quantityInput.Focus();
            datePicker.Focus();

            string error = "";
            error += errorProvider.GetError(reasonCombo);
            error += errorProvider.GetError(ammountBox);
            error += errorProvider.GetError(fromCombo);
            error += errorProvider.GetError(toCombo);
            error += errorProvider.GetError(quantityInput);

            performValidation = false;

            return string.IsNullOrEmpty(error);
        }

        void ReasonComboValidating(object sender, CancelEventArgs e){
            if (performValidation){
                if (string.IsNullOrEmpty(reasonCombo.Text)){
                    e.Cancel = true;
                    errorProvider.SetError((Control) sender, "Please enter a reason");
                } else {
                    errorProvider.Clear();
                }
            }
        }

        void FromComboValidating(object sender, CancelEventArgs e){
            if (performValidation){
                if (fromCombo.SelectedIndex < 0){
                    e.Cancel = true;
                    errorProvider.SetError((Control) sender, "Please select a source");
                } else {
                    errorProvider.Clear();
                }
            }
        }

        void ToComboValidating(object sender, CancelEventArgs e){
            if (performValidation){
                if (toCombo.SelectedIndex < 0){
                    e.Cancel = true;
                    errorProvider.SetError((Control) sender, "Please select a destinantion");
                } else {
                    errorProvider.Clear();
                }
            }
        }

        void QuantityInputValidating(object sender, CancelEventArgs e){
            if (performValidation){
                if (quantityInput.Value < 0){
                    e.Cancel = true;
                    errorProvider.SetError((Control) sender, "Please enter a positive integer value");
                } else {
                    errorProvider.Clear();
                }
            }
        }

        void AmmountBoxValidating(object sender, CancelEventArgs e){
            if (performValidation){
                try {
                    if (decimal.Parse(ammountBox.Text) <= 0){
                        throw new ApplicationException();
                    }
                    errorProvider.Clear();
                } catch (Exception) {
                    e.Cancel = true;
                    errorProvider.SetError((Control) sender, "Please enter a decimal value grater than 0");
                }
            }
        }

        #endregion

        #region CRUD

        void ClearEditBoxes(){
            reasonCombo.SelectedItem = null;
            ammountBox.Text = "";
            fromCombo.SelectedItem = null;
            toCombo.SelectedItem = null;
            quantityInput.Value = 0;
            noteControl.Note = null;

            Dirty = false;
        }

        DalReason CreateReasonFromUi() {
            DalReason reason = null;
            float quantity = (int) quantityInput.Value;
            if (quantity != 0){
                reason = new DalFood();
            } else {
                reason = new DalReason();
            }
            reason.Name = "_" + reasonCombo.Text;
            DbUtil.InsertTransactionReason(reason);
            return reason;
        }

        void UiData2Transaction(ref DalTransaction transaction){
            transaction.When = datePicker.Value.Date;
            if (reasonCombo.SelectedItem != null){
                transaction.Reason = (DalReason) reasonCombo.SelectedItem;
            } else {
                int index = reasonCombo.FindStringExact(reasonCombo.Text);
                if (index >= 0){
                    transaction.Reason = (DalReason) reasonCombo.Items[index];
                } else {
                    transaction.Reason = CreateReasonFromUi();
                }
            }
            transaction.Ammount = decimal.Parse(ammountBox.Text);
            transaction.From = (DalTransferLocation) fromCombo.SelectedItem;
            transaction.To = (DalTransferLocation) toCombo.SelectedItem;
            transaction.Quantity = (int) quantityInput.Value;
            
            transaction.Reason.Ammount = transaction.Ammount;
            transaction.Reason.FromId = transaction.FromId;
            transaction.Reason.ToId = transaction.ToId;
            transaction.Reason.Quantity = transaction.Quantity;
        }

        void ReasonComboSelectedIndexChanged(object sender, EventArgs e){
            if (reasonCombo.SelectedItem is DalReason){
                DalReason reason = (DalReason) reasonCombo.SelectedItem;
                ammountBox.Text = reason.Ammount.ToString("0.00");
                foreach (object obj in fromCombo.Items){
                    if (obj is DalTransferLocation){
                        if (((DalTransferLocation) obj).Id == reason.FromId){
                            fromCombo.SelectedItem = obj;
                        }
                    }
                }
                foreach (object obj in toCombo.Items){
                    if (obj is DalTransferLocation){
                        if (((DalTransferLocation) obj).Id == reason.ToId){
                            toCombo.SelectedItem = obj;
                        }
                    }
                }
                quantityInput.Value = reason.Quantity;
            }
        }

        void TransactionData2Ui(DalTransaction transaction){
            datePicker.Value = transaction.When;
            reasonCombo.SelectedItem = transaction.Reason;
            ammountBox.Text = transaction.Ammount.ToString("0.00");
            fromCombo.SelectedItem = transaction.From;
            toCombo.SelectedItem = transaction.To;
            quantityInput.Value = transaction.Quantity;
            noteControl.Note = transaction.HasNote ? transaction.Note : null;

            Dirty = false;
        }

        void TransactionsViewSelectedIndexChanged(object sender, EventArgs e){
            DalTransaction transaction = transactionsView.SelectedTransaction;
            if (transaction != null){
                EditMode = EEditModes.UPDATE;
                TransactionData2Ui(transaction);
            } else {
                EditMode = EEditModes.NEW;
            }
        }

        void RecordButtonClick(object sender, EventArgs e){
            switch (EditMode){
            case EEditModes.NEW:
                if (IsTransactionValid()){
                    DalTransaction transaction = new DalTransaction();
                    UiData2Transaction(ref transaction);
                    DbUtil.InsertTransaction(transaction, noteControl.Note);
                    RequestReadTransactions();
                    ClearEditBoxes();
                }
                break;
            case EEditModes.UPDATE:
                EditMode = EEditModes.NEW;
                ClearEditBoxes();
                break;
            }
        }

        void UpdateButtonClick(object sender, EventArgs e){
            if (IsTransactionValid()){
                DalTransaction transaction = transactionsView.SelectedTransaction;
                UiData2Transaction(ref transaction);
                DbUtil.UpdateTransaction(transaction, noteControl.Note);
                RequestReadTransactions();
                transactionsView.SelectedTransaction = transaction;
            }
        }

        void DeleteButtonClick(object sender, EventArgs e){
            DbUtil.DeleteTransaction(transactionsView.SelectedTransaction);
            RequestReadTransactions();
            EditMode = EEditModes.NEW;
        }

        #endregion
    }
}
