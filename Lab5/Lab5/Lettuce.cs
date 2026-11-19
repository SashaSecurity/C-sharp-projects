using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    public class Lettuce:Vegetables
    {
        public Lettuce (Category category, string name, double calories_per100gramm, double weight) : base( category, name, calories_per100gramm, weight) 
        {
            category = Category.Leafy;
            name = "Lettuce";
            calories_per100gramm = 14;
            weight = 60;
        }
    }
}
