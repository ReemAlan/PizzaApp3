using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PizzaClient.WASM;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Grpc.Net.Client.Web;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazorise( options =>
{
    options.ChangeTextOnKeyPress = true;
} )
.AddBootstrapProviders()
.AddFontAwesomeIcons();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped(services => 
{ 
    var channel = GrpcChannel.ForAddress("https://localhost:7016", new GrpcChannelOptions
    {
        HttpHandler = new GrpcWebHandler(new HttpClientHandler())
    });
    return new Greeter.GreeterClient(channel);
});

builder.Services.AddScoped(services => 
{ 
    var channel = GrpcChannel.ForAddress("https://localhost:7016", new GrpcChannelOptions
    {
        HttpHandler = new GrpcWebHandler(new HttpClientHandler())
    });
    return new Menu.MenuClient(channel);
});

builder.Services.AddScoped(services => 
{ 
    var channel = GrpcChannel.ForAddress("https://localhost:7016", new GrpcChannelOptions
    {
        HttpHandler = new GrpcWebHandler(new HttpClientHandler())
    });
    return new PizzaOrder.PizzaOrderClient(channel);
});

await builder.Build().RunAsync();
