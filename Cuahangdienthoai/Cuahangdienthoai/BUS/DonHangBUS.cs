using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuahangdienthoai.DAL;
using Cuahangdienthoai.DTO;

namespace Cuahangdienthoai.BUS
{
    public class DonHangBUS
    {
        private static DonHangBUS _instance;
        public static DonHangBUS Instance
        {
            get { if (_instance == null) _instance = new DonHangBUS(); return DonHangBUS._instance; }
            private set { DonHangBUS._instance = value; }
        }
        private DonHangBUS() { DonHangBUS._instance = null; }
        public object GetListDonHang(string TimKiem, DateTime NgayBD, DateTime NgayKT)
        {
            return DonHangDAL.Instance.GetListDonHang(TimKiem, NgayBD, NgayKT);
        }
        public void ThemDonHang(int MaNV, int MaKH, DateTime NgayBan, double TongTien, double TongLoiNhuan)
        {
            DonHangDAL.Instance.ThemDonHang(MaNV, MaKH, NgayBan, TongTien, TongLoiNhuan);
        }
        public int GetLastHD()
        {
            return DonHangDAL.Instance.GetLastHD();
        }
        public void ThemHoaDonChiTiet(int MaHD, int MaDT, int SoLuong)
        {
            DienThoai dt = DienThoaiDAL.Instance.TimDTByMaDT(MaDT);
            float DonGia = (float)dt.GiaBanDT;
            float TongTienNhap = (float)dt.GiaNhapDT * SoLuong;
            float TongTien = (float)dt.GiaBanDT * SoLuong;
            float GiamGia = (float)dt.C_GiamGia;
            float ThanhTien = TongTien - (GiamGia / 100 * (float)dt.GiaBanDT)*SoLuong;
            float LoiNhuan = ThanhTien - TongTienNhap;
            DonHangDAL.Instance.ThemHoaDonChiTiet(MaHD, MaDT, SoLuong, DonGia, GiamGia, LoiNhuan, ThanhTien);
        }
        public void XoaHoaDonChiTiet(int MaHD)
        {
            DonHangDAL.Instance.XoaHoaDonChiTiet(MaHD);
        }
        public void XoaDonHang(int MaHD)
        {
            DonHangDAL.Instance.XoaDonHang(MaHD);
        }
    }
}
