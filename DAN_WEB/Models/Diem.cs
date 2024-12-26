using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAN_WEB.Models
{
    public partial class Diem
    {
        [Key]
        public decimal Diemgk { get; set; }

        [Key]
        public decimal Diemck { get; set; }
        public int Hocky { get; set; }
        public string Masv { get; set; } = null!;
        public string Mamh { get; set; } = null!;

        public virtual MonHoc MamhNavigation { get; set; } = null!;
        public virtual SinhVien MasvNavigation { get; set; } = null!;
    }
}
