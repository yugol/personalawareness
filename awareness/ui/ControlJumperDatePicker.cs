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
 * Date: 03/10/2008
 * Time: 18:33
 *
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace awareness.ui
{
    public enum EJumpSize { Day, Week, Month }

    public partial class ControlJumperDatePicker : UserControl {
        public event EventHandler ValueChanged;

        EJumpSize jumpSize = EJumpSize.Day;
        public EJumpSize JumpSize
        {
            get { return jumpSize; }
            set
            {
                jumpSize = value;
                switch (jumpSize){
                case EJumpSize.Day:
                    this.toolTip.SetToolTip(this.leftLeftButton, "Previous week");
                    this.toolTip.SetToolTip(this.leftButton, "Previous day");
                    this.toolTip.SetToolTip(this.rightButton, "Next day");
                    this.toolTip.SetToolTip(this.rightRightButton, "Next week");
                    break;
                case EJumpSize.Week:
                    this.toolTip.SetToolTip(this.leftLeftButton, "Previous month");
                    this.toolTip.SetToolTip(this.leftButton, "Previous week");
                    this.toolTip.SetToolTip(this.rightButton, "Next week");
                    this.toolTip.SetToolTip(this.rightRightButton, "Next month");
                    break;
                case EJumpSize.Month:
                    this.toolTip.SetToolTip(this.leftLeftButton, "Previous year");
                    this.toolTip.SetToolTip(this.leftButton, "Previous month");
                    this.toolTip.SetToolTip(this.rightButton, "Next month");
                    this.toolTip.SetToolTip(this.rightRightButton, "Next year");
                    break;
                }
            }
        }

        public DateTime Value
        {
            get { return datePicker.Value; }
            set { datePicker.Value = value; }
        }

        public ControlJumperDatePicker(){
            InitializeComponent();
            datePicker.MinDate = Configuration.MIN_DATE_TIME;
            datePicker.MaxDate = Configuration.MAX_DATE_TIME;
        }

        void LeftLeftButtonClick(object sender, EventArgs e){
            try {
                switch (jumpSize){
                case EJumpSize.Day:
                    datePicker.Value = datePicker.Value.AddDays(-7);
                    break;
                case EJumpSize.Week:
                    datePicker.Value = datePicker.Value.AddMonths(-1);
                    break;
                case EJumpSize.Month:
                    datePicker.Value = datePicker.Value.AddYears(-1);
                    break;
                }
            } catch (Exception)  {
            }
        }

        void LeftButtonClick(object sender, EventArgs e){
            try {
                switch (jumpSize){
                case EJumpSize.Day:
                    datePicker.Value = datePicker.Value.AddDays(-1);
                    break;
                case EJumpSize.Week:
                    datePicker.Value = datePicker.Value.AddDays(-7);
                    break;
                case EJumpSize.Month:
                    datePicker.Value = datePicker.Value.AddMonths(-1);
                    break;
                }
            } catch (Exception)  {
            }
        }

        void RightButtonClick(object sender, EventArgs e){
            try {
                switch (jumpSize){
                case EJumpSize.Day:
                    datePicker.Value = datePicker.Value.AddDays(1);
                    break;
                case EJumpSize.Week:
                    datePicker.Value = datePicker.Value.AddDays(7);
                    break;
                case EJumpSize.Month:
                    datePicker.Value = datePicker.Value.AddMonths(1);
                    break;
                }
            } catch (Exception)  {
            }
        }

        void RightRightButtonClick(object sender, EventArgs e){
            try {
                switch (jumpSize){
                case EJumpSize.Day:
                    datePicker.Value = datePicker.Value.AddDays(7);
                    break;
                case EJumpSize.Week:
                    datePicker.Value = datePicker.Value.AddMonths(1);
                    break;
                case EJumpSize.Month:
                    datePicker.Value = datePicker.Value.AddYears(1);
                    break;
                }
            } catch (Exception)  {
            }
        }

        void DatePickerValueChanged(object sender, EventArgs e){
            if (ValueChanged != null){
                ValueChanged(this, e);
            }
        }

        void TodayButtonClick(object sender, EventArgs e){
            datePicker.Value = DateTime.Now;
        }
    }
}
