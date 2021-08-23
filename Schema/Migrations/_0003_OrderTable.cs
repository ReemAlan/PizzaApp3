using FluentMigrator;

namespace Schema.Migrations
{
    [Migration(3)]
    public class _0003_OrderTable : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("order")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey().Identity()
                .WithColumn("customer_name").AsString().Nullable();
        }
    }
}
