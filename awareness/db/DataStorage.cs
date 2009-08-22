/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 7/23/2009
 * Time: 2:11 PM
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
using System.IO;

namespace Awareness.db
{
    public abstract class DataStorage
    {
        public const int RESERVED_NOTES = 100;
        public const int RESERVED_ACCOUNT_TYPES = 5;
        public const int RESERVED_TRANSFER_LOCATIONS = 10;
        public const int RESERVED_ACTIONS = 100;

        public const int ACCOUNT_TYPE_APPLICATION_INTERNAL_ID = 1;

        public const int ACCOUNT_FOODS_ID = 1;
        public const int ACCOUNT_RECIPES_ID = 2;

        public const int NOTE_ROOT_ID = 1;
        public const int ACTION_ROOT_ID = 1;

        public const int NOTE_APPLICATION_INTERNAL_ID = 2;
        public const int NOTE_PROPERTIES_ID = 3;
        public const int NOTE_ACCOUNT_TYPES_ID = 4;
        public const int NOTE_TRANSFER_LOCATIONS_ID = 5;
        public const int NOTE_REASONS_ID = 6;
        public const int NOTE_TRANSACTIONS_ID = 7;
        public const int NOTE_MEALS_ID = 8;
        public const int NOTE_ACTIONS_ID = 9;
        public const int NOTE_TODOS_ID = 10;

        string connectionString;
        public string ConnectionString
        {
            get {
                return connectionString;
            }
        }

        protected string nick;
        public string Nick
        {
            get {
                return nick;
            }
        }

        public DataStorage(string connectionString)
        {
            this.connectionString = connectionString;
            this.nick = connectionString;
        }

        #region Events

        public event DataChangedHandler AccountTypesChanged;
        public event DataChangedHandler TransferLocationsChanged;
        public event DataChangedHandler AccountsChanged;
        public event DataChangedHandler BudgetCategoriesChanged;
        public event DataChangedHandler RecipesChanged;
        public event DataChangedHandler FoodsChanged;
        public event DataChangedHandler ConsumersChanged;
        public event DataChangedHandler ReasonsChanged;
        public event DataChangedHandler TransactionReasonsChanged;
        public event DataChangedHandler PropertiesChanged;
        public event DataChangedHandler MealsChanged;
        public event DataChangedHandler TransactionsChanged;
        public event DataChangedHandler ActionsChanged;

        #endregion

        #region Interface

        public abstract void Close();
        public abstract void Delete();
        public abstract void RestoreDb(TextReader reader);


        /* Read | Query */

        public abstract DalProperties GetProperties();
        public abstract DalNote GetRootNote();
        public abstract DalNote GetTodoNote();
        public abstract DalAccount GetFoodsAccount();
        public abstract DalAccount GetRecipesAccount();
        public abstract DalAction GetRootAction();

        public abstract IEnumerable<DalAccountType> GetAccountTypes();
        public abstract IEnumerable<DalAccount> GetAccounts();
        public abstract IEnumerable<DalBudgetCategory> GetBudgetCategories();
        public abstract bool IsTransferLocationUsed(DalTransferLocation transferLocation);
        public abstract IEnumerable<DalReason> GetTransactionReasons(sbyte reasonType);
        public abstract float GetLastEnergyForRecipe(DalRecipe recipe);
        public abstract float GetAverageEnergyForRecipe(DalRecipe recipe);
        public abstract IEnumerable<DalMeal> GetMealsTimeDesc(int history);
        public abstract IEnumerable<DalMeal> GetMeals(DateTime date, DalReason why);
        public abstract decimal GetTotalOutAmmount(DalTransferLocation location);
        public abstract decimal GetTotalInAmmount(DalTransferLocation location);
        public abstract decimal GetBalance(DalAccount a);
        public abstract IEnumerable<DalAction> GetRootActions();
        public abstract IEnumerable<DalAction> GetChildActions(DalAction action);
        public abstract IEnumerable<DalConsumer> GetConsumers();
        public abstract IEnumerable<DalRecipe> GetRecipes();
        public abstract IEnumerable<DalFood> GetFoods();
        public abstract List<ActionOccurrence> GetUncheckedActionOccurencesWithReminder(TimeInterval interval);
        public abstract List<ActionOccurrence> GetActionOccurrences(TimeInterval interval);
        public abstract float GetAvailableQuantity(DalFood reason);
        public abstract IEnumerable<DalNote> GetRootNotes();
        public abstract IEnumerable<DalNote> GetChildNotes(DalNote note);
        public abstract IEnumerable<DalBudgetCategory> GetIncomeBudgetCategories();
        public abstract IEnumerable<DalBudgetCategory> GetExpensesBudgetCategories();
        public abstract IEnumerable<DalReason> GetTransactionReasons();

