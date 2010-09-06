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
 * Date: 01/10/2008
 * Time: 15:39
 *
 */
#if TEST

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Awareness.DB
{
    [TestFixture]
    public class DalActionTest
    {
        [Test]
        public void GetOccurrences()
        {
            DalAction action = new DalAction();
            action.Start = new DateTime(2008, 10, 3, 10, 30, 0);
            action.End = new DateTime(2008, 10, 3, 11, 00, 0);

            TimeInterval interval = TimeInterval.CreateInterval(ETimeIntervals.TODAY, new DateTime(2008, 10, 3));

            List<ActionOccurrence> occurrences = action.GetOccurrences(interval);
            Assert.AreEqual(1, occurrences.Count);
            ActionOccurrence occurrence = occurrences[0];
            Assert.AreEqual(new DateTime(2008, 10, 3, 10, 30, 0), occurrence.Start);
            Assert.AreEqual(new DateTime(2008, 10, 3, 11, 00, 0), occurrence.End);

            action.IsRecurrent = true;
            action.RecurrencePattern = new RecurrencePattern(RecurrencePattern.STEP_INTRADAY, 6 * 60 + 40, 0);

            occurrences = action.GetOccurrences(interval);
            Assert.AreEqual(3, occurrences.Count);
            occurrence = occurrences[0];
            Assert.AreEqual(new DateTime(2008, 10, 3, 10, 30, 0), occurrence.Start);
            Assert.AreEqual(new DateTime(2008, 10, 3, 11, 00, 0), occurrence.End);
            occurrence = occurrences[1];
            Assert.AreEqual(new DateTime(2008, 10, 3, 17, 10, 0), occurrence.Start);
            Assert.AreEqual(new DateTime(2008, 10, 3, 17, 40, 0), occurrence.End);
            occurrence = occurrences[2];
            Assert.AreEqual(new DateTime(2008, 10, 3, 23, 50, 0), occurrence.Start);
            Assert.AreEqual(new DateTime(2008, 10, 3, 23, 59, 0), occurrence.End);

            action.RepeatUntil = new DateTime(2008, 10, 5);
            interval = TimeInterval.CreateInterval(ETimeIntervals.TODAY, new DateTime(2008, 10, 5));
            occurrences = action.GetOccurrences(interval);
            Assert.AreEqual(0, occurrences.Count);
        }
    }
}
#endif
