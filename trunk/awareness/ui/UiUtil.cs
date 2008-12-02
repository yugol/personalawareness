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
 * Date: 21/09/2008
 * Time: 23:11
 *
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using awareness.db;

namespace awareness.ui
{
    internal class UiUtil {
        internal static string FormatCurrency(decimal ammount){
            string rep = ammount.ToString("#,###,##0.00");
            if (Configuration.PlaceCurrencySymbolAfterValue){
                rep += " " + Configuration.CurrencySymbol;
            } else {
                rep = Configuration.CurrencySymbol + rep;
            }
            return rep;
        }

        internal static void FillFoodConsumptionReasons(ComboBox whyCombo, DalReason what){
            whyCombo.Items.Clear();

            AwarenessDataContext dc = DbUtil.GetDataContext();
            IEnumerable<DalConsumer> consumers = from r in dc.transactionReasons.OfType<DalConsumer>()
                                                 orderby r.Name
                                                 select r;
            whyCombo.Items.Add("---Consumers---");
            foreach (DalConsumer consumer in consumers) {
                whyCombo.Items.Add(consumer);
            }

            if (!(what is DalRecipe)){
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
    }
}
