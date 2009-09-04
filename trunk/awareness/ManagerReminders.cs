/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 24/11/2008
 * Time: 22:26
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
using System.Collections.Generic;
using System.Windows.Forms;

using Awareness.UI;
using Awareness.DB;

namespace Awareness
{
    public class ManagerReminders
    {

        private static ManagerReminders instance = null;
        internal static ManagerReminders Instance
        {
            get {
                return instance;
            }
        }

        internal static void CreateInstance()
        {
            if (instance == null) {
                instance = new ManagerReminders();
            }
        }

        private Timer timer;
        private TimerLogic timerLogic;
        private FormReminders remindersWindow;

        ManagerReminders()
        {
            timer = new Timer();
            timer.Interval = 10000000;

            timerLogic = new TimerLogic();
            timerLogic.Interval = 5000;

            remindersWindow = new FormReminders();

            timer.Tick += new EventHandler(TimerTick); // periodically read reminders

            timerLogic.Tick += new EventHandler(remindersWindow.RefreshDueTimes);
            timerLogic.Completed += new TaskCompletedHandler(TaskCompleted);

            Controller.StorageOpened += new DataChangedHandler(StorageOpened);
            Controller.StorageClosing += new DataChangedHandler(StorageClosing);

            timer.Start();
            timerLogic.Start();
            remindersWindow.Clear();
        }

        void StorageOpened()
        {
            ReadReminders();
            Controller.Storage.ActionsChanged += new DataChangedHandler(ReadReminders);
        }

        void StorageClosing()
        {
            Hide();
        }

        internal void Display()
        {
            remindersWindow.Visible = false;
            remindersWindow.Visible = true;
        }

        void Hide()
        {
            remindersWindow.Visible = false;
        }

        void TimerTick(object sender, EventArgs e)
        {
            ReadReminders();
        }

        private void ReadReminders()
        {
            TimeInterval interval = new TimeInterval(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(1));

            timerLogic.Clear();
            remindersWindow.Clear();

            List<ActionOccurrence> occurrences = Controller.Storage.GetUncheckedActionOccurencesWithReminder(interval);
            foreach (ActionOccurrence occurrence in occurrences) {
                remindersWindow.Add(occurrence);
                timerLogic.Add(occurrence);
            }

            remindersWindow.RefreshDueTimes(null, null);
        }

        private void TaskCompleted(object sender, Timerable task)
        {
            ActionOccurrence occurrence = (ActionOccurrence) task;
            if (occurrence.Action.HasSoundReminder) {
                string command = occurrence.Action.ReminderSound;
                Launcher.PlayMediaFile(command);
            }
            if (occurrence.Action.HasCommandReminder) {
                string command = occurrence.Action.ReminderCommand;
                Launcher.ExecuteComand(command);
            }
            if (occurrence.Action.HasWindowReminder) {
                MessageBox.Show(occurrence.Action.Name,
                                "Reminder",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }
    }
}
