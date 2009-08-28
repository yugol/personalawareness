/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 27/11/2008
 * Time: 22:08
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
    public class XmlPropertiesTest
    {
        [Test]
        public void CreateNewPropertiesXml()
        {
            XmlProperties prop = new XmlProperties();
            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"utf-16\"?><properties><currency><symbol>$</symbol><placeAfterValue>False</placeAfterValue></currency><lastMealReportReason>0</lastMealReportReason></properties>", prop.XmlString);
        }

        [Test]
        public void CurrencySymbol()
        {
            XmlProperties prop = new XmlProperties();
            Assert.AreEqual("$", prop.CurrencySymbol);
            prop.CurrencySymbol = "RON";
            Assert.AreEqual("RON", prop.CurrencySymbol);
            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"utf-16\"?><properties><currency><symbol>RON</symbol><placeAfterValue>False</placeAfterValue></currency><lastMealReportReason>0</lastMealReportReason></properties>", prop.XmlString);
        }

        [Test]
        public void PlaceCurrencySymbolAfterValue()
        {
            XmlProperties prop = new XmlProperties();
            Assert.AreEqual(false, prop.PlaceCurrencySymbolAfterValue);
            prop.PlaceCurrencySymbolAfterValue = true;
            Assert.AreEqual(true, prop.PlaceCurrencySymbolAfterValue);
            Assert.AreEqual("<?xml version=\"1.0\" encoding=\"utf-16\"?><properties><currency><symbol>$</symbol><placeAfterValue>True</placeAfterValue></currency><lastMealReportReason>0</lastMealReportReason></properties>", prop.XmlString);
        }
    }
}
#endif
