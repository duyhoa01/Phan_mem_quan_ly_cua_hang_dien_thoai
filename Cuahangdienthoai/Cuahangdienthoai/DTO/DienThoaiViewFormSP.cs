﻿using System;
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
        public string GiaNhap { get; set; }
        public string GiaBan { get; set; }
        public string PtGiamGia { get; set; }
        public string DiemDanhGia { get; set; }
        public string LinkAnh { get; set; }
    }
}
