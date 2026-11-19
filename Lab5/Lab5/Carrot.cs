using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    public class Carrot : Vegetables
    {
        public Carrot(Category category, string name, double calories_per100gramm, double weight) : base(category, name, calories_per100gramm, weight)
        {
            category = Category.Root;
            name = "Carrot";
            calories_per100gramm = 35;
            weight = 70;
        }
    }
}
