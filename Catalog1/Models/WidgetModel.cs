namespace Catalog1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class WidgetModel : DbContext
    {
        public WidgetModel()
            : base("name=WidgetModel")
        {
            //Database.SetInitializer<WidgetModel>(
            //    new DropCreateDatabaseAlways<WidgetModel>()
            //    );

            //Seed();
        }

        private void Seed()
        {
#if DEBUG
            Database.ExecuteSqlCommand("TRUNCATE TABLE [ProductReviews]");
            Database.ExecuteSqlCommand("DELETE FROM Products");
            Database.ExecuteSqlCommand("DELETE FROM CartItems");

            var products = new List<Product>()
            {
                {new Product(){
                    Name = "Widget", Quantity=10, Price = 2.50m, 
                    Description = "Normal everyday widget",
                    ImageLarge="http://placehold.it/800x300",
                    ImageSmall="http://placehold.it/320x150"
                }},
                {new Product(){
                    Name = "SuperWidget", Quantity=20, Price = 12.99m, 
                    Description = "A better widget",
                    ImageLarge="http://placehold.it/800x300",
                    ImageSmall="http://placehold.it/320x150"
                }},
                {new Product(){
                    Name = "MegaWidget", Quantity=25, Price = 79.99m, 
                    Description = "Mega super better widget",
                    ImageLarge="http://placehold.it/800x300",
                    ImageSmall="http://placehold.it/320x150"
                }},
                {new Product(){
                    Name = "iWidget", Quantity=18, Price = 101.99m, 
                    Description = "An Apple widget with twice the goodness",
                    ImageLarge="http://placehold.it/800x300",
                    ImageSmall="http://placehold.it/320x150"
                }},
                {new Product(){
                    Name = "WidgetKitchen", Quantity=4, Price = 10.98m, 
                    Description = "Get the kitchen widget now",
                    ImageLarge="http://placehold.it/800x300",
                    ImageSmall="http://placehold.it/320x150"
                }},
            };

            foreach(Product productItem in products)
            {
                productItem.Reviews = new List<ProductReview>();

                productItem.Reviews.Add(new ProductReview()
                    {
                        ProductReviewID = productItem.ProductID,
                        Rating = 4,
                        IsApproved = true,
                        TimeStamp = DateTime.Now,
                        ReviewText = "It was ALRIGHT...",
                        Title = "Ho Hum"
                    });
            }


            Products.AddRange(products);

            SaveChanges();
#else
            
#endif
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartItem> CartItems { get; set; }
        public virtual DbSet<ProductReview> ProductReviews { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
    }
}