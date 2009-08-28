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
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using Awareness.db;
using ZedGraph;

namespace Awareness.ui
{
    partial class ControlTransactions
    {
        enum EGrouping {DAILY, WEEKLY, MONTHLY, YEARLY}

        void ReportsButtonClick(object sender, EventArgs e)
        {
            reportsMenu.Show(Cursor.Position);
        }

        void ExpensesPieChartToolStripMenuItemClick(object sender, EventArgs e)
        {
            FormReport report = new FormReport();
            report.Text = "Expenses by Bugetary Caregories";
            PieReport(report,
                      Controller.Storage.GetExpensesPieChartData(
                          timeIntervalSelectorControl.First,
                          timeIntervalSelectorControl.Last,
                          selectedTransferLocation,
                          reasonSelectionPattern));
        }

        void ExpensesDailyToolStripMenuItemClick(object sender, EventArgs e)
        {
            FormReport report = new FormReport();
            report.Text = "Daily Expenses";
            HistogramReport(Controller.Storage.GetExpensesHistogramData(
                                timeIntervalSelectorControl.First,
                                timeIntervalSelectorControl.Last,
                                selectedTransferLocation,
                                reasonSelectionPattern),
                            report,
                            EGrouping.DAILY);
        }

        void ExpensesWeeklyToolStripMenuItemClick(object sender, EventArgs e)
        {
            FormReport report = new FormReport();
            report.Text = "Weekly Expenses";
            HistogramReport(Controller.Storage.GetExpensesHistogramData(
                                timeIntervalSelectorControl.First,
                                timeIntervalSelectorControl.Last,
                                selectedTransferLocation,
                                reasonSelectionPattern),
                            report,
                            EGrouping.WEEKLY);
        }

        void ExpensesMonthlyToolStripMenuItemClick(object sender, EventArgs e)
        {
            FormReport report = new FormReport();
            report.Text = "Monthly Expenses";
            HistogramReport(Controller.Storage.GetExpensesHistogramData(
                                timeIntervalSelectorControl.First,
                                timeIntervalSelectorControl.Last,
                                selectedTransferLocation,
                                reasonSelectionPattern),
                            report,
                            EGrouping.MONTHLY);
        }

        void ExpensesYearlyToolStripMenuItemClick(object sender, EventArgs e)
        {
            FormReport report = new FormReport();
            report.Text = "Yearly Expenses";
            HistogramReport(Controller.Storage.GetExpensesHistogramData(
                                timeIntervalSelectorControl.First,
                                timeIntervalSelectorControl.Last,
                                selectedTransferLocation,
                                reasonSelectionPattern),
                            report,
                            EGrouping.YEARLY);
        }


        void IncomePieChartToolStripMenuItemClick(object sender, EventArgs e)
        {
            FormReport report = new FormReport();
            report.Text = "Income by Bugetary Caregories";
            PieReport(report,
                      Controller.Storage.GetExpensesPieChartData(
                          timeIntervalSelectorControl.First,
                          timeIntervalSelectorControl.Last,
                          selectedTransferLocation,
                          reasonSelectionPattern));
        }

        void IncomeYearlyToolStripMenuItemClick(object sender, EventArgs e)
        {
            FormReport report = new FormReport();
            report.Text = "Yearly Income";
            HistogramReport(Controller.Storage.GetIncomeHistogramData(
                                timeIntervalSelectorControl.First,
                                timeIntervalSelectorControl.Last,
                                selectedTransferLocation,
                                reasonSelectionPattern),
                            report,
                            EGrouping.YEARLY);
        }

        void IncomeMonthlyToolStripMenuItemClick(object sender, EventArgs e)
        {
            FormReport report = new FormReport();
            report.Text = "Monthly Income";
            HistogramReport(Controller.Storage.GetIncomeHistogramData(
                                timeIntervalSelectorControl.First,
                                timeIntervalSelectorControl.Last,
                                selectedTransferLocation,
                                reasonSelectionPattern),
                            report,
                            EGrouping.MONTHLY);
        }

        void IncomeWeeklyToolStripMenuItemClick(object sender, EventArgs e)
        {
            FormReport report = new FormReport();
            report.Text = "Weekly Income";
            HistogramReport(Controller.Storage.GetIncomeHistogramData(
                                timeIntervalSelectorControl.First,
                                timeIntervalSelectorControl.Last,
                                selectedTransferLocation,
                                reasonSelectionPattern),
                            report,
                            EGrouping.WEEKLY);
        }

        void IncomeDailyToolStripMenuItemClick(object sender, EventArgs e)
        {
            FormReport report = new FormReport();
            report.Text = "Daily Income";
            HistogramReport(Controller.Storage.GetIncomeHistogramData(
                                timeIntervalSelectorControl.First,
                                timeIntervalSelectorControl.Last,
                                selectedTransferLocation,
                                reasonSelectionPattern),
                            report,
                            EGrouping.DAILY);
        }

        void PieReport(FormReport report, IEnumerable<NameAmmount> pieSlices)
        {
            int sliceCount = 0;
            foreach (var slice in pieSlices) {
                ++sliceCount;
            }
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
                labels[i] = string.Format("{0}\n{1} ({2}%)", labels[i], Util.FormatCurrency((decimal) values[i]), perCent.ToString("#0.00"));
            }

            string title = "Total ammount: " + Util.FormatCurrency(total);
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

        void HistogramReport(IEnumerable<DalTransaction> transactions, FormReport report, EGrouping grouping)
        {
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

        PointPairList GroupTransactions(IEnumerable<DalTransaction> transactions, EGrouping grouping)
        {
            PointPairList data = new PointPairList();
            PeriodAmmount pa = null;

            foreach (DalTransaction transaction in transactions) {
                if (pa == null) {
                    pa = new PeriodAmmount();
                    pa.date = transaction.When;
                    pa.ammount = transaction.Ammount;
                } else if (IsInOtherGroup(transaction.When, pa.date, grouping)) {
                    data.Add(pa.date.ToOADate(), (double) pa.ammount);
                    pa = new PeriodAmmount();
                    pa.date = transaction.When;
                    pa.ammount = transaction.Ammount;
                } else {
                    // pa.date = transaction.When;
                    pa.ammount += transaction.Ammount;
                }
            }
            if (pa != null) {
                data.Add(pa.date.ToOADate(), (double) pa.ammount);
            }

            return data;
        }

        bool IsInOtherGroup(DateTime date, DateTime group, EGrouping grouping)
        {
            switch (grouping) {
            case EGrouping.DAILY:
                return date != group;

            case EGrouping.WEEKLY:
                return TimeInterval.GetMonday(date) != TimeInterval.GetMonday(group);

            case EGrouping.MONTHLY:
                return !(date.Year == group.Year&&date.Month == group.Month);

            case EGrouping.YEARLY:
                return date.Year != group.Year;
            }
            throw new ArgumentException("ControlTransactions.Reports.IsInOtherGroup");
        }
    }
}
