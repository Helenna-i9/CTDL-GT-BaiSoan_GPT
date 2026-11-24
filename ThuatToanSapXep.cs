using System; // Dùng Array và các ngoại lệ của .NET.
using System.Collections.Generic; // Namespace bộ sưu tập, giữ sẵn cho các cấu trúc hỗ trợ.

namespace CTDL_GT_thuat_toan // Namespace chung của dự án.
{
    internal class ThuatToanSapXep // Lớp cài đặt các thuật toán sắp xếp mảng.
    {
        private void Swap(ref int a, ref int b) // Hàm hoán đổi hai số nguyên qua tham chiếu.
        { int temp = a; a = b; b = temp; } // Giữ a tạm thời rồi đổi chỗ hai giá trị.

        public void SelectionSort(int[] A) // Sắp xếp chọn phần tử nhỏ nhất ở mỗi lượt.
        {
            RequireArray(A); // Kiểm tra mảng khác null trước khi thao tác.
            for (int i = 0; i < A.Length - 1; i++) // Chọn vị trí đầu vùng chưa được sắp xếp.
            {
                int min = i; // Tạm xác định phần tử tại i là nhỏ nhất.
                for (int j = i + 1; j < A.Length; j++) if (A[j] < A[min]) min = j; // Dò các phần tử phía sau để tìm giá trị nhỏ nhất.
                if (min != i) Swap(ref A[i], ref A[min]); // Chỉ hoán đổi khi tìm được phần tử nhỏ hơn vị trí i.
            }
        }

        public void InsertionSort(int[] A) // Sắp xếp chèn từng phần tử vào đoạn trái đã có thứ tự.
        {
            RequireArray(A); // Kiểm tra mảng khác null trước khi thao tác.
            for (int i = 1; i < A.Length; i++) // Tạo tổng tích lũy để xác định vị trí ghi.
            {
                int x = A[i], j = i - 1; // Lưu giá trị cần chèn và bắt đầu so sánh từ bên trái.
                while (j >= 0 && A[j] > x) { A[j + 1] = A[j]; j--; } // Dời các giá trị lớn hơn x sang phải để tạo chỗ.
                A[j + 1] = x; // Đặt x vào vị trí trống vừa tìm được.
            }
        }

        // Sắp xếp đổi chỗ trực tiếp.
        public void InterChangeSort(int[] A) // Sắp xếp đổi chỗ trực tiếp bằng cách so sánh từng cặp.
        {
            RequireArray(A); // Kiểm tra mảng khác null trước khi thao tác.
            for (int i = 0; i < A.Length - 1; i++) // Chọn vị trí đầu vùng chưa được sắp xếp.
                for (int j = i + 1; j < A.Length; j++) // Dò các phần tử phía sau để tìm giá trị nhỏ nhất.
                    if (A[j] < A[i]) Swap(ref A[i], ref A[j]); // Đưa giá trị nhỏ hơn về trước bằng phép hoán đổi.
        }

        public void BubbleSort(int[] A) // Sắp xếp nổi bọt, đẩy phần tử nhỏ về đầu mảng.
        {
            RequireArray(A); // Kiểm tra mảng khác null trước khi thao tác.
            for (int i = 0; i < A.Length - 1; i++) // Chọn vị trí đầu vùng chưa được sắp xếp.
            {
                bool swapped = false; // Theo dõi lượt quét có hoán đổi hay không.
                for (int j = A.Length - 1; j > i; j--) // Quét từ cuối đoạn về vị trí đầu chưa cố định.
                    if (A[j] < A[j - 1]) { Swap(ref A[j], ref A[j - 1]); swapped = true; } // Đổi cặp kề nhau khi chúng đang sai thứ tự.
                if (!swapped) break; // Nếu không đổi chỗ thì mảng đã được sắp xếp.
            }
        }

