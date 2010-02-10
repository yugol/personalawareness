/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 30/09/2008
 * Time: 20:12
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
using System.Diagnostics;
using System.Windows.Forms;

using Awareness.DB;

namespace Awareness.UI
{
    partial class ControlActionEdit {

        void RecurrencePatternChanged(){
            action.RecurrencePattern = recurrencePatternEditControl.Pattern;
            UpdateAction();
            Action = action;
        }

        void PlanTimeCheckCheckedChanged(object sender, EventArgs e){
            if (processEvents){
                if (planTimeCheck.Checked){
                    processEvents = false;
                    DateTime now = DateTime.Now;
                    startTimePicker.Value = now;
                    endTimePicker.Value = now;
                    Ui2DataStartTime();
                    Ui2DataEndTime();
                    processEvents = true;
                } else {
                    action.HasWindowReminder = false;
                    action.HasCommandReminder = false;
                    action.HasSoundReminder = false;
                }
                action.IsTimePlanned = planTimeCheck.Checked;
                UpdateAction();
                Action = action;
            }
        }

        void SetEndCheckCheckedChanged(object sender, EventArgs e){
            if (processEvents){
                action.Type = (setEndCheck.Checked) ? (DalAction.TYPE_TASK) : (DalAction.TYPE_TODO);
                UpdateAction();
                Action = action;
                ControlActionsOverview.SetNodeImage(node);
            }
        }

        void StartDatePickerValueChanged(object sender, EventArgs e){
            if (processEvents){
                Ui2DataStartTime();
                UpdateAction();
                Action = action;
            }
        }

        void EndDatePickerValueChanged(object sender, EventArgs e){
            if (processEvents){
                Ui2DataEndTime();
                UpdateAction();
                Action = action;
            }
        }

        void StartTimePickerValueChanged(object sender, EventArgs e){
            if (processEvents){
                Ui2DataStartTime();
                UpdateAction();
                Action = action;
            }
        }

        void EndTimePickerValueChanged(object sender, EventArgs e){
            if (processEvents){
                Ui2DataEndTime();
                UpdateAction();
                Action = action;
            }
        }

        void RepeatCheckCheckedChanged(object sender, EventArgs e){
            if (processEvents){
                action.IsRecurrent = repeatCheck.Checked;
                UpdateAction();
                Action = action;
            }
        }

        void IndefinitelyRadioCheckedChanged(object sender, EventArgs e){
            if (processEvents&&indefinitelyRadio.Checked){
                action.RepeatTimes = 0;
                UpdateAction();
                Action = action;
            }
        }

        void AnotherRadioCheckedChanged(object sender, EventArgs e){
            if (processEvents&&anotherRadio.Checked){
                action.RepeatTimes = (int) anotherUpDown.Value;
                action.IsRepeatNoOfTimes = true;
                UpdateAction();
                Action = action;
            }
        }

        void UntilRadioCheckedChanged(object sender, EventArgs e){
            if (processEvents&&untilRadio.Checked){
                action.RepeatUntil = untilPicker.Value;
                action.IsRepeatNoOfTimes = false;
                UpdateAction();
                Action = action;
            }
        }

        void AnotherUpDownValueChanged(object sender, EventArgs e){
            if (processEvents){
                action.RepeatTimes = (int) anotherUpDown.Value;
                UpdateAction();
                Action = action;
            }
        }

        void UntilPickerValueChanged(object sender, EventArgs e){
            if (processEvents){
                action.RepeatUntil = untilPicker.Value;
                UpdateAction();
                Action = action;
            }
        }
    }
}
