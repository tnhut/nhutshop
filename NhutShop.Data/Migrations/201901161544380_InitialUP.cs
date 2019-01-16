namespace NhutShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialUP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PostCategories", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PostCategories", "Status");
        }
    }
}
