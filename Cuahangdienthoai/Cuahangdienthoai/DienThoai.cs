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
    
    public partial class DienThoai
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DienThoai()
        {
            this.HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
            this.HoaDonNhapChiTiets = new HashSet<HoaDonNhapChiTiet>();
        }
    
        public int MaDT { get; set; }
        public string TenDienThoai { get; set; }
        public Nullable<double> GiaNhapDT { get; set; }
        public Nullable<double> GiaBanDT { get; set; }
        public Nullable<int> SLHienTai { get; set; }
        public Nullable<int> SLBanRaTrongNam { get; set; }
        public Nullable<double> C_GiamGia { get; set; }
        public string ThongSoKyThuat { get; set; }
        public Nullable<double> DiemDanhGia { get; set; }
        public Nullable<int> LuotDanhGia { get; set; }
        public string Anh { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonNhapChiTiet> HoaDonNhapChiTiets { get; set; }
    }
}