/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 25/09/2008
 * Time: 12:45
 * 
 */
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace awareness.db
{
    [Table(Name = "transaction_reasons")]
    [InheritanceMapping(Code = DalReason.TYPE_DEFAULT, Type = typeof(DalReason), IsDefault = true)]
    [InheritanceMapping(Code = DalReason.TYPE_FOOD, Type = typeof(DalFood))]
    [InheritanceMapping(Code = DalReason.TYPE_RECIPE, Type = typeof(DalRecipe))]
    [InheritanceMapping(Code = DalReason.TYPE_CONSUMER, Type = typeof(DalConsumer))]
    public class DalReason
    {
        public const sbyte TYPE_DEFAULT = 0;
        public const sbyte TYPE_FOOD = 1;
        public const sbyte TYPE_RECIPE = 2;
        public const sbyte TYPE_CONSUMER = 3;

        public const string MAX_NAME_CHAR_COUNT = "100";

        internal static DalReason CreateReason(sbyte type)
        {
            DalReason reason = null;
            
            switch (type)
            {
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
        
        public DalReason()
        {
            _type = DalReason.TYPE_DEFAULT;
        }        
        
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
        
        public override string ToString()
        {
            return Name;
        }
    }
}
