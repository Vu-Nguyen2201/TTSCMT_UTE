//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyTTSCMT
{
    using System;
    using System.Collections.Generic;
    
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            this.LapTops = new HashSet<LapTop>();
        }
    
        public int ID { get; set; }
        public string Ten { get; set; }
        public string MSSV { get; set; }
        public string SDT { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MKTaiKhoan { get; set; }
        public bool LaQuanLy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LapTop> LapTops { get; set; }
    }
}
