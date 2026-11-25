using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    public class WeightComparator:IComparer<Ingredient>
    {
        public int Compare(Ingredient a, Ingredient b)
        {
            if (a == null || b == null) return 0;
            return a.Getweight().CompareTo(b.Getweight());

        }

    }
}
