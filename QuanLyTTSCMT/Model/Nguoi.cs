using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyTTSCMT.Model
{
    public class Nguoi
    {
        private string ten;
        private string mSSV;
        private string sDT;
        private string tenTaiKhoan;
        private string mKTaiKhoan;
        protected bool quyenQuanLy;
        public Nguoi() { }
        public Nguoi(string ten,string mSSV,string sDT,string tenTaiKhoan,string mKTaiKhoan)
        {
            Ten = ten;
            MSSV = mSSV;
            SDT = sDT;
            TenTaiKhoan = tenTaiKhoan;
            MKTaiKhoan = mKTaiKhoan;
        }

        public Nguoi(string ten,string mSSV,string sDT)
        {
            Ten = ten;
            MSSV = mSSV;
            SDT = sDT;
        }
        public void NhapDonHang(Nguoi khachHang, LaptopRoot mayTinh, ref int idMay)
        {
            DB_QuanLyTTSCMTEntities data = new DB_QuanLyTTSCMTEntities();
            LapTop lapTopData = new LapTop();
            var duLieuKhachHang = from table in data.KhachHangs select table;
            bool kiemTra= false;
            int idChuMay=0;
            foreach (var iteam in duLieuKhachHang)
            {
                if(iteam.MSSV==khachHang.MSSV)
                {
                    kiemTra = true;
                    lapTopData.IDChuMay = iteam.ID;
                    idChuMay = iteam.ID;
                    break;
                }
            }
            if(!kiemTra)
            {
                KhachHang khachHangData = new KhachHang();
                khachHangData.Ten = khachHang.ten;
                khachHangData.MSSV = khachHang.MSSV;
                khachHangData.SDT = khachHang.SDT;
                data.KhachHangs.Add(khachHangData);
                data.SaveChanges();
                var duLieuKhachHang1 = from table in data.KhachHangs select table;
                foreach (var iteam in duLieuKhachHang1)
                {
                    if (iteam.MSSV == khachHang.MSSV)
                    {
                        lapTopData.IDChuMay = iteam.ID;
                        idChuMay = iteam.ID;
                        break;
                    }
                }
            }

            lapTopData.TenMay = mayTinh.TenMayTinh;
            lapTopData.NgayNhan = mayTinh.NgayNhanMay;
            lapTopData.NgayGiao = mayTinh.NgayNhanMay;
            lapTopData.NDSuaChua = mayTinh.NoiDungSuaChua;
            lapTopData.GhiChu = mayTinh.GhiChu;
            lapTopData.IDNguoiNhanMay = NguoiSuDung.ID;
            lapTopData.ThanhTien = mayTinh.ThanhTien;
            data.LapTops.Add(lapTopData);
            data.SaveChanges();
            var duLieuKhachHang2 = from table in data.LapTops select table;
            foreach (var iteam in duLieuKhachHang2)
            {
                if (iteam.NgayNhan==mayTinh.NgayNhanMay&&iteam.NgayNhan==iteam.NgayGiao&&iteam.IDChuMay==idChuMay)
                {
                    idMay = iteam.ID;
                    break;
                }
            }
            
        }
        public string Ten { get => ten; set => ten = value; }
        public string MSSV { get => mSSV; set => mSSV = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string TenTaiKhoan { get => tenTaiKhoan; set => tenTaiKhoan = value; }
        public string MKTaiKhoan { get => mKTaiKhoan; set => mKTaiKhoan = value; }
        public bool QuyenQuanLy { get => quyenQuanLy; }
    }
}
