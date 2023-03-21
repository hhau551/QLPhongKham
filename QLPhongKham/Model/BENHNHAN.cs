namespace QLPhongKham.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BENHNHAN")]
    public partial class BENHNHAN
    {
        [Key]
        [StringLength(5)]
        public string MaBN { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayKham { get; set; }

        [Required]
        [StringLength(5)]
        public string MaKB { get; set; }

        [Required]
        [StringLength(5)]
        public string MaBenh { get; set; }

        [Required]
        [StringLength(5)]
        public string MaThuoc { get; set; }

        [Required]
        [StringLength(5)]
        public string MaNS { get; set; }

        [Required]
        [StringLength(5)]
        public string MaCV { get; set; }

        public virtual BENH BENH { get; set; }

        public virtual CHUCVU CHUCVU { get; set; }

        public virtual KHAMBENH KHAMBENH { get; set; }

        public virtual NHANSU NHANSU { get; set; }

        public virtual THUOC THUOC { get; set; }
    }
}
