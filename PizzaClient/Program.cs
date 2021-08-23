using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.DatabaseSpecific;
using Restaurant.Linq;
using SD.LLBLGen.Pro.DQE.PostgreSql;
using SD.LLBLGen.Pro.ORMSupportClasses;
using Npgsql;

namespace PizzaClient
{
    class Program
    {
        static void Main(string[] args)
        {
            RuntimeConfiguration.ConfigureDQE<PostgreSqlDQEConfiguration>(
                                c => c.SetTraceLevel(TraceLevel.Verbose)
                                        .AddDbProviderFactory(typeof(NpgsqlFactory)));

            using (var adapter = new DataAccessAdapter())
            {
                var metaData = new LinqMetaData(adapter);
                var count = metaData.Topping.Count();
                Console.WriteLine("Number of toppings: {0}", count);
            }
        }
    }
}
