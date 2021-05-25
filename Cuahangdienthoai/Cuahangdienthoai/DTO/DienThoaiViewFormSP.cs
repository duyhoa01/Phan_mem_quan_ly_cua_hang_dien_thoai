using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuahangdienthoai.DTO
{
    public class DienThoaiViewFormSP
    {
        public Image Anh { get; set; }
        public int MaDT { get; set; }
        public string TenDT { get; set; }
        public int SoLuong { get; set; }
        public float GiaNhap { get; set; }
        public float GiaBan { get; set; }
        public float PtGiamGia { get; set; }
        public float DiemDanhGia { get; set; }
        public int LuotDanhGia { get; set; }
    }
}
