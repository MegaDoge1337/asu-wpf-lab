namespace Willberries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeliveryMethodChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WB_DeliveryMethods", "Amount", c => c.Int(nullable: false));
            AlterColumn("dbo.WB_DeliveryMethods", "Method", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WB_DeliveryMethods", "Method", c => c.Int(nullable: false));
            DropColumn("dbo.WB_DeliveryMethods", "Amount");
        }
    }
}
