using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ASP_Upload_Images.Models
{
    public partial class fShop : DbContext
    {
        public fShop()
            : base("name=fShopDB")
        {
        }

        public virtual DbSet<GioHang> GioHang { get; set; }
        public virtual DbSet<Hang> Hang { get; set; }
        public virtual DbSet<NguoiDung> NguoiDung { get; set; }
        public virtual DbSet<Nha_CC> Nha_CC { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hang>()
                .Property(e => e.Gia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Hang>()
                .Property(e => e.ChietKhau)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Nha_CC>()
                .HasMany(e => e.Hang)
                .WithRequired(e => e.Nha_CC)
                .WillCascadeOnDelete(false);
        }
    }
}
