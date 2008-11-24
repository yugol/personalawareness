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

namespace awareness.ui
{
    public partial class FormTeaTimer : Form {
        public enum PresentationMode { EDIT, RUN }

        private PresentationMode mode;

        public PresentationMode Mode {
            get { return mode; }
            set
            {
                mode = value;
                switch (mode){
                case PresentationMode.EDIT:
                    hoursBox.Enabled = true;
                    minutesBox.Enabled = true;
                    secondsBox.Enabled = true;
                    actionButton.Text = "Start";
                    resetButton.Enabled = true;
                    break;
                case PresentationMode.RUN:
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
            Mode = PresentationMode.EDIT;
            ResetUi();
            timerLogic.Tick += new EventHandler(TimerLogicTick);
            timerLogic.Completed += new EventHandler(TimerLogicCompleted);
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

        void ResetButtonClick(object sender, EventArgs e){
            ResetUi();
        }

        void ActionButtonClick(object sender, EventArgs e){
            switch (Mode){
            case PresentationMode.EDIT:
                TimeSpan duration = Ui2TimeSpan();
                if (duration.TotalSeconds >= 1){
                    timerLogic.Deadline = DateTime.Now.Add(duration);
                    timerLogic.Start();
                    Mode = PresentationMode.RUN;
                }
                break;

            case PresentationMode.RUN:
                timerLogic.Cancel();
                Mode = PresentationMode.EDIT;
                break;
            }
        }

        void TimerLogicTick(object sender, EventArgs e) {
            TimeSpan remaining = timerLogic.Deadline.Subtract(DateTime.Now);
            TimeSpan2Ui(remaining);
        }

        void TimerLogicCompleted(object sender, EventArgs e) {
            MessageBox.Show("Time is up", "Tea Timer", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Mode = PresentationMode.EDIT;
        }

        TimeSpan Ui2TimeSpan() {
            return new TimeSpan((int) hoursBox.Value, (int) minutesBox.Value, (int) secondsBox.Value);
        }

        void TimeSpan2Ui(TimeSpan delta) {
            secondsBox.Value = delta.Seconds;
            minutesBox.Value = delta.Minutes;
            hoursBox.Value = (int) delta.TotalHours;
        }
    }
}
