using System;
using System.Collections.Generic;
namespace Lab5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Recipe recipe = new Recipe();
            List<Salad> salad = recipe.MakeRecipe();

            if (salad.Count == 0)
            {
                Console.WriteLine("Список салатов пуст");
                return;
            }

            Console.WriteLine("Доступные салаты");

            for (int i = 0; i < salad.Count; i++)
            {
                Console.WriteLine($"{i + 1} {salad[i].Name}");
            }

            int choice = ReadInt("Выберите салат: ", 1, salad.Count);

            Salad select = salad[choice - 1];

            Console.WriteLine($"\n Салат {select.Name}");
            PrintIngredients(select.Ingredient);

            Console.WriteLine($"Общая калорийность: {select.calculateCalories():F1} ккал\n");


            Console.WriteLine("Сортировка по весу");
            select.SortIngredients(new WeightComparator());
            Console.WriteLine("Отсортировано по весу");

            PrintIngredients(select.Ingredient);


            Console.WriteLine("\n Поиск овощей по калорийности (на 100 г)");
            double minCal = ReadDouble("Введите минимальную калорийность: ");
            double maxCal = ReadDouble("Введите максимальную калорийность: ");



            List<Vegetables> found = select.SortVegetables(minCal, maxCal);
            if (found.Count == 0)
                Console.WriteLine("Овощей в этом диапазоне нет.");
            else
                foreach (var veg in found)
                    Console.WriteLine(veg);
        }





        private static int ReadInt(string text, int min, int max)
        {
            while (true)
            {
                Console.WriteLine(text);
                if (int.TryParse(Console.ReadLine(), out int val) && val >= min && val<=max) return val;
                Console.WriteLine($"Введите значение от {min} до {max}");
            }
        }

        private static double ReadDouble(string text)
        {
            while (true) {
                Console.WriteLine(text);
                if(double.TryParse(Console.ReadLine(), out double value) && value >= 0)
                {
                    return value;
                }
                Console.WriteLine("Введите положительное число");
            }
        }

        private static void PrintIngredients(IReadOnlyList<Ingredient> ingredients)
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                Console.WriteLine(ingredients[i]);
            }
        }


        
    }
}


    
