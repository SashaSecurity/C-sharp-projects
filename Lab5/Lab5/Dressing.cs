using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    public abstract class Dressing:Ingredient
    {
        double FatPercentage;
        Type type;

        public Dressing(double FatPercentage, Type type, string name, double calories_per100gramm, double weight) : base(name, calories_per100gramm, weight)
        {
            FatPercentage=this.FatPercentage;
            type = this.type;
        }
    }
}
