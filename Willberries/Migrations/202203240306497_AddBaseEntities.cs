namespace Willberries.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBaseEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WB_Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Title = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Delegate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WB_DeliveryMethods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Method = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WB_Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Customer_Id = c.Int(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WB_Customers", t => t.Customer_Id)
                .ForeignKey("dbo.WB_Products", t => t.Product_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.WB_Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Code = c.String(),
                        Price = c.Int(nullable: false),
                        DeliveryMethod_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WB_DeliveryMethods", t => t.DeliveryMethod_Id)
                .Index(t => t.DeliveryMethod_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WB_Orders", "Product_Id", "dbo.WB_Products");
            DropForeignKey("dbo.WB_Products", "DeliveryMethod_Id", "dbo.WB_DeliveryMethods");
            DropForeignKey("dbo.WB_Orders", "Customer_Id", "dbo.WB_Customers");
            DropIndex("dbo.WB_Products", new[] { "DeliveryMethod_Id" });
            DropIndex("dbo.WB_Orders", new[] { "Product_Id" });
            DropIndex("dbo.WB_Orders", new[] { "Customer_Id" });
            DropTable("dbo.WB_Products");
            DropTable("dbo.WB_Orders");
            DropTable("dbo.WB_DeliveryMethods");
            DropTable("dbo.WB_Customers");
        }
    }
}
