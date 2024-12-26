using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DAN_WEB.Models
{
    public partial class DangKy
    {
        [DisplayName("Mã đăng ký môn học")]
        [Required(ErrorMessage = "Mã đăng ký môn học không được để trống!")]
        [StringLength(maximumLength: 4, MinimumLength = 4, ErrorMessage = "Mã đăng ký môn học phải nhập đủ 4 ký tự")]
        public string Madk { get; set; } = null!;
        [DisplayName("Tên môn học đăng ký")]
        public string Tenmondk { get; set; } = null!;
        [DisplayName("Số tín chỉ")]
        public int Stc { get; set; }
        [DisplayName("Mã sinh viên")]
        public string Masv { get; set; } = null!;
        [DisplayName("Mã nhóm môn học")]
        public string Manmh { get; set; } = null!;

        public virtual NhomMonHoc ManmhNavigation { get; set; } = null!;
        public virtual SinhVien MasvNavigation { get; set; } = null!;
    }
}
