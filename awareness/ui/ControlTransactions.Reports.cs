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
 * Date: 02/11/2008
 * Time: 19:36
 *
 */
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using awareness.db;
using ZedGraph;

namespace awareness.ui
{
    partial class ControlTransactions {
        enum Grouping {DAILY, WEEKLY, MONTHLY, YEARLY}

        class PeriodAmmount {
            public DateTime date = DateTime.MinValue;
            public decimal ammount = 0;
        }

        class NameAmmount {
            public string Name = null;
            public decimal Ammount = 0;
        }

        void ReportsButtonClick(object sender, EventArgs e){
            reportsMenu.Show(Cursor.Position);
        }

        void ExpensesPieChartToolStripMenuItemClick(object sender, EventArgs e){
            FormReport report = new FormReport();
            report.Text = "Expenses by Bugetary Caregories";

            IQueryable<NameAmmount> pieSlices = from t in transactions
                                                where t.To.IsBudget&&!((DalBudgetCategory) t.To).IsIncome
                                                group t by t.To into slice
                                                // orderby slice.Key.Name
                                                select new NameAmmount() {
                Name = slice.Key.Name, Ammount = slice.Sum(t => t.Ammount)
            };

            PieReport(report, pieSlices);
        }

        void ExpensesDailyToolStripMenuItemClick(object sender, EventArgs e){
            FormReport report = new FormReport();
            report.Text = "Daily Expenses";
            HistogramReport(GetExpensesHistogram(), report, Grouping.DAILY);
        }

        void ExpensesWeeklyToolStripMenuItemClick(object sender, EventArgs e){
            FormReport report = new FormReport();
            report.Text = "Weekly Expenses";
            HistogramReport(GetExpensesHistogram(), report, Grouping.WEEKLY);
        }

        void ExpensesMonthlyToolStripMenuItemClick(object sender, EventArgs e){
            FormReport report = new FormReport();
            report.Text = "Monthly Expenses";
            HistogramReport(GetExpensesHistogram(), report, Grouping.MONTHLY);
        }

        void ExpensesYearlyToolStripMenuItemClick(object sender, EventArgs e){
            FormReport report = new FormReport();
            report.Text = "Yearly Expenses";
            HistogramReport(GetExpensesHistogram(), report, Grouping.YEARLY);
        }

        IQueryable<DalTransaction> GetExpensesHistogram() {
            return from t in transactions
                   where t.To.IsBudget&&!((DalBudgetCategory) t.To).IsIncome
                   orderby t.When
                   select t;
        }

        void IncomePieChartToolStripMenuItemClick(object sender, EventArgs e){
            FormReport report = new FormReport();
            report.Text = "Income by Bugetary Caregories";

            IQueryable<NameAmmount> pieSlices = from t in transactions
                                                where t.From.IsBudget&&((DalBudgetCategory) t.From).IsIncome
                                                group t by t.From into slice
                                                // orderby slice.Key.Name
                                                select new NameAmmount() {
                Name = slice.Key.Name, Ammount = slice.Sum(t => t.Ammount)
            };

            PieReport(report, pieSlices);
        }

        void IncomeYearlyToolStripMenuItemClick(object sender, EventArgs e){
            FormReport report = new FormReport();
            report.Text = "Yearly Income";
            HistogramReport(GetIncomeHistogram(), report, Grouping.YEARLY);
        }

        void IncomeMonthlyToolStripMenuItemClick(object sender, EventArgs e){
            FormReport report = new FormReport();
            report.Text = "Monthly Income";
            HistogramReport(GetIncomeHistogram(), report, Grouping.MONTHLY);
        }

        void IncomeWeeklyToolStripMenuItemClick(object sender, EventArgs e){
            FormReport report = new FormReport();
            report.Text = "Weekly Income";
            HistogramReport(GetIncomeHistogram(), report, Grouping.WEEKLY);
        }

