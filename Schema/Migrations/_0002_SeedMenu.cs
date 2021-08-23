using FluentMigrator;

namespace Schema.Migrations
{
    [Migration(2)]
    public class _0002_SeedMenu : Migration
    {
        public override void Up()
        {
            Insert.IntoTable("size")
                .Row(new { option = "small", multiplier = 1 })
                .Row(new { option = "medium", multiplier = 1.5 })
                .Row(new { option = "large", multiplier = 2 });

            Insert.IntoTable("dough")
                .Row(new { option = "pan", price = 5 })
                .Row(new { option = "pan - stuffed crust", price = 10 })
                .Row(new { option = "thin", price = 10 })
                .Row(new { option = "thin - stuffed crust", price = 15 })
                .Row(new { option = "regular", price = 15 })
                .Row(new { option = "regular - stuffed crust", price = 20 });

            Insert.IntoTable("topping")
                .Row(new { option = "pepperoni", price = 5 })
                .Row(new { option = "mushroom", price = 10 })
                .Row(new { option = "meat", price = 20 })
                .Row(new { option = "veal", price = 25 })
                .Row(new { option = "chicken", price = 15 })
                .Row(new { option = "seafood", price = 30 })
                .Row(new { option = "shrimp", price = 25 })
                .Row(new { option = "chilli pepper", price = 5 })
                .Row(new { option = "tomato", price = 5 })
                .Row(new { option = "olives", price = 5 })
                .Row(new { option = "onion", price = 5 })
                .Row(new { option = "mozarella cheese", price = 3 });

            Insert.IntoTable("base")
                .Row(new { option = "tomato sauce", price = 5 })
                .Row(new { option = "white sauce", price = 10 });
        }

        public override void Down()
        {
            Delete.FromTable("size").AllRows();

            Delete.FromTable("dough").AllRows();

            Delete.FromTable("topping").AllRows();

            Delete.FromTable("base").AllRows();
        }
    }
}
