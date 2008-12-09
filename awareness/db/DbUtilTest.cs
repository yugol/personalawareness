/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 25/09/2008
 * Time: 10:57
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

#if TEST

using System;
using System.Linq;
using NUnit.Framework;

namespace awareness.db
{
    [TestFixture]
    public class DbUtilTest {
        [Test]
        public void IsTransferLocationUsed() {
            DalBudgetCategory bc = new DalBudgetCategory();
            bc.Name = "UsageTestBudget";
            Assert.IsFalse(DbUtil.IsTransferLocationUsed(bc));

            DbUtil.InsertTransferLocation(bc);
            Assert.IsFalse(DbUtil.IsTransferLocationUsed(bc));
            
            DalReason r = new DalReason();
            r.Name = "Reason";
            DbUtil.InsertTransactionReason(r, null);
            DalTransaction t = new DalTransaction();
            t.Reason = r;
            t.From = bc;
            t.To = bc;
            DbUtil.InsertTransaction(t, null);
            Assert.IsTrue(DbUtil.IsTransferLocationUsed(bc));
            
            DbUtil.DeleteTransaction(t);
            Assert.IsFalse(DbUtil.IsTransferLocationUsed(bc));
            
            DbUtil.DeleteTransactionReason(r);
            DbUtil.DeleteTransferLocation(bc);
        }
        
        
        [Test]
        public void GetTodoNote() {
            DalNote note = DbUtil.GetTodoNote();
            Assert.IsNotNull(note);
            Assert.AreEqual("", note.Text);
            note.Text = "dummy";
            DbUtil.UpdateNote(note);
            note = DbUtil.GetTodoNote();
            Assert.AreEqual("dummy", note.Text);
        }                

        [Test]
        public void GetBalance(){
            DalAccountType at = new DalAccountType() {
                Name = "at"
            };
            DbUtil.InsertAccountType(at);

            DalReason tr = new DalReason() {
                Name = "tr"
            };
            DbUtil.InsertTransactionReason(tr, null);

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
            DbUtil.InsertTransferLocation(a1);
            DbUtil.InsertTransferLocation(a2);
            DbUtil.InsertTransferLocation(bc1);
            DbUtil.InsertTransferLocation(bc2);

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
            DbUtil.InsertTransaction(t1, null);
            DbUtil.InsertTransaction(t2, null);
            DbUtil.InsertTransaction(t3, null);
            DbUtil.InsertTransaction(t4, null);
            DbUtil.InsertTransaction(t5, null);
            DbUtil.InsertTransaction(t6, null);

            Assert.AreEqual(60, DbUtil.GetTotalOutAmmount(a1));
            Assert.AreEqual(90, DbUtil.GetTotalOutAmmount(a2));
            Assert.AreEqual(30, DbUtil.GetTotalOutAmmount(bc1));
            Assert.AreEqual(0, DbUtil.GetTotalOutAmmount(bc2));

            Assert.AreEqual(30, DbUtil.GetTotalInAmmount(a1));
            Assert.AreEqual(60, DbUtil.GetTotalInAmmount(a2));
            Assert.AreEqual(0, DbUtil.GetTotalInAmmount(bc1));
            Assert.AreEqual(90, DbUtil.GetTotalInAmmount(bc2));

            Assert.AreEqual(70, DbUtil.GetBalance(a1));
            Assert.AreEqual(-40, DbUtil.GetBalance(a2));

            DbUtil.DeleteTransaction(t6);
            DbUtil.DeleteTransaction(t5);
            DbUtil.DeleteTransaction(t4);
            DbUtil.DeleteTransaction(t3);
            DbUtil.DeleteTransaction(t2);
            DbUtil.DeleteTransaction(t1);

            DbUtil.DeleteTransactionReason(tr);

            DbUtil.DeleteTransferLocation(bc2);
            DbUtil.DeleteTransferLocation(bc1);
            DbUtil.DeleteTransferLocation(a2);
            DbUtil.DeleteTransferLocation(a1);

            DbUtil.DeleteAccountType(at);
        }

