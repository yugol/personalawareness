/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 22/09/2008
 * Time: 17:30
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
using System.Collections.Generic;
using System.Linq;

namespace Awareness.DB
{
    partial class DBUtil {
        internal static IQueryable<DalAccountType> GetAccountTypes(){
            IQueryable<DalAccountType> accountTypes = null;
            #if DEBUG
            accountTypes = from t in dataContext.accountTypes
                           orderby t.Name
                           select t;
            #else
            accountTypes = from t in dataContext.accountTypes
                           where t.Id > AwarenessDataContext.RESERVED_ACCOUNT_TYPES
                           orderby t.Name
                           select t;
            #endif
            return accountTypes;
        }

        internal static IQueryable<DalAccount> GetAccounts(){
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

        internal static IQueryable<DalBudgetCategory> GetBudgetCategories(){
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

        internal static IQueryable<DalTransaction> GetTransactions(DateTime first, DateTime last){
            IQueryable<DalTransaction> transactions = null;
            #if DEBUG
            transactions = from t in dataContext.transactions
                           where (t.When >= first)&&(t.When <= last)
                           orderby t.When, t.Reason.Name, t.From.Name, t.To.Name
            select t;
            #else
            transactions = from t in dataContext.transactions
                           where (t.When >= first)&&(t.When <= last)
                           where t.FromId > AwarenessDataContext.RESERVED_TRANSFER_LOCATIONS&&t.ToId > AwarenessDataContext.RESERVED_TRANSFER_LOCATIONS
                           orderby t.When, t.Reason.Name, t.From.Name, t.To.Name
            select t;
            #endif
            return transactions;
        }

        internal static IQueryable<DalReason> GetTransferReasons(){
            IQueryable<DalReason> reasons = null;
            #if DEBUG
            reasons = from r in dataContext.transactionReasons
                      orderby r.Name
                      select r;
            #else
            reasons = from r in dataContext.transactionReasons
                      where (r.Type == DalReason.TYPE_DEFAULT)||(r.Type == DalReason.TYPE_FOOD)
                      orderby r.Name
                      select r;
            #endif
            return reasons;
        }

        internal static IQueryable<DalNote> GetRootNotes(){
            IQueryable<DalNote> notes = null;
            notes = from n in dataContext.notes
                    where n.Id > 1
                    where n.ParentId == 1
                    orderby n.Title
                    select n;
            return notes;
        }

        internal static IQueryable<DalNote> GetChildNotes(DalNote note){
            IQueryable<DalNote> notes = from n in dataContext.notes
                                        where n.Id > 1
                                        where n.ParentId == note.Id
                                        orderby n.Title
                                        select n;
            return notes;
        }

        internal static IQueryable<DalAction> GetRootActions(){
            IQueryable<DalAction> actions = from a in dataContext.actions
                                            where a.Id > 1
                                            where a.ParentId == 1
                                            orderby a.Index
                                            select a;
            return actions;
        }

        internal static IQueryable<DalAction> GetChildActions(DalAction action){
            IQueryable<DalAction> actions = from a in dataContext.actions
                                            where a.Id > 1
                                            where a.ParentId == action.Id
                                            orderby a.Index
                                            select a;
            return actions;
        }

        internal static decimal GetTotalOutAmmount(DalTransferLocation location){
            decimal ammount = 0;
            IQueryable<DalTransaction> locationTransactions = dataContext.transactions.Where(t => t.FromId == location.Id);
            foreach (DalTransaction transaction in locationTransactions){
                ammount += transaction.Ammount;
            }
            return ammount;
        }

        internal static decimal GetTotalInAmmount(DalTransferLocation location){
            decimal ammount = 0;
            IQueryable<DalTransaction> locationTransactions = dataContext.transactions.Where(t => t.ToId == location.Id);
            foreach (DalTransaction transaction in locationTransactions){
                ammount += transaction.Ammount;
            }
            return ammount;
        }

        internal static decimal GetBalance(DalAccount a){
            return a.StartingBalance + GetTotalInAmmount(a) - GetTotalOutAmmount(a);
        }

        internal static float GetTransactedQuantity(DalFood reason){
            float quantity = 0;
            IQueryable<DalTransaction> reasonTransactions = dataContext.transactions.Where(t => t.ReasonId == reason.Id);
            foreach (DalTransaction transaction in reasonTransactions){
                quantity += DBUtil.GetCompositeQuantity(transaction);
            }
            return quantity;
        }

        internal static float GetConsumedQuantity(DalFood reason){
            float quantity = 0;
            IQueryable<DalMeal> reasonMeals = dataContext.meals.Where(m => m.WhatId == reason.Id);
            foreach (DalMeal meal in reasonMeals){
                quantity += meal.Quantity;
            }
            return quantity;
        }

        internal static float GetAvailableQuantity(DalFood reason){
            return GetTransactedQuantity(reason) - GetConsumedQuantity(reason);
        }

        internal static float GetAverageEnergyForRecipe(DalRecipe recipe){
            float energy = 0, quantity = 0;

            IQueryable<DalMeal> meals = from m in dataContext.meals
                                        where m.WhyId == recipe.Id
                                        select m;

            foreach (DalMeal meal in meals){
                quantity += meal.Quantity;
                energy += meal.What.GetEnergy(meal.Quantity);
            }

            if (energy == 0){
                return 0;
            }

            return DalFood.QUANTITY_FOR_ENERGY * energy / quantity;
        }

        internal static float GetLastEnergyForRecipe(DalRecipe recipe){
            float energy = 0, quantity = 0;

            try {
                var lastWhen = dataContext.meals.Where(m => m.WhyId == recipe.Id).Max(m => m.When);

                IQueryable<DalMeal> meals = from m in dataContext.meals
                                            where m.WhyId == recipe.Id
                                            where m.When == lastWhen
                                            select m;

                foreach (DalMeal meal in meals){
                    quantity += meal.Quantity;
                    energy += meal.What.GetEnergy(meal.Quantity);
                }

                return DalFood.QUANTITY_FOR_ENERGY * energy / quantity;
            } catch (Exception) {
                return 0;
            }
        }

        internal static float GetCompositeQuantity(DalTransaction transaction){
            if (transaction.Reason is DalRecipe){
                float quantity = 0;

                IQueryable<DalMeal> meals = from m in dataContext.meals
                                            where m.WhyId == transaction.ReasonId
                                            where m.When.Equals(transaction.When)
                                            select m;

                if (meals.Count()> 0){
                    foreach (DalMeal meal in meals){
                        quantity += meal.Quantity;
                    }
                }

                return quantity;
            } else {
                return transaction.Quantity;
            }
        }

        internal static List<ActionOccurrence> GetActionOccurrences(TimeInterval interval){
            IQueryable<DalAction> actions = dataContext.actions
                                            .Where(a => a.Type != DalAction.TYPE_GROUP);
            return SplitAndSortOccurrences(interval, actions);
        }

        static List<ActionOccurrence> SplitAndSortOccurrences(TimeInterval interval, IQueryable<DalAction> actions){
            List<ActionOccurrence> occurrences = new List<ActionOccurrence>();
            foreach (DalAction action in actions) {
                occurrences.AddRange(action.GetOccurrences(interval));
            }
            occurrences.Sort();
            return occurrences;
        }

        internal static List<ActionOccurrence> GetUncompletedActionOccurencesWithReminder(TimeInterval interval) {
            IQueryable<DalAction> actions = dataContext.actions
                                            .Where(a => a.Type != DalAction.TYPE_GROUP)
                                            .Where(a => a.CompletionTime < a.CreationTime)
                                            .Where(a => a.HasCommandReminder||a.HasSoundReminder||a.HasWindowReminder);
            return SplitAndSortOccurrences(interval, actions);
        }

        internal static DalNote GetTodoNote() {
            DalNote note = null;
            try {
                note = dataContext.notes.Where(n => n.ParentId == AwarenessDataContext.NOTE_TODOS_ID).First();
            } catch (InvalidOperationException ex) {
                if (ex.Message == "Sequence contains no elements"){
                    note = new DalNote();
                    note.Title = "Todo list";
                    note.Text = "";
                    note.IsPermanent = true;
                    note.Parent = dataContext.GetNoteById(AwarenessDataContext.NOTE_TODOS_ID);
                    InsertNote(note);
                }
            }
            return note;
        }

        internal static bool IsTransferLocationUsed(DalTransferLocation tl) {
            IQueryable<DalTransaction> q = dataContext.transactions.Where(d => d.FromId == tl.Id||d.ToId == tl.Id);
            if (q.Count() > 0){
                return true;
            }
            return false;
        }
    }
}
