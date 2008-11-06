/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 10/09/2008
 * Time: 16:04
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
    /// <summary>
    /// Description of FormManageMeals.
    /// </summary>
    public partial class FormManageMeals : Form
    {
        AwarenessDataContext dc = DbUtil.GetDataContext();
        
        public FormManageMeals()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            ReadMeals();
        }
        
        void ReadMeals()
        {
            IEnumerable<DalMeal> meals = from m in dc.meals
                orderby m.When descending, m.What.Name
                select m;
            mealsView.Items.Clear();
            bool useAlternateBackground = false;
            foreach (DalMeal meal in meals)
            {
                ListViewItem item = new ListViewItem(meal.When.ToShortDateString());
                item.Tag = meal;
                item.SubItems.Add(meal.What.Name);
                item.SubItems.Add(meal.Quantity.ToString());
                item.SubItems.Add(meal.Why.Name);
                item.BackColor = useAlternateBackground ? Configuration.ALTERNATE_BACKGROUND : Configuration.NORMAL_BACKGROUND;
                useAlternateBackground = !useAlternateBackground;
                mealsView.Items.Add(item);
            }
            deleteButton.Enabled = false;
        }
                
        void MealsViewSelectedIndexChanged(object sender, EventArgs e)
        {
            if (mealsView.SelectedItems.Count > 0)
            {
                deleteButton.Enabled = true;
            }
            else
            {
                deleteButton.Enabled = false;
            }
        }
        
        void DeleteButtonClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the meal? ", 
                                "Connfirm Delete", 
                                MessageBoxButtons.OKCancel, 
                                MessageBoxIcon.Question, 
                                MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                DbUtil.DeleteMeal((DalMeal) mealsView.SelectedItems[0].Tag);
                ReadMeals();
            }
        }
        
    }
}
