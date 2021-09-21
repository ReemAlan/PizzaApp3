using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace PizzaApp
{

    public class Pizza
    {
        public string Size { get; set; }
        public string Dough { get; set; }
        public string[] Toppings { get; set; }
        public string BaseSauce { get; set; }
        public double Price { get; set; } = 0;

        public Pizza(string size, string dough, string[] toppings, string baseSauce) 
        {
            Size = size;
            Dough = dough;
            Toppings = toppings;
            BaseSauce = baseSauce;
        }

        public override string ToString() 
        {
            return JsonSerializer.Serialize<Pizza>(this, new JsonSerializerOptions 
            {
                    WriteIndented = true
            });
        }
    }
}
