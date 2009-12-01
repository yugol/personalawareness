/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 11/09/2008
 * Time: 12:06
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
using System.Diagnostics;
using System.Windows.Forms;

using Awareness.DB;

namespace Awareness.UI
{
    public partial class ControlMealsDailyReport : UserControl
    {
        bool updateReportBit = true;
        bool isDisplayed = false;

        public bool IsDisplayed
        {
            get {
                return isDisplayed;
            }
            set {
                isDisplayed = value;
                UpdateReport();
            }
        }

        public ControlMealsDailyReport()
        {
            InitializeComponent();
            datePicker.JumpSize = EJumpSize.Day;
            datePicker.ValueChanged += new EventHandler(DatePickerValueChanged);
            Controller.StorageOpened += new DataChangedHandler(StorageOpened);
        }

        void StorageOpened()
        {
            Debug.WriteLine("ControlMealsDailyReport.StorageOpened |-");

            RequestUpdateReport();
            UpdateWhyCombo();
            Controller.Storage.MealsChanged += new DataChangedHandler(RequestUpdateReport);
            Controller.Storage.FoodsChanged += new DataChangedHandler(RequestUpdateReport);
            Controller.Storage.RecipesChanged += new DataChangedHandler(UpdateWhyCombo);
            Controller.Storage.ConsumersChanged += new DataChangedHandler(UpdateWhyCombo);

            Debug.WriteLine("ControlMealsDailyReport.StorageOpened -|");
        }

        void RequestUpdateReport()
        {
            updateReportBit = true;
            UpdateReport();
        }

        void UpdateReport()
        {
            if (isDisplayed&&updateReportBit) {
                mealsView.Items.Clear();
                float totalEnergy = 0;
                if (whyCombo.SelectedItem is DalReason) {
                    IEnumerable<DalMeal> meals = Controller.Storage.GetMeals(
                                                     datePicker.Value.Date,
                                                     (DalReason) whyCombo.SelectedItem);
                    bool useAlternateBackground = false;
                    foreach (DalMeal meal in meals) {
                        float energy = meal.What.GetEnergy(meal.Quantity);
                        totalEnergy += energy;
                        ListViewItem item = new ListViewItem(meal.What.Name);
                        item.SubItems.Add(meal.Quantity.ToString());
                        item.SubItems.Add(energy.ToString("#,##0.00"));
                        item.BackColor = useAlternateBackground ? Configuration.ALTERNATE_BACKGROUND : Configuration.NORMAL_BACKGROUND;
                        useAlternateBackground = !useAlternateBackground;
                        mealsView.Items.Add(item);
                    }
                }
                energyValueLabel.Text = totalEnergy.ToString("#,##0.00");
                updateReportBit = false;
                //MessageBox.Show("MealsDailyReport updated");
            }
        }

        void UpdateWhyCombo()
        {
            Util.FillFoodConsumptionReasons(whyCombo, null);
            int id = Configuration.StorageProperties.LastMealReportReason;
            foreach (object obj in whyCombo.Items) {
                if (obj is DalReason&&((DalReason) obj).Id == id) {
                    whyCombo.SelectedItem = obj;
                }
            }
        }

        void DatePickerValueChanged(object sender, EventArgs e)
        {
            RequestUpdateReport();
        }

        void WhyComboSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(whyCombo.SelectedItem is DalReason)) {
                whyCombo.SelectedItem = null;
            } else {
                Configuration.StorageProperties.LastMealReportReason = ((DalReason) whyCombo.SelectedItem).Id;
                Controller.Storage.UpdateProperties(Configuration.StorageProperties);
            }
            RequestUpdateReport();
        }

        void ControlMealsDailyReportLoad(object sender, EventArgs e)
        {
            datePicker.Value = DateTime.Now;
        }
    }
}