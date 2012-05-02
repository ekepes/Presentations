using FluentMigrator;

namespace SampleSOA.PatientOrderService.Migrations
{
    [Migration(201202091027)]
    public class ItemPickTableCreationMigration : AutoReversingMigration
    {
        public override void Up()
        {
            Create.Table("ItemPick")
                .WithColumn("ItemPickId").AsInt64().PrimaryKey().Identity()
                .WithColumn("EventTime").AsDateTime()
                .WithColumn("ItemId").AsString()
                .WithColumn("Quantity").AsInt32()
                .WithColumn("AtDeviceId").AsString()
                .WithColumn("ByUserId").AsString()
                .WithColumn("CorrelationId").AsGuid();
        }
    }
}
