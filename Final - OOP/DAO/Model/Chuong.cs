//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final___OOP.DAO.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Chuong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chuong()
        {
            this.CauHois = new HashSet<CauHoi>();
        }
    
        public string MaChuong { get; set; }
        public string TenChuong { get; set; }
        public string MaMH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CauHoi> CauHois { get; set; }
        public virtual MonHoc MonHoc { get; set; }
    }
}
