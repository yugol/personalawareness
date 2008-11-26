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
 * Date: 11/09/2008
 * Time: 10:56
 *
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    public partial class ControlAvailableFoods : UserControl {
        bool dirty;
        bool Dirty
        {
            get { return dirty; }
            set
            {
                datePicker.Enabled = value;
                whatBox.Enabled = value;
                whyCombo.Enabled = value;
                quantityInput.Enabled = value;
                consumeButton.Enabled = value;
                dirty = value;
            }
        }

        public ControlAvailableFoods(){
            InitializeComponent();

            DbUtil.DataContextChanged += new DatabaseChangedHandler(UpdateAvailableFoods);
            DbUtil.MealsChanged += new DatabaseChangedHandler(UpdateAvailableFoods);
            DbUtil.FoodsChanged += new DatabaseChangedHandler(UpdateAvailableFoods);
            DbUtil.TransactionsChanged += new DatabaseChangedHandler(UpdateAvailableFoods);
        }

        void UpdateAvailableFoods(){
            AwarenessDataContext dc = DbUtil.GetDataContext();
            IEnumerable<DalFood> foods = dc.transactionReasons.OfType<DalFood>().OrderBy(f => f.Name);
            availableFoodsView.Items.Clear();
            bool useAlternateBackground = false;
            foreach (DalFood food in foods){
                float available = DbUtil.GetAvailableQuantity(food);
                if (available != 0){
                    ListViewItem item = new ListViewItem(food.Name);
                    item.Tag = food;
                    item.SubItems.Add(available.ToString());
                    item.BackColor = useAlternateBackground ? Configuration.ALTERNATE_BACKGROUND : Configuration.NORMAL_BACKGROUND;
                    useAlternateBackground = !useAlternateBackground;
                    availableFoodsView.Items.Add(item);
                }
            }
            ClearEditBoxes();
        }

        void AvailableFoodsViewSelectedIndexChanged(object sender, EventArgs e){
            if (availableFoodsView.SelectedItems.Count > 0){
                DalFood what = (DalFood) availableFoodsView.SelectedItems[0].Tag;
                whatBox.Tag = what;
                whatBox.Text = what.Name;
                quantityInput.Value = double.Parse(availableFoodsView.SelectedItems[0].SubItems[1].Text);
                UiUtil.FillFoodConsumptionReasons(whyCombo, what);
                Dirty = true;
            } else {
                ClearEditBoxes();
            }
        }

        void ClearEditBoxes(){
            whatBox.Tag = null;
            whatBox.Text = "";
            quantityInput.Value = 0;
            Dirty = false;
        }

        void ConsumeButtonClick(object sender, EventArgs e){
            // TODO: run validation
            DalMeal meal = new DalMeal()
            {
                When = datePicker.Value.Date,
                What = (DalFood) whatBox.Tag,
                Quantity = (int) quantityInput.Value,
                Why = (DalReason) whyCombo.SelectedItem
            };
            DbUtil.InsertMeal(meal);
        }

        void WhyComboSelectedIndexChanged(object sender, EventArgs e){
            if (!(whyCombo.SelectedItem is DalReason)){
                whyCombo.SelectedItem = null;
            }
        }

        void QuantityInputValidating(object sender, CancelEventArgs e){
            if (quantityInput.Value <= 0){
                e.Cancel = true;
                errorProvider.SetError((Control) sender, "Please enter a positive integer value");
            } else {
                errorProvider.Clear();
            }
        }
    }
}
