using System; // Khai báo thư viện .NET được dùng trong file.
using System.Collections.Generic; // Khai báo thư viện .NET được dùng trong file.
using System.Linq; // Khai báo thư viện .NET được dùng trong file.
using System.Text; // Khai báo thư viện .NET được dùng trong file.
using System.Threading.Tasks; // Khai báo thư viện .NET được dùng trong file.

namespace CTDL_GT_thuat_toan // Namespace chung chứa lớp bài tập.
{
    /*
====================================================================
MỤC LỤC: CẤU TRÚC DỮ LIỆU VÀ GIẢI THUẬT - TỔNG HỢP BÀI GIẢNG
====================================================================

Giới thiệu học phần (Trang 1)

0. Ôn tập kiến thức cơ bản (Trang 2)
0.1. Biến con trỏ (Trang 2)
0.2. Truyền tham trị, tham chiếu (Trang 3)
0.3. Mảng (Trang 4)
0.4. Struct & Class (Trang 6)
0.5. Đệ quy (Trang 9)

1. Thuật toán và đánh giá độ phức tạp (Trang 16)
1.1. Giới thiệu thuật toán (Trang 16)
1.2. Phương pháp biểu diễn thuật toán (Trang 19)
1.3. Độ phức tạp thuật toán (Trang 22)

2. Các thuật toán tìm kiếm và sắp xếp (Trang 36)
2.1. Các thuật toán tìm kiếm (Trang 36)
    2.1.1. Giới thiệu bài toán tìm kiếm (Trang 36)
    2.1.2. Tìm kiếm tuyến tính (Trang 36)
    2.1.3. Tìm kiếm nhị phân (Trang 38)
    2.1.4. Tìm kiếm nội suy (Trang 40)
2.2. Các thuật toán sắp xếp cơ bản (Trang 43)
    2.2.1. Giới thiệu bài toán sắp xếp (Trang 43)
    2.2.2. Sắp xếp chọn trực tiếp (Trang 43)
    2.2.3. Sắp xếp chèn trực tiếp (Trang 45)
    2.2.4. Sắp xếp đổi chỗ trực tiếp (Trang 47)
    2.2.5. Sắp xếp nổi bọt (Trang 49)
    2.2.6. Sắp xếp rung lắc (Trang 54)
    2.2.7. Sắp xếp dựa trên cơ số (Trang 57)
2.3. QuickSort (Trang 60)
    2.3.1. Giới thiệu kỹ thuật Chia để trị (Trang 60)
    2.3.2. Giải thuật sắp xếp nhanh (Quick Sort) (Trang 60)
2.4. MergeSort (Trang 66)
    2.4.1. Thuật toán sắp xếp trộn (MergeSort) (Trang 66)
    2.4.2. Đánh giá độ phức tạp (Trang 69)
2.5. HeapSort (Trang 70)
    2.5.1. Các khái niệm cơ bản (Trang 70)
    2.5.2. Một số tính chất của Heap (Trang 71)
    2.5.3. Giới thiệu HeapSort (Trang 72)
    2.5.4. Đánh giá độ phức tạp thuật toán (Trang 74)

3. Danh sách liên kết và Skip List (Trang 76)
3.1. Danh sách liên kết (Trang 76)
    3.1.1. Giới thiệu cấu trúc dữ liệu động (Trang 76)
    3.1.2. Giới thiệu danh sách liên kết (Trang 76)
    3.1.3. Các thao tác với danh sách liên kết đơn (Trang 79)
3.2. Sắp xếp trên danh sách liên kết (Trang 93)
    3.2.1. Giới thiệu bài toán sắp xếp trên danh sách liên kết (Trang 93)
    3.2.2. Phương pháp hoán vị thành phần dữ liệu (Trang 93)
    3.2.3. Phương pháp thay đổi thành phần liên kết (Trang 96)
3.3. Skip List (Trang 101)
    3.3.1. Giới thiệu Skip List (Trang 101)
    3.3.2. Các thao tác cơ bản (Trang 103)
    3.3.3. Đánh giá và ứng dụng (Trang 106)

4. Ngăn xếp và hàng đợi (Trang 109)
4.1. Ngăn xếp (Stack) (Trang 109)
    4.1.1. Giới thiệu ngăn xếp (Trang 109)
    4.1.2. Cài đặt ngăn xếp (Trang 110)
    4.1.3. Ứng dụng của ngăn xếp (Trang 115)
4.2. Hàng đợi (Queue) (Trang 123)
    4.2.1. Giới thiệu hàng đợi (Trang 123)
    4.2.2. Cài đặt hàng đợi (Trang 124)
    4.2.3. Ứng dụng của hàng đợi (Trang 129)

5. Cây và cây nhị phân tìm kiếm (Trang 131)
5.1. Cấu trúc cây (Trang 131)
    5.1.1. Giới thiệu cấu trúc cây (Trang 131)
    5.1.2. Các thao tác trên cây nhị phân (Trang 137)
5.2. Cây nhị phân tìm kiếm (Trang 141)
    5.2.1. Giới thiệu cây nhị phân tìm kiếm (Trang 141)
    5.2.2. Các thao tác trong cây NPTK (Trang 141)

6. Bảng băm (Trang 150)
6.1. Giới thiệu bảng băm (Trang 150)
6.2. Một số phương pháp xây dựng hàm băm (Trang 151)
6.3. Các thao tác và hệ số tải (Trang 152)
6.4. Các phương pháp xử lý đụng độ (Trang 153)
    6.4.1. Nối kết trực tiếp (Trang 153)
    6.4.2. Địa chỉ mở (Trang 153)
    6.4.3. Dò tuyến tính (Trang 154)
    6.4.4. Dò bậc hai (Trang 156)
    6.4.5. Băm kép (Trang 157)
6.5. Xóa phần tử và mở rộng bảng (Trang 159)
6.6. Độ phức tạp (Trang 160)

7. Hàng đợi ưu tiên (Trang 162)
7.1. Giới thiệu hàng đợi ưu tiên (Trang 162)
7.2. Cài đặt bằng Binary Heap (Trang 163)
    7.2.1. Thao tác Insert (Trang 164)
    7.2.2. Thao tác GetMax (Trang 165)
    7.2.3. Thao tác ExtractMax (Trang 166)
7.3. Cài đặt Priority Queue (Trang 167)
7.4. Max-Priority Queue và Min-Priority Queue (Trang 170)
7.5. Đánh giá độ phức tạp (Trang 170)
7.6. Ứng dụng (Trang 171)

Tài liệu tham khảo (Trang 173)
====================================================================
*/

