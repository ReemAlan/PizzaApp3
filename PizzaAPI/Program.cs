using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics; 
using System.Linq; 
using Restaurant.DatabaseSpecific;
using Restaurant.Linq;
using Restaurant.EntityClasses;
using Restaurant.FactoryClasses;
using Restaurant.HelperClasses;
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

app.MapGet("/api/menu", async () =>
{
    var toppings = new EntityCollection<ToppingEntity>();
    using var adapter = new DataAccessAdapter();
    var metaData = new LinqMetaData(adapter);
    return "";
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