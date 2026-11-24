# Bộ bài soạn CTDL & Giải thuật (bản hoàn thiện)

Bộ mã nguồn C# .NET Framework 4.8 dùng cho các nội dung thuật toán tìm kiếm, sắp xếp và danh sách liên kết đơn.

## Nội dung

- `ThuatToanTimKiem.cs`: tìm tuyến tính, tìm tuyến tính có lính canh (khôi phục dữ liệu sau tìm), tìm nhị phân đệ quy/lặp, tìm nội suy.
- `ThuatToanSapXep.cs`: Selection, Insertion, Interchange, Bubble, Shaker, Radix (số không âm), QuickSort Hoare, QuickSort Median-of-three và MergeSort.
- `DanhSachLienKet.cs`, `Node.cs`: danh sách liên kết đơn với thêm đầu/cuối/chèn vị trí, truy cập/cập nhật, tìm kiếm, xóa, chuyển mảng và hai cách sắp xếp.
- `Program.cs`: chương trình console nhập N và mảng, sắp xếp, tìm kiếm nhị phân, minh họa danh sách liên kết.
- `BaiTap.cs`: giữ phần mục lục bài giảng có sẵn.
- `CTDL_GT_thuat_toan.csproj`: dự án .NET Framework 4.8 đã cập nhật danh sách tệp biên dịch.

## Chạy

Mở `CTDL_GT_thuat_toan.csproj` trong Visual Studio hoặc build bằng MSBuild/.NET SDK có hỗ trợ .NET Framework 4.8.

Binary Search và Interpolation Search yêu cầu mảng đầu vào đã được sắp xếp tăng dần. RadixSort chỉ nhận số nguyên không âm. Với QuickSort/MergeSort, truyền `left = 0`, `right = A.Length - 1`; mảng rỗng dùng `left = 0`, `right = -1`.

## Ghi chú

`Node.cs` được thêm vì file dự án tham chiếu nút danh sách nhưng file này không có trong bộ file được nêu ban đầu. PDF tham khảo là bản scan, không trích xuất được văn bản; nội dung mã được hoàn thiện theo tên các chủ đề trong mục lục `BaiTap.cs` và các cài đặt sẵn trong dự án.
