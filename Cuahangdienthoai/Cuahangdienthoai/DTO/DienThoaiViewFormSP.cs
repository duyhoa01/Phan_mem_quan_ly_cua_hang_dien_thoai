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
        public float GiaGoc { get; set; }
        public float PtGiamGia { get; set; }
        public float GiamCon { get; set; }
        public string DiemDanhGia { get; set; }
        public string LinkAnh { get; set; }
    }
}
