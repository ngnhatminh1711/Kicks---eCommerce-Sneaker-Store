using API.Models;
using Microsoft.EntityFrameworkCore;

namespace SneakerStoreApp.API.Data
{
    public class DbInitializer
    {
        public void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<StoreContext>()
                ?? throw new InvalidOperationException("Failed to retrieve store context");

            SeedData(context);
        }

        private void SeedData(StoreContext context)
        {
            context.Database.Migrate();

            if (context.Products.Any()) return;

            // === USERS ===
            var users = new List<User>
            {
                new()
                {
                    FirstName = "Minh",
                    LastName = "Nguyễn",
                    Gender = "Nam",
                    Email = "minh@example.com",
                    PasswordHash = "hashedpassword1",
                    Role = "admin"
                },
                new ()
                {
                    FirstName = "Nhi",
                    LastName = "Phạm",
                    Gender = "Nữ",
                    Email = "nhi@example.com",
                    PasswordHash = "hashedpassword2",
                    Role = "user"
                }
            };
            context.Users.AddRange(users);

            // === CATEGORIES ===
            var categories = new List<Category>
            {
                new() { Name = "Giày thể thao", Description = "Các loại giày thể thao cho nam nữ" },
                new() { Name = "Giày da", Description = "Các loại giày da cao cấp" },
                new() { Name = "Sandal/Dép", Description = "Sandal và dép thời trang" },
                new() { Name = "Giày Sneaker", Description = "Sneaker thời trang cho giới trẻ" }
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();

            // === PRODUCRTS ===
            var products = new List<Product>
            {
                new()
                {
                    Name = "Giày Running Pro",
                    Description = "Giày chạy bộ chuyên nghiệp",
                    SKU = "SKU001",
                    BrandName = "Nike",
                    RegularPrice = 1500000,
                    SalePrice = 1200000,
                    StockQuantity = 50,
                    MainImageUrl = "/images/running-pro.jpg",
                    CategoryId = categories[0].Id
                },
                new ()
                {
                    Name = "Giày Da Công Sở",
                    Description = "Giày da dành cho dân văn phòng",
                    SKU = "SKU002",
                    BrandName = "Biti's",
                    RegularPrice = 1800000,
                    StockQuantity = 30,
                    MainImageUrl = "/images/giay-da.jpg",
                    CategoryId = categories[1].Id
                },
                new()
                {
                    Name = "Sandal Basic",
                    Description = "Sandal nhẹ cho mùa hè",
                    SKU = "SKU003",
                    BrandName = "Adidas",
                    RegularPrice = 500000,
                    SalePrice = 450000,
                    StockQuantity = 70,
                    MainImageUrl = "/images/sandal.jpg",
                    CategoryId = categories[2].Id
                },
                new()
                {
                    Name = "Sneaker Trendy",
                    Description = "Sneaker phong cách",
                    SKU = "SKU004",
                    BrandName = "Converse",
                    RegularPrice = 1200000,
                    SalePrice = 1000000,
                    StockQuantity = 40,
                    MainImageUrl = "/images/sneaker.jpg",
                    CategoryId = categories[3].Id
                }
            };
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}