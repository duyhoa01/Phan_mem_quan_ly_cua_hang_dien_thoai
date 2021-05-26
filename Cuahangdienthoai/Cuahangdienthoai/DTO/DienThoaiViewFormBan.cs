using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuahangdienthoai.DTO
{
    class DienThoaiViewFormBan
    {
        public Image Anh { get; set; }
        public int MaDT { get; set; }
        public string TenDT { get; set; }
        public string DonGia { get; set; }
        public string GiaSauGiam { get; set; }
        public int SoLuong { get; set; }
        public string Tong { get; set; }
    }
}
