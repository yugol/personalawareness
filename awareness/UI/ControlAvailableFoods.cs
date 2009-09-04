/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 11/09/2008
 * Time: 10:56
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
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

using Awareness.DB;

namespace Awareness.UI
{
    public partial class ControlAvailableFoods : UserControl
    {
        bool updateAvailableFoodsBit = true;
        bool isDisplayed = false;

        public bool IsDisplayed
        {
            get {
                return isDisplayed;
            }
            set {
                isDisplayed = value;
                UpdateAvailableFoods();
            }
        }

        bool dirty;
        bool Dirty
        {
            get {
                return dirty;
            }
            set {
                datePicker.Enabled = value;
                whatBox.Enabled = value;
                whyCombo.Enabled = value;
                quantityInput.Enabled = value;
                consumeButton.Enabled = value;
                dirty = value;
            }
        }

        public ControlAvailableFoods()
        {
            InitializeComponent();
            Util.SetMinMaxDatesAndShortFormatFor(datePicker);
            Controller.StorageOpened += new DataChangedHandler(StorageOpened);
        }
        
        void StorageOpened()
        {
            Debug.WriteLine("ControlAvailableFoods.StorageOpened |-");
            
            RequestUpdateAvailableFoods();
            Controller.Storage.MealsChanged += new DataChangedHandler(RequestUpdateAvailableFoods);
            Controller.Storage.FoodsChanged += new DataChangedHandler(RequestUpdateAvailableFoods);
            Controller.Storage.TransactionsChanged += new DataChangedHandler(RequestUpdateAvailableFoods);
            
            Debug.WriteLine("ControlAvailableFoods.StorageOpened -|");
        }

        void RequestUpdateAvailableFoods()
        {
            updateAvailableFoodsBit = true;
            UpdateAvailableFoods();
        }

        void UpdateAvailableFoods()
        {
            if (isDisplayed&&updateAvailableFoodsBit) {
                IEnumerable<DalFood> foods = Controller.Storage.GetFoods();
                availableFoodsView.Items.Clear();
                bool useAlternateBackground = false;
                foreach (DalFood food in foods) {
                    float available = Controller.Storage.GetAvailableQuantity(food);
                    if (available != 0) {
                        ListViewItem item = new ListViewItem(food.Name);
                        item.Tag = food;
                        item.SubItems.Add(available.ToString());
                        item.BackColor = useAlternateBackground ? Configuration.ALTERNATE_BACKGROUND : Configuration.NORMAL_BACKGROUND;
                        useAlternateBackground = !useAlternateBackground;
                        availableFoodsView.Items.Add(item);
                    }
                }
                ClearEditBoxes();
                updateAvailableFoodsBit = false;
                // MessageBox.Show("AvailableFoods update");
            }
        }

        void AvailableFoodsViewSelectedIndexChanged(object sender, EventArgs e)
        {
            if (availableFoodsView.SelectedItems.Count > 0) {
                DalFood what = (DalFood) availableFoodsView.SelectedItems[0].Tag;
                whatBox.Tag = what;
                whatBox.Text = what.Name;
                quantityInput.Value = double.Parse(availableFoodsView.SelectedItems[0].SubItems[1].Text);
                Util.FillFoodConsumptionReasons(whyCombo, what);
                Dirty = true;
            } else {
                ClearEditBoxes();
            }
        }

        void ClearEditBoxes()
        {
            whatBox.Tag = null;
            whatBox.Text = "";
            quantityInput.Value = 0;
            Dirty = false;
        }

        void ConsumeButtonClick(object sender, EventArgs e)
        {
            if (IsTransactionValid()) {
                DalMeal meal = new DalMeal() {
                    When = datePicker.Value.Date,
                           What = (DalFood) whatBox.Tag,
                                  Quantity = (int) quantityInput.Value,
                                             Why = (DalReason) whyCombo.SelectedItem
                                               };
                Controller.Storage.InsertMeal(meal);
            }
        }

        void WhyComboSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(whyCombo.SelectedItem is DalReason)) {
                whyCombo.SelectedItem = null;
            }
        }

        #region Validation

        private bool performValidation = false;

        bool IsTransactionValid()
        {
            performValidation = true;

            quantityInput.Focus();
            whyCombo.Focus();
            datePicker.Focus();

            string error = "";
            error += errorProvider.GetError(quantityInput);
            error += errorProvider.GetError(whyCombo);

            performValidation = false;

            return string.IsNullOrEmpty(error);
        }

        void QuantityInputValidating(object sender, CancelEventArgs e)
        {
            if (performValidation) {
                if (quantityInput.Value <= 0) {
                    e.Cancel = true;
                    errorProvider.SetError((Control) sender, "Please enter a positive integer value");
                } else {
                    errorProvider.Clear();
                }
            }
        }

        void WhyComboValidating(object sender, CancelEventArgs e)
        {
            if (performValidation) {
                try {
                    if ((DalReason) whyCombo.SelectedItem != null) {
                        errorProvider.Clear();
                    } else {
                        throw new Exception();
                    }
                } catch (Exception) {
                    errorProvider.SetError((Control) sender, "Please select a reason for this meal");
                }
            }
        }

        #endregion
    }
}
