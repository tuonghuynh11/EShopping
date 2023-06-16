# EShopping
 
# ShopGo

Ứng dụng mua sắm trực tuyến.

## 1. Mô tả 

Hiện nay việc mua sắm là một nhu cầu cần thiết của mỗi người. Tuy nhiên, việc đến trực tiếp một cửa hàng để lựa chọn sẽ làm mất nhiều thời gian, công sức và chưa chắc sẽ lựa chọn được món đồ mình muốn. Vì vậy, ứng dụng ShopGo ra đời giúp cho người dùng có thể lựa chọn sản phẩm một cách dễ dàng hơn và tiết kiệm được thời gian cũng như công sức. Đồng thời, ứng dụng này cũng giúp cho chủ cửa hàng có thể đưa sản phẩm của mình tiếp cận đến với nhiều khách hàng hơn và giúp tăng doanh thu cho cửa hàng.

### 2. Mục đích, yêu cầu, người dùng hướng tới của đề tài

#### Mục đích

* Phần mềm được tạo ra nhằm mục đích giúp người dụng dễ dàng mua sắm trực tuyến.
* Phần mềm được tạo ra nhằm mục đích giúp chủ cửa hàng dễ dàng tiếp cận với nhiều khách hàng, giúp tăng doanh thu cho cửa hàng.
* Hỗ trợ cửa hàng cập nhật các mặt hàng và quản lý doanh thu. 

#### Yêu cầu

* UI/UX hợp lý, rõ ràng, thuận tiện cho người sử dụng. 

* Ứng dụng có những tính năng cơ bản. 

* Phân chia quyền hạn rõ ràng. 

#### Người dùng

* Quản lý của cửa hàng.

* Nhân viên của cửa hàng.

* Khách hàng.

### 3. Tổng quan sản phẩm

#### 3.1 Chức năng
<details>
  <summary>Chức năng chung </summary>
 
- Đăng nhập
- Đăng xuất
- Quên mật khẩu
- Chỉnh sửa thông tin cá nhân
- Đổi mật khẩu
- Xem sản phẩm
- Thêm sản phẩm vào giỏ hàng
- Thanh toán
- Gửi feedback

</details>

  ###### Admin (Chủ cửa hàng)

  <details>
    <summary>Quản lý toàn bộ danh sách các mặt hàng </summary>

  - Thêm sản phẩm
  - Xem tổng hợp các sản phẩm (có thể lọc và sắp xếp)
  - Xóa sản phẩm
  - Xem chi tiết sản phẩm
  - Sửa thông tin sản phẩm
  - Xem thống kê
  - Xác nhận đơn hàng
  - Xác nhận đơn hàng hoàn thành

  </details>

  <details>
    <summary>Quản lý toàn bộ danh sách các tài khoản </summary>

  - Xem các tài khoản người dùng
  - Xem chi tiết thông tin người dùng
  - Phân quyền cho người dùng
  - Ban người dùng
  - Unban người dùng

  </details>

  ###### Assistant (Nhân viên cửa hàng)

  <details>
    <summary>Tài khoản </summary>
 
  - Đăng kí
 
  </details>
  <details>
   <summary>Hỗ trợ khách hàng </summary>
 
  - Trò chuyện với khách hàng
 
  </details>
  
  <details>
    <summary>Xem sản phẩm </summary>

  - Tìm kiếm sản phẩm
  - Sắp xếp thứ tự sản phẩm
  - Xem chi tiết sản phẩm
  - Thêm sản phẩm vào giỏ hàng
  - Mua sản phẩm
  - Thanh toán sản phẩm

  </details>

  ###### Customer (Khách hàng)
<details>
     <summary>Tài khoản </summary>
 
  - Đăng kí
 </details>
 <details>
   <summary>Xem sản phẩm </summary>

  - Tìm kiếm sản phẩm
  - Sắp xếp thứ tự sản phẩm
  - Xem chi tiết sản phẩm
  - Thêm sản phẩm vào giỏ hàng
  - Mua sản phẩm
  - Thanh toán sản phẩm
