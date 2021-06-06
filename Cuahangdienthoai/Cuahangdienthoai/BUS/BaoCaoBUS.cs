using Cuahangdienthoai.DAL;
using Cuahangdienthoai.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuahangdienthoai.BUS
{
    class BaoCaoBUS
    {
        private static BaoCaoBUS _Instance;
        public static BaoCaoBUS Instance
        {
            get
            {
                if (_Instance == null) _Instance = new BaoCaoBUS();
                return _Instance;
            }
            private set
            {

            }
        }
        public Double GetTongTien(DateTime fisrtTime,DateTime lastTime)
        {
            return BaoCaoDAL.Instance.GetTongTien(fisrtTime, lastTime);
        }
        public int CountHoaDon(DateTime firstTime, DateTime lastTime)
        {
            return BaoCaoDAL.Instance.CountHoaDon(firstTime, lastTime);
        }
        public int CountKhachHang(DateTime firstTime, DateTime lastTime)
        {
            return BaoCaoDAL.Instance.CountKhachHang(firstTime, lastTime);
        }
        public double GetLoiNhuan(DateTime firstTime, DateTime lastTime)
        {
            return BaoCaoDAL.Instance.GetLoiNhuan(firstTime, lastTime);
        }
        public List<DoanhThuLoiNhuan> GetDoanhThuLoiNhuan(int i)
        {
            if (i == 0)
            {
                return BaoCaoDAL.Instance.GetHoaDonTheoNgay();
            } else if (i == 1)
            {
                return BaoCaoDAL.Instance.GetHoaDonTheoTuan();
            } else if (i == 2)
            {
                return BaoCaoDAL.Instance.GetHoaDonTheoThang();
            }
            return null;
        }
    }
}
