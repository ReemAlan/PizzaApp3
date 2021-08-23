using FluentMigrator;

namespace Schema.Migrations
{
    [Migration(5)]
    public class _0005_PizzaToppingTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("pizza_topping")
                .WithColumn("pizza_id").AsInt32().NotNullable()
                .WithColumn("topping").AsString().NotNullable();

            Create.PrimaryKey()
                .OnTable("pizza_topping").Columns(new string[] { "pizza_id", "topping" });

            Create.ForeignKey()
                .FromTable("pizza_topping").ForeignColumn("pizza_id")
                .ToTable("pizza").PrimaryColumn("id");

            Create.ForeignKey()
                .FromTable("pizza_topping").ForeignColumn("topping")
                .ToTable("topping").PrimaryColumn("option");
        }
    }
}
