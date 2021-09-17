using FluentMigrator;

namespace Schema.Migrations
{
    [Migration(6)]
    public class _0006_PizzaPriceColumn : Migration
    {
        public override void Up()
        {
            Alter.Table("pizza")
                .AddColumn("price")
                .AsCurrency()
                .NotNullable();
        }

        public override void Down()
        {
            Delete.Column("price")
                .FromTable("pizza");
        }

    }
}
