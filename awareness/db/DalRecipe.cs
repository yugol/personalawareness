/*
 * Created by SharpDevelop.
 * User: Iulian
 * Date: 25/09/2008
 * Time: 12:46
 * 
 */
using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace awareness.db
{
    public class DalRecipe : DalFood
    {
        public DalRecipe()
        {
            _type = DalReason.TYPE_RECIPE;
        }
    }
}