    internal class BaiTap // Lớp cung cấp chức năng in mục lục môn học.
    {
        public void InMucluc() // In các dòng mục lục đã khai báo bên dưới.
        {
            string[] mucLuc = new string[] // Tạo danh sách các dòng văn bản của mục lục.
      {
            "==========================================================================",
            "MỤC LỤC: CẤU TRÚC DỮ LIỆU VÀ GIẢI THUẬT - TỔNG HỢP BÀI GIẢNG",
            "==========================================================================",
            "Giới thiệu học phần ................................................. 1",
            "",
            "0. Ôn tập kiến thức cơ bản .......................................... 2",
            "   0.1. Biến con trỏ ................................................ 2",
            "   0.2. Truyền tham trị, tham chiếu ................................. 3",
            "   0.3. Mảng ........................................................ 4",
            "   0.4. Struct & Class .............................................. 6",
            "   0.5. Đệ quy ...................................................... 9",
            "",
            "1. Thuật toán và đánh giá độ phức tạp ............................... 16",
            "   1.1. Giới thiệu thuật toán ....................................... 16",
            "   1.2. Phương pháp biểu diễn thuật toán ............................ 19",
            "   1.3. Độ phức tạp thuật toán ...................................... 22",
            "",
            "2. Các thuật toán tìm kiếm và sắp xếp ............................... 36",
            "   2.1. Các thuật toán tìm kiếm ..................................... 36",
            "        2.1.1. Giới thiệu bài toán tìm kiếm ......................... 36",
            "        2.1.2. Tìm kiếm tuyến tính .................................. 36",
            "        2.1.3. Tìm kiếm nhị phân .................................... 38",
            "        2.1.4. Tìm kiếm nội suy ..................................... 40",
            "   2.2. Các thuật toán sắp xếp cơ bản ............................... 43",
            "        2.2.1. Giới thiệu bài toán sắp xếp .......................... 43",
            "        2.2.2. Sắp xếp chọn trực tiếp ............................... 43",
            "        2.2.3. Sắp xếp chèn trực tiếp ............................... 45",
            "        2.2.4. Sắp xếp đổi chỗ trực tiếp ............................ 47",
            "        2.2.5. Sắp xếp nổi bọt ...................................... 49",
            "        2.2.6. Sắp xếp rung lắc ..................................... 54",
            "        2.2.7. Sắp xếp dựa trên cơ số ............................... 57",
            "   2.3. QuickSort ................................................... 60",
            "        2.3.1. Giới thiệu kỹ thuật Chia để trị ...................... 60",
            "        2.3.2. Giải thuật sắp xếp nhanh (Quick Sort) ................ 60",
            "   2.4. MergeSort ................................................... 66",
            "        2.4.1. Thuật toán sắp xếp trộn (MergeSort) .................. 66",
            "        2.4.2. Đánh giá độ phức tạp ................................. 69",
            "   2.5. HeapSort .................................................... 70",
            "        2.5.1. Các khái niệm cơ bản ................................. 70",
            "        2.5.2. Một số tính chất của Heap ............................ 71",
            "        2.5.3. Giới thiệu HeapSort .................................. 72",
            "        2.5.4. Đánh giá độ phức tạp thuật toán ...................... 74",
            "",
            "3. Danh sách liên kết và Skip List .................................. 76",
            "   3.1. Danh sách liên kết .......................................... 76",
            "        3.1.1. Giới thiệu cấu trúc dữ liệu động ..................... 76",
            "        3.1.2. Giới thiệu danh sách liên kết ........................ 76",
            "        3.1.3. Các thao tác với danh sách liên kết đơn .............. 79",
            "   3.2. Sắp xếp trên danh sách liên kết ............................. 93",
            "        3.2.1. Giới thiệu bài toán sắp xếp trên danh sách liên kết .. 93",
            "        3.2.2. Phương pháp hoán vị thành phần dữ liệu ............... 93",
            "        3.2.3. Phương pháp thay đổi thành phần liên kết ............. 96",
            "   3.3. Skip List ................................................... 101",
            "        3.3.1. Giới thiệu Skip List ................................. 101",
            "        3.3.2. Các thao tác cơ bản .................................. 103",
            "        3.3.3. Đánh giá và ứng dụng ................................. 106",
            "",
            "4. Ngăn xếp và hàng đợi ............................................. 109",
            "   4.1. Ngăn xếp (Stack) ............................................ 109",
            "        4.1.1. Giới thiệu ngăn xếp .................................. 109",
            "        4.1.2. Cài đặt ngăn xếp ..................................... 110",
            "        4.1.3. Ứng dụng của ngăn xếp ................................ 115",
            "   4.2. Hàng đợi (Queue) ............................................ 123",
            "        4.2.1. Giới thiệu hàng đợi .................................. 123",
            "        4.2.2. Cài đặt hàng đợi ..................................... 124",
            "        4.2.3. Ứng dụng của hàng đợi ................................ 129",
            "",
            "5. Cây và cây nhị phân tìm kiếm ..................................... 131",
            "   5.1. Cấu trúc cây ................................................ 131",
            "        5.1.1. Giới thiệu cấu trúc cây .............................. 131",
            "        5.1.2. Các thao tác trên cây nhị phân ....................... 137",
            "   5.2. Cây nhị phân tìm kiếm ....................................... 141",
            "        5.2.1. Giới thiệu cây nhị phân tìm kiếm ..................... 141",
            "        5.2.2. Các thao tác trong cây NPTK .......................... 141",
            "",
            "6. Bảng băm ......................................................... 150",
            "   6.1. Giới thiệu bảng băm ......................................... 150",
            "   6.2. Một số phương pháp xây dựng hàm băm ......................... 151",
            "   6.3. Các thao tác và hệ số tải ................................... 152",
            "   6.4. Các phương pháp xử lý đụng độ ............................... 153",
            "        6.4.1. Nối kết trực tiếp .................................... 153",
            "        6.4.2. Địa chỉ mở ........................................... 153",
            "        6.4.3. Dò tuyến tính ........................................ 154",
            "        6.4.4. Dò bậc hai ........................................... 156",
            "        6.4.5. Băm kép .............................................. 157",
            "   6.5. Xóa phần tử và mở rộng bảng ................................. 159",
            "   6.6. Độ phức tạp ................................................. 160",
            "",
            "7. Hàng đợi ưu tiên ................................................. 162",
            "   7.1. Giới thiệu hàng đợi ưu tiên ................................. 162",
            "   7.2. Cài đặt bằng Binary Heap .................................... 163",
            "        7.2.1. Thao tác Insert ...................................... 164",
            "        7.2.2. Thao tác GetMax ...................................... 165",
            "        7.2.3. Thao tác ExtractMax .................................. 166",
            "   7.3. Cài đặt Priority Queue ...................................... 167",
            "   7.4. Max-Priority Queue và Min-Priority Queue .................... 170",
            "   7.5. Đánh giá độ phức tạp ........................................ 170",
            "   7.6. Ứng dụng .................................................... 171",
            "",
            "Tài liệu tham khảo .................................................. 173",
            "=========================================================================="
      };

            foreach (string dong in mucLuc) // Duyệt lần lượt từng dòng theo đúng thứ tự trong mảng.
            {
                Console.WriteLine(dong); // Hiển thị dòng hiện tại và xuống dòng.
            }
        }
    }
}
