using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuahangdienthoai.DTO
{
    public class DienThoaiFormMua
    {
        public Image Anh { get; set; }
        public int MaDT { get; set; }
        public string TenDT { get; set; }
        public float GiaNhap { get; set; }
        public int SoLuong { get; set; }
        public double ThanhTien { get; set; }
    }
}
