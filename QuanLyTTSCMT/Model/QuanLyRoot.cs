using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuanLyTTSCMT.Model
{
    public class QuanLyRoot:Nguoi
    {
        #region Các hàm tạo   
        public QuanLyRoot():base()
        {
            quyenQuanLy = true;
        }
        public QuanLyRoot(string ten, string mSSV, string sDT, string tenTaiKhoan, string mKTaiKhoan):base (ten,mSSV,sDT,tenTaiKhoan,mKTaiKhoan)
        {
            quyenQuanLy = true;
        }
        public QuanLyRoot(QuanLyRoot root)
        {
            quyenQuanLy = true;
            Ten = root.Ten;
            MSSV = root.MSSV;
            SDT = root.SDT;
            TenTaiKhoan = root.TenTaiKhoan;
            MKTaiKhoan = root.MKTaiKhoan;
            
        }

        public override void themNhanVien(string ten, string mSSV, string sDT, string tenTaiKhoan, string mKTaiKhoan,bool quyenQuanLy)
        {
            DB_QuanLyTTSCMTEntities newDataBase = new DB_QuanLyTTSCMTEntities();
            NhanVien newNhanVien = new NhanVien();
            newNhanVien.Ten = ten;
            newNhanVien.MSSV = mSSV;
            newNhanVien.SDT = sDT;
            newNhanVien.TenTaiKhoan = tenTaiKhoan;
            newNhanVien.MKTaiKhoan = mKTaiKhoan;
            newNhanVien.LaQuanLy = quyenQuanLy;
            newDataBase.NhanViens.Add(newNhanVien);
            newDataBase.SaveChanges();
        }
        #endregion
        #region Override lại các phương thức ảo của lớp cha
        public override List<LaptopRoot> timCacThongTinMayTuNgayBatDauDenNgayKetThuc(DateTime Batdau, DateTime ketThuc)
        {
            List<LaptopRoot> may = new List<LaptopRoot>();
            DB_QuanLyTTSCMTEntities CSDL = new DB_QuanLyTTSCMTEntities();
            var duLieuMayTinh = from bang in CSDL.LapTops select bang;
            foreach (var mayTinh in duLieuMayTinh)
            {
                if (mayTinh.NgayNhan.Date >= Batdau.Date && mayTinh.NgayNhan.Date <= ketThuc.Date)
                {
                    LaptopRoot mayTinhMoi = new LaptopRoot(mayTinh.IDNguoiSuaMay, mayTinh.IDChuMay, mayTinh.IDNguoiNhanMay, mayTinh.TenMay, mayTinh.ID, "", mayTinh.NgayNhan, mayTinh.NgayGiao, mayTinh.NDSuaChua, mayTinh.GhiChu, mayTinh.ThanhTien);
                    may.Add(mayTinhMoi);
                }
            }
            return may;
        }
        #endregion
    }
}
