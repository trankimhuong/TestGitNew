namespace DemoLINQToEF.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [Key]
        [StringLength(5)]
        public string MaNV { get; set; }

        [StringLength(30)]
        public string HoNV { get; set; }

        [StringLength(10)]
        public string TenNV { get; set; }

        public double? Luong { get; set; }

        [StringLength(5)]
        public string Phai { get; set; }

        public DateTime? NgaySinh { get; set; }

        [StringLength(3)]
        public string MaCV { get; set; }

        [StringLength(4)]
        public string MaBP { get; set; }

        public virtual Bophan Bophan { get; set; }

        public virtual ChucVu ChucVu { get; set; }
    }
}
