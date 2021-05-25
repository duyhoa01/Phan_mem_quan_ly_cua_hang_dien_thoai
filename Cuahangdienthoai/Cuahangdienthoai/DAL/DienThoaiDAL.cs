using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                DienThoai dt = new DienThoai {
                    TenDienThoai = TenDT,
                    GiaNhapDT = GiaNhap,
                    GiaBanDT = GiaBan,
                    C_GiamGia = PtGiamGia,
                    DiemDanhGia = DiemDanhGia,
                    LuotDanhGia = LuotDanhGia,
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
        public List<DienThoai> GetListDT(string TimKiem)
        {
            List<DienThoai> listDT = new List<DienThoai>();
            using (PBL3Entities db = new PBL3Entities())
            {
                //TimKiem = "N'%" + TimKiem + "%'";
                var list = db.USP_GetPhoneList("Xiaomi");
                return listDT;
            }
        }
    }
}
