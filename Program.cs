using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using ServiceStack.Text;

namespace PopularPizzas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var pizzas = ParseFile();
            
            //Group by toppings and get top 20
            var topPizzas = pizzas.GroupBy(s => s, new PizzaComparer())
                    .OrderByDescending(s => s.Count())
                    .Take(20)
                    .Select(g => new { Toppings = g.First().Toppings, Count = g.Count()}).ToList();
                        
            for (int i = 0; i < topPizzas.Count; i++)
            {
                Console.WriteLine("{0}/20 best pizza: {1}", i+1, topPizzas[i].Dump());
            }
            Console.Read();
        }
        
        public static List<Pizza> ParseFile()
        {
            var text = File.ReadAllText("pizzaData.json");
            return JsonSerializer.DeserializeFromString<List<Pizza>>(text);
        }
    }
}
