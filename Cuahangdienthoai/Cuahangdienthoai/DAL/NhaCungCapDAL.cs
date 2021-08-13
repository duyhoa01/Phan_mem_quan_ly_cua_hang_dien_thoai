using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cuahangdienthoai.DAL
{
    class NhaCungCapDAL
    {
        private static NhaCungCapDAL _Intance;
        public static NhaCungCapDAL Intance
        {
            get
            {
                if (_Intance == null)
                {
                    _Intance = new NhaCungCapDAL();
                }
                return _Intance;
            }
            private set { _Intance = value; }
        }
        public NhaCungCapDAL()
        {
            _Intance = null;
        }
        public void XoaNhaCungCapdall(int MaNCC)
        {
            try
            {
                using (PBL3Entities db = new PBL3Entities())
                {
                    db.NhaCungCaps.Remove(db.NhaCungCaps.Find(MaNCC));
                    db.SaveChanges();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể xóa nhà cung cấp này vì liên quan đến hóa đơn nhập trước đó!", "Lỗi!");
            }
        }
        public List<NhaCungCap> getlistncc()
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                return db.NhaCungCaps.ToList().Select(p => new NhaCungCap {MaNhanCungCap = p.MaNhanCungCap, 
                    TenNhaCungCap = p.TenNhaCungCap,
                    DiaChi = p.DiaChi,
                    SoDienThoai = p.SoDienThoai,
                    Email = p.Email }).ToList();
            }
        }
        public void addncc(NhaCungCap s)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                db.NhaCungCaps.Add(s);
                db.SaveChanges();
            }
        }
        public void editdal(NhaCungCap s)
        {
            using (PBL3Entities db = new PBL3Entities())
            {
                NhaCungCap nc = db.NhaCungCaps.Find(s.MaNhanCungCap);
                nc.TenNhaCungCap = s.TenNhaCungCap;
                nc.SoDienThoai = s.SoDienThoai;
                nc.Email = s.Email;
                nc.DiaChi = s.DiaChi;
                db.SaveChanges();
            }
        }
        public NhaCungCap getnccdal(int mncc)
        {
            foreach (NhaCungCap i in getlistncc())
            {
                if (i.MaNhanCungCap == mncc)
                {
                    return i;
                }
            }
            return null;
        }
        public List<NhaCungCap> getlistname(string name)
        {
            List<NhaCungCap> data = new List<NhaCungCap>();
            foreach (NhaCungCap i in getlistncc())
            {
                if (i.TenNhaCungCap.Contains(name))
                {
                    data.Add(i);
                }
            }
            return data;
        }
        public int GetIDNhaCCNew()
        {
            using(PBL3Entities db = new PBL3Entities())
            {
                return db.NhaCungCaps.ToList().LastOrDefault().MaNhanCungCap;
            }
        }
    }
}
