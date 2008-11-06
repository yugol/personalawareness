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
using NUnit.Framework.SyntaxHelpers;

namespace awareness.db
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
            
            TimeInterval interval = TimeInterval.CreateInterval(Intervals.TODAY, new DateTime(2008, 10, 3));
            
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
            interval = TimeInterval.CreateInterval(Intervals.TODAY, new DateTime(2008, 10, 5));
            occurrences = action.GetOccurrences(interval);
            Assert.AreEqual(0, occurrences.Count);
        }
    }
}
#endif
