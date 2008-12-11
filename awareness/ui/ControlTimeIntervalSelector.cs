/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 12/09/2008
 * Time: 12:35
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
using System.Drawing;
using System.Windows.Forms;

using Awareness.DB;

namespace Awareness.UI
{
    public delegate void TimeIntervalChangedHandler();

    public partial class ControlTimeIntervalSelector : UserControl {
        public event TimeIntervalChangedHandler TimeIntervalChanged;

        bool uiInitiatedChanged = true;

        public ETimeIntervals Interval
        {
            set
            {
                foreach (NamingTimeIntervals intervalName in NamingTimeIntervals.GetNames()){
                    if (intervalName.Value == value){
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

        public ControlTimeIntervalSelector(){
            InitializeComponent();

            Util.SetMinMaxDatesFor(firstPicker);
            Util.SetMinMaxDatesFor(lastPicker);
            
            intervalCombo.DropDownHeight = 200;
            foreach (NamingTimeIntervals intervalName in NamingTimeIntervals.GetNames()){
                intervalCombo.Items.Add(intervalName);
            }
        }

        void IntervalComboSelectedIndexChanged(object sender, EventArgs e){
            if (intervalCombo.SelectedItem != null){
                NamingTimeIntervals intervalName = (NamingTimeIntervals) intervalCombo.SelectedItem;
                if (intervalName.Value != ETimeIntervals.UNDEFINED){
                    TimeInterval timeInterval = TimeInterval.CreateInterval(intervalName.Value);
                    uiInitiatedChanged = false;
                    firstPicker.Value = timeInterval.First;
                    lastPicker.Value = timeInterval.Second;
                    uiInitiatedChanged = true;
                    if (TimeIntervalChanged != null){
                        TimeIntervalChanged();
                    }
                }
            }
        }

        void FirstPickerValueChanged(object sender, EventArgs e){
            if (uiInitiatedChanged){
                Interval = ETimeIntervals.UNDEFINED;
                if (TimeIntervalChanged != null){
                    TimeIntervalChanged();
                }
            }
        }

        void LastPickerValueChanged(object sender, EventArgs e){
            if (uiInitiatedChanged){
                Interval = ETimeIntervals.UNDEFINED;
                if (TimeIntervalChanged != null){
                    TimeIntervalChanged();
                }
            }
        }
    }
}
