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
 * Time: 12:50
 *
 */
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Awareness.db
{
    [Table(Name = "meals")]
    public class DalMeal
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

        DateTime _when = DateTime.Now;
        [Column(Storage = "_when",
                Name = "when",
                DbType = "datetime NOT NULL",
                CanBeNull = false)]
        public DateTime When
        {
            get {
                return _when;
            }
            set {
                _when = value;
            }
        }

        int _whatId = 0;
        [Column(Storage = "_whatId",
                Name = "what",
                DbType = "int NOT NULL",
                CanBeNull = false)]
        public int WhatId
        {
            get {
                return _whatId;
            }
        }

        private EntityRef<DalFood> _what;
        [Association(Storage = "_what",
                     ThisKey = "WhatId")]
        public DalFood What
        {
            get {
                return _what.Entity;
            }
            set {
                _what.Entity = value;
                _whatId = value.Id;
            }
        }

        float _quantity = 0F;
        [Column(Storage = "_quantity",
                Name = "quantity",
                DbType = "real NOT NULL",
                CanBeNull = false)]
        public float Quantity
        {
            get {
                return _quantity;
            }
            set {
                _quantity = value;
            }
        }

        int _whyId = 0;
        [Column(Storage = "_whyId",
                Name = "why",
                DbType = "int NOT NULL",
                CanBeNull = false)]
        public int WhyId
        {
            get {
                return _whyId;
            }
        }

        private EntityRef<DalReason> _why;
        [Association(Storage = "_why",
                     ThisKey = "WhyId")]
        public DalReason Why
        {
            get {
                return _why.Entity;
            }
            set {
                _why.Entity = value;
                _whyId = value.Id;
            }
        }
    }
}
