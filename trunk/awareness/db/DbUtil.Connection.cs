/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 22/09/2008
 * Time: 12:58
 *
 */
using System;
using System.Linq;

namespace awareness.db
{
    partial class DbUtil {
        internal static void CreateDataContext(string dbConnectionString){
            AwarenessDataContext localDataContext = new AwarenessDataContext(dbConnectionString);
            localDataContext.CreateDatabase();
            localDataContext.Connection.Close();
            localDataContext.Dispose();
        }

        internal static void OpenDataContext(string dbConnectionString){
            if (dataContext != null){
                CloseDataContext();
            }
            dataContext = new AwarenessDataContext(dbConnectionString);

            object o = dataContext.properties.First();
            o = dataContext.accountTypes.First();
            //o = dataContext.transferLocations.OfType<DalBudgetCategory>().First();
            o = dataContext.transferLocations.OfType<DalAccount>().First();
            //o = dataContext.transactionReasons.OfType<DalReason>().First();
            //o = dataContext.transactionReasons.OfType<DalFood>().First();
            //o = dataContext.transactionReasons.OfType<DalRecipe>().First();
            //o = dataContext.transactionReasons.OfType<DalConsumer>().First();
            //o = dataContext.transactions.First();
            //o = dataContext.meals.First();
            o = dataContext.notes.First();
            o = dataContext.actions.First();

            if (DataContextChanged != null){
                DataContextChanged();
            }
        }

        internal static AwarenessDataContext ReOpenDataContext(){
            string dbConnectionString = dataContext.Connection.ConnectionString;
            CloseDataContext();
            OpenDataContext(dbConnectionString);
            return dataContext;
        }

        internal static void CloseDataContext(){
            if (dataContext != null){
                dataContext.Connection.Close();
                dataContext.Dispose();
                dataContext = null;
            }
        }

        internal static void DeleteDataContext(){
            dataContext.Connection.Close();
            dataContext.DeleteDatabase();
            dataContext = null;
        }

        internal static AwarenessDataContext GetDataContext(){
            return dataContext;
        }
    }
}
