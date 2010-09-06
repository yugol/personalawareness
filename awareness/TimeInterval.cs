/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 12/09/2008
 * Time: 10:58
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

namespace Awareness
{
    public enum ETimeIntervals { TODAY, THIS_WEEK, LAST_WEEK, THIS_MONTH, LAST_MONTH, THIS_QUARTER, LAST_QUARTER, THIS_YEAR, LAST_YEAR, ALL, UNDEFINED }

    public class TimeInterval {
        DateTime first;
        public DateTime First
        {
            get { return first; }
        }

        DateTime second;
        public DateTime Second
        {
            get { return second; }
        }

        public TimeInterval(){
        }

        public TimeInterval(DateTime from, DateTime to){
            if (from.CompareTo(to) > 0){
                throw new ArgumentException("First value cannot be bigger than the second one");
            }
            this.first = from;
            this.second = to;
        }

        public TimeInterval(DateTime from, TimeSpan duration)
            : this(from, from.Add(duration)) {
        }

        public TimeInterval Intersect(TimeInterval other){
            if (this.first.CompareTo(other.first) < 0){
                if (this.second.CompareTo(other.first) < 0){
                    return null;
                } else {
                    if (this.second.CompareTo(other.second) < 0){
                        return new TimeInterval(other.first, this.second);
                    } else {
                        return new TimeInterval(other.first, other.second);
                    }
                }
            } else {
                if (this.first.CompareTo(other.second) <= 0){
                    if (this.second.CompareTo(other.second) < 0){
                        return new TimeInterval(this.first, this.second);
                    } else {
                        return new TimeInterval(this.first, other.second);
                    }
                } else {
                    return null;
                }
            }
        }

        public static TimeInterval CreateInterval(ETimeIntervals interval){
            return CreateInterval(interval, DateTime.Now);
        }

        public static TimeInterval CreateInterval(ETimeIntervals interval, DateTime today){
            TimeInterval timeInterval = new TimeInterval();
            DateTime temp;

            switch (interval){
            case ETimeIntervals.TODAY:
                timeInterval.first = today.Date;
                timeInterval.second = new DateTime(today.Year, today.Month, today.Day, 23, 59, 59, 999);
                break;
            case ETimeIntervals.THIS_WEEK:
                SetWeek(timeInterval, today);
                break;
            case ETimeIntervals.LAST_WEEK:
                SetWeek(timeInterval, today.AddDays(-7));
                break;
            case ETimeIntervals.THIS_MONTH:
                timeInterval.first = new DateTime(today.Year, today.Month, 1).Date;
                temp = timeInterval.first.AddMonths(1).AddDays(-1);
                timeInterval.second = new DateTime(temp.Year, temp.Month, temp.Day, 23, 59, 59, 999);
                break;
            case ETimeIntervals.LAST_MONTH:
                temp = new DateTime(today.Year, today.Month, 1).Date;
                timeInterval.first = temp.AddMonths(-1);
                temp = temp.AddDays(-1);
                timeInterval.second = new DateTime(temp.Year, temp.Month, temp.Day, 23, 59, 59, 999);
                break;
            case ETimeIntervals.THIS_QUARTER:
                temp = new DateTime(today.Year, today.Month, 1).Date;
                timeInterval.first = temp.AddMonths(-2);
                temp = temp.AddMonths(1).AddDays(-1);
                timeInterval.second = new DateTime(temp.Year, temp.Month, temp.Day, 23, 59, 59, 999);
                break;
            case ETimeIntervals.LAST_QUARTER:
                temp = new DateTime(today.Year, today.Month, 1);
                timeInterval.first = temp.AddMonths(-5);
                temp = temp.AddMonths(-2).AddDays(-1);
                timeInterval.second = new DateTime(temp.Year, temp.Month, temp.Day, 23, 59, 59, 999);
                break;
            case ETimeIntervals.THIS_YEAR:
                timeInterval.first = new DateTime(today.Year, 1, 1);
                timeInterval.second = new DateTime(today.Year, 12, 31, 23, 59, 59, 999);
                break;
            case ETimeIntervals.LAST_YEAR:
                timeInterval.first = new DateTime(today.Year - 1, 1, 1);
                timeInterval.second = new DateTime(today.Year - 1, 12, 31, 23, 59, 59, 999);
                break;
            case ETimeIntervals.ALL:
                timeInterval.first = Configuration.MIN_DATE_TIME;
                timeInterval.second = Configuration.MAX_DATE_TIME;
                break;
            }

            return timeInterval;
        }

        static void SetWeek(TimeInterval timeInterval, DateTime today){
            DateTime temp = GetMonday(today);
            timeInterval.first = temp.Date;
            temp = GetSunday(today);
            timeInterval.second = new DateTime(temp.Year, temp.Month, temp.Day, 23, 59, 59, 999);
        }

        public static DateTime GetMonday(DateTime day){
            DayOfWeek dow = day.DayOfWeek;
            switch (dow){
            case DayOfWeek.Tuesday:
                return day.AddDays(-1);

            case DayOfWeek.Wednesday:
                return day.AddDays(-2);

            case DayOfWeek.Thursday:
                return day.AddDays(-3);

            case DayOfWeek.Friday:
                return day.AddDays(-4);

            case DayOfWeek.Saturday:
                return day.AddDays(-5);

            case DayOfWeek.Sunday:
                return day.AddDays(-6);

            default:
                return day;
            }
        }

        public static DateTime GetSunday(DateTime day){
            return GetMonday(day).AddDays(6);
        }
    }
}
