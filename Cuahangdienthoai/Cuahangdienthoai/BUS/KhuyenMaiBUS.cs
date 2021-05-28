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
        public List<KMApDung> GetListKMApDung(double TongTien)
        {
            List<KMApDung> list = new List<KMApDung>();
            foreach (KhuyenMai item in KhuyenMaiDAL.Instance.GetListKMApDung(TongTien))
            {
                float apdung;
                if((TongTien * (double)item.phantram / 100) >= item.khuyenmaitoida)
                {
                    apdung = (float)item.khuyenmaitoida;
                }
                else
                {
                    apdung = (float)(TongTien * (double)item.phantram / 100);
                }
                list.Add(new KMApDung
                {
                    MaKM = item.makhuyenmai,
                    TenKhuyenMai = item.tenkhuyenmai,
                    TienToiThieu = (float)item.tientoithieu,
                    PtGiamGia = (float)item.phantram,
                    GiamToiDa = (float)item.khuyenmaitoida,
                    ApDung = apdung
                });
            }
            return list;
        }
        public void ThemKhuyenMaiApDungHD(int MaHD, int MaKM)
        {
            KhuyenMaiDAL.Instance.ThemKhuyenMaiApDungHD(MaHD, MaKM);
        }
        public void XoaKhuyenMaiApDungHD(int MaHD)
        {
            KhuyenMaiDAL.Instance.XoaKhuyenMaiApDungHD(MaHD);
        }
    }
}
