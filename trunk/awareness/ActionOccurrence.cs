/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 03/10/2008
 * Time: 10:44
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

using Awareness.DB;

namespace Awareness
{
    public class ActionOccurrence : IComparable, Timerable {
        DalAction action;
        DateTime start;
        DateTime end;
        bool completed;
        DateTime deadline;

        public DalAction Action
        {
            get { return action; }
        }

        public DateTime Start
        {
            get { return start; }
        }

        public DateTime End
        {
            get { return end; }
        }

        public ActionOccurrence(DalAction action, TimeInterval interval){
            this.action = action;
            this.start = DataUtil.RemoveSeconds(interval.First);
            this.end = DataUtil.RemoveSeconds(interval.Second);
            if (action.HasReminder){
                deadline = this.start.AddMinutes(-action.ReminderDuration);
                completed = deadline < DateTime.Now;
            }
        }

        public int CompareTo(object obj){
            ActionOccurrence other = (ActionOccurrence) obj;
            int cmp = this.Start.CompareTo(other.Start);
            if (cmp != 0){
                return cmp;
            }
            cmp = this.End.CompareTo(other.End);
            if (cmp != 0){
                return cmp;
            }
            return string.Compare(this.Action.Name, other.Action.Name);
        }

        public bool Completed {
            get {
                return completed;
            }
            set {
                completed = value;
            }
        }

        public DateTime Deadline {
            get {
                return deadline;
            }
        }

        public override bool Equals(object obj){
            return CompareTo(obj) == 0;
        }
        
        public override int GetHashCode() {
            return (int) (this.start.Ticks + this.end.Ticks + Action.Name.GetHashCode());
        }
        
    }
}
