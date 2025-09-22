USE sneaker_store
GO
/* ============= SEED DATA ============= */

/* USERS */
INSERT INTO Users (FirstName, LastName, Gender, Email, PasswordHash, Role)
VALUES
(N'Minh', N'Nguyễn', N'Nam', N'minh@example.com', N'hashedpassword1', N'admin'),
(N'Hoa', N'Trần', N'Nữ', N'hoa@example.com', N'hashedpassword2', N'user');
GO

/* CATEGORIES */
INSERT INTO Categories (Name, Description)
VALUES 
(N'Giày Thể Thao', N'Các loại giày thể thao cho nam nữ'),
(N'Giày Da', N'Các loại giày da cao cấp'),
(N'Sandal/Dép', N'Sandal và dép thời trang'),
(N'Giày Sneaker', N'Sneaker thời trang cho giới trẻ');
GO

/* PRODUCTS */
INSERT INTO Products (Name, Description, SKU, BrandName, RegularPrice, SalePrice, StockQuantity, MainImageUrl, CategoryId)
VALUES
(N'Giày Running Pro', N'Giày chạy bộ chuyên nghiệp', N'SKU001', N'Nike', 1500000, 1200000, 50, N'/images/running-pro.jpg', 1),
(N'Giày Da Công Sở', N'Giày da dành cho dân văn phòng', N'SKU002', N'Biti''s', 1800000, NULL, 30, N'/images/giay-da.jpg', 2),
(N'Sandal Basic', N'Sandal nhẹ cho mùa hè', N'SKU003', N'Adidas', 500000, 450000, 70, N'/images/sandal.jpg', 3),
(N'Sneaker Trendy', N'Sneaker phong cách', N'SKU004', N'Converse', 1200000, 1000000, 40, N'/images/sneaker.jpg', 4);
GO

/* PRODUCT VARIANTS */
INSERT INTO ProductVariants (ProductId, Color, Size, AdditionalStock)
VALUES
(1, N'Đỏ', N'40', 10),
(1, N'Xanh', N'41', 5),
(2, N'Nâu', N'42', 8),
(4, N'Trắng', N'39', 15);
GO

/* PRODUCT IMAGES */
INSERT INTO ProductImages (ProductId, ImageUrl)
VALUES
(1, N'/images/running-pro-1.jpg'),
(1, N'/images/running-pro-2.jpg'),
(2, N'/images/giay-da-1.jpg'),
(3, N'/images/sandal-1.jpg'),
(4, N'/images/sneaker-1.jpg');
GO

/* PROMO CODES */
INSERT INTO PromoCodes (Code, Description, DiscountType, DiscountValue, StartDate, EndDate, MinOrderAmount)
VALUES
(N'NEWUSER10', N'Giảm 10% cho khách mới', N'Percent', 10, GETDATE(), DATEADD(DAY, 30, GETDATE()), 0),
(N'SUMMER50', N'Giảm 50K mùa hè', N'Fixed', 50000, GETDATE(), DATEADD(DAY, 60, GETDATE()), 500000);
GO

/* ORDERS */
INSERT INTO Orders (UserId, Email, FirstName, LastName, PhoneNumber, Address, Status, DeliveryFee, SalesTax, TotalAmount, PaymentMethod, Notes, PromoCodeId)
VALUES
(1, N'minh@example.com', N'Minh', N'Nguyễn', N'0909000001', N'123 Đường ABC, TP.HCM', N'Pending', 30000, 5000, 1205000, N'COD', N'Giao nhanh', 1),
(2, N'hoa@example.com', N'Hoa', N'Trần', N'0909000002', N'456 Đường XYZ, Hà Nội', N'Shipping', 30000, 5000, 1850000, N'CreditCard', N'Liên hệ trước khi giao', NULL);
GO

/* ORDER DETAILS */
INSERT INTO OrderDetails (OrderId, ProductId, VariantId, Quantity, UnitPrice)
VALUES
(1, 1, 1, 2, 600000),
(1, 3, NULL, 1, 450000),
(2, 2, 3, 1, 1800000);
GO
