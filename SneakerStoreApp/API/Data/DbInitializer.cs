using API.Models;
using Microsoft.EntityFrameworkCore;

namespace SneakerStoreApp.API.Data
{
    public class DbInitializer
    {
        public static void InitDb(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<StoreContext>()
                ?? throw new InvalidOperationException("Failed to retrieve store context");

            SeedData(context);
        }

        private static void SeedData(StoreContext context)
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

            // === PRODUCT VARIANTS ===
            var variants = new List<ProductVariant>
            {
                new ()
                {
                    ProductId = products[0].Id,
                    Color = "Đỏ",
                    Size = "40",
                    AddidtionalStock = 10
                },
                new ()
                {
                    ProductId = products[0].Id,
                    Color = "Xanh",
                    Size = "41",
                    AddidtionalStock = 5
                },
                new ()
                {
                    ProductId = products[1].Id,
                    Color = "Nâu",
                    Size = "42",
                    AddidtionalStock = 8
                },
                new ()
                {
                    ProductId = products[3].Id,
                    Color = "Trắng",
                    Size = "39",
                    AddidtionalStock = 15
                },
            };
            context.ProductVariants.AddRange(variants);

            // === PRODUCT IMAGES ===
            var images = new List<ProductImage>
            {
                new() { ProductId = products[0].Id, ImageUrl = "/images/running-pro-1.jpg" },
                new() { ProductId = products[0].Id, ImageUrl = "/images/running-pro-2.jpg" },
                new() { ProductId = products[1].Id, ImageUrl = "/images/giay-da-1.jpg" },
                new() { ProductId = products[2].Id, ImageUrl = "/images/sandal-1.jpg" },
                new() { ProductId = products[3].Id, ImageUrl = "/images/sneaker-1.jpg" }
            };
            context.ProductImages.AddRange(images);

            // === PROMO CODES ===
            var promoCodes = new List<PromoCode>
            {
                new()
                {
                    Code = "NEWUSER10",
                    Description = "Giảm 10% cho khách mới",
                    DiscountType = "Percent",
                    DiscountValue = 10,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(30),
                    MinOrderAmount = 0,
                },
                new()
                {
                    Code = "SUMMER50",
                    Description = "Giảm 50k mùa hè",
                    DiscountType = "Fixed",
                    DiscountValue = 50000,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(60),
                    MinOrderAmount = 500000,
                }
            };
            context.PromoCodes.AddRange(promoCodes);
            context.SaveChanges();

            // === ORDERS ===
            var orders = new List<Order>
            {
                new()
                {
                    UserId = users[0].Id,
                    Email = "minh@example.com",
                    FirstName = "Minh",
                    LastName = "Nguyễn",
                    PhoneNumber = "0909000001",
                    Address = "123 Đường ABC, TP.HCM",
                    Status = "Pending",
                    DeliveryFee = 30000,
                    SalesTax = 5000,
                    TotalAmount = 1205000,
                    PaymentMethod = "COD",
                    Notes = "Giao nhanh",
                    PromoCodeId = promoCodes[0].Id,
                },
                new()
                {
                    UserId = users[1].Id,
                    Email = "hoa@example.com",
                    FirstName = "Hoa",
                    LastName = "Trần",
                    PhoneNumber = "0909000002",
                    Address = "456 Đường XYZ, Hà Nội",
                    Status = "Shipping",
                    DeliveryFee = 30000,
                    SalesTax = 5000,
                    TotalAmount = 1850000,
                    PaymentMethod = "CreditCard",
                    Notes = "Liên hệ trước khi giao",
                    PromoCodeId = null,
                }
            };
            context.Orders.AddRange(orders);
            context.SaveChanges();

            // === ORDER DETAILS ===
            var orderDetails = new List<OrderDetail>
            {
                new()
                {
                    OrderId = orders[0].Id,
                    ProductId = products[0].Id,
                    VariantId = variants[0].Id,
                    Quantity = 2,
                    UnitPrice = 600000
                },
                new()
                {
                    OrderId = orders[0].Id,
                    ProductId = products[2].Id,
                    VariantId = null,
                    Quantity = 1,
                    UnitPrice = 450000
                },
                new()
                {
                    OrderId = orders[1].Id,
                    ProductId = products[1].Id,
                    VariantId = variants[2].Id,
                    Quantity = 1,
                    UnitPrice = 1800000
                }
            };
            context.OrderDetails.AddRange(orderDetails);
            context.SaveChanges();
        }
    }
}