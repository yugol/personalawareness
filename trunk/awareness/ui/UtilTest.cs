/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 22/09/2008
 * Time: 13:21
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
using NUnit.Framework.SyntaxHelpers;

namespace Awareness.ui {
    [TestFixture]
    public class UtilTest {
        // [Test]
        public void FormatCurrency() {
            Assert.AreEqual("USD10.00", Util.FormatCurrency(10m));
        }

        [Test]
        public void FormatTimeSpan() {
            TimeSpan ts = new TimeSpan(2, 3, 4);
            Assert.AreEqual("02:03:04", Util.FormatTimeSpan(ts));

            ts = new TimeSpan(0, 0, 4);
            Assert.AreEqual("00:00:04", Util.FormatTimeSpan(ts));

            ts = new TimeSpan(0, 3, 0);
            Assert.AreEqual("00:03:00", Util.FormatTimeSpan(ts));

            ts = new TimeSpan(-2, 0, 0);
            Assert.AreEqual("-02:00:00", Util.FormatTimeSpan(ts));

            ts = new TimeSpan(-1, 0, 0, 0);
            Assert.AreEqual("-1.00:00:00", Util.FormatTimeSpan(ts));
        }

        [Test]
        public void Minutes2TimeSpanString() {
            Assert.AreEqual("0 min", Util.Minutes2TimeSpanString(0));
            Assert.AreEqual("1 min", Util.Minutes2TimeSpanString(1));
            Assert.AreEqual("-1 min", Util.Minutes2TimeSpanString(-1));
            Assert.AreEqual("1 hour ", Util.Minutes2TimeSpanString(60));
            Assert.AreEqual("-1 hour ", Util.Minutes2TimeSpanString(-60));
            Assert.AreEqual("1 hour 30 min", Util.Minutes2TimeSpanString(90));
            Assert.AreEqual("-1 hour 30 min", Util.Minutes2TimeSpanString(-90));
            Assert.AreEqual("2 hours ", Util.Minutes2TimeSpanString(120));
            Assert.AreEqual("-2 hours ", Util.Minutes2TimeSpanString(-120));
            Assert.AreEqual("1 day ", Util.Minutes2TimeSpanString(1440));
            Assert.AreEqual("-1 day ", Util.Minutes2TimeSpanString(-1440));
            Assert.AreEqual("2 days ", Util.Minutes2TimeSpanString(2880));
            Assert.AreEqual("-2 days ", Util.Minutes2TimeSpanString(-2880));
        }

    }
}
#endif
