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
 * Time: 13:00
 *
 */
using System;
using System.Diagnostics;
using System.Linq;

namespace awareness.db
{
    partial class DbUtil {
        internal static void InsertAccountType(DalAccountType accountTypes){
            dataContext.accountTypes.InsertOnSubmit(accountTypes);
            dataContext.SubmitChanges();
            NotifyAccountTypesChanged();
        }

        internal static void UpdateAccountType(DalAccountType accountTypes){
            dataContext.SubmitChanges();
            NotifyAccountTypesChanged();
        }

        internal static void DeleteAccountType(DalAccountType accountType){
            dataContext.accountTypes.DeleteOnSubmit(accountType);
            dataContext.SubmitChanges();
            NotifyAccountTypesChanged();
        }

        static void NotifyAccountTypesChanged(){
            if (AccountTypesChanged != null){
                AccountTypesChanged();
            }
        }

        internal static void InsertTransferLocation(DalTransferLocation transferLocation){
            dataContext.transferLocations.InsertOnSubmit(transferLocation);
            dataContext.SubmitChanges();
            NotifyTransferLocationsChanged(transferLocation);
        }

        internal static void UpdateTransferLocation(DalTransferLocation transferLocation){
            dataContext.SubmitChanges();
            NotifyTransferLocationsChanged(transferLocation);
        }

        internal static void DeleteTransferLocation(DalTransferLocation transferLocation){
            dataContext.transferLocations.DeleteOnSubmit(transferLocation);
            dataContext.SubmitChanges();
            NotifyTransferLocationsChanged(transferLocation);
        }

        static void NotifyTransferLocationsChanged(DalTransferLocation transferLocation){
            if (transferLocation is DalAccount){
                if (AccountsChanged != null){
                    AccountsChanged();
                }
            } else if (transferLocation is DalBudgetCategory) {
                if (BudgetCategoriesChanged != null){
                    BudgetCategoriesChanged();
                }
            }
            if (TransferLocationsChanged != null){
                TransferLocationsChanged();
            }
        }

        internal static void InsertTransactionReason(DalReason transactionReason){
            dataContext.transactionReasons.InsertOnSubmit(transactionReason);
            dataContext.SubmitChanges();
            NotifyTransactionReasonsChanged(transactionReason);
        }

        internal static void UpdateTransactionReason(DalReason transactionReason){
            dataContext.SubmitChanges();
            NotifyTransactionReasonsChanged(transactionReason);
        }

        internal static void UpdateTransactionReason(int id, sbyte type, string name, float energy){
            dataContext.UpdateTransactionReasonType(id, type, name, energy);
            ReOpenDataContext();
        }

        internal static void DeleteTransactionReason(DalReason transactionReason){
            try {
                dataContext.transactionReasons.DeleteOnSubmit(transactionReason);
                dataContext.SubmitChanges();
                NotifyTransactionReasonsChanged(transactionReason);
            } catch (Exception ex) {
                ReOpenDataContext();
                throw ex;
            }
        }

        static void NotifyTransactionReasonsChanged(DalReason transactionReason){
            if (transactionReason is DalRecipe){
                if (RecipesChanged != null){
                    RecipesChanged();
                }
            } else if (transactionReason is DalFood) {
                if (FoodsChanged != null){
                    FoodsChanged();
                }
            } else if (transactionReason is DalConsumer) {
                if (ConsumersChanged != null){
                    ConsumersChanged();
                }
            } else {
                if (ReasonsChanged != null){
                    ReasonsChanged();
                }
            }
            if (TransactionReasonsChanged != null){
                TransactionReasonsChanged();
            }
        }

        internal static void InsertMeal(DalMeal meal){
            dataContext.meals.InsertOnSubmit(meal);
            dataContext.SubmitChanges();

            if (meal.Why is DalRecipe){
                DalTransaction recipeTransaction = GetRecipeTransaction((DalRecipe) meal.Why, meal.When);
                if (recipeTransaction == null){
                    recipeTransaction = new DalTransaction()
                    {
                        When = meal.When,
                        Reason = meal.Why,
                        Ammount = 0m,
                        From = GetFoodsAccount(),
                        To = GetRecipesAccount(),
                    };
                    InsertTransaction(recipeTransaction, null);
                }
            }

            NotifyMealsChanged();
        }

        internal static void DeleteMeal(DalMeal meal){
            DateTime when = meal.When;
            DalReason why = meal.Why;

            dataContext.meals.DeleteOnSubmit(meal);
            dataContext.SubmitChanges();

            if (why is DalRecipe){
                int constituentCount = GetRecipeConstituentCount((DalRecipe) why, when);
                if (constituentCount == 0){
                    DalTransaction recipeTransaction = GetRecipeTransaction((DalRecipe) why, when);
                    DeleteTransaction(recipeTransaction);
                }
            }

            NotifyMealsChanged();
        }

        static void NotifyMealsChanged(){
            if (MealsChanged != null){
                MealsChanged();
            }
        }
    }
}
