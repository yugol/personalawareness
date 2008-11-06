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
 * Time: 13:01
 *
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace awareness.db
{
    internal class DbDumper {
        internal static readonly string YYYYMMDDHHMMSS = "yyyy-MM-dd HH:mm:ss";

        AwarenessDataContext dc = null;

        internal DbDumper(AwarenessDataContext dc){
            this.dc = dc;
        }

        internal void DumpDb(TextWriter writer){
            IDictionary<int, int> accountTypes = DumpAccountTypes(writer);
            IDictionary<int, int> transferLocations = DumpTransferLocations(writer, accountTypes);
            IDictionary<int, int> transactionReasons = DumpTransactionReasons(writer);
            DumpTransactions(writer, transferLocations, transactionReasons);
            DumpMeals(writer, transactionReasons);
            IDictionary<int, int> notes = DumpNotes(writer);
            DumpActions(writer, notes);
        }

        internal IDictionary<int, int> DumpAccountTypes(TextWriter writer){
            IDictionary<int, int> accountType = new Dictionary<int, int>();
            int id = AwarenessDataContext.RESERVED_ACCOUNT_TYPES + 1;
            foreach (DalAccountType entry in dc.accountTypes.Where(r => r.Id > AwarenessDataContext.RESERVED_ACCOUNT_TYPES)){
                writer.WriteLine("INSERT INTO account_types (name) VALUES ({0});",
                                 String2SqlString(entry.Name));
                accountType[entry.Id] = id;
                ++id;
            }
            return accountType;
        }

        internal IDictionary<int, int> DumpTransferLocations(TextWriter writer, IDictionary<int, int> accountTypes){
            IDictionary<int, int> transferReasons = new Dictionary<int, int>();
            int id = AwarenessDataContext.RESERVED_TRANSFER_LOCATIONS + 1;
            foreach (DalTransferLocation entry in dc.transferLocations.Where(r => r.Id > AwarenessDataContext.RESERVED_TRANSFER_LOCATIONS)){
                if (entry is DalAccount){
                    writer.WriteLine("INSERT INTO transfer_locations (is_budget, account_type, name, starting_balance) VALUES ({0}, {1}, {2}, {3});",
                                     Bool2String(entry.IsBudget),
                                     (accountTypes != null) ? accountTypes[((DalAccount) entry).AccountTypeId] : ((DalAccount) entry).AccountTypeId,
                                     String2SqlString(entry.Name), ((DalAccount) entry).StartingBalance);
                } else if ( entry is DalBudgetCategory)  {
                    writer.WriteLine("INSERT INTO transfer_locations (is_budget, is_income, name) VALUES ({0}, {1}, {2});",
                                     Bool2String(entry.IsBudget),
                                     Bool2String(((DalBudgetCategory) entry).IsIncome),
                                     String2SqlString(entry.Name));
                }
                transferReasons[entry.Id] = id;
                ++id;
            }
            return transferReasons;
        }

        internal IDictionary<int, int> DumpTransactionReasons(TextWriter writer){
            IDictionary<int, int> transactionReasons = new Dictionary<int, int>();
            int id = 1;
            foreach (DalReason entry in dc.transactionReasons){
                if (entry is DalFood){
                    writer.WriteLine("INSERT INTO transaction_reasons (type, name, energy) VALUES ({0}, {1}, {2});",
                                     entry.Type,
                                     String2SqlString(entry.Name),
                                     ((DalFood) entry).Energy);
                } else {
                    writer.WriteLine("INSERT INTO transaction_reasons (type, name) VALUES ({0}, {1});",
                                     entry.Type,
                                     String2SqlString(entry.Name));
                }
                transactionReasons[entry.Id] = id;
                ++id;
            }
            return transactionReasons;
        }

        internal void DumpTransactions(TextWriter writer, IDictionary<int, int> transferLocations, IDictionary<int, int> transactionReasons){
            foreach (DalTransaction entry in dc.transactions){
                writer.WriteLine("INSERT INTO transactions ([when], [from], [to], reason, ammount, quantity, memo) VALUES ('{0}', {1}, {2}, {3}, {4}, {5}, {6});",
                                 entry.When.ToString("yyyy-MM-dd"),
                                 (transferLocations != null&&transferLocations.ContainsKey(entry.FromId)) ? transferLocations[entry.FromId] : entry.FromId,
                                 (transferLocations != null&&transferLocations.ContainsKey(entry.FromId)) ? transferLocations[entry.ToId] : entry.ToId,
                                 (transactionReasons != null) ? transactionReasons[entry.ReasonId] : entry.ReasonId,
                                 entry.Ammount,
                                 entry.Quantity,
                                 String2SqlString(entry.Memo));
            }
        }

        internal void DumpMeals(TextWriter writer, IDictionary<int, int> transactionReasons){
            foreach (DalMeal entry in dc.meals){
                writer.WriteLine("INSERT INTO meals ([when], what, quantity, why) VALUES ('{0}', {1}, {2}, {3});",
                                 entry.When.ToString("yyyy-MM-dd"),
                                 (transactionReasons != null) ? transactionReasons[entry.WhatId] : entry.WhatId,
                                 entry.Quantity,
                                 (transactionReasons != null) ? transactionReasons[entry.WhyId] : entry.WhyId);
            }
        }

        internal IDictionary<int, int> DumpNotes(TextWriter writer){
            IDictionary<int, int> idMap = new Dictionary<int, int>();
            int id = AwarenessDataContext.RESERVED_NOTES + 1;
            for (int parentId = 1; parentId <= AwarenessDataContext.RESERVED_NOTES; ++parentId){
                _RecursiveDumpNotes(writer, parentId, idMap, ref id);
            }
            return idMap;
        }

        void _RecursiveDumpNotes(TextWriter writer, int parentId, IDictionary<int, int> idMap, ref int id){
            foreach (DalNote note in dc.notes.Where(n => n.Id > AwarenessDataContext.RESERVED_NOTES&&n.ParentId == parentId)){
                writer.WriteLine("INSERT INTO notes (parent, permanent, expanded, created, icons, title, text) " +
                                 "VALUES ({0}, {1}, {2}, '{3}', {4}, {5}, {6});",
                                 idMap.ContainsKey(note.ParentId) ? idMap[note.ParentId] : note.ParentId,
                                 Bool2String(note.IsPermanent),
                                 Bool2String(note.IsExpanded),
                                 note.CreationTime.ToString(YYYYMMDDHHMMSS),
                                 note.Icon, String2SqlString(note.Title),
                                 String2SqlString(note.Text));
                idMap[note.Id] = id;
                ++id;
                _RecursiveDumpNotes(writer, note.Id, idMap, ref id);
            }
        }

        internal void DumpActions(TextWriter writer, IDictionary<int, int> notes){
            IDictionary<int, int> idMap = new Dictionary<int, int>();
            int id = AwarenessDataContext.RESERVED_ACTIONS + 1;
            for (int parentId = 1; parentId <= AwarenessDataContext.RESERVED_ACTIONS; ++parentId){
                _RecursiveDumpActions(writer, parentId, notes, idMap, ref id);
            }
        }

        void _RecursiveDumpActions(TextWriter writer, int parentId, IDictionary<int, int> notes, IDictionary<int, int> idMap, ref int id){
            foreach (DalAction action in dc.actions.Where(n => n.Id > AwarenessDataContext.RESERVED_ACTIONS&&n.ParentId == parentId)){
                writer.WriteLine("INSERT INTO actions (parent, [index], type, expanded, created, modified, completed, name, note, time_planned, start, [end], recurrent, pattern, repeat_no_of_times, repeat_until, has_window_reminder, reminder_duration, has_command_reminder, reminder_command, has_sound_reminder, reminder_sound) " +
                                 "VALUES ({0}, {1}, {2}, {3}, '{4}', '{5}', '{6}', {7}, {8}, {9}, '{10}', '{11}', {12}, {13}, {14}, '{15}', {16}, {17}, {18}, {19}, {20}, {21});",
                                 idMap.ContainsKey(action.ParentId) ? idMap[action.ParentId] : action.ParentId,
                                 action.Index,
                                 action.Type,
                                 Bool2String(action.IsExpanded),
                                 action.CreationTime.ToString(YYYYMMDDHHMMSS),
                                 action.ModificationTime.ToString(YYYYMMDDHHMMSS),
                                 action.CompletionTime.ToString(YYYYMMDDHHMMSS),
                                 String2SqlString(action.Name),
                                 action.NoteId,
                                 Bool2String(action.IsTimePlanned),
                                 action.Start.ToString(YYYYMMDDHHMMSS),
                                 action.End.ToString(YYYYMMDDHHMMSS),
                                 Bool2String(action.IsRecurrent),
                                 action.Pattern,
                                 Bool2String(action.IsRepeatNoOfTimes),
                                 action.RepeatUntil.ToString(YYYYMMDDHHMMSS),
                                 Bool2String(action.HasWindowReminder),
                                 action.ReminderDuration,
                                 Bool2String(action.HasCommandReminder),
                                 String2SqlString(action.ReminderCommand),
                                 Bool2String(action.HasSoundReminder),
                                 String2SqlString(action.ReminderSound));
                idMap[action.Id] = id;
                ++id;
                _RecursiveDumpActions(writer, action.Id, notes, idMap, ref id);
            }
        }

        internal void RestoreDb(TextReader reader){
            string command;
            while ((command = reader.ReadLine()) != null){
                dc.ExecuteCommand(command);
            }
        }

        internal static string Bool2String(bool b){
            return b ? "1" : "0";
        }

        internal static string String2SqlString(string memo){
            if (string.IsNullOrEmpty(memo)){
                return "null";
            } else {
                string escaped = memo.Replace("'", "''");
                escaped = escaped.Replace("\r", "' + NCHAR(13) + N'");
                escaped = escaped.Replace("\n", "' + NCHAR(10) + N'");
                return string.Format("N'{0}'", escaped);
            }
        }
    }
}
