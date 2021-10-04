using Pizza.WASM.gRPC.Services;
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
using Restaurant.EntityClasses;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowSpecificOrigins",
    builder =>
    {
        builder.WithOrigins("https://localhost:7028","http://localhost:5129")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();
string connString = app.Configuration["ConnectionStrings:ConnectionString.PostgreSql (Npgsql)"];
LlblGen(connString);

app.UseGrpcWeb(new GrpcWebOptions { DefaultEnabled = true });
app.UseCors("MyAllowSpecificOrigins");

// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>();
app.MapGrpcService<MenuService>();
app.MapGrpcService<PizzaOrderService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

static void LlblGen(string connString)
{
    NpgsqlConnection.GlobalTypeMapper.UseNetTopologySuite(geographyAsDefault: true);

    RuntimeConfiguration.AddConnectionString("ConnectionString.PostgreSql (Npgsql)", connString);

    RuntimeConfiguration.ConfigureDQE<PostgreSqlDQEConfiguration>(
                                    c => c.SetTraceLevel(TraceLevel.Verbose)
                                          .AddDbProviderFactory(typeof(NpgsqlFactory)));
}