/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 22/09/2008
 * Time: 13:00
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
