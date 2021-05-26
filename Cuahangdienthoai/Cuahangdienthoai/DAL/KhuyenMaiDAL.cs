using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuahangdienthoai.DAL
{
    public class KhuyenMaiDAL
    {
        private static KhuyenMaiDAL _instance;
        public static KhuyenMaiDAL Instance
        {
            get { if (_instance == null) _instance = new KhuyenMaiDAL(); return KhuyenMaiDAL._instance; }
            private set { KhuyenMaiDAL._instance = value; }
        }
        private KhuyenMaiDAL() { KhuyenMaiDAL._instance = null; }
        public List<KhuyenMai> GetListKM()
        {
            DateTime today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            using(PBL3Entities db = new PBL3Entities())
            {
                return db.KhuyenMais.Where(p => p.ngayketthuc >= today).Select(p => p).ToList();
            }
        }
        public void XoaKM(int MaKM)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                db.KhuyenMais.Remove(db.KhuyenMais.Find(MaKM));
                db.SaveChanges();
            }
        }
        public void ThemKM(string TenKM, DateTime NgayBatDau, DateTime NgayKetThuc, float TienToiThieu, Decimal PtGiamGia, float GiamGiaMax)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                KhuyenMai km = new KhuyenMai();
                km.tenkhuyenmai = TenKM;
                km.ngaybatdau = NgayBatDau;
                km.ngayketthuc = NgayKetThuc;
                km.tientoithieu = TienToiThieu;
                km.phantram = Convert.ToDecimal(PtGiamGia);
                km.khuyenmaitoida = GiamGiaMax;
                db.KhuyenMais.Add(km);
                db.SaveChanges();
            }
        }
        public void SuaKM(int MaKM, string TenKM, DateTime NgayBatDau, DateTime NgayKetThuc, float TienToiThieu, Decimal PtGiamGia, float GiamGiaMax)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                KhuyenMai km = db.KhuyenMais.Find(MaKM);
                km.tenkhuyenmai = TenKM;
                km.ngaybatdau = NgayBatDau;
                km.ngayketthuc = NgayKetThuc;
                km.tientoithieu = TienToiThieu;
                km.phantram = Convert.ToDecimal(PtGiamGia);
                km.khuyenmaitoida = GiamGiaMax;
                db.SaveChanges();
            }
        }
        public void AnKM(int MaKM)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                KhuyenMai km = db.KhuyenMais.Find(MaKM);
                km.ngayketthuc = DateTime.Now.AddDays(-1);
            }
        }
    }
}
