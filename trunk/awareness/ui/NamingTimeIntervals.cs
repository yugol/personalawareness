/*
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

/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 12/09/2008
 * Time: 12:47
 *
 */
using System;
using System.Collections.Generic;

using awareness.db;

namespace awareness.ui
{
    public struct NamingTimeIntervals : IEquatable<NamingTimeIntervals>
    {
        Intervals value;
        string name;

        public Intervals Value
        {
            get { return value; }
        }

        public string Name
        {
            get { return name; }
        }


        public NamingTimeIntervals(Intervals value, string name){
            this.value = value;
            this.name = name;
        }

        #region Equals and GetHashCode implementation
        // The code in this region is useful if you want to use this structure in collections.
        // If you don't need it, you can just remove the region and the ": IEquatable<IntervalName>" declaration.

        public override bool Equals(object obj){
            if (obj is NamingTimeIntervals){
                return Equals((NamingTimeIntervals) obj); // use Equals method below
            } else {
                return false;
            }
        }

        public bool Equals(NamingTimeIntervals other){
            // add comparisions for all members here
            return this.value == other.value;
        }

        public override int GetHashCode(){
            // combine the hash codes of all members here (e.g. with XOR operator ^)
            return value.GetHashCode();
        }

        public static bool operator == (NamingTimeIntervals lhs, NamingTimeIntervals rhs){
            return lhs.Equals(rhs);
        }

        public static bool operator != (NamingTimeIntervals lhs, NamingTimeIntervals rhs){
            return !(lhs.Equals(rhs)); // use operator == and negate result
        }

        #endregion

        public override string ToString(){
            return Name;
        }

        static List<NamingTimeIntervals> timeIntervalNames = null;

        public static List<NamingTimeIntervals> GetNames(){
            if (timeIntervalNames == null){
                timeIntervalNames = new List<NamingTimeIntervals>();
                timeIntervalNames.Add(new NamingTimeIntervals(Intervals.TODAY, "Today"));
                timeIntervalNames.Add(new NamingTimeIntervals(Intervals.THIS_WEEK, "This Week"));
                timeIntervalNames.Add(new NamingTimeIntervals(Intervals.LAST_WEEK, "Last Week"));
                timeIntervalNames.Add(new NamingTimeIntervals(Intervals.THIS_MONTH, "This Month"));
                timeIntervalNames.Add(new NamingTimeIntervals(Intervals.LAST_MONTH, "Last Month"));
                timeIntervalNames.Add(new NamingTimeIntervals(Intervals.THIS_QUARTER, "This Quarter"));
                timeIntervalNames.Add(new NamingTimeIntervals(Intervals.LAST_QUARTER, "Last Quarter"));
                timeIntervalNames.Add(new NamingTimeIntervals(Intervals.THIS_YEAR, "This Year"));
                timeIntervalNames.Add(new NamingTimeIntervals(Intervals.LAST_YEAR, "Last Year"));
                timeIntervalNames.Add(new NamingTimeIntervals(Intervals.ALL, "All"));
                timeIntervalNames.Add(new NamingTimeIntervals(Intervals.UNDEFINED, "Custom"));
            }
            return timeIntervalNames;
        }
    }
}
