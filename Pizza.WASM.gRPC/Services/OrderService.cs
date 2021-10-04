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

public class PizzaOrderService : PizzaOrder.PizzaOrderBase
{
    private readonly ILogger<PizzaOrderService> _logger;
    public PizzaOrderService(ILogger<PizzaOrderService> logger)
    {
        _logger = logger;
    }

    public override async Task<Confirmation> MakeOrder(Order order, ServerCallContext context)
    {
        using var adapter = new DataAccessAdapter();
        adapter.StartTransaction(IsolationLevel.ReadCommitted, "MultiEntityInsertion");
        try
        {
            OrderEntity orderRow = new OrderEntity();
            orderRow.CustomerName = order.CustomerName;
            await adapter.SaveEntityAsync(orderRow, true);
            int orderId = orderRow.Id;

            PizzaEntity pizzaRow = new PizzaEntity();
            pizzaRow.Base = order.Pizza.Sauce;
            pizzaRow.Dough = order.Pizza.Dough;
            pizzaRow.OrderId = orderId;
            pizzaRow.Size = order.Pizza.Size;
            pizzaRow.Price = (decimal)order.Pizza.Price;
            await adapter.SaveEntityAsync(pizzaRow, true);

            int pizzaId = pizzaRow.Id;
            foreach (var topping in order.Pizza.Toppings)
            {
                PizzaToppingEntity toppingRow = new PizzaToppingEntity();
                toppingRow.PizzaId = pizzaId;
                toppingRow.Topping = topping;
                await adapter.SaveEntityAsync(toppingRow, true);
            }
        
            await adapter.CommitAsync(CancellationToken.None);
            return new Confirmation { Message = "Thank you for visiting our restaurant!"};
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            adapter.Rollback();
            return new Confirmation { Message = "Sorry, a problem occurred. We couldn't place your order. :("};
        }
    }
}
