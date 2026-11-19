using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    public class Tomato : Vegetables
    {
        public Tomato(Category category, string name, double calories_per100gramm, double weight) : base(category, name, calories_per100gramm, weight)
        {
            category = Category.Fruity;
            name = "Tomato";
            calories_per100gramm = 18;
            weight = 120;
        }
    }
}
