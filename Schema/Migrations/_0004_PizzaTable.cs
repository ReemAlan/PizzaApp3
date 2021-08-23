using FluentMigrator;

namespace Schema.Migrations
{
    [Migration(4)]
    public class _0004_PizzaTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("pizza")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("order_id").AsInt32().NotNullable()
                .WithColumn("size").AsString().NotNullable()
                .WithColumn("dough").AsString().NotNullable()
                .WithColumn("base").AsString().NotNullable();

            Create.ForeignKey()
                .FromTable("pizza").ForeignColumn("order_id")
                .ToTable("order").PrimaryColumn("id");

            Create.ForeignKey()
                .FromTable("pizza").ForeignColumn("size")
                .ToTable("size").PrimaryColumn("option");

            Create.ForeignKey()
                .FromTable("pizza").ForeignColumn("dough")
                .ToTable("dough").PrimaryColumn("option");

            Create.ForeignKey()
                .FromTable("pizza").ForeignColumn("base")
                .ToTable("base").PrimaryColumn("option");
        }
    }
}
