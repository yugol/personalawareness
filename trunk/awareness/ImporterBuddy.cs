/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 06/09/2008
 * Time: 15:06
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

#if DEBUG

using System;
using System.Globalization;
using System.IO;
using System.Linq;

using Awareness.DB;
using LumenWorks.Framework.IO.Csv;

namespace Awareness
{
    internal class ImporterBuddy {
        AwarenessDataContext dc;
        IFormatProvider culture = new CultureInfo("en-US");
        DalAccountType buddyAccountType = new DalAccountType() {
            Name = "BUDDY ACCOUNT"
        };

        internal DalAccountType BuddyAccountType
        {
            get { return buddyAccountType; }
        }

        internal ImporterBuddy(AwarenessDataContext dc){
            this.dc = dc;
        }

        internal void Import(string fileName){
            EnsureImportAccountType();
            CachedCsvReader csv = new CachedCsvReader(new StreamReader(fileName), true);
            foreach (string[] record in csv){
                DalTransaction transaction = CreateTransaction(record);
                transaction.Reason = EnsureReason(transaction.Reason);
                transaction.From = EnsureTransferLocation(transaction.From);
                transaction.To = EnsureTransferLocation(transaction.To);
                dc.transactions.InsertOnSubmit(transaction);
            }
            dc.SubmitChanges();
            csv.Dispose();
        }

        internal void EnsureImportAccountType(){
            try {
                buddyAccountType = dc.accountTypes.Single(at => at.Name == buddyAccountType.Name);
            } catch (Exception) {
                dc.accountTypes.InsertOnSubmit(buddyAccountType);
                dc.SubmitChanges();
            }
        }

        internal DalTransaction CreateTransaction(string[] record){
            DalTransaction transaction = new DalTransaction();

            string[] dateParts = record[0].Split(' ');
            string date = string.Format("{0}{1}{2}", dateParts[1], dateParts[2], dateParts[5]);
            transaction.When = DateTime.ParseExact(date, "MMMddyyyy", null);

            transaction.Reason = new DalReason() {
                Name = record[1]
            };

            string[] ammountParts = record[4].Split(' ');
            transaction.Ammount = (decimal) double.Parse(ammountParts[0]);

            transaction.From = CreateTransferLocation(record[5], true);

            transaction.To = CreateTransferLocation(record[6], false);

            if ( !string.IsNullOrEmpty(record[3]) ){
                // TODO: import buddy note
                // transaction.Memo = record[3];
            }

            return transaction;
        }

        internal DalTransferLocation CreateTransferLocation(string location, bool isFrom) {
            string[] parts = location.Split(':');
            if ( parts[0].Equals("Account") ){
                return new DalAccount() {
                           Name = parts[1], AccountType = buddyAccountType, StartingBalance = 0m
                };
            } else if ( parts[0].Equals("Category") ) {
                return new DalBudgetCategory() {
                           Name = parts[1], IsIncome = isFrom
                };
            }
            return null;
        }

        internal DalReason EnsureReason(DalReason reason) {
            try {
                return dc.transactionReasons.Single(r => r.Name == reason.Name);
            } catch (Exception) {
                dc.transactionReasons.InsertOnSubmit(reason);
                dc.SubmitChanges();
            }
            return reason;
        }

        internal DalTransferLocation EnsureTransferLocation(DalTransferLocation location) {
            if (location is DalAccount){
                return EnsureAccount( (DalAccount) location );
            } else if (location is DalBudgetCategory) {
                return EnsureBudgetCategory( (DalBudgetCategory) location );
            }
            return null;
        }

        internal DalBudgetCategory EnsureBudgetCategory(DalBudgetCategory category) {
            try {
                return dc.transferLocations.OfType<DalBudgetCategory>().Single(r => r.Name == category.Name);
            } catch (Exception) {
                dc.transferLocations.InsertOnSubmit(category);
                dc.SubmitChanges();
            }
            return category;
        }

        internal DalAccount EnsureAccount(DalAccount account) {
            try {
                return dc.transferLocations.OfType<DalAccount>().Single(r => r.Name == account.Name);
            } catch (Exception) {
                dc.transferLocations.InsertOnSubmit(account);
                dc.SubmitChanges();
            }
            return account;
        }
    }
}

#endif
