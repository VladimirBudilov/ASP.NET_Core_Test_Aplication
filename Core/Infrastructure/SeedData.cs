using Core.Models;

namespace Core.Infrastructure
{
    public class SeedData
    {

        public static void SeedDatabase(DataContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var categories = new[]
            {
                new Category { Name = "Watersports"},
                new Category { Name = "Soccer"},
            };

            var products = new[]
            {
                new Product { Name = "Kayak", Category = categories[0]},
                new Product { Name = "Lifejacket", Category = categories[0]},
                new Product { Name = "Soccer Ball", Category = categories[1]},
                new Product { Name = "Corner Flags", Category = categories[1]},
            };

            context.Products.AddRange(products);
            context.Categories.AddRange(categories);
            context.SaveChanges();

        }
    }
}
