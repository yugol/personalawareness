/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 01/10/2008
 * Time: 18:27
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

namespace Awareness.DB
{
    public struct RecurrencePattern
    {
        public const UInt32 STEP_INTRADAY = 0;
        public const UInt32 STEP_DAILY = 1;
        public const UInt32 STEP_WEEKLY = 2;
        public const UInt32 STEP_MONTHLY = 3;
        public const UInt32 STEP_YEARLY = 4;

        public const UInt32 FREQUENCY_WEEKDAYS = 0;

        public const UInt32 FREQUENCY_JANUARY = 1;
        public const UInt32 FREQUENCY_FEBRUARY = 2;
        public const UInt32 FREQUENCY_MARCH = 3;
        public const UInt32 FREQUENCY_APRIL = 4;
        public const UInt32 FREQUENCY_MAY = 5;
        public const UInt32 FREQUENCY_JUNE = 6;
        public const UInt32 FREQUENCY_JULY = 7;
        public const UInt32 FREQUENCY_AUGUST = 8;
        public const UInt32 FREQUENCY_SEPTEMBER = 9;
        public const UInt32 FREQUENCY_OCTOBER = 10;
        public const UInt32 FREQUENCY_NOVEMBER = 11;
        public const UInt32 FREQUENCY_DECEMBER = 12;

        public const UInt32 WHEN_SUNDAY = 1 << 6;
        public const UInt32 WHEN_MONDAY = 1 << 5;
        public const UInt32 WHEN_TUESDAY = 1 << 4;
        public const UInt32 WHEN_WEDNESDAY = 1 << 3;
        public const UInt32 WHEN_THURSDAY = 1 << 2;
        public const UInt32 WHEN_FRIDAY = 1 << 1;
        public const UInt32 WHEN_SATURDAY = 1 << 0;
        public const UInt32 WHEN_WEEKDAYS = WHEN_MONDAY | WHEN_TUESDAY | WHEN_WEDNESDAY | WHEN_THURSDAY | WHEN_FRIDAY;
        public const UInt32 WHEN_WEEKEND = WHEN_SATURDAY | WHEN_SUNDAY;
        public const UInt32 WHEN_ALL_WEEK = WHEN_WEEKDAYS | WHEN_WEEKEND;

        const int WHEN_BITLEN = 8;
        const int FREQUENCY_BITLEN = 16;
        const int STEP_BITLEN = 4;
        const int RESERVED_BITLEN = 4;

        public const UInt32 ABSOLUTE_MAX_WHEN = 0xFF;
        public const UInt32 ABSOLUTE_MAX_FREQUENCY = 0xFFFF;
        public const UInt32 ABSOLUTE_MAX_STEP = 0xF;

        const UInt32 WHEN_MASK = ABSOLUTE_MAX_WHEN;
        const UInt32 FREQUENCY_MASK = ABSOLUTE_MAX_FREQUENCY << WHEN_BITLEN;
        const UInt32 STEP_MASK = ABSOLUTE_MAX_STEP << (FREQUENCY_BITLEN + WHEN_BITLEN);

        public static UInt32 DayOfWeek2When(DayOfWeek dow){
            switch (dow){
            case DayOfWeek.Monday:
                return WHEN_MONDAY;

            case DayOfWeek.Tuesday:
                return WHEN_TUESDAY;

            case DayOfWeek.Wednesday:
                return WHEN_WEDNESDAY;

            case DayOfWeek.Thursday:
                return WHEN_THURSDAY;

            case DayOfWeek.Friday:
                return WHEN_FRIDAY;

            case DayOfWeek.Saturday:
                return WHEN_SATURDAY;

            default:
                return WHEN_SUNDAY;
            }
        }

        UInt32 pattern;

        public UInt32 Step
        {
            get { return (pattern & STEP_MASK) >> (FREQUENCY_BITLEN + WHEN_BITLEN); }
        }

        public UInt32 Frequency
        {
            get { return (pattern & FREQUENCY_MASK) >> WHEN_BITLEN; }
        }

        public UInt32 When
        {
            get { return pattern & WHEN_MASK; }
        }

        public UInt32 Pattern
        {
            get { return pattern; }
        }

        public RecurrencePattern(UInt32 step, UInt32 frequency, UInt32 when){
            if (step > ABSOLUTE_MAX_STEP){
                throw new ArgumentOutOfRangeException("STEP outside of bounds");
            }

            if (frequency > ABSOLUTE_MAX_FREQUENCY){
                throw new ArgumentOutOfRangeException("FREQUENCY outside of bounds");
            }

            if (when > ABSOLUTE_MAX_WHEN){
                throw new ArgumentOutOfRangeException("WHEN outside of bounds");
            }

            pattern = step;
            pattern <<= FREQUENCY_BITLEN;
            pattern += frequency;
            pattern <<= WHEN_BITLEN;
            pattern += when;

            ValidatePattern();
        }

