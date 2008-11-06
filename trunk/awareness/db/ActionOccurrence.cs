/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 03/10/2008
 * Time: 10:44
 *
 */
using System;

namespace awareness.db
{
    public class ActionOccurrence : IComparable {
        DalAction action;
        DateTime start;
        DateTime end;

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
            this.start = DbUtil.RemoveSeconds(interval.First);
            this.end = DbUtil.RemoveSeconds(interval.Second);
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
            return this.Action.Name.CompareTo(other.Action.Name);
        }
    }
}
