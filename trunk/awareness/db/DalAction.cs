/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 28/09/2008
 * Time: 12:37
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
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Awareness.DB
{
    [Table(Name = "actions")]
    public class DalAction {
        public const string MaxNameCharCount = "100";
        public const string DefaultNewActionName = "New Action";
        public const string DefaultNewGroupName = "New Group";

        public const byte TYPE_GROUP = 0;
        public const byte TYPE_TODO = 1;
        public const byte TYPE_TASK = 2;

        public DalAction(){
            _created = DBUtil.RemoveMilliseconds(DateTime.Now);
            _modified = _created;
            _start = _created.Date;
            _end = _start;
        }

        int _id = 0;
        [Column(Storage = "_id",
                Name = "id",
                DbType = "int NOT NULL IDENTITY",
                IsPrimaryKey = true,
                IsDbGenerated = true,
                CanBeNull = false)]
        public int Id
        {
            get { return _id; }
        }

        int _parentId = AwarenessDataContext.ACTION_ROOT_ID;
        [Column(Storage = "_parentId",
                Name = "parent",
                DbType = "int NOT NULL",
                CanBeNull = false)]
        public int ParentId
        {
            get { return _parentId; }
        }

        private EntityRef<DalAction> _parent;
        [Association(Storage = "_parent",
                     ThisKey = "ParentId")]
        public DalAction Parent
        {
            get { return _parent.Entity; }
            set
            {
                // SHOULD: create reparent method in dbutil class
                _parent.Entity = value;
                _parentId = value.Id;
            }
        }

        int _index = 0;
        [Column(Storage = "_index",
                Name = "index",
                DbType = "int NOT NULL",
                CanBeNull = false)]
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        byte _type = TYPE_TASK;
        [Column(Storage = "_type",
                Name = "type",
                DbType = "tinyint NOT NULL",
                CanBeNull = false)]
        public byte Type
        {
            get { return _type; }
            set
            {
                if (_type != value){
                    _type = value;
                    switch (value){
                    case TYPE_TODO:
                        _end = _start;
                        break;

                    case TYPE_TASK:
                        break;

                    case TYPE_GROUP:
                        break;

                    default:
                        throw new ArgumentException("Unknown type");
                    }
                }
            }
        }

        bool _expanded = true;
        [Column(Storage = "_expanded",
                Name = "expanded",
                DbType = "bit NOT NULL",
                CanBeNull = false)]
        public bool IsExpanded
        {
            get { return _expanded; }
            set { _expanded = value; }
        }

        DateTime _created;
        [Column(Storage = "_created",
                Name = "created",
                DbType = "datetime NOT NULL",
                CanBeNull = false)]
        public DateTime CreationTime
        {
            get { return _created; }
        }

        DateTime _modified;
        [Column(Storage = "_modified",
                Name = "modified",
                DbType = "datetime NOT NULL",
                CanBeNull = false)]
        public DateTime ModificationTime
        {
            get { return _modified; }
            set { _modified = value; }
        }

        DateTime _completed = Configuration.ZERO_DATE;
        [Column(Storage = "_completed",
                Name = "completed",
                DbType = "datetime NOT NULL",
                CanBeNull = false)]
        public DateTime CompletionTime
        {
            get { return _completed; }
            set { _completed = value; }
        }

        public bool IsCompleted
        {
            get { return _completed > _created; }
        }

        string _name = null;
        [Column(Storage = "_name",
                Name = "name",
                DbType = "nvarchar(" + MaxNameCharCount + ") NOT NULL",
                CanBeNull = false)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        int _noteId = AwarenessDataContext.NOTE_ROOT_ID;
        [Column(Storage = "_noteId",
                Name = "note",
                DbType = "int NOT NULL",
                CanBeNull = false)]
        public int NoteId
        {
            get { return _noteId; }
        }

        private EntityRef<DalNote> _note;
        [Association(Storage = "_note",
                     ThisKey = "NoteId")]
        public DalNote Note
        {
            get { return _note.Entity; }
            set
            {
                _note.Entity = value;
                _noteId = value.Id;
            }
        }

        public bool HasNote
        {
            get { return _noteId != AwarenessDataContext.NOTE_ROOT_ID; }
        }

        bool _timePlanned = false;
        [Column(Storage = "_timePlanned",
                Name = "time_planned",
                DbType = "bit NOT NULL",
                CanBeNull = false)]
        public bool IsTimePlanned
        {
            get { return _timePlanned; }
            set
            {
                _timePlanned = value;
                if (!value){
                    _start = _start.Date;
                    UpdateRecurrence();
                    _end = _end.Date;
                }
            }
        }

        DateTime _start;
        [Column(Storage = "_start",
                Name = "start",
                DbType = "datetime NOT NULL",
                CanBeNull = false)]
        public DateTime Start
        {
            get { return _start; }
            set
            {
                if (value.CompareTo(Configuration.MAX_DATE_TIME) > 0){
                    value = Configuration.MAX_DATE_TIME;
                }
                if (value.CompareTo(Configuration.MIN_DATE_TIME) < 0){
                    value = Configuration.MIN_DATE_TIME;
                }
                _start = value;
                if (_start.CompareTo(_end) > 0){
                    _end = _start;
                }
                UpdateRecurrence();
            }
        }

        DateTime _end;
        [Column(Storage = "_end",
                Name = "end",
                DbType = "datetime NOT NULL",
                CanBeNull = false)]
        public DateTime End
        {
            get { return _end; }
            set
            {
                if (value.CompareTo(Configuration.MAX_DATE_TIME) > 0){
                    value = Configuration.MAX_DATE_TIME;
                }
                if (value.CompareTo(Configuration.MIN_DATE_TIME) < 0){
                    value = Configuration.MIN_DATE_TIME;
                }
                _end = value;
                if (_start.CompareTo(_end) > 0){
                    _start = _end;
                    UpdateRecurrence();
                }
            }
        }

        bool _recurrent = false;
        [Column(Storage = "_recurrent",
                Name = "recurrent",
                DbType = "bit NOT NULL",
                CanBeNull = false)]
        public bool IsRecurrent
        {
            get { return _recurrent; }
            set { _recurrent = value; }
        }

        UInt32 _pattern = Configuration.DEFAULT_RECURRENCE_PATTERN.Pattern;
        [Column(Storage = "_pattern",
                Name = "pattern",
                DbType = "int NOT NULL",
                CanBeNull = false)]
        public UInt32 Pattern
        {
            get { return _pattern; }
        }

        public RecurrencePattern RecurrencePattern
        {
            get { return new RecurrencePattern(_pattern); }
            set
            {
                _pattern = value.Pattern;
                UpdateRecurrence();
            }
        }

        void UpdateRecurrence(){
            if (!IsRepeatIndefinitely){
                if (IsRepeatNoOfTimes){
                    RepeatTimes = RepeatTimes;
                } else {
                    RepeatUntil = RepeatUntil;
                }
            }
        }

        bool _repeatNoOfTimes = false;
        [Column(Storage = "_repeatNoOfTimes",
                Name = "repeat_no_of_times",
                DbType = "bit NOT NULL",
                CanBeNull = false)]
        public bool IsRepeatNoOfTimes
        {
            get { return _repeatNoOfTimes; }
            set { _repeatNoOfTimes = value; }
        }

        DateTime _repeatUntil = Configuration.ZERO_DATE;
        [Column(Storage = "_repeatUntil",
                Name = "repeat_until",
                DbType = "datetime NOT NULL",
                CanBeNull = false)]
        public DateTime RepeatUntil
        {
            get { return _repeatUntil; }
            set
            {
                if (value.CompareTo(Configuration.MAX_DATE_TIME) > 0){
                    value = Configuration.MAX_DATE_TIME;
                }
                if (value.CompareTo(Configuration.MIN_DATE_TIME) < 0){
                    value = Configuration.MIN_DATE_TIME;
                }
                _repeatUntil = value;

                _repeatTimes = -1;
                if (_repeatUntil.CompareTo(Start) <= 0||
                    Configuration.MAX_DATE_TIME.CompareTo(_repeatUntil) <= 0){
                    _repeatUntil = Configuration.ZERO_DATE;
                }
            }
        }

        int CalculateRepeatTimes(){
            int counter = 0;
            if (!_repeatUntil.Equals(Configuration.ZERO_DATE)){
                RecurrencePattern p = RecurrencePattern;
                DateTime temp = p.NextOccurrence(Start);
                while (temp.CompareTo(_repeatUntil) <= 0){
                    ++counter;
                    if (counter >= Configuration.MAX_REPEAT_TIMES){
                        counter = 0;
                        break;
                    }
                    temp = p.NextOccurrence(temp);
                }
            }
            return counter;
        }

        int _repeatTimes = -1;
        public int RepeatTimes
        {
            get
            {
                if (_repeatTimes < 0){
                    _repeatTimes =  CalculateRepeatTimes();
                }
                return _repeatTimes;
            }
            set
            {
                _repeatTimes = value;

                if (0 < _repeatTimes&&_repeatTimes < Configuration.MAX_REPEAT_TIMES){
                    RecurrencePattern p = RecurrencePattern;
                    _repeatUntil = _start;
                    for (int i = 0; i < _repeatTimes; ++i){
                        _repeatUntil = p.NextOccurrence(_repeatUntil);
                        if (Configuration.MAX_DATE_TIME.CompareTo(_repeatUntil) <= 0){
                            _repeatTimes = 0;
                            break;
                        }
                    }
                } else {
                    _repeatTimes = 0;
                }

                if (_repeatTimes == 0){
                    _repeatUntil = Configuration.ZERO_DATE;
                }
            }
        }

        public bool IsRepeatIndefinitely
        {
            get { return _repeatUntil.Equals(Configuration.ZERO_DATE); }
        }

        public TimeSpan Duration
        {
            get { return _end.Subtract(_start); }
        }

        bool _hasWindowReminder = false;
        [Column(Storage = "_hasWindowReminder",
                Name = "has_window_reminder",
                DbType = "bit NOT NULL",
                CanBeNull = false)]
        public bool HasWindowReminder
        {
            get { return _hasWindowReminder; }
            set { _hasWindowReminder = value; }
        }

        int _reminderDuration = 0;
        [Column(Storage = "_reminderDuration",
                Name = "reminder_duration",
                DbType = "int NOT NULL",
                CanBeNull = false)]
        public int ReminderDuration
        {
            get { return _reminderDuration; }
            set { _reminderDuration = value; }
        }

        bool _hasCommandReminder = false;
        [Column(Storage = "_hasCommandReminder",
                Name = "has_command_reminder",
                DbType = "bit NOT NULL",
                CanBeNull = false)]
        public bool HasCommandReminder
        {
            get { return _hasCommandReminder; }
            set { _hasCommandReminder = value; }
        }

        string _reminderCommand = null;
        [Column(Storage = "_reminderCommand",
                Name = "reminder_command",
                DbType = "ntext NULL",
                CanBeNull = true,
                UpdateCheck = UpdateCheck.Never)]
        public string ReminderCommand
        {
            get { return _reminderCommand; }
            set { _reminderCommand = value; }
        }

        bool _hasSoundReminder = false;
        [Column(Storage = "_hasSoundReminder",
                Name = "has_sound_reminder",
                DbType = "bit NOT NULL",
                CanBeNull = false)]
        public bool HasSoundReminder
        {
            get { return _hasSoundReminder; }
            set { _hasSoundReminder = value; }
        }

        string _reminderSound = null;
        [Column(Storage = "_reminderSound",
                Name = "reminder_sound",
                DbType = "ntext NULL",
                CanBeNull = true,
                UpdateCheck = UpdateCheck.Never)]
        public string ReminderSound
        {
            get { return _reminderSound; }
            set { _reminderSound = value; }
        }

        public bool HasReminder
        {
            get { return HasWindowReminder||HasSoundReminder||HasCommandReminder; }
        }

        public List<ActionOccurrence> GetOccurrences(TimeInterval interval){
            List<ActionOccurrence> occurrences = new List<ActionOccurrence>();

            TimeInterval when = new TimeInterval(Start, End);
            TimeInterval occurrenceInterval = interval.Intersect(when);
            if (occurrenceInterval != null){
                ActionOccurrence occurrence = new ActionOccurrence(this, occurrenceInterval);
                occurrences.Add(occurrence);
            }

            if (IsRecurrent){
                DateTime recurrenceFirst = RecurrencePattern.NextOccurrence(Start);
                
                if (recurrenceFirst.CompareTo(Configuration.MAX_DATE_TIME) <= 0){
                    TimeSpan actionDuration = Duration;

                    TimeInterval recurrenceInterval = null;

                    if (IsRepeatIndefinitely){
                        recurrenceInterval = new TimeInterval(recurrenceFirst, Configuration.MAX_DATE_TIME);
                    } else {
                        recurrenceInterval = new TimeInterval(recurrenceFirst, RepeatUntil.Add(actionDuration));
                    }

                    if (interval.Intersect(recurrenceInterval) != null){
                        do {
                            when = new TimeInterval(recurrenceFirst, recurrenceFirst.Add(actionDuration));
                            occurrenceInterval = interval.Intersect(when);
                            if (occurrenceInterval != null){
                                ActionOccurrence occurrence = new ActionOccurrence(this, occurrenceInterval);
                                occurrences.Add(occurrence);
                            }
                            recurrenceFirst = RecurrencePattern.NextOccurrence(recurrenceFirst);
                            if (!IsRepeatIndefinitely&&RepeatUntil.CompareTo(recurrenceFirst) < 0){
                                break;
                            }
                        } while (when.Second.CompareTo(interval.Second) <= 0);
                    }
                }
            }

            return occurrences;
        }
    }
}
