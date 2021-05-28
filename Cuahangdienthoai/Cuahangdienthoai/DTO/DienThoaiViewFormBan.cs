using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuahangdienthoai.DTO
{
    public class DienThoaiViewFormBan
    {
        public Image Anh { get; set; }
        public int MaDT { get; set; }
        public string TenDT { get; set; }
        public float DonGia { get; set; }
        public float PtGiamGia { get; set; }
        public float GiaSauGiam { get; set; }
        public int SoLuong { get; set; }
        public double TongTien { get; set; }
        public double Giam { get; set; }
        public double ThanhTien { get; set; }
    }
}
