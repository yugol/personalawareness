/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 25/09/2008
 * Time: 12:42
 * 
 */
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace awareness.db
{
    [Table(Name = "properties")]
    public class DalProperties
    {
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

        float _dbVersion = 0.0F;
        [Column(Storage = "_dbVersion",
                Name = "db_version",
                DbType="real NOT NULL",
                CanBeNull=false)]
        public float DbVersion
        {
            get { return _dbVersion; }
        }
    }
}
