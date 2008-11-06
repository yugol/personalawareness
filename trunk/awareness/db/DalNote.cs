/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 25/09/2008
 * Time: 12:53
 * 
 */
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace awareness.db
{
    [Table(Name = "notes")]
    public class DalNote
    {
        public const string MAX_TITLE_CHAR_COUNT = "1000";
        
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

        int _parentId = AwarenessDataContext.NOTE_ROOT_ID;
        [Column(Storage = "_parentId",
                Name = "parent",
                DbType = "int NOT NULL",
                CanBeNull = false)]
        public int ParentId
        {
            get { return _parentId; }
        }

        private EntityRef<DalNote> _parent;
        [Association(Storage = "_parent",
                     ThisKey = "ParentId")]
        public DalNote Parent
        {
            get { return _parent.Entity; }
            set
            {
                _parent.Entity = value;
                _parentId = value.Id;
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
        
        bool _permanent = false;
        [Column(Storage = "_permanent",
                Name = "permanent",
                DbType = "bit DEFAULT 0 NOT NULL",
                CanBeNull = false)]
        public bool IsPermanent
        {
            get { return _permanent; }
            set { _permanent = value; }
        }

        byte _icons = 0;
        [Column(Storage = "_icons",
                Name = "icons",
                DbType = "tinyint NOT NULL",
                CanBeNull = false)]
        public byte Icon
        {
            get { return _icons; }
            set { _icons = value; }
        }
        
        DateTime _created = DbUtil.RemoveMilliseconds(DateTime.Now);
        [Column(Storage = "_created",
                Name = "created",
                DbType = "datetime NOT NULL",
                CanBeNull = false)]
        public DateTime CreationTime
        {
            get { return _created; }
        }
        
        string _title = null;
        [Column(Storage = "_title",
                Name = "title",
                DbType = "nvarchar(" + MAX_TITLE_CHAR_COUNT + ") NOT NULL", // TODO: Make it TEXT
                CanBeNull = false)]
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        
        string _text = null;
        [Column(Storage = "_text",
                Name = "text",
                DbType = "ntext NULL",
                CanBeNull = true,
                UpdateCheck = UpdateCheck.Never)]
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        
    }
}
