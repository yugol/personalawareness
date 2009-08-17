/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 8/17/2009
 * Time: 5:51 PM
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
#if TEST

using System;
using NUnit.Framework;

namespace Awareness.db.mssql
{
    [TestFixture]
    public class DataStorageTest
    {
        static readonly string TEST_DB_NAME = "awareness_test.sdf";

        DataStorage storage;

        [TestFixtureSetUp]
        public void Init()
        {
            storage = new DataStorage(TEST_DB_NAME);
        }

        [TestFixtureTearDown]
        public void Dispose()
        {
            storage.Delete();
        }

        [Test]
        public void IsTransferLocationUsed()
        {
            DalBudgetCategory bc = new DalBudgetCategory();
            bc.Name = "UsageTestBudget";
            Assert.IsFalse(storage.IsTransferLocationUsed(bc));

            storage.InsertTransferLocation(bc, null);
            Assert.IsFalse(storage.IsTransferLocationUsed(bc));

            DalReason r = new DalReason();
            r.Name = "Reason";
            storage.InsertTransactionReason(r, null);
            DalTransaction t = new DalTransaction();
            t.Reason = r;
            t.From = bc;
            t.To = bc;
            storage.InsertTransaction(t, null);
            Assert.IsTrue(storage.IsTransferLocationUsed(bc));

            storage.DeleteTransaction(t);
            Assert.IsFalse(storage.IsTransferLocationUsed(bc));

            storage.DeleteTransactionReason(r);
            storage.DeleteTransferLocation(bc);
        }


        [Test]
        public void GetTodoNote()
        {
            DalNote note = storage.GetTodoNote();
            Assert.IsNotNull(note);
            Assert.AreEqual("", note.Text);
            note.Text = "dummy";
            storage.UpdateNote(note);
            note = storage.GetTodoNote();
            Assert.AreEqual("dummy", note.Text);
        }


        [Test]
        public void GetBalance()
        {
            DalAccountType at = new DalAccountType() {
                Name = "at"
                   };
            storage.InsertAccountType(at, null);

            DalReason tr = new DalReason() {
                Name = "tr"
                   };
            storage.InsertTransactionReason(tr, null);

            DalAccount a1 = new DalAccount() {
                AccountType = at, Name = "a1", StartingBalance = 100
                                     };
            DalAccount a2 = new DalAccount() {
                AccountType = at, Name = "a2", StartingBalance = -10
                                     };
            DalBudgetCategory bc1 = new DalBudgetCategory() {
                IsIncome = true, Name = "bc1"
                                    };
            DalBudgetCategory bc2 = new DalBudgetCategory() {
                IsIncome = false, Name = "bc2"
                                     };
            storage.InsertTransferLocation(a1, null);
            storage.InsertTransferLocation(a2, null);
            storage.InsertTransferLocation(bc1, null);
            storage.InsertTransferLocation(bc2, null);

            DalTransaction t1 = new DalTransaction() {
                From = bc1, To = a1, Reason = tr, Ammount = 20
                                          };
            DalTransaction t2 = new DalTransaction() {
                From = a1, To = a2, Reason = tr, Ammount = 40
                                         };
            DalTransaction t3 = new DalTransaction() {
                From = a2, To = bc2, Reason = tr, Ammount = 60
                                          };
            DalTransaction t4 = new DalTransaction() {
                From = bc1, To = a1, Reason = tr, Ammount = 10
                                          };
            DalTransaction t5 = new DalTransaction() {
                From = a1, To = a2, Reason = tr, Ammount = 20
                                         };
            DalTransaction t6 = new DalTransaction() {
                From = a2, To = bc2, Reason = tr, Ammount = 30
                                          };
            storage.InsertTransaction(t1, null);
            storage.InsertTransaction(t2, null);
            storage.InsertTransaction(t3, null);
            storage.InsertTransaction(t4, null);
            storage.InsertTransaction(t5, null);
            storage.InsertTransaction(t6, null);

            Assert.AreEqual(60, storage.GetTotalOutAmmount(a1));
            Assert.AreEqual(90, storage.GetTotalOutAmmount(a2));
            Assert.AreEqual(30, storage.GetTotalOutAmmount(bc1));
            Assert.AreEqual(0, storage.GetTotalOutAmmount(bc2));

            Assert.AreEqual(30, storage.GetTotalInAmmount(a1));
            Assert.AreEqual(60, storage.GetTotalInAmmount(a2));
            Assert.AreEqual(0, storage.GetTotalInAmmount(bc1));
            Assert.AreEqual(90, storage.GetTotalInAmmount(bc2));

            Assert.AreEqual(70, storage.GetBalance(a1));
            Assert.AreEqual(-40, storage.GetBalance(a2));

            storage.DeleteTransaction(t6);
            storage.DeleteTransaction(t5);
            storage.DeleteTransaction(t4);
            storage.DeleteTransaction(t3);
            storage.DeleteTransaction(t2);
            storage.DeleteTransaction(t1);

            storage.DeleteTransactionReason(tr);

            storage.DeleteTransferLocation(bc2);
            storage.DeleteTransferLocation(bc1);
            storage.DeleteTransferLocation(a2);
            storage.DeleteTransferLocation(a1);

            storage.DeleteAccountType(at);
        }

        [Test]
        public void AddDeleteAction()
        {
            DalAction a1 = new DalAction() {
                Name = "a1"
                   };
            storage.InsertAction(a1, null);

            DalAction a2 = new DalAction() {
                Name = "a2"
                   };
            storage.InsertAction(a2, null);

            DalAction a3 = new DalAction() {
                Name = "a3"
                   };
            storage.InsertAction(a3, null);

            DalAction a11 = new DalAction() {
                Name = "a11", Parent = a1
                                   };
            storage.InsertAction(a11, null);

            DalAction a12 = new DalAction() {
                Name = "a12", Parent = a1
                                   };
            storage.InsertAction(a12, null);

            DalAction a31 = new DalAction() {
                Name = "a31", Parent = a3
                                   };
            storage.InsertAction(a31, null);

            storage.DeleteActionRec(a1);
            storage.DeleteActionRec(a2);
            storage.DeleteActionRec(a3);

            int count = 0;
            foreach (DalAction action in storage.GetRootActions()) {
                ++count;
            }
            Assert.AreEqual(0, count);
        }
    }
}

#endif
