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
 * Date: 08/09/2008
 * Time: 13:04
 *
 */
#if TEST

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Awareness.db.mssql;

using NUnit.Framework;

namespace Awareness.db
{
    [TestFixture]
    public class DumperTest {
        IDictionary<string, DateTime> dateTimeMap = new Dictionary<string, DateTime>();

        void PopulateDb(){
            AwarenessDataContext dc = DBUtil.GetDataContext();

            DalAccount ra1 = (DalAccount) dc.GetTransferLocationById(DataStorage.ACCOUNT_FOODS_ID);
            DalAccount ra2 = (DalAccount) dc.GetTransferLocationById(DataStorage.ACCOUNT_RECIPES_ID);;

            DalBudgetCategory bc1 = new DalBudgetCategory() {
                IsIncome = true, Name = "bc1"
            };
            DBUtil.InsertTransferLocation(bc1, null);
            DalBudgetCategory bc2 = new DalBudgetCategory() {
                IsIncome = false, Name = "bc'2'"
            };
            DBUtil.InsertTransferLocation(bc2, null);

            DalAccountType at1 = new DalAccountType { Name = "at1" };
            DBUtil.InsertAccountType(at1, null);
            DalAccountType at = new DalAccountType { Name = "at" };
            DBUtil.InsertAccountType(at, null);
            DBUtil.DeleteAccountType(at);
            DalAccountType at2 = new DalAccountType { Name = "at'2'" };
            DBUtil.InsertAccountType(at2, null);

            DalAccount a1 = new DalAccount() {
                AccountType = at1, Name = "a1", StartingBalance = -10m
            };
            DBUtil.InsertTransferLocation(a1, null);
            DalAccount a2 = new DalAccount() {
                AccountType = at2, Name = "a'2'", StartingBalance = 0.01m
            };
            DBUtil.InsertTransferLocation(a2, null);

            DalReason tr1 = new DalReason() {
                Name = "tr1"
            };
            DBUtil.InsertTransactionReason(tr1, null);
            DalReason tr2 = new DalReason() {
                Name = "tr'2'"
            };
            DBUtil.InsertTransactionReason(tr2, null);
            DalFood tr3 = new DalFood() {
                Name = "tr3", Energy = 50
            };
            DBUtil.InsertTransactionReason(tr3, null);
            DalRecipe tr4 = new DalRecipe() {
                Name = "r1"
            };
            DBUtil.InsertTransactionReason(tr4, null);
            DalConsumer tr5 = new DalConsumer() {
                Name = "c1"
            };
            DBUtil.InsertTransactionReason(tr5, null);

            DalTransaction t1 = new DalTransaction() {
                When = new DateTime(2008, 01, 02), From = bc1, To = a1, Reason = tr1, Ammount = 1m, Quantity = 0
            };
            DBUtil.InsertTransaction(t1, null);
            DalTransaction t2 = new DalTransaction() {
                When = new DateTime(2008, 03, 04), From = a1, To = a2, Reason = tr2, Ammount = 2m, Quantity = 1
            };
            DBUtil.InsertTransaction(t2, null);
            DalTransaction t3 = new DalTransaction() {
                When = new DateTime(2008, 05, 06), From = a2, To = bc2, Reason = tr3, Ammount = 3m, Quantity = 200
            };
            DBUtil.InsertTransaction(t3, null);
            DalTransaction t4 = new DalTransaction() {
                When = new DateTime(2008, 07, 08), From = ra1, To = ra2, Reason = tr4, Ammount = 0m, Quantity = 1400
            };
            DBUtil.InsertTransaction(t4, null);

            DalMeal m1 = new DalMeal() {
                When = new DateTime(2008, 07, 08), What = tr3, Quantity = 150, Why = tr5
            };
            DBUtil.InsertMeal(m1);
            DalMeal m2 = new DalMeal() {
                When = new DateTime(2008, 07, 09), What = tr3, Quantity = 200, Why = tr4
            };
            DBUtil.InsertMeal(m2);
            DalMeal m3 = new DalMeal() {
                When = new DateTime(2008, 07, 10), What = tr4, Quantity = 250, Why = tr5
            };
            DBUtil.InsertMeal(m3);

            DalNote rootNote = dc.GetNoteById(DataStorage.NOTE_ROOT_ID);
            DalNote n1 = new DalNote() {
                Parent = rootNote, IsExpanded = true, Icon = 0, Title = "n1"
            };
            DBUtil.InsertNote(n1);
            DalNote n2 = new DalNote() {
                Parent = rootNote, IsExpanded = true, Icon = 1, Title = "n2"
            };
            DBUtil.InsertNote(n2);
            DalNote n3 = new DalNote() {
                Parent = n2, IsExpanded = false, Icon = 2, Title = "n3", Text = "for (int i = 0; i < 10; ++i);"
            };
            DBUtil.InsertNote(n3);
            DalNote n4 = new DalNote() {
                Parent = n1, IsExpanded = false, Icon = 2, Title = "n4", Text = ""
            };
            DBUtil.InsertNote(n4);
            n3.Parent = n4;
            DBUtil.UpdateNote(n3);
            DBUtil.DeleteNote(n2);

            dateTimeMap["note1_CreationTime"] = n1.CreationTime;
            dateTimeMap["note3_CreationTime"] = n3.CreationTime;
            dateTimeMap["note4_CreationTime"] = n4.CreationTime;

            DalAction rootAction = dc.GetActionById(DataStorage.ACTION_ROOT_ID);
            DalAction act1 = new DalAction() {
                Parent = rootAction, Name = "act1"
            };
            DBUtil.InsertAction(act1, null);
            DalAction act2 = new DalAction() {
                Parent = rootAction, Name = "act2"
            };
            act2.HasWindowReminder = true;
            act2.HasSoundReminder = true;
            act2.HasCommandReminder = true;
            DBUtil.InsertAction(act2, null);
            act1.Parent = act2;
            DBUtil.UpdateAction(act1, null);
            
            Configuration.DBProperties.CurrencySymbol = "USD";
            DBUtil.UpdateProperties();
        }

