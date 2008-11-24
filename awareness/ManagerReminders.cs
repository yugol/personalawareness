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
using System.Windows.Forms;

using awareness.ui;
using awareness.db;

namespace awareness
{
    public class ManagerReminders
    {
        private static TimerLogic timerLogic;
        private static FormReminders remindersWindow;
        
        static ManagerReminders() {
            timerLogic = new TimerLogic();
            timerLogic.Interval = 10000;
            remindersWindow = new FormReminders();
            
            timerLogic.Tick += new EventHandler(remindersWindow.RefreshDueTimes);
            timerLogic.Completed += new TaskCompletedHandler(TaskCompleted);
            
            DbUtil.DataContextChanged += new DatabaseChangedHandler(ReadReminders);
            DbUtil.ActionsChanged += new DatabaseChangedHandler(ReadReminders);
            
            timerLogic.Start();
        }

        public static void Display() {
            remindersWindow.Visible = false;
            remindersWindow.Visible = true;
        }
        
        private static void ReadReminders() {
            
        }
        
        private static void TaskCompleted(object sender, ITimerable task) {
            
        }
    }
}