</details>
<details>
    <summary>Trò chuyện với shop </summary>

  - Nhắn tin cho shop
 
  </details>

#### 3.2 Công nghệ sử dụng

- Công cụ: Visual Studio, SQL Server Management Studio, Github Desktop, Microsoft SQL Server.
- Ngôn ngữ lập trình: C#, TSQL.
- Thư viện: .NET Framework, MaterialDesignXAML, Show Me The XAML, Entity Framework, Devexpress Framework, WPF.

## 4. Hướng dẫn cài đặt
<details>
    <summary>Đối với người dùng</summary>

  * Liên hệ với nhà phát triển để được hỗ trợ khởi tạo cơ sở dữ liệu và kết nối đến cơ sở dữ liệu.
  * Giải nén và chạy file 
    * Dowload phần mềm tại:
      [ShopGo](https://uithcm-my.sharepoint.com/:f:/g/personal/21520123_ms_uit_edu_vn/ErFwwdW_IcZNmuSio4aQqWkBoOotKqS4OcqN8S0C3UiPHg?e=s4bqHP)

</details>

<details>
    <summary>Đối với nhà phát triển</summary>

  * Dowload, giải nén phần mềm
    * Github: https://github.com/tuonghuynh11/EShopping.git
    * Google Drive:
      [ShopGo](https://uithcm-my.sharepoint.com/:u:/g/personal/21520123_ms_uit_edu_vn/EWnqN6RXCRBMjfKTI0c3fUwB50ufChzYFMV47c4J5r_-mg?e=M8XUF6)
  * Cài đặt database
    * Khuyến nghị sử dụng các dịch vụ đám mây như Azure, AWS,… để sử dụng tất cả tính năng hiện có của chương trình  (server đi kèm với chương trình đã đóng).
    * Ngoài ra có thể sử dụng SQL Server (Lưu ý: cách này sẽ mất đi tính năng tương tác giữa các user ở các máy tính khác nhau).
  * Khởi tạo Database bằng cách chạy script chứa trong file Seed.sql
    * Tải file script tại:
      [ShopGo](https://uithcm-my.sharepoint.com/:f:/g/personal/21520123_ms_uit_edu_vn/Eg6Me6flEfROpg5qG9i2kqMBj8JV_MHF4yOC0_wDNNuwNQ?e=Up4W3p)
  * Kết nối với Database vừa tạo bằng cách thay đổi connectionStrings trong file App.config.
  * Đăng nhập với vai trò admin
      * tên đăng nhập: admin
      * mật khẩu: 1234
  * LƯU Ý: Cần phải cài DevExpress để có thể chạy được chương trình.

</details>

## 5. Hướng dẫn sử dụng

* Video demo: 

## 6. Tác giả

| STT | MSSV     | Họ và tên                                                  | Lớp      | 
| --- | -------- | ---------------------------------------------------------- | -------- | 
| 1   | 21520123| [Huỳnh Mạnh Tường](https://github.com/tuonghuynh11)           | KTPM2021 | 
| 2   | 21520341| [Dương Ngọc Mẫn](https://github.com/DNM03)              | KTPM2021 | 
| 3   | 21520613| [Nguyễn Hoàng Quốc Bảo](https://github.com/QuocBaoKho) | KTPM2021 | 
| 4   | 21520169 | [Nguyễn Thái Công](https://github.com/thai-cong-nguyen)         	  | KTPM2021 | 
* Sinh viên khoa Công nghệ Phần mềm, trường Đại học Công nghệ Thông tin, Đại học Quốc gia thành phố Hồ Chí Minh.

## 7. Giảng viên hướng dẫn

* Cô Nguyễn Thị Thanh Trúc, giảng viên Khoa Công Nghệ Phần Mềm, trường Đại học Công nghệ Thông tin, Đại học Quốc gia Thành phố Hồ Chí Minh.
