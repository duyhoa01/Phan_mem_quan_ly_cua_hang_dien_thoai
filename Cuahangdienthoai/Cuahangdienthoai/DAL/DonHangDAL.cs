using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuahangdienthoai.DTO;

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
                                            p.NgayBan.Value,
                                            p.NhanVien.TenNhanVien,
                                            p.KhachHang.TenKhachHang,
                                            p.TongTien,
                                            p.TongLoiNhuan
                                        }).OrderByDescending(p => p.MaHoaDon).ToList();
            }
        }
        public void ThemDonHang(int MaNV, int MaKH, DateTime NgayBan, double TongTien, double TongLoiNhuan)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                db.HoaDonBanHangs.Add(new HoaDonBanHang
                {
                    MaNhanVien = MaNV,
                    MaKhachHang = MaKH,
                    TongTien = TongTien,
                    NgayBan = NgayBan,
                    TongLoiNhuan = TongLoiNhuan
                });
                db.SaveChanges();
            }
        }
        public int GetLastHD()
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                return Convert.ToInt32(db.USP_GetMaBillMoi().FirstOrDefault());
            }
        }
        public void ThemHoaDonChiTiet(int MaHD, int MaDT, int SoLuong, float DonGia, float PtGiamGia, float LoiNhuan, float ThanhTien)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                db.HoaDonChiTiets.Add(new HoaDonChiTiet
                {
                    MaHoaDon = MaHD,
                    MaDT = MaDT,
                    DonGia = DonGia,
                    SoLuong = SoLuong,
                    GiamGia = PtGiamGia,
                    LoiNhuan = LoiNhuan,
                    ThanhTien = ThanhTien,
                });
                db.SaveChanges();
            }
        }
        public void XoaHoaDonChiTiet(int MaHD)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                db.HoaDonChiTiets.RemoveRange(db.HoaDonChiTiets.Where(p => p.MaHoaDon == MaHD).Select(p => p).ToList());
                db.SaveChanges();
            }
        }
        public void XoaDonHang(int MaHD)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                db.HoaDonBanHangs.Remove(db.HoaDonBanHangs.Find(MaHD));
                db.SaveChanges();
            }
        }
        public HoaDonBanViewFormHDBCT HDBH(int MaHD)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                HoaDonBanHang hd = db.HoaDonBanHangs.Find(MaHD);
                return new HoaDonBanViewFormHDBCT
                {
                    MaNV = hd.MaNhanVien,
                    TenNV = hd.NhanVien.TenNhanVien,
                    MaKH = hd.MaKhachHang,
                    TenKH = hd.KhachHang.TenKhachHang,
                    NgayBan = Convert.ToDateTime(hd.NgayBan)
                };
            }
        }
        public List<HoaDonChiTiet> GetListHDBCTByMaHD(int MaHD)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                return db.HoaDonChiTiets.Where(p => p.MaHoaDon == MaHD).Select(p => p).ToList();
            }
        }
    }
}
