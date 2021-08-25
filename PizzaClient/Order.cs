using Spectre.Console;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PizzaApp
{
    public class Order 
    {
        [JsonPropertyName("pizzas")]
        public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
        [JsonPropertyName("customerName")]
        public string CustomerName { get; set; }
        
        public Order(string customerName)
        {
            CustomerName = customerName;
        }

        public override string ToString() => JsonSerializer.Serialize<Order>(this);

        public void GetOrderPrice()
        {
            double total = 0;
            foreach (var pizza in this.Pizzas)
            {
                total += pizza.Price;
            }
            AnsiConsole.Markup($"Total price: [green]{total}[/]\n\n");
        }

        public double CalculatePrice(Pizza pizza) 
        {
            double sum = 0;
            foreach (var topping in pizza.Toppings)
            {
                sum += Program.Toppings[topping];
            }

            sum += Program.Sizes[pizza.Size] * Program.Dough[pizza.Dough] + Program.Sauces[pizza.BaseSauce];
            return sum;
        }
    }
}