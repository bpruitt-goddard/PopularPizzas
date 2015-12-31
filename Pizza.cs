using System;

public class Pizza
{
    public string[] Toppings { get; set; }
}

public class PizzaComparer : System.Collections.Generic.IEqualityComparer<Pizza>
{
    public bool Equals (Pizza a, Pizza b)
    {
        if (object.ReferenceEquals(a, b)) return true;
        
        return GetHashCode(a) == GetHashCode(b);
    }
    
    public int GetHashCode(Pizza pizza)
    {
        int hashCode = pizza.Toppings.Length;
        Array.Sort(pizza.Toppings, StringComparer.InvariantCultureIgnoreCase);
        
        for (int i = 0; i < pizza.Toppings.Length; i++)
        {
            hashCode = unchecked(hashCode * 17 + pizza.Toppings[i].GetHashCode());
        }
        return hashCode;
    }   
}