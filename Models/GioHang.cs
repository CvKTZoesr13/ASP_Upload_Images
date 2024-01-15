namespace ASP_Upload_Images.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        [StringLength(15)]
        public string MaHang { get; set; }

        [StringLength(15)]
        public string MaNguoiDung { get; set; }

        [Key]
        public int MaGioHang { get; set; }

        public virtual Hang Hang { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }
    }
}
