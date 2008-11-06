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
