using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAN_WEB.Models
{
    public partial class QLDSVienNhom12Context : DbContext
    {
        public QLDSVienNhom12Context()
        {
        }

        public QLDSVienNhom12Context(DbContextOptions<QLDSVienNhom12Context> options)
            : base(options)
        {
        }

        public virtual DbSet<DangKy> DangKies { get; set; } = null!;
        public virtual DbSet<Diem> Diems { get; set; } = null!;
        public virtual DbSet<HocKy> HocKies { get; set; } = null!;
        public virtual DbSet<Lop> Lops { get; set; } = null!;
        public virtual DbSet<MonHoc> MonHocs { get; set; } = null!;
        public virtual DbSet<NhomMonHoc> NhomMonHocs { get; set; } = null!;
        public virtual DbSet<QuanTri> QuanTris { get; set; } = null!;
        public virtual DbSet<SinhVien> SinhViens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MSI;Database=QLDSVienNhom12;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DangKy>(entity =>
            {
                entity.HasKey(e => e.Madk)
                    .HasName("pk_DangKy");

                entity.ToTable("DangKy");

                entity.Property(e => e.Madk)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("madk");

                entity.Property(e => e.Manmh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("manmh");

                entity.Property(e => e.Masv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("masv");

                entity.Property(e => e.Stc).HasColumnName("stc");

                entity.Property(e => e.Tenmondk)
                    .HasMaxLength(50)
                    .HasColumnName("tenmondk");

                entity.HasOne(d => d.ManmhNavigation)
                    .WithMany(p => p.DangKies)
                    .HasForeignKey(d => d.Manmh)
                    .HasConstraintName("fk_DK_MNH");

                entity.HasOne(d => d.MasvNavigation)
                    .WithMany(p => p.DangKies)
                    .HasForeignKey(d => d.Masv)
                    .HasConstraintName("fk_DK_SV");
            });

            modelBuilder.Entity<Diem>(entity =>
            {
                entity.HasKey(e => new { e.Masv, e.Mamh })
                    .HasName("pk_Diem");

                entity.ToTable("Diem");

                entity.Property(e => e.Masv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("masv");

                entity.Property(e => e.Mamh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mamh");

                entity.Property(e => e.Diemck)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("diemck");

                entity.Property(e => e.Diemgk)
                    .HasColumnType("decimal(4, 2)")
                    .HasColumnName("diemgk");

                entity.Property(e => e.Hocky).HasColumnName("hocky");

                entity.HasOne(d => d.MamhNavigation)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.Mamh)
                    .HasConstraintName("fk_Diem_MonHoc");

                entity.HasOne(d => d.MasvNavigation)
                    .WithMany(p => p.Diems)
                    .HasForeignKey(d => d.Masv)
                    .HasConstraintName("fk_Diem_SinhVien");
            });

            modelBuilder.Entity<HocKy>(entity =>
            {
                entity.HasKey(e => e.Mahk)
                    .HasName("pk_NamHoc");

                entity.ToTable("HocKy");

                entity.Property(e => e.Mahk)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("mahk");

                entity.Property(e => e.Namhoc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("namhoc");

                entity.Property(e => e.Tenhk)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("tenhk");
            });

            modelBuilder.Entity<Lop>(entity =>
            {
                entity.HasKey(e => e.Malop)
                    .HasName("pk_Lop");

                entity.ToTable("Lop");

                entity.Property(e => e.Malop)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("malop");

                entity.Property(e => e.Tenlop)
                    .HasMaxLength(10)
                    .HasColumnName("tenlop");
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.HasKey(e => e.Mamh)
                    .HasName("pk_MonHoc");

                entity.ToTable("MonHoc");

                entity.Property(e => e.Mamh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mamh");

                entity.Property(e => e.Stc).HasColumnName("stc");

                entity.Property(e => e.Tenmh)
                    .HasMaxLength(50)
                    .HasColumnName("tenmh");
            });

            modelBuilder.Entity<NhomMonHoc>(entity =>
            {
                entity.HasKey(e => e.Manmh)
                    .HasName("pk_NhomMonHoc");

                entity.ToTable("NhomMonHoc");

                entity.Property(e => e.Manmh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("manmh");

                entity.Property(e => e.Mahk)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("mahk");

                entity.Property(e => e.Mamh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("mamh");

                entity.Property(e => e.Maqt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("maqt");

                entity.Property(e => e.Tenmh)
                    .HasMaxLength(50)
                    .HasColumnName("tenmh");

                entity.HasOne(d => d.MahkNavigation)
                    .WithMany(p => p.NhomMonHocs)
                    .HasForeignKey(d => d.Mahk)
                    .HasConstraintName("fk_NMH_HK");

                entity.HasOne(d => d.MamhNavigation)
                    .WithMany(p => p.NhomMonHocs)
                    .HasForeignKey(d => d.Mamh)
                    .HasConstraintName("fk_NMH_MH");

                entity.HasOne(d => d.MaqtNavigation)
                    .WithMany(p => p.NhomMonHocs)
                    .HasForeignKey(d => d.Maqt)
                    .HasConstraintName("fk_NMH_QT");
            });

            modelBuilder.Entity<QuanTri>(entity =>
            {
                entity.HasKey(e => e.Maqt)
                    .HasName("pk_QuanTri");

                entity.ToTable("QuanTri");

                entity.Property(e => e.Maqt)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("maqt");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(50)
                    .HasColumnName("diachi");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sdt")
                    .IsFixedLength();

                entity.Property(e => e.Tenqt)
                    .HasMaxLength(20)
                    .HasColumnName("tenqt");
            });

            modelBuilder.Entity<SinhVien>(entity =>
            {
                entity.HasKey(e => e.Masv)
                    .HasName("pk_SinhVien");

                entity.ToTable("SinhVien");

                entity.Property(e => e.Masv)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("masv");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(50)
                    .HasColumnName("diachi");

                entity.Property(e => e.Gioitinh).HasColumnName("gioitinh");

                entity.Property(e => e.Hosv)
                    .HasMaxLength(10)
                    .HasColumnName("hosv");

                entity.Property(e => e.Malop)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("malop");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaysinh");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("sdt")
                    .IsFixedLength();

                entity.Property(e => e.Tensv)
                    .HasMaxLength(20)
                    .HasColumnName("tensv");

                entity.HasOne(d => d.MalopNavigation)
                    .WithMany(p => p.SinhViens)
                    .HasForeignKey(d => d.Malop)
                    .HasConstraintName("fk_SinhVien_Lop");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
