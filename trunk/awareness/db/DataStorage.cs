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

        public event DataChangedHandler AccountTypesChanged;
        
        string id;
        public string Id
        {
            get { return id; }
        }
        
        protected string nick;
        public string Nick
        {
            get { return nick; }
        }
        
        
        public DataStorage(string storageId)
        {
            this.id = storageId;
            this.nick = storageId;
        }
        
        public abstract void Close();
        public abstract void Delete();
            
        // Query
        
        public abstract IEnumerable<DalAccountType> GetAccountTypes();
        
        
        // Create, Update, Delete
        
        // Notes
        public abstract void UpdateNote(DalNote note);
        public abstract void DeleteNote(DalNote note);
        
        
        // AccountTypes
        public abstract void InsertAccountType(DalAccountType accountTypes, DalNote note);        
        public abstract void UpdateAccountType(DalAccountType accountTypes, DalNote note);
        public abstract void DeleteAccountType(DalAccountType accountType);

        protected void NotifyAccountTypesChanged()
        {
            if (AccountTypesChanged != null){
                AccountTypesChanged();
            }
        }

        
    }
}
