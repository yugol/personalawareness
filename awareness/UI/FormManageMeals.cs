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

using Awareness.db;
using Awareness.db.mssql;

namespace Awareness.ui
{
    public partial class FormManageMeals : Form
    {
        public FormManageMeals()
        {
            InitializeComponent();
            ReadMeals();
        }
        
        void ReadMeals()
        {
            IEnumerable<DalMeal> meals = Controller.Storage.GetMealsTimeDesc(Configuration.MealManagerHistoryLength);
            mealsView.Items.Clear();
            int index = 0;
            foreach (DalMeal meal in meals)
            {
                ListViewItem item = new ListViewItem(meal.When.ToString(Configuration.DATE_FORMAT));
                item.Tag = meal;
                item.SubItems.Add(meal.What.Name);
                item.SubItems.Add(meal.Quantity.ToString());
                item.SubItems.Add(meal.Why.Name);
                item.BackColor = ((index % 2) == 1) ? Configuration.ALTERNATE_BACKGROUND : Configuration.NORMAL_BACKGROUND;
                mealsView.Items.Add(item);
                ++index;
            }
            deleteButton.Enabled = false;
        }
                
        void MealsViewSelectedIndexChanged(object sender, EventArgs e)
        {
            deleteButton.Enabled = mealsView.SelectedItems.Count > 0;
        }
        
        void DeleteButtonClick(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete the meal? ", 
                                "Connfirm Delete", 
                                MessageBoxButtons.OKCancel, 
                                MessageBoxIcon.Question, 
                                MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                Controller.Storage.DeleteMeal((DalMeal) mealsView.SelectedItems[0].Tag);
                ReadMeals();
            }
        }
        
    }
}
