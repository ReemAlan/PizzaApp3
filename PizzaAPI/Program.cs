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
using SD.LLBLGen.Pro.DQE.PostgreSql; 
using SD.LLBLGen.Pro.ORMSupportClasses;
using SD.LLBLGen.Pro.LinqSupportClasses;
using Npgsql;

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

app.MapPost("api/order", () =>
{

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