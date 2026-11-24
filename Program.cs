using System; // Dùng Console và phương thức chuyển đổi chuỗi sang số.

namespace CTDL_GT_thuat_toan // Namespace chung với các lớp thuật toán.
{
    internal class Program // Lớp chứa điểm bắt đầu của ứng dụng console.
    {
        private static void Main(string[] args) // Hàm Main được chạy đầu tiên khi mở chương trình.
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Bật mã hóa UTF-8 để hiển thị tiếng Việt.
            Console.InputEncoding = System.Text.Encoding.UTF8; // Bật mã hóa UTF-8 khi đọc ký tự nhập vào.
            Console.Write("Nhập số phần tử N (0 trở lên): "); // Yêu cầu người dùng nhập số lượng phần tử.
            int n; // Biến lưu số lượng phần tử.
            while (!int.TryParse(Console.ReadLine(), out n) || n < 0) // Lặp đến khi nhập được số nguyên không âm.
                Console.Write("Vui lòng nhập số nguyên không âm: "); // Báo cách nhập hợp lệ khi dữ liệu sai.

            int[] A = new int[n]; // Cấp phát mảng chứa n số nguyên.
            NhapMang(A); // Gọi hàm nhập từng giá trị cho mảng.
            Console.Write("Mảng ban đầu: "); XuatMang(A); // In nhãn và mảng trước khi sắp xếp.
            new ThuatToanSapXep().InsertionSort(A); // Tạo bộ thuật toán sắp xếp và sắp xếp tăng dần.
            Console.Write("Mảng sau sắp xếp tăng dần: "); XuatMang(A); // In mảng sau khi đã sắp xếp.

            if (A.Length > 0) // Chỉ hỏi giá trị tìm khi mảng có phần tử.
            {
                Console.Write("Nhập số cần tìm: "); // Yêu cầu người dùng nhập số lượng phần tử.
                int x; // Biến chứa giá trị cần tìm.
                while (!int.TryParse(Console.ReadLine(), out x)) Console.Write("Vui lòng nhập số nguyên: "); // Lặp đến khi nhập được số nguyên không âm.
                int index = new ThuatToanTimKiem().BinarySearchFor(A, x); // Tìm x bằng tìm kiếm nhị phân trên mảng đã sắp xếp.
                Console.WriteLine(index < 0 ? "Không tìm thấy." : "Tìm thấy tại chỉ số " + index + "."); // In vị trí tìm thấy hoặc thông báo không có.
            }

            Console.WriteLine("\nDanh sách liên kết đơn minh họa:"); // In tiêu đề phần minh họa danh sách liên kết.
            DanhSachLienKet danhSach = new DanhSachLienKet(); // Tạo một danh sách liên kết đơn mới.
            foreach (int value in A) danhSach.AddLast(value); // Duyệt mảng và chèn các giá trị vào cuối danh sách.
            Console.WriteLine(danhSach.IsEmpty ? "(rỗng)" : danhSach.ToString()); // In nội dung danh sách hoặc thông báo danh sách rỗng.
        }

        private static void NhapMang(int[] A) // Hàm nhập các phần tử cho mảng.
        {
            for (int i = 0; i < A.Length; i++) // Lặp qua từng chỉ số mảng cần nhập.
            {
                Console.Write("A[" + i + "] = "); // Hiển thị chỉ số hiện tại cho người dùng.
                while (!int.TryParse(Console.ReadLine(), out A[i])) Console.Write("Vui lòng nhập số nguyên: "); // Lặp đến khi nhập được số nguyên không âm.
            }
        }

        private static void XuatMang(int[] A) { Console.WriteLine(string.Join(", ", A)); } // Hàm in các phần tử mảng trên một dòng.
    }
}
