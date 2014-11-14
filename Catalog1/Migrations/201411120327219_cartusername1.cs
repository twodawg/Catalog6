namespace Catalog1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cartusername1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Carts", "UserName", c => c.String());
            AddColumn("dbo.Carts", "IsFulfilled", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Carts", "IsFulfilled");
            DropColumn("dbo.Carts", "UserName");
        }
    }
}
