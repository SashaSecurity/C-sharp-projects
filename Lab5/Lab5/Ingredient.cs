using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Lab5
{
    public abstract class  Ingredient
    {
        public string name;
        public double calories_per100gramm;

        public Ingredient(string name, double calories_per100gramm)
        {
            this.name = name;
            this.calories_per100gramm = calories_per100gramm;
        }

        public  double TotalCalories()
        {
            return (Getweight() * calories_per100gramm / 100);
        }

        public abstract double Getweight();
        public abstract void AddAmount(double amount);

        

        public override string ToString()
        {
            return $"{name,-18} | Вес: {Getweight(),6:F1} г | {calories_per100gramm,5:F1} ккал/100г | Итого: {TotalCalories(),6:F1} ккал";
        }
    }
}
