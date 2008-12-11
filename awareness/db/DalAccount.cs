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
 * Time: 12:45
 * 
 */
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Awareness.DB
{
    public class DalAccount : DalTransferLocation
    {
        public DalAccount()
        {
            _isBudget = false;
        }
        
        int _accountTypeId = 0;
        [Column(Storage = "_accountTypeId",
                Name = "account_type",
                DbType = "int",
                CanBeNull = true)]
        public int AccountTypeId
        {
            get { return _accountTypeId; }
        }

        private EntityRef<DalAccountType> _accountType;
        [Association(Storage = "_accountType",
                     ThisKey = "AccountTypeId")]
        public DalAccountType AccountType
        {
            get { return _accountType.Entity; }
            set
            {
                _accountType.Entity = value;
                _accountTypeId = value.Id;
            }
        }
        
        decimal _startingBalance = 0;
        [Column(Storage = "_startingBalance",
                Name = "starting_balance",
                DbType = "numeric(18, 2)",
                CanBeNull = true)]        
        public decimal StartingBalance
        {
            get { return _startingBalance; }
            set { _startingBalance = value; }
        }   
        
        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, AccountType.Name);
        }
    }
}
