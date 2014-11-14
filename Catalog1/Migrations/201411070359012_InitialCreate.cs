namespace Catalog1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        CartItemID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cart_CartID = c.Int(),
                    })
                .PrimaryKey(t => t.CartItemID)
                .ForeignKey("dbo.Carts", t => t.Cart_CartID)
                .Index(t => t.Cart_CartID);
            
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.CartID);
            
            CreateTable(
                "dbo.ProductReviews",
                c => new
                    {
                        ProductReviewID = c.Int(nullable: false, identity: true),
                        IsApproved = c.Boolean(nullable: false),
                        Title = c.String(),
                        ReviewText = c.String(),
                        Rating = c.Int(),
                        TimeStamp = c.DateTime(nullable: false),
                        Product_ProductID = c.Int(),
                    })
                .PrimaryKey(t => t.ProductReviewID)
                .ForeignKey("dbo.Products", t => t.Product_ProductID)
                .Index(t => t.Product_ProductID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(nullable: false),
                        OrderMaximumQuantity = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        ImageSmall = c.String(),
                        ImageLarge = c.String(),
                        PriceModifier = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductReviews", "Product_ProductID", "dbo.Products");
            DropForeignKey("dbo.CartItems", "Cart_CartID", "dbo.Carts");
            DropIndex("dbo.ProductReviews", new[] { "Product_ProductID" });
            DropIndex("dbo.CartItems", new[] { "Cart_CartID" });
            DropTable("dbo.Products");
            DropTable("dbo.ProductReviews");
            DropTable("dbo.Carts");
            DropTable("dbo.CartItems");
        }
    }
}
