/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 7/23/2009
 * Time: 5:13 PM
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
using System.Collections.Generic;
using System.Linq;

namespace Awareness.db.mssql
{
    partial class DataStorage
    {
        public override DalNote GetRootNote()
        {
            return dataContext.GetNoteById(NOTE_ROOT_ID);
        }

        public override DalAccount GetFoodsAccount()
        {
            return (DalAccount) dataContext.GetTransferLocationById(DataStorage.ACCOUNT_FOODS_ID);
        }

        public override DalAccount GetRecipesAccount()
        {
            return (DalAccount) dataContext.GetTransferLocationById(DataStorage.ACCOUNT_RECIPES_ID);
        }

        public override DalAction GetRootAction()
        {
            return dataContext.GetActionById(DataStorage.ACTION_ROOT_ID);
        }

        public override IEnumerable<DalNote> GetNotes()
        {
            return dataContext.notes;
        }
        
        public override IEnumerable<DalAction> GetActions()
        {
            return dataContext.actions;
        }
        
        
        public override IEnumerable<DalAccountType> GetAccountTypes()
        {
            IQueryable<DalAccountType> accountTypes = null;
            #if DEBUG
            accountTypes = from t in dataContext.accountTypes
                           orderby t.Name
                           select t;
            #else
            accountTypes = from t in dataContext.accountTypes
                           where t.Id > RESERVED_ACCOUNT_TYPES
                           orderby t.Name
                           select t;
            #endif
            return accountTypes;
        }

        public override IEnumerable<DalAccount> GetAccounts()
        {
            IQueryable<DalAccount> accounts = null;
            #if DEBUG
            accounts = from a in dataContext.transferLocations.OfType<DalAccount>()
                       orderby a.Name
                       select a;
            #else
            accounts = from a in dataContext.transferLocations.OfType<DalAccount>()
                       where a.Id > AwarenessDataContext.RESERVED_TRANSFER_LOCATIONS
                       orderby a.Name
                       select a;
            #endif
            return accounts;
        }

        public override IEnumerable<DalBudgetCategory> GetBudgetCategories()
        {
            IQueryable<DalBudgetCategory> categories = null;
            #if DEBUG
            categories = from c in dataContext.transferLocations.OfType<DalBudgetCategory>()
                         orderby c.Name
                         select c;
            #else
            categories = from c in dataContext.transferLocations.OfType<DalBudgetCategory>()
                         where c.Id > AwarenessDataContext.RESERVED_TRANSFER_LOCATIONS
                         orderby c.Name
                         select c;
            #endif
            return categories;
        }

        public override bool IsTransferLocationUsed(DalTransferLocation tl)
        {
            IQueryable<DalTransaction> q = dataContext.transactions
                                           .Where(tr => tr.FromId == tl.Id || tr.ToId == tl.Id);
            if (q.Count() > 0) {
                return true;
            }
            return false;
        }

        public override IEnumerable<DalReason> GetTransactionReasons(sbyte reasonType)
        {
            IQueryable<DalReason> reasons = dataContext.transactionReasons.OrderBy(r => r.Name);
            if (reasonType >= 0) {
                reasons = reasons.Where(r => r.Type == reasonType);
            }
            #if !DEBUG
            reasons = reasons.Where(r => (r.Type == TYPE_DEFAULT) || (r.Type == TYPE_FOOD));
            #endif
            return reasons;
        }

        public override float GetLastEnergyForRecipe(DalRecipe recipe)
        {
            float energy = 0, quantity = 0;

            try {
                var lastWhen = dataContext.meals.Where(m => m.WhyId == recipe.Id).Max(m => m.When);

                IQueryable<DalMeal> meals = from m in dataContext.meals
                                            where m.WhyId == recipe.Id
                                            where m.When == lastWhen
                                            select m;

                foreach (DalMeal meal in meals) {
                    quantity += meal.Quantity;
                    energy += meal.What.GetEnergy(meal.Quantity);
                }

                return DalFood.QUANTITY_FOR_ENERGY * energy / quantity;
            } catch (Exception) {
                return 0;
            }
        }

        public override float GetAverageEnergyForRecipe(DalRecipe recipe)
        {
            float energy = 0, quantity = 0;

            IQueryable<DalMeal> meals = from m in dataContext.meals
                                        where m.WhyId == recipe.Id
                                        select m;

            foreach (DalMeal meal in meals) {
                quantity += meal.Quantity;
                energy += meal.What.GetEnergy(meal.Quantity);
            }

            if (energy == 0) {
                return 0;
            }

            return DalFood.QUANTITY_FOR_ENERGY * energy / quantity;
        }

