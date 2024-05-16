using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models
{
    public class SeedData
    {
        public static void EnsurePoPulated(IApplicationBuilder app)
        {
            StoreDBContext context = app.ApplicationServices
                .CreateScope().ServiceProvider 
                .GetRequiredService<StoreDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            
            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kayak",
                        Description = "A boat for one person.",
                        Category = "WaterSports",
                        Price = 499.95m
                    },
                    new Product
                    {
                        Name = "Lifejacket",
                        Description = "Protective and fasionable.",
                        Category = "WaterSports",
                        Price = 249.95m
                    },
                    new Product
                    {
                        Name = "Kayak",
                        Description = "A boat for one person.",
                        Category = "WaterSports",
                        Price = 499.95m
                    }
                    );
            }
        }
    }
}
