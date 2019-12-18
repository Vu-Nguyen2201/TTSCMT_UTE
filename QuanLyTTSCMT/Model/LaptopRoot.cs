using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTTSCMT.Model
{
    public class LaptopRoot
    {
        #region Các thuộc tính
        private string tenMayTinh;
        private string tenChuMay;
        private DateTime ngayNhanMay;
        private DateTime ngayGiaoMay;
        private string noiDungSuaChua;
        private string ghiChu;
        private string thanhTien;
        private string tinhTrang;
        private int iDNguoiSuaMay;
        private int iD;
        private int iDChuMay;
        private int iDNguoiNhanMay;
        #endregion
        #region Các hàm tạo
        public LaptopRoot() { }
        public LaptopRoot(int iDNguoiSuaMay,int iDChuMay,int iDNguoiNhanMay,string tenMayTinh,int iD,string tenChuMay,DateTime ngayNhanMay,DateTime ngayGiaoMay,string noiDungSuaChua,string ghiChu,string thanhTien) 
        {
            IDNguoiSuaMay = iDNguoiSuaMay;
            TenMayTinh = tenMayTinh;
            TenChuMay = tenChuMay;
            NgayNhanMay = ngayNhanMay;
            NgayGiaoMay = ngayGiaoMay;
            NoiDungSuaChua = noiDungSuaChua;
            GhiChu = ghiChu;
            ID = iD;
            IDChuMay = iDChuMay;
            IDNguoiNhanMay = iDNguoiNhanMay;
            ThanhTien = thanhTien;
            TinhTrang = "Đang sửa";
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
            iDNguoiSuaMay = root.IDNguoiSuaMay;
            tinhTrang = root.TinhTrang;
        }
        #endregion
        #region Truy xuất các thuộc tính
        public string TenMayTinh { get => tenMayTinh; set => tenMayTinh = value; }
        public string TenChuMay { get => tenChuMay; set => tenChuMay = value; }
        public DateTime NgayNhanMay { get => ngayNhanMay; set => ngayNhanMay = value; }
        public DateTime NgayGiaoMay { get => ngayGiaoMay; set => ngayGiaoMay = value; }
        public string ThanhTien { get => thanhTien; set => thanhTien = value; }
        public string NoiDungSuaChua { get => noiDungSuaChua; set => noiDungSuaChua = value; }
        public string GhiChu { get => ghiChu; set => ghiChu = value; }
        public int IDNguoiSuaMay { get => iDNguoiSuaMay; set => iDNguoiSuaMay = value; }
        public string TinhTrang { get => tinhTrang; set => tinhTrang = value; }
        public int ID { get => iD; set => iD = value; }
        public int IDChuMay { get => iDChuMay; set => iDChuMay = value; }
        public int IDNguoiNhanMay { get => iDNguoiNhanMay; set => iDNguoiNhanMay = value; }
        #endregion
    }
}
