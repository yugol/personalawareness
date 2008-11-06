/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 21/09/2008
 * Time: 15:00
 * 
 */
using System;
using System.Collections.Generic;

using awareness.db;

namespace awareness.ui
{
    public struct NamingReasonTypes : IEquatable<NamingReasonTypes>
    {
        sbyte type;
        string name;
        
        public sbyte Type
        {
            get { return type; }
        }
        
        public string Name
        {
            get { return name; }
        }
        
        public NamingReasonTypes(sbyte type, string name)
        {
            this.type = type;
            this.name = name;
        }
        
        #region Equals and GetHashCode implementation
        // The code in this region is useful if you want to use this structure in collections.
        // If you don't need it, you can just remove the region and the ": IEquatable<NameReasonType>" declaration.
        
        public override bool Equals(object obj)
        {
            if (obj is NamingReasonTypes)
                return Equals((NamingReasonTypes)obj); // use Equals method below
            else
                return false;
        }
        
        public bool Equals(NamingReasonTypes other)
        {
            // add comparisions for all members here
            return this.type == other.type;
        }
        
        public override int GetHashCode()
        {
            // combine the hash codes of all members here (e.g. with XOR operator ^)
            return type.GetHashCode();
        }
        
        public static bool operator ==(NamingReasonTypes lhs, NamingReasonTypes rhs)
        {
            return lhs.Equals(rhs);
        }
        
        public static bool operator !=(NamingReasonTypes lhs, NamingReasonTypes rhs)
        {
            return !(lhs.Equals(rhs)); // use operator == and negate result
        }
        #endregion

        public override string ToString()
        {
            return Name;
        }
        
        static List<NamingReasonTypes> reasonTypeNames = null;
        
        public static List<NamingReasonTypes> GetNames()
        {
            if (reasonTypeNames == null)
            {
                reasonTypeNames = new List<NamingReasonTypes>();
                reasonTypeNames.Add(new NamingReasonTypes(DalReason.TYPE_DEFAULT, "Regular"));
                reasonTypeNames.Add(new NamingReasonTypes(DalReason.TYPE_CONSUMER, "Consumer"));
                reasonTypeNames.Add(new NamingReasonTypes(DalReason.TYPE_FOOD, "Food"));
                reasonTypeNames.Add(new NamingReasonTypes(DalReason.TYPE_RECIPE, "Recipe"));
            }
            return reasonTypeNames;
        }
    
    }
}