        [Test]
        public void _RunMeFirst_DumpRestore(){
            PopulateDb();

            AwarenessDataContext dc = DBUtil.GetDataContext();
            
            DalProperties dbProp = DBUtil.GetProperties();
            Assert.AreEqual(1.00F, dbProp.DBVersion);
            XmlProperties xmlProp = new XmlProperties(dbProp.Xml);
            Assert.AreEqual("USD", xmlProp.CurrencySymbol);

            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            Dumper dd = new Dumper(dc);
            dd.DumpAll(writer);

            DBUtil.DeleteDataContext();
            DBUtil.CreateDataContext(DBTest.TEST_DB_NAME);
            DBUtil.OpenDataContext(DBTest.TEST_DB_NAME);

            dc = DBUtil.GetDataContext();

            string dump = sb.ToString();
            StringReader reader = new StringReader(dump);
            dd = new Dumper(dc);
            dd.RestoreDb(reader);

            dbProp = DBUtil.GetProperties();
            xmlProp = new XmlProperties(dbProp.Xml);
            Assert.AreEqual("USD", xmlProp.CurrencySymbol);

            IEnumerable<DalTransaction> transactions = dc.transactions.Select(e => e);
            DalTransaction t = transactions.First();
            Assert.AreEqual("bc1", t.From.Name);
            Assert.AreEqual("a1", t.To.Name);
            Assert.AreEqual("tr1", t.Reason.Name);

            t = transactions.ElementAt(1);
            Assert.AreEqual("a1", t.From.Name);
            Assert.AreEqual("a'2'", t.To.Name);
            Assert.AreEqual("tr'2'", t.Reason.Name);

            t = transactions.ElementAt(2);
            Assert.AreEqual("a'2'", t.From.Name);
            Assert.AreEqual("bc'2'", t.To.Name);
            Assert.AreEqual("tr3", t.Reason.Name);

            IEnumerable<DalReason> reasons = dc.transactionReasons.Select(r => r);
            Assert.AreEqual(5, reasons.Count());
            Assert.IsInstanceOfType(typeof(DalReason), reasons.ElementAt(0));
            Assert.IsInstanceOfType(typeof(DalReason), reasons.ElementAt(1));
            Assert.IsInstanceOfType(typeof(DalFood), reasons.ElementAt(2));
            Assert.IsInstanceOfType(typeof(DalRecipe), reasons.ElementAt(3));
            Assert.IsInstanceOfType(typeof(DalConsumer), reasons.ElementAt(4));

            IEnumerable<DalMeal> meals = dc.meals.Select(e => e);
            DalMeal meal = meals.ElementAt(0);
            Assert.AreEqual(new DateTime(2008, 7, 8), meal.When);
            Assert.AreEqual("tr3", meal.What.Name);
            Assert.AreEqual(150, meal.Quantity);
            Assert.AreEqual("c1", meal.Why.Name);

            meal = meals.ElementAt(1);
            Assert.AreEqual(new DateTime(2008, 7, 9), meal.When);
            Assert.AreEqual("tr3", meal.What.Name);
            Assert.AreEqual(200, meal.Quantity);
            Assert.AreEqual("r1", meal.Why.Name);

            meal = meals.ElementAt(2);
            Assert.AreEqual(new DateTime(2008, 7, 10), meal.When);
            Assert.AreEqual("r1", meal.What.Name);
            Assert.AreEqual(250, meal.Quantity);
            Assert.AreEqual("c1", meal.Why.Name);

            IEnumerable<DalNote> notes = dc.notes.Select(r => r);
            Assert.AreEqual(13, notes.Count());

            DalNote n = dc.GetNoteById(DataStorage.RESERVED_NOTES + 1);
            Assert.AreEqual(1, n.ParentId);
            Assert.AreEqual(true, n.IsExpanded);
            Assert.AreEqual(dateTimeMap["note1_CreationTime"], n.CreationTime);
            Assert.AreEqual(0, n.Icon);
            Assert.AreEqual("n1", n.Title);
            Assert.IsNull(n.Text);

            n = dc.GetNoteById(DataStorage.RESERVED_NOTES + 2);
            Assert.AreEqual(DataStorage.RESERVED_NOTES + 1, n.ParentId);
            Assert.AreEqual(false, n.IsExpanded);
            Assert.AreEqual(dateTimeMap["note4_CreationTime"], n.CreationTime);
            Assert.AreEqual(2, n.Icon);
            Assert.AreEqual("n4", n.Title);
            Assert.IsNull(n.Text);

            n = dc.GetNoteById(DataStorage.RESERVED_NOTES + 3);
            Assert.AreEqual(DataStorage.RESERVED_NOTES + 2, n.ParentId);
            Assert.AreEqual(false, n.IsExpanded);
            Assert.AreEqual(dateTimeMap["note3_CreationTime"], n.CreationTime);
            Assert.AreEqual(2, n.Icon);
            Assert.AreEqual("n3", n.Title);
            Assert.AreEqual("for (int i = 0; i < 10; ++i);", n.Text);

            DalAction act = dc.GetActionById(DataStorage.RESERVED_ACTIONS + 1);
            Assert.AreEqual("act2", act.Name);
            Assert.IsTrue(act.HasWindowReminder);
            Assert.IsTrue(act.HasSoundReminder);
            Assert.IsTrue(act.HasCommandReminder);
            act = dc.GetActionById(DataStorage.RESERVED_ACTIONS + 2);
            Assert.AreEqual("act1", act.Name);            
        }

