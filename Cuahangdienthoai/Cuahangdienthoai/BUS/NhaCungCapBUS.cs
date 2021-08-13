using Cuahangdienthoai.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuahangdienthoai.BUS
{
    class NhaCungCapBUS
    {
        private static NhaCungCapBUS _Intance;
        public static NhaCungCapBUS Intance
        {
            get
            {
                if (_Intance == null)
                {
                    _Intance = new NhaCungCapBUS();
                }
                return _Intance;
            }
            private set { _Intance = value; }
        }
        public NhaCungCapBUS()
        {
            _Intance = null;
        }
        public NhaCungCap getnccbus(int mncc)
        {
            return NhaCungCapDAL.Intance.getnccdal(mncc);
        }
        public List<NhaCungCap> getlisnccbus()
        {
            return NhaCungCapDAL.Intance.getlistncc();
        }
        public void xoa_nccBus(int mncc)
        {
            NhaCungCapDAL.Intance.XoaNhaCungCapdall(mncc);
        }
        public void extbus(NhaCungCap s)
        {
            bool check = false;
            foreach (NhaCungCap i in NhaCungCapDAL.Intance.getlistncc())
            {
                if (s.MaNhanCungCap == i.MaNhanCungCap)
                {
                    check = true;
                }
            }
            if (check)
            {
                editbus(s);
            }
            else
            {
                addbus(s);
            }

        }
        public void editbus(NhaCungCap s)
        {
            NhaCungCapDAL.Intance.editdal(s);
        }
        public void addbus(NhaCungCap s)
        {
            NhaCungCapDAL.Intance.addncc(s);
        }
        public List<NhaCungCap> getlistnamebus(string name)
        {
            if (name == null)
            {
                return getlisnccbus();
            }
            else
            {
                return NhaCungCapDAL.Intance.getlistname(name);
            }
        }
        public int GetIDNhaCCNew()
        {
            return NhaCungCapDAL.Intance.GetIDNhaCCNew();
        }
    }
}
