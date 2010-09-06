/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 28/09/2008
 * Time: 19:23
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
using System.Windows.Forms;
using Awareness.DB;

namespace Awareness.UI
{
    public partial class ControlActionEdit : UserControl
    {
        bool processEvents = true;

        TreeNode node = null;

        public TreeNode Node
        {
            set {
                node = value;
                if (node != null) {
                    Action = (DalAction) node.Tag;
                } else {
                    Action = null;
                }
            }
        }

        DalAction action;

        public DalAction Action
        {
            get {
                return action;
            }
            set {
                processEvents = false;
                action = value;

                errorProvider.Clear();
                if (action == null) {
                    Visible = false;
                } else {
                    Visible = true;
                    Data2UiPlan();
                    Data2UiGeneral();
                }

                processEvents = true;
            }
        }

        public ControlActionEdit()
        {
            InitializeComponent();

            Util.SetMinMaxDatesAndShortFormatFor(startDatePicker);
            Util.SetMinMaxDatesAndShortFormatFor(endDatePicker);
            Util.SetMinMaxDatesAndLongFormatFor(untilPicker);

            recurrencePatternEditControl.PatternChanged += new PatternChangedHandler(RecurrencePatternChanged);
        }

        void Data2UiGeneral()
        {
            switch (action.Type) {
            case DalAction.TYPE_TODO:
                setEndCheck.Checked = false;
                SetTodoUi();
                break;
            case DalAction.TYPE_TASK:
                setEndCheck.Checked = true;
                SetTaskUi();
                break;
            case DalAction.TYPE_GROUP:
                SetGroupUi();
                break;
            default:
                throw new ApplicationException("Unknown action type");
            }
            noteControl.Note = action.Note;
        }

        void Data2UiPlan()
        {
            startDatePicker.Value = action.Start;
            endDatePicker.Value = action.End;
            startTimePicker.Value = action.Start;
            endTimePicker.Value = action.End;
            planTimeCheck.Checked = action.IsTimePlanned;

            repeatCheck.Checked = action.IsRecurrent;
            recurrencePatternEditControl.Pattern = action.RecurrencePattern;

            indefinitelyRadio.Checked = false;
            anotherRadio.Checked = false;
            untilRadio.Checked = false;
            anotherUpDown.Enabled = false;
            untilPicker.Enabled = false;

            SetRecurrenceConstraints();

            if (action.IsRepeatIndefinitely) {
                indefinitelyRadio.Checked = true;

                anotherUpDown.Value = 1;
                untilPicker.Value = untilPicker.MinDate;
            } else {
                if (action.IsRepeatNoOfTimes) {
                    anotherRadio.Checked = true;
                    anotherUpDown.Enabled = true;
                } else {
                    untilRadio.Checked = true;
                    untilPicker.Enabled = true;
                }
                anotherUpDown.Value = action.RepeatTimes;
                untilPicker.Value = action.RepeatUntil;
            }
        }

        void SetTodoUi()
        {
            startDatePicker.Enabled = true;
            endDatePicker.Enabled = false;

            startTimePicker.Visible = action.IsTimePlanned;
            endTimePicker.Visible = action.IsTimePlanned;
            startTimePicker.Enabled = true;
            endTimePicker.Enabled = false;

            planTimeCheck.Visible = true;
            setEndCheck.Visible = true;
            repeatCheck.Visible = true;

            durationValueLabel.Text = "N/A";

            recurrenceGroup.Visible = action.IsRecurrent;
        }

        void SetTaskUi()
        {
            startDatePicker.Enabled = true;
            endDatePicker.Enabled = true;

            startTimePicker.Visible = action.IsTimePlanned;
            endTimePicker.Visible = action.IsTimePlanned;
            startTimePicker.Enabled = true;
            endTimePicker.Enabled = true;

            planTimeCheck.Visible = true;
            setEndCheck.Visible = true;
            repeatCheck.Visible = true;

            UpdateDuration();

            recurrenceGroup.Visible = action.IsRecurrent;
        }

        void SetGroupUi()
        {
            startDatePicker.Enabled = false;
            endDatePicker.Enabled = false;

            startTimePicker.Visible = true;
            endTimePicker.Visible = true;
            startTimePicker.Enabled = false;
            endTimePicker.Enabled = false;

            planTimeCheck.Visible = false;
            setEndCheck.Visible = false;
            repeatCheck.Visible = false;

            UpdateDuration();

            recurrenceGroup.Visible = false;
        }

        void UpdateDuration()
        {
            durationValueLabel.Text = Util.FormatTimeSpan(action.End.Subtract(action.Start));
        }

        void Ui2DataStartTime()
        {
            DateTime start = new DateTime(startDatePicker.Value.Year,
                                          startDatePicker.Value.Month,
                                          startDatePicker.Value.Day,
                                          startTimePicker.Value.Hour,
                                          startTimePicker.Value.Minute,
                                          0);
            action.Start = start;
            if (action.Type == DalAction.TYPE_TODO) {
                action.End = start;
            }
        }

        void Ui2DataEndTime()
        {
            DateTime end = new DateTime(endDatePicker.Value.Year,
                                        endDatePicker.Value.Month,
                                        endDatePicker.Value.Day,
                                        endTimePicker.Value.Hour,
                                        endTimePicker.Value.Minute,
                                        0);
            action.End = end;
        }

        void SetRecurrenceConstraints()
        {
            try {
                untilPicker.MinDate = action.RecurrencePattern.NextOccurrence(action.Start);
            } catch (Exception) {
                untilPicker.MinDate = untilPicker.MaxDate;
            }
        }

        public void UpdateAction()
        {
            if (action != null) {
                Controller.Storage.UpdateAction(action, noteControl.Note);
            }
        }

    }
}
