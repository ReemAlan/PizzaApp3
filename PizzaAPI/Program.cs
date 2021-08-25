using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using Restaurant;
using Restaurant.DatabaseSpecific;
using View.DtoClasses;
using View.Persistence;
using Restaurant.Linq;
using Npgsql;
using System.Collections.Generic;
using SD.LLBLGen.Pro.DQE.PostgreSql;
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.LinqSupportClasses;
using System.Linq;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Restaurant.EntityClasses;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

var app = builder.Build();
string connString = app.Configuration["ConnectionStrings:ConnectionString.PostgreSql (Npgsql)"];
LlblGen(connString);

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.MapGet("/api/menu", () =>
{
    List<BaseView>? sauces = null;
    List<DoughView>? doughs = null;
    List<SizeView>? sizes = null;
    List<ToppingView>? toppings = null;
    using (var adapter = new DataAccessAdapter())
    {
        var metaData = new LinqMetaData(adapter);

        var qSauces = (from b in metaData.Base
                       select b)
                       .ProjectToBaseView();
        sauces = qSauces.ToList();

        var qDoughs = (from d in metaData.Dough
                       select d)
                       .ProjectToDoughView();
        doughs = qDoughs.ToList();

        var qSizes = (from s in metaData.Size
                      select s)
                      .ProjectToSizeView();
        sizes = qSizes.ToList();

        var qToppings = (from t in metaData.Topping
                         select t)
                         .ProjectToToppingView();
        toppings = qToppings.ToList();
    }
    return new {
        baseTable = sauces,
        doughTable = doughs,
        sizeTable = sizes,
        toppingTable = toppings
    };
});

app.MapPost("api/order", ([FromBody] Order order) =>
{
    int orderId = -1;

    using(DataAccessAdapter adapter = new DataAccessAdapter())
    {
        OrderEntity orderRow = new OrderEntity();
        orderRow.CustomerName = order.CustomerName;
        adapter.SaveEntity(orderRow, true);
        orderId = orderRow.Id;
        foreach (var pizza in order.Pizzas)
        {
            PizzaEntity pizzaRow = new PizzaEntity();
            pizzaRow.Base = pizza.BaseSauce;
            pizzaRow.Dough = pizza.Dough;
            pizzaRow.OrderId = orderId;
            pizzaRow.Size = pizza.Size;
            adapter.SaveEntity(pizzaRow, true);

            int pizzaId = pizzaRow.Id;
            foreach (var topping in pizza.Toppings)
            {
                PizzaToppingEntity toppingRow = new PizzaToppingEntity();
                toppingRow.PizzaId = pizzaId;
                toppingRow.Topping = topping;
                adapter.SaveEntity(toppingRow, true);
            }
        }
    }

    /*using(DataAccessAdapter adapter = new DataAccessAdapter())
    {
        var metaData = new LinqMetaData(adapter);
        var qSauces = (from b in metaData.Base
                       select b)
                       .ProjectToBaseView();
    }*/
});

app.Run();

static void LlblGen(string connString)
{
    NpgsqlConnection.GlobalTypeMapper.UseNetTopologySuite(geographyAsDefault: true);

    RuntimeConfiguration.AddConnectionString("ConnectionString.PostgreSql (Npgsql)", connString);

    RuntimeConfiguration.ConfigureDQE<PostgreSqlDQEConfiguration>(
                                    c => c.SetTraceLevel(TraceLevel.Verbose)
                                          .AddDbProviderFactory(typeof(NpgsqlFactory)));
}

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
}

public class Pizza
{
    [JsonPropertyName("size")]
    public string Size { get; set; }
    [JsonPropertyName("dough")]
    public string Dough { get; set; }
    [JsonPropertyName("topping")]
    public string[] Toppings { get; set; }
    [JsonPropertyName("base")]
    public string BaseSauce { get; set; }
    [JsonPropertyName("price")]
    public double Price { get; set; }
    public Pizza(string size, string dough, string[] toppings, string baseSauce) 
    {
        Size = size;
        Dough = dough;
        Toppings = toppings;
        BaseSauce = baseSauce;
    }

}