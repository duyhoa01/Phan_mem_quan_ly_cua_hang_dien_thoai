using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuahangdienthoai.DAL;
using Cuahangdienthoai.DTO;

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
        public List<KhuyenMaiApDung> GetListKMApDung(float TongTien)
        {
            List<KhuyenMaiApDung> list = new List<KhuyenMaiApDung>();
            foreach (KhuyenMai item in KhuyenMaiDAL.Instance.GetListKMApDung(TongTien))
            {
                list.Add(new KhuyenMaiApDung
                {
                    TenKM = item.tenkhuyenmai,
                    TienToiThieu = String.Format("{0:0,0} đ", item.tientoithieu),
                    PtGiamGia = String.Format("{0:0.##}", item.phantram) + " %",
                    GiamGiaMax = String.Format("{0:0,0} đ", item.khuyenmaitoida),
                    TienApDung = String.Format("{0:0,0} đ", (item.khuyenmaitoida >= (TongTien * ((float)Convert.ToDouble(item.phantram)) / 100))
                                                                ? (TongTien * ((float)Convert.ToDouble(item.phantram)) / 100) : item.khuyenmaitoida),
                });
            }
            return list;
        }
        public List<KhuyenMai> GetListKMThanhToan(float TongTien)
        {
            return KhuyenMaiDAL.Instance.GetListKMApDung(TongTien);
        }
    }
}
