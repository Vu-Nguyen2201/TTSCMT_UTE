using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyTTSCMT.Model;
namespace QuanLyTTSCMT.Model
{
    class NhanVienRoot:Nguoi
    {
        #region Các hàm tạo
        public NhanVienRoot() : base()
        {
            quyenQuanLy = true;
        }
        public NhanVienRoot(string ten, string mSSV, string sDT, string tenTaiKhoan, string mKTaiKhoan) : base(ten, mSSV, sDT, tenTaiKhoan, mKTaiKhoan)
        {
            quyenQuanLy = true;
        }
        public NhanVienRoot(NhanVienRoot root) 
        {
            quyenQuanLy = true;
            Ten = root.Ten;
            MSSV = root.MSSV;
            SDT = root.SDT;
            TenTaiKhoan = root.TenTaiKhoan;
            MKTaiKhoan = root.MKTaiKhoan;
        }
        #endregion
        #region Override lại các phương thức ảo của lớp cha
        public override void themNhanVien(string ten, string mSSV, string sDT, string tenTaiKhoan, string mKTaiKhoan, bool quyenQuanLy)
        {

        }
        public override List<LaptopRoot> timCacThongTinMayTuNgayBatDauDenNgayKetThuc(DateTime Batdau, DateTime ketThuc)
        {
            return new List<LaptopRoot>();
        }
        #endregion
    }
}