        [Test]
        public void DumpAccountTypes(){
            StringWriter writer = new StringWriter();
            Dumper dd = new Dumper(DBUtil.GetDataContext());
            dd.DumpAccountTypes(writer, null);
            Assert.AreEqual(
                "INSERT INTO account_types (name, note) VALUES (N'at1', 1);\r\n" +
                "INSERT INTO account_types (name, note) VALUES (N'at''2''', 1);\r\n",
                writer.GetStringBuilder().ToString());
        }

        [Test]
        public void DumpTransferLocations(){
            StringWriter writer = new StringWriter();
            Dumper dd = new Dumper(DBUtil.GetDataContext());
            dd.DumpTransferLocations(writer, null, null);
            Assert.AreEqual(
                "INSERT INTO transfer_locations (is_budget, is_income, name, note) VALUES (1, 1, N'bc1', 1);\r\n" +
                "INSERT INTO transfer_locations (is_budget, is_income, name, note) VALUES (1, 0, N'bc''2''', 1);\r\n" +
                "INSERT INTO transfer_locations (is_budget, account_type, name, starting_balance, note) VALUES (0, 6, N'a1', -10.00, 1);\r\n" +
                "INSERT INTO transfer_locations (is_budget, account_type, name, starting_balance, note) VALUES (0, 7, N'a''2''', 0.01, 1);\r\n",
                writer.GetStringBuilder().ToString());
        }

