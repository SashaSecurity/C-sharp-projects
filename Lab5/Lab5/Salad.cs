using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    public class Salad
    {
        public string Name { get; private set; }

        private readonly List<Ingredient> ing = new List<Ingredient>();

        public IReadOnlyList<Ingredient> Ingredient
        {
            get { return ing; }
        }

        public Salad(string Name)
        {
            this.Name = Name;
        }

        public void addIngredient(Ingredient newIng)
        {
            Ingredient existItem = null;
            foreach (Ingredient item in ing)
            {

                if (item.name == newIng.name)
                {

                    existItem = item;
                    break;

                }
            }
            if (existItem != null)
            {
                existItem.AddAmount(newIng.Getweight());
            }
            else
            {
                ing.Add(newIng);
            }
        }

        public  double calculateCalories(){

            double total=0.0;
            foreach (Ingredient item in ing)
            {
                total += item.TotalCalories();
            }

            return total;

        }

        public void SortIngredients(IComparer<Ingredient> comparer)
        {
            ing.Sort(comparer);
        }

        public List<Vegetables> SortVegetables(double mincallories, double maxcallories) { 
        
            List<Vegetables> result= new List<Vegetables>();

            foreach(Ingredient item in ing) { 
            
            if(item is Vegetables veg)
                    if(veg.calories_per100gramm >=mincallories && veg.calories_per100gramm<=maxcallories)
                    {
                        result.Add(veg);
                    }
            }
            return result;
        }
    }
}
