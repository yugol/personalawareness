/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 11/09/2008
 * Time: 12:06
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
    public partial class ControlMealsDailyReport : UserControl
    {
        public ControlMealsDailyReport()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            
            datePicker.JumpSize = JumpSize.Day;
            datePicker.ValueChanged += new EventHandler(DatePickerValueChanged);
            
            DbUtil.DataContextChanged += new DatabaseChangedHandler(UpdateReport);
            DbUtil.MealsChanged += new DatabaseChangedHandler(UpdateReport);
            DbUtil.FoodsChanged += new DatabaseChangedHandler(UpdateReport);
            DbUtil.DataContextChanged += new DatabaseChangedHandler(UpdateWhyCombo);
            DbUtil.RecipesChanged += new DatabaseChangedHandler(UpdateWhyCombo);
            DbUtil.ConsumersChanged += new DatabaseChangedHandler(UpdateWhyCombo);
        }
        
        void UpdateReport()
        {
            mealsView.Items.Clear();
            float totalEnergy = 0;

            if (whyCombo.SelectedItem is DalReason)
            {
                AwarenessDataContext dc = DbUtil.GetDataContext();
                DateTime date = datePicker.Value.Date;
                IEnumerable<DalMeal> meals = from m in dc.meals 
                    where m.When == date
                    where m.Why.Id == ((DalReason) whyCombo.SelectedItem).Id
                    orderby m.What.Name 
                    select m;
                bool useAlternateBackground = false;
                foreach (DalMeal meal in meals)
                {
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
        }
        
        void UpdateWhyCombo()
        {
            UiUtil.FillFoodConsumptionReasons(whyCombo, null);    
        }
        
        void DatePickerValueChanged(object sender, EventArgs e)
        {
            UpdateReport(); 	
        }
        
        void WhyComboSelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(whyCombo.SelectedItem is DalReason))
            {
                whyCombo.SelectedItem = null;
            }
            UpdateReport();
        }
        
        void ControlMealsDailyReportLoad(object sender, EventArgs e)
        {
            datePicker.Value = DateTime.Now;
        }
    }
}
