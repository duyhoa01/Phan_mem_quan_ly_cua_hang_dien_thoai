using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuahangdienthoai.DAL
{
    public class DienThoaiDAL
    {
        private static DienThoaiDAL _instance;
        public static DienThoaiDAL Instance
        {
            get { if (_instance == null) _instance = new DienThoaiDAL(); return DienThoaiDAL._instance; }
            private set { DienThoaiDAL._instance = value; }
        }
        private DienThoaiDAL() { DienThoaiDAL._instance = null; }
        public void ThemDT(string TenDT, float GiaNhap, float GiaBan, float PtGiamGia, float DiemDanhGia
            , int LuotDanhGia, string ThongSoKyThuat, string Anh)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                DienThoai dt = new DienThoai 
                {
                    TenDienThoai = TenDT,
                    GiaNhapDT = GiaNhap,
                    GiaBanDT = GiaBan,
                    C_GiamGia = PtGiamGia,
                    DiemDanhGia = DiemDanhGia,
                    LuotDanhGia = LuotDanhGia,
                    SLBanRaTrongNam = 0,
                    ThongSoKyThuat = ThongSoKyThuat,
                    SLHienTai = 0,
                    Anh = Anh,
                };
                db.DienThoais.Add(dt);
                db.SaveChanges();
            }
        }
        public DienThoai TimDTByMaDT(int MaDT)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                return db.DienThoais.Find(MaDT);
            }
        }
        public bool XoaDT(DienThoai dt)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                bool oldValidateOnSaveEnabled = db.Configuration.ValidateOnSaveEnabled;

                try
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.DienThoais.Attach(dt);
                    db.Entry(dt).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    db.Configuration.ValidateOnSaveEnabled = oldValidateOnSaveEnabled;
                }
            }
        }
        public List<DienThoai> GetListDT(string TimKiem, string SapXep, string PhanKhuc)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                double GiaMin;
                double GiaMax;
                switch (PhanKhuc)
                {
                    case "Dưới 2 triệu":
                        {
                            GiaMin = 0;
                            GiaMax = 1999999;
                            break;
                        }
                    case "Từ 2 - 4 triệu":
                        {
                            GiaMin = 2000000;
                            GiaMax = 4000000;
                            break;
                        }
                    case "Từ 4 - 7 triệu":
                        {
                            GiaMin = 4000000;
                            GiaMax = 7000000;
                            break;
                        }
                    case "Từ 7 - 13 triệu":
                        {
                            GiaMin = 7000000;
                            GiaMax = 13000000;
                            break;
                        }
                    case "Từ 13 - 20 triệu":
                        {
                            GiaMin = 13000000;
                            GiaMax = 20000000;
                            break;
                        }
                    case "Trên 20 triệu":
                        {
                            GiaMin = 20000001;
                            GiaMax = float.MaxValue;
                            break;
                        }
                    default:
                        GiaMin = 0;
                        GiaMax = float.MaxValue;
                        break;
                }
                switch (SapXep)
                {
                    case "Tên từ A->Z":
                        return db.DienThoais.Where(p => (p.TenDienThoai.Contains(TimKiem) || p.MaDT.ToString().Contains(TimKiem))
                                                    && (p.GiaBanDT >= GiaMin) && (p.GiaBanDT <= GiaMax)).Select(p => p)
                                            .OrderBy(p => p.TenDienThoai).ToList();
                    case "Tên từ Z->A":
                        return db.DienThoais.Where(p => (p.TenDienThoai.Contains(TimKiem) || p.MaDT.ToString().Contains(TimKiem))
                                                    && (p.GiaBanDT >= GiaMin) && (p.GiaBanDT <= GiaMax)).Select(p => p)
                                            .OrderByDescending(p => p.TenDienThoai).ToList();
                    case "Giá tăng dần":
                        return db.DienThoais.Where(p => (p.TenDienThoai.Contains(TimKiem) || p.MaDT.ToString().Contains(TimKiem))
                                                    && (p.GiaBanDT >= GiaMin) && (p.GiaBanDT <= GiaMax)).Select(p => p)
                                            .OrderBy(p => p.GiaBanDT).ToList();
                    case "Giá giảm dần":
                        return db.DienThoais.Where(p => (p.TenDienThoai.Contains(TimKiem) || p.MaDT.ToString().Contains(TimKiem))
                                                    && (p.GiaBanDT >= GiaMin) && (p.GiaBanDT <= GiaMax)).Select(p => p)
                                            .OrderByDescending(p => p.GiaBanDT).ToList();
                    case "Đánh giá cao":
                        return db.DienThoais.Where(p => (p.TenDienThoai.Contains(TimKiem) || p.MaDT.ToString().Contains(TimKiem))
                                                    && (p.GiaBanDT >= GiaMin) && (p.GiaBanDT <= GiaMax)).Select(p => p)
                                            .OrderByDescending(p => p.DiemDanhGia).ToList();
                    default:
                        return db.DienThoais.Where(p => (p.TenDienThoai.Contains(TimKiem) || p.MaDT.ToString().Contains(TimKiem))
                                                    && (p.GiaBanDT >= GiaMin) && (p.GiaBanDT <= GiaMax)).Select(p => p).ToList();
                }
            }
        }
        public bool SuaDT(int MaDT, string TenDT, float PtGiamGia, float DiemDanhGia
            , int LuotDanhGia, string ThongSoKyThuat, string Anh, float GiaBan, float GiaNhap)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                DienThoai dt = db.DienThoais.Find(MaDT);
                if((dt.GiaBanDT != GiaBan) || (dt.GiaNhapDT != GiaNhap))
                {
                    if (db.HoaDonChiTiets.FirstOrDefault(p => p.MaDT == MaDT) != null) return false;
                    if (db.HoaDonNhapChiTiets.FirstOrDefault(p => p.MaDT == MaDT) != null) return false;
                }
                dt.GiaNhapDT = GiaNhap;
                dt.GiaBanDT = GiaBan;
                dt.TenDienThoai = TenDT;
                dt.C_GiamGia = PtGiamGia;
                dt.DiemDanhGia = DiemDanhGia;
                dt.LuotDanhGia = LuotDanhGia;
                dt.ThongSoKyThuat = ThongSoKyThuat;
                dt.Anh = Anh;
                db.SaveChanges();
                return true;
            }
        }
        public void XuLyBanDT(int MaDT, int SoLuong)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                DienThoai dt = db.DienThoais.Find(MaDT);
                dt.SLHienTai -= SoLuong;
                dt.SLBanRaTrongNam += SoLuong;
                db.SaveChanges();
            }
        }
        public void XuLyNhapDT(int MaDT, int SoLuong)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                DienThoai dt = db.DienThoais.Find(MaDT);
                dt.SLHienTai += SoLuong;
                db.SaveChanges();
            }
        }
    }
}
