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
using System;

namespace PizzaClient.Razor.Pages
{
    public class MenuModel : PageModel
    {
        public Dictionary<string, double> Sizes { get; set; } = new();
        public Dictionary<string, double> Dough { get; set; } = new();
        public Dictionary<string, double> Toppings { get; set; } = new();
        public Dictionary<string, double> Sauces { get; set; } = new();

        [TempData]
        public bool isSubmitClicked { get; set; } = false;
        
        [BindProperty]
        public Order Order { get; set; }

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
                return RedirectToPage("Menu");
            }

            var client = _clientFactory.CreateClient("localhost");
            var jsonPizza = JsonSerializer.Serialize<Pizza>(Order.Pizza, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(client.BaseAddress.ToString() + "price"),
                Content = new StringContent(jsonPizza, Encoding.UTF8, "application/json"),
            };
            var price = await client.SendAsync(request);
            Order.Pizza.Price = Double.Parse(await price.Content.ReadAsStringAsync());
            
            var jsonOrder = JsonSerializer.Serialize<Order>(Order);

            StringContent newOrder = new StringContent(jsonOrder, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("order", newOrder);

            if (response.IsSuccessStatusCode)
            {
                TempData["message"] = $"Thank you for visiting our restaurant!\nThe total price is {Order.Pizza.Price}";
            }
            else
            {
                TempData["message"] = "We could not place your order :(";
            }
            
            isSubmitClicked = true;

            return RedirectToPage("Menu");
        }
    }
}
