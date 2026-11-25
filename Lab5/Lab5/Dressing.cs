using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    public class Dressing:Ingredient
    {
        private double volume_mil;
        private double density;
        Type type;

        public Dressing(Type type, string name, double volume_mil, double density, double calories_per100gramm) : base(name, calories_per100gramm)
        {
            this.volume_mil=volume_mil;
            this.type= type;
            this.density = density;
        }

        public override void AddAmount(double amount)

        {
           
              volume_mil += amount;
        }

        public override double Getweight()
        {
            return (volume_mil * density);
        }

        public override string ToString()
        {
            return $"{base.ToString()} {volume_mil:F1} мл";
        }
    }
}
