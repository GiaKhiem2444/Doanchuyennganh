using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;

namespace DAN_WEB.Models
{
    public partial class NhomMonHoc
    {
        public NhomMonHoc()
        {
            DangKies = new HashSet<DangKy>();
        }
        [DisplayName("Mã nhóm môn học")]
        [Required(ErrorMessage = "Mã nhóm môn học không được để trống!")]
        [StringLength(maximumLength: 5, MinimumLength = 4, ErrorMessage = "Mã nhóm môn học phải nhập đủ 4 ký tự")]
        public string Manmh { get; set; } = null!;
        [DisplayName("Tên môn học")]
        public string Tenmh { get; set; } = null!;
        [DisplayName("Mã học kỳ")]
        
        public string Mahk { get; set; } = null!;
        [DisplayName("Mã quản trị")]
        
        public string Maqt { get; set; } = null!;
        [DisplayName("Mã môn học")]
        
        public string Mamh { get; set; } = null!;
        

        public virtual HocKy MahkNavigation { get; set; } = null!;
        public virtual MonHoc MamhNavigation { get; set; } = null!;
        public virtual QuanTri MaqtNavigation { get; set; } = null!;
        public virtual ICollection<DangKy> DangKies { get; set; }
    }
}
