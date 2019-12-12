using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace QuanLyTTSCMT.Model
{
    public abstract class Nguoi
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
        
        public string Ten { get => ten; set => ten = value; }
        public string MSSV { get => mSSV; set => mSSV = value; }
        public string SDT { get => sDT; set => sDT = value; }
        public string TenTaiKhoan { get => tenTaiKhoan; set => tenTaiKhoan = value; }
        public string MKTaiKhoan { get => mKTaiKhoan; set => mKTaiKhoan = value; }
        public bool QuyenQuanLy { get => quyenQuanLy; }
        public void NhapDonHang(Nguoi khachHang, LaptopRoot mayTinh, ref int idMay)
        {
            DB_QuanLyTTSCMTEntities data = new DB_QuanLyTTSCMTEntities();
            LapTop lapTopData = new LapTop();
            var duLieuKhachHang = from table in data.KhachHangs select table;
            bool kiemTra = false;
            int idChuMay = 0;
            foreach (var iteam in duLieuKhachHang)
            {
                if (iteam.MSSV == khachHang.MSSV)
                {
                    kiemTra = true;
                    lapTopData.IDChuMay = iteam.ID;
                    idChuMay = iteam.ID;
                    break;
                }
            }
            if (!kiemTra)
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
                if (iteam.NgayNhan == mayTinh.NgayNhanMay && iteam.NgayNhan == iteam.NgayGiao && iteam.IDChuMay == idChuMay)
                {
                    idMay = iteam.ID;
                    break;
                }
            }
            //DB_QuanLyTTSCMTEntities CSDL = new DB_QuanLyTTSCMTEntities();
            //LapTop lapTopData = new LapTop();
            //var duLieuKhachHang = from bang in CSDL.KhachHangs select bang;
            //bool kiemTra = false;
            //int idChuMay = 0;
            //if (timCacIDMayDuaVaoMSSVChuMay(khachHang.MSSV).Count != 0)
            //    lapTopData.IDChuMay = Convert.ToInt32(timCacIDMayDuaVaoMSSVChuMay(khachHang.MSSV)[0]);
            //foreach (var iteam in duLieuKhachHang)
            //{
            //    if (iteam.MSSV == khachHang.MSSV)
            //    {
            //        kiemTra = true;
            //        lapTopData.IDChuMay = iteam.ID;
            //        idChuMay = iteam.ID;
            //        break;
            //    }
            //}
            //if (!kiemTra)
            //{

            //    var duLieuMayTinh = from bang in CSDL.KhachHangs select bang;
            //    foreach (var mayTinh1 in duLieuMayTinh)
            //    {
            //        if (mayTinh1.MSSV == khachHang.MSSV)
            //        {
            //            lapTopData.IDChuMay = mayTinh1.ID;
            //            idChuMay = mayTinh1.ID;
            //            break;
            //        }
            //    }
            //}

            //lapTopData.TenMay = mayTinh.TenMayTinh;
            //lapTopData.NgayNhan = mayTinh.NgayNhanMay;
            //lapTopData.NgayGiao = mayTinh.NgayNhanMay;
            //lapTopData.NDSuaChua = mayTinh.NoiDungSuaChua;
            //lapTopData.GhiChu = mayTinh.GhiChu;
            //lapTopData.IDNguoiNhanMay = NguoiSuDung.ID;
            //lapTopData.ThanhTien = mayTinh.ThanhTien;

            //CSDL.LapTops.Add(lapTopData);
            //CSDL.SaveChanges();
            //var duLieuKhachHang2 = from table in CSDL.LapTops select table;
            //foreach (var iteam in duLieuKhachHang2)
            //{
            //    if (iteam.NgayNhan == mayTinh.NgayNhanMay && iteam.NgayNhan == iteam.NgayGiao && iteam.IDChuMay == idChuMay)
            //    {
            //        idMay = iteam.ID;
            //        break;
            //    }
            //}

            ////            CSDL.SaveChanges();

        }
        public int timDonHangTheoIDMay(int iD,out string tenMay,out string NDSuaChua,out string GhiChu,out string ThanhTien,out DateTime NgayGiao)
        {
            DB_QuanLyTTSCMTEntities CSDL = new DB_QuanLyTTSCMTEntities();
            var duLieuMayTinh = from bang in CSDL.LapTops select bang;
            foreach (var mayTinh in duLieuMayTinh)
            {
                #region Có đơn hàng ứng với ID đầu vào
                if (mayTinh.ID.ToString() == iD.ToString())
                    #region Máy tính này chưa được giao
                    if (mayTinh.NgayNhan == mayTinh.NgayGiao)
                    {
                        tenMay = mayTinh.TenMay;
                        NDSuaChua = mayTinh.NDSuaChua;
                        GhiChu = mayTinh.GhiChu;
                        ThanhTien =mayTinh.ThanhTien;
                        NgayGiao = DateTime.Now;
                        return 0;
                    }
                    #endregion
                    #region Máy tính này đã được giao
                    else
                    {
                        tenMay = mayTinh.TenMay;
                        NDSuaChua = mayTinh.NDSuaChua;
                        GhiChu = mayTinh.GhiChu;
                        ThanhTien = mayTinh.ThanhTien;
                        NgayGiao = mayTinh.NgayGiao;
                        return 1;
                    }
                #endregion
                #endregion
            }
            #region Không có đơn hàng ứng với ID đầu vào
            tenMay = "";
            NDSuaChua = "";
            GhiChu = "";
            ThanhTien = "";
            NgayGiao = DateTime.Now;
            return 2;
            #endregion
        }
        public int timIDKhachHangDuaVaoMSSV(string mSSV)
        {
            DB_QuanLyTTSCMTEntities CSDL = new DB_QuanLyTTSCMTEntities();
            var duLieuKhachHang = from bang in CSDL.KhachHangs select bang;
            foreach (var khachHang in duLieuKhachHang)
                #region Có khách hàng ứng với MSSV đầu vào
                if (khachHang.MSSV == mSSV)
                    return khachHang.ID;
            #endregion
            #region Không có khách hàng ứng với MSSV đầu vào
            return -1;
            #endregion
        }
        public ArrayList timCacIDMayDuaVaoMSSVChuMay(string mSSV)
        {
            DB_QuanLyTTSCMTEntities CSDL = new DB_QuanLyTTSCMTEntities();
            var duLieuMayTinh = from bang in CSDL.LapTops select bang;
            ArrayList DSID = new ArrayList();
            int iDChuMay = timIDKhachHangDuaVaoMSSV(mSSV);
            foreach (var mayTinh in duLieuMayTinh)
                if (mayTinh.IDChuMay == iDChuMay)
                    DSID.Add(mayTinh.ID);
            return DSID;
        }
        public void xacNhanDonHang(int ID)
        {
            DateTime datetime = DateTime.Now;
            DB_QuanLyTTSCMTEntities CSDL = new DB_QuanLyTTSCMTEntities();
            var duLieuDonHang = from table in CSDL.LapTops select table;
            foreach (var donHang in duLieuDonHang)
            {
                #region Thay đổi ngày giao của đơn hàng trong dữ liệu
                if (donHang.ID.ToString() == ID.ToString())
                {
                    donHang.NgayGiao = datetime;
                    break;
                }
                #endregion
            }
            CSDL.SaveChanges();//Lưu lại sự thay đổi của dữ liệu
        }
        public bool kiemTraSDT(string sdt)
        {
            if (sdt[0] != '0')
                return false;
            bool kt = true;
            for (int i = 0; i < sdt.Length; i++)
            {
                if (!char.IsDigit(sdt[i]))
                    return false;
            }
            return kt;
        }
        public abstract void themNhanVien(string ten, string mSSV, string sDT, string tenTaiKhoan, string mKTaiKhoan, bool quyenQuanLy);
        public int DoiMatKhau(string matKhauCu,string matKhauMoi,string XNMatKhauMoi)
        {
            bool kiemTra = false;
            DB_QuanLyTTSCMTEntities CSDL = new DB_QuanLyTTSCMTEntities();
            var duLieuNhanVien = from bang in CSDL.NhanViens select bang;
            foreach(var nhanVien in duLieuNhanVien)
                if(nhanVien.ID==NguoiSuDung.ID)
                {
                    #region Thay đổi mật khẩu thành công
                    if (nhanVien.MKTaiKhoan == matKhauCu)
                        if (matKhauMoi == XNMatKhauMoi)
                        {
                            nhanVien.MKTaiKhoan = matKhauMoi;
                            kiemTra = true;
                            break;
                        }
                        #endregion
                }
            CSDL.SaveChanges();
            if (kiemTra==true)
                return 0;
            if (matKhauMoi != XNMatKhauMoi)
                return 1;//Mật khẩu mới và xác nhận mật khẩu mới không trùng khớp
            return 2;//Mật khẩu cũ không đúng
        }
    }
}
