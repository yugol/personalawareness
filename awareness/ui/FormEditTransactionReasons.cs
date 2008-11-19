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
 * Date: 05/09/2008
 * Time: 09:00
 *
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
        // TODO: use ListView and icons
        // TODO: adjust tab indices
        // TODO: incremental search
        // FIXME: when no reason is entered hide the edit controls in window

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

        public FormEditTransactionReasons(){
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            energyMeasureUnitLabel.Text = string.Format("({0}):", Configuration.FOOD_ENERGY_MEASURE_UNIT);

            selectedTypeCombo.Items.Add("All");
            foreach (NamingReasonTypes typeName in NamingReasonTypes.GetNames()){
                typeCombo.Items.Add(typeName);
                selectedTypeCombo.Items.Add(typeName);
            }
            selectedTypeCombo.SelectedIndex = 0;

            // ReadTransactionReasons();
        }

        void ReadTransactionReasons(){
            AwarenessDataContext dc = DbUtil.GetDataContext();

            IEnumerable<DalReason> reasons = null;
            sbyte type = -1;
            if (selectedTypeCombo.SelectedItem is NamingReasonTypes ){
                type = ((NamingReasonTypes) selectedTypeCombo.SelectedItem).Type;
            }
            if (type < 0){
                reasons = from t in dc.transactionReasons
                          orderby t.Name
                          select t;
            } else {
                reasons = from t in dc.transactionReasons
                          where t.Type == type
                          orderby t.Name
                          select t;
            }
            reasonList.Items.Clear();
            foreach (DalReason reason in reasons){
                reasonList.Items.Add(reason);
            }
            EditControlsEnabled(false);
            ClearEditBoxes();
            if (reasonList.Items.Count > 0){
                reasonList.SelectedIndex = 0;
            }
        }

        void EditControlsEnabled(bool val){
            nameLabel.Enabled = val;
            nameBox.Enabled = val;
            typeLabel.Enabled = val;
            typeCombo.Enabled = val;
            energyLabel.Enabled = val;
            energyBox.Enabled = val;
            energyMeasureUnitLabel.Enabled = val;
            deleteButton.Enabled = val;
            updateButton.Enabled = false;
        }

        void ClearEditBoxes(){
            nameBox.Text = "";
            energyBox.Text = "0.0";
        }

        void ReasonListSelectedIndexChanged(object sender, EventArgs e){
            if (reasonList.SelectedItem is DalReason){
                DalReason tr = (DalReason) reasonList.SelectedItem;
                nameBox.Text = tr.Name;
                foreach (NamingReasonTypes typeName in NamingReasonTypes.GetNames()){
                    if (typeName.Type == tr.Type){
                        typeCombo.SelectedItem = typeName;
                        break;
                    }
                }
                if (tr is DalFood){
                    energyBox.Text = ((DalFood) tr).Energy.ToString();
                }
                EditControlsEnabled(true);
            } else {
                EditControlsEnabled(false);
                ClearEditBoxes();
            }
            Dirty = false;
        }

        void NewButtonClick(object sender, EventArgs e){
            sbyte selectedType = -1;
            if (selectedTypeCombo.SelectedItem is NamingReasonTypes){
                selectedType = ((NamingReasonTypes) selectedTypeCombo.SelectedItem).Type;
            }
            DalReason transactionReason = DalReason.CreateReason(selectedType);
            transactionReason.Name = "_New Element";
            DbUtil.InsertTransactionReason(transactionReason);
            ReadTransactionReasons();
            reasonList.SelectedItem = transactionReason;
            nameBox.Focus();
        }

        void UpdateButtonClick(object sender, EventArgs e){
            DalReason transactionReason = (DalReason) reasonList.SelectedItem;
            if (transactionReason.Type != ((NamingReasonTypes) typeCombo.SelectedItem).Type){
                DbUtil.UpdateTransactionReason(transactionReason.Id, ((NamingReasonTypes) typeCombo.SelectedItem).Type,
                                               nameBox.Text, float.Parse(energyBox.Text));
            } else {
                transactionReason.Name = nameBox.Text;
                if (transactionReason is DalFood){
                    ((DalFood) transactionReason).Energy = float.Parse(energyBox.Text);
                }
                DbUtil.UpdateTransactionReason(transactionReason);
            }
            ReadTransactionReasons();
        }

        void DeleteButtonClick(object sender, EventArgs e){
            try {
                DbUtil.DeleteTransactionReason((DalReason) reasonList.SelectedItem);
            } catch (Exception err)  {
                MessageBox.Show("Could not delete transaction reason:\n" + err.Message,
                                "Delete transaction reason",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ReadTransactionReasons();
            }
        }

        void NameBoxTextChanged(object sender, EventArgs e){
            Dirty = true;
        }

        void NameBoxValidating(object sender, System.ComponentModel.CancelEventArgs e){
            if (string.IsNullOrEmpty(nameBox.Text)){
                e.Cancel = true;
                errorProvider.SetError((Control) sender, "Please enter a name");
            } else {
                errorProvider.Clear();
            }
        }

        void TypeComboSelectedIndexChanged(object sender, EventArgs e){
            sbyte selectedType = ((NamingReasonTypes) typeCombo.SelectedItem).Type;
            bool isFood = (selectedType == DalReason.TYPE_FOOD);
            bool isRecipe = (selectedType == DalReason.TYPE_RECIPE);
            energyLabel.Visible = isFood||isRecipe;
            energyBox.Visible = isFood||isRecipe;
            energyMeasureUnitLabel.Visible = isFood||isRecipe;
            lastMealButton.Visible = isRecipe;
            averageMealsButton.Visible = isRecipe;
            Dirty = true;
        }

        void EnergyBoxTextChanged(object sender, EventArgs e){
            Dirty = true;
        }

        void EnergyBoxValidating(object sender, System.ComponentModel.CancelEventArgs e){
            try {
                float.Parse(energyBox.Text);
                errorProvider.Clear();
            } catch (Exception)  {
                e.Cancel = true;
                errorProvider.SetError((Control) sender, "Please enter a real value");
            }
        }

        void SelectetTypeComboSelectedIndexChanged(object sender, EventArgs e){
            ReadTransactionReasons();
        }

        void LastMealButtonClick(object sender, EventArgs e){
            float energy = DbUtil.GetLastEnergyForRecipe((DalRecipe) reasonList.SelectedItem);
            energyBox.Text = energy.ToString("0.00");
        }

        void Button1Click(object sender, EventArgs e){
            float energy = DbUtil.GetAverageEnergyForRecipe((DalRecipe) reasonList.SelectedItem);
            energyBox.Text = energy.ToString("0.00");
        }
    }
}