        public RecurrencePattern(UInt32 pattern){
            this.pattern = pattern;
            ValidatePattern();
        }

        void ValidatePattern(){
            switch (Step){
            case STEP_INTRADAY:
                if (Frequency == 0){
                    throw new ArgumentOutOfRangeException("FREQUENCY outside of bounds");
                }
                if (When > 0){
                    throw new ArgumentOutOfRangeException("WHEN outside of bounds");
                }
                break;
            case STEP_DAILY:
                if (When > 0){
                    throw new ArgumentOutOfRangeException("WHEN outside of bounds");
                }
                break;
            case STEP_WEEKLY:
                if (Frequency == 0){
                    throw new ArgumentOutOfRangeException("FREQUENCY outside of bounds");
                }
                if (When == 0||When > WHEN_ALL_WEEK){
                    throw new ArgumentOutOfRangeException("WHEN outside of bounds");
                }
                break;
            case STEP_MONTHLY:
                if (Frequency == 0){
                    throw new ArgumentOutOfRangeException("FREQUENCY outside of bounds");
                }
                if (When == 0||When > 31){
                    throw new ArgumentOutOfRangeException("WHEN outside of bounds");
                }
                break;
            case STEP_YEARLY:
                if (Frequency == 0||Frequency > FREQUENCY_DECEMBER){
                    throw new ArgumentOutOfRangeException("FREQUENCY outside of bounds");
                }
                if (When == 0||When > 31){
                    throw new ArgumentOutOfRangeException("WHEN outside of bounds");
                }
                break;
            default:
                throw new ArgumentOutOfRangeException("STEP outside of bounds");
            }
        }

        public DateTime NextOccurrence(DateTime dt){
            switch (Step){
            case STEP_INTRADAY:
                return dt.AddMinutes(Frequency);

            case STEP_DAILY:
                if (Frequency != FREQUENCY_WEEKDAYS){
                    return dt.AddDays(Frequency);
                } else if (dt.DayOfWeek == DayOfWeek.Friday) {
                    return dt.AddDays(3);
                } else if (dt.DayOfWeek == DayOfWeek.Saturday) {
                    return dt.AddDays(2);
                } else {
                    return dt.AddDays(1);
                }

            case STEP_WEEKLY:
                DateTime nextOccurrenceSameWeek = NextOccurrenceSameWeek(dt);
                if (nextOccurrenceSameWeek.Equals(dt)){
                    return FirstOccurrenceSameWeek(dt).AddDays(7 * Frequency);
                } else {
                    return nextOccurrenceSameWeek;
                }

            case STEP_MONTHLY:
                DateTime nextOccurrenceSameMonth = NextOccurrenceSameMonth(dt);
                if (dt.CompareTo(nextOccurrenceSameMonth) < 0){
                    return nextOccurrenceSameMonth;
                } else {
                    return NextOccurrenceSameMonth(dt.AddMonths((int) Frequency));
                }

            default:     // STEP_YEARLY:
                DateTime nextOccurrenceSameYear = NextOccurrenceSameYear(dt);
                if (dt.CompareTo(nextOccurrenceSameYear) < 0){
                    return nextOccurrenceSameYear;
                } else {
                    return NextOccurrenceSameYear(dt.AddYears(1));
                }


                throw new ApplicationException("This should not happen");
            }
        }

