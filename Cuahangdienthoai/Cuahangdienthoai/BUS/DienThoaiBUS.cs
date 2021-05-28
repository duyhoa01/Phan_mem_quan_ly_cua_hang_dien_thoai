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
    class DienThoaiBUS
    {
        private static DienThoaiBUS _instance;
        public static DienThoaiBUS Instance
        {
            get { if (_instance == null) _instance = new DienThoaiBUS(); return DienThoaiBUS._instance; }
            private set { DienThoaiBUS._instance = value; }
        }
        private DienThoaiBUS() { DienThoaiBUS._instance = null; }
        public void ThemDT(string TenDT, float GiaNhap, float GiaBan, float PtGiamGia, float DiemDanhGia
            , int LuotDanhGia, string ThongSoKyThuat, string Anh)
        {
            DienThoaiDAL.Instance.ThemDT(TenDT, GiaNhap, GiaBan, PtGiamGia, DiemDanhGia, LuotDanhGia, ThongSoKyThuat, Anh);
        }
        public DienThoai TimDTByMaDT(int MaDT)
        {
            return DienThoaiDAL.Instance.TimDTByMaDT(MaDT);
        }
        public bool XoaDT(int MaDT)
        {
            return DienThoaiDAL.Instance.XoaDT(DienThoaiDAL.Instance.TimDTByMaDT(MaDT));
        }
        public List<DienThoaiViewFormSP> GetListDT(string TimKiem, string SapXep)
        {
            List<DienThoaiViewFormSP> listDT = new List<DienThoaiViewFormSP>();
            foreach (DienThoai item in DienThoaiDAL.Instance.GetListDT(TimKiem, SapXep))
            {
                string path = MenuFor.path + item.Anh;
                Image AnhGoc = new Bitmap(path);
                listDT.Add(new DienThoaiViewFormSP
                {
                    Anh = new Bitmap(AnhGoc, 180, 180),
                    MaDT = item.MaDT,
                    TenDT = item.TenDienThoai,
                    SoLuong = Convert.ToInt32(item.SLHienTai),
                    GiaGoc = (float)item.GiaBanDT,
                    GiamCon = (float)(item.GiaBanDT*(100-item.C_GiamGia)/100),
                    DiemDanhGia = ((float)Convert.ToDouble(item.DiemDanhGia)).ToString() + " / 5\n\n"
                                    + item.LuotDanhGia.ToString() + " đánh giá",
                    PtGiamGia = (float)item.C_GiamGia,
                    LinkAnh = item.Anh
                });       
            }
            return listDT;
        }
        public void SuaDT(int MaDT, string TenDT, float PtGiamGia, float DiemDanhGia
            , int LuotDanhGia, string ThongSoKyThuat, string Anh)
        {
            DienThoaiDAL.Instance.SuaDT(MaDT, TenDT, PtGiamGia, DiemDanhGia, LuotDanhGia, ThongSoKyThuat, Anh);
        }
        public DienThoaiViewFormBan DTGioHang(int MaDT, int SoLuong)
        {
            DienThoai dt = DienThoaiDAL.Instance.TimDTByMaDT(MaDT);
            string path = MenuFor.path + dt.Anh;
            Image AnhGoc = new Bitmap(path);
            return new DienThoaiViewFormBan
            {
                Anh = new Bitmap(AnhGoc, 100, 100),
                MaDT = dt.MaDT,
                TenDT = dt.TenDienThoai,
                DonGia = (float)dt.GiaBanDT,
                PtGiamGia = (float)dt.C_GiamGia,
                GiaSauGiam = (float)(dt.GiaBanDT*(100-dt.C_GiamGia)/100),
                SoLuong = SoLuong,
                TongTien = (double)(dt.GiaBanDT * SoLuong),
                Giam = (double)(dt.GiaBanDT * dt.C_GiamGia / 100 * SoLuong),
                ThanhTien = (double)(dt.GiaBanDT * (100 - dt.C_GiamGia) / 100 * SoLuong),
            };
        }
    }
}
