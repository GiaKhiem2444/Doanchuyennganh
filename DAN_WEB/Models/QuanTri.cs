using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DAN_WEB.Models
{
    public partial class QuanTri
    {
        public QuanTri()
        {
            NhomMonHocs = new HashSet<NhomMonHoc>();
        }

        [DisplayName("Mã quản trị")]
        [Required(ErrorMessage = "Mã quản trị không được để trống!")]
        [StringLength(maximumLength: 4, MinimumLength = 4, ErrorMessage = "Mã quản trị phải nhập đủ 4 ký tự")]
        public string Maqt { get; set; } = null!;

        [DisplayName("Tên quản trị")]
        public string Tenqt { get; set; } = null!;

        [DisplayName("Số điện thoại")]
        public string Sdt { get; set; } = null!;

        [DisplayName("Địa chỉ")]
        public string Diachi { get; set; } = null!;

        public virtual ICollection<NhomMonHoc> NhomMonHocs { get; set; }
    }
}
