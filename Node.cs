namespace CTDL_GT_thuat_toan // Namespace chung của các lớp dự án.
{
    /// <summary>Nút của danh sách liên kết đơn.</summary>
    internal sealed class Node // Khai báo nút nội bộ và không cho lớp khác kế thừa.
    {
        public int Data { get; set; } // Thuộc tính lưu số nguyên tại nút.
        public Node Next { get; set; } // Tham chiếu đến nút kế tiếp hoặc null nếu là nút cuối.
        public Node(int data) { Data = data; } // Hàm tạo nút với dữ liệu ban đầu.
    }
}
