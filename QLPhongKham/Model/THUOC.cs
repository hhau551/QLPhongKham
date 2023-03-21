namespace QLPhongKham.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("THUOC")]
    public partial class THUOC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public THUOC()
        {
            BENHNHANs = new HashSet<BENHNHAN>();
            HOADONs = new HashSet<HOADON>();
        }

        [Key]
        [StringLength(5)]
        public string MaThuoc { get; set; }

        [Required]
        [StringLength(30)]
        public string TenThuoc { get; set; }

        [Required]
        [StringLength(2)]
        public string HSD { get; set; }

        public double DonGia { get; set; }

        public int SoLuongCon { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BENHNHAN> BENHNHANs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
