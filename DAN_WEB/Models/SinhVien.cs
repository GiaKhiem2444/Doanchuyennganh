using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DAN_WEB.Models
{
    public partial class SinhVien
    {
        public SinhVien()
        {
            DangKies = new HashSet<DangKy>();
            Diems = new HashSet<Diem>();
        }

        [DisplayName("Họ sinh viên")]
        public string Hosv { get; set; } = null!;

        [DisplayName("Tên sinh viên")]
        
        public string Tensv { get; set; } = null!;

        [DisplayName("Mã sinh viên")]
        [Required(ErrorMessage = "Mã sinh viên không được để trống!")]
        [StringLength(maximumLength: 4, MinimumLength = 4, ErrorMessage = "Mã sinh viên phải nhập đủ 4 ký tự")]
        public string Masv { get; set; } = null!;

        [DisplayName("Giới tính ")]
        public bool? Gioitinh { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime Ngaysinh { get; set; }

        [DisplayName("Địa chỉ")]
        public string Diachi { get; set; } = null!;

        [DisplayName("SĐT")]
        public string Sdt { get; set; } = null!;

        [DisplayName("Mã lớp")]
        public string Malop { get; set; } = null!;

        public virtual Lop MalopNavigation { get; set; } = null!;
        public virtual ICollection<DangKy> DangKies { get; set; }
        public virtual ICollection<Diem> Diems { get; set; }
    }
}
