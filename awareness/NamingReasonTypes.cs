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

        public NamingReasonTypes(sbyte type, string name){
            this.type = type;
            this.name = name;
        }

        #region Equals and GetHashCode implementation
        // The code in this region is useful if you want to use this structure in collections.
        // If you don't need it, you can just remove the region and the ": IEquatable<NameReasonType>" declaration.

        public override bool Equals(object obj){
            if (obj is NamingReasonTypes){
                return Equals((NamingReasonTypes) obj); // use Equals method below
            } else {
                return false;
            }
        }

        public bool Equals(NamingReasonTypes other){
            // add comparisions for all members here
            return this.type == other.type;
        }

        public override int GetHashCode(){
            // combine the hash codes of all members here (e.g. with XOR operator ^)
            return type.GetHashCode();
        }

        public static bool operator == (NamingReasonTypes lhs, NamingReasonTypes rhs){
            return lhs.Equals(rhs);
        }

        public static bool operator != (NamingReasonTypes lhs, NamingReasonTypes rhs){
            return !(lhs.Equals(rhs)); // use operator == and negate result
        }

        #endregion

        public override string ToString(){
            return Name;
        }

        static List<NamingReasonTypes> reasonTypeNames = null;

        public static List<NamingReasonTypes> GetNames(){
            if (reasonTypeNames == null){
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
