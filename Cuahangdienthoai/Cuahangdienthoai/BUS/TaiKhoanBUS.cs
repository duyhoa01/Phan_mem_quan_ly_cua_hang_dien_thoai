using Cuahangdienthoai.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuahangdienthoai.BUS
{
    class TaiKhoanBUS
    {
        private static TaiKhoanBUS _Instance;
        public static TaiKhoanBUS Instance
        {
            get
            {
                if (_Instance == null) _Instance = new TaiKhoanBUS();
                return _Instance;
            }
            private set
            {

            }
        }
        public Account GetAccountLogin(string tendangnhap,string matkhau)
        {
            return TaiKhoanDAL.Instance.GetAccountLogin(tendangnhap, matkhau);
        }
        public List<string> GetPhanQuyenTaiKhoan(Account account)
        {
            return TaiKhoanDAL.Instance.GetPhanQuenTaiKhoan(account);
        }
        public NhanVien GetNhanVien(Account account)
        {
            return TaiKhoanDAL.Instance.GetNhanVien(account);
        }
        public object GetListAcc(string TimKiem)
        {
            return TaiKhoanDAL.Instance.GetListAcc(TimKiem);
        }
        public List<NhanVien> GetListNVKhongAcc()
        {
            return TaiKhoanDAL.Instance.GetListNVKhongAcc();
        }
        public void ThemAcc(Account acc)
        {
            TaiKhoanDAL.Instance.ThemAcc(acc);
        }
        public void XoaAcc(int ID)
        {
            TaiKhoanDAL.Instance.XoaAcc(ID);
        }
        public void SuaAcc(Account acc)
        {
            TaiKhoanDAL.Instance.SuaAcc(acc);
        }
        public int GetMaIDMoi()
        {
            return TaiKhoanDAL.Instance.GetMaIDMoi();
        }
        public void ThemPhanQuyenLienKet(Account acc)
        {
            TaiKhoanDAL.Instance.ThemPhanQuyenLienKet(acc);
        }
        public void SuaAccByUser(Account newAcc)
        {
            TaiKhoanDAL.Instance.SuaAccByUser(newAcc);
        }
    }
}
