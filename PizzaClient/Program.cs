// See https://aka.ms/new-console-template for more information
using Spectre.Console;
using System.Net.Http;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Text.Json.Serialization;
using System;

namespace PizzaApp
{
    public class Program
    {
        static readonly string _baseUrl = "http://localhost:5000/api";

        public static Dictionary<string, double> Sizes { get; set; } = new();
        public static Dictionary<string, double> Dough { get; set; } = new();
        public static Dictionary<string, double> Toppings { get; set; } = new();
        public static Dictionary<string, double> Sauces { get; set; } = new();

        public static async Task Main(string[] args)
        {
            var client = new HttpClient();

            AnsiConsole.Render(new FigletText("The Pizza Place")
                    .LeftAligned()
                    .Color(Color.Red));

            var menu = await client.GetStringAsync(_baseUrl + "/menu");
            JsonObject parsedMenu = JsonNode.Parse(menu).AsObject();
            DisplayMenu(parsedMenu);


            string name = AnsiConsole.Ask<string>("What's your [green]name[/]?");
            Order order = new Order(name);
            bool keepActive = true;

            while (keepActive)
            {
                order.PlaceOrder();
                if (!AnsiConsole.Confirm("Would you like another pizza?"))
                {
                    keepActive = false;
                }
            }

            if (AnsiConsole.Confirm("Place this order?"))
            {
               var jsonOrder = JsonSerializer.Serialize<Order>(order, new JsonSerializerOptions
               {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
               });
               Console.WriteLine(jsonOrder);
               StringContent newOrder = new StringContent(jsonOrder, Encoding.UTF8, "application/json");
               var response = await client.PostAsync(_baseUrl + "/order", newOrder);

               if (response.IsSuccessStatusCode)
               {
                   order.GetOrderPrice();
                   AnsiConsole.Markup("[blue]Thank you for visiting our store![/]");
               }
               else
               {
                   AnsiConsole.Markup("[crimson]We could not place your order :([/]");
               }
            }
        }

        public static void DisplayMenu(JsonObject menu)
        {
            var sizeTable = new Table().RoundedBorder().BorderColor(Color.BlueViolet);
            sizeTable.AddColumn("Size");
            sizeTable.AddColumn("Dough Multiplier");

            List<JsonNode> sizes = menu["sizeTable"].AsArray().ToList();
            foreach (var obj in sizes)
            {
                sizeTable.AddRow($"{obj["option"]}", $"{obj["multiplier"]}");
                Sizes.Add((string)obj["option"], (double)obj["multiplier"]);
            }

            var baseTable = new Table().RoundedBorder().BorderColor(Color.BlueViolet);
            baseTable.AddColumn("Base");
            baseTable.AddColumn("Price");

            List<JsonNode> bases = menu["baseTable"].AsArray().ToList();
            foreach (var obj in bases)
            {
                baseTable.AddRow($"{obj["option"]}", $"{obj["price"]}");
                Sauces.Add((string)obj["option"], (double)obj["price"]);
            }

            var doughTable = new Table().RoundedBorder().BorderColor(Color.BlueViolet);
            doughTable.AddColumn("Dough");
            doughTable.AddColumn("Price");

            List<JsonNode> dough = menu["doughTable"].AsArray().ToList();
            foreach (var obj in dough)
            {
                doughTable.AddRow($"{obj["option"]}", $"{obj["price"]}");
                Dough.Add((string)obj["option"], (double)obj["price"]);
            }

            var toppingTable = new Table().RoundedBorder().BorderColor(Color.BlueViolet);
            toppingTable.AddColumn("Topping");
            toppingTable.AddColumn("Price");

            List<JsonNode> toppings = menu["toppingTable"].AsArray().ToList();
            foreach (var obj in toppings)
            {
                toppingTable.AddRow($"{obj["option"]}", $"{obj["price"]}");
                Toppings.Add((string)obj["option"], (double)obj["price"]);
            }

            AnsiConsole.Render(sizeTable);
            AnsiConsole.Render(doughTable);
            AnsiConsole.Render(baseTable);
            AnsiConsole.Render(toppingTable);
        }
    }
}