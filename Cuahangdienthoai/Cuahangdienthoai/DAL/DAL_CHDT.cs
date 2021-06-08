using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuahangdienthoai.DAL
{
    class DAL_CHDT
    {
        public List<NhanVien> GetAllNV_DAL()
        {
            CHDT_DB db = new CHDT_DB();
            return db.NhanViens.ToList();
        }
        public void AddNV_DAL(NhanVien s)
        {
            CHDT_DB db = new CHDT_DB();
            db.NhanViens.Add(s);
            db.SaveChanges();
        }
        public void EditNV_DAL(NhanVien sedit)
        {
            CHDT_DB db = new CHDT_DB();
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
            CHDT_DB db = new CHDT_DB();
            NhanVien s = db.NhanViens.Find(MaNV);
            db.NhanViens.Remove(s);
            db.SaveChanges();
        }
        public List<KhachHang> GetAllKH_DAL()
        {
            CHDT_DB db = new CHDT_DB();
            return db.KhachHangs.ToList();
        }
        public void AddKH_DAL(KhachHang s)
        {
            CHDT_DB db = new CHDT_DB();
            db.KhachHangs.Add(s);
            db.SaveChanges();
        }
        public void EditKH_DAL(KhachHang sedit)
        {
            CHDT_DB db = new CHDT_DB();
            KhachHang s = db.KhachHangs.Find(sedit.MaKhachHang);
            //s = sedit;
            /*s.TenNhanVien = sedit.TenNhanVien;
            if (sedit.Nam == true) s.Nam = true;
            else s.Nam = false;
            s.DiaChi = sedit.DiaChi;
            s.CMND = sedit.CMND;
            s.DienThoai = sedit.DienThoai;
            s.NgaySinh = sedit.NgaySinh;
            s.ChucVu = sedit.ChucVu;*/
            s.TenKhachHang = "Sua roi";
            db.SaveChanges();
        }
        public void DelKH_DAL(int MaKH)
        {
            CHDT_DB db = new CHDT_DB();
            KhachHang s = db.KhachHangs.Find(MaKH);
            db.KhachHangs.Remove(s);
            db.SaveChanges();
        }
    }
}
