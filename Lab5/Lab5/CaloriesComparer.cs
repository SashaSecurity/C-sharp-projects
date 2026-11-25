using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    public class CaloriesComparer:IComparer<Ingredient>
    {
        public int Compare(Ingredient a, Ingredient b)
        {
            if (a == null || b == null) return 0;
            return a.calories_per100gramm.CompareTo(b.calories_per100gramm);
        }
    }
}
