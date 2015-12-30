using System;
using System.Collections.Generic;
using System.Linq;
using ServiceStack.Text;

namespace PopularPizzas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            var pizzas = Test();
            Console.WriteLine("{0} pizzas", pizzas.Count());
            // Console.WriteLine("First Pizza {0}", pizzas.First().Toppings.Count());
            Console.Read();
            
        }
        
        public static List<Pizza> Test()
        {
            var json = "[  {    \"toppings\": [      \"pepperoni\"    ]  },  {    \"toppings\": [      \"feta cheese\"    ]  },  {    \"toppings\": [      \"pepperoni\"    ]  }";        
            var pizzas = JsonSerializer.DeserializeFromString<List<Pizza>>(json);
            return pizzas;
        }
    }
}
