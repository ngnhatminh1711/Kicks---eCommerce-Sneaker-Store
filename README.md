# Kicks - eCommerce Sneaker Store Management (ASP.NET Core + ReactJS)

Dự án cá nhân quản lý cửa hàng bán giày, xây dựng theo mô hình E-commerce.  
Mục tiêu: thể hiện khả năng thiết kế backend ASP.NET Core + frontend ReactJS, cùng thiết kế CSDL quan hệ đầy đủ.

---

## 🚀 Công nghệ sử dụng

- **Backend**: ASP.NET Core Web API (.NET 7+)
- **Frontend**: ReactJS + TailwindCSS/Bootstrap
- **CSDL**: Microsoft SQL Server
- **Authentication**: JWT
- **Khác**: EF Core, Swagger, Axios

---

## 🗄️ Cấu trúc cơ sở dữ liệu

| Bảng             | Mô tả                                                                |
|-----------------|---------------------------------------------------------------------|
| **Categories**  | Nhóm sản phẩm (Sneakers, Boots…)                                     |
| **Products**    | Sản phẩm (giày)                                                      |
| **ProductVariants** | Biến thể sản phẩm theo màu / size                                  |
| **ProductImages** | Hình ảnh sản phẩm                                                  |
| **Users**       | Người dùng đã đăng ký                                               |
| **PromoCodes**  | Mã khuyến mãi, giảm giá                                              |
| **Orders**      | Đơn hàng                                                            |
| **OrderDetails**| Chi tiết từng sản phẩm trong đơn hàng                                |

**Quan hệ chính:**

- `Products` thuộc về `Categories`
- `Products` có nhiều `ProductVariants` và `ProductImages`
- `Users` có nhiều `Orders`
- `Orders` có thể có `PromoCode`
- `Orders` chứa nhiều `OrderDetails`

---

## 📂 File SQL

- **schema.sql**: Tạo toàn bộ bảng CSDL.  
- **seed.sql**: Sinh dữ liệu mẫu (categories, users, products, variants, images, promo codes, orders, order details).

---

## ⚙️ Cài đặt & Khởi chạy

1. **Chạy script schema.sql** để tạo bảng:

   ```sql
   -- mở schema.sql và chạy toàn bộ
   ```

2. **Chạy script seed.sql** để insert dữ liệu mẫu:

   ```sql
   -- mở seed.sql và chạy toàn bộ
   ```

3. Cấu hình chuỗi kết nối trong `appsettings.json` (ASP.NET Core):

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=sneaker_store;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

4. Chạy API ASP.NET Core và frontend ReactJS.

---

## 📝 Các tính năng dự kiến

* CRUD sản phẩm, danh mục, người dùng.
* Hiển thị danh sách sản phẩm, chi tiết sản phẩm.
* Chọn màu, size (biến thể).
* Giỏ hàng, checkout, áp dụng promo code.
* Quản lý đơn hàng cho admin.
* Authentication + Authorization.

---

## 📄 Ghi chú

* Các mật khẩu hiện tại là chuỗi giả `hashedpwd` → thay bằng hash thực tế khi triển khai.
* Promo code có ngày hết hạn (ExpiryDate).

---

## 👤 Tác giả

Nguyễn Nhật Minh – Dự án cá nhân showcase kỹ năng ASP.NET Core + ReactJS.

```
