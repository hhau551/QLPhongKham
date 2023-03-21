using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLPhongKham.Model
{
    public partial class QuanLyPK_DB : DbContext
    {
        public QuanLyPK_DB()
            : base("name=QuanLyPK_DB")
        {
        }

        public virtual DbSet<BENH> BENHs { get; set; }
        public virtual DbSet<BENHNHAN> BENHNHANs { get; set; }
        public virtual DbSet<CHUCVU> CHUCVUs { get; set; }
        public virtual DbSet<DICHVU> DICHVUs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHAMBENH> KHAMBENHs { get; set; }
        public virtual DbSet<KHOA> KHOAs { get; set; }
        public virtual DbSet<NHANSU> NHANSUs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TAIKHOAN> TAIKHOANs { get; set; }
        public virtual DbSet<THUOC> THUOCs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BENH>()
                .Property(e => e.MaBenh)
                .IsFixedLength();

            modelBuilder.Entity<BENH>()
                .HasMany(e => e.BENHNHANs)
                .WithRequired(e => e.BENH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BENHNHAN>()
                .Property(e => e.MaBN)
                .IsFixedLength();

            modelBuilder.Entity<BENHNHAN>()
                .Property(e => e.MaKB)
                .IsFixedLength();

            modelBuilder.Entity<BENHNHAN>()
                .Property(e => e.MaBenh)
                .IsFixedLength();

            modelBuilder.Entity<BENHNHAN>()
                .Property(e => e.MaThuoc)
                .IsFixedLength();

            modelBuilder.Entity<BENHNHAN>()
                .Property(e => e.MaNS)
                .IsFixedLength();

            modelBuilder.Entity<BENHNHAN>()
                .Property(e => e.MaCV)
                .IsFixedLength();

            modelBuilder.Entity<CHUCVU>()
                .Property(e => e.MaCV)
                .IsFixedLength();

            modelBuilder.Entity<CHUCVU>()
                .HasMany(e => e.BENHNHANs)
                .WithRequired(e => e.CHUCVU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CHUCVU>()
                .HasMany(e => e.NHANSUs)
                .WithRequired(e => e.CHUCVU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DICHVU>()
                .Property(e => e.MaDV)
                .IsFixedLength();

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MaHD)
                .IsFixedLength();

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MaKB)
                .IsFixedLength();

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MaThuoc)
                .IsFixedLength();

            modelBuilder.Entity<HOADON>()
                .Property(e => e.MaDV)
                .IsFixedLength();

            modelBuilder.Entity<KHAMBENH>()
                .Property(e => e.MaKB)
                .IsFixedLength();

            modelBuilder.Entity<KHAMBENH>()
                .Property(e => e.SDT)
                .IsFixedLength();

            modelBuilder.Entity<KHAMBENH>()
                .Property(e => e.BHYT)
                .IsFixedLength();

            modelBuilder.Entity<KHAMBENH>()
                .HasMany(e => e.BENHNHANs)
                .WithRequired(e => e.KHAMBENH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHAMBENH>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.KHAMBENH)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHOA>()
                .Property(e => e.MaKhoa)
                .IsFixedLength();

            modelBuilder.Entity<KHOA>()
                .HasMany(e => e.NHANSUs)
                .WithRequired(e => e.KHOA)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NHANSU>()
                .Property(e => e.MaNS)
                .IsFixedLength();

            modelBuilder.Entity<NHANSU>()
                .Property(e => e.MaKhoa)
                .IsFixedLength();

            modelBuilder.Entity<NHANSU>()
                .Property(e => e.MaCV)
                .IsFixedLength();

            modelBuilder.Entity<NHANSU>()
                .Property(e => e.SDT)
                .IsFixedLength();

            modelBuilder.Entity<NHANSU>()
                .HasMany(e => e.BENHNHANs)
                .WithRequired(e => e.NHANSU)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.TenDN)
                .IsFixedLength();

            modelBuilder.Entity<TAIKHOAN>()
                .Property(e => e.MatKhau)
                .IsFixedLength();

            modelBuilder.Entity<THUOC>()
                .Property(e => e.MaThuoc)
                .IsFixedLength();

            modelBuilder.Entity<THUOC>()
                .Property(e => e.HSD)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<THUOC>()
                .HasMany(e => e.BENHNHANs)
                .WithRequired(e => e.THUOC)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<THUOC>()
                .HasMany(e => e.HOADONs)
                .WithRequired(e => e.THUOC)
                .WillCascadeOnDelete(false);
        }
    }
}
