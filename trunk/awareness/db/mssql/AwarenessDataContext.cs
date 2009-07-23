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
 * Time: 17:34
 *
 */
using System;
using System.Linq;
using System.Data.Linq;

namespace Awareness.db.mssql
{
    public class AwarenessDataContext : DataContext {

        public AwarenessDataContext(string connectionString) : base (connectionString) {
        }

        public Table<DalProperties> properties;
        public Table<DalAccountType> accountTypes;
        public Table<DalTransferLocation> transferLocations;
        public Table<DalReason> transactionReasons;
        public Table<DalTransaction> transactions;
        public Table<DalMeal> meals;
        public Table<DalNote> notes;
        public Table<DalAction> actions;

        public new void CreateDatabase(){
            if (DatabaseExists()){
                DeleteDatabase();
            }
            base.CreateDatabase();

            CreateForeignKeys();

            ReserveNotes();
            CreateProperties();
            ReserveAccountTypes();
            ReserveTransferLocations();
            ReserveActions();
        }

        void ReserveActions(){
            int reserved = 0;
            DalAction rootAction = new DalAction() {
                Name = "Root", Type = DalAction.TYPE_GROUP
            };
            actions.InsertOnSubmit(rootAction);
            SubmitChanges();
            ++reserved;

            for (int i = reserved; i < DataStorage.RESERVED_ACTIONS; ++i){
                actions.InsertOnSubmit(new DalAction() {
                                           Name = "Reserved"
                                       });
            }
            SubmitChanges();
            actions.DeleteAllOnSubmit(actions.Where(n => n.Id > reserved));
            SubmitChanges();
        }

        void ReserveNotes(){
            int reserved = 0;

            DalNote rootNote = new DalNote() {
                Title = "Root", Icon = 1
            };
            notes.InsertOnSubmit(rootNote);
            SubmitChanges();
            ++reserved;

            DalNote applicationInternalNote = new DalNote() {
                IsPermanent = true, Title = "Application Specific", Icon = 1, IsExpanded = false
            };
            notes.InsertOnSubmit(applicationInternalNote);
            SubmitChanges();
            ++reserved;

            notes.InsertOnSubmit(new DalNote { Parent = applicationInternalNote, IsPermanent = true, Title = "Properties" });
            ++reserved;
            notes.InsertOnSubmit(new DalNote { Parent = applicationInternalNote, IsPermanent = true, Title = "Account Types" });
            ++reserved;
            notes.InsertOnSubmit(new DalNote { Parent = applicationInternalNote, IsPermanent = true, Title = "Transfer Locations" });
            ++reserved;
            notes.InsertOnSubmit(new DalNote { Parent = applicationInternalNote, IsPermanent = true, Title = "Reasons" });
            ++reserved;
            notes.InsertOnSubmit(new DalNote { Parent = applicationInternalNote, IsPermanent = true, Title = "Transactions" });
            ++reserved;
            notes.InsertOnSubmit(new DalNote { Parent = applicationInternalNote, IsPermanent = true, Title = "Meals" });
            ++reserved;
            notes.InsertOnSubmit(new DalNote { Parent = applicationInternalNote, IsPermanent = true, Title = "Actions" });
            ++reserved;
            notes.InsertOnSubmit(new DalNote { Parent = applicationInternalNote, IsPermanent = true, Title = "Todos" });
            ++reserved;

            for (int i = reserved; i < DataStorage.RESERVED_NOTES; ++i){
                notes.InsertOnSubmit(new DalNote { Parent = rootNote, Title = "Reserved" });
            }
            SubmitChanges();
            notes.DeleteAllOnSubmit(notes.Where(n => n.Id > reserved));
            SubmitChanges();
        }

        void ReserveTransferLocations(){
            int reserved = 0;
            DalAccountType rat1 = GetAccountTypeById(DataStorage.ACCOUNT_TYPE_APPLICATION_INTERNAL_ID);

            transferLocations.InsertOnSubmit(new DalAccount { Name = "Foods", AccountType = rat1, StartingBalance = 0 });
            ++reserved;
            transferLocations.InsertOnSubmit(new DalAccount { Name = "Recipes", AccountType = rat1, StartingBalance = 0 });
            ++reserved;

            for ( int i = reserved; i < DataStorage.RESERVED_TRANSFER_LOCATIONS; ++i){
                transferLocations.InsertOnSubmit(new DalBudgetCategory() {
                                                     Name = "Reserved"
                                                 } );
            }
            SubmitChanges();
            transferLocations.DeleteAllOnSubmit(transferLocations.Where(n => n.Id > reserved));
            SubmitChanges();
        }

