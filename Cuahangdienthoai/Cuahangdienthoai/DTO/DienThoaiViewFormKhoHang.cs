using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuahangdienthoai.DTO
{
    class DienThoaiViewFormKhoHang
    {
        public Image Anh { get; set; }
        public int MaDT { get; set; }
        public string TenDT { get; set; }
        public int SoLuong { get; set; }
        public float GiaNhap { get; set; }
        public float GiaBan { get; set; }
        public int SLBanTrongNam { get; set; }
        public string DiemDanhGia { get; set; }
        public string LinkAnh { get; set; }
    }
}
