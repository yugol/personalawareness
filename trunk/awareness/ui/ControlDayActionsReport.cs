/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 03/10/2008
 * Time: 20:58
 * 
 */
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    public partial class ControlDayActionsReport : UserControl
    {
        public ControlDayActionsReport()
        {
            InitializeComponent();
            datePicker.ValueChanged += new EventHandler(DatePickerValueChanged);
        }
        
        public void UpdateActions()
        {
            actionsListControl.UpdateActions();
        }
        
        void DatePickerValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("DatePickerValueChanged - day");
            actionsListControl.TimeInterval = TimeInterval.CreateInterval(Intervals.TODAY, datePicker.Value);
        }
        
        void ControlDayActionsReportLoad(object sender, EventArgs e)
        {
            datePicker.Value = DateTime.Now;
        }
        
    }
}