        public void ShakerSort(int[] A) // Sắp xếp rung lắc với hai lượt quét ngược chiều.
        {
            RequireArray(A); // Kiểm tra mảng khác null trước khi thao tác.
            int left = 0, right = A.Length - 1; // Khởi tạo hai biên của đoạn chưa hoàn tất.
            while (left < right) // Tiếp tục khi đoạn chưa sắp xếp còn ít nhất hai phần tử.
            {
                int lastSwap = left; // Lưu vị trí hoán đổi cuối của lượt quét để thu hẹp biên.
                for (int j = right; j > left; j--) // Quét từ phải sang trái để đưa số nhỏ về trái.
                    if (A[j] < A[j - 1]) { Swap(ref A[j], ref A[j - 1]); lastSwap = j; } // Đổi cặp kề nhau khi chúng đang sai thứ tự.
                left = lastSwap; // Cập nhật biên trái theo vị trí cuối còn cần xét.
                if (left >= right) break; // Dừng nếu hai biên đã gặp nhau.
                lastSwap = right; // Đặt biên dự phòng cho lượt quét xuôi.
                for (int i = left; i < right; i++) // Quét từ trái sang phải để đưa số lớn về phải.
                    if (A[i] > A[i + 1]) { Swap(ref A[i], ref A[i + 1]); lastSwap = i; } // Đổi cặp kề nhau sai thứ tự và ghi lại vị trí hoán đổi cuối.
                right = lastSwap; // Cập nhật biên phải sau lượt quét xuôi.
            }
        }

        // Radix sort LSD cho số nguyên không âm.
        public void RadixSort(int[] A) // Sắp xếp cơ số theo từng chữ số từ hàng đơn vị.
        {
            RequireArray(A); // Kiểm tra mảng khác null trước khi thao tác.
            for (int i = 0; i < A.Length; i++) // Chọn vị trí đầu vùng chưa được sắp xếp.
                if (A[i] < 0) throw new ArgumentException("RadixSort chỉ hỗ trợ số nguyên không âm.", "A"); // RadixSort này không hỗ trợ số âm nên báo lỗi.
            if (A.Length < 2) return; // Mảng có dưới hai phần tử đã được sắp xếp.
            int max = A[0]; // Khởi tạo giá trị lớn nhất bằng phần tử đầu.
            for (int i = 1; i < A.Length; i++) if (A[i] > max) max = A[i]; // Tạo tổng tích lũy để xác định vị trí ghi.
            long place = 1; // Đại diện hàng chữ số hiện tại, bắt đầu từ đơn vị.
            int[] output = new int[A.Length]; // Tạo mảng phụ lưu kết quả của mỗi lượt phân phối.
            while (max / place > 0) // Lặp đến hàng chữ số cao nhất của số lớn nhất.
            {
                int[] count = new int[10]; // Mảng đếm tần suất cho các chữ số từ 0 đến 9.
                for (int i = 0; i < A.Length; i++) count[(int)(A[i] / place % 10)]++; // Chọn vị trí đầu vùng chưa được sắp xếp.
                for (int i = 1; i < count.Length; i++) count[i] += count[i - 1]; // Tạo tổng tích lũy để xác định vị trí ghi.
                for (int i = A.Length - 1; i >= 0; i--) // Duyệt ngược để giữ tính ổn định của Radix sort.
                {
                    int digit = (int)(A[i] / place % 10); // Lấy chữ số đang dùng để phân nhóm phần tử.
                    output[--count[digit]] = A[i]; // Ghi phần tử vào vị trí được bộ đếm xác định.
                }
                Array.Copy(output, A, A.Length); // Chép kết quả lượt hiện tại về mảng ban đầu.
                place *= 10; // Chuyển sang hàng chữ số tiếp theo.
            }
        }

        private (int, int) Partition(int[] A, int left, int right, int pivot) // Phân hoạch đoạn quanh giá trị chốt và trả hai biên mới.
        {
            int i = left, j = right; // Khởi tạo hai con trỏ quét từ hai đầu đoạn.
            while (i <= j) // Tiếp tục cho đến khi hai con trỏ vượt qua nhau.
            {
                while (A[i] < pivot) i++; // Bỏ qua các giá trị nhỏ hơn chốt ở phía trái.
                while (A[j] > pivot) j--; // Bỏ qua các giá trị lớn hơn chốt ở phía phải.
                if (i <= j) { Swap(ref A[i], ref A[j]); i++; j--; } // Hoán đổi cặp đang nằm nhầm phía rồi dịch con trỏ.
            }
            return (i, j); // Trả biên để QuickSort xử lý hai đoạn con.
        }

        public void QuickSortHo(int[] A, int left, int right) // QuickSort dùng phân hoạch Hoare với chốt giữa.
        {
            RequireArray(A); ValidateRange(A, left, right); // Kiểm tra mảng khác null trước khi thao tác.
            if (left >= right) return; // Dừng nếu hai biên đã gặp nhau.
            int pivot = A[left + (right - left) / 2]; // Chọn phần tử giữa làm chốt phân hoạch.
            (int i, int j) = Partition(A, left, right, pivot); // Chia đoạn thành hai phần quanh chốt.
            if (left < j) QuickSortHo(A, left, j); // Sắp xếp đệ quy phần trái nếu còn nhiều phần tử.
            if (i < right) QuickSortHo(A, i, right); // Sắp xếp đệ quy phần phải nếu còn nhiều phần tử.
        }

