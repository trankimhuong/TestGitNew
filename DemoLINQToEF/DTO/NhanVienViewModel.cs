using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLINQToEF.DTO
{
    public class NhanVienViewModel
    {
        public string MaNV { get; set; }
      //  public string HoNV { get; set; }
       // public string TenNV { get; set; }
        public string HoTen { get; set; }
        public double? Luong { get; set; }
       public string TenCV { get; set; }
      public string TenBP { get; set; }
      //  public string MaCV { get; set; }
      //  public string MaBP { get; set; }
    }

    public class NhanVienModel
    {
        public string MaNV { get; set; }
        public string HoNV { get; set; }
        public string TenNV { get; set; }
        public double? Luong { get; set; }
        public string MaCV { get; set; }
        public string MaBP { get; set; }
    }
}
