/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 10/12/2008
 * Time: 14:03
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
using Awareness.db.mssql;
namespace Awareness.db
{
    partial class DBUtil
    {
        internal static void InsertAccountType(DalAccountType accountTypes, DalNote note){
            PreludeInsertNotable(accountTypes, note, DataStorage.NOTE_ACCOUNT_TYPES_ID);
            dataContext.accountTypes.InsertOnSubmit(accountTypes);
            dataContext.SubmitChanges();
            NotifyAccountTypesChanged();
        }

        internal static void UpdateAccountType(DalAccountType accountTypes, DalNote note){
            PreludeUpdateNotable(accountTypes, note, DataStorage.NOTE_ACCOUNT_TYPES_ID);
            NotifyAccountTypesChanged();
        }

        internal static void DeleteAccountType(DalAccountType accountType){
            DalNote note = (accountType.HasNote) ? (accountType.Note) : (null);
            dataContext.accountTypes.DeleteOnSubmit(accountType);
            dataContext.SubmitChanges();
            if (note != null){
                DeleteNote(note);
            }
            NotifyAccountTypesChanged();
        }

        static void NotifyAccountTypesChanged(){
            if (AccountTypesChanged != null){
                AccountTypesChanged();
            }
        }
    }
}
