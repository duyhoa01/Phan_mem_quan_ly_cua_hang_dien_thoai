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
    
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            this.Accounts = new HashSet<Account>();
            this.HoaDonNhaps = new HashSet<HoaDonNhap>();
            this.HoaDonBanHangs = new HashSet<HoaDonBanHang>();
        }
    
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public Nullable<bool> Nam { get; set; }
        public string DiaChi { get; set; }
        public string CMND { get; set; }
        public string DienThoai { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string ChucVu { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Account> Accounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonNhap> HoaDonNhaps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonBanHang> HoaDonBanHangs { get; set; }
    }
}
