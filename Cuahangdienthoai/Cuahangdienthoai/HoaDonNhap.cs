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
    
    public partial class HoaDonNhap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HoaDonNhap()
        {
            this.HoaDonNhapChiTiets = new HashSet<HoaDonNhapChiTiet>();
        }
    
        public int MaHoaDon { get; set; }
        public Nullable<int> MaNhanVien { get; set; }
        public Nullable<System.DateTime> NgayNhap { get; set; }
        public Nullable<double> TongTienNhap { get; set; }
        public Nullable<int> MaNhaCungCap { get; set; }
    
        public virtual NhaCungCap NhaCungCap { get; set; }
        public virtual NhanVien NhanVien { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonNhapChiTiet> HoaDonNhapChiTiets { get; set; }
    }
}
