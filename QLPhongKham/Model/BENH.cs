namespace QLPhongKham.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BENH")]
    public partial class BENH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BENH()
        {
            BENHNHANs = new HashSet<BENHNHAN>();
        }

        [Key]
        [StringLength(5)]
        public string MaBenh { get; set; }

        [Required]
        [StringLength(30)]
        public string TenBenh { get; set; }

        [Required]
        [StringLength(50)]
        public string TrieuChung { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BENHNHAN> BENHNHANs { get; set; }
    }
}
