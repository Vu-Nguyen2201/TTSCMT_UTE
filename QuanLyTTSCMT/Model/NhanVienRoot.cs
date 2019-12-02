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
        public NhanVienRoot() : base()
        {
            quyenQuanLy = true;
        }
        public NhanVienRoot(string ten, string mSSV, string sDT, string tenTaiKhoan, string mKTaiKhoan) : base(ten, mSSV, sDT, tenTaiKhoan, mKTaiKhoan)
        {
            quyenQuanLy = true;
        }
        public NhanVienRoot(QuanLyRoot root) //Cái này dùng cho trường hợp nào?
        {
            quyenQuanLy = true;
            Ten = root.Ten;
            MSSV = root.MSSV;
            SDT = root.SDT;
            TenTaiKhoan = root.TenTaiKhoan;
            MKTaiKhoan = root.MKTaiKhoan;
        }
    }
}
