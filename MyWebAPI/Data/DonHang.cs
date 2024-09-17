namespace MyWebAPI.Data
{
    public enum TinhTrangDonDatHang
    {
        New = 0, Payment = 1, Complete = 2, Cancel = -1 
    }
    public class DonHang
    {
        public Guid MaDH { get; set; } 
        public DateTime NgayDat { get; set; }
        public DateTime? NgayGiao { get; set; }
        public TinhTrangDonDatHang TinhTrangDonHang { get; set; }
        public String NguoiNhan { get; set; }
        public String DiaChiGiao { get; set; }
        public String SoDienThoai { get; set; }

        public ICollection<DonHangChiTiet> DonHangChiTiets { get; set; }

        public DonHang()
        {
            DonHangChiTiets = new List<DonHangChiTiet>();
        }

    }
}
