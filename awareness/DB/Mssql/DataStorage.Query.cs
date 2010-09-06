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

namespace Awareness.DB.Mssql
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
            return dataContext.Notes;
        }

        public override IEnumerable<DalAction> GetActions()
        {
            return dataContext.Actions;
        }


        public override IEnumerable<DalAccountType> GetAccountTypes()
        {
            IQueryable<DalAccountType> accountTypes = null;
            #if DEBUG
            accountTypes = from t in dataContext.AccountTypes
                           orderby t.Name
                           select t;
            #else
            accountTypes = from t in dataContext.AccountTypes
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
            accounts = from a in dataContext.TransferLocations.OfType<DalAccount>()
                       orderby a.Name
                       select a;
            #else
            accounts = from a in dataContext.TransferLocations.OfType<DalAccount>()
                       where a.Id > DataStorage.RESERVED_TRANSFER_LOCATIONS
                       orderby a.Name
                       select a;
            #endif
            return accounts;
        }

        public override IEnumerable<DalBudgetCategory> GetBudgetCategories()
        {
            IQueryable<DalBudgetCategory> categories = null;
            #if DEBUG
            categories = from c in dataContext.TransferLocations.OfType<DalBudgetCategory>()
                         orderby c.Name
                         select c;
            #else
            categories = from c in dataContext.TransferLocations.OfType<DalBudgetCategory>()
                         where c.Id > DataStorage.RESERVED_TRANSFER_LOCATIONS
                         orderby c.Name
                         select c;
            #endif
            return categories;
        }

        public override IEnumerable<DalReason> GetTransactionReasons()
        {
            IQueryable<DalReason> reasons = null;
            
            reasons = from r in dataContext.TransactionReasons
                      orderby r.Name
                      select r;
            
            // #if DEBUG
            // #else
            // reasons = from r in dataContext.TransactionReasons
            //           where (r.Type == DalReason.TYPE_DEFAULT)||(r.Type == DalReason.TYPE_FOOD)
            //           orderby r.Name
            //           select r;
            // #endif
            
            return reasons;
        }

        public override bool IsTransferLocationUsed(DalTransferLocation transferLocation)
        {
            IQueryable<DalTransaction> q = dataContext.Transactions
                                           .Where(tr => tr.FromId == transferLocation.Id || tr.ToId == transferLocation.Id);
            if (q.Count() > 0) {
                return true;
            }
            return false;
        }

        public override IEnumerable<DalReason> GetTransactionReasons(sbyte reasonType)
        {
            IQueryable<DalReason> reasons = dataContext.TransactionReasons.OrderBy(r => r.Name);
            if (reasonType >= 0) {
                reasons = reasons.Where(r => r.Type == reasonType);
            }
            // #if !DEBUG
            // reasons = reasons.Where(r => (r.Type == DalReason.TYPE_DEFAULT) || (r.Type == DalReason.TYPE_FOOD));
            // #endif
            return reasons;
        }

        public override float GetLastEnergyForRecipe(DalRecipe recipe)
        {
            float energy = 0, quantity = 0;

            try {
                var lastWhen = dataContext.Meals.Where(m => m.WhyId == recipe.Id).Max(m => m.When);

                IQueryable<DalMeal> meals = from m in dataContext.Meals
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

            IQueryable<DalMeal> meals = from m in dataContext.Meals
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
            IQueryable<DalMeal> meals = from m in dataContext.Meals

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

            IQueryable<DalTransaction> cookings = from t in dataContext.Transactions
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
            IQueryable<DalMeal> meals = from m in dataContext.Meals
                                        where m.WhyId == recipe.Id
                                        where m.When.Equals(when)
                                        select m;
            return meals.Count();
        }

        public override DalNote GetTodoNote()
        {
            DalNote note = null;
            try {
                note = dataContext.Notes.Where(n => n.ParentId == DataStorage.NOTE_TODOS_ID).First();
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
            IQueryable<DalTransaction> locationTransactions = dataContext.Transactions.Where(t => t.FromId == location.Id);
            foreach (DalTransaction transaction in locationTransactions) {
                ammount += transaction.Ammount;
            }
            return ammount;
        }

        public override decimal GetTotalInAmmount(DalTransferLocation location)
        {
            decimal ammount = 0;
            IQueryable<DalTransaction> locationTransactions = dataContext.Transactions.Where(t => t.ToId == location.Id);
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
            IQueryable<DalAction> actions = from a in dataContext.Actions
                                            where a.Id > 1
                                            where a.ParentId == 1
                                            select a;
            return actions;
        }

        public override IEnumerable<DalAction> GetChildActions(DalAction action)
        {
            IQueryable<DalAction> actions = from a in dataContext.Actions
                                            where a.Id > 1
                                            where a.ParentId == action.Id
                                            select a;
            return actions;
        }

        public override IEnumerable<DalAccountType> GetDumperAccountTypes()
        {
            return dataContext.AccountTypes.Where(r => r.Id > DataStorage.RESERVED_ACCOUNT_TYPES);
        }

        public override IEnumerable<DalAction> GetDumperActions(int parentId)
        {
            return dataContext.Actions.Where(n => n.Id > DataStorage.RESERVED_ACTIONS&&n.ParentId == parentId);
        }

        public override IEnumerable<DalMeal> GetDumperMeals()
        {
            return dataContext.Meals;
        }

        public override IEnumerable<DalNote> GetDumperNotes(int parentId)
        {
            return dataContext.Notes.Where(n => n.Id > DataStorage.RESERVED_NOTES && n.ParentId == parentId);
        }

        public override IEnumerable<DalReason> GetDumperTransactionReasons()
        {
            return dataContext.TransactionReasons;
        }

        public override IEnumerable<DalTransaction> GetDumperTransactions()
        {
            return dataContext.Transactions;
        }

        public override IEnumerable<DalTransferLocation> GetDumperTransferLocations()
        {
            return dataContext.TransferLocations.Where(r => r.Id > DataStorage.RESERVED_TRANSFER_LOCATIONS);
        }

        public override IEnumerable<DalConsumer> GetConsumers()
        {
            return from r in dataContext.TransactionReasons.OfType<DalConsumer>()
                   orderby r.Name
                   select r;
        }

        public override IEnumerable<DalRecipe> GetRecipes()
        {
            return from r in dataContext.TransactionReasons.OfType<DalRecipe>()
                   orderby r.Name
                   select r;
        }

        public override IEnumerable<DalFood> GetFoods()
        {
            return dataContext.TransactionReasons.OfType<DalFood>().OrderBy(f => f.Name);
        }

        public override List<ActionOccurrence> GetUncheckedActionOccurencesWithReminder(TimeInterval interval)
        {
            IQueryable<DalAction> actions = dataContext.Actions
                                            .Where(a => a.Type != DalAction.TYPE_GROUP)
                                            .Where(a => !a.IsChecked)
                                            .Where(a => a.HasCommandReminder||a.HasSoundReminder||a.HasWindowReminder);
            return SplitAndSortOccurrences(interval, actions);
        }

        public override List<ActionOccurrence> GetActionOccurrences(TimeInterval interval)
        {
            IQueryable<DalAction> actions = from a in dataContext.Actions
                                            where a.Type != DalAction.TYPE_GROUP
                                            orderby a.Start, a.End, a.Name
                                            select a;
            return SplitAndSortOccurrences(interval, actions);
        }

        public override float GetAvailableQuantity(DalFood reason)
        {
            try {
                return reason.AvailableQuantity;
            } catch (CashEmptyException) {
                reason.AvailableQuantity = GetTransactedQuantity(reason) - GetConsumedQuantity(reason);
                dataContext.SubmitChanges();
                return reason.AvailableQuantity;
            }
        }

        float GetConsumedQuantity(DalFood reason)
        {
            float quantity = 0;
            IQueryable<DalMeal> reasonMeals = dataContext.Meals.Where(m => m.WhatId == reason.Id);
            foreach (DalMeal meal in reasonMeals) {
                quantity += meal.Quantity;
            }
            return quantity;
        }

        float GetTransactedQuantity(DalFood reason)
        {
            float quantity = 0;
            IQueryable<DalTransaction> reasonTransactions = dataContext.Transactions.Where(t => t.ReasonId == reason.Id);
            foreach (DalTransaction transaction in reasonTransactions) {
                quantity += GetCompositeQuantity(transaction);
            }
            return quantity;
        }

        float GetCompositeQuantity(DalTransaction transaction)
        {
            if (transaction.Reason is DalRecipe) {
                float quantity = 0;

                IQueryable<DalMeal> meals = from m in dataContext.Meals
                                            where m.WhyId == transaction.ReasonId
                                            where m.When.Equals(transaction.When)
                                            select m;

                if (meals.Count()> 0) {
                    foreach (DalMeal meal in meals) {
                        quantity += meal.Quantity;
                    }
                }

                return quantity;
            } else {
                return transaction.Quantity;
            }
        }

        public override IEnumerable<DalMeal> GetMeals(DateTime date, DalReason why)
        {
            IQueryable<DalMeal> meals = from m in dataContext.Meals
                                        where m.When == date
                                        where m.Why.Id == why.Id
                                        orderby m.What.Name
                                        select m;
            return meals;
        }

        public override IEnumerable<DalNote> GetRootNotes()
        {
            IQueryable<DalNote> notes = from n in dataContext.Notes
                                        where n.Id > 1
                                        where n.ParentId == 1
                                        orderby n.Title
                                        select n;
            return notes;
        }

        public override IEnumerable<DalNote> GetChildNotes(DalNote note)
        {
            IQueryable<DalNote> notes = from n in dataContext.Notes
                                        where n.Id > 1
                                        where n.ParentId == note.Id
                                        orderby n.Title
                                        select n;
            return notes;
        }

        public override IEnumerable<DalBudgetCategory> GetIncomeBudgetCategories()
        {
            return GetBudgetCategories().Where(bc => bc.IsIncome);
        }

        public override IEnumerable<DalBudgetCategory> GetExpensesBudgetCategories()
        {
            return GetBudgetCategories().Where(bc => !bc.IsIncome);
        }

        public override IEnumerable<DalTransaction> GetTransactions(DateTime first, DateTime last, DalTransferLocation transferLocation, string reasonSelectionPattern)
        {
            return _GetTransactions(first, last, transferLocation, reasonSelectionPattern);
        }

        IQueryable<DalTransaction> _GetTransactions(DateTime first, DateTime last, DalTransferLocation transferLocation, string reasonSelectionPattern)
        {
            IQueryable<DalTransaction> transactions = null;

            #if DEBUG
            transactions = from t in dataContext.Transactions
                           where (t.When >= first)&&(t.When <= last)
                           orderby t.When, t.Reason.Name, t.From.Name, t.To.Name
                           select t;
            #else
            transactions = from t in dataContext.Transactions
                           where (t.When >= first)&&(t.When <= last)
                           where t.FromId > DataStorage.RESERVED_TRANSFER_LOCATIONS&&t.ToId > DataStorage.RESERVED_TRANSFER_LOCATIONS
                           orderby t.When, t.Reason.Name, t.From.Name, t.To.Name
                           select t;
            #endif

            if (transferLocation != null) {
                transactions = transactions.Where(t => (t.FromId == transferLocation.Id)||(t.ToId == transferLocation.Id));
            }
            if (reasonSelectionPattern != null) {
                transactions = transactions.Where(t => t.Reason.Name.Contains(reasonSelectionPattern));
            }

            return transactions;
        }

        public override IEnumerable<DalTransaction> GetExpensesHistogramData(DateTime first, DateTime last, DalTransferLocation transferLocation, string reasonSelectionPattern)
        {
            IQueryable<DalTransaction> transactions = _GetTransactions(first, last, transferLocation, reasonSelectionPattern);
            return from t in transactions
                   where t.To.IsBudget && !((DalBudgetCategory) t.To).IsIncome
                   orderby t.When
                   select t;
        }

        public override IEnumerable<DalTransaction> GetIncomeHistogramData(DateTime first, DateTime last, DalTransferLocation transferLocation, string reasonSelectionPattern)
        {
            IQueryable<DalTransaction> transactions = _GetTransactions(first, last, transferLocation, reasonSelectionPattern);
            return from t in transactions
                   where t.From.IsBudget && ((DalBudgetCategory) t.From).IsIncome
                   orderby t.When
                   select t;
        }

        public override IEnumerable<NameAmmount> GetExpensesPieChartData(DateTime first, DateTime last, DalTransferLocation transferLocation, string reasonSelectionPattern)
        {
            IQueryable<DalTransaction> transactions = _GetTransactions(first, last, transferLocation, reasonSelectionPattern);
            return from t in transactions
                   where t.To.IsBudget&&!((DalBudgetCategory) t.To).IsIncome
                   group t by t.To into slice
            select new NameAmmount() {
                Name = slice.Key.Name, Ammount = slice.Sum(t => t.Ammount)
                                             };
        }

        public override IEnumerable<NameAmmount> GetIncomePieChartData(DateTime first, DateTime last, DalTransferLocation transferLocation, string reasonSelectionPattern)
        {
            IQueryable<DalTransaction> transactions = _GetTransactions(first, last, transferLocation, reasonSelectionPattern);
            return from t in transactions
                   where t.From.IsBudget&&((DalBudgetCategory) t.From).IsIncome
                   group t by t.From into slice
                   // orderby slice.Key.Name
            select new NameAmmount() {
                Name = slice.Key.Name, Ammount = slice.Sum(t => t.Ammount)
                                             };
        }


    }
}
