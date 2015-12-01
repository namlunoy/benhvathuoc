For the Windows Phone toolkit make sure that you have
marked the icons in the "Toolkit.Content" folder as content.  That way they 
can be used as the icons for the ApplicationBar control.
//==================================================

1. Bảo hoàng anh đọc cách hướng dẫn settup trước khi chạy project ở trên github


2. Cách sử dụng một số code đã có sắn

a. Cách quyery từ database:
MyDB.Instance.Conn.Query<NhomBenh>("select * from benh_category");

b. Load dữ liệu có thể để vào hàm tạo hoặc đệ vào trong sự kiện loaded của page
  Loaded += TraCuuBenh_Loaded;

c. Cách chuyển trang
  MainPage.Current.ShowChildViewNext(this, new PageChiTietBenh());	