        public abstract IEnumerable<DalAccountType> GetDumperAccountTypes();
        public abstract IEnumerable<DalTransferLocation> GetDumperTransferLocations();
        public abstract IEnumerable<DalReason> GetDumperTransactionReasons();
        public abstract IEnumerable<DalTransaction> GetDumperTransactions();
        public abstract IEnumerable<DalMeal> GetDumperMeals();
        public abstract IEnumerable<DalNote> GetDumperNotes(int parentId);
        public abstract IEnumerable<DalAction> GetDumperActions(int parentId);
        public abstract IEnumerable<DalNote> GetNotes();
        public abstract IEnumerable<DalAction> GetActions();


        /* Create, Update, Delete */

        // Notes
        public abstract void InsertNote(DalNote note);
        public abstract void UpdateNote(DalNote note);
        public abstract void DeleteNote(DalNote note);

        // AccountTypes
        public abstract void InsertAccountType(DalAccountType accountTypes, DalNote note);
        public abstract void UpdateAccountType(DalAccountType accountTypes, DalNote note);
        public abstract void DeleteAccountType(DalAccountType accountType);

        // Transfer Locations
        public abstract void InsertTransferLocation(DalTransferLocation transferLocation, DalNote note);
        public abstract void UpdateTransferLocation(DalTransferLocation transferLocation, DalNote note);
        public abstract void DeleteTransferLocation(DalTransferLocation transferLocation);

        // Transaction Reasons
        public abstract void InsertTransactionReason(DalReason reason, DalNote note);
        public abstract void UpdateTransactionReason(DalReason reason, DalNote note);
        public abstract void UpdateTransactionReason(int id, sbyte type, string name, float energy, DalNote note);
        public abstract void DeleteTransactionReason(DalReason reason);

        // Properties
        public abstract void UpdateProperties(XmlProperties xmlProp);

        // Meals
        public abstract void InsertMeal(DalMeal meal);
        public abstract void DeleteMeal(DalMeal meal);

        // Transactions
        public abstract void InsertTransaction(DalTransaction transaction, DalNote note);
        public abstract void UpdateTransaction(DalTransaction transaction, DalNote note);
        public abstract void DeleteTransaction(DalTransaction transaction);

        // Actions
        public abstract void InsertAction(DalAction action, DalNote note);
        public abstract void UpdateAction(DalAction action, DalNote note);
        public abstract void UpdateActionNoNotification(DalAction action, DalNote note);
        public abstract void DeleteActionRec(DalAction action);

        #endregion

        #region Event handling

        protected void NotifyAccountTypesChanged()
        {
            if (AccountTypesChanged != null) {
                AccountTypesChanged();
            }
        }

        protected void NotifyTransferLocationsChanged(DalTransferLocation transferLocation)
        {
            if (transferLocation is DalAccount) {
                if (AccountsChanged != null) {
                    AccountsChanged();
                }
            } else if (transferLocation is DalBudgetCategory) {
                if (BudgetCategoriesChanged != null) {
                    BudgetCategoriesChanged();
                }
            }
            if (TransferLocationsChanged != null) {
                TransferLocationsChanged();
            }
        }

        protected void NotifyTransactionReasonsChanged(DalReason transactionReason)
        {
            if (transactionReason is DalRecipe) {
                if (RecipesChanged != null) {
                    RecipesChanged();
                }
            } else if (transactionReason is DalFood) {
                if (FoodsChanged != null) {
                    FoodsChanged();
                }
            } else if (transactionReason is DalConsumer) {
                if (ConsumersChanged != null) {
                    ConsumersChanged();
                }
            } else {
                if (ReasonsChanged != null) {
                    ReasonsChanged();
                }
            }
            if (TransactionReasonsChanged != null) {
                TransactionReasonsChanged();
            }
        }

        protected void NotifyPropertiesChanged()
        {
            if (PropertiesChanged != null) {
                PropertiesChanged();
            }
        }

        protected void NotifyMealsChanged()
        {
            if (MealsChanged != null) {
                MealsChanged();
            }
        }

        protected void NotifyTransactionsChanged(DalTransaction transaction)
        {
            if (TransactionsChanged != null) {
                TransactionsChanged();
            }
        }

        protected void NotifyActionsChanged()
        {
            if (ActionsChanged != null) {
                ActionsChanged();
            }
        }

        #endregion

        #region Util

        protected List<ActionOccurrence> SplitAndSortOccurrences(TimeInterval interval, IEnumerable<DalAction> actions)
        {
            List<ActionOccurrence> occurrences = new List<ActionOccurrence>();
            foreach (DalAction action in actions) {
                occurrences.AddRange(action.GetOccurrences(interval));
            }
            occurrences.Sort();
            return occurrences;
        }

        #endregion

    }
}
