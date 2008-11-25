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

using awareness.db;

namespace awareness.ui
{
    partial class ControlActionEdit {
        void NoteTextChanged(object sender, DalNote e){
            if (!action.HasNote){
                string text = ((Control) sender).Text;
                if (!string.IsNullOrEmpty(text)){
                    DbUtil.AttachNote(action);
                    action.Note.Text = text;
                    noteTextView.Note = action.Note;
                }
            }
        }

        void RecurrencePatternChanged(){
            action.RecurrencePattern = recurrencePatternEditControl.Pattern;
            DbUtil.UpdateActionTimeStamp(action);
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
                }
                action.IsTimePlanned = planTimeCheck.Checked;
                DbUtil.UpdateActionTimeStamp(action);
                Action = action;
            }
        }

        void SetEndCheckCheckedChanged(object sender, EventArgs e){
            if (processEvents){
                action.Type = (setEndCheck.Checked) ? (DalAction.TYPE_TASK) : (DalAction.TYPE_TODO);
                DbUtil.UpdateActionTimeStamp(action);
                Action = action;
                ControlActionsOverview.SetNodeImage(node);
            }
        }

        void StartDatePickerValueChanged(object sender, EventArgs e){
            if (processEvents){
                Ui2DataStartTime();
                if (true){
                }
                DbUtil.UpdateActionTimeStamp(action);
                Action = action;
            }
        }

        void EndDatePickerValueChanged(object sender, EventArgs e){
            if (processEvents){
                Ui2DataEndTime();
                DbUtil.UpdateActionTimeStamp(action);
                Action = action;
            }
        }

        void StartTimePickerValueChanged(object sender, EventArgs e){
            if (processEvents){
                Ui2DataStartTime();
                DbUtil.UpdateActionTimeStamp(action);
                Action = action;
            }
        }

        void EndTimePickerValueChanged(object sender, EventArgs e){
            if (processEvents){
                Ui2DataEndTime();
                DbUtil.UpdateActionTimeStamp(action);
                Action = action;
            }
        }

        void RepeatCheckCheckedChanged(object sender, EventArgs e){
            if (processEvents){
                action.IsRecurrent = repeatCheck.Checked;
                DbUtil.UpdateActionTimeStamp(action);
                Action = action;
            }
        }

        void IndefinitelyRadioCheckedChanged(object sender, EventArgs e){
            if (processEvents&&indefinitelyRadio.Checked){
                action.RepeatTimes = 0;
                DbUtil.UpdateActionTimeStamp(action);
                Action = action;
            }
        }

        void AnotherRadioCheckedChanged(object sender, EventArgs e){
            if (processEvents&&anotherRadio.Checked){
                action.RepeatTimes = (int) anotherUpDown.Value;
                action.IsRepeatNoOfTimes = true;
                DbUtil.UpdateActionTimeStamp(action);
                Action = action;
            }
        }

        void UntilRadioCheckedChanged(object sender, EventArgs e){
            if (processEvents&&untilRadio.Checked){
                action.RepeatUntil = untilPicker.Value;
                action.IsRepeatNoOfTimes = false;
                DbUtil.UpdateActionTimeStamp(action);
                Action = action;
            }
        }

        void AnotherUpDownValueChanged(object sender, EventArgs e){
            if (processEvents){
                action.RepeatTimes = (int) anotherUpDown.Value;
                DbUtil.UpdateActionTimeStamp(action);
                Action = action;
            }
        }

        void UntilPickerValueChanged(object sender, EventArgs e){
            if (processEvents){
                action.RepeatUntil = untilPicker.Value;
                DbUtil.UpdateActionTimeStamp(action);
                Action = action;
            }
        }

        void ShowReminderCheckCheckedChanged(object sender, EventArgs e){
            if (processEvents){
                action.HasWindowReminder = showReminderCheck.Checked;
                DbUtil.UpdateActionTimeStamp(action);
                Action = action;
            }
        }

        void ReminderDurationComboValidating(object sender, System.ComponentModel.CancelEventArgs e){
            Debug.WriteLine("CommandSelectorLeave");
        }

        void ReminderDurationComboTextChanged(object sender, EventArgs e){
            Debug.WriteLine("CommandSelectorLeave");
        }

        void RunCommandCheckCheckedChanged(object sender, EventArgs e){
            if (processEvents){
                action.HasCommandReminder = runCommandCheck.Checked;
                DbUtil.UpdateActionTimeStamp(action);
                Action = action;
            }
        }

        void PlaySoundCheckCheckedChanged(object sender, EventArgs e){
            if (processEvents){
                action.HasSoundReminder = playSoundCheck.Checked;
                DbUtil.UpdateActionTimeStamp(action);
                Action = action;
            }
        }

        void CommandSelectorCommandChanged(object sender, EventArgs e){
            if (processEvents){
                action.ReminderCommand = commandSelector.Command;
                DbUtil.UpdateActionTimeStamp(action);
                Action = action;
            }
        }

        void CommandSelectorTestClick(object sender, EventArgs e){
            Launcher.ExecuteComand(action.ReminderCommand);
        }

        void SoundSelectorCommandChanged(object sender, EventArgs e){
            if (processEvents){
                action.ReminderSound = soundSelector.Command;
                DbUtil.UpdateActionTimeStamp(action);
                Action = action;
            }
        }

        void SoundSelectorTestClick(object sender, EventArgs e){
            Launcher.PlayMediaFile(action.ReminderSound);
        }
    }
}
