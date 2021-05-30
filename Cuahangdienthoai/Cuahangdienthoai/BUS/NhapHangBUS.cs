using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuahangdienthoai.DAL;
using Cuahangdienthoai.DTO;
using Cuahangdienthoai.View;

namespace Cuahangdienthoai.BUS
{
    public class NhapHangBUS
    {
        private static NhapHangBUS _instance;
        public static NhapHangBUS Instance
        {
            get { if (_instance == null) _instance = new NhapHangBUS(); return NhapHangBUS._instance; }
            private set { NhapHangBUS._instance = value; }
        }
        private NhapHangBUS() { NhapHangBUS._instance = null; }
        public object GetListNhapKho(string TimKiem, DateTime NgayBD, DateTime NgayKT)
        {
            return NhapHangDAL.Instance.GetListNhapKho(TimKiem, NgayBD, NgayKT);
        }
        public void ThemNhapHang(int MaNV, int MaNCC, DateTime NgayNhap, double TongTienNhap)
        {
            NhapHangDAL.Instance.ThemNhapHang(MaNV, MaNCC, NgayNhap, TongTienNhap);
        }
        public int GetLastHD()
        {
            return NhapHangDAL.Instance.GetLastHD();
        }
        public void ThemHoaDonNhapChiTiet(int MaHD, int MaDT, int SoLuong, float GiaNhap, double ThanhTien)
        {
            NhapHangDAL.Instance.ThemHoaNhapChiTiet(MaHD, MaDT, SoLuong, GiaNhap, ThanhTien);
        }
        public void XoaHoaDonNhapChiTiet(int MaHD)
        {
            NhapHangDAL.Instance.XoaHoaDonNhapChiTiet(MaHD);
        }
        public void XoaNhapHang(int MaHD)
        {
            NhapHangDAL.Instance.XoaNhapHang(MaHD);
        }
        //public HoaDonBanViewFormHDBCT HDBH(int MaHD)
        //{
        //    return DonHangDAL.Instance.HDBH(MaHD);
        //}
        public List<DienThoaiFormMua> GetListHDNCTByMaHD(int MaHD)
        {
            List<DienThoaiFormMua> list = new List<DienThoaiFormMua>();
            foreach (HoaDonNhapChiTiet item in NhapHangDAL.Instance.GetListHDNCTByMaHD(MaHD))
            {
                DienThoai dt = DienThoaiDAL.Instance.TimDTByMaDT((int)item.MaDT);
                string path = MenuFor.path + dt.Anh;
                Image AnhGoc = new Bitmap(path);
                list.Add(new DienThoaiFormMua
                {
                    Anh = new Bitmap(AnhGoc, 80, 80),
                    MaDT = (int)item.MaDT,
                    TenDT = dt.TenDienThoai,
                    GiaNhap = (float)dt.GiaBanDT,
                    SoLuong = (int)item.SoLuong,
                    ThanhTien = (float)(dt.GiaBanDT * item.SoLuong),
                });
            }
            return list;
        }
    }
}
