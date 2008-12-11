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
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Awareness.DB;

namespace Awareness.UI
{
    public partial class ControlMealsDailyReport : UserControl {
        bool updateReportBit = true;
        bool isDisplayed = false;

        public bool IsDisplayed {
            get { return isDisplayed; }
            set {
                isDisplayed = value;
                UpdateReport();
            }
        }

        public ControlMealsDailyReport(){
            InitializeComponent();

            datePicker.JumpSize = EJumpSize.Day;
            datePicker.ValueChanged += new EventHandler(DatePickerValueChanged);

            DBUtil.DataContextChanged += new DatabaseChangedHandler(RequestUpdateReport);
            DBUtil.MealsChanged += new DatabaseChangedHandler(RequestUpdateReport);
            DBUtil.FoodsChanged += new DatabaseChangedHandler(RequestUpdateReport);

            DBUtil.DataContextChanged += new DatabaseChangedHandler(UpdateWhyCombo);
            DBUtil.RecipesChanged += new DatabaseChangedHandler(UpdateWhyCombo);
            DBUtil.ConsumersChanged += new DatabaseChangedHandler(UpdateWhyCombo);
        }

        void RequestUpdateReport() {
            updateReportBit = true;
            UpdateReport();
        }

        void UpdateReport(){
            if (isDisplayed&&updateReportBit){
                mealsView.Items.Clear();
                float totalEnergy = 0;
                if (whyCombo.SelectedItem is DalReason){
                    AwarenessDataContext dc = DBUtil.GetDataContext();
                    DateTime date = datePicker.Value.Date;
                    IEnumerable<DalMeal> meals = from m in dc.meals
                                                 where m.When == date
                                                 where m.Why.Id == ((DalReason) whyCombo.SelectedItem).Id
                                                 orderby m.What.Name
                                                 select m;
                    bool useAlternateBackground = false;
                    foreach (DalMeal meal in meals){
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

        void UpdateWhyCombo(){
            Util.FillFoodConsumptionReasons(whyCombo, null);
            int id = Configuration.DBProperties.LastMealReportReason;
            foreach (object obj in whyCombo.Items){
                if (obj is DalReason&&((DalReason) obj).Id == id){
                    whyCombo.SelectedItem = obj;
                }
            }
        }

        void DatePickerValueChanged(object sender, EventArgs e){
            RequestUpdateReport();
        }

        void WhyComboSelectedIndexChanged(object sender, EventArgs e){
            if (!(whyCombo.SelectedItem is DalReason)){
                whyCombo.SelectedItem = null;
            } else {
                Configuration.DBProperties.LastMealReportReason = ((DalReason) whyCombo.SelectedItem).Id;
                DBUtil.UpdateProperties();
            }
            RequestUpdateReport();
        }

        void ControlMealsDailyReportLoad(object sender, EventArgs e){
            datePicker.Value = DateTime.Now;
        }
    }
}
