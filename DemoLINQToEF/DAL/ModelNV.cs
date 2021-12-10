using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DemoLINQToEF.DAL
{
    public partial class ModelNV : DbContext
    {
        public ModelNV()
            : base("name=ModelNV")
        {
        }

        public virtual DbSet<Bophan> Bophans { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
