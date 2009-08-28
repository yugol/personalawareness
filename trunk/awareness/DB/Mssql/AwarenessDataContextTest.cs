/*
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

/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 03/09/2008
 * Time: 18:16
 *
 */
#if TEST

// #define DEBUG_CREATE_DATABASE

using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace Awareness.DB.Mssql
{
    [TestFixture]
    public class AwarenessDataContextTest
    {
        static readonly string TEST_DB_NAME = "awareness_test.sdf";
        AwarenessDataContext dc = null;

        #if !DEBUG_CREATE_DATABASE
        [TestFixtureSetUp]
        public void SetUp()
        {
            dc = new AwarenessDataContext(TEST_DB_NAME);
            dc.CreateDatabase();
        }
        #endif
        [TestFixtureTearDown]
        public void TearDown()
        {
            dc.Connection.Close();
            dc.DeleteDatabase();
        }

        [Test]
        public void CreateDatabase()
        {
            #if DEBUG_CREATE_DATABASE
            dc = new AwarenessDataContext(TEST_DB_NAME);
            dc.CreateDatabase();
            #endif
            Assert.AreEqual("01.10", dc.GetProperties().DBVersion.ToString("00.00"));
            Assert.AreEqual(1, dc.AccountTypes.Count());
            Assert.AreEqual(2, dc.TransferLocations.Count());
            Assert.AreEqual(0, dc.TransactionReasons.Count());
            Assert.AreEqual(0, dc.Transactions.Count());
            Assert.AreEqual(0, dc.Meals.Count());
            Assert.AreEqual(10, dc.Notes.Count());
            Assert.AreEqual(1, dc.Actions.Count());
        }

        [Test]
        public void AccountTypes()
        {
            DalAccountType ac1 = new DalAccountType();
            ac1.Name = "Cash";
            dc.AccountTypes.InsertOnSubmit(ac1);
            DalAccountType ac2 = new DalAccountType();
            ac2.Name = "Bank";
            dc.AccountTypes.InsertOnSubmit(ac2);
            dc.SubmitChanges();

            IEnumerable<DalAccountType> query = from row in dc.AccountTypes select row;
            Assert.AreEqual(3, query.Count());

            dc.AccountTypes.DeleteOnSubmit(ac1);
            dc.AccountTypes.DeleteOnSubmit(ac2);
            dc.SubmitChanges();
            query = from row in dc.AccountTypes select row;
            Assert.AreEqual(1, query.Count());
        }

        [Test]
        public void TransferLocations()
        {
            DalAccountType at = new DalAccountType() {
                Name = "Cash"
                   };
            dc.AccountTypes.InsertOnSubmit(at);
            dc.SubmitChanges();

            DalAccount ac = new DalAccount() {
                AccountType = at, Name = "ATE"
                                     };
            dc.TransferLocations.InsertOnSubmit(ac);
            DalBudgetCategory bc = new DalBudgetCategory() {
                Name = "Food"
                   };
            dc.TransferLocations.InsertOnSubmit(bc);
            dc.SubmitChanges();

            var query = from t in dc.TransferLocations select t;
            Assert.AreEqual(4, query.Count());

            try { // check foreign key existence
                dc.AccountTypes.DeleteOnSubmit(at);
                dc.SubmitChanges();
                Assert.Fail();
            } catch (AssertionException e) {
                throw e;
            } catch (Exception) {
                dc.Connection.Close();
                dc = new AwarenessDataContext(TEST_DB_NAME);
            }


            IEnumerable<DalAccount> query1 = from t in dc.TransferLocations.OfType<DalAccount>() select t;
            Assert.AreEqual(3, query1.Count());
            IEnumerable<DalBudgetCategory> query2 = from t in dc.TransferLocations.OfType<DalBudgetCategory>() select t;
            Assert.AreEqual(1, query2.Count());

            dc.TransferLocations.DeleteOnSubmit(query1.Last());
            dc.TransferLocations.DeleteOnSubmit(query2.Last());
            dc.SubmitChanges();

            IEnumerable<DalAccountType> query3 = from t in dc.AccountTypes select t;
            dc.AccountTypes.DeleteOnSubmit(query3.Last());
            dc.SubmitChanges();
        }

        [Test]
        public void Transactions()
        {
            // db = new AwarenessDataContext(testDbName);
            // db.CreateDatabase();

            DalAccountType at = new DalAccountType() {
                Name = "Cash"
                   };
            dc.AccountTypes.InsertOnSubmit(at);
            dc.SubmitChanges();

            DalAccount ac = new DalAccount() {
                AccountType = at, Name = "ATE"
                                     };
            dc.TransferLocations.InsertOnSubmit(ac);
            DalBudgetCategory bc = new DalBudgetCategory() {
                Name = "Food"
                   };
            dc.TransferLocations.InsertOnSubmit(bc);
            dc.SubmitChanges();

            DalReason tr = new DalReason() {
                Name = "P?ine"
                   };
            dc.TransactionReasons.InsertOnSubmit(tr);
            dc.SubmitChanges();

            DalTransaction t = new DalTransaction() {
                From = ac, To = bc, Ammount = 2.23m, Reason = tr
                                          };
            dc.Transactions.InsertOnSubmit(t);
            dc.SubmitChanges();

            try { // check foreign key existence
                dc.TransactionReasons.DeleteOnSubmit(dc.TransactionReasons.First());
                dc.SubmitChanges();
                Assert.Fail();
            } catch (AssertionException e) {
                throw e;
            } catch (Exception) {
                dc.Connection.Close();
                dc = new AwarenessDataContext(TEST_DB_NAME);
            }

            try { // check foreign key existence
                dc.TransferLocations.DeleteOnSubmit(dc.TransferLocations.OfType<DalAccount>().Last());
                dc.SubmitChanges();
                Assert.Fail();
            } catch (AssertionException e) {
                throw e;
            } catch (Exception) {
                dc.Connection.Close();
                dc = new AwarenessDataContext(TEST_DB_NAME);
            }

            try { // check foreign key existence
                dc.TransferLocations.DeleteOnSubmit(dc.TransferLocations.OfType<DalBudgetCategory>().Last());
                dc.SubmitChanges();
                Assert.Fail();
            } catch (AssertionException e) {
                throw e;
            } catch (Exception) {
                dc.Connection.Close();
                dc = new AwarenessDataContext(TEST_DB_NAME);
            }

            dc.Transactions.DeleteOnSubmit(dc.Transactions.OfType<DalTransaction>().First());
            dc.SubmitChanges();
            IEnumerable<DalBudgetCategory> q1 = from e in dc.TransferLocations.OfType<DalBudgetCategory>() select e;
            dc.TransferLocations.DeleteOnSubmit(q1.Last());
            dc.SubmitChanges();
            IEnumerable<DalAccount> q2 = from e in dc.TransferLocations.OfType<DalAccount>() select e;
            dc.TransferLocations.DeleteOnSubmit(q2.Last());
            dc.SubmitChanges();
            dc.TransactionReasons.DeleteOnSubmit(dc.TransactionReasons.First());
            dc.SubmitChanges();
            IEnumerable<DalAccountType> q3 = from e in dc.AccountTypes select e;
            dc.AccountTypes.DeleteOnSubmit(q3.Last());
            dc.SubmitChanges();
        }

        [Test]
        public void UpdateTransactionReason()
        {
            DalReason tr1 = new DalReason() {
                Name = "t'r'1"
                   };
            dc.TransactionReasons.InsertOnSubmit(tr1);
            dc.SubmitChanges();

            int id = tr1.Id;

            dc.UpdateTransactionReasonType(id, DalReason.TYPE_FOOD, "tr'1'", 50);

            dc.Connection.Close();
            dc = new AwarenessDataContext(TEST_DB_NAME);

            DalFood tr2 = dc.TransactionReasons.OfType<DalFood>().First();
            Assert.AreEqual(id, tr2.Id);
            Assert.AreEqual("tr'1'", tr2.Name);
            Assert.AreEqual(50, tr2.Energy);

            dc.Connection.Close();
            dc = new AwarenessDataContext(TEST_DB_NAME);

            dc.UpdateTransactionReasonType(id, DalReason.TYPE_RECIPE, "'t'r1", 0);
            tr1 = dc.TransactionReasons.OfType<DalRecipe>().First();
            Assert.AreEqual(id, tr1.Id);
            Assert.AreEqual("'t'r1", tr1.Name);
            Assert.AreEqual(100, ((DalRecipe) tr1).Energy);

            dc.Connection.Close();
            dc = new AwarenessDataContext(TEST_DB_NAME);

            dc.UpdateTransactionReasonType(id, DalReason.TYPE_CONSUMER, "'t'r1", 0);
            tr1 = dc.TransactionReasons.OfType<DalConsumer>().First();
            Assert.AreEqual(id, tr1.Id);
            Assert.AreEqual("'t'r1", tr1.Name);

            dc.Connection.Close();
            dc = new AwarenessDataContext(TEST_DB_NAME);

            dc.UpdateTransactionReasonType(id, DalReason.TYPE_DEFAULT, "'t'r1", 100);
            tr1 = dc.TransactionReasons.OfType<DalReason>().First();
            Assert.AreEqual(id, tr1.Id);
            Assert.AreEqual("'t'r1", tr1.Name);

            dc.TransactionReasons.DeleteOnSubmit(tr1);
            dc.SubmitChanges();
        }

        [Test]
        public void Meals()
        {
            DalFood tr = new DalFood() {
                Name = "Castravete"
                   };
            dc.TransactionReasons.InsertOnSubmit(tr);
            dc.SubmitChanges();

            DalConsumer c = new DalConsumer() {
                Name = "C"
                   };
            dc.TransactionReasons.InsertOnSubmit(c);
            dc.SubmitChanges();

            DalMeal m1 = new DalMeal() {
                When = DateTime.Now, What = tr, Quantity = 12, Why = c
                                        };
            dc.Meals.InsertOnSubmit(m1);
            dc.SubmitChanges();

            try { // check foreign key for what
                dc.TransactionReasons.DeleteOnSubmit(tr);
                dc.SubmitChanges();
                Assert.Fail("No FK for [what] column");
            } catch (AssertionException e) {
                throw e;
            } catch (Exception) {
                dc.Connection.Close();
                dc = new AwarenessDataContext(TEST_DB_NAME);
            }

            try { // check foreign key for why
                c = dc.TransactionReasons.OfType<DalConsumer>().First();
                dc.TransactionReasons.DeleteOnSubmit(c);
                dc.SubmitChanges();
                Assert.Fail("No FK for [why] column");
            } catch (AssertionException e) {
                throw e;
            } catch (Exception) {
                dc.Connection.Close();
                dc = new AwarenessDataContext(TEST_DB_NAME);
            }

            m1 = dc.Meals.First();
            Assert.AreEqual("Castravete", m1.What.Name);

            dc.Meals.DeleteOnSubmit(m1);
            dc.SubmitChanges();

            dc.TransactionReasons.DeleteOnSubmit(dc.TransactionReasons.OfType<DalFood>().First());
            dc.TransactionReasons.DeleteOnSubmit(dc.TransactionReasons.OfType<DalConsumer>().First());
            dc.SubmitChanges();
        }

        [Test]
        public void Notes()
        {
            DalNote n1 = dc.Notes.Select(n => n).First();
            Assert.AreEqual(1, n1.Id);
            Assert.AreEqual(1, n1.ParentId);
            Assert.AreEqual(1, n1.Icon);
            Assert.AreEqual(DateTime.Now.Date, n1.CreationTime.Date);
            Assert.AreEqual("Root", n1.Title);
            Assert.IsNull(n1.Text);

            DalNote n2 = new DalNote() {
                Parent = n1, Title = "Test", Text = "<html></html>"
                                                };
            dc.Notes.InsertOnSubmit(n2);
            dc.SubmitChanges();
            Assert.AreEqual(101, n2.Id);
            Assert.AreEqual(1, n2.ParentId);
            Assert.AreEqual(0, n2.Icon);
            Assert.AreEqual(DateTime.Now.Date, n2.CreationTime.Date);
            Assert.AreEqual("Test", n2.Title);
            Assert.AreEqual("<html></html>", n2.Text);

            try { // check foreign key for parent
                dc.Notes.DeleteOnSubmit(n1);
                dc.SubmitChanges();
                Assert.Fail("No FK for [parent] column");
            } catch (AssertionException e) {
                throw e;
            } catch (Exception) {
                dc.Connection.Close();
                dc = new AwarenessDataContext(TEST_DB_NAME);
            }

            dc.Notes.DeleteOnSubmit(dc.Notes.Where(n => n.Id > DataStorage.RESERVED_NOTES).First());
            dc.SubmitChanges();

            Assert.AreEqual(10, dc.Notes.Count());
        }
    }
}
#endif
