using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuahangdienthoai.DAL;
using Cuahangdienthoai.DTO;
using System.Windows.Forms;

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
        public List<DienThoaiViewFormSP> GetListDT(string TimKiem)
        {
            List<DienThoaiViewFormSP> listDT = new List<DienThoaiViewFormSP>();
            foreach (DienThoai item in DienThoaiDAL.Instance.GetListDT(TimKiem))
            {
                string path = Directory.GetParent((Directory.GetParent(Application.StartupPath)).FullName).FullName;
                path += @"\AnhDT\" + item.Anh;
                Image AnhGoc = new Bitmap(path);
                listDT.Add(new DienThoaiViewFormSP
                {
                    Anh = new Bitmap(AnhGoc, 180, 200),
                    MaDT = item.MaDT,
                    TenDT = item.TenDienThoai,
                    SoLuong = Convert.ToInt32(item.SLHienTai),
                    GiaNhap = (float)Convert.ToDouble(item.GiaNhapDT),
                    GiaBan = (float)Convert.ToDouble(item.GiaBanDT),
                    DiemDanhGia = (float)Convert.ToDouble(item.DiemDanhGia),
                    LuotDanhGia = Convert.ToInt32(item.LuotDanhGia)
                });
               
            }
            return listDT;
        }
    }
}
