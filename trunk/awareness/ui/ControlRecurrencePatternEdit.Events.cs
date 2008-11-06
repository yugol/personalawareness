/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 02/10/2008
 * Time: 14:38
 * 
 */
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    partial class ControlRecurrencePatternEdit
    {
        void IntradayRadioCheckedChanged(object sender, EventArgs e)
        {
            if (processEvents && intradayRadio.Checked)
            {
                Debug.WriteLine("IntradayRadioCheckedChanged");
                Pattern = new RecurrencePattern(RecurrencePattern.STEP_INTRADAY, 60, 0);
                if (PatternChanged != null)
                {
                    PatternChanged();
                }
            }
        }
        
        void DailyRadioCheckedChanged(object sender, EventArgs e)
        {
            if (processEvents && dailyRadio.Checked)
            {
                Debug.WriteLine("DailyRadioCheckedChanged");
                Pattern = new RecurrencePattern(RecurrencePattern.STEP_DAILY, 1, 0);
                if (PatternChanged != null)
                {
                    PatternChanged();
                }
            }
        }
        
        void WeeklyRadioCheckedChanged(object sender, EventArgs e)
        {
            if (processEvents && weeklyRadio.Checked)
            {
                Debug.WriteLine("WeeklyRadioCheckedChanged");
                Pattern = new RecurrencePattern(RecurrencePattern.STEP_WEEKLY, 1, RecurrencePattern.DayOfWeek2When(DateTime.Now.DayOfWeek));
                if (PatternChanged != null)
                {
                    PatternChanged();
                }
            }
        }
        
        void MonthlyRadioCheckedChanged(object sender, EventArgs e)
        {
            if (processEvents && monthlyRadio.Checked)
            {
                Debug.WriteLine("MonthlyRadioCheckedChanged");
                Pattern = new RecurrencePattern(RecurrencePattern.STEP_MONTHLY, 1, (UInt32)DateTime.Now.Day);
                if (PatternChanged != null)
                {
                    PatternChanged();
                }
            }
        }
        
        void YearlyRadioCheckedChanged(object sender, EventArgs e)
        {
            if (processEvents && yearlyRadio.Checked)
            {
                Debug.WriteLine("YearlyRadioCheckedChanged");
                Pattern = new RecurrencePattern(RecurrencePattern.STEP_YEARLY, (UInt32)DateTime.Now.Month, (UInt32)DateTime.Now.Day);
                if (PatternChanged != null)
                {
                    PatternChanged();
                }
            }
        }
        
        void IntradayFrequencyComboValidating(object sender, CancelEventArgs e)
        {
            Debug.WriteLine("IntradayFrequencyComboValidating");
            try
            {
                UInt32 minutes = RecurrencePattern.ParseIntradayString(intradayFrequencyCombo.Text);
                if (minutes  < 1 || minutes > RecurrencePattern.ABSOLUTE_MAX_FREQUENCY)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception)
            {
                e.Cancel = true;
                errorProvider.SetError((Control) sender, "Can read formats like '2 hours 10 min' or '2:10'\n" +
                                       "with a total in minutes between 1 and " + 
                                       RecurrencePattern.ABSOLUTE_MAX_FREQUENCY);
            }
        }
        
        void DailyFrequencyBoxValidating(object sender, CancelEventArgs e)
        {
            Debug.WriteLine("DailyFrequencyBoxValidating");
            try
            {
                int f = int.Parse(dailyFrequencyBox.Text);
                if (f <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception)
            {
                e.Cancel = true;
                errorProvider.SetError((Control) sender, "Can only work with integer values greater than 0");
            }
        }
        
        void WeeklyFrequencyBoxValidating(object sender, CancelEventArgs e)
        {
            Debug.WriteLine("WeeklyFrequencyBoxValidating");
            try
            {
                int f = int.Parse(weeklyFrequencyBox.Text);
                if (f <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception)
            {
                e.Cancel = true;
                errorProvider.SetError((Control) sender, "Can only work with integer values greater than 0");
            }
        }
                
        void MonthlyFrequencyBoxValidating(object sender, CancelEventArgs e)
        {
            Debug.WriteLine("MonthlyFrequencyBoxValidating");
            try
            {
                int f = int.Parse(monthlyFrequencyBox.Text);
                if (f <= 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception)
            {
                e.Cancel = true;
                errorProvider.SetError((Control) sender, "Can only work with integer values greater than 0");
            }
        }
        
        void IntradayFrequencyComboValidated(object sender, EventArgs e)
        {
            if (pattern.Frequency != RecurrencePattern.ParseIntradayString(intradayFrequencyCombo.Text))
            {
                Debug.WriteLine("IntradayFrequencyComboValidated");
                Intraday2Pattern();
                if (PatternChanged != null)
                {
                    PatternChanged();
                }
            }
        }
        
        void DailyFrequencyRadioCheckedChanged(object sender, EventArgs e)
        {
            if (processEvents && dailyFrequencyRadio.Checked)
            {
                Debug.WriteLine("DailyFrequencyRadioCheckedChanged");
                Daily2Pattern();
                if (PatternChanged != null)
                {
                    PatternChanged();
                }
            }
        }
        
        void DailyFrequencyBoxValidated(object sender, EventArgs e)
        {
            if (pattern.Frequency != UInt32.Parse(dailyFrequencyBox.Text))
            {
                Debug.WriteLine("DailyFrequencyBoxValidated");
                Daily2Pattern();
                if (PatternChanged != null)
                {
                    PatternChanged();
                }
            }
        }

        void WeekdaysFrequencyRadioCheckedChanged(object sender, EventArgs e)
        {
            if (processEvents && weekdaysFrequencyRadio.Checked)
            {
                Debug.WriteLine("WeekdaysFrequencyRadioCheckedChanged");
                Daily2Pattern();
                if (PatternChanged != null)
                {
                    PatternChanged();
                }
            }
        }

        void WeeklyFrequencyBoxValidated(object sender, EventArgs e)
        {
            if (pattern.Frequency != UInt32.Parse(weeklyFrequencyBox.Text))
            {
                Debug.WriteLine("WeeklyFrequencyBoxValidated");
                Weekly2Pattern();
                if (PatternChanged != null)
                {
                    PatternChanged();
                }
            }
        }
        
        void MondayCheckCheckedChanged(object sender, EventArgs e)
        {
            if (processEvents)
            {
                Debug.WriteLine("MondayCheckCheckedChanged");        
                if (Weekly2Pattern())
                {
                    if (PatternChanged != null)
                    {
                        PatternChanged();
                    }
                }
            }
        }
        
        void TuesdayCheckCheckedChanged(object sender, EventArgs e)
        {
            if (processEvents)
            {
                Debug.WriteLine("TuesdayCheckCheckedChanged");        
                if (Weekly2Pattern())
                {
                    if (PatternChanged != null)
                    {
                        PatternChanged();
                    }
                }
            }
        }
        
        void WednesdayCheckCheckedChanged(object sender, EventArgs e)
        {
            if (processEvents)
            {
                Debug.WriteLine("WednesdayCheckCheckedChanged");        
                if (Weekly2Pattern())
                {
                    if (PatternChanged != null)
                    {
                        PatternChanged();
                    }
                }
            }
        }
        
        void ThursdayCheckCheckedChanged(object sender, EventArgs e)
        {
            if (processEvents)
            {
                Debug.WriteLine("ThursdayCheckCheckedChanged");        
                if (Weekly2Pattern())
                {
                    if (PatternChanged != null)
                    {
                        PatternChanged();
                    }
                }
            }
        }
        
        void FridayCheckCheckedChanged(object sender, EventArgs e)
        {
            if (processEvents)
            {
                Debug.WriteLine("FridayCheckCheckedChanged");        
                if (Weekly2Pattern())
                {
                    if (PatternChanged != null)
                    {
                        PatternChanged();
                    }
                }
            }
        }
        
        void SaturdayCheckCheckedChanged(object sender, EventArgs e)
        {
            if (processEvents)
            {
                Debug.WriteLine("SaturdayCheckCheckedChanged");        
                if (Weekly2Pattern())
                {
                    if (PatternChanged != null)
                    {
                        PatternChanged();
                    }
                }
            }
        }
        
        void SundayCheckCheckedChanged(object sender, EventArgs e)
        {
            if (processEvents)
            {
                Debug.WriteLine("SundayCheckCheckedChanged");        
                if (Weekly2Pattern())
                {
                    if (PatternChanged != null)
                    {
                        PatternChanged();
                    }
                }
            }
        }
        
        void MonthlyFrequencyBoxValidated(object sender, EventArgs e)
        {
            if (pattern.Frequency != UInt32.Parse(monthlyFrequencyBox.Text))
            {
                Debug.WriteLine("MonthlyFrequencyBoxValidated");
                Monthly2Pattern();
                if (PatternChanged != null)
                {
                    PatternChanged();
                }
            }
        }

        void MonthlyWhenComboSelectedIndexChanged(object sender, EventArgs e)
        {
            if (processEvents)
            {
                Debug.WriteLine("MonthlyWhenComboSelectedIndexChanged");
                Monthly2Pattern();
                if (PatternChanged != null)
                {
                    PatternChanged();
                }
            }
        }

        void YearlyFrequencyComboSelectedIndexChanged(object sender, EventArgs e)
        {
            if (processEvents)
            {
                Debug.WriteLine("YearlyFrequencyComboSelectedIndexChanged");
                Yearly2Pattern();
                if (PatternChanged != null)
                {
                    PatternChanged();
                }
            }
        }
        
        void YearlyWhenComboSelectedIndexChanged(object sender, EventArgs e)
        {
            if (processEvents)
            {
                Debug.WriteLine("YearlyWhenComboSelectedIndexChanged");
                Yearly2Pattern();
                if (PatternChanged != null)
                {
                    PatternChanged();
                }
            }
        }
        
    }
}
