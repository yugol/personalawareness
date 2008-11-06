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
    public enum JumpSize { Day, Week, Month }
    
    public partial class ControlJumperDatePicker : UserControl
    {
        public event EventHandler ValueChanged;
        
        JumpSize jumpSize = JumpSize.Day;
        public JumpSize JumpSize
        {
            get { return jumpSize; }
            set 
            { 
                jumpSize = value;
                switch (jumpSize)
                {
                    case JumpSize.Day:
                        this.toolTip.SetToolTip(this.leftLeftButton, "Previous week");
                        this.toolTip.SetToolTip(this.leftButton, "Previous day");
                        this.toolTip.SetToolTip(this.rightButton, "Next day");
                        this.toolTip.SetToolTip(this.rightRightButton, "Next week");
                        break;
                    case JumpSize.Week:
                        this.toolTip.SetToolTip(this.leftLeftButton, "Previous month");
                        this.toolTip.SetToolTip(this.leftButton, "Previous week");
                        this.toolTip.SetToolTip(this.rightButton, "Next week");
                        this.toolTip.SetToolTip(this.rightRightButton, "Next month");
                        break;
                    case JumpSize.Month:
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
        
        public ControlJumperDatePicker()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
            datePicker.MinDate = Configuration.MIN_DATE_TIME;
            datePicker.MaxDate = Configuration.MAX_DATE_TIME;
        }
        
        void LeftLeftButtonClick(object sender, EventArgs e)
        {
            try
            {
                switch (jumpSize)
                {
                    case JumpSize.Day:
                        datePicker.Value = datePicker.Value.AddDays(-7);
                        break;
                    case JumpSize.Week:
                        datePicker.Value = datePicker.Value.AddMonths(-1);
                        break;
                    case JumpSize.Month:
                        datePicker.Value = datePicker.Value.AddYears(-1);
                        break;
                }
            }
            catch (Exception)
            {
            }
        }
        
        void LeftButtonClick(object sender, EventArgs e)
        {
            try
            {
                switch (jumpSize)
                {
                    case JumpSize.Day:
                        datePicker.Value = datePicker.Value.AddDays(-1);
                        break;
                    case JumpSize.Week:
                        datePicker.Value = datePicker.Value.AddDays(-7);
                        break;
                    case JumpSize.Month:
                        datePicker.Value = datePicker.Value.AddMonths(-1);
                        break;
                }
            }
            catch (Exception)
            {
            }
        }
        
        void RightButtonClick(object sender, EventArgs e)
        {
            try
            {
                switch (jumpSize)
                {
                    case JumpSize.Day:
                        datePicker.Value = datePicker.Value.AddDays(1);
                        break;
                    case JumpSize.Week:
                        datePicker.Value = datePicker.Value.AddDays(7);
                        break;
                    case JumpSize.Month:
                        datePicker.Value = datePicker.Value.AddMonths(1);
                        break;
                }
            }
            catch (Exception)
            {
            }
        }
        
        void RightRightButtonClick(object sender, EventArgs e)
        {
            try
            {
                switch (jumpSize)
                {
                    case JumpSize.Day:
                        datePicker.Value = datePicker.Value.AddDays(7);
                        break;
                    case JumpSize.Week:
                        datePicker.Value = datePicker.Value.AddMonths(1);
                        break;
                    case JumpSize.Month:
                        datePicker.Value = datePicker.Value.AddYears(1);
                        break;
                }
            }
            catch (Exception)
            {
            }
        }
        
        void DatePickerValueChanged(object sender, EventArgs e)
        {
            if (ValueChanged != null) 
            {
                ValueChanged(this, e);
            }
        }
        
        void TodayButtonClick(object sender, EventArgs e)
        {
            datePicker.Value = DateTime.Now;
        }
    }
}
