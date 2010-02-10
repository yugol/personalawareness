/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 08/09/2008
 * Time: 13:01
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
using System.Collections.Generic;
using System.IO;

using Awareness.DB.Mssql;

namespace Awareness.DB.Mssql
{
	public class Dumper : Awareness.DB.Dumper
    {

		public Dumper(Awareness.DB.DataStorage storage) : base(storage)
        {
        }

        public override void DumpAll(TextWriter writer)
        {
            DumpProperties(writer);
            IDictionary<int, int> notes = DumpNotes(writer);
            IDictionary<int, int> accountTypes = DumpAccountTypes(writer, notes);
            IDictionary<int, int> transferLocations = DumpTransferLocations(writer, accountTypes, notes);
            IDictionary<int, int> reasons = DumpReasons(writer, notes);
            DumpTransactions(writer, transferLocations, reasons, notes);
            DumpMeals(writer, reasons);
            DumpActions(writer, notes);
        }

        internal void DumpProperties(TextWriter writer)
        {
            DalProperties dbProp = storage.GetProperties();
            writer.WriteLine("UPDATE properties SET db_version = {0}, xml = {1};",
                             dbProp.DBVersion,
                             DataUtil.String2SqlString(dbProp.Xml));
        }

        internal IDictionary<int, int> DumpAccountTypes(TextWriter writer, IDictionary<int, int> notes)
        {
            IDictionary<int, int> accountType = new Dictionary<int, int>();
            int id = DataStorage.RESERVED_ACCOUNT_TYPES + 1;
            foreach (DalAccountType entry in storage.GetDumperAccountTypes()) {
                writer.WriteLine("INSERT INTO account_types (name, note) " +
                                 "VALUES ({0}, {1});",
                                 DataUtil.String2SqlString(entry.Name),
                                 (notes != null&&notes.ContainsKey(entry.NoteId)) ? (notes[entry.NoteId]) : (entry.NoteId));
                accountType[entry.Id] = id;
                ++id;
            }
            return accountType;
        }

        internal IDictionary<int, int> DumpTransferLocations(TextWriter writer, IDictionary<int, int> accountTypes, IDictionary<int, int> notes)
        {
            IDictionary<int, int> transferReasons = new Dictionary<int, int>();
            int id = DataStorage.RESERVED_TRANSFER_LOCATIONS + 1;
            foreach (DalTransferLocation entry in storage.GetDumperTransferLocations()) {
                if (entry is DalAccount) {
                    writer.WriteLine("INSERT INTO transfer_locations (is_budget, account_type, name, starting_balance, note) " +
                                     "VALUES ({0}, {1}, {2}, {3}, {4});",
                                     DataUtil.Bool2String(entry.IsBudget),
                                     (accountTypes != null) ? accountTypes[((DalAccount) entry).AccountTypeId] : ((DalAccount) entry).AccountTypeId,
                                     DataUtil.String2SqlString(entry.Name),
                                     ((DalAccount) entry).StartingBalance,
                                     (notes != null&&notes.ContainsKey(entry.NoteId)) ? (notes[entry.NoteId]) : (entry.NoteId));
                } else if ( entry is DalBudgetCategory) {
                    writer.WriteLine("INSERT INTO transfer_locations (is_budget, is_income, name, note) " +
                                     "VALUES ({0}, {1}, {2}, {3});",
                                     DataUtil.Bool2String(entry.IsBudget),
                                     DataUtil.Bool2String(((DalBudgetCategory) entry).IsIncome),
                                     DataUtil.String2SqlString(entry.Name),
                                     (notes != null&&notes.ContainsKey(entry.NoteId)) ? (notes[entry.NoteId]) : (entry.NoteId));
                }
                transferReasons[entry.Id] = id;
                ++id;
            }
            return transferReasons;
        }

        internal IDictionary<int, int> DumpReasons(TextWriter writer, IDictionary<int, int> notes)
        {
            IDictionary<int, int> transactionReasons = new Dictionary<int, int>();
            int id = 1;
            foreach (DalReason entry in storage.GetDumperTransactionReasons()) {
                if (entry is DalFood) {
                    writer.WriteLine("INSERT INTO transaction_reasons (type, name, energy, note) " +
                                     "VALUES ({0}, {1}, {2}, {3});",
                                     entry.Type,
                                     DataUtil.String2SqlString(entry.Name),
                                     ((DalFood) entry).Energy,
                                     (notes != null&&notes.ContainsKey(entry.NoteId)) ? (notes[entry.NoteId]) : (entry.NoteId));
                } else {
                    writer.WriteLine("INSERT INTO transaction_reasons (type, name, note) " +
                                     "VALUES ({0}, {1}, {2});",
                                     entry.Type,
                                     DataUtil.String2SqlString(entry.Name),
                                     (notes != null&&notes.ContainsKey(entry.NoteId)) ? (notes[entry.NoteId]) : (entry.NoteId));
                }
                transactionReasons[entry.Id] = id;
                ++id;
            }
            return transactionReasons;
        }

