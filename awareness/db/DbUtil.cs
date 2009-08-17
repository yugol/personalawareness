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
 * Date: 30/08/2008
 * Time: 22:36
 *
 */
using System;
using System.IO;
using System.Linq;
using Awareness.db.mssql;

namespace Awareness.db
{
    internal delegate void DatabaseChangedHandler();

    internal abstract partial class DBUtil {
        

        internal static event DatabaseChangedHandler DataContextChanged;
        internal static event DatabaseChangedHandler DataContextClosing;
        internal static event DatabaseChangedHandler AccountTypesChanged;
        internal static event DatabaseChangedHandler TransferLocationsChanged;
        internal static event DatabaseChangedHandler AccountsChanged;
        internal static event DatabaseChangedHandler BudgetCategoriesChanged;
        internal static event DatabaseChangedHandler TransactionReasonsChanged;
        internal static event DatabaseChangedHandler ReasonsChanged;
        internal static event DatabaseChangedHandler FoodsChanged;
        internal static event DatabaseChangedHandler RecipesChanged;
        internal static event DatabaseChangedHandler ConsumersChanged;
        internal static event DatabaseChangedHandler TransactionsChanged;
        internal static event DatabaseChangedHandler MealsChanged;
        internal static event DatabaseChangedHandler ActionsChanged;
        
        internal static void RestoreFromSqlDump(string fileName){
            StreamReader reader = null;
            try {
                string dbConnectionString = dataContext.Connection.ConnectionString;
                DeleteDataContext();
                CreateDataContext(dbConnectionString);
                OpenDataContext(dbConnectionString);
                reader = new StreamReader(fileName);
                throw new NotImplementedException();
                // Dumper dd = new Dumper(dataContext);
                // dd.RestoreDb(reader);
            } catch (Exception ex) {
                throw ex;
            }
            finally
            {
                if (reader != null){
                    reader.Dispose();
                }
                ReOpenDataContext();
            }
        }

        static DalAccount GetFoodsAccount(){
            return (DalAccount) dataContext.GetTransferLocationById(DataStorage.ACCOUNT_FOODS_ID);
        }

        static DalAccount GetRecipesAccount(){
            return (DalAccount) dataContext.GetTransferLocationById(DataStorage.ACCOUNT_RECIPES_ID);
        }

        static DalTransaction GetRecipeTransaction(DalRecipe why, DateTime when){
            DalTransaction recipeTransaction = null;

            IQueryable<DalTransaction> cookings = from t in dataContext.transactions
                                                  where t.Reason.Id == why.Id
                                                  where t.When == when
                                                  select t;

            if (cookings.Count() > 0){
                recipeTransaction = cookings.First();
            }

            return recipeTransaction;
        }

        static int GetRecipeConstituentCount(DalRecipe recipe, DateTime when){
            IQueryable<DalMeal> meals = from m in dataContext.meals
                                        where m.WhyId == recipe.Id
                                        where m.When.Equals(when)
                                        select m;
            return meals.Count();
        }

        internal static DalNote GetRootNote(){
            return dataContext.GetNoteById(DataStorage.NOTE_ROOT_ID);
        }

        internal static DalAction GetRootAction(){
            return dataContext.GetActionById(DataStorage.ACTION_ROOT_ID);
        }

    }
}
