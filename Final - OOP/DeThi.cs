//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final___OOP
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeThi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeThi()
        {
            this.BaiLams = new HashSet<BaiLam>();
        }
    
        public string MaDeThi { get; set; }
        public string TenDeThi { get; set; }
        public System.TimeSpan TGlambai { get; set; }
        public int SoLuongCau { get; set; }
        public string NoiDungDeThi { get; set; }
        public string MaCB { get; set; }
        public string MaLop { get; set; }
        public string MaMH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaiLam> BaiLams { get; set; }
        public virtual Lophoc Lophoc { get; set; }
        public virtual MonHoc MonHoc { get; set; }
        public virtual ThongTinCB ThongTinCB { get; set; }
    }
}