        [Test]
        public void DumpTransactionReasons(){
            StringWriter writer = new StringWriter();
            Dumper dd = new Dumper(DBUtil.GetDataContext());
            dd.DumpReasons(writer, null);
            Assert.AreEqual(
                "INSERT INTO transaction_reasons (type, name, note) VALUES (0, N'tr1', 1);\r\n" +
                "INSERT INTO transaction_reasons (type, name, note) VALUES (0, N'tr''2''', 1);\r\n" +
                "INSERT INTO transaction_reasons (type, name, energy, note) VALUES (1, N'tr3', 50, 1);\r\n" +
                "INSERT INTO transaction_reasons (type, name, energy, note) VALUES (2, N'r1', 0, 1);\r\n" +
                "INSERT INTO transaction_reasons (type, name, note) VALUES (3, N'c1', 1);\r\n",
                writer.GetStringBuilder().ToString());
        }

        [Test]
        public void DumpTransactions(){
            StringWriter writer = new StringWriter();
            Dumper dd = new Dumper(DBUtil.GetDataContext());
            dd.DumpTransactions(writer, null, null, null);
            Assert.AreEqual(
                "INSERT INTO transactions ([when], [from], [to], reason, ammount, quantity, note) VALUES ('2008-01-02', 11, 13, 1, 1.00, 0, 1);\r\n" +
                "INSERT INTO transactions ([when], [from], [to], reason, ammount, quantity, note) VALUES ('2008-03-04', 13, 14, 2, 2.00, 1, 1);\r\n" +
                "INSERT INTO transactions ([when], [from], [to], reason, ammount, quantity, note) VALUES ('2008-05-06', 14, 12, 3, 3.00, 200, 1);\r\n" +
                "INSERT INTO transactions ([when], [from], [to], reason, ammount, quantity, note) VALUES ('2008-07-08', 1, 2, 4, 0.00, 1400, 1);\r\n" +
                "INSERT INTO transactions ([when], [from], [to], reason, ammount, quantity, note) VALUES ('2008-07-09', 1, 2, 4, 0.00, 0, 1);\r\n",
                writer.GetStringBuilder().ToString());
        }

        [Test]
        public void DumpMeals(){
            StringWriter writer = new StringWriter();
            Dumper dd = new Dumper(DBUtil.GetDataContext());
            dd.DumpMeals(writer, null);
            Assert.AreEqual(
                "INSERT INTO meals ([when], what, quantity, why) VALUES ('2008-07-08', 3, 150, 5);\r\n" +
                "INSERT INTO meals ([when], what, quantity, why) VALUES ('2008-07-09', 3, 200, 4);\r\n" +
                "INSERT INTO meals ([when], what, quantity, why) VALUES ('2008-07-10', 4, 250, 5);\r\n",
                writer.GetStringBuilder().ToString());
        }

        [Test]
        public void DumpNotes(){
            StringWriter writer = new StringWriter();
            Dumper dd = new Dumper(DBUtil.GetDataContext());
            dd.DumpNotes(writer);
            string dump = writer.GetStringBuilder().ToString();
            Assert.AreEqual(string.Format(
                                "INSERT INTO notes (parent, permanent, expanded, created, icons, title, text) VALUES (1, 0, 1, '{0}', 0, N'n1', null);\r\n" +
                                "INSERT INTO notes (parent, permanent, expanded, created, icons, title, text) VALUES (101, 0, 0, '{1}', 2, N'n4', null);\r\n" +
                                "INSERT INTO notes (parent, permanent, expanded, created, icons, title, text) VALUES (102, 0, 0, '{2}', 2, N'n3', N'for (int i = 0; i < 10; ++i);');\r\n",
                                dateTimeMap["note1_CreationTime"].ToString(Dumper.YYYYMMDDHHMMSS),
                                dateTimeMap["note4_CreationTime"].ToString(Dumper.YYYYMMDDHHMMSS),
                                dateTimeMap["note3_CreationTime"].ToString(Dumper.YYYYMMDDHHMMSS)),
                            writer.GetStringBuilder().ToString());
        }

        // [Test]
        public void SqlServerEscapedString(){
            System.Console.WriteLine();
            string str = "abc\r\nabc";
            System.Console.WriteLine("'" + str + "'");
            System.Console.WriteLine();
            str = str.Replace("\r", "' + CHAR(13) + N'");
            str = str.Replace("\n", "' + CHAR(10) + N'");
            System.Console.WriteLine("'" + str + "'");
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
