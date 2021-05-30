using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuahangdienthoai.DTO
{
    public class DienThoaiViewHDBCT
    {
        public Image Anh { get; set; }
        public int MaDT { get; set; }
        public string TenDT { get; set; }
        public float GiaBan { get; set; }
        public float PtGiamGia { get; set; }
        public float GiamCon { get; set; }
        public float GiaNhap { get; set; }
        public int SoLuong { get; set; }
        public double TongTien { get; set; }
        public double TongGiam { get; set; }
        public double ThanhTien { get; set; }
        public double TongGiaNhap { get; set; }
    }
}
