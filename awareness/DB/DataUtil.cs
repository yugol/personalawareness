/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 7/25/2009
 * Time: 4:22 PM
 *
 *
 * Copyright (c) 2008, 2009 Iulian GORIAC
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
    public static class DataUtil
    {
        public static readonly string YYYYMMDDHHMMSS = "yyyy-MM-dd HH:mm:ss";
        public static readonly string YYYYMMDD = "yyyy-MM-dd";

        public static string Bool2String(bool value)
        {
            return value ? "1" : "0";
        }

        public static string String2SqlString(string memo)
        {
            if (string.IsNullOrEmpty(memo)) {
                return "null";
            } else {
                string escaped = memo.Replace("'", "''");
                escaped = escaped.Replace("\r", "' + NCHAR(13) + N'");
                escaped = escaped.Replace("\n", "' + NCHAR(10) + N'");
                return string.Format("N'{0}'", escaped);
            }
        }

        public static string DateTime2String(DateTime dateTime)
        {
            return string.Format("'{0}'", dateTime.ToString(YYYYMMDDHHMMSS));
        }

        public static string Date2String(DateTime dateTime)
        {
            return string.Format("'{0}'", dateTime.ToString(YYYYMMDD));
        }

        public static DateTime RemoveMilliseconds(DateTime when)
        {
            return new DateTime(when.Year, when.Month, when.Day, when.Hour, when.Minute, when.Second);
        }

        public static DateTime RemoveSeconds(DateTime when)
        {
            return new DateTime(when.Year, when.Month, when.Day, when.Hour, when.Minute, 0);
        }
    }
}
