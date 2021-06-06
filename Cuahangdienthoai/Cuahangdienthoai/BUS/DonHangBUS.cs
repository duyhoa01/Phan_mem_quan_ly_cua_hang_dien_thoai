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
            float PtGiamGia = (float)dt.C_GiamGia;
            float ThanhTien = TongTien - ((float)dt.C_GiamGia / 100 * (float)dt.GiaBanDT)*SoLuong;
            float LoiNhuan = ThanhTien - TongTienNhap;
            DonHangDAL.Instance.ThemHoaDonChiTiet(MaHD, MaDT, SoLuong, DonGia, PtGiamGia, LoiNhuan, ThanhTien);
        }
        public void XoaHoaDonChiTiet(int MaHD)
        {
            DonHangDAL.Instance.XoaHoaDonChiTiet(MaHD);
        }
        public void XoaDonHang(int MaHD)
        {
            DonHangDAL.Instance.XoaDonHang(MaHD);
        }
        public HoaDonBanViewFormHDBCT HDBH(int MaHD)
        {
            return DonHangDAL.Instance.HDBH(MaHD);
        }
        public List<DienThoaiViewHDBCT> GetListHDBCTByMaHD(int MaHD)
        {
            List<DienThoaiViewHDBCT> list = new List<DienThoaiViewHDBCT>();
            foreach (HoaDonChiTiet item in DonHangDAL.Instance.GetListHDBCTByMaHD(MaHD))
            {
                DienThoai dt = DienThoaiDAL.Instance.TimDTByMaDT(item.MaDT);
                string path = MenuFor.path + dt.Anh;
                Image AnhGoc = new Bitmap(path);
                list.Add(new DienThoaiViewHDBCT
                {
                    Anh = new Bitmap(AnhGoc, 80, 80),
                    MaDT = item.MaDT,
                    TenDT = dt.TenDienThoai,
                    GiaBan = (float)dt.GiaBanDT,
                    PtGiamGia = (float)item.GiamGia,
                    GiamCon = (float)(dt.GiaBanDT*(100 - item.GiamGia) /100),
                    GiaNhap = (float)dt.GiaNhapDT,
                    SoLuong = (int)item.SoLuong,
                    TongTien = (float)(dt.GiaBanDT*item.SoLuong),
                    TongGiam = (float)(dt.GiaBanDT*(item.GiamGia) /100 * item.SoLuong),
                    ThanhTien = (float)(dt.GiaBanDT * (100 - item.GiamGia) / 100 * item.SoLuong),
                    TongGiaNhap = (float)(dt.GiaNhapDT*item.SoLuong),
                }); 
            }
            return list;
        }
    }
}