        private int Median3(int[] A, int left, int right) // Chọn trung vị trong ba mẫu đầu, giữa và cuối.
        {
            int middle = left + (right - left) / 2; // Tính vị trí phần tử giữa đoạn.
            if (A[left] > A[middle]) Swap(ref A[left], ref A[middle]); // Đưa phần tử nhỏ hơn trong cặp đầu/giữa lên trước.
            if (A[left] > A[right]) Swap(ref A[left], ref A[right]); // Đảm bảo phần tử đầu không lớn hơn phần tử cuối.
            if (A[middle] > A[right]) Swap(ref A[middle], ref A[right]); // Sắp thứ tự ba mẫu để giữa là trung vị.
            return A[middle]; // Trả trung vị làm giá trị chốt.
        }

        public void QuicSortMe(int[] A, int left, int right) // QuickSort chọn chốt trung vị ba phần tử.
        {
            RequireArray(A); ValidateRange(A, left, right); // Kiểm tra mảng khác null trước khi thao tác.
            if (left >= right) return; // Dừng nếu hai biên đã gặp nhau.
            int pivot = Median3(A, left, right); // Tính chốt trung vị để giảm khả năng chia lệch.
            (int i, int j) = Partition(A, left, right, pivot); // Chia đoạn thành hai phần quanh chốt.
            if (left < j) QuicSortMe(A, left, j); // Sắp xếp đệ quy phần trái nếu còn nhiều phần tử.
            if (i < right) QuicSortMe(A, i, right); // Sắp xếp đệ quy phần phải nếu còn nhiều phần tử.
        }

        private void Merge(int[] A, int left, int middle, int right) // Trộn hai đoạn con đã sắp thành một đoạn có thứ tự.
        {
            int[] temp = new int[right - left + 1]; // Cấp mảng phụ vừa đủ chứa đoạn cần trộn.
            int i = left, j = middle + 1, k = 0; // Khởi tạo chỉ số hai nửa và chỉ số ghi mảng phụ.
            while (i <= middle && j <= right) // So sánh hai nửa khi cả hai còn phần tử.
                temp[k++] = A[i] <= A[j] ? A[i++] : A[j++]; // Chép phần tử nhỏ hơn tiếp theo vào mảng phụ.
            while (i <= middle) temp[k++] = A[i++]; // So sánh hai nửa khi cả hai còn phần tử.
            while (j <= right) temp[k++] = A[j++]; // Chép phần còn lại của nửa phải nếu có.
            Array.Copy(temp, 0, A, left, temp.Length); // Chép đoạn đã trộn trở lại mảng ban đầu.
        }

        public void MergeSort(int[] A, int left, int right) // Chia đôi và sắp xếp trộn đoạn [left, right].
        {
            RequireArray(A); ValidateRange(A, left, right); // Kiểm tra mảng khác null trước khi thao tác.
            if (left >= right) return; // Dừng nếu hai biên đã gặp nhau.
            int middle = left + (right - left) / 2; // Tính vị trí phần tử giữa đoạn.
            MergeSort(A, left, middle); // Sắp xếp đệ quy nửa trái.
            MergeSort(A, middle + 1, right); // Sắp xếp đệ quy nửa phải.
            Merge(A, left, middle, right); // Trộn hai nửa đã sắp thành đoạn hoàn chỉnh.
        }

        private static void RequireArray(int[] A) // Hàm dùng chung để kiểm tra mảng đầu vào.
        { if (A == null) throw new ArgumentNullException("A"); } // Ném ngoại lệ nếu tham chiếu mảng là null.

        private static void ValidateRange(int[] A, int left, int right) // Kiểm tra phạm vi chỉ số dùng trong thuật toán đệ quy.
        {
            if (A.Length == 0 && left == 0 && right == -1) return; // Chấp nhận đoạn rỗng chuẩn của mảng rỗng.
            if (left < 0 || right >= A.Length || left > right + 1) // Phát hiện biên âm, vượt mảng hoặc đoạn sai thứ tự.
                throw new ArgumentOutOfRangeException("Phạm vi chỉ số không hợp lệ."); // Báo lỗi chỉ số rõ ràng trước khi truy cập mảng.
        }
    }
}
