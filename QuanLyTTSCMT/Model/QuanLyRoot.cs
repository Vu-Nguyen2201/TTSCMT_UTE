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

        public void themNhanVien(string ten, string mSSV, string sDT, string tenTaiKhoan, string mKTaiKhoan,bool quyenQuanLy)
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
        public bool kiemTraSDT(string sdt)
        {
            if (sdt[0] != '0')
                return false;
            bool kt = true;
            for(int i=0;i<sdt.Length;i++)
            {
                if (!char.IsDigit(sdt[i]))
                    return false;
            }
            return kt;
        }
        
    }
}
