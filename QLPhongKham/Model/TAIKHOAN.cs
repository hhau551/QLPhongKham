namespace QLPhongKham.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TAIKHOAN")]
    public partial class TAIKHOAN
    {
        [Key]
        [StringLength(20)]
        public string TenDN { get; set; }

        [Required]
        [StringLength(20)]
        public string MatKhau { get; set; }
    }
}
