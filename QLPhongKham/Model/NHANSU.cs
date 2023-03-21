namespace QLPhongKham.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANSU")]
    public partial class NHANSU
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANSU()
        {
            BENHNHANs = new HashSet<BENHNHAN>();
        }

        [Key]
        [StringLength(5)]
        public string MaNS { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgaySinh { get; set; }

        [Required]
        [StringLength(5)]
        public string GioiTinh { get; set; }

        [Required]
        [StringLength(5)]
        public string MaKhoa { get; set; }

        [Required]
        [StringLength(5)]
        public string MaCV { get; set; }

        [Required]
        [StringLength(10)]
        public string SDT { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayVaoLam { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BENHNHAN> BENHNHANs { get; set; }

        public virtual CHUCVU CHUCVU { get; set; }

        public virtual KHOA KHOA { get; set; }
    }
}
