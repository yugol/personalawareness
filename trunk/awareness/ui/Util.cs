/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 21/09/2008
 * Time: 23:11
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Awareness.db.mssql;
using Awareness.db;

namespace Awareness.ui {
    internal class Util {
        internal static string FormatCurrency(decimal ammount) {
            string rep = ammount.ToString("#,###,##0.00");
            if (Configuration.StorageProperties.PlaceCurrencySymbolAfterValue) {
                rep += Configuration.StorageProperties.CurrencySymbol;
            } else {
                rep = Configuration.StorageProperties.CurrencySymbol + rep;
            }
            return rep;
        }

        internal static void FillFoodConsumptionReasons(ComboBox whyCombo, DalReason what) {
            whyCombo.Items.Clear();

            AwarenessDataContext dc = DBUtil.GetDataContext();
            IEnumerable<DalConsumer> consumers = from r in dc.transactionReasons.OfType<DalConsumer>()
                                                 orderby r.Name
                                                 select r;
            whyCombo.Items.Add("---Consumers---");
            foreach (DalConsumer consumer in consumers) {
                whyCombo.Items.Add(consumer);
            }

            if (!(what is DalRecipe)) {
                IEnumerable<DalRecipe> recipes = from r in dc.transactionReasons.OfType<DalRecipe>()
                                                 orderby r.Name
                                                 select r;
                whyCombo.Items.Add("");
                whyCombo.Items.Add("---Recipes---");
                foreach (DalRecipe recipe in recipes) {
                    whyCombo.Items.Add(recipe);
                }
            }
        }

        internal static string FormatTimeSpan(TimeSpan ts) {
            StringBuilder buf = new StringBuilder();
            if (ts.TotalMinutes < 0) {
                buf.Append("-");
            }
            int days = Math.Abs((int) ts.TotalDays);
            if (days > 0) {
                buf.Append(days);
                buf.Append(".");
            }
            buf.Append(Math.Abs(ts.Hours).ToString("00"));
            buf.Append(":");
            buf.Append(Math.Abs(ts.Minutes).ToString("00"));
            buf.Append(":");
            buf.Append(Math.Abs(ts.Seconds).ToString("00"));
            return buf.ToString();
        }

        internal static void SetMinMaxDatesAndShortFormatFor(DateTimePicker picker) {
            SetMinMaxDatesFor(picker);
            picker.CustomFormat = Configuration.DATE_FORMAT;
            picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        }

        internal static void SetMinMaxDatesAndLongFormatFor(DateTimePicker picker) {
            SetMinMaxDatesFor(picker);
            picker.CustomFormat = Configuration.DATE_TIME_FORMAT;
            picker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        }

        static void SetMinMaxDatesFor(DateTimePicker picker) {
            picker.MinDate = Configuration.MIN_DATE_TIME;
            picker.MaxDate = Configuration.MAX_DATE_TIME;
        }

        internal static string Minutes2TimeSpanString(int minutes) {
            bool negative = minutes < 0;

            TimeSpan timeSpan = new TimeSpan(0, Math.Abs(minutes), 0);
            int days = (int) timeSpan.TotalDays;
            int hours = timeSpan.Hours;
            minutes = timeSpan.Minutes;

            string duration = "";

            if (days != 0) {
                duration += days.ToString();
                duration += (days == 1) ? (" day ") : (" days ");
            }

            if (hours != 0) {
                duration += hours.ToString();
                duration += (hours == 1) ? (" hour ") : (" hours ");
            }

            if (string.IsNullOrEmpty(duration)||(!string.IsNullOrEmpty(duration)&&(minutes != 0))) {
                duration += minutes.ToString() + " min";
            }

            if (negative) {
                duration = "-" + duration;
            }

            return duration;
        }

    }
}
