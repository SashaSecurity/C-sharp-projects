using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Lab5
{
    public abstract class Vegetables:Ingredient
    {
       protected Category category;

       public Vegetables(Category category, string name, double calories_per100gramm, double weight) :base(name, calories_per100gramm, weight)
        {
            this.category = category;
        }

        public void printType()
        {
            Console.WriteLine("Category: " + category);
        }
    }
}
