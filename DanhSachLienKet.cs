using System; // Dùng các ngoại lệ chuẩn để kiểm tra chỉ số.
using System.Collections; // Dùng giao diện duyệt không có kiểu phần tử.
using System.Collections.Generic; // Dùng giao diện duyệt danh sách số nguyên.

namespace CTDL_GT_thuat_toan // Namespace chung của các lớp trong dự án.
{
    /// <summary>Danh sách liên kết đơn các số nguyên.</summary>
    internal class DanhSachLienKet : IEnumerable<int> // Cài đặt danh sách liên kết đơn chứa các số nguyên.
    {
        private Node dau; // Tham chiếu đến nút đầu danh sách.
        private Node cuoi; // Tham chiếu đến nút cuối để thêm cuối nhanh.
        public int Count { get; private set; } // Lưu số lượng nút hiện có; chỉ lớp này được thay đổi.
        public bool IsEmpty { get { return Count == 0; } } // Trả về true khi danh sách không có nút.

        public void AddFirst(int value) // Thêm giá trị mới vào đầu danh sách.
        {
            dau = new Node(value) { Next = dau }; // Tạo nút mới và nối nút đó đến đầu hiện tại.
            if (cuoi == null) cuoi = dau; // Kiểm tra danh sách trước đó có rỗng không.
            Count++; // Cập nhật số lượng sau khi thêm nút.
        }

        public void AddLast(int value) // Thêm giá trị mới vào cuối danh sách.
        {
            Node node = new Node(value); // Tạo nút mới, mặc định chưa trỏ đến nút kế tiếp.
            if (cuoi == null) dau = cuoi = node; // Kiểm tra danh sách trước đó có rỗng không.
            else { cuoi.Next = node; cuoi = node; } // Nối nút cuối cũ với nút mới rồi cập nhật nút cuối.
            Count++; // Cập nhật số lượng sau khi thêm nút.
        }

        public void Insert(int index, int value) // Chèn giá trị vào vị trí index tính từ 0.
        {
            if (index < 0 || index > Count) throw new ArgumentOutOfRangeException("index"); // Bảo đảm vị trí nằm trong khoảng từ 0 đến Count.
            if (index == 0) { AddFirst(value); return; } // Trường hợp chèn đầu danh sách.
            if (index == Count) { AddLast(value); return; } // Trường hợp chèn đúng sau nút cuối.
            Node previous = GetNode(index - 1); // Tìm nút đứng ngay trước vị trí chèn.
            previous.Next = new Node(value) { Next = previous.Next }; // Nối nút mới vào giữa nút trước và nút sau.
            Count++; // Cập nhật số lượng sau khi thêm nút.
        }

        public int GetAt(int index) { return GetNode(index).Data; } // Lấy dữ liệu ở vị trí được yêu cầu.
        public void SetAt(int index, int value) { GetNode(index).Data = value; } // Cập nhật dữ liệu ở vị trí được yêu cầu.

        public int IndexOf(int value) // Tìm vị trí xuất hiện đầu tiên của giá trị.
        {
            int index = 0; // Bắt đầu đánh số từ vị trí đầu tiên.
            for (Node current = dau; current != null; current = current.Next, index++) // Duyệt từng nút và đồng thời tăng chỉ số.
                if (current.Data == value) return index; // So sánh dữ liệu nút hiện tại với giá trị cần tìm.
            return -1; // Quy ước -1 là không tìm thấy.
        }

        public bool Contains(int value) { return IndexOf(value) >= 0; } // Kiểm tra giá trị có nằm trong danh sách hay không.

        public bool Remove(int value) // Xóa lần xuất hiện đầu tiên của một giá trị.
        {
            Node previous = null, current = dau; // Theo dõi nút trước và nút đang xét khi tìm.
            while (current != null && current.Data != value) // Tìm đến khi hết danh sách hoặc gặp dữ liệu cần xóa.
            { previous = current; current = current.Next; } // Dời hai tham chiếu cùng tiến một nút.
            if (current == null) return false; // Không tìm thấy giá trị trong danh sách.
            RemoveNode(previous, current); // Gỡ nút đã tìm thấy và cập nhật trạng thái danh sách.
            return true; // Báo thao tác xóa đã thành công.
        }

        public int RemoveAt(int index) // Xóa nút theo vị trí và trả về dữ liệu bị xóa.
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException("index"); // Bảo đảm vị trí nằm trong khoảng từ 0 đến Count.
            Node previous = index == 0 ? null : GetNode(index - 1); // Nút đầu không có nút trước; vị trí khác cần tìm nút trước.
            Node current = previous == null ? dau : previous.Next; // Chọn nút đầu hoặc nút sau previous làm nút cần xóa.
            int value = current.Data; // Giữ dữ liệu để trả lại sau khi gỡ nút.
            RemoveNode(previous, current); // Gỡ nút đã tìm thấy và cập nhật trạng thái danh sách.
            return value; // Trả về dữ liệu của nút vừa xóa.
        }

        public bool RemoveFirst(out int value) // Xóa lần xuất hiện đầu tiên của một giá trị.
        {
            if (IsEmpty) { value = default(int); return false; } // Nếu danh sách rỗng thì không có gì để xóa.
            value = RemoveAt(0); return true; // Xóa đầu danh sách và lưu dữ liệu bị xóa.
        }

