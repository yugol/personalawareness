/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 24/11/2008
 * Time: 09:55
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
using System.Drawing;
using System.Windows.Forms;

namespace Awareness.UI
{
    public partial class FormTeaTimer : Form {
        public enum EPresentationMode { EDIT, RUN }

        private EPresentationMode mode;
        private BasicTimerable task = null;

        public EPresentationMode Mode {
            get { return mode; }
            set
            {
                mode = value;
                switch (mode){
                case EPresentationMode.EDIT:
                    hoursBox.Enabled = true;
                    minutesBox.Enabled = true;
                    secondsBox.Enabled = true;
                    actionButton.Text = "Start";
                    resetButton.Enabled = true;
                    break;
                case EPresentationMode.RUN:
                    hoursBox.Enabled = false;
                    minutesBox.Enabled = false;
                    secondsBox.Enabled = false;
                    actionButton.Text = "Stop";
                    resetButton.Enabled = false;
                    break;
                }
            }
        }

        private TimerLogic timerLogic = null;

        public FormTeaTimer(){
            InitializeComponent();
            timerLogic = new TimerLogic();
            Mode = EPresentationMode.EDIT;
            ResetUi();
            timerLogic.Tick += new EventHandler(TimerLogicTick);
            timerLogic.Completed += new TaskCompletedHandler(TimerLogicCompleted);
        }

        void FormTeaTimerFormClosing(object sender, FormClosingEventArgs e){
            e.Cancel = true;
            Visible = false;
        }

        void ResetUi() {
            hoursBox.Value = 0;
            minutesBox.Value = 0;
            secondsBox.Value = 0;
        }

        void ResetTask() {
            task = null;
            Mode = EPresentationMode.EDIT;
        }

        void ResetButtonClick(object sender, EventArgs e){
            ResetUi();
        }

        void ActionButtonClick(object sender, EventArgs e){
            switch (Mode){
            case EPresentationMode.EDIT:
                TimeSpan duration = Ui2TimeSpan();
                if (duration.TotalSeconds >= 1){
                    timerLogic.Clear();
                    task = new BasicTimerable(DateTime.Now.Add(duration));
                    timerLogic.Add(task);
                    timerLogic.Start();
                    Mode = EPresentationMode.RUN;
                }
                break;

            case EPresentationMode.RUN:
                timerLogic.Cancel();
                ResetTask();
                break;
            }
        }

        void TimerLogicTick(object sender, EventArgs e) {
            if (task != null){
                TimeSpan remaining = task.Deadline.Subtract(DateTime.Now);
                TimeSpan2Ui(remaining);
            }
        }

        void TimerLogicCompleted(object sender, Timerable e) {
            MessageBox.Show("Time is up", "Tea Timer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetTask();
        }

        TimeSpan Ui2TimeSpan() {
            return new TimeSpan((int) hoursBox.Value, (int) minutesBox.Value, (int) secondsBox.Value);
        }

        void TimeSpan2Ui(TimeSpan delta) {
            if (delta.TotalSeconds <= 0){
                ResetUi();
            } else {
                secondsBox.Value = delta.Seconds;
                minutesBox.Value = delta.Minutes;
                hoursBox.Value = (int) delta.TotalHours;
            }
        }
    }
}
