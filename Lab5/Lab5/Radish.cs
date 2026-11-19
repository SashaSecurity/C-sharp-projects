using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    public class Redish : Vegetables
    {
        public Redish(Category category, string name, double calories_per100gramm, double weight) : base(category, name, calories_per100gramm, weight)
        {
            category = Category.Root;
            name = "Redish";
            calories_per100gramm = 20;
            weight = 50;
        }
    }
}
