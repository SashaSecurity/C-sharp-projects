using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    public abstract class  Ingredient
    {
        protected string name;
        protected double calories_per100gramm;
         protected double weight;

        public Ingredient(string name, double calories_per100gramm, double weight)
        {
            this.name = name;
            this.calories_per100gramm = calories_per100gramm;
            this.weight = weight;
        }

        public double TotalCalories(double calories_per100gramm, double weight)
        {
           double Total = (weight / 100.0) * calories_per100gramm;
            return Total;
        }
    }
}
