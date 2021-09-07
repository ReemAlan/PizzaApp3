using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using PizzaClient.Razor.DTOs;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PizzaClient.Razor.Pages
{
    public class MenuModel : PageModel
    {
        public IDictionary<string, double> Sizes { get; set; } = new Dictionary<string, double>();
        public IDictionary<string, double> Dough { get; set; } = new Dictionary<string, double>();
        public IDictionary<string, double> Toppings { get; set; } = new Dictionary<string, double>();
        public IDictionary<string, double> Sauces { get; set; } = new Dictionary<string, double>();
        
        [BindProperty]
        public Order order { get; set; }
        private readonly IHttpClientFactory _clientFactory;

        public MenuModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task OnGetAsync()
        {
            var client = _clientFactory.CreateClient("localhost");
            string response = await client.GetStringAsync("menu");
            JsonObject? menu = JsonNode.Parse(response).AsObject();

            var sizes = menu["sizeTable"].AsArray();
            foreach (var obj in sizes)
            {
                Sizes.Add((string)obj["option"], (double)obj["multiplier"]);
            }

            var bases = menu["baseTable"].AsArray();
            foreach (var obj in bases)
            {
                Sauces.Add((string)obj["option"], (double)obj["price"]);
            }

            var dough = menu["doughTable"].AsArray();
            foreach (var obj in dough)
            {
                Dough.Add((string)obj["option"], (double)obj["price"]);
            }

            var toppings = menu["toppingTable"].AsArray();
            foreach (var obj in toppings)
            {
                Toppings.Add((string)obj["option"], (double)obj["price"]);
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("OnGetAsync");
            }

            var price = CalculatePrice(order.Pizza);

            var client = _clientFactory.CreateClient("localhost");
            var jsonOrder = JsonSerializer.Serialize<Order>(order);
            StringContent newOrder = new StringContent(jsonOrder, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("order", newOrder);

            if (response.IsSuccessStatusCode)
            {
                ViewData["message"] = $"Thank you for visiting our restaurant!\nThe total price is {price}";
            }
            else
            {
                ViewData["message"] = "We could not place your order :(";
            }

            return Page();
        }

        // public double GetOrderPrice(Order order)
        // {
        //     double total = 0;
        //     foreach (var pizza in order.Pizzas)
        //     {
        //         pizza.Price = CalculatePrice(pizza);
        //         total += pizza.Price;
        //     }
        //     return total;
        // }

        public double CalculatePrice(Pizza pizza) 
        {
            double sum = 0;
            foreach (var topping in pizza.Toppings)
            {
                sum += Toppings[topping];
            }

            sum += Sizes[pizza.Size] * Dough[pizza.Dough] + Sauces[pizza.BaseSauce];
            return sum;
        }
    }

}