//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cuahangdienthoai
{
    using System;
    using System.Collections.Generic;
    
    public partial class GiamGia
    {
        public int ID { get; set; }
        public Nullable<int> maHoaDon { get; set; }
        public Nullable<int> maKhuyenMai { get; set; }
    
        public virtual KhuyenMai KhuyenMai { get; set; }
        public virtual HoaDonBanHang HoaDonBanHang { get; set; }
    }
}
