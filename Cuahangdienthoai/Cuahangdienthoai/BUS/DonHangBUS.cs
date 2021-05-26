using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuahangdienthoai.DAL;

namespace Cuahangdienthoai.BUS
{
    public class DonHangBUS
    {
        private static DonHangBUS _instance;
        public static DonHangBUS Instance
        {
            get { if (_instance == null) _instance = new DonHangBUS(); return DonHangBUS._instance; }
            private set { DonHangBUS._instance = value; }
        }
        private DonHangBUS() { DonHangBUS._instance = null; }
        public Object GetListDonHang(string TimKiem, DateTime NgayBD, DateTime NgayKT)
        {
            return DonHangDAL.Instance.GetListDonHang(TimKiem, NgayBD, NgayKT);
        }
    }
}
