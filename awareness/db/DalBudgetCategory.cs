/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 25/09/2008
 * Time: 12:44
 * 
 */
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace awareness.db
{
    public class DalBudgetCategory : DalTransferLocation
    {
        public DalBudgetCategory()
        {
            _isBudget = true;
        }
        
        bool _isIncome = false;
        [Column(Storage = "_isIncome",
                Name = "is_income",
                DbType = "bit",
                CanBeNull = true)]
        public bool IsIncome
        {
            get { return _isIncome; }
            set { _isIncome = value; }
        }
    }
}
