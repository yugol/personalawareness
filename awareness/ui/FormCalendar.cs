/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 03/12/2008
 * Time: 21:11
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
using System.Drawing;
using System.Windows.Forms;

namespace awareness.ui
{
    public partial class FormCalendar : Form {
        public FormCalendar(){
            InitializeComponent();
            UpdateDisplay();
        }

        void FormCalendarFormClosing(object sender, FormClosingEventArgs e){
            Visible = false;
            e.Cancel = true;
        }

        void DatePickerValueChanged(object sender, EventArgs e){
            UpdateDisplay();
        }

        private void UpdateDisplay() {
            DateTime left = datePicker.Value;
            DateTime middle = left.AddMonths(1);
            DateTime right = middle.AddMonths(1);
            leftCalendar.Date = left;
            middleCalendar.Date = middle;
            rightCalendar.Date = right;
        }
    }
}
