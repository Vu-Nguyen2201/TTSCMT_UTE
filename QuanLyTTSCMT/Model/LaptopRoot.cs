using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTTSCMT.Model
{
    public class LaptopRoot
    {

        private string tenMayTinh;
        private string tenChuMay;
        private string tenNV;
        private DateTime ngayNhanMay;
        private DateTime ngayGiaoMay;
        private string noiDungSuaChua;
        private string ghiChu;
        private string thanhTien;
        public LaptopRoot() { }
        public LaptopRoot(string tenNV,string tenMayTinh,string tenChuMay,DateTime ngayNhanMay,DateTime ngayGiaoMay,string noiDungSuaChua,string ghiChu,string thanhTien) 
        {
            TenNV = tenNV;

            TenMayTinh = tenMayTinh;
            TenChuMay = tenChuMay;
            NgayNhanMay = ngayNhanMay;
            NgayGiaoMay = ngayGiaoMay;
            NoiDungSuaChua = noiDungSuaChua;
            GhiChu = ghiChu;
            ThanhTien = thanhTien;
        }
        public LaptopRoot(LaptopRoot root)
        {

            TenMayTinh = root.TenMayTinh;
            TenChuMay = root.TenChuMay;
            NgayNhanMay = root.NgayNhanMay;
            NgayGiaoMay = root.NgayGiaoMay;
            NoiDungSuaChua = root.NoiDungSuaChua;
            GhiChu = root.GhiChu;
            ThanhTien = root.ThanhTien;
            TenNV = root.TenNV;
        }

        public string TenMayTinh { get => tenMayTinh; set => tenMayTinh = value; }
        public string TenChuMay { get => tenChuMay; set => tenChuMay = value; }
        public DateTime NgayNhanMay { get => ngayNhanMay; set => ngayNhanMay = value; }
        public DateTime NgayGiaoMay { get => ngayGiaoMay; set => ngayGiaoMay = value; }

        public string ThanhTien { get => thanhTien; set => thanhTien = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string NoiDungSuaChua { get => noiDungSuaChua; set => noiDungSuaChua = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
    }
}
