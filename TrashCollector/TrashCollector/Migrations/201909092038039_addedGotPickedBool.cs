namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedGotPickedBool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "gotPickedUp", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "gotPickedUp");
        }
    }
}
