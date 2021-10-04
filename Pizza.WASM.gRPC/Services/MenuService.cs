using Grpc.Core;
using Pizza.WASM.gRPC;
using Google.Protobuf.WellKnownTypes;
using Google.Protobuf.Collections;
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
using Restaurant.EntityClasses;


namespace Pizza.WASM.gRPC.Services;

public class MenuService : Menu.MenuBase
{
    private readonly ILogger<MenuService> _logger;
    public MenuService(ILogger<MenuService> logger)
    {
        _logger = logger;
    }

    public override async Task<MenuReply> GetMenu(Empty _, ServerCallContext context)
    {
        using var adapter = new DataAccessAdapter();
        var metaData = new LinqMetaData(adapter);

        var sauces = await (from b in metaData.Base
                        select b)
                        .ProjectToBaseView()
                        .ToListAsync();

        var doughs = await (from d in metaData.Dough
                        select d)
                        .ProjectToDoughView()
                        .ToListAsync();

        var sizes = await (from s in metaData.Size
                        select s)
                        .ProjectToSizeView()
                        .ToListAsync();

        var toppings = await (from t in metaData.Topping
                            select t)
                            .ProjectToToppingView()
                            .ToListAsync();

        MenuReply menu = new();

        foreach (var size in sizes)
        {
            menu.Sizes.Add(new ItemMultiplier { Name = size.Option, Multiplier = size.Multiplier });
        }

        foreach (var dough in doughs)
        {
            menu.Doughs.Add(new Item { Name = dough.Option, Price = (double)dough.Price });
        }
       
        foreach (var sauce in sauces)
        {
            menu.Sauces.Add(new Item { Name = sauce.Option, Price = (double)sauce.Price });
        }

        foreach (var topping in toppings)
        {
            menu.Toppings.Add(new Item { Name = topping.Option, Price = (double)topping.Price });
        }

        return menu;
    }
}
