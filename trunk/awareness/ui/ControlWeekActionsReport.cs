/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 03/10/2008
 * Time: 22:59
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
    public partial class ControlWeekActionsReport : UserControl
    {
        public ControlWeekActionsReport()
        {
            InitializeComponent();
            datePicker.ValueChanged += new EventHandler(DatePickerValueChanged);
        }

        public void UpdateActions()
        {
            mondayActions.UpdateActions();
            tuesdayActions.UpdateActions();
            wednesdayActions.UpdateActions();
            thursdayActions.UpdateActions();
            fridayActions.UpdateActions();
            saturdayActions.UpdateActions();
            sundayActions.UpdateActions();
        }

        void DatePickerValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("DatePickerValueChanged - week");

            DateTime day = TimeInterval.GetMonday(datePicker.Value);
            mondayActions.TimeInterval = TimeInterval.CreateInterval(Intervals.TODAY, day);
            day = day.AddDays(1);
            tuesdayActions.TimeInterval = TimeInterval.CreateInterval(Intervals.TODAY, day);
            day = day.AddDays(1);
            wednesdayActions.TimeInterval = TimeInterval.CreateInterval(Intervals.TODAY, day);
            day = day.AddDays(1);
            thursdayActions.TimeInterval = TimeInterval.CreateInterval(Intervals.TODAY, day);
            day = day.AddDays(1);
            fridayActions.TimeInterval = TimeInterval.CreateInterval(Intervals.TODAY, day);
            day = day.AddDays(1);
            saturdayActions.TimeInterval = TimeInterval.CreateInterval(Intervals.TODAY, day);
            day = day.AddDays(1);
            sundayActions.TimeInterval = TimeInterval.CreateInterval(Intervals.TODAY, day);
        }
        
        void ControlWeekActionsReportLoad(object sender, EventArgs e)
        {
            datePicker.Value = DateTime.Now;	
        }
        
    }
}
