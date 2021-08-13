using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cuahangdienthoai.DAL
{
    class DAL_CHDT
    {
        public List<NhanVien> GetAllNV_DAL()
        {
            PBL3Entities db = new PBL3Entities();
            return db.NhanViens.ToList();
        }
        public void AddNV_DAL(NhanVien s)
        {
            PBL3Entities db = new PBL3Entities();
            db.NhanViens.Add(s);
            db.SaveChanges();
        }
        public void EditNV_DAL(NhanVien sedit)
        {
            PBL3Entities db = new PBL3Entities();
            NhanVien s = db.NhanViens.Find(sedit.MaNhanVien);
            //s = sedit;
            s.TenNhanVien = sedit.TenNhanVien;
            if (sedit.Nam == true) s.Nam = true;
            else s.Nam = false;
            s.DiaChi = sedit.DiaChi;
            s.CMND = sedit.CMND;
            s.DienThoai = sedit.DienThoai;
            s.NgaySinh = sedit.NgaySinh;
            s.ChucVu = sedit.ChucVu;
            db.SaveChanges();
        }
        public void DelNV_DAL(int MaNV)
        {
            PBL3Entities db = new PBL3Entities();
            NhanVien s = db.NhanViens.Find(MaNV);
            db.NhanViens.Remove(s);
            db.SaveChanges();
        }
        public List<KhachHang> GetAllKH_DAL()
        {
            PBL3Entities db = new PBL3Entities();
            return db.KhachHangs.ToList();
        }
        public void AddKH_DAL(KhachHang s)
        {
            PBL3Entities db = new PBL3Entities();
            db.KhachHangs.Add(s);
            db.SaveChanges();
        }
        public void EditKH_DAL(KhachHang sedit)
        {
            PBL3Entities db = new PBL3Entities();
            KhachHang s = db.KhachHangs.Find(sedit.MaKhachHang);
            //s = sedit;
            s.TenKhachHang = sedit.TenKhachHang;
            s.DiaChi = sedit.DiaChi;
            s.CMND = sedit.CMND;
            s.DienThoai = sedit.DienThoai;
            db.SaveChanges();
        }
        public void DelKH_DAL(int MaKH)
        {
            try
            {
                using (PBL3Entities db = new PBL3Entities())
                {
                    KhachHang s = db.KhachHangs.Find(MaKH);
                    db.KhachHangs.Remove(s);
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể xóa khách hàng này vì liên quan đến hóa đơn bán trước đó!", "Lỗi!");
            }
        }
        public KhachHang GetKHByCMND(string CMND)
        {
            using(PBL3Entities db = new PBL3Entities())
            {
                return (KhachHang)db.KhachHangs.Where(p => p.CMND == CMND).Select(p => p).FirstOrDefault();
            }
        }
        public int GetIDNewKH()
        {
            using(PBL3Entities db = new PBL3Entities())
            {
                return db.KhachHangs.ToList().LastOrDefault().MaKhachHang;
            }
        }
    }
}