        void ReserveAccountTypes(){
            int reserved = 0;

            accountTypes.InsertOnSubmit(new DalAccountType { Name = "Application Specific" });
            ++reserved;

            for ( int i = reserved; i < DataStorage.RESERVED_ACCOUNT_TYPES; ++i){
                accountTypes.InsertOnSubmit(new DalAccountType() {
                                                Name = "Reserved"
                                            } );
            }
            SubmitChanges();
            accountTypes.DeleteAllOnSubmit(accountTypes.Where(n => n.Id > reserved));
            SubmitChanges();
        }

        void CreateProperties(){
            DalProperties prop = new DalProperties();
            prop.Xml = new XmlProperties().XmlString;
            properties.InsertOnSubmit(prop);
            SubmitChanges();
        }

        void CreateForeignKeys(){
            ExecuteCommand("ALTER TABLE transfer_locations ADD FOREIGN KEY (account_type) REFERENCES account_types(id) ON DELETE NO ACTION");
            ExecuteCommand("ALTER TABLE transactions ADD FOREIGN KEY (reason) REFERENCES transaction_reasons(id) ON DELETE NO ACTION");
            ExecuteCommand("ALTER TABLE transactions ADD FOREIGN KEY ([from]) REFERENCES transfer_locations(id) ON DELETE NO ACTION");
            ExecuteCommand("ALTER TABLE transactions ADD FOREIGN KEY ([to]) REFERENCES transfer_locations(id) ON DELETE NO ACTION");
            ExecuteCommand("ALTER TABLE meals ADD FOREIGN KEY (what) REFERENCES transaction_reasons(id) ON DELETE NO ACTION");
            ExecuteCommand("ALTER TABLE meals ADD FOREIGN KEY (why) REFERENCES transaction_reasons(id) ON DELETE NO ACTION");
            ExecuteCommand("ALTER TABLE notes ADD FOREIGN KEY (parent) REFERENCES notes(id) ON DELETE NO ACTION");
            ExecuteCommand("ALTER TABLE actions ADD FOREIGN KEY (parent) REFERENCES actions(id) ON DELETE NO ACTION");
            ExecuteCommand("ALTER TABLE actions ADD FOREIGN KEY (note) REFERENCES notes(id) ON DELETE NO ACTION");
            ExecuteCommand("ALTER TABLE account_types ADD FOREIGN KEY (note) REFERENCES notes(id) ON DELETE NO ACTION");
            ExecuteCommand("ALTER TABLE transaction_reasons ADD FOREIGN KEY (note) REFERENCES notes(id) ON DELETE NO ACTION");
            ExecuteCommand("ALTER TABLE transactions ADD FOREIGN KEY (note) REFERENCES notes(id) ON DELETE NO ACTION");
            ExecuteCommand("ALTER TABLE transfer_locations ADD FOREIGN KEY (note) REFERENCES notes(id) ON DELETE NO ACTION");
        }

        public DalAccountType GetAccountTypeById(int id){
            return accountTypes.Where(r => r.Id == id).First();
        }

        public DalTransferLocation GetTransferLocationById(int id){
            return transferLocations.Where(r => r.Id == id).First();
        }

        public DalNote GetNoteById(int id){
            return notes.Where(r => r.Id == id).First();
        }

        public DalAction GetActionById(int id){
            return actions.Where(r => r.Id == id).First();
        }
        
        public DalReason GetReasonById(int id) {
            return transactionReasons.Where(r => r.Id == id).First();
        }

        public DalProperties GetProperties(){
            return properties.First();
        }

        public void UpdateTransactionReasonType(int id, sbyte type, string name, float energy){
            string command = null;
            switch (type){
            case DalReason.TYPE_DEFAULT:
                command = string.Format("UPDATE transaction_reasons SET type = {0}, name = {1}, energy = null WHERE id = {2}",
                                        type, Dumper.String2SqlString(name), id);
                break;
            case DalReason.TYPE_FOOD:
                command = string.Format("UPDATE transaction_reasons SET type = {0}, name = {1}, energy = {2} WHERE id = {3}",
                                        type, Dumper.String2SqlString(name), energy, id);
                break;
            case DalReason.TYPE_RECIPE:
                command = string.Format("UPDATE transaction_reasons SET type = {0}, name = {1}, energy = {2} WHERE id = {3}",
                                        type, Dumper.String2SqlString(name), DalFood.QUANTITY_FOR_ENERGY, id);
                break;
            case DalReason.TYPE_CONSUMER:
                command = string.Format("UPDATE transaction_reasons SET type = {0}, name = {1}, energy = null WHERE id = {2}",
                                        type, Dumper.String2SqlString(name), id);
                break;
            }
            ExecuteCommand(command);
        }
    }
}
