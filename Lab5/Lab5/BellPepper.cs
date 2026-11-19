using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    public class BellPepper : Vegetables
    {
        public BellPepper(Category category, string name, double calories_per100gramm, double weight) : base(category, name, calories_per100gramm, weight)
        {
            category = Category.Fruity;
            name = "BellPepper";
            calories_per100gramm = 27;
            weight = 80;
        }
    }
}
