using FluentMigrator;

namespace Schema.Migrations
{
    [Migration(6)]
    public class _0006_PizzaPriceColumn : AutoReversingMigration
    {
        public override void Up()
        {
            Alter.Table("pizza")
                .AddColumn("price")
                .AsCurrency()
                .NotNullable();
        }
    }
}
