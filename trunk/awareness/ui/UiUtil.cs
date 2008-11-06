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
    internal class UiUtil
    {
        // TODO: validarea se face doar la apasarea butonului si nu la pierdereaa focus-ului
        
        internal static string FormatCurrency(decimal ammount)
        {
            return ammount.ToString("#,###,##0.00 RON");
        }

        internal static void FillFoodConsumptionReasons(ComboBox whyCombo, DalReason what)
        {
            whyCombo.Items.Clear();

            AwarenessDataContext dc = DbUtil.GetDataContext();
            IEnumerable<DalConsumer> consumers = from r in dc.transactionReasons.OfType<DalConsumer>()
                orderby r.Name
                select r;
            whyCombo.Items.Add("---Consumers---");
            foreach (DalConsumer consumer in consumers) {
                whyCombo.Items.Add(consumer);
            }
            
            if (!(what is DalRecipe))
            {
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
