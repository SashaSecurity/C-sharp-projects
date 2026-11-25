using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab5
{
    public class Recipe
    {
        public List<Salad> MakeRecipe()
        {
            string file = "recipe.txt";
            List<Salad> salad = new List<Salad>();
            if (!File.Exists(file))
            {
                Console.WriteLine("Няма файла");
                return salad;
            }

            string[] lines = File.ReadAllLines(file);
            Salad currentsalad = null;

            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line)) continue;

                if (line.StartsWith("#"))
                {
                    string saladName = line.Substring(1).Trim();
                    currentsalad = new Salad(saladName);
                    salad.Add(currentsalad);
                }
                else if (currentsalad != null) {
                    string[] parts = line.Split(';');

                    if (parts.Length == 2 && double.TryParse(parts[1].Trim(), out double amount))
                    {
                        Ingredient ingredient = createIngredient(parts[0].Trim(), amount);

                        if (ingredient != null)
                        {

                            currentsalad.addIngredient(ingredient);
                        }
                        else Console.WriteLine("Ингредиент не найден");
                    }
                }



            }
            return salad;
        }

        public Ingredient createIngredient(string name, double amount) {
            switch (name.ToLower()){

                    case "tomato": return new Vegetables(Category.Fruity, "Tomato", 18, amount);
                    case "cucumber": return new Vegetables(Category.Fruity, "Cucumber" , 15, amount);
                    case "carrot": return new Vegetables(Category.Fruity, "Carrot", 35, amount);
                    case "dill": return new Vegetables(Category.Leafy, "Dill", 40, amount);
                case "potato": return new Vegetables(Category.Root, "Potato", 50, amount);
                case "redonion": return new Vegetables(Category.Bulb, "Red Onion", 40, amount);
                case "mayonnaise": return new Dressing(Type.Creamy, "Mayonise", amount, 0.92, 884);
                case "oliveoil": return new Dressing(Type.Oil, "Oliveoil", amount, 1.05, 680);
                default: return null;
            }
        }

     }

}