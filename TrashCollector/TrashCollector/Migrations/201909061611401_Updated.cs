namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "oneTimePickUp", c => c.String());
            AddColumn("dbo.Customers", "amountOwed", c => c.Double(nullable: false));
            AddColumn("dbo.Customers", "startAndEndDateForSuspendDate", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "startAndEndDateForSuspendDate");
            DropColumn("dbo.Customers", "amountOwed");
            DropColumn("dbo.Customers", "oneTimePickUp");
        }
    }
}
