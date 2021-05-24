using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuahangdienthoai.DAL;

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
        public List<DienThoai> GetListDT(string TimKiem)
        {
            return DienThoaiDAL.Instance.GetListDT(TimKiem);
        }
    }
}
