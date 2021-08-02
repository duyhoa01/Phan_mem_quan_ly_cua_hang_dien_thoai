using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuahangdienthoai.DAL
{
    public class NhapHangDAL
    {
        private static NhapHangDAL _instance;
        public static NhapHangDAL Instance
        {
            get { if (_instance == null) _instance = new NhapHangDAL(); return NhapHangDAL._instance; }
            private set { NhapHangDAL._instance = value; }
        }
        private NhapHangDAL() { NhapHangDAL._instance = null; }
        public object GetListNhapKho(string TimKiem, DateTime NgayBD, DateTime NgayKT)
        {
            DateTime ngayKT = new DateTime(NgayKT.Year, NgayKT.Month, NgayKT.Day, 23, 59, 59);
            DateTime ngayBD = new DateTime(NgayBD.Year, NgayBD.Month, NgayBD.Day, 0, 0, 0);
            using (PBL3Entities db = new PBL3Entities())
            {
                return db.HoaDonNhaps.Where(p => (p.MaHoaDon.ToString().Contains(TimKiem)
                                                        || p.NhanVien.TenNhanVien.Contains(TimKiem)
                                                        || p.NhaCungCap.TenNhaCungCap.Contains(TimKiem))
                                                    && p.NgayNhap <= ngayKT
                                                    && p.NgayNhap >= ngayBD
                                                     )
                                        .Select(p => new
                                        {
                                            p.MaHoaDon,
                                            p.NgayNhap.Value,
                                            p.NhanVien.TenNhanVien,
                                            p.NhaCungCap.TenNhaCungCap,
                                            p.TongTienNhap,
                                            p.MaNhanVien,
                                            p.MaNhaCungCap
                                        }).OrderByDescending(p => p.MaHoaDon).ToList();
            }
        }
        public void ThemNhapHang(int MaNV, int MaNCC, DateTime NgayNhap, double TongTienNhap)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                db.HoaDonNhaps.Add(new HoaDonNhap
                {
                    MaNhanVien = MaNV,
                    MaNhaCungCap = MaNCC,
                    TongTienNhap = TongTienNhap,
                    NgayNhap = NgayNhap
                });
                db.SaveChanges();
            }
        }
        public int GetLastHD()
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                return db.HoaDonNhaps.ToList().LastOrDefault().MaHoaDon;
            }
        }
        public void ThemHoaNhapChiTiet(int MaHD, int MaDT, int SoLuong, float DonGia, double ThanhTien)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                db.HoaDonNhapChiTiets.Add(new HoaDonNhapChiTiet
                {
                    MaHoaDon = MaHD,
                    MaDT = MaDT,
                    DonGia = DonGia,
                    SoLuong = SoLuong,
                    ThanhTien = ThanhTien,
                });
                db.SaveChanges();
            }
        }
        public void XoaHoaDonNhapChiTiet(int MaHD)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                db.HoaDonNhapChiTiets.RemoveRange(db.HoaDonNhapChiTiets.Where(p => p.MaHoaDon == MaHD).Select(p => p).ToList());
                db.SaveChanges();
            }
        }
        public void XoaNhapHang(int MaHD)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                db.HoaDonNhaps.Remove(db.HoaDonNhaps.Find(MaHD));
                db.SaveChanges();
            }
        }
        public List<HoaDonNhapChiTiet> GetListHDNCTByMaHD(int MaHD)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                return db.HoaDonNhapChiTiets.Where(p => p.MaHoaDon == MaHD).Select(p => p).ToList();
            }
        }
    }
}
