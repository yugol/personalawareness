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
 * Date: 02/10/2008
 * Time: 11:48
 *
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Awareness.DB;

namespace Awareness.UI
{
    public delegate void PatternChangedHandler();

    public partial class ControlRecurrencePatternEdit : UserControl {
        public event PatternChangedHandler PatternChanged;

        bool processEvents = true;

        RecurrencePattern pattern;
        internal RecurrencePattern Pattern
        {
            get { return pattern; }
            set
            {
                processEvents = false;
                pattern = value;
                Pattern2Ui();
                processEvents = true;
            }
        }

        public ControlRecurrencePatternEdit(){
            InitializeComponent();
        }

        void Pattern2Ui(){
            intradayPanel.Visible = intradayRadio.Checked = pattern.Step == RecurrencePattern.STEP_INTRADAY;
            dailyPanel.Visible = dailyRadio.Checked = pattern.Step == RecurrencePattern.STEP_DAILY;
            weeklyPanel.Visible = weeklyRadio.Checked = pattern.Step == RecurrencePattern.STEP_WEEKLY;
            monthlyPanel.Visible = monthlyRadio.Checked = pattern.Step == RecurrencePattern.STEP_MONTHLY;
            yearlyPanel.Visible = yearlyRadio.Checked = pattern.Step == RecurrencePattern.STEP_YEARLY;

            switch (pattern.Step){
            case RecurrencePattern.STEP_INTRADAY:
                intradayFrequencyCombo.Text = pattern.ToFrequencyString();
                break;
            case RecurrencePattern.STEP_DAILY:
                if (pattern.Frequency == 0){
                    dailyFrequencyRadio.Checked = false;
                    dailyFrequencyBox.Text = "1";
                    dailyFrequencyBox.Enabled = false;
                    weekdaysFrequencyRadio.Checked = true;
                } else {
                    dailyFrequencyRadio.Checked = true;
                    dailyFrequencyBox.Text = pattern.Frequency.ToString();
                    dailyFrequencyBox.Enabled = true;
                    weekdaysFrequencyRadio.Checked = false;
                }
                break;
            case RecurrencePattern.STEP_WEEKLY:
                weeklyFrequencyBox.Text = pattern.Frequency.ToString();
                mondayCheck.Checked = (pattern.When & RecurrencePattern.WHEN_MONDAY) != 0;
                tuesdayCheck.Checked = (pattern.When & RecurrencePattern.WHEN_TUESDAY) != 0;
                wednesdayCheck.Checked = (pattern.When & RecurrencePattern.WHEN_WEDNESDAY) != 0;
                thursdayCheck.Checked = (pattern.When & RecurrencePattern.WHEN_THURSDAY) != 0;
                fridayCheck.Checked = (pattern.When & RecurrencePattern.WHEN_FRIDAY) != 0;
                saturdayCheck.Checked = (pattern.When & RecurrencePattern.WHEN_SATURDAY) != 0;
                sundayCheck.Checked = (pattern.When & RecurrencePattern.WHEN_SUNDAY) != 0;
                break;
            case RecurrencePattern.STEP_MONTHLY:
                monthlyFrequencyBox.Text = pattern.Frequency.ToString();
                monthlyWhenCombo.SelectedIndex = (int) pattern.When - 1;
                break;
            case RecurrencePattern.STEP_YEARLY:
                yearlyFrequencyCombo.SelectedIndex = (int) pattern.Frequency - 1;
                yearlyWhenCombo.SelectedIndex = (int) pattern.When - 1;
                break;
            }

            errorProvider.Clear();
        }

        void Intraday2Pattern(){
            Pattern = new RecurrencePattern(RecurrencePattern.STEP_INTRADAY,
                                            RecurrencePattern.ParseIntradayString(intradayFrequencyCombo.Text),
                                            0);
        }

        void Daily2Pattern(){
            UInt32 frequency = RecurrencePattern.FREQUENCY_WEEKDAYS;
            if (dailyFrequencyRadio.Checked){
                frequency = UInt32.Parse(dailyFrequencyBox.Text);
            }
            Pattern = new RecurrencePattern(RecurrencePattern.STEP_DAILY, frequency, 0);
        }

        bool Weekly2Pattern(){
            UInt32 frequency = UInt32.Parse(weeklyFrequencyBox.Text);

            UInt32 when = 0;
            if (mondayCheck.Checked){
                when |= RecurrencePattern.WHEN_MONDAY;
            }
            if (tuesdayCheck.Checked){
                when |= RecurrencePattern.WHEN_TUESDAY;
            }
            if (wednesdayCheck.Checked){
                when |= RecurrencePattern.WHEN_WEDNESDAY;
            }
            if (thursdayCheck.Checked){
                when |= RecurrencePattern.WHEN_THURSDAY;
            }
            if (fridayCheck.Checked){
                when |= RecurrencePattern.WHEN_FRIDAY;
            }
            if (saturdayCheck.Checked){
                when |= RecurrencePattern.WHEN_SATURDAY;
            }
            if (sundayCheck.Checked){
                when |= RecurrencePattern.WHEN_SUNDAY;
            }

            try {
                Pattern = new RecurrencePattern(RecurrencePattern.STEP_WEEKLY, frequency, when);
                return true;
            } catch (Exception)  {
                Pattern = new RecurrencePattern(RecurrencePattern.STEP_WEEKLY, frequency, pattern.When);
                return false;
            }
        }

        void Monthly2Pattern(){
            Pattern = new RecurrencePattern(RecurrencePattern.STEP_MONTHLY,
                                            UInt32.Parse(monthlyFrequencyBox.Text),
                                            (UInt32) monthlyWhenCombo.SelectedIndex + 1);
        }

        void Yearly2Pattern(){
            Pattern = new RecurrencePattern(RecurrencePattern.STEP_YEARLY,
                                            (UInt32) yearlyFrequencyCombo.SelectedIndex,
                                            (UInt32) yearlyWhenCombo.SelectedIndex + 1);
        }
    }
}
