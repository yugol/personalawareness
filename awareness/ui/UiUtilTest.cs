/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 22/09/2008
 * Time: 13:21
 * 
 */
#if TEST

using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace awareness.ui
{
    [TestFixture]
    public class UiUtilTest
    {
        [Test]
        public void FormatCurrency()
        {
            Assert.AreEqual("10.00 RON", UiUtil.FormatCurrency(10m));
        }
    }
}
#endif
