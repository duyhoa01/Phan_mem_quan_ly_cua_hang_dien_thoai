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
    }
}
