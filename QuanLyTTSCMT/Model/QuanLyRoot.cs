using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuanLyTTSCMT.Model
{
    public class QuanLyRoot:Nguoi
    {
        
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
        
        public void doiMatKhau(string mKMoi)
        {
          
            DB_QuanLyTTSCMTEntities data = new DB_QuanLyTTSCMTEntities();
            var duLieuNhanVien = from table in data.NhanViens select table;
            foreach (var iteam in duLieuNhanVien)
                if (iteam.ID == NguoiSuDung.ID)
                {
                    iteam.MKTaiKhoan = mKMoi;
                    break;
                }
            data.SaveChanges();
        }
    }
}
