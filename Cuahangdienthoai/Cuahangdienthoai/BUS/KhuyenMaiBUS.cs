using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuahangdienthoai.DAL;

namespace Cuahangdienthoai.BUS
{
    public class KhuyenMaiBUS
    {
        private static KhuyenMaiBUS _instance;
        public static KhuyenMaiBUS Instance
        {
            get { if (_instance == null) _instance = new KhuyenMaiBUS(); return KhuyenMaiBUS._instance; }
            private set { KhuyenMaiBUS._instance = value; }
        }
        private KhuyenMaiBUS() { KhuyenMaiBUS._instance = null; }
        public List<KhuyenMai> GetListKM()
        {
            return KhuyenMaiDAL.Instance.GetListKM();
        }
        public void XoaKM(int MaKM)
        {
            KhuyenMaiDAL.Instance.XoaKM(MaKM);
        }
        public void ThemKM(string TenKM, DateTime NgayBatDau, DateTime NgayKetThuc, float TienToiThieu, Decimal PtGiamGia, float GiamGiaMax)
        {
            KhuyenMaiDAL.Instance.ThemKM(TenKM, NgayBatDau, NgayKetThuc, TienToiThieu, PtGiamGia, GiamGiaMax);
        }
        public void SuaKM(int MaKM, string TenKM, DateTime NgayBatDau, DateTime NgayKetThuc, float TienToiThieu, Decimal PtGiamGia, float GiamGiaMax)
        {
            KhuyenMaiDAL.Instance.SuaKM(MaKM, TenKM, NgayBatDau, NgayKetThuc, TienToiThieu, PtGiamGia, GiamGiaMax);
        }
        public void AnKM(int MaKM)
        {
            KhuyenMaiDAL.Instance.AnKM(MaKM);
        }
    }
}
