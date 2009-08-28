/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 01/10/2008
 * Time: 18:29
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

#if TEST

using System;
using NUnit.Framework;

namespace Awareness.DB
{
    [TestFixture]
    public class RecurrencePatternTest {
        [Test]
        public void Getters(){
            RecurrencePattern p = new RecurrencePattern(RecurrencePattern.STEP_WEEKLY, 1, RecurrencePattern.WHEN_MONDAY | RecurrencePattern.WHEN_SUNDAY);
            p = new RecurrencePattern(p.Pattern);
            Assert.AreEqual(RecurrencePattern.STEP_WEEKLY, p.Step);
            Assert.AreEqual(1, p.Frequency);
            Assert.AreEqual(RecurrencePattern.WHEN_MONDAY | RecurrencePattern.WHEN_SUNDAY, p.When);
        }

        [Test]
        public void Validation(){
            RecurrencePattern p = new RecurrencePattern(256); // every minute

            try {
                p = new RecurrencePattern(256, 0, 0);
                Assert.Fail("STEP out of range");
            } catch (ArgumentOutOfRangeException)  {
            }

            try {
                p = new RecurrencePattern(1 + RecurrencePattern.STEP_YEARLY, 0, 0);
                Assert.Fail("STEP out of range");
            } catch (ArgumentOutOfRangeException)  {
            }

            try {
                p = new RecurrencePattern(RecurrencePattern.STEP_INTRADAY, 0, 0);
                Assert.Fail("FREQUENCY out of range");
            } catch (ArgumentOutOfRangeException)  {
            }

            try {
                p = new RecurrencePattern(RecurrencePattern.STEP_INTRADAY, 65536, 0);
                Assert.Fail("FREQUENCY out of range");
            } catch (ArgumentOutOfRangeException)  {
            }

            try {
                p = new RecurrencePattern(RecurrencePattern.STEP_INTRADAY, 1, 1);
                Assert.Fail("WHEN out of range");
            } catch (ArgumentOutOfRangeException)  {
            }

            try {
                p = new RecurrencePattern(RecurrencePattern.STEP_DAILY, 65536, 0);
                Assert.Fail("FREQUENCY out of range");
            } catch (ArgumentOutOfRangeException)  {
            }

            try {
                p = new RecurrencePattern(RecurrencePattern.STEP_DAILY, 0, 1);
                Assert.Fail("WHEN out of range");
            } catch (ArgumentOutOfRangeException)  {
            }

            try {
                p = new RecurrencePattern(RecurrencePattern.STEP_WEEKLY, 0, 1);
                Assert.Fail("FREQUENCY out of range");
            } catch (ArgumentOutOfRangeException)  {
            }

            try {
                p = new RecurrencePattern(RecurrencePattern.STEP_WEEKLY, 1, 0);
                Assert.Fail("WHEN out of range");
            } catch (ArgumentOutOfRangeException)  {
            }

            try {
                p = new RecurrencePattern(RecurrencePattern.STEP_WEEKLY, 1, RecurrencePattern.WHEN_ALL_WEEK + 1);
                Assert.Fail("WHEN out of range");
            } catch (ArgumentOutOfRangeException)  {
            }

            try {
                p = new RecurrencePattern(RecurrencePattern.STEP_WEEKLY, 1, 256);
                Assert.Fail("WHEN out of range");
            } catch (ArgumentOutOfRangeException)  {
            }

            try {
                p = new RecurrencePattern(RecurrencePattern.STEP_MONTHLY, 0, 1);
                Assert.Fail("FREQUENCY out of range");
            } catch (ArgumentOutOfRangeException)  {
            }

            try {
                p = new RecurrencePattern(RecurrencePattern.STEP_MONTHLY, 1, 0);
                Assert.Fail("WHEN out of range");
            } catch (ArgumentOutOfRangeException)  {
            }

            try {
                p = new RecurrencePattern(RecurrencePattern.STEP_MONTHLY, 1, 32);
                Assert.Fail("WHEN out of range");
            } catch (ArgumentOutOfRangeException)  {
            }

            try {
                p = new RecurrencePattern(RecurrencePattern.STEP_YEARLY, 0, 1);
                Assert.Fail("FREQUENCY out of range");
            } catch (ArgumentOutOfRangeException)  {
            }

            try {
                p = new RecurrencePattern(RecurrencePattern.STEP_YEARLY, 1 + RecurrencePattern.FREQUENCY_DECEMBER, 1);
                Assert.Fail("FREQUENCY out of range");
            } catch (ArgumentOutOfRangeException)  {
            }

            try {
                p = new RecurrencePattern(RecurrencePattern.STEP_YEARLY, 1, 0);
                Assert.Fail("WHEN out of range");
            } catch (ArgumentOutOfRangeException)  {
            }

            try {
                p = new RecurrencePattern(RecurrencePattern.STEP_YEARLY, 1, 32);
                Assert.Fail("WHEN out of range");
            } catch (ArgumentOutOfRangeException)  {
            }
        }

