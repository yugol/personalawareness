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
 * Date: 22/09/2008
 * Time: 12:58
 *
 */
using System;
using System.Linq;

namespace awareness.db
{
    partial class DbUtil {
        internal static bool IsDbAvailable() {
            return dataContext != null;
        }

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

            Configuration.ReadFromDb();

            object o = dataContext.accountTypes.First();
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
                if (DataContextClosing != null){
                    DataContextClosing();
                }
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
