using FluentMigrator;

namespace Schema.Migrations
{
    [Migration(1)]
    public class _0001_MenuTables : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("size")
                .WithColumn("option").AsString().NotNullable().PrimaryKey()
                .WithColumn("multiplier").AsFloat().NotNullable();

            Create.Table("dough")
                .WithColumn("option").AsString().NotNullable().PrimaryKey()
                .WithColumn("price").AsCurrency().NotNullable();

            Create.Table("topping")
                .WithColumn("option").AsString().NotNullable().PrimaryKey()
                .WithColumn("price").AsCurrency().NotNullable();

            Create.Table("base")
                .WithColumn("option").AsString().NotNullable().PrimaryKey()
                .WithColumn("price").AsCurrency().NotNullable();
        }
    }
}