        public bool RemoveLast(out int value) // Xóa lần xuất hiện đầu tiên của một giá trị.
        {
            if (IsEmpty) { value = default(int); return false; } // Nếu danh sách rỗng thì không có gì để xóa.
            value = RemoveAt(Count - 1); return true; // Xóa vị trí cuối cùng hiện có.
        }

        public void Clear() { dau = cuoi = null; Count = 0; } // Bỏ các tham chiếu nút và đặt số lượng về 0.

        public int[] ToArray() // Sao chép danh sách thành mảng số nguyên.
        {
            int[] result = new int[Count]; int index = 0; // Tạo mảng có kích thước bằng số nút.
            foreach (int value in this) result[index++] = value; // Duyệt từng giá trị trong danh sách.
            return result; // Trả về mảng đã được điền dữ liệu.
        }

        public void SortByData() // Sắp xếp tăng dần bằng cách đổi dữ liệu trong nút.
        {
            // Selection sort trên dữ liệu, giữ nguyên liên kết các nút.
            for (Node i = dau; i != null; i = i.Next) // Chọn lần lượt đầu mỗi đoạn chưa sắp xếp.
            {
                Node min = i; // Tạm xem nút hiện tại là nút nhỏ nhất.
                for (Node j = i.Next; j != null; j = j.Next) // Tìm nút nhỏ nhất ở phần còn lại.
                    if (j.Data < min.Data) min = j; // Cập nhật nút nhỏ nhất nếu gặp dữ liệu nhỏ hơn.
                int temp = i.Data; i.Data = min.Data; min.Data = temp; // Đổi dữ liệu của nút hiện tại và nút nhỏ nhất.
            }
        }

        public void SortByLinks() // Sắp xếp tăng dần bằng cách đổi liên kết nút.
        {
            // Insertion sort bằng cách nối lại nút, không hoán đổi dữ liệu.
            Node sorted = null, current = dau; // Tạo danh sách đã sắp xếp rỗng và bắt đầu ở đầu cũ.
            while (current != null) // Tìm đến khi hết danh sách hoặc gặp dữ liệu cần xóa.
            {
                Node next = current.Next; // Lưu nút kế tiếp trước khi thay đổi liên kết.
                if (sorted == null || current.Data < sorted.Data) // Kiểm tra current có cần trở thành nút đầu mới không.
                { current.Next = sorted; sorted = current; } // Nối current vào trước đầu danh sách đã sắp xếp.
                else // Nếu không đứng đầu thì tìm chỗ chèn trong danh sách.
                {
                    Node position = sorted; // Bắt đầu dò vị trí từ nút đầu đã sắp xếp.
                    while (position.Next != null && position.Next.Data <= current.Data) // Đi qua các nút có dữ liệu nhỏ hơn hoặc bằng current.
                        position = position.Next; // Tiến đến nút kế tiếp để xác định chỗ chèn.
                    current.Next = position.Next; position.Next = current; // Nối current vào sau position và giữ phần đuôi.
                }
                current = next; // Xử lý nút tiếp theo của danh sách chưa sắp xếp.
            }
            dau = sorted; cuoi = dau; // Cập nhật đầu mới rồi dò lại nút cuối.
            if (cuoi != null) while (cuoi.Next != null) cuoi = cuoi.Next; // Chỉ dò nút cuối khi danh sách không rỗng.
        }

        public override string ToString() { return string.Join(" -> ", ToArray()); } // Biểu diễn dữ liệu các nút thành chuỗi có mũi tên.

        public IEnumerator<int> GetEnumerator() // Cung cấp bộ duyệt có kiểu để dùng foreach.
        {
            for (Node current = dau; current != null; current = current.Next) // Duyệt từng nút và đồng thời tăng chỉ số.
                yield return current.Data; // Trả dữ liệu nút hiện tại cho vòng duyệt.
        }
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); } // Cài đặt giao diện duyệt không kiểu bằng bộ duyệt có kiểu.

        private Node GetNode(int index) // Tìm nút tại index; đây là thao tác nội bộ của lớp.
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException("index"); // Bảo đảm vị trí nằm trong khoảng từ 0 đến Count.
            Node current = dau; // Bắt đầu tìm từ đầu danh sách.
            for (int i = 0; i < index; i++) current = current.Next; // Đi qua index liên kết để đến đúng nút.
            return current; // Trả nút đã tìm thấy.
        }

        private void RemoveNode(Node previous, Node current) // Gỡ nút đã xác định và cập nhật đầu/cuối/số lượng.
        {
            if (previous == null) dau = current.Next; // Nếu xóa nút đầu thì chuyển đầu sang nút kế tiếp.
            else previous.Next = current.Next; // Nếu không đứng đầu thì tìm chỗ chèn trong danh sách.
            if (current == cuoi) cuoi = previous; // Nếu nút bị xóa là cuối thì lùi cuối về nút trước.
            Count--; // Giảm số lượng sau khi gỡ nút.
            if (Count == 0) dau = cuoi = null; // Chuẩn hóa đầu và cuối khi danh sách trở thành rỗng.
        }
    }
}