        public override IEnumerable<DalMeal> GetMealsTimeDesc(int history)
        {
            IQueryable<DalMeal> meals = from m in dataContext.meals

                                        orderby m.When descending, m.What.Name
                                        select m;
            if (history > 0) {
                return meals.Take(history);
            }
            return meals;
        }

        DalTransaction GetRecipeTransaction(DalRecipe why, DateTime when)
        {
            DalTransaction recipeTransaction = null;

            IQueryable<DalTransaction> cookings = from t in dataContext.transactions
                                                  where t.Reason.Id == why.Id
                                                  where t.When == when
                                                  select t;

            if (cookings.Count() > 0) {
                recipeTransaction = cookings.First();
            }

            return recipeTransaction;
        }

        int GetRecipeConstituentCount(DalRecipe recipe, DateTime when)
        {
            IQueryable<DalMeal> meals = from m in dataContext.meals
                                        where m.WhyId == recipe.Id
                                        where m.When.Equals(when)
                                        select m;
            return meals.Count();
        }

        public override DalNote GetTodoNote()
        {
            DalNote note = null;
            try {
                note = dataContext.notes.Where(n => n.ParentId == DataStorage.NOTE_TODOS_ID).First();
            } catch (InvalidOperationException ex) {
                if (ex.Message == "Sequence contains no elements") {
                    note = new DalNote();
                    note.Title = "Todo list";
                    note.Text = "";
                    note.IsPermanent = true;
                    note.Parent = dataContext.GetNoteById(DataStorage.NOTE_TODOS_ID);
                    InsertNote(note);
                }
            }
            return note;
        }

        public override decimal GetTotalOutAmmount(DalTransferLocation location)
        {
            decimal ammount = 0;
            IQueryable<DalTransaction> locationTransactions = dataContext.transactions.Where(t => t.FromId == location.Id);
            foreach (DalTransaction transaction in locationTransactions) {
                ammount += transaction.Ammount;
            }
            return ammount;
        }

        public override decimal GetTotalInAmmount(DalTransferLocation location)
        {
            decimal ammount = 0;
            IQueryable<DalTransaction> locationTransactions = dataContext.transactions.Where(t => t.ToId == location.Id);
            foreach (DalTransaction transaction in locationTransactions) {
                ammount += transaction.Ammount;
            }
            return ammount;
        }

        public override decimal GetBalance(DalAccount a)
        {
            return a.StartingBalance + GetTotalInAmmount(a) - GetTotalOutAmmount(a);
        }

        public override IEnumerable<DalAction> GetRootActions()
        {
            IQueryable<DalAction> actions = from a in dataContext.actions
                                            where a.Id > 1
                                            where a.ParentId == 1
                                            select a;
            return actions;
        }

        public override IEnumerable<DalAction> GetChildActions(DalAction action)
        {
            IQueryable<DalAction> actions = from a in dataContext.actions
                                            where a.Id > 1
                                            where a.ParentId == action.Id
                                            select a;
            return actions;
        }

        public override IEnumerable<DalAccountType> GetDumperAccountTypes()
        {
            return dataContext.accountTypes.Where(r => r.Id > DataStorage.RESERVED_ACCOUNT_TYPES);
        }

        public override IEnumerable<DalAction> GetDumperActions(int parentId)
        {
            return dataContext.actions.Where(n => n.Id > DataStorage.RESERVED_ACTIONS&&n.ParentId == parentId);
        }

        public override IEnumerable<DalMeal> GetDumperMeals()
        {
            return dataContext.meals;
        }

        public override IEnumerable<DalNote> GetDumperNotes(int parentId)
        {
            return dataContext.notes.Where(n => n.Id > DataStorage.RESERVED_NOTES && n.ParentId == parentId);
        }

        public override IEnumerable<DalReason> GetDumperTransactionReasons()
        {
            return dataContext.transactionReasons;
        }

        public override IEnumerable<DalTransaction> GetDumperTransactions()
        {
            return dataContext.transactions;
        }

        public override IEnumerable<DalTransferLocation> GetDumperTransferLocations()
        {
            return dataContext.transferLocations.Where(r => r.Id > DataStorage.RESERVED_TRANSFER_LOCATIONS);
        }


    }
}