        void IncomeDailyToolStripMenuItemClick(object sender, EventArgs e){
            FormReport report = new FormReport();
            report.Text = "Daily Income";
            HistogramReport(GetIncomeHistogram(), report, Grouping.DAILY);
        }

        IQueryable<DalTransaction> GetIncomeHistogram() {
            return from t in transactions
                   where t.From.IsBudget&&((DalBudgetCategory) t.From).IsIncome
                   orderby t.When
                   select t;
        }

        void PieReport(FormReport report, IQueryable<NameAmmount> pieSlices){
            int sliceCount = pieSlices.Count();
            double[] values = new double[sliceCount];
            string[] labels = new string[sliceCount];
            int i = 0;
            decimal total = 0;
            foreach (var slice in pieSlices) {
                total += slice.Ammount;
                values[i] = (double) slice.Ammount;
                labels[i] = slice.Name;
                ++i;
            }

            for (i = 0; i < sliceCount; ++i) {
                double perCent = values[i] *100 / ((double) total);
                labels[i] = string.Format("{0}\n{1} ({2}%)", labels[i], UiUtil.FormatCurrency((decimal) values[i]), perCent.ToString("#0.00"));
            }

            string title = "Total ammount: " + UiUtil.FormatCurrency(total);
            title += "\n(" + timeIntervalSelectorControl.First.ToString("yyyy-MM-dd");
            title += " -> " + timeIntervalSelectorControl.Last.ToString("yyyy-MM-dd");
            title += ")";

            GraphPane myPane = report.Graph.GraphPane;
            myPane.Title.Text = title;
            myPane.Legend.IsVisible = false;
            myPane.AddPieSlices(values, labels);

            report.Graph.AxisChange();
            report.Show();
        }

        void HistogramReport(IQueryable<DalTransaction> transactions, FormReport report, Grouping grouping){
            string title = "From " + timeIntervalSelectorControl.First.ToString("yyyy-MM-dd");
            title += " to " + timeIntervalSelectorControl.Last.ToString("yyyy-MM-dd");

            GraphPane myPane = report.Graph.GraphPane;
            report.Graph.IsShowPointValues = true;
            myPane.Title.Text = title;
            myPane.Legend.IsVisible = false;
            myPane.XAxis.Title.IsVisible = false;
            myPane.YAxis.Title.IsVisible = false;
            myPane.XAxis.Type = AxisType.Date;
            myPane.AddBar("", GroupTransactions(transactions, grouping), Color.Blue);

            report.Graph.AxisChange();
            report.Show();
        }

        PointPairList GroupTransactions(IQueryable<DalTransaction> transactions, Grouping grouping) {
            PointPairList data = new PointPairList();
            PeriodAmmount pa = null;

            foreach (DalTransaction transaction in transactions){
                if (pa == null){
                    pa = new PeriodAmmount();
                    pa.date = transaction.When;
                    pa.ammount = transaction.Ammount;
                } else if (IsInOtherGroup(transaction.When, pa.date, grouping)){
                    data.Add(pa.date.ToOADate(), (double) pa.ammount);
                    pa = new PeriodAmmount();
                    pa.date = transaction.When;
                    pa.ammount = transaction.Ammount;
                } else {
                    // pa.date = transaction.When;
                    pa.ammount += transaction.Ammount;
                }
            }
            if (pa != null){
                data.Add(pa.date.ToOADate(), (double) pa.ammount);
            }

            return data;
        }

        bool IsInOtherGroup(DateTime date, DateTime group, Grouping grouping) {
            switch (grouping){
            case Grouping.DAILY:
                return date != group;

            case Grouping.WEEKLY:
                return TimeInterval.GetMonday(date) != TimeInterval.GetMonday(group);

            case Grouping.MONTHLY:
                return !(date.Year == group.Year&&date.Month == group.Month);

            case Grouping.YEARLY:
                return date.Year != group.Year;
            }
            throw new ArgumentException("ControlTransactions.Reports.IsInOtherGroup");
        }
    }
}
