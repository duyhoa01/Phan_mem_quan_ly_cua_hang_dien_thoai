using Cuahangdienthoai.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cuahangdienthoai.DAL
{
    class BaoCaoDAL
    {
        private static BaoCaoDAL _Instance;
        public static BaoCaoDAL Instance
        {
            get
            {
                if (_Instance == null) _Instance = new BaoCaoDAL();
                return _Instance;
            }
            private set
            {

            }
        }
        public double GetTongTien(DateTime fistTime,DateTime lastTime)
        { 
            using(PBL3Entities db = new PBL3Entities())
            {
                var l = db.HoaDonBanHangs.Where(p => p.NgayBan >= fistTime && p.NgayBan < lastTime).Sum(p => p.TongTien);
                return Convert.ToDouble(l);
            }      
        }
        public int CountHoaDon(DateTime firstTime,DateTime lastTime)
        {
            using(PBL3Entities db = new PBL3Entities())
            {
                var l = db.HoaDonBanHangs.Where(p => p.NgayBan >= firstTime && p.NgayBan < lastTime).Count();
                return l;
            }  
        }
        public int CountKhachHang(DateTime firstTime, DateTime lastTime)
        {
            using(PBL3Entities db = new PBL3Entities())
            {
                var l = db.HoaDonBanHangs.Where(p => p.NgayBan >= firstTime && p.NgayBan < lastTime)
                .GroupBy(p => p.MaKhachHang).Count();
                return l;
            }      
        }
        public double GetLoiNhuan(DateTime firstTime, DateTime lastTime)
        {
            using(PBL3Entities db = new PBL3Entities())
            {
                var l = db.HoaDonBanHangs.Where(p => p.NgayBan >= firstTime && p.NgayBan < lastTime).Sum(p => p.TongLoiNhuan);
                return Convert.ToDouble(l);
            }       
        }
        public List<DoanhThuLoiNhuan> GetHoaDonTheoNgay()
        {
            List<DoanhThuLoiNhuan> list = new List<DoanhThuLoiNhuan>();
            using (PBL3Entities db = new PBL3Entities())
            {
                DateTime firstTime = DateTime.Now.Date.AddDays(-1);
                DateTime lastTime = DateTime.Now.Date;
                for (int i = 0; i < 7; i++)
                {
                    var l = db.HoaDonBanHangs
                        .Where(p => p.NgayBan >= firstTime && p.NgayBan < lastTime)
                        .Select(p => new
                        {
                            p.TongTien,
                            p.TongLoiNhuan
                        });
                    DoanhThuLoiNhuan d = new DoanhThuLoiNhuan();
                    double s1 = 0, s2 = 0;
                    foreach (var h in l)
                    {
                        s1 += Double.Parse(h.TongTien.ToString());
                        s2 += Double.Parse(h.TongLoiNhuan.ToString());
                    }
                    d.ThoiGian = "ngày " + firstTime.Day.ToString();
                    d.DoanhThu = s1;
                    d.LoiNhuan = s2;
                    firstTime = firstTime.AddDays(-1);
                    lastTime = lastTime.AddDays(-1);
                    list.Add(d);

                }
                return list;
            }      
        }
        public List<DoanhThuLoiNhuan> GetHoaDonTheoTuan()
        {
            List<DoanhThuLoiNhuan> list = new List<DoanhThuLoiNhuan>();
            using(PBL3Entities db = new PBL3Entities())
            {
                DateTime firstTime =NgayCuaTuan(NgayCuaTuan(DateTime.Now.Date).AddDays(-1));
                DateTime lastTime = NgayCuaTuan(DateTime.Now.Date);
                for (int i = 0; i < 4; i++)
                {
                    var l = db.HoaDonBanHangs
                        .Where(p => p.NgayBan >= firstTime && p.NgayBan < lastTime)
                        .Select(p => new
                        {
                            p.TongTien,
                            p.TongLoiNhuan
                        });
                    DoanhThuLoiNhuan d = new DoanhThuLoiNhuan();
                    double s1 = 0, s2 = 0;
                    foreach (var h in l)
                    {
                        s1 += Double.Parse(h.TongTien.ToString());
                        s2 += Double.Parse(h.TongLoiNhuan.ToString());
                    }
                    d.ThoiGian = "ngày " + firstTime.Day.ToString() + "->" + lastTime.AddDays(-1).Day.ToString();
                    d.DoanhThu = s1;
                    d.LoiNhuan = s2;
                    firstTime = firstTime.AddDays(-7);
                    lastTime = firstTime.AddDays(7);
                    list.Add(d);

                }
                return list;
            }       
        }
        public static DateTime NgayCuaTuan(DateTime date)
        {
            var dayOfWeek = date.DayOfWeek;
            if (dayOfWeek == DayOfWeek.Sunday)
            {
                DateTime dateTime = date.AddDays(-6);

                return date.AddDays(-6);
            }
            int offset = dayOfWeek - DayOfWeek.Monday;
            return date.AddDays(-offset);
        }
        public List<DoanhThuLoiNhuan> GetHoaDonTheoThang()
        {
            List<DoanhThuLoiNhuan> list = new List<DoanhThuLoiNhuan>();
            using(PBL3Entities db = new PBL3Entities())
            {
                DateTime firstTime = GetFistDayInMonth(GetFistDayInMonth(DateTime.Now.Year, DateTime.Now.Month).AddDays(-1).Year,
                   GetFistDayInMonth(DateTime.Now.Year, DateTime.Now.Month).AddDays(-1).Month);
                DateTime lastTime = GetFistDayInMonth(DateTime.Now.Year, DateTime.Now.Month);
                for (int i = 0; i < 6; i++)
                {
                    var l = db.HoaDonBanHangs
                        .Where(p => p.NgayBan >= firstTime && p.NgayBan < lastTime)
                        .Select(p => new
                        {
                            p.TongTien,
                            p.TongLoiNhuan
                        });
                    DoanhThuLoiNhuan d = new DoanhThuLoiNhuan();
                    double s1 = 0, s2 = 0;
                    foreach (var h in l)
                    {
                        s1 += Double.Parse(h.TongTien.ToString());
                        s2 += Double.Parse(h.TongLoiNhuan.ToString());
                    }
                    d.ThoiGian = "tháng " + firstTime.Month;
                    d.DoanhThu = s1;
                    d.LoiNhuan = s2;
                    lastTime = firstTime;
                    firstTime = GetFistDayInMonth(firstTime.AddDays(-1).Year, firstTime.AddDays(-1).Month);
                    list.Add(d);

                }
                return list;
            }  
        }
        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime dateTime = new DateTime(year, month, 1);
            return dateTime;
        }
    }
}
