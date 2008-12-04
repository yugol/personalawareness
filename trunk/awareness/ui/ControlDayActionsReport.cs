/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 03/10/2008
 * Time: 20:58
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
    public partial class ControlDayActionsReport : UserControl {
        bool updateActionsBit = true;
        bool isDisplayed = false;

        public bool IsDisplayed {
            get { return isDisplayed; }
            set {
                isDisplayed = value;
                UpdateActions();
            }
        }

        public ControlDayActionsReport(){
            InitializeComponent();
            datePicker.ValueChanged += new EventHandler(DatePickerValueChanged);
            DbUtil.ActionsChanged += new DatabaseChangedHandler(RequestUpdateActions);
        }

        void RequestUpdateActions(){
            updateActionsBit = true;
            UpdateActions();
        }

        public void UpdateActions(){
            if (isDisplayed&&updateActionsBit){
                actionsListControl.UpdateActions();
                updateActionsBit = false;
                //MessageBox.Show("DayActionsReport updated");
            }
        }

        void DatePickerValueChanged(object sender, EventArgs e){
            Debug.WriteLine("DatePickerValueChanged - day");
            actionsListControl.TimeInterval = TimeInterval.CreateInterval(Intervals.TODAY, datePicker.Value);
        }

        void ControlDayActionsReportLoad(object sender, EventArgs e){
            datePicker.Value = DateTime.Now;
        }
    }
}
