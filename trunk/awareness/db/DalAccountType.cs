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
 * Date: 25/09/2008
 * Time: 12:43
 * 
 */
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using Awareness.db.mssql;

namespace Awareness.db
{
    [Table(Name = "account_types")]
    public class DalAccountType : Notable
    {
        public const string MaxNameCharCount = "50";
        
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
        
        int _noteId = DataStorage.NOTE_ROOT_ID;
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
            get { return _noteId != DataStorage.NOTE_ROOT_ID; }
        }
        
        public override string ToString()
        {
            return Name;
        }
    }
}
