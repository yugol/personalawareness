/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 03/12/2008
 * Time: 20:35
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
using System.Windows.Forms;

namespace Awareness.ui
{
    public partial class ControlCalendar : UserControl {
        private static readonly string[] MONTH_NAME = {"", "JAN", "FEB", "MAR", "APR", "MAY", "JUN", "JUL", "AUG", "SEP", "OCT", "NOV", "DEC"};
        private static readonly IDictionary<DayOfWeek, int> WEEK_DAY_INDEX = new Dictionary<DayOfWeek, int>()
        {
            {DayOfWeek.Monday, 0},
            {DayOfWeek.Tuesday, 1},
            {DayOfWeek.Wednesday, 2},
            {DayOfWeek.Thursday, 3},
            {DayOfWeek.Friday, 4},
            {DayOfWeek.Saturday, 5},
            {DayOfWeek.Sunday, 6}
        };

        private Label[, ] dayMatrix = new Label[6, 7];

        public ControlCalendar(){
            InitializeComponent();
            FillDayMatrix();
            Date = DateTime.Today;
        }

        public DateTime Date {
            set {
                DateTime today = DateTime.Now.Date;
                value = value.Date;

                Selected = (value.Month == today.Month) && (value.Year == today.Year);

                labelMonthYear.Text = MONTH_NAME[value.Month] + " - " + value.Year;

                DateTime day = new DateTime(value.Year, value.Month, 1);
                int lin = 0, col = 0;
                while (col < WEEK_DAY_INDEX[day.DayOfWeek]) {
                    dayMatrix[0, col].Text = "";
                    dayMatrix[0, col].BorderStyle = BorderStyle.None;
                    ++col;
                }
                while (day.Month == value.Month){
                    if (col >= 7){
                        col = 0;
                        ++lin;
                    }
                    dayMatrix[lin, col].Text = day.Day.ToString();
                    dayMatrix[lin, col].BorderStyle = (day == today) ? BorderStyle.FixedSingle : BorderStyle.None;
                    day = day.AddDays(1);
                    ++col;
                }
                while (col < 7){
                    dayMatrix[lin, col].Text = "";
                    dayMatrix[lin, col].BorderStyle = BorderStyle.None;
                    ++col;
                }
                if (lin < 5){
                    lin = 5;
                    for (col = 0; col < 7; ++col){
                        dayMatrix[lin, col].Text = "";
                        dayMatrix[lin, col].BorderStyle = BorderStyle.None;
                    }
                }
            }
        }

        public bool Selected {
            set{
                Color bkTitle = value ? SystemColors.ActiveCaption : SystemColors.InactiveCaption;
                labelMonthYear.BackColor = bkTitle;
                labelMonday.BackColor = bkTitle;
                labelTuesday.BackColor = bkTitle;
                labelWednesday.BackColor = bkTitle;
                labelThursday.BackColor = bkTitle;
                labelFriday.BackColor = bkTitle;
                labelSaturday.BackColor = bkTitle;
                labelSunday.BackColor = bkTitle;
            }
        }

        private void FillDayMatrix() {
            dayMatrix[0, 0] = label11;
            dayMatrix[0, 1] = label12;
            dayMatrix[0, 2] = label13;
            dayMatrix[0, 3] = label14;
            dayMatrix[0, 4] = label15;
            dayMatrix[0, 5] = label16;
            dayMatrix[0, 6] = label17;

            dayMatrix[1, 0] = label21;
            dayMatrix[1, 1] = label22;
            dayMatrix[1, 2] = label23;
            dayMatrix[1, 3] = label24;
            dayMatrix[1, 4] = label25;
            dayMatrix[1, 5] = label26;
            dayMatrix[1, 6] = label27;

            dayMatrix[2, 0] = label31;
            dayMatrix[2, 1] = label32;
            dayMatrix[2, 2] = label33;
            dayMatrix[2, 3] = label34;
            dayMatrix[2, 4] = label35;
            dayMatrix[2, 5] = label36;
            dayMatrix[2, 6] = label37;

            dayMatrix[3, 0] = label41;
            dayMatrix[3, 1] = label42;
            dayMatrix[3, 2] = label43;
            dayMatrix[3, 3] = label44;
            dayMatrix[3, 4] = label45;
            dayMatrix[3, 5] = label46;
            dayMatrix[3, 6] = label47;

            dayMatrix[4, 0] = label51;
            dayMatrix[4, 1] = label52;
            dayMatrix[4, 2] = label53;
            dayMatrix[4, 3] = label54;
            dayMatrix[4, 4] = label55;
            dayMatrix[4, 5] = label56;
            dayMatrix[4, 6] = label57;

            dayMatrix[5, 0] = label61;
            dayMatrix[5, 1] = label62;
            dayMatrix[5, 2] = label63;
            dayMatrix[5, 3] = label64;
            dayMatrix[5, 4] = label65;
            dayMatrix[5, 5] = label66;
            dayMatrix[5, 6] = label67;
        }
    }
}
