/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 25/09/2008
 * Time: 12:45
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
using System.Data.Linq;
using System.Data.Linq.Mapping;

using Awareness.db.mssql;

namespace Awareness.db
{
    [Table(Name = "transaction_reasons")]
    [InheritanceMapping(Code = DalReason.TYPE_DEFAULT, Type = typeof(DalReason), IsDefault = true)]
    [InheritanceMapping(Code = DalReason.TYPE_FOOD, Type = typeof(DalFood))]
    [InheritanceMapping(Code = DalReason.TYPE_RECIPE, Type = typeof(DalRecipe))]
    [InheritanceMapping(Code = DalReason.TYPE_CONSUMER, Type = typeof(DalConsumer))]
    public class DalReason : Notable {
        public const sbyte TYPE_DEFAULT = 0;
        public const sbyte TYPE_FOOD = 1;
        public const sbyte TYPE_RECIPE = 2;
        public const sbyte TYPE_CONSUMER = 3;

        public const string MAX_NAME_CHAR_COUNT = "100";

        internal static DalReason CreateReason(sbyte type){
            DalReason reason = null;

            switch (type){
            case DalReason.TYPE_FOOD:
                reason = new DalFood();
                break;
            case DalReason.TYPE_CONSUMER:
                reason = new DalConsumer();
                break;
            case DalReason.TYPE_RECIPE:
                reason = new DalRecipe();
                break;
            default:
                reason = new DalReason();
                break;
            }

            return reason;
        }

        public DalReason(){
            _type = DalReason.TYPE_DEFAULT;
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

        protected sbyte _type;
        [Column(Storage = "_type",
                Name = "type",
                DbType = "tinyint NOT NULL",
                CanBeNull = false,
                IsDiscriminator = true)]
        public sbyte Type
        {
            get { return _type; }
        }

        string _name = null;
        [Column(Storage = "_name",
                Name = "name",
                DbType = "nvarchar(" + MAX_NAME_CHAR_COUNT + ") NOT NULL",
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

        public override string ToString(){
            return Name;
        }

        float _quantity = 0F;
        [Column(Storage = "_quantity",
                Name = "quantity",
                DbType = "real default 0",
                CanBeNull = false)]
        public float Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        #region CASHING_FIELDS
        // do not save these fields
        
        decimal _ammount = 0;
        [Column(Storage = "_ammount",
                Name = "ammount",
                DbType = "numeric(18, 2) default 0",
                CanBeNull = false)]
        public decimal Ammount
        {
            get { return _ammount; }
            set { _ammount = value; }
        }

        int _fromId = 0;
        [Column(Storage = "_fromId",
                Name = "from",
                DbType = "int default 0",
                CanBeNull = false)]
        public int FromId
        {
            get { return _fromId; }
            set { _fromId = value; }
        }

        int _toId = 0;
        [Column(Storage = "_toId",
                Name = "to",
                DbType = "int default 0",
                CanBeNull = true)]
        public int ToId
        {
            get { return _toId; }
            set { _toId = value; }
        }
                
        string _availableQuantity = null;
        [Column(Storage = "_availableQuantity",
                Name = "available_quantity",
                DbType = "nvarchar(20)",
                CanBeNull = true)]
        private string _AvailableQuantityRep
        {
        	get { return _availableQuantity; }
        	set { _availableQuantity = value; }
        }
        
        #endregion
        
        public float AvailableQuantity
        {
        	get {
        		try {
        			return float.Parse(_availableQuantity);
        		} catch (Exception) {
        			throw new CashEmptyException();
        		}
        	}
        	set { _availableQuantity = value.ToString(); }
        }
        
        public void AvailableQuantitySetNull() {
        	_availableQuantity = null;
        }


    }
}