        [Test]
        public void AddDeleteAction(){
            DalAction a1 = new DalAction() {
                Name = "a1"
            };
            DbUtil.AddAction(a1);
            Assert.AreEqual(0, a1.Index);

            DalAction a2 = new DalAction() {
                Name = "a2"
            };
            DbUtil.AddAction(a2);
            Assert.AreEqual(1, a2.Index);

            DalAction a3 = new DalAction() {
                Name = "a3"
            };
            DbUtil.AddAction(a3);
            Assert.AreEqual(2, a3.Index);

            DalAction a11 = new DalAction() {
                Name = "a11", Parent = a1
            };
            DbUtil.AddAction(a11);
            Assert.AreEqual(0, a11.Index);

            DalAction a12 = new DalAction() {
                Name = "a12", Parent = a1
            };
            DbUtil.AddAction(a12);
            Assert.AreEqual(1, a12.Index);

            DalAction a31 = new DalAction() {
                Name = "a31", Parent = a3
            };
            DbUtil.AddAction(a31);
            Assert.AreEqual(0, a31.Index);

            DbUtil.DeleteActionRecursive(a1);
            DbUtil.DeleteActionRecursive(a2);
            DbUtil.DeleteActionRecursive(a3);

            Assert.AreEqual(0, DbUtil.GetRootActions().Count());
        }

        [Test]
        public void InsertDeleteAction(){
            DalAction a = new DalAction() {
                Name = "a"
            };
            DbUtil.AddAction(a);
            Assert.AreEqual(0, a.Index);

            DalAction a1 = new DalAction() {
                Name = "a1", Parent = a
            };
            DbUtil.InsertAction(0, a1);
            Assert.AreEqual(0, a1.Index);

            DalAction a2 = new DalAction() {
                Name = "a2", Parent = a
            };
            DbUtil.InsertAction(0, a2);
            Assert.AreEqual(0, a2.Index);
            Assert.AreEqual(1, a1.Index);

            DalAction a3 = new DalAction() {
                Name = "a3", Parent = a
            };
            DbUtil.InsertAction(1, a3);
            Assert.AreEqual(1, a3.Index);
            Assert.AreEqual(0, a2.Index);
            Assert.AreEqual(2, a1.Index);

            DalAction a4 = new DalAction() {
                Name = "a4", Parent = a
            };
            DbUtil.InsertAction(3, a4);
            Assert.AreEqual(3, a4.Index);
            Assert.AreEqual(1, a3.Index);
            Assert.AreEqual(0, a2.Index);
            Assert.AreEqual(2, a1.Index);

            DalAction a5 = new DalAction() {
                Name = "a5", Parent = a
            };

            DbUtil.DeleteActionRecursive(a);
            Assert.AreEqual(0, DbUtil.GetRootActions().Count());
        }

        [Test]
        public void Minutes2TimeSpanString(){
            Assert.AreEqual("0 min", DbUtil.Minutes2TimeSpanString(0));
            Assert.AreEqual("1 min", DbUtil.Minutes2TimeSpanString(1));
            Assert.AreEqual("-1 min", DbUtil.Minutes2TimeSpanString(-1));
            Assert.AreEqual("1 hour ", DbUtil.Minutes2TimeSpanString(60));
            Assert.AreEqual("-1 hour ", DbUtil.Minutes2TimeSpanString(-60));
            Assert.AreEqual("1 hour 30 min", DbUtil.Minutes2TimeSpanString(90));
            Assert.AreEqual("-1 hour 30 min", DbUtil.Minutes2TimeSpanString(-90));
            Assert.AreEqual("2 hours ", DbUtil.Minutes2TimeSpanString(120));
            Assert.AreEqual("-2 hours ", DbUtil.Minutes2TimeSpanString(-120));
            Assert.AreEqual("1 day ", DbUtil.Minutes2TimeSpanString(1440));
            Assert.AreEqual("-1 day ", DbUtil.Minutes2TimeSpanString(-1440));
            Assert.AreEqual("2 days ", DbUtil.Minutes2TimeSpanString(2880));
            Assert.AreEqual("-2 days ", DbUtil.Minutes2TimeSpanString(-2880));
        }

        [TestFixtureSetUp]
        public void Init(){
            DbUtil.CreateDataContext(DbTest.TEST_DB_NAME);
            DbUtil.OpenDataContext(DbTest.TEST_DB_NAME);
        }

        [TestFixtureTearDown]
        public void Dispose(){
            DbUtil.DeleteDataContext();
        }
    }
}
#endif
