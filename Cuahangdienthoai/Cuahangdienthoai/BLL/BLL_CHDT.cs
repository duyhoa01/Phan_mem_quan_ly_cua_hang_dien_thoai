using Cuahangdienthoai.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuahangdienthoai.BLL
{
    class BLL_CHDT
    {
        public List<NhanVien> GetAllNV_BLL()
        {
            DAL_CHDT dal = new DAL_CHDT();
            return dal.GetAllNV_DAL();
        }
        public NhanVien GetNVByMaNV_BLL(int MaNV)
        {
            DAL_CHDT dal = new DAL_CHDT();
            foreach(NhanVien i in dal.GetAllNV_DAL())
            {
                if (i.MaNhanVien == MaNV) return i;
            }
            return null;
        }
        public void AddNV_BLL(NhanVien s)
        {
            DAL_CHDT dal = new DAL_CHDT();
            bool check = true;
            foreach(NhanVien i in GetAllNV_BLL())
            {
                if(i.MaNhanVien == s.MaNhanVien)
                {
                    check = false;
                    break;
                }    
            }
            if (check == true) dal.AddNV_DAL(s);
        }
        public void EditNV_BLL(NhanVien s)
        {
            DAL_CHDT dal = new DAL_CHDT();
            dal.EditNV_DAL(s);
        }
        public void DelNV_BLL(int MaNV)
        {
            DAL_CHDT dal = new DAL_CHDT();
            dal.DelNV_DAL(MaNV);
        }



        public List<KhachHang> GetAllKH_BLL()
        {
            DAL_CHDT dal = new DAL_CHDT();
            return dal.GetAllKH_DAL();
        }
        public KhachHang GetKHByMaNV_BLL(int MaKH)
        {
            DAL_CHDT dal = new DAL_CHDT();
            foreach (KhachHang i in dal.GetAllKH_DAL())
            {
                if (i.MaKhachHang == MaKH) return i;
            }
            return null;
        }
        public void AddKH_BLL(KhachHang s)
        {
            DAL_CHDT dal = new DAL_CHDT();
            bool check = true;
            foreach (KhachHang i in GetAllKH_BLL())
            {
                if (i.MaKhachHang == s.MaKhachHang)
                {
                    check = false;
                    break;
                }
            }
            if (check == true) dal.AddKH_DAL(s);
        }
        public void EditKH_BLL(KhachHang s)
        {
            DAL_CHDT dal = new DAL_CHDT();
            dal.EditKH_DAL(s);
        }
        public void DelKH_BLL(int MaKH)
        {
            DAL_CHDT dal = new DAL_CHDT();
            dal.DelKH_DAL(MaKH);
        }
    }
}
