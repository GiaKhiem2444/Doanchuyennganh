using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DAN_WEB.Models
{
    public partial class MonHoc
    {
        public MonHoc()
        {
            Diems = new HashSet<Diem>();
            NhomMonHocs = new HashSet<NhomMonHoc>();
        }
        [DisplayName("Mã môn học")]
        [Required(ErrorMessage = "Mã môn học không được để trống!")]
        [StringLength(maximumLength: 4, MinimumLength = 4, ErrorMessage = "Mã môn học phải nhập đủ 4 ký tự")]
        public string Mamh { get; set; } = null!;
        [DisplayName("Tên môn học")]
        public string Tenmh { get; set; } = null!;
        [DisplayName("Số tín chỉ")]
        public int Stc { get; set; }

        public virtual ICollection<Diem> Diems { get; set; }
        public virtual ICollection<NhomMonHoc> NhomMonHocs { get; set; }
    }
}
