using System;
using System.Collections.Generic;

namespace DAN_WEB.Models
{
    public partial class HocKy
    {
        public HocKy()
        {
            NhomMonHocs = new HashSet<NhomMonHoc>();
        }

        public string Mahk { get; set; } = null!;
        public string Tenhk { get; set; } = null!;
        public string Namhoc { get; set; } = null!;

        public virtual ICollection<NhomMonHoc> NhomMonHocs { get; set; }
    }
}