        DateTime NextOccurrenceSameWeek(DateTime dt){
            switch (dt.DayOfWeek){
            case DayOfWeek.Monday:
                if ((When & WHEN_TUESDAY) != 0){
                    return dt.AddDays(1);
                }
                if ((When & WHEN_WEDNESDAY) != 0){
                    return dt.AddDays(2);
                }
                if ((When & WHEN_THURSDAY) != 0){
                    return dt.AddDays(3);
                }
                if ((When & WHEN_FRIDAY) != 0){
                    return dt.AddDays(4);
                }
                if ((When & WHEN_SATURDAY) != 0){
                    return dt.AddDays(5);
                }
                if ((When & WHEN_SUNDAY) != 0){
                    return dt.AddDays(6);
                }
                break;
            case DayOfWeek.Tuesday:
                if ((When & WHEN_WEDNESDAY) != 0){
                    return dt.AddDays(1);
                }
                if ((When & WHEN_THURSDAY) != 0){
                    return dt.AddDays(2);
                }
                if ((When & WHEN_FRIDAY) != 0){
                    return dt.AddDays(3);
                }
                if ((When & WHEN_SATURDAY) != 0){
                    return dt.AddDays(4);
                }
                if ((When & WHEN_SUNDAY) != 0){
                    return dt.AddDays(5);
                }
                break;
            case DayOfWeek.Wednesday:
                if ((When & WHEN_THURSDAY) != 0){
                    return dt.AddDays(1);
                }
                if ((When & WHEN_FRIDAY) != 0){
                    return dt.AddDays(2);
                }
                if ((When & WHEN_SATURDAY) != 0){
                    return dt.AddDays(3);
                }
                if ((When & WHEN_SUNDAY) != 0){
                    return dt.AddDays(4);
                }
                break;
            case DayOfWeek.Thursday:
                if ((When & WHEN_FRIDAY) != 0){
                    return dt.AddDays(1);
                }
                if ((When & WHEN_SATURDAY) != 0){
                    return dt.AddDays(2);
                }
                if ((When & WHEN_SUNDAY) != 0){
                    return dt.AddDays(3);
                }
                break;
            case DayOfWeek.Friday:
                if ((When & WHEN_SATURDAY) != 0){
                    return dt.AddDays(1);
                }
                if ((When & WHEN_SUNDAY) != 0){
                    return dt.AddDays(2);
                }
                break;
            case DayOfWeek.Saturday:
                if ((When & WHEN_SUNDAY) != 0){
                    return dt.AddDays(1);
                }
                break;
            }
            return dt;
        }

        DateTime FirstOccurrenceSameWeek(DateTime dt){
            dt = TimeInterval.GetMonday(dt);
            if ((When & WHEN_MONDAY) != 0){
                return dt;
            } else if ((When & WHEN_TUESDAY) != 0) {
                return dt.AddDays(1);
            } else if ((When & WHEN_WEDNESDAY) != 0) {
                return dt.AddDays(2);
            } else if ((When & WHEN_THURSDAY) != 0) {
                return dt.AddDays(3);
            } else if ((When & WHEN_FRIDAY) != 0) {
                return dt.AddDays(4);
            } else if ((When & WHEN_SATURDAY) != 0) {
                return dt.AddDays(5);
            } else {         // ((When & WHEN_SUNDAY) != 0)
                return dt.AddDays(6);
            }
        }

        DateTime NextOccurrenceSameMonth(DateTime dt){
            try {
                DateTime nextOccurrence = new DateTime(dt.Year, dt.Month, (int) When, dt.Hour, dt.Minute, dt.Second);
                return nextOccurrence;
            } catch (ArgumentOutOfRangeException) {
                DateTime nextOccurrence = new DateTime(dt.Year, dt.Month, 1, dt.Hour, dt.Minute, dt.Second);
                return nextOccurrence.AddMonths(1).AddDays(-1);
            }
        }

        DateTime NextOccurrenceSameYear(DateTime dt){
            try {
                DateTime nextOccurrence = new DateTime(dt.Year, (int) Frequency, (int) When, dt.Hour, dt.Minute, dt.Second);
                return nextOccurrence;
            } catch (Exception) {
                DateTime nextOccurrence = new DateTime(dt.Year, (int) Frequency, 1, dt.Hour, dt.Minute, dt.Second);
                return nextOccurrence.AddMonths(1).AddDays(-1);;
            }
        }

        public string ToFrequencyString(){
            UInt32 frequency = Frequency;
            UInt32 hours = frequency / 60;
            UInt32 minutes = frequency % 60;
            string h = (hours > 0) ? ((hours == 1) ? (hours + " hour ") : (hours + " hours ")) : ("");
            string m = (minutes > 0) ? (minutes + " min") : ("");
            return h + m;
        }

        public static UInt32 ParseIntradayString(string s){
            string firstInt = "";
            string secondInt = null;

            foreach (char c in s){
                if (char.IsDigit(c)){
                    if (secondInt == null){
                        firstInt += c;
                    } else {
                        secondInt += c;
                    }
                } else {
                    if (firstInt.Length > 0){
                        if (secondInt == null){
                            secondInt = "";
                        } else if (secondInt.Length > 0) {
                            break;
                        }
                    }
                }
            }

            UInt32 hours = 0;
            UInt32 minutes = 0;

            if (!string.IsNullOrEmpty(firstInt)){
                if (string.IsNullOrEmpty(secondInt)){
                    minutes = UInt32.Parse(firstInt);
                } else {
                    minutes = UInt32.Parse(secondInt);
                    hours = UInt32.Parse(firstInt);
                }
            }

            return hours * 60 + minutes;
        }
    }
}
