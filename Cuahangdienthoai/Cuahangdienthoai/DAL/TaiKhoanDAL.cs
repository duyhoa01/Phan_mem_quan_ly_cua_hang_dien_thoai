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
        public object GetListAcc(string TimKiem)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                return db.Accounts.Where(p => p.MaNhanVien.ToString().Contains(TimKiem)
                                                || p.TenDangNhap.Contains(TimKiem)
                                                || p.NhanVien.TenNhanVien.Contains(TimKiem))
                    .Select(p => new
                {
                    p.ID,
                    p.MaNhanVien,
                    p.TenDangNhap,
                    p.LoaiTK,
                    p.NhanVien.TenNhanVien,
                    p.EmailKhoiPhuc,
                }).ToList();
            }
        }
        public List<NhanVien> GetListNVKhongAcc()
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                return db.NhanViens.Where(p => p.Accounts.FirstOrDefault() == null).Select(p => p).ToList();
            }
        }
        public void ThemAcc(Account acc)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                db.Accounts.Add(acc);
                db.SaveChanges();
            }
        }
        public void XoaAcc(int ID)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                db.Accounts.Remove(db.Accounts.Find(ID));
                db.PhanQuyenLienKets.RemoveRange(db.PhanQuyenLienKets.Where(p => p.MaAcc == ID).ToList());
                db.SaveChanges();
            }
        }
        public void SuaAcc(Account acc)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                Account accOld = db.Accounts.Find(acc.ID);
                accOld.TenDangNhap = acc.TenDangNhap;
                accOld.EmailKhoiPhuc = acc.EmailKhoiPhuc;
                if (!accOld.LoaiTK.Equals(acc.LoaiTK))
                {
                    accOld.LoaiTK = acc.LoaiTK;
                    db.PhanQuyenLienKets.RemoveRange(db.PhanQuyenLienKets.Where(p => p.MaAcc == acc.ID).ToList());
                }
                db.SaveChanges();
            }
        }
        public int GetMaIDMoi()
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                return db.Accounts.ToList().LastOrDefault().ID;
            }
        }
        public void ThemPhanQuyenLienKet(Account acc)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                if (acc.LoaiTK == "Admin")
                {
                    db.PhanQuyenLienKets.Add(new PhanQuyenLienKet { MaAcc = acc.ID, MaNhomQuyen = 1 });
                }
                db.PhanQuyenLienKets.Add(new PhanQuyenLienKet { MaAcc = acc.ID, MaNhomQuyen = 2 });
                db.SaveChanges();
            }
        }
        public void SuaAccByUser(Account newAcc)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                Account Acc = db.Accounts.Find(newAcc.ID);
                Acc.EmailKhoiPhuc = newAcc.EmailKhoiPhuc;
                Acc.AnhAcc = newAcc.AnhAcc;
                Acc.TenHienThi = newAcc.TenHienThi;
                Acc.MatKhau = newAcc.MatKhau;
                db.SaveChanges();
            }
        }
    }
}
