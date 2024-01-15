namespace ASP_Upload_Images.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nha CC")]
    public partial class Nha_CC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nha_CC()
        {
            Hang = new HashSet<Hang>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        [StringLength(15)]
        public string MaNCC { get; set; }

        [Required(ErrorMessage = "Tên nhà cung cấp không được để trống.")]
        [StringLength(20)]
        public string TenNCC { get; set; }

        [Required(ErrorMessage = "Địa chỉ không được để trống.")]
        [StringLength(20)]
        public string DiaChi { get; set; }

        [Required(ErrorMessage = "Số điện thoại không được để trống.")]
        [StringLength(10)]
        public string DienThoai { get; set; }

        [Required(ErrorMessage = "Email không được để trống.")]
        [StringLength(25)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Hang> Hang { get; set; }
    }
}
