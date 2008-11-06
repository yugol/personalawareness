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
 * Date: 16/09/2008
 * Time: 22:02
 *
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using ZedGraph;

using awareness.db;

namespace awareness.ui
{
    public partial class FormManageTransactions {
        void Button1Click(object sender, EventArgs e){
            reportsMenu.Show(Cursor.Position);
        }

        void PieChartToolStripMenuItemClick(object sender, EventArgs e){
            var expensesPie = from t in transactions
                              where t.To.IsBudget&&!((DalBudgetCategory) t.To).IsIncome
                              group t by t.To into slice
                              // orderby slice.Key.Name
                              select new {Name = slice.Key.Name, Ammount = slice.Sum(t => t.Ammount)};

            int pieCount = expensesPie.Count();
            double[] values = new double[pieCount];
            string[] labels = new string[pieCount];
            int i = 0;
            decimal total = 0;
            foreach (var slice in expensesPie){
                total += slice.Ammount;
                values[i] = (double) slice.Ammount;
                labels[i] = slice.Name;
                ++i;
            }

            for (i = 0; i < pieCount; ++i){
                double perCent = values[i] *100 / ((double) total);
                labels[i] = string.Format("{0}\n{1} ({2}%)", labels[i], UiUtil.FormatCurrency((decimal) values[i]), perCent.ToString("#0.00"));
            }

            FormReport report = new FormReport();
            report.Text = "Expenses by Bugetary Caregories";
            GraphPane myPane = report.Graph.GraphPane;
            myPane.Fill = new Fill(Configuration.ALTERNATE_BACKGROUND, Configuration.ALTERNATE_BACKGROUND, 90f);
            myPane.Chart.Fill = new Fill(Configuration.NORMAL_BACKGROUND, Configuration.ALTERNATE_BACKGROUND, 90f);
            myPane.Title.Text = "Total expenses: " + UiUtil.FormatCurrency(total);
            myPane.Legend.IsVisible = false;
            myPane.AddPieSlices(values, labels);
            report.Graph.AxisChange();

            report.Show();
        }
    }
}
