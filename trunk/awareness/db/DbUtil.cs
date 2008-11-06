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

namespace awareness.db
{
    internal delegate void DatabaseChangedHandler();

    internal abstract partial class DbUtil {
        // TODO: hide reopendatacontext

        static AwarenessDataContext dataContext = null;

        internal static event DatabaseChangedHandler DataContextChanged;
        // internal static event VoidVoid PropertiesChanged;
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

        internal static DateTime RemoveMilliseconds(DateTime when){
            return new DateTime(when.Year, when.Month, when.Day, when.Hour, when.Minute, when.Second);
        }

        internal static DateTime RemoveSeconds(DateTime when){
            return new DateTime(when.Year, when.Month, when.Day, when.Hour, when.Minute, 0);
        }

        internal static void RestoreFromSqlDump(string fileName){
            StreamReader reader = null;
            try {
                string dbConnectionString = dataContext.Connection.ConnectionString;
                DeleteDataContext();
                CreateDataContext(dbConnectionString);
                OpenDataContext(dbConnectionString);
                reader = new StreamReader(fileName);
                DbDumper dd = new DbDumper(dataContext);
                dd.RestoreDb(reader);
            } catch (Exception ex)  {
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
            return (DalAccount) dataContext.GetTransferLocationById(AwarenessDataContext.ACCOUNT_FOODS_ID);
        }

        static DalAccount GetRecipesAccount(){
            return (DalAccount) dataContext.GetTransferLocationById(AwarenessDataContext.ACCOUNT_RECIPES_ID);
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
            return dataContext.notes.Where(n => n.Id == AwarenessDataContext.NOTE_ROOT_ID).First();
        }

        internal static string Minutes2TimeSpanString(int minutes){
            bool negative = minutes < 0;

            TimeSpan timeSpan = new TimeSpan(0, Math.Abs(minutes), 0);
            int days = (int) timeSpan.TotalDays;
            int hours = timeSpan.Hours;
            minutes = timeSpan.Minutes;

            string duration = "";

            if (days != 0){
                duration += days.ToString();
                duration += (days == 1) ? (" day ") : (" days ");
            }

            if (hours != 0){
                duration += hours.ToString();
                duration += (hours == 1) ? (" hour ") : (" hours ");
            }

            if (string.IsNullOrEmpty(duration)||(!string.IsNullOrEmpty(duration)&&(minutes != 0))){
                duration += minutes.ToString() + " min";
            }

            if (negative){
                duration = "-" + duration;
            }

            return duration;
        }
    }
}
