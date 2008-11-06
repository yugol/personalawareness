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
    public partial class FormManageTransactions
    {
        void Button1Click(object sender, EventArgs e)
        {
            reportsMenu.Show(Cursor.Position);
        }
        
        void PieChartToolStripMenuItemClick(object sender, EventArgs e)
        {
            var expensesPie = from t in transactions 
                where t.To.IsBudget && !((DalBudgetCategory) t.To).IsIncome
                group t by t.To into slice
                // orderby slice.Key.Name
                select new {Name = slice.Key.Name, Ammount = slice.Sum(t => t.Ammount)};
           
            int pieCount = expensesPie.Count();
            double[] values = new double[pieCount];
            string[] labels = new string[pieCount];
            int i = 0;
            decimal total = 0;
            foreach (var slice in expensesPie)
            {
                total += slice.Ammount;
                values[i] = (double) slice.Ammount;
                labels[i] = slice.Name;
                ++i;
            }

            for (i = 0; i < pieCount; ++i)
            {
                double perCent = values[i] * 100 / ((double) total);
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
