namespace ASP_Upload_Images.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hang")]
    public partial class Hang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hang()
        {
            GioHang = new HashSet<GioHang>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [StringLength(15)]
        [Required(ErrorMessage = "Mã định danh không được để trống.")]
        public string MaHang { get; set; }

        [Required(ErrorMessage = "Mã nhà cung cấp không được để trống.")]
        [StringLength(15)]
        public string MaNCC { get; set; }

        [Required(ErrorMessage = "Tên mặt hàng không được để trống.")]
        [StringLength(20)]
        public string TenHang { get; set; }

        [Column(TypeName = "numeric")]
        [DisplayName("Giá nhập")]
        public decimal Gia { get; set; }

        [Column(TypeName = "numeric")]
        public short LuongCo { get; set; }

        [StringLength(200)]
        [DisplayName("Mô tả")]
        public string MoTa { get; set; }

        public decimal? ChietKhau { get; set; }

        [StringLength(30)]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GioHang> GioHang { get; set; }

        public virtual Nha_CC Nha_CC { get; set; }
    }
}
