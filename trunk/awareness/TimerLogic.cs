/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 24/11/2008
 * Time: 12:13
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

namespace awareness.ui
{
    public delegate void TaskCompletedHandler(object sender, ITimerable task);

    public class TimerLogic {
        public event EventHandler Tick;
        public event TaskCompletedHandler Completed;

        private Timer timer;
        private IList<ITimerable> schedule = new List<ITimerable>();

        public TimerLogic(){
            timer = new Timer();
            timer.Interval = 250;
            timer.Tick += new EventHandler(TimerTick);
        }
        
        public int Interval {
            get { return timer.Interval; }
            set { timer.Interval = value; }
        }

        public void Add(ITimerable task) {
            schedule.Add(task);
        }

        public void Remove(ITimerable task) {
            schedule.Remove(task);
        }

        public void Clear() {
            schedule.Clear();
        }

        public void Start() {
            timer.Start();
        }

        public void Cancel() {
            timer.Stop();
        }

        public void TimerTick(object sender, EventArgs e) {
            if (Tick != null){
                Tick(this, e);
            }
            
            if (Completed != null) {
                DateTime now = DateTime.Now;
                foreach (ITimerable task in schedule){
                    if (!task.Completed&&IsTimeFor(task, now)){
                        task.Completed = true;
                        Completed(this, task);
                    }
                }
            }
        }

        bool IsTimeFor(ITimerable task, DateTime now) {
            if (now.Date == task.Deadline.Date){
                if (now.Hour == task.Deadline.Hour&&now.Minute == task.Deadline.Minute){
                    if (now.Second >= task.Deadline.Second){
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
