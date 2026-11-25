using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Lab5
{
    public class Vegetables:Ingredient
    {
       private Category category;
        
        private double weight;
        

       public Vegetables(Category category, string name, double calories_per100gramm, double weight) :base(name, calories_per100gramm)
        {
            this.category = category;
            this.weight = weight;
        }

       
        public override double Getweight()
        {
            return weight;
        }

        public override void AddAmount(double amount)
        {
            weight += amount;
        }
   

    }
}
