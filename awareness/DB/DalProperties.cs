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
 * Time: 12:42
 *
 */
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Awareness.DB
{
    [Table(Name = "properties")]
    public class DalProperties
    {
        int _id = 0;
        [Column(Storage = "_id",
                Name = "id",
                DbType = "int NOT NULL IDENTITY",
                IsPrimaryKey = true,
                IsDbGenerated = true,
                CanBeNull = false)]
        public int Id
        {
            get {
                return _id;
            }
        }

        float _dbVersion = Configuration.DBVersion;
        [Column(Storage = "_dbVersion",
                Name = "db_version",
                DbType = "real NOT NULL",
                CanBeNull = false)]
        public float DBVersion
        {
            get {
                return _dbVersion;
            }
        }

        string _xml = null;
        [Column(Storage = "_xml",
                Name = "xml",
                DbType = "ntext NULL",
                CanBeNull = true,
                UpdateCheck = UpdateCheck.Never)]
        public string Xml
        {
            get {
                return _xml;
            }
            set {
                _xml = value;
            }
        }

    }
}