        internal void DumpTransactions(TextWriter writer, IDictionary<int, int> transferLocations, IDictionary<int, int> transactionReasons, IDictionary<int, int> notes)
        {
            foreach (DalTransaction entry in storage.GetDumperTransactions()) {
                writer.WriteLine("INSERT INTO transactions ([when], [from], [to], reason, ammount, quantity, note) " +
                                 "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6});",
                                 DataUtil.Date2String(entry.When),
                                 (transferLocations != null&&transferLocations.ContainsKey(entry.FromId)) ? transferLocations[entry.FromId] : entry.FromId,
                                 (transferLocations != null&&transferLocations.ContainsKey(entry.FromId)) ? transferLocations[entry.ToId] : entry.ToId,
                                 (transactionReasons != null) ? transactionReasons[entry.ReasonId] : entry.ReasonId,
                                 entry.Ammount,
                                 entry.Quantity,
                                 (notes != null&&notes.ContainsKey(entry.NoteId)) ? (notes[entry.NoteId]) : (entry.NoteId));
            }
        }

        internal void DumpMeals(TextWriter writer, IDictionary<int, int> transactionReasons)
        {
            foreach (DalMeal entry in storage.GetDumperMeals()) {
                writer.WriteLine("INSERT INTO meals ([when], what, quantity, why) " +
                                 "VALUES ({0}, {1}, {2}, {3});",
                                 DataUtil.Date2String(entry.When),
                                 (transactionReasons != null) ? transactionReasons[entry.WhatId] : entry.WhatId,
                                 entry.Quantity,
                                 (transactionReasons != null) ? transactionReasons[entry.WhyId] : entry.WhyId);
            }
        }

        internal IDictionary<int, int> DumpNotes(TextWriter writer)
        {
            IDictionary<int, int> idMap = new Dictionary<int, int>();
            int id = DataStorage.RESERVED_NOTES + 1;
            for (int parentId = 1; parentId <= DataStorage.RESERVED_NOTES; ++parentId) {
                _RecursiveDumpNotes(writer, parentId, idMap, ref id);
            }
            return idMap;
        }

        void _RecursiveDumpNotes(TextWriter writer, int parentId, IDictionary<int, int> idMap, ref int id)
        {
            foreach (DalNote note in storage.GetDumperNotes(parentId)) {
                writer.WriteLine("INSERT INTO notes (parent, permanent, expanded, created, icons, title, text) " +
                                 "VALUES ({0}, {1}, {2}, '{3}', {4}, {5}, {6});",
                                 idMap.ContainsKey(note.ParentId) ? idMap[note.ParentId] : note.ParentId,
                                 DataUtil.Bool2String(note.IsPermanent),
                                 DataUtil.Bool2String(note.IsExpanded),
                                 note.CreationTime.ToString(DataUtil.YYYYMMDDHHMMSS),
                                 note.Icon, DataUtil.String2SqlString(note.Title),
                                 DataUtil.String2SqlString(note.Text));
                idMap[note.Id] = id;
                ++id;
                _RecursiveDumpNotes(writer, note.Id, idMap, ref id);
            }
        }

        internal void DumpActions(TextWriter writer, IDictionary<int, int> notes)
        {
            IDictionary<int, int> idMap = new Dictionary<int, int>();
            int id = DataStorage.RESERVED_ACTIONS + 1;
            for (int parentId = 1; parentId <= DataStorage.RESERVED_ACTIONS; ++parentId) {
                _RecursiveDumpActions(writer, parentId, notes, idMap, ref id);
            }
        }

        void _RecursiveDumpActions(TextWriter writer, int parentId, IDictionary<int, int> notes, IDictionary<int, int> idMap, ref int id)
        {
            foreach (DalAction entry in storage.GetDumperActions(parentId)) {
                writer.WriteLine("INSERT INTO actions (parent, checked, type, expanded, name, note, time_planned, start, [end], recurrent, pattern, repeat_no_of_times, repeat_until, has_window_reminder, reminder_duration, has_command_reminder, reminder_command, has_sound_reminder, reminder_sound) " +
                                 "VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18});",
                                 idMap.ContainsKey(entry.ParentId) ? idMap[entry.ParentId] : entry.ParentId,
                                 DataUtil.Bool2String(entry.IsChecked),
                                 entry.Type,
                                 DataUtil.Bool2String(entry.IsExpanded),
                                 DataUtil.String2SqlString(entry.Name),
                                 (notes != null&&notes.ContainsKey(entry.NoteId)) ? (notes[entry.NoteId]) : (entry.NoteId),
                                 DataUtil.Bool2String(entry.IsTimePlanned),
                                 DataUtil.DateTime2String(entry.Start),
                                 DataUtil.DateTime2String(entry.End),
                                 DataUtil.Bool2String(entry.IsRecurrent),
                                 entry.Pattern,
                                 DataUtil.Bool2String(entry.IsRepeatNoOfTimes),
                                 DataUtil.DateTime2String(entry.RepeatUntil),
                                 DataUtil.Bool2String(entry.HasWindowReminder),
                                 entry.ReminderDuration,
                                 DataUtil.Bool2String(entry.HasCommandReminder),
                                 DataUtil.String2SqlString(entry.ReminderCommand),
                                 DataUtil.Bool2String(entry.HasSoundReminder),
                                 DataUtil.String2SqlString(entry.ReminderSound));
                idMap[entry.Id] = id;
                ++id;
                _RecursiveDumpActions(writer, entry.Id, notes, idMap, ref id);
            }
        }

    }
}
