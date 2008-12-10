/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 05/09/2008
 * Time: 09:00
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
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    public partial class FormEditTransactionReasons : Form {
        private DalReason lastSelectedReason;

        public FormEditTransactionReasons(){
            InitializeComponent();

            noteControl.NoteAdded += new NoteHandler(NoteUpdated);
            noteControl.NoteTextChanged += new NoteHandler(NoteUpdated);
            noteControl.NoteRemoved += new NoteHandler(NoteUpdated);

            energyMeasureUnitLabel.Text = string.Format("({0}):", Configuration.FOOD_ENERGY_MEASURE_UNIT);

            selectedTypeCombo.Items.Add("All");
            foreach (NamingReasonTypes typeName in NamingReasonTypes.GetNames()){
                typeCombo.Items.Add(typeName);
                selectedTypeCombo.Items.Add(typeName);
            }
            selectedTypeCombo.SelectedIndex = 0; // calls ReadTransactionReasons()
        }

        void ReadReasons(){
            // get reasons from db
            sbyte reasonType = GetTypeForCombo(selectedTypeCombo);
            AwarenessDataContext dc = DbUtil.GetDataContext();
            IEnumerable<DalReason> reasons = null;
            if (reasonType < 0){
                reasons = from t in dc.transactionReasons
                          orderby t.Name
                          select t;
            } else {
                reasons = from t in dc.transactionReasons
                          where t.Type == reasonType
                          orderby t.Name
                          select t;
            }

            // fill reason list
            reasonCombo.Text = string.Empty;
            reasonCombo.Items.Clear();
            foreach (DalReason reason in reasons){
                reasonCombo.Items.Add(reason);
            }

            // set-up interface
            ShowControlsForType(reasonType);
            EnableControls(false);
            ClearEditBoxes();
            lastSelectedReason = null;
            Dirty = false;
        }

        #region Edit events

        void SelectedTypeComboSelectedIndexChanged(object sender, EventArgs e){
            ReadReasons();
        }

        void ReasonComboTextChanged(object sender, EventArgs e){
            if (string.IsNullOrEmpty(reasonCombo.Text)){
                newButton.Enabled = false;
                Dirty = false;
            } else {
                newButton.Enabled = true;
                Dirty = lastSelectedReason != null;
            }
        }

        void ReasonComboSelectedIndexChanged(object sender, EventArgs e){
            if (reasonCombo.SelectedItem is DalReason){
                lastSelectedReason = (DalReason) reasonCombo.SelectedItem;
                foreach (NamingReasonTypes typeName in NamingReasonTypes.GetNames()){
                    if (typeName.Type == lastSelectedReason.Type){
                        typeCombo.SelectedItem = typeName;
                        break;
                    }
                }
                if (lastSelectedReason is DalFood){
                    energyBox.Text = ((DalFood) lastSelectedReason).Energy.ToString();
                }
                noteControl.Note = lastSelectedReason.Note;
                ShowControlsForType(lastSelectedReason.Type);
                EnableControls(true);
            } else {
                EnableControls(false);
                ClearEditBoxes();
            }
            Dirty = false;
        }

        void TypeComboSelectedIndexChanged(object sender, EventArgs e){
            ShowControlsForType(((NamingReasonTypes) typeCombo.SelectedItem).Type);
            Dirty = true;
        }

        void EnergyBoxTextChanged(object sender, EventArgs e){
            Dirty = true;
        }

        void LastMealButtonClick(object sender, EventArgs e){
            float energy = DbUtil.GetLastEnergyForRecipe((DalRecipe) lastSelectedReason);
            energyBox.Text = energy.ToString("0.00");
        }

        void Button1Click(object sender, EventArgs e){
            float energy = DbUtil.GetAverageEnergyForRecipe((DalRecipe) lastSelectedReason);
            energyBox.Text = energy.ToString("0.00");
        }

        void NoteUpdated(object sender, DalNote note) {
            Dirty = true;
        }

        #endregion

        #region Validation

        void EnergyBoxValidating(object sender, System.ComponentModel.CancelEventArgs e){
            try {
                float val = float.Parse(energyBox.Text);
                if (val < 0){
                    throw new Exception();
                }
                errorProvider.Clear();
            } catch (Exception) {
                e.Cancel = true;
                errorProvider.SetError((Control) sender, "Please enter a positive real value");
            }
        }

        #endregion

        #region CUD

        void NewButtonClick(object sender, EventArgs e){
            DalReason newReason = DalReason.CreateReason(GetTypeForCombo(selectedTypeCombo));
            newReason.Name = reasonCombo.Text;
            DbUtil.InsertTransactionReason(newReason, noteControl.Note);
            ReadReasons();
            reasonCombo.SelectedItem = newReason;
        }

        void UpdateButtonClick(object sender, EventArgs e){
            int lastSelectedReasonId = lastSelectedReason.Id;
            if (lastSelectedReason.Type != ((NamingReasonTypes) typeCombo.SelectedItem).Type){
                DbUtil.UpdateTransactionReason(lastSelectedReason.Id,
                                               ((NamingReasonTypes) typeCombo.SelectedItem).Type,
                                               reasonCombo.Text,
                                               float.Parse(energyBox.Text),
                                               noteControl.Note);
            } else {
                lastSelectedReason.Name = reasonCombo.Text;
                if (lastSelectedReason is DalFood){
                    ((DalFood) lastSelectedReason).Energy = float.Parse(energyBox.Text);
                }
                DbUtil.UpdateTransactionReason(lastSelectedReason, noteControl.Note);
            }
            ReadReasons();
            foreach (object obj in reasonCombo.Items){
                if (obj is DalReason&&((DalReason) obj).Id == lastSelectedReasonId){
                    reasonCombo.SelectedItem = obj;
                    break;
                }
            }
        }

        void DeleteButtonClick(object sender, EventArgs e){
            try {
                DbUtil.DeleteTransactionReason(lastSelectedReason);
            } catch (Exception err) {
                MessageBox.Show("Could not delete transaction reason:\n" + err.Message,
                                "Delete transaction reason",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ReadReasons();
            }
        }

        #endregion

        #region Ui

        bool dirty = false;
        bool Dirty
        {
            get { return dirty; }
            set
            {
                updateButton.Enabled = value;
                dirty = value;
            }
        }

        sbyte GetTypeForCombo(ComboBox combo){
            sbyte type = -1;
            if (combo.SelectedItem is NamingReasonTypes) {
                type = ((NamingReasonTypes) combo.SelectedItem).Type;
            }
            return type;
        }

        void ShowControlsForType(sbyte reasonType){
            bool isFood = (reasonType == DalReason.TYPE_FOOD);
            bool isRecipe = (reasonType == DalReason.TYPE_RECIPE);
            energyLabel.Visible = isFood||isRecipe;
            energyBox.Visible = isFood||isRecipe;
            energyMeasureUnitLabel.Visible = isFood||isRecipe;
            lastMealButton.Visible = isRecipe;
            averageMealsButton.Visible = isRecipe;
        }

        void EnableControls(bool val){
            typeLabel.Enabled = val;
            typeCombo.Enabled = val&&(GetTypeForCombo(typeCombo) == DalReason.TYPE_DEFAULT);
            energyLabel.Enabled = val;
            energyBox.Enabled = val;
            energyMeasureUnitLabel.Enabled = val;
            lastMealButton.Enabled = val;
            averageMealsButton.Enabled = val;
            noteControl.Enabled = val;
            deleteButton.Enabled = val;
        }

        void ClearEditBoxes(){
            energyBox.Text = "0.0";
            noteControl.Note = null;
        }

        #endregion
    }
}
