/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 02/11/2008
 * Time: 19:12
 *
 */
using System;

namespace awareness.db
{
    partial class DbUtil {
        
        internal static void InsertTransaction(DalTransaction transaction){
            dataContext.transactions.InsertOnSubmit(transaction);
            dataContext.SubmitChanges();
            NotifyTransactionsChanged(transaction);
        }

        internal static void UpdateTransaction(DalTransaction transaction){
            dataContext.SubmitChanges();
            NotifyTransactionsChanged(transaction);
        }

        internal static void DeleteTransaction(DalTransaction transaction){
            dataContext.transactions.DeleteOnSubmit(transaction);
            dataContext.SubmitChanges();
            NotifyTransactionsChanged(transaction);
        }

        static void NotifyTransactionsChanged(DalTransaction transaction){
            if (TransactionsChanged != null){
                TransactionsChanged();
            }
        }
    }
}
