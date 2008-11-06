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
 * Time: 12:49
 *
 */
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace awareness.db
{
    [Table(Name = "transactions")]
    public class DalTransaction {
        int _id = 0;
        [Column(Storage = "_id",
                Name = "id",
                DbType="int NOT NULL IDENTITY",
                IsPrimaryKey=true,
                IsDbGenerated=true,
                CanBeNull=false)]
        public int Id
        {
            get { return _id; }
        }

        DateTime _when = DateTime.Now;
        [Column(Storage = "_when",
                Name = "when",
                DbType="datetime NOT NULL",
                CanBeNull=false)]
        public DateTime When
        {
            get { return _when; }
            set { _when = value; }
        }

        int _fromId = 0;
        [Column(Storage = "_fromId",
                Name = "from",
                DbType="int NOT NULL",
                CanBeNull=false)]
        public int FromId
        {
            get { return _fromId; }
        }

        private EntityRef<DalTransferLocation> _from;
        [Association(Storage = "_from",
                     ThisKey = "FromId")]
        public DalTransferLocation From
        {
            get { return _from.Entity; }
            set
            {
                _from.Entity = value;
                _fromId = value.Id;
            }
        }

        int _toId = 0;
        [Column(Storage = "_toId",
                Name = "to",
                DbType = "int NOT NULL",
                CanBeNull = false)]
        public int ToId
        {
            get { return _toId; }
        }

        private EntityRef<DalTransferLocation> _to;
        [Association(Storage = "_to",
                     ThisKey = "ToId")]
        public DalTransferLocation To
        {
            get { return _to.Entity; }
            set
            {
                _to.Entity = value;
                _toId = value.Id;
            }
        }

        decimal _ammount = 0;
        [Column(Storage = "_ammount",
                Name = "ammount",
                DbType = "numeric(18, 2) NOT NULL",
                CanBeNull = false)]
        public decimal Ammount
        {
            get { return _ammount; }
            set { _ammount = value; }
        }

        int _reasonId = 0;
        [Column(Storage = "_reasonId",
                Name = "reason",
                DbType = "int NOT NULL",
                CanBeNull = false)]
        public int ReasonId
        {
            get { return _reasonId; }
        }

        private EntityRef<DalReason> _reason;
        [Association(Storage = "_reason",
                     ThisKey = "ReasonId")]
        public DalReason Reason
        {
            get { return _reason.Entity; }
            set
            {
                _reason.Entity = value;
                _reasonId = value.Id;
            }
        }

        string _memo = null;
        [Column(Storage = "_memo",
                Name = "memo",
                DbType = "ntext",
                CanBeNull = true,
                UpdateCheck = UpdateCheck.Never)]
        public string Memo
        {
            get { return _memo; }
            set { _memo = value; }
        }

        float _quantity = 0F;
        [Column(Storage = "_quantity",
                Name = "quantity",
                DbType = "real NOT NULL",
                CanBeNull = false)]
        public float Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
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

        public override string ToString(){
            return string.Format("{0} {1} {2}", Reason.ToString(), From.ToString(), To.ToString());
        }
    }
}
