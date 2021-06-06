using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuahangdienthoai.DAL
{
    class TaiKhoanDAL
    {
        private static TaiKhoanDAL _Instance;
        public static TaiKhoanDAL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new TaiKhoanDAL();
                return _Instance;
            }
            private set
            {

            }
        }
        public Account GetAccountLogin(string tendangnhap,string matkhau)
        {
            using(PBL3Entities db = new PBL3Entities())
            {
                var l = db.Accounts.Select(p => p);
                foreach (Account acc in l)
                {
                    if (acc.TenDangNhap.Equals(tendangnhap) && acc.MatKhau.Equals(matkhau))
                    {
                        return acc;
                    }
                }
                return null;
            }        
        }
        public List<String> GetPhanQuenTaiKhoan(Account account)
        {
            using(PBL3Entities db = new PBL3Entities())
            {
                var l = from a in db.Accounts
                        join pqlk in db.PhanQuyenLienKets on a.ID equals pqlk.MaAcc
                        join nq in db.NhomQuyens on pqlk.MaNhomQuyen equals nq.maNhomQuyen
                        join nqct in db.NhomQuyenChiTiets on nq.maNhomQuyen equals nqct.MaNhomQuyen
                        where a.ID == account.ID
                        select new
                        {
                            nqct.Ma_hanhdong
                        };
                List<string> list = new List<string>();
                for (int i = 0; i < l.ToList().Count; i++)
                {
                    list.Add(l.ToList()[i].Ma_hanhdong);
                }
                return list;
            }
            
            
        }
        public NhanVien GetNhanVien(Account account)
        {
            using(PBL3Entities db = new PBL3Entities())
            {
                var l = from n in db.NhanViens
                        join acc in db.Accounts on n.MaNhanVien equals acc.MaNhanVien
                        where acc.MaNhanVien == account.MaNhanVien
                        select n;
                return l.FirstOrDefault();
            }
        }

    }
}
