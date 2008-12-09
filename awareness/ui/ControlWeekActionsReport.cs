/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 03/10/2008
 * Time: 22:59
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
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    public partial class ControlWeekActionsReport : UserControl {
        bool updateActionsBit = true;
        bool isDisplayed = false;

        public bool IsDisplayed {
            get { return isDisplayed; }
            set {
                isDisplayed = value;
                UpdateActions();
            }
        }

        public ControlWeekActionsReport(){
            InitializeComponent();
            datePicker.ValueChanged += new EventHandler(DatePickerValueChanged);
            DbUtil.ActionsChanged += new DatabaseChangedHandler(RequestUpdateActions);
        }

        void RequestUpdateActions(){
            updateActionsBit = true;
            UpdateActions();
        }

        void UpdateActions(){
            if (isDisplayed&&updateActionsBit){
                mondayActions.UpdateActions();
                tuesdayActions.UpdateActions();
                wednesdayActions.UpdateActions();
                thursdayActions.UpdateActions();
                fridayActions.UpdateActions();
                saturdayActions.UpdateActions();
                sundayActions.UpdateActions();
                updateActionsBit = false;
                //MessageBox.Show("WeekActionsReport updated");
            }
        }

        void DatePickerValueChanged(object sender, EventArgs e){
            DateTime day = TimeInterval.GetMonday(datePicker.Value);
            mondayActions.TimeInterval = TimeInterval.CreateInterval(ETimeIntervals.TODAY, day);
            tuesdayActions.TimeInterval = TimeInterval.CreateInterval(ETimeIntervals.TODAY, day.AddDays(1));
            wednesdayActions.TimeInterval = TimeInterval.CreateInterval(ETimeIntervals.TODAY, day.AddDays(2));
            thursdayActions.TimeInterval = TimeInterval.CreateInterval(ETimeIntervals.TODAY, day.AddDays(3));
            fridayActions.TimeInterval = TimeInterval.CreateInterval(ETimeIntervals.TODAY, day.AddDays(4));
            saturdayActions.TimeInterval = TimeInterval.CreateInterval(ETimeIntervals.TODAY, day.AddDays(5));
            sundayActions.TimeInterval = TimeInterval.CreateInterval(ETimeIntervals.TODAY, day.AddDays(6));
        }

        void ControlWeekActionsReportLoad(object sender, EventArgs e){
            datePicker.Value = DateTime.Now;
        }
    }
}
