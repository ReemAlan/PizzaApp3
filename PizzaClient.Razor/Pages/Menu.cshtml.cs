using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace PizzaClient.Razor.Pages;

public class MenuModel : PageModel
{
    private readonly ILogger<MenuModel> _logger;
    private readonly IHttpClientFactory _clientFactory;

    // public List<BaseView> Sauces { get; set; }
    // public List<DoughView> Dough { get; set; }   
    // public List<SizeView> Sizes { get; set; }
    // public List<ToppingView> Toppings { get; set; }      

    public MenuModel(ILogger<MenuModel> logger, IHttpClientFactory clientFactory)
    {
        _logger = logger;
        _clientFactory = clientFactory;
    }

    public async void OnGet()
    {
        var client = _clientFactory.CreateClient("localhost");
        string response = await client.GetStringAsync("menu");
        JsonObject menu = JsonNode.Parse(response).AsObject();
        _logger.LogInformation(menu["baseTable"].ToString());
    }
}