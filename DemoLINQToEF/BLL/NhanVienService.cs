using DemoLINQToEF.DAL;
using DemoLINQToEF.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLINQToEF.BLL
{
    public class NhanVienService
    {
        // kbao object DB
        ModelNV _contextDB = new ModelNV();

        public List<NhanVienViewModel> getAllNhanVien()
        {
            // var res = _contextDB.NhanViens.ToList();
            //var res = _contextDB.NhanViens.Select(entity => new NhanVienViewModel
            //{
            //    MaNV = entity.MaNV,
            //    HoTen = entity.HoNV + " " + entity.TenNV,
            //    Luong = entity.Luong,
            //    MaCV = entity.MaCV,
            //    MaBP = entity.MaBP
            //}).ToList();

            var res2 = (from nv in _contextDB.NhanViens
                        join cv in _contextDB.ChucVus on nv.MaCV equals cv.MaCV
                        join bp in _contextDB.Bophans on nv.MaBP equals bp.MaBP
                       select new NhanVienViewModel
                       {
                           MaNV = nv.MaNV,
                           HoTen = nv.HoNV + " " + nv.TenNV,
                           Luong = nv.Luong,
                           TenCV = cv.TenCV,
                           TenBP = bp.TenBP
                       }).OrderBy(x=>x.HoTen).Take(5).ToList();
           // var res3 = res2.OrderBy(x => x.HoTen);

            return res2;
        }

        // insert NV
        public void InsertNV(NhanVienModel nv)
        {
            var countNV = _contextDB.NhanViens.Count();
            var _newNV = new NhanVien();
            _newNV.MaNV = (countNV + 1).ToString();
            _newNV.HoNV = nv.HoNV;
            _newNV.TenNV = nv.TenNV;
            _newNV.Luong = nv.Luong;
            _newNV.MaCV = nv.MaCV;
            _newNV.MaBP = nv.MaBP;

            _contextDB.NhanViens.Add(_newNV);
            _contextDB.SaveChanges();
        }

        // update
        public void UpdateNV(NhanVienModel nv)
        {
            var nvDB = _contextDB.NhanViens.FirstOrDefault(x => x.MaNV == nv.MaNV);
            if(nvDB == null)
            {
                throw new Exception("NV does not exist!");
            }
            nvDB.HoNV = nv.HoNV;
            nvDB.TenNV = nv.TenNV;
            nvDB.Luong = nv.Luong;
            nvDB.MaCV = nv.MaCV;
            nvDB.MaBP = nv.MaBP;

            _contextDB.SaveChanges();
        }

        // delete
        public void DeleteNV(string maNV)
        {
            var nvDB = _contextDB.NhanViens.FirstOrDefault(x => x.MaNV == maNV);
            if (nvDB == null)
            {
                throw new Exception("NV does not exist!");
            }
            _contextDB.NhanViens.Remove(nvDB);
            _contextDB.SaveChanges();
        }
    }
}
