using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace PizzaClient.Razor.Pages;

public class MenuModel : PageModel
{
    public IDictionary<string, double> Sizes { get; set; } = new Dictionary<string, double>();
    public IDictionary<string, double> Dough { get; set; } = new Dictionary<string, double>();
    public IDictionary<string, double> Toppings { get; set; } = new Dictionary<string, double>();
    public IDictionary<string, double> Sauces { get; set; } = new Dictionary<string, double>();

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

}