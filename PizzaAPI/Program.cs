using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System;
using System.Data;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
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

app.MapGet("/api/menu", async () =>
{
    using var adapter = new DataAccessAdapter();
    var metaData = new LinqMetaData(adapter);

    var qSauces = (from b in metaData.Base
                    select b)
                    .ProjectToBaseView();
    var sauces = await qSauces.ToListAsync();

    var qDoughs = (from d in metaData.Dough
                    select d)
                    .ProjectToDoughView();
    var doughs = await qDoughs.ToListAsync();

    var qSizes = (from s in metaData.Size
                    select s)
                    .ProjectToSizeView();
    var sizes = await qSizes.ToListAsync();

    var qToppings = (from t in metaData.Topping
                        select t)
                        .ProjectToToppingView();
    var toppings = await qToppings.ToListAsync();

    return new {
        baseTable = sauces,
        doughTable = doughs,
        sizeTable = sizes,
        toppingTable = toppings
    };
});

app.MapGet("api/price", async ([FromBody]Pizza pizza) => 
{
    decimal sum = 0;
    
    using var adapter = new DataAccessAdapter();
    var metaData = new LinqMetaData(adapter);

    var sizePrice = (from s in metaData.Size
                    where s.Option == pizza.Size
                    select s.Multiplier);

    var doughPrice = (from d in metaData.Dough
                    where d.Option == pizza.Dough
                    select d.Price);

    var saucePrice = (from b in metaData.Base
                    where b.Option == pizza.BaseSauce
                    select b.Price);
    
    var toppingsPrice = await (from t in metaData.Topping
                        where pizza.Toppings.Contains(t.Option)
                        select t.Price)
                        .ToListAsync();

    sum =  (decimal)(await sizePrice.SingleAsync()) * (await doughPrice.SingleAsync()) + (await saucePrice.SingleAsync()) + toppingsPrice.Sum();

    return sum;
});

app.MapPost("api/order", async ([FromBody]Order order) =>
{
    using var adapter = new DataAccessAdapter();
    adapter.StartTransaction(IsolationLevel.ReadCommitted, "MultiEntityInsertion");
    try
    {
        OrderEntity orderRow = new OrderEntity();
        orderRow.CustomerName = order.CustomerName;
        await adapter.SaveEntityAsync(orderRow, true);
        int orderId = orderRow.Id;
        foreach (var pizza in order.Pizzas)
        {
            PizzaEntity pizzaRow = new PizzaEntity();
            pizzaRow.Base = pizza.BaseSauce;
            pizzaRow.Dough = pizza.Dough;
            pizzaRow.OrderId = orderId;
            pizzaRow.Size = pizza.Size;
            pizzaRow.Price = (decimal)pizza.Price;
            await adapter.SaveEntityAsync(pizzaRow, true);

            int pizzaId = pizzaRow.Id;
            foreach (var topping in pizza.Toppings)
            {
                PizzaToppingEntity toppingRow = new PizzaToppingEntity();
                toppingRow.PizzaId = pizzaId;
                toppingRow.Topping = topping;
                await adapter.SaveEntityAsync(toppingRow, true);
            }
        }
        await adapter.CommitAsync(CancellationToken.None);
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        adapter.Rollback();
    }
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
    public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
    public string CustomerName { get; set; }
    
    public Order(string customerName)
    {
        CustomerName = customerName;
    }
}

public class Pizza
{
    public string Size { get; set; }
    public string Dough { get; set; }
    public string[] Toppings { get; set; }
    public string BaseSauce { get; set; }
    public double Price { get; set; }

    public Pizza(string size, string dough, string[] toppings, string baseSauce) 
    {
        Size = size;
        Dough = dough;
        Toppings = toppings;
        BaseSauce = baseSauce;
    }

}