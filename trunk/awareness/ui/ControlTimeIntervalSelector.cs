/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 12/09/2008
 * Time: 12:35
 * 
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    public partial class ControlTimeIntervalSelector : UserControl
    {
        internal event DatabaseChangedHandler TimeIntervalChanged;
        
        bool uiInitiatedChanged = true;
        
        public Intervals Interval
        {
            set 
            {  
                foreach (NamingTimeIntervals intervalName in NamingTimeIntervals.GetNames())
                {
                    if (intervalName.Value == value)
                    {
                        intervalCombo.SelectedItem = intervalName;
                        break;
                    }
                }
            }
        }
        
        public DateTime First
        {
            get { return firstPicker.Value.Date; }
        }
        
        public DateTime Last
        {
            get { return lastPicker.Value.Date; }
        }

        public ControlTimeIntervalSelector()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            intervalCombo.DropDownHeight = 200;
            foreach (NamingTimeIntervals intervalName in NamingTimeIntervals.GetNames())
            {
                intervalCombo.Items.Add(intervalName);
            }
            
        }
        
        void IntervalComboSelectedIndexChanged(object sender, EventArgs e)
        {
            if (intervalCombo.SelectedItem != null)
            {
                NamingTimeIntervals intervalName = (NamingTimeIntervals) intervalCombo.SelectedItem;
                if (intervalName.Value != Intervals.UNDEFINED)
                {
                    TimeInterval timeInterval = TimeInterval.CreateInterval(intervalName.Value);
                    uiInitiatedChanged = false;
                    firstPicker.Value = timeInterval.First;
                    lastPicker.Value = timeInterval.Second;
                    uiInitiatedChanged = true;
                    if (TimeIntervalChanged != null)
                    {
                        TimeIntervalChanged();
                    }
                }
            }
        }
        
        void FirstPickerValueChanged(object sender, EventArgs e)
        {
            if (uiInitiatedChanged)
            {
                Interval = Intervals.UNDEFINED; 
                if (TimeIntervalChanged != null)
                {
                    TimeIntervalChanged();
                }
            }
        }
        
        void LastPickerValueChanged(object sender, EventArgs e)
        {
            if (uiInitiatedChanged)
            {
                Interval = Intervals.UNDEFINED;    
                if (TimeIntervalChanged != null)
                {
                    TimeIntervalChanged();
                }
            }
        }
    }
}