        [Test]
        public void NextOccurrenceIntraday(){
            DateTime dt = new DateTime(2000, 1, 1, 0, 0, 0);

            RecurrencePattern p = new RecurrencePattern(RecurrencePattern.STEP_INTRADAY, 31, 0);
            DateTime nextDt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2000, 1, 1, 0, 31, 0), nextDt);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2000, 1, 1, 1, 2, 0), nextDt);

            p = new RecurrencePattern(RecurrencePattern.STEP_INTRADAY, 14 * 60, 0);
            nextDt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2000, 1, 1, 14, 0, 0), nextDt);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2000, 1, 2, 4, 0, 0), nextDt);
        }

        [Test]
        public void NextOccurrenceDaily(){
            DateTime dt = new DateTime(2000, 1, 1, 0, 0, 0);

            RecurrencePattern p = new RecurrencePattern(RecurrencePattern.STEP_DAILY, 3, 0);
            DateTime nextDt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2000, 1, 4, 0, 0, 0), nextDt);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2000, 1, 7, 0, 0, 0), nextDt);

            dt = new DateTime(2008, 10, 1, 22, 13, 0);
            p = new RecurrencePattern(RecurrencePattern.STEP_DAILY, RecurrencePattern.FREQUENCY_WEEKDAYS, 0);
            nextDt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2008, 10, 2, 22, 13, 0), nextDt);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2008, 10, 3, 22, 13, 0), nextDt);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2008, 10, 6, 22, 13, 0), nextDt);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2008, 10, 7, 22, 13, 0), nextDt);

            dt = new DateTime(2008, 10, 4, 22, 13, 0);
            nextDt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2008, 10, 6, 22, 13, 0), nextDt);

            dt = new DateTime(2008, 10, 5, 22, 13, 0);
            nextDt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2008, 10, 6, 22, 13, 0), nextDt);
        }

        [Test]
        public void NextOccurrenceWeekly(){
            DateTime dt = new DateTime(2008, 10, 1, 22, 13, 0);
            RecurrencePattern p = new RecurrencePattern(RecurrencePattern.STEP_WEEKLY, 2, RecurrencePattern.WHEN_ALL_WEEK);

            dt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2008, 10, 2, 22, 13, 0), dt);
            dt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2008, 10, 3, 22, 13, 0), dt);
            dt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2008, 10, 4, 22, 13, 0), dt);
            dt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2008, 10, 5, 22, 13, 0), dt);
            dt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2008, 10, 13, 22, 13, 0), dt);
            dt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2008, 10, 14, 22, 13, 0), dt);
            dt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2008, 10, 15, 22, 13, 0), dt);
            dt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2008, 10, 16, 22, 13, 0), dt);

            dt = new DateTime(2008, 10, 1, 22, 13, 0);
            p = new RecurrencePattern(RecurrencePattern.STEP_WEEKLY, 1, RecurrencePattern.WHEN_TUESDAY);
            dt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2008, 10, 7, 22, 13, 0), dt);

            dt = new DateTime(2008, 10, 1, 22, 13, 0);
            p = new RecurrencePattern(RecurrencePattern.STEP_WEEKLY, 1, RecurrencePattern.WHEN_WEDNESDAY);
            dt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2008, 10, 8, 22, 13, 0), dt);

            dt = new DateTime(2008, 10, 1, 22, 13, 0);
            p = new RecurrencePattern(RecurrencePattern.STEP_WEEKLY, 1, RecurrencePattern.WHEN_SUNDAY);
            dt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2008, 10, 5, 22, 13, 0), dt);
            dt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2008, 10, 12, 22, 13, 0), dt);
        }

        [Test]
        public void NextOccurrenceMonthly(){
            DateTime dt = new DateTime(2004, 1, 20, 12, 34, 0);

            RecurrencePattern p = new RecurrencePattern(RecurrencePattern.STEP_MONTHLY, 1, 30);
            DateTime nextDt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2004, 1, 30, 12, 34, 0), nextDt);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2004, 2, 29, 12, 34, 0), nextDt);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2004, 3, 30, 12, 34, 0), nextDt);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2004, 4, 30, 12, 34, 0), nextDt);

            p = new RecurrencePattern(RecurrencePattern.STEP_MONTHLY, 2, 31);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2004, 6, 30, 12, 34, 0), nextDt);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2004, 8, 31, 12, 34, 0), nextDt);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2004, 10, 31, 12, 34, 0), nextDt);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2004, 12, 31, 12, 34, 0), nextDt);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2005, 2, 28, 12, 34, 0), nextDt);

            dt = new DateTime(2004, 1, 20, 12, 34, 0);
            p = new RecurrencePattern(RecurrencePattern.STEP_MONTHLY, 3, 10);
            nextDt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2004, 4, 10, 12, 34, 0), nextDt);

            dt = new DateTime(2004, 2, 20, 12, 34, 0);
            p = new RecurrencePattern(RecurrencePattern.STEP_MONTHLY, 1, 31);
            nextDt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2004, 2, 29, 12, 34, 0), nextDt);
        }

        [Test]
        public void NextOccurrenceYearly(){
            DateTime dt = new DateTime(2004, 2, 20, 12, 34, 0);

            RecurrencePattern p = new RecurrencePattern(RecurrencePattern.STEP_YEARLY, 2, 30);
            DateTime nextDt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2004, 2, 29, 12, 34, 0), nextDt);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2005, 2, 28, 12, 34, 0), nextDt);

            dt = new DateTime(2004, 4, 20, 12, 34, 0);

            p = new RecurrencePattern(RecurrencePattern.STEP_YEARLY, 2, 30);
            nextDt = p.NextOccurrence(dt);
            Assert.AreEqual(new DateTime(2005, 2, 28, 12, 34, 0), nextDt);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2006, 2, 28, 12, 34, 0), nextDt);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2007, 2, 28, 12, 34, 0), nextDt);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2008, 2, 29, 12, 34, 0), nextDt);

            p = new RecurrencePattern(RecurrencePattern.STEP_YEARLY, 3, 30);
            nextDt = p.NextOccurrence(nextDt);
            Assert.AreEqual(new DateTime(2008, 3, 30, 12, 34, 0), nextDt);
        }

        [Test]
        public void ParseIntradayString(){
            Assert.AreEqual(0, RecurrencePattern.ParseIntradayString(""));
            Assert.AreEqual(1, RecurrencePattern.ParseIntradayString("1"));
            Assert.AreEqual(10, RecurrencePattern.ParseIntradayString(" 10"));
            Assert.AreEqual(100, RecurrencePattern.ParseIntradayString(" 100 "));
            Assert.AreEqual(60, RecurrencePattern.ParseIntradayString("1 0"));
            Assert.AreEqual(200, RecurrencePattern.ParseIntradayString("2 80"));
            Assert.AreEqual(61, RecurrencePattern.ParseIntradayString("asdf1.1.2380"));
            // Assert.AreEqual(RecurrencePattern.ABSOLUTE_MAX_FREQUENCY, RecurrencePattern.ParseIntradayString("11111111111111111111111111"));
        }
    }
}
#endif
