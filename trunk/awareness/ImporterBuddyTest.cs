/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 06/09/2008
 * Time: 15:11
 *
 */
#if TEST

using System;
using System.Collections.Generic;
using System.Linq;

using awareness.db;
using NUnit.Framework;

namespace awareness
{
    [TestFixture]
    public class ImporterBuddyTest {
        static string buddyFile = @"..\..\..\testdata\buddy_export.csv";

        ImporterBuddy importer = new ImporterBuddy(null);

        [Test]
        public void Import(){
            importer.Import(buddyFile);
            AwarenessDataContext dc = DbUtil.GetDataContext();
            IEnumerable<DalTransaction> transactions =
                from t in dc.transactions
                orderby t.Reason.Name
                select t;
            Assert.AreEqual(5, transactions.Count());
        }

        [Test]
        public void EnsureImportAccountType(){
            int id = importer.BuddyAccountType.Id;
            Assert.Greater(id, 0);
            importer.EnsureImportAccountType();
            Assert.AreEqual(id, importer.BuddyAccountType.Id);
        }

        [Test]
        public void EnsureReason(){
            DalReason reason = new DalReason() {
                Name = "Reason"
            };
            reason = importer.EnsureReason(reason);
            int id = reason.Id;
            Assert.Greater(id, 0);
            reason = importer.EnsureReason(reason);
            Assert.AreEqual(id, reason.Id);
        }

        [Test]
        public void EnsureBudgetCategory(){
            DalBudgetCategory category = new DalBudgetCategory() {
                IsIncome = true, Name = "Budget Category"
            };
            category = importer.EnsureBudgetCategory(category);
            int id = category.Id;
            Assert.Greater(id, 0);
            category = importer.EnsureBudgetCategory(category);
            Assert.AreEqual(id, category.Id);
        }

        [Test]
        public void EnsureAccount(){
            DalAccount account = new DalAccount() {
                Name = "Account", AccountType = importer.BuddyAccountType
            };
            account = importer.EnsureAccount(account);
            int id = account.Id;
            Assert.Greater(id, 0);
            account = importer.EnsureAccount(account);
            Assert.AreEqual(id, account.Id);
        }

        [Test]
        public void CreateTransaction_Account2Account(){
            string[] record = new string[] {"Fri Nov 17 00:00:00 EET 2006", "Depozit", "", "2007-11-19 179.4744", "2,500.00 RON", "Account:Unicredit", "Account:ATE"};
            DalTransaction transaction = importer.CreateTransaction(record);

            Assert.AreEqual(new DateTime(2006, 11, 17), transaction.When);
            Assert.AreEqual("Depozit", transaction.Reason.Name);
            Assert.AreEqual(2500m, transaction.Ammount);
            Assert.IsTrue(transaction.From is DalAccount);
            Assert.AreEqual("Unicredit", transaction.From.Name);
            Assert.IsTrue(transaction.To is DalAccount);
            Assert.AreEqual("ATE", transaction.To.Name);
            Assert.AreEqual("2007-11-19 179.4744", transaction.Memo);
        }

        [Test]
        public void CreateTransaction_Account2Category(){
            string[] record = new string[] {"Wed Jan 24 00:00:00 EET 2007", "Paine", "", "", "1.60 RON", "Account:Unicredit", "Category:Food"};
            DalTransaction transaction = importer.CreateTransaction(record);

            Assert.AreEqual(new DateTime(2007, 1, 24), transaction.When);
            Assert.AreEqual("Paine", transaction.Reason.Name);
            Assert.AreEqual(1.60m, transaction.Ammount);
            Assert.IsTrue(transaction.From is DalAccount);
            Assert.AreEqual("Unicredit", transaction.From.Name);
            Assert.IsTrue(transaction.To is DalBudgetCategory);
            Assert.AreEqual("Food", transaction.To.Name);
            Assert.IsNull(transaction.Memo);
        }

        [Test]
        public void CreateTransaction_Category2Account(){
            string[] record = new string[] {"Tue Sep 02 00:00:00 EEST 2008", "Lichidare", "", "", "1,000.00 RON", "Category:Salary", "Account:Cash"};
            DalTransaction transaction = importer.CreateTransaction(record);

            Assert.AreEqual(new DateTime(2008, 9, 2), transaction.When);
            Assert.AreEqual("Lichidare", transaction.Reason.Name);
            Assert.AreEqual(1000m, transaction.Ammount);
            Assert.IsTrue(transaction.From is DalBudgetCategory);
            Assert.AreEqual("Salary", transaction.From.Name);
            Assert.IsTrue(transaction.To is DalAccount);
            Assert.AreEqual("Cash", transaction.To.Name);
            Assert.IsNull(transaction.Memo);
        }

        [Test]
        public void CreateTransferLocation_FromAccount(){
            DalAccount account = (DalAccount) importer.CreateTransferLocation("Account:Unicredit", true);
            Assert.AreEqual("Unicredit", account.Name);
            Assert.AreEqual(0m, account.StartingBalance);
            Assert.AreEqual("BUDDY ACCOUNT", account.AccountType.Name);
        }

        [Test]
        public void CreateTransferLocation_ToAccount(){
            DalAccount account = (DalAccount) importer.CreateTransferLocation("Account:ATE", false);
            Assert.AreEqual("ATE", account.Name);
            Assert.AreEqual(0m, account.StartingBalance);
            Assert.AreEqual("BUDDY ACCOUNT", account.AccountType.Name);
        }

        [Test]
        public void CreateTransferLocation_FromBudgetCategory(){
            DalBudgetCategory account = (DalBudgetCategory) importer.CreateTransferLocation("Category:Salary", true);
            Assert.AreEqual("Salary", account.Name);
            Assert.AreEqual(true, account.IsIncome);
        }

        [Test]
        public void CreateTransferLocation_ToBudgetCategory(){
            DalBudgetCategory account = (DalBudgetCategory) importer.CreateTransferLocation("Category:Food", false);
            Assert.AreEqual("Food", account.Name);
            Assert.AreEqual(false, account.IsIncome);
        }

        [Test]
        public void ParseDecimal(){
            decimal n = (decimal) double.Parse("2,500.00");
            Assert.AreEqual(2500m, n);
        }

        [TestFixtureSetUp]
        public void Init(){
            DbUtil.CreateDataContext(DbTest.TEST_DB_NAME);
            DbUtil.OpenDataContext(DbTest.TEST_DB_NAME);
            importer = new ImporterBuddy(DbUtil.GetDataContext());
            importer.EnsureImportAccountType();
        }

        [TestFixtureTearDown]
        public void Dispose(){
            DbUtil.DeleteDataContext();
        }
    }
}
#endif
