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

namespace awareness.db
{
    [Table(Name = "account_types")]
    public class DalAccountType
    {
        public const string MAX_NAME_CHAR_COUNT = "50";
        
        int _id = 0;
        [Column(Storage = "_id",
                Name = "id",
                DbType = "int NOT NULL IDENTITY",
                IsPrimaryKey = true,
                IsDbGenerated = true,
                CanBeNull=false)]
        public int Id
        {
            get { return _id; }
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
