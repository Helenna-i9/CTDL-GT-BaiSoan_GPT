// Dùng các ngoại lệ chuẩn để báo dữ liệu đầu vào không hợp lệ.
using System; // Dùng các ngoại lệ chuẩn để kiểm tra tham số.
// Gom lớp tìm kiếm vào namespace chung của dự án.
namespace CTDL_GT_thuat_toan // Namespace chung chứa các lớp của dự án.
{
    // Lớp tập hợp các phương pháp tìm kiếm trên mảng số nguyên.
    internal class ThuatToanTimKiem // Lớp cài đặt các phương pháp tìm kiếm mảng số nguyên.
    {
        // Trả về chỉ số xuất hiện đầu tiên; -1 nếu không tìm thấy.
        public int LinearSearch(int[] A, int x) // Tìm x tuần tự và trả vị trí xuất hiện đầu tiên.
        {
            if (A == null) throw new ArgumentNullException("A"); // Báo lỗi nếu mảng chưa được khởi tạo.
            for (int i = 0; i < A.Length; i++) if (A[i] == x) return i; // Kiểm tra lần lượt từng ô và trả vị trí ngay khi gặp x.
            // Giá trị -1 quy ước là không tìm thấy.
            return -1; // Quy ước -1 nghĩa là không tìm thấy.
        }
        // Tìm tuyến tính có lính canh. Luôn khôi phục phần tử cuối sau khi tìm.
        public int LinearSearchEx(int[] A, int x) // Tìm x tuần tự và trả vị trí xuất hiện đầu tiên.
        {
            if (A == null) throw new ArgumentNullException("A"); // Báo lỗi nếu mảng chưa được khởi tạo.
            if (A.Length == 0) return -1; // Mảng rỗng không thể chứa giá trị cần tìm.
            int lastIndex = A.Length - 1, lastValue = A[lastIndex]; // Lưu vị trí và giá trị gốc cuối mảng để khôi phục.
            // Đặt lính canh để vòng lặp chắc chắn gặp x trước khi vượt mảng.
            A[lastIndex] = x; // Đặt lính canh ở cuối để vòng lặp không cần tự kiểm tra giới hạn.
            // Bắt đầu tìm từ vị trí đầu tiên.
            int i = 0; // Bắt đầu dò từ đầu mảng.
            while (A[i] != x) i++; // Tăng chỉ số đến khi gặp x hoặc lính canh.
            A[lastIndex] = lastValue; // Trả phần tử cuối về đúng dữ liệu ban đầu.
            return i < lastIndex || lastValue == x ? i : -1; // Phân biệt x thật sự có trong mảng với lính canh vừa đặt.
        }
        // Mảng phải được sắp xếp tăng dần.
        public int BinarySearchRe(int[] A, int left, int right, int x) // Tìm nhị phân bằng đệ quy trên mảng tăng dần.
        {
            if (A == null) throw new ArgumentNullException("A"); // Báo lỗi nếu mảng chưa được khởi tạo.
            if (A.Length == 0) return -1; // Mảng rỗng không thể chứa giá trị cần tìm.
            if (left < 0 || right >= A.Length) throw new ArgumentOutOfRangeException(); // Kiểm tra biên tìm kiếm nằm trong phạm vi mảng.
            if (left > right) return -1; // Đoạn rỗng là điều kiện dừng đệ quy không tìm thấy.
            int middle = left + (right - left) / 2; // Tính chỉ số giữa tránh cộng trực tiếp hai biên.
            if (A[middle] == x) return middle; // Trả về vị trí khi phần tử giữa khớp x.
            // Chỉ đệ quy vào nửa có thể chứa x dựa trên thứ tự tăng dần.
            return A[middle] > x // Chọn nửa phù hợp theo thứ tự tăng dần của mảng.
                ? BinarySearchRe(A, left, middle - 1, x) // Tìm tiếp ở nửa trái nếu phần tử giữa lớn hơn x.
                : BinarySearchRe(A, middle + 1, right, x); // Tìm tiếp ở nửa phải nếu phần tử giữa nhỏ hơn x.
        }
        public int BinarySearchFor(int[] A, int x) // Tìm nhị phân bằng vòng lặp trên mảng tăng dần.
        {
            if (A == null) throw new ArgumentNullException("A"); // Báo lỗi nếu mảng chưa được khởi tạo.
            int left = 0, right = A.Length - 1; // Khởi tạo hai biên bao phủ toàn mảng.
            // Tiếp tục khi phạm vi còn ít nhất một phần tử.
            while (left <= right) // Tiếp tục khi đoạn tìm kiếm chưa rỗng.
            {
                int middle = left + (right - left) / 2; // Tính chỉ số giữa tránh cộng trực tiếp hai biên.
                if (A[middle] == x) return middle; // Trả về vị trí khi phần tử giữa khớp x.
                if (A[middle] > x) right = middle - 1; // Bỏ nửa phải nếu giá trị giữa lớn hơn x.
                else left = middle + 1; // Bỏ nửa trái nếu giá trị giữa nhỏ hơn x.
            }
            // Giá trị -1 quy ước là không tìm thấy.
            return -1; // Quy ước -1 nghĩa là không tìm thấy.
        }
        // Mảng phải được sắp xếp tăng dần.
        public int InterpolationSearch(int[] A, int x) // Tìm nội suy theo vị trí ước lượng trên mảng tăng dần.
        {
            if (A == null) throw new ArgumentNullException("A"); // Báo lỗi nếu mảng chưa được khởi tạo.
            int left = 0, right = A.Length - 1; // Khởi tạo hai biên bao phủ toàn mảng.
            while (left <= right && x >= A[left] && x <= A[right]) // Chỉ xét đoạn khi x nằm giữa hai giá trị biên.
            {
                if (A[left] == A[right]) return A[left] == x ? left : -1; // Tránh chia cho 0 khi các giá trị hai đầu bằng nhau.
                long numerator = ((long)x - A[left]) * (right - left); // Tính tử bằng kiểu long để giảm khả năng tràn số.
                int pos = left + (int)(numerator / ((long)A[right] - A[left])); // Ước lượng vị trí x theo nội suy tuyến tính.
                if (A[pos] == x) return pos; // Trả vị trí khi giá trị ước lượng khớp x.
                if (A[pos] > x) right = pos - 1; // Giá trị tại pos lớn hơn x nên thu hẹp đoạn về bên trái.
                // Thu hẹp phạm vi về bên phải khi giá trị ước lượng quá nhỏ.
                else left = pos + 1; // Giá trị tại pos nhỏ hơn x nên thu hẹp đoạn về bên phải.
            }
            // Giá trị -1 quy ước là không tìm thấy.
            return -1; // Quy ước -1 nghĩa là không tìm thấy.
        }
    }
}
