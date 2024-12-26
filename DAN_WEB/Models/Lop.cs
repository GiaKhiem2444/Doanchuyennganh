using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DAN_WEB.Models
{
    public partial class Lop
    {
        public Lop()
        {
            SinhViens = new HashSet<SinhVien>();
        }
        [DisplayName("Mã lớp")]
        [Required(ErrorMessage = "Mã lớp không được để trống!")]
        public string Malop { get; set; } = null!;


        [DisplayName("Tên lớp")]
        public string Tenlop { get; set; } = null!;

        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
