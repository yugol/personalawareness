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
    public class DalFood : DalReason
    {
        public const float QUANTITY_FOR_ENERGY = 100F;
        
        public DalFood()
        {
            _type = DalReason.TYPE_FOOD;   
        }
        
        protected float _energy = 0;
        [Column(Storage = "_energy",
                Name = "energy",
                DbType = "real NULL",
                CanBeNull = true)]
        public virtual float Energy
        {
            get { return _energy; }
            set { _energy = value; }
        }
        
        public float GetEnergy(float quantity)
        {
            return _energy * quantity / DalFood.QUANTITY_FOR_ENERGY;
        }
    }
}
