namespace QLPhongKham.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [Key]
        [StringLength(5)]
        public string MaHD { get; set; }

        [Required]
        [StringLength(5)]
        public string MaKB { get; set; }

        [Required]
        [StringLength(50)]
        public string HoTen { get; set; }

        [Required]
        [StringLength(5)]
        public string MaThuoc { get; set; }

        public double DGThuoc { get; set; }

        [StringLength(5)]
        public string MaDV { get; set; }

        public double? DGDichVu { get; set; }

        public int? SoLuongDV { get; set; }

        public double ThanhTien { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayLapHD { get; set; }

        [Required]
        [StringLength(20)]
        public string TinhTrang { get; set; }

        public virtual DICHVU DICHVU { get; set; }

        public virtual KHAMBENH KHAMBENH { get; set; }

        public virtual THUOC THUOC { get; set; }
    }
}
