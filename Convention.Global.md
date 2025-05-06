
# Quy Tắc Đặt Tên và Quy Ước Trong Dự Án

## 1. Đặt Tên Biến, Hàm và Enum

### Biến (Variables)
- **Tính mô tả**: Tên biến phải rõ ràng và mô tả được mục đích.
  - Ví dụ: `userService`, `productRepository`, `orderDTO`
- **Sử dụng camelCase**: Tuân thủ quy tắc camelCase.
  - Ví dụ: `customerOrderList`, `userProfile`, `totalAmount`

### Hàm (Methods)
- **Đặt tên theo hành động**: Tên hàm bắt đầu bằng động từ mô tả hành động.
  - Ví dụ: `getUserById()`, `saveProduct()`, `createOrder()`
- **Đảm bảo tính nhất quán**:
  - Ví dụ: `findById()`, `updateOrder()`, `deleteProduct()`

### Enum
- **Tính mô tả**: Tên rõ ràng, dễ hiểu.
  - Ví dụ: `OrderStatus`, `PaymentMethod`, `UserRole`
- **Giá trị enum in hoa, phân cách bằng dấu gạch dưới**:
  - Ví dụ: `PENDING`, `COMPLETED`, `CANCELLED`

#### a. Đặt tên Enum chung cho các thông báo lỗi
- Ví dụ: `INVALID_REQUEST`, `USER_NOT_FOUND`, `EMAIL_ALREADY_EXISTS`

#### b. Đặt tên Enum theo nhóm lỗi
- Chia thành nhóm như: `ValidationError`, `SystemError`, `AuthenticationError`

#### c. Sử dụng Enum trong Global Exception Handler
- Dễ dàng quản lý lỗi và hiển thị thông báo rõ ràng

---

## 2. Đặt Tên Cho Constants

- **Sử dụng in hoa, phân cách bằng dấu gạch dưới**.
  - Ví dụ: `MAX_USER_COUNT`, `DEFAULT_PAGE_SIZE`, `APP_SECRET_KEY`
- **Phân loại theo chủ đề**: `Paging`, `Status`, `Action`

---

## 3. Comment (Chú Thích Mã Nguồn)

- **Chú thích rõ ràng, đầy đủ**: Đặc biệt với hàm và khối mã phức tạp
- **Sử dụng JavaDocs cho public methods/lớp**

```java
/**
 * Lấy thông tin người dùng theo ID
 * @param userId ID của người dùng
 * @return Thông tin người dùng
 */
public User getUserById(Long userId) {
    // logic
}
```

- **Giải thích các quyết định thiết kế hoặc xử lý đặc biệt**

---

## 4. Đặt Tên Cho Git và Cấu Trúc Thư Mục

- **Tên repo**: `user-service`, `order-service`, `payment-service`
- **Cấu trúc nhánh**:
  - `main`/`master`: Bản phát hành ổn định
  - `feature/<ten-tinh-nang>`
  - `bugfix/<issue-name>`
  - `release/v1.0`

---

## 5. Đặt Tên Cho RESTful API

### Cấu trúc URL
- Danh từ số nhiều cho danh sách: `/users`
- Danh từ số ít cho đơn lẻ: `/user/{id}`

### Phương thức HTTP
- `GET /users`, `GET /user/{id}`
- `POST /users`
- `PUT /user/{id}`
- `PATCH /user/{id}`
- `DELETE /user/{id}`

### Quy tắc bổ sung
- Dùng `/` (slash), không dùng `_` (underscore)
- Tránh dùng động từ trong URL (đã thể hiện qua HTTP verb)
- Dùng query params để tìm kiếm, phân trang:
  - `/users?page=1&size=10&sort=asc`

---

## 6. Đặt Tên Cho Model (Lớp Mô Hình Dữ Liệu)

- **Dùng danh từ rõ ràng**: `User`, `Order`, `Product`
- **Model con mô tả cụ thể**: `OrderItem`, `ProductCategory`
- **Không dùng tên chung chung**: Tránh `Entity`, `Data`
- **Trường dùng camelCase**: `firstName`, `orderDate`
- **Trường thời gian**: `createdAt`, `updatedAt`, `orderDate`

---

## 7. Đặt Tên Cho DTO (Data Transfer Object)

- **Thêm hậu tố `DTO`**: `UserDTO`, `OrderDTO`
- **Chỉ chứa dữ liệu cần thiết**: tránh truyền dữ liệu không cần thiết

---

## 8. Ví Dụ Tổng Hợp

- **API**: `/users/{id}`
- **Model**: `User`
- **DTO**: `UserDTO`

---

## 9. Không Hardcode

- Dùng enum hoặc constants để tránh hardcode giá trị

---

## 10. FE Không Viết Inline Style

- Viết CSS vào class, không dùng trực tiếp trong HTML

---

## 11. Sử Dụng i18n

- Dùng i18n để hỗ trợ đa ngôn ngữ cho ứng dụng

---

## 12. Base Model Cho Các Trường Dùng Chung

- Các trường như:
  - `created_at`, `deleted_at`, `updated_at`
  - `is_status`, `created_by`, `changed_by`
- Viết vào file base, các model kế thừa
