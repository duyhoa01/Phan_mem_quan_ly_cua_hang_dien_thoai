using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuahangdienthoai.DAL
{
    public class DonHangDAL
    {
        private static DonHangDAL _instance;
        public static DonHangDAL Instance
        {
            get { if (_instance == null) _instance = new DonHangDAL(); return DonHangDAL._instance; }
            private set { DonHangDAL._instance = value; }
        }
        private DonHangDAL() { DonHangDAL._instance = null; }
        public object GetListDonHang(string TimKiem, DateTime NgayBD, DateTime NgayKT)
        {
            DateTime ngayKT = new DateTime(NgayKT.Year, NgayKT.Month, NgayKT.Day, 23, 59, 59);
            DateTime ngayBD = new DateTime(NgayBD.Year, NgayBD.Month, NgayBD.Day, 0, 0, 0);
            using (PBL3Entities db = new PBL3Entities())
            {
                return db.HoaDonBanHangs.Where(p => (p.MaHoaDon.ToString().Contains(TimKiem)
                                                        || p.NhanVien.TenNhanVien.Contains(TimKiem)
                                                        || p.KhachHang.TenKhachHang.Contains(TimKiem))
                                                    && p.NgayBan <= ngayKT
                                                    && p.NgayBan >= ngayBD
                                                     )
                                        .Select(p => new
                                        {
                                            p.MaHoaDon,
                                            p.NgayBan,
                                            p.KhachHang.TenKhachHang,
                                            p.NhanVien.TenNhanVien,
                                            p.TongTien,
                                            p.TongLoiNhuan
                                        }
                                            ).ToList();
            }
        }
    }
}
