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
