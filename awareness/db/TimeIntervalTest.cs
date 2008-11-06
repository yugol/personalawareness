/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 12/09/2008
 * Time: 11:27
 *
 */
#if TEST

using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace awareness.db
{
    [TestFixture]
    public class TimeIntervalTest {
        [Test]
        public void CreateInterval(){
            DateTime today = new DateTime(2008, 2, 14, 1, 2, 3, 4);

            TimeInterval timeIntrerval = TimeInterval.CreateInterval(Intervals.ALL, today);
            Assert.AreEqual(new DateTime(1900, 1, 1), timeIntrerval.First);
            Assert.AreEqual(new DateTime(3000, 1, 1), timeIntrerval.Second);

            timeIntrerval = TimeInterval.CreateInterval(Intervals.TODAY, today);
            Assert.AreEqual(new DateTime(2008, 2, 14), timeIntrerval.First);
            Assert.AreEqual(new DateTime(2008, 2, 14, 23, 59, 59, 999), timeIntrerval.Second);

            timeIntrerval = TimeInterval.CreateInterval(Intervals.THIS_WEEK, today);
            Assert.AreEqual(new DateTime(2008, 2, 11), timeIntrerval.First);
            Assert.AreEqual(new DateTime(2008, 2, 17, 23, 59, 59, 999), timeIntrerval.Second);

            timeIntrerval = TimeInterval.CreateInterval(Intervals.LAST_WEEK, today);
            Assert.AreEqual(new DateTime(2008, 2, 4), timeIntrerval.First);
            Assert.AreEqual(new DateTime(2008, 2, 10, 23, 59, 59, 999), timeIntrerval.Second);

            timeIntrerval = TimeInterval.CreateInterval(Intervals.LAST_WEEK, today);
            Assert.AreEqual(new DateTime(2008, 2, 4), timeIntrerval.First);
            Assert.AreEqual(new DateTime(2008, 2, 10, 23, 59, 59, 999), timeIntrerval.Second);

            timeIntrerval = TimeInterval.CreateInterval(Intervals.THIS_MONTH, today);
            Assert.AreEqual(new DateTime(2008, 2, 1), timeIntrerval.First);
            Assert.AreEqual(new DateTime(2008, 2, 29, 23, 59, 59, 999), timeIntrerval.Second);

            timeIntrerval = TimeInterval.CreateInterval(Intervals.LAST_MONTH, today);
            Assert.AreEqual(new DateTime(2008, 1, 1), timeIntrerval.First);
            Assert.AreEqual(new DateTime(2008, 1, 31, 23, 59, 59, 999), timeIntrerval.Second);

            timeIntrerval = TimeInterval.CreateInterval(Intervals.THIS_QUARTER, today);
            Assert.AreEqual(new DateTime(2007, 12, 1), timeIntrerval.First);
            Assert.AreEqual(new DateTime(2008, 2, 29, 23, 59, 59, 999), timeIntrerval.Second);

            timeIntrerval = TimeInterval.CreateInterval(Intervals.LAST_QUARTER, today);
            Assert.AreEqual(new DateTime(2007, 9, 1), timeIntrerval.First);
            Assert.AreEqual(new DateTime(2007, 11, 30, 23, 59, 59, 999), timeIntrerval.Second);

            timeIntrerval = TimeInterval.CreateInterval(Intervals.THIS_YEAR, today);
            Assert.AreEqual(new DateTime(2008, 1, 1), timeIntrerval.First);
            Assert.AreEqual(new DateTime(2008, 12, 31, 23, 59, 59, 999), timeIntrerval.Second);

            timeIntrerval = TimeInterval.CreateInterval(Intervals.LAST_YEAR, today);
            Assert.AreEqual(new DateTime(2007, 1, 1), timeIntrerval.First);
            Assert.AreEqual(new DateTime(2007, 12, 31, 23, 59, 59, 999), timeIntrerval.Second);
        }

        [Test]
        public void GetMonday(){
            DateTime monday = new DateTime(2008, 9, 1);
            Assert.AreEqual(monday, TimeInterval.GetMonday(new DateTime(2008, 9, 1)));
            Assert.AreEqual(monday, TimeInterval.GetMonday(new DateTime(2008, 9, 2)));
            Assert.AreEqual(monday, TimeInterval.GetMonday(new DateTime(2008, 9, 3)));
            Assert.AreEqual(monday, TimeInterval.GetMonday(new DateTime(2008, 9, 4)));
            Assert.AreEqual(monday, TimeInterval.GetMonday(new DateTime(2008, 9, 5)));
            Assert.AreEqual(monday, TimeInterval.GetMonday(new DateTime(2008, 9, 6)));
            Assert.AreEqual(monday, TimeInterval.GetMonday(new DateTime(2008, 9, 7)));
            Assert.AreEqual(monday.AddDays(7), TimeInterval.GetMonday(new DateTime(2008, 9, 8)));
        }

        [Test]
        public void GetSunday(){
            DateTime sunday = new DateTime(2008, 9, 7);
            Assert.AreEqual(sunday, TimeInterval.GetSunday(new DateTime(2008, 9, 1)));
            Assert.AreEqual(sunday, TimeInterval.GetSunday(new DateTime(2008, 9, 2)));
            Assert.AreEqual(sunday, TimeInterval.GetSunday(new DateTime(2008, 9, 3)));
            Assert.AreEqual(sunday, TimeInterval.GetSunday(new DateTime(2008, 9, 4)));
            Assert.AreEqual(sunday, TimeInterval.GetSunday(new DateTime(2008, 9, 5)));
            Assert.AreEqual(sunday, TimeInterval.GetSunday(new DateTime(2008, 9, 6)));
            Assert.AreEqual(sunday, TimeInterval.GetSunday(new DateTime(2008, 9, 7)));
            Assert.AreEqual(sunday.AddDays(7), TimeInterval.GetSunday(new DateTime(2008, 9, 8)));
        }

        [Test]
        public void Intersect_abXY(){
            DateTime v1 = new DateTime(2000, 1, 1);
            DateTime v2 = new DateTime(2000, 2, 1);
            DateTime v3 = new DateTime(2000, 3, 1);
            DateTime v4 = new DateTime(2000, 4, 1);

            TimeInterval AB = new TimeInterval(v1, v2);
            TimeInterval XY = new TimeInterval(v3, v4);

            TimeInterval intersection = XY.Intersect(AB);
            Assert.AreEqual(null, intersection);

            intersection = AB.Intersect(XY);
            Assert.AreEqual(null, intersection);
        }

        [Test]
        public void Intersect_axXY(){
            DateTime v1 = new DateTime(2000, 1, 1);
            DateTime v2 = new DateTime(2000, 2, 1);
            DateTime v3 = new DateTime(2000, 3, 1);
            DateTime v4 = new DateTime(2000, 4, 1);

            TimeInterval AB = new TimeInterval(v1, v3);
            TimeInterval XY = new TimeInterval(v3, v4);

            TimeInterval intersection = XY.Intersect(AB);
            Assert.AreEqual(v3, intersection.First);
            Assert.AreEqual(v3, intersection.Second);

            intersection = AB.Intersect(XY);
            Assert.AreEqual(v3, intersection.First);
            Assert.AreEqual(v3, intersection.Second);
        }

        [Test]
        public void Intersect_aXbY(){
            DateTime v1 = new DateTime(2000, 1, 1);
            DateTime v2 = new DateTime(2000, 2, 1);
            DateTime v3 = new DateTime(2000, 3, 1);
            DateTime v4 = new DateTime(2000, 4, 1);

            TimeInterval AB = new TimeInterval(v1, v3);
            TimeInterval XY = new TimeInterval(v2, v4);

            TimeInterval intersection = XY.Intersect(AB);
            Assert.AreEqual(v2, intersection.First);
            Assert.AreEqual(v3, intersection.Second);

            intersection = AB.Intersect(XY);
            Assert.AreEqual(v2, intersection.First);
            Assert.AreEqual(v3, intersection.Second);
        }

        [Test]
        public void Intersect_aXyY(){
            DateTime v1 = new DateTime(2000, 1, 1);
            DateTime v2 = new DateTime(2000, 2, 1);
            DateTime v3 = new DateTime(2000, 3, 1);
            DateTime v4 = new DateTime(2000, 4, 1);

            TimeInterval AB = new TimeInterval(v1, v4);
            TimeInterval XY = new TimeInterval(v3, v4);

            TimeInterval intersection = XY.Intersect(AB);
            Assert.AreEqual(v3, intersection.First);
            Assert.AreEqual(v4, intersection.Second);

            intersection = AB.Intersect(XY);
            Assert.AreEqual(v3, intersection.First);
            Assert.AreEqual(v4, intersection.Second);
        }

        [Test]
        public void Intersect_aXYb(){
            DateTime v1 = new DateTime(2000, 1, 1);
            DateTime v2 = new DateTime(2000, 2, 1);
            DateTime v3 = new DateTime(2000, 3, 1);
            DateTime v4 = new DateTime(2000, 4, 1);

            TimeInterval AB = new TimeInterval(v1, v4);
            TimeInterval XY = new TimeInterval(v2, v3);

            TimeInterval intersection = XY.Intersect(AB);
            Assert.AreEqual(v2, intersection.First);
            Assert.AreEqual(v3, intersection.Second);

            intersection = AB.Intersect(XY);
            Assert.AreEqual(v2, intersection.First);
            Assert.AreEqual(v3, intersection.Second);
        }

        [Test]
        public void Intersect_xxXY(){
            DateTime v1 = new DateTime(2000, 1, 1);
            DateTime v2 = new DateTime(2000, 2, 1);
            DateTime v3 = new DateTime(2000, 3, 1);
            DateTime v4 = new DateTime(2000, 4, 1);

            TimeInterval AB = new TimeInterval(v3, v3);
            TimeInterval XY = new TimeInterval(v3, v4);

            TimeInterval intersection = XY.Intersect(AB);
            Assert.AreEqual(v3, intersection.First);
            Assert.AreEqual(v3, intersection.Second);

            intersection = AB.Intersect(XY);
            Assert.AreEqual(v3, intersection.First);
            Assert.AreEqual(v3, intersection.Second);
        }

        [Test]
        public void Intersect_xXbY(){
            DateTime v1 = new DateTime(2000, 1, 1);
            DateTime v2 = new DateTime(2000, 2, 1);
            DateTime v3 = new DateTime(2000, 3, 1);
            DateTime v4 = new DateTime(2000, 4, 1);

            TimeInterval AB = new TimeInterval(v1, v2);
            TimeInterval XY = new TimeInterval(v1, v4);

            TimeInterval intersection = XY.Intersect(AB);
            Assert.AreEqual(v1, intersection.First);
            Assert.AreEqual(v2, intersection.Second);

            intersection = AB.Intersect(XY);
            Assert.AreEqual(v1, intersection.First);
            Assert.AreEqual(v2, intersection.Second);
        }

        [Test]
        public void Intersect_xXyY(){
            DateTime v1 = new DateTime(2000, 1, 1);
            DateTime v2 = new DateTime(2000, 2, 1);
            DateTime v3 = new DateTime(2000, 3, 1);
            DateTime v4 = new DateTime(2000, 4, 1);

            TimeInterval AB = new TimeInterval(v1, v2);
            TimeInterval XY = new TimeInterval(v1, v2);

            TimeInterval intersection = XY.Intersect(AB);
            Assert.AreEqual(v1, intersection.First);
            Assert.AreEqual(v2, intersection.Second);

            intersection = AB.Intersect(XY);
            Assert.AreEqual(v1, intersection.First);
            Assert.AreEqual(v2, intersection.Second);
        }

        [Test]
        public void Intersect_xXYb(){
            DateTime v1 = new DateTime(2000, 1, 1);
            DateTime v2 = new DateTime(2000, 2, 1);
            DateTime v3 = new DateTime(2000, 3, 1);
            DateTime v4 = new DateTime(2000, 4, 1);

            TimeInterval AB = new TimeInterval(v1, v2);
            TimeInterval XY = new TimeInterval(v1, v3);

            TimeInterval intersection = XY.Intersect(AB);
            Assert.AreEqual(v1, intersection.First);
            Assert.AreEqual(v2, intersection.Second);

            intersection = AB.Intersect(XY);
            Assert.AreEqual(v1, intersection.First);
            Assert.AreEqual(v2, intersection.Second);
        }

        [Test]
        public void Intersect_XaaY(){
            DateTime v1 = new DateTime(2000, 1, 1);
            DateTime v2 = new DateTime(2000, 2, 1);
            DateTime v3 = new DateTime(2000, 3, 1);
            DateTime v4 = new DateTime(2000, 4, 1);

            TimeInterval AB = new TimeInterval(v2, v2);
            TimeInterval XY = new TimeInterval(v1, v3);

            TimeInterval intersection = XY.Intersect(AB);
            Assert.AreEqual(v2, intersection.First);
            Assert.AreEqual(v2, intersection.Second);

            intersection = AB.Intersect(XY);
            Assert.AreEqual(v2, intersection.First);
            Assert.AreEqual(v2, intersection.Second);
        }

        [Test]
        public void Intersect_XabY(){
            DateTime v1 = new DateTime(2000, 1, 1);
            DateTime v2 = new DateTime(2000, 2, 1);
            DateTime v3 = new DateTime(2000, 3, 1);
            DateTime v4 = new DateTime(2000, 4, 1);

            TimeInterval AB = new TimeInterval(v1, v3);
            TimeInterval XY = new TimeInterval(v2, v2);

            TimeInterval intersection = XY.Intersect(AB);
            Assert.AreEqual(v2, intersection.First);
            Assert.AreEqual(v2, intersection.Second);

            intersection = AB.Intersect(XY);
            Assert.AreEqual(v2, intersection.First);
            Assert.AreEqual(v2, intersection.Second);
        }

        [Test]
        public void Intersect_XayY(){
            DateTime v1 = new DateTime(2000, 1, 1);
            DateTime v2 = new DateTime(2000, 2, 1);
            DateTime v3 = new DateTime(2000, 3, 1);
            DateTime v4 = new DateTime(2000, 4, 1);

            TimeInterval AB = new TimeInterval(v1, v3);
            TimeInterval XY = new TimeInterval(v2, v3);

            TimeInterval intersection = XY.Intersect(AB);
            Assert.AreEqual(v2, intersection.First);
            Assert.AreEqual(v3, intersection.Second);

            intersection = AB.Intersect(XY);
            Assert.AreEqual(v2, intersection.First);
            Assert.AreEqual(v3, intersection.Second);
        }

        [Test]
        public void Intersect_XaYb(){
            DateTime v1 = new DateTime(2000, 1, 1);
            DateTime v2 = new DateTime(2000, 2, 1);
            DateTime v3 = new DateTime(2000, 3, 1);
            DateTime v4 = new DateTime(2000, 4, 1);

            TimeInterval AB = new TimeInterval(v2, v4);
            TimeInterval XY = new TimeInterval(v1, v3);

            TimeInterval intersection = XY.Intersect(AB);
            Assert.AreEqual(v2, intersection.First);
            Assert.AreEqual(v3, intersection.Second);

            intersection = AB.Intersect(XY);
            Assert.AreEqual(v2, intersection.First);
            Assert.AreEqual(v3, intersection.Second);
        }

        [Test]
        public void Intersect_XyyY(){
            DateTime v1 = new DateTime(2000, 1, 1);
            DateTime v2 = new DateTime(2000, 2, 1);
            DateTime v3 = new DateTime(2000, 3, 1);
            DateTime v4 = new DateTime(2000, 4, 1);

            TimeInterval AB = new TimeInterval(v2, v2);
            TimeInterval XY = new TimeInterval(v1, v2);

            TimeInterval intersection = XY.Intersect(AB);
            Assert.AreEqual(v2, intersection.First);
            Assert.AreEqual(v2, intersection.Second);

            intersection = AB.Intersect(XY);
            Assert.AreEqual(v2, intersection.First);
            Assert.AreEqual(v2, intersection.Second);
        }

        [Test]
        public void Intersect_XyYb(){
            DateTime v1 = new DateTime(2000, 1, 1);
            DateTime v2 = new DateTime(2000, 2, 1);
            DateTime v3 = new DateTime(2000, 3, 1);
            DateTime v4 = new DateTime(2000, 4, 1);

            TimeInterval AB = new TimeInterval(v2, v4);
            TimeInterval XY = new TimeInterval(v1, v2);

            TimeInterval intersection = XY.Intersect(AB);
            Assert.AreEqual(v2, intersection.First);
            Assert.AreEqual(v2, intersection.Second);

            intersection = AB.Intersect(XY);
            Assert.AreEqual(v2, intersection.First);
            Assert.AreEqual(v2, intersection.Second);
        }

        [Test]
        public void Intersect_XYab(){
            DateTime v1 = new DateTime(2000, 1, 1);
            DateTime v2 = new DateTime(2000, 2, 1);
            DateTime v3 = new DateTime(2000, 3, 1);
            DateTime v4 = new DateTime(2000, 4, 1);

            TimeInterval AB = new TimeInterval(v1, v2);
            TimeInterval XY = new TimeInterval(v3, v4);

            TimeInterval intersection = XY.Intersect(AB);
            Assert.AreEqual(null, intersection);

            intersection = AB.Intersect(XY);
            Assert.AreEqual(null, intersection);
        }
    }
}
#endif
