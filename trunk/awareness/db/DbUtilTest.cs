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

namespace Awareness.db
{
    [TestFixture]
    public class DBUtilTest {
        [Test]
        public void IsTransferLocationUsed() {
            DalBudgetCategory bc = new DalBudgetCategory();
            bc.Name = "UsageTestBudget";
            Assert.IsFalse(DBUtil.IsTransferLocationUsed(bc));

            DBUtil.InsertTransferLocation(bc, null);
            Assert.IsFalse(DBUtil.IsTransferLocationUsed(bc));
            
            DalReason r = new DalReason();
            r.Name = "Reason";
            DBUtil.InsertTransactionReason(r, null);
            DalTransaction t = new DalTransaction();
            t.Reason = r;
            t.From = bc;
            t.To = bc;
            DBUtil.InsertTransaction(t, null);
            Assert.IsTrue(DBUtil.IsTransferLocationUsed(bc));
            
            DBUtil.DeleteTransaction(t);
            Assert.IsFalse(DBUtil.IsTransferLocationUsed(bc));
            
            DBUtil.DeleteTransactionReason(r);
            DBUtil.DeleteTransferLocation(bc);
        }
        
        
        [Test]
        public void GetTodoNote() {
            DalNote note = DBUtil.GetTodoNote();
            Assert.IsNotNull(note);
            Assert.AreEqual("", note.Text);
            note.Text = "dummy";
            DBUtil.UpdateNote(note);
            note = DBUtil.GetTodoNote();
            Assert.AreEqual("dummy", note.Text);
        }                

        [Test]
        public void GetBalance(){
            DalAccountType at = new DalAccountType() {
                Name = "at"
            };
            DBUtil.InsertAccountType(at, null);

            DalReason tr = new DalReason() {
                Name = "tr"
            };
            DBUtil.InsertTransactionReason(tr, null);

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
            DBUtil.InsertTransferLocation(a1, null);
            DBUtil.InsertTransferLocation(a2, null);
            DBUtil.InsertTransferLocation(bc1, null);
            DBUtil.InsertTransferLocation(bc2, null);

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
            DBUtil.InsertTransaction(t1, null);
            DBUtil.InsertTransaction(t2, null);
            DBUtil.InsertTransaction(t3, null);
            DBUtil.InsertTransaction(t4, null);
            DBUtil.InsertTransaction(t5, null);
            DBUtil.InsertTransaction(t6, null);

            Assert.AreEqual(60, DBUtil.GetTotalOutAmmount(a1));
            Assert.AreEqual(90, DBUtil.GetTotalOutAmmount(a2));
            Assert.AreEqual(30, DBUtil.GetTotalOutAmmount(bc1));
            Assert.AreEqual(0, DBUtil.GetTotalOutAmmount(bc2));

            Assert.AreEqual(30, DBUtil.GetTotalInAmmount(a1));
            Assert.AreEqual(60, DBUtil.GetTotalInAmmount(a2));
            Assert.AreEqual(0, DBUtil.GetTotalInAmmount(bc1));
            Assert.AreEqual(90, DBUtil.GetTotalInAmmount(bc2));

            Assert.AreEqual(70, DBUtil.GetBalance(a1));
            Assert.AreEqual(-40, DBUtil.GetBalance(a2));

            DBUtil.DeleteTransaction(t6);
            DBUtil.DeleteTransaction(t5);
            DBUtil.DeleteTransaction(t4);
            DBUtil.DeleteTransaction(t3);
            DBUtil.DeleteTransaction(t2);
            DBUtil.DeleteTransaction(t1);

            DBUtil.DeleteTransactionReason(tr);

            DBUtil.DeleteTransferLocation(bc2);
            DBUtil.DeleteTransferLocation(bc1);
            DBUtil.DeleteTransferLocation(a2);
            DBUtil.DeleteTransferLocation(a1);

            DBUtil.DeleteAccountType(at);
        }

        [Test]
        public void AddDeleteAction(){
            DalAction a1 = new DalAction() {
                Name = "a1"
            };
            DBUtil.InsertAction(a1, null);

            DalAction a2 = new DalAction() {
                Name = "a2"
            };
            DBUtil.InsertAction(a2, null);

            DalAction a3 = new DalAction() {
                Name = "a3"
            };
            DBUtil.InsertAction(a3, null);

            DalAction a11 = new DalAction() {
                Name = "a11", Parent = a1
            };
            DBUtil.InsertAction(a11, null);

            DalAction a12 = new DalAction() {
                Name = "a12", Parent = a1
            };
            DBUtil.InsertAction(a12, null);

            DalAction a31 = new DalAction() {
                Name = "a31", Parent = a3
            };
            DBUtil.InsertAction(a31, null);

            DBUtil.DeleteActionRec(a1);
            DBUtil.DeleteActionRec(a2);
            DBUtil.DeleteActionRec(a3);

            Assert.AreEqual(0, DBUtil.GetRootActions().Count());
        }

        [Test]
        public void Minutes2TimeSpanString(){
            Assert.AreEqual("0 min", DBUtil.Minutes2TimeSpanString(0));
            Assert.AreEqual("1 min", DBUtil.Minutes2TimeSpanString(1));
            Assert.AreEqual("-1 min", DBUtil.Minutes2TimeSpanString(-1));
            Assert.AreEqual("1 hour ", DBUtil.Minutes2TimeSpanString(60));
            Assert.AreEqual("-1 hour ", DBUtil.Minutes2TimeSpanString(-60));
            Assert.AreEqual("1 hour 30 min", DBUtil.Minutes2TimeSpanString(90));
            Assert.AreEqual("-1 hour 30 min", DBUtil.Minutes2TimeSpanString(-90));
            Assert.AreEqual("2 hours ", DBUtil.Minutes2TimeSpanString(120));
            Assert.AreEqual("-2 hours ", DBUtil.Minutes2TimeSpanString(-120));
            Assert.AreEqual("1 day ", DBUtil.Minutes2TimeSpanString(1440));
            Assert.AreEqual("-1 day ", DBUtil.Minutes2TimeSpanString(-1440));
            Assert.AreEqual("2 days ", DBUtil.Minutes2TimeSpanString(2880));
            Assert.AreEqual("-2 days ", DBUtil.Minutes2TimeSpanString(-2880));
        }

        [TestFixtureSetUp]
        public void Init(){
            DBUtil.CreateDataContext(DBTest.TEST_DB_NAME);
            DBUtil.OpenDataContext(DBTest.TEST_DB_NAME);
        }

        [TestFixtureTearDown]
        public void Dispose(){
            DBUtil.DeleteDataContext();
        }
    }
}
#endif
