/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 7/25/2009
 * Time: 2:47 PM
 * 
 *
 * Copyright (c) 2008, 2009 Iulian GORIAC
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

namespace Awareness.db.mssql
{
    partial class DataStorage
    {
        public override void InsertMeal(DalMeal meal)
        {
            dataContext.meals.InsertOnSubmit(meal);
            meal.What.AvailableQuantitySetNull();
            if (meal.Why.Type == DalReason.TYPE_FOOD) {
            	meal.Why.AvailableQuantitySetNull();
            }
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

        public override void DeleteMeal(DalMeal meal)
        {
            DateTime when = meal.When;
            DalReason why = meal.Why;

            meal.What.AvailableQuantitySetNull();
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

    }
}
