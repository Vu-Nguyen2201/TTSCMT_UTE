using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyTTSCMT.Model;
using System.Collections;
namespace QuanLyTTSCMT.Model
{

    public partial class FrmQuanLy : Form
    {
        private Nguoi NguoiSuDungRoot;

        public FrmQuanLy()
        {
            InitializeComponent();
        }
        private void FrmQuanLy_Load(object sender, EventArgs e)
        {
            btnTraMay.Visible = false;
            this.iteamScriptDoiMatKhau.Visible = false;
            this.iteamScriptDangXuat.Visible = false;
            DB_QuanLyTTSCMTEntities CSDL = new DB_QuanLyTTSCMTEntities();
            var duLieuNhanVien = from bang in CSDL.NhanViens select bang;
            foreach (var nhanVien in duLieuNhanVien)
                if (nhanVien.ID == NguoiSuDung.ID)
                {
                    if (nhanVien.LaQuanLy == true)
                    {
                        NguoiSuDungRoot = new QuanLyRoot(nhanVien.Ten, nhanVien.MSSV, nhanVien.SDT, nhanVien.TenTaiKhoan, nhanVien.MKTaiKhoan);
                        lblNguoiNhanMay.Text = "Người nhận máy: " + nhanVien.Ten;
                        //tabQuanLy.TabPages.Remove(tabThongKe);
                        //tabQuanLy.TabPages.Remove(tabThemNhanVien);
                        break;
                    }
                    else
                    {
                        NguoiSuDungRoot = new NhanVienRoot(nhanVien.Ten, nhanVien.MSSV, nhanVien.SDT, nhanVien.TenTaiKhoan, nhanVien.MKTaiKhoan);
                        lblNguoiNhanMay.Text = "Người nhận máy: " + nhanVien.Ten;
                        tabCaNhan.TabPages.Remove(tabThongKe);
                        tabCaNhan.TabPages.Remove(tabThemNhanVien);
                        break;
                    }
                }
        }

        public bool kiemTraSDT(string sdt)
        {
            if (sdt[0] != '0'||(sdt.Length!=10&&sdt.Length!=11))
                return false;
            bool kt = true;
            for (int i = 0; i < sdt.Length; i++)
            {
                if (!char.IsDigit(sdt[i]))
                    return false;
            }
            return kt;
        }
        public bool kiemTraTien(string sdt)
        {
            bool kt = true;
            for (int i = 0; i < sdt.Length; i++)
            {
                if (!char.IsDigit(sdt[i]))
                    return false;
            }
            return kt;
        }

        private void dataThongKe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {

            if (txtTenNhanVien.Text.Trim() == "" || txtMSSVNV.Text.Trim() == "" || txtSDTNV.Text.Trim() == "" || txtTenTaiKhoan.Text.Trim() == "" || txtMatKhau.Text.Trim() == "")
                MessageBox.Show("Bạn phải điền hết thông tin chúng tôi yêu cầu", "Lỗi");
            else if (txtMatKhau.Text.Trim() != txtXNMK.Text.Trim())
            {
                txtXNMK.Text = "";
                MessageBox.Show("Mời bạn xác nhận lại mật khẩu");
            }
            else if (!NguoiSuDungRoot.kiemTraSDT(txtSDTNV.Text.Trim()) || txtSDTNV.TextLength != 10)
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Lỗi");
            }
            else
            {
                DB_QuanLyTTSCMTEntities newDataBase = new DB_QuanLyTTSCMTEntities();
                var select = from table in newDataBase.NhanViens select table;
                bool check = true;

                foreach (var iteam in select)
                {
                    if (iteam.MSSV == txtMSSVNV.Text || iteam.TenTaiKhoan == txtTenTaiKhoan.Text)
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                {
                    NguoiSuDungRoot.themNhanVien(txtTenNhanVien.Text, txtMSSVNV.Text, txtSDTNV.Text, txtTenTaiKhoan.Text, txtMatKhau.Text, cbQuyenQuanLy.Checked);
                    MessageBox.Show("Thêm nhân viên thành công:");
                }
                else
                    MessageBox.Show("Nhân Viên hoặc Tài Khoản đã tồn tại", "Lỗi");
            }
        }

        private void tabXacNhanTraMay_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvThongTinDonHang.Rows.Clear();
            if (cbBLoaiTimKiem.Text == "")
                MessageBox.Show("Bạn phải chọn loại tìm kiếm","Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            #region Tìm kiếm theo ID của Máy
            else if(cbBLoaiTimKiem.Text=="ID Máy")
            {
                string ID = txtIDMHoacMSSV.Text.Trim();
                if (ID == "")
                    MessageBox.Show("Bạn hãy nhập ID Máy cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if(!int.TryParse(ID,out int a))
                {
                    MessageBox.Show("ID không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {

                    dgvThongTinDonHang.Rows.Add();
                    string tenMay, nDSuaChua, ghiChu, thanhTien;
                    DateTime NgayGiao;
                    int tinhTrang = NguoiSuDungRoot.timDonHangTheoIDMay(Convert.ToUInt16(ID), out tenMay, out nDSuaChua, out ghiChu, out thanhTien, out NgayGiao);
                    dgvThongTinDonHang.Rows[0].Cells[0].Value = tenMay;
                    dgvThongTinDonHang.Rows[0].Cells[1].Value = nDSuaChua;
                    dgvThongTinDonHang.Rows[0].Cells[2].Value = ghiChu;
                    dgvThongTinDonHang.Rows[0].Cells[3].Value = thanhTien;
                    if (tinhTrang == 0)
                        btnTraMay.Visible = true;
                    else
                    {
                        if (tinhTrang == 1)
                            MessageBox.Show("Đơn hàng có ID=" + ID + " đã được giao vào lúc " + NgayGiao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Không có đơn hàng nào ứng với ID = " + ID, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnTraMay.Visible = false;
                    }
                }
            }
            #endregion
            #region Tìm kiếm theo MSSV của Chủ máy
            else
            {
                string MSSV = txtIDMHoacMSSV.Text.Trim();
                if (MSSV == "")
                    MessageBox.Show("Bạn hãy nhập MSSV Chủ Máy cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {

                    string tenMay, nDSuaChua, ghiChu, thanhTien;
                    DateTime NgayGiao;
                    int soHang = 0;
                    foreach(int ID in NguoiSuDungRoot.timCacIDMayDuaVaoMSSVChuMay(MSSV))
                    {
                        dgvThongTinDonHang.Rows.Add();
                        int tinhTrang = NguoiSuDungRoot.timDonHangTheoIDMay(ID, out tenMay, out nDSuaChua, out ghiChu, out thanhTien, out NgayGiao);
                        dgvThongTinDonHang.Rows[soHang].Cells[0].Value = tenMay;
                        dgvThongTinDonHang.Rows[soHang].Cells[1].Value = nDSuaChua;
                        dgvThongTinDonHang.Rows[soHang].Cells[2].Value = ghiChu;
                        dgvThongTinDonHang.Rows[soHang++].Cells[3].Value = thanhTien;
                    }
                    if (NguoiSuDungRoot.timIDKhachHangDuaVaoMSSV(MSSV) == -1)
                        MessageBox.Show("Không có khách hàng nào có mssv :" + MSSV,"Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Mời bạn chọn máy tính cần giao", "Thông báo",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(cbBLoaiTimKiem.Text == "ID Máy")
                NguoiSuDungRoot.xacNhanDonHang(Convert.ToInt32(txtIDMHoacMSSV.Text.Trim()));
            else
                NguoiSuDungRoot.xacNhanDonHang(Convert.ToInt32(NguoiSuDungRoot.timCacIDMayDuaVaoMSSVChuMay(txtIDMHoacMSSV.Text.Trim())[0]));
            MessageBox.Show("Đơn hàng đã được giao","Thành Công",MessageBoxButtons.OK,MessageBoxIcon.Information);
            foreach(var may in dgvThongTinDonHang.SelectedRows)
            {

            }
            btnTraMay.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(var iteam in dataThongKe.Rows)
            {
                dataThongKe.Rows.Clear();
            }
            if (timeTuNgay.Value.Date > timeDenNgay.Value.Date)
                MessageBox.Show("Số ngày của bạn không hợp lệ", "lỗi");
            else
            {
                DB_QuanLyTTSCMTEntities data = new DB_QuanLyTTSCMTEntities();
                var duLieuKhachHang = from table in data.LapTops select table;
                int i = 0;
                Double tongTien = 0;
                foreach (var iteam in duLieuKhachHang)
                {
                    int j = 0;
                    if (iteam.NgayGiao.Date >= timeTuNgay.Value.Date && iteam.NgayGiao.Date <= timeDenNgay.Value.Date)
                    {
                        dataThongKe.Rows.Add();
                        dataThongKe.Rows[i].Cells[j++].Value = i + 1;
                        dataThongKe.Rows[i].Cells[j++].Value = iteam.TenMay;
                        dataThongKe.Rows[i].Cells[j++].Value = iteam.ID;
                        dataThongKe.Rows[i].Cells[j++].Value = iteam.NgayNhan;
                        dataThongKe.Rows[i].Cells[j++].Value = iteam.NgayGiao;
                        dataThongKe.Rows[i].Cells[j++].Value = iteam.IDChuMay;
                        dataThongKe.Rows[i].Cells[j++].Value = iteam.IDNguoiNhanMay;
                        dataThongKe.Rows[i].Cells[j++].Value = iteam.ThanhTien;
                        if (iteam.NgayNhan != iteam.NgayGiao)
                            dataThongKe.Rows[i++].Cells[j++].Value = "Đã Giao";
                        else
                            dataThongKe.Rows[i++].Cells[j++].Value = "Đang Sửa";
                        tongTien += Convert.ToDouble(iteam.ThanhTien);
                    }
                }
                lblTongTienValues.Text = tongTien.ToString() + " VND";
            }
            
        }

        private void lblTongTienValues_Click(object sender, EventArgs e)
        {

        }

        private void txtTenKhachHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabNhapDonHang_Click(object sender, EventArgs e)
        {

        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            bool check = true;
            if (txtTenKhachHang.Text.Trim() == "" || txtMSSV.Text.Trim() == "" || txtSDT.Text.Trim() == "null" || txtTenMay.Text.Trim() == "" || rtbNDSuaChua.Text.Trim() == "" || rtbGhiChu.Text.Trim() == "" || txtThanhTien.Text.Trim() == "")
                MessageBox.Show("Bạn phải điền hết thông tin chúng tôi yêu cầu", "Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else if (!kiemTraSDT(txtSDT.Text.Trim()))
                MessageBox.Show("Số điện thoại không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!kiemTraTien(txtThanhTien.Text.Trim()))
                MessageBox.Show("Số tiền không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DB_QuanLyTTSCMTEntities data = new DB_QuanLyTTSCMTEntities();
                var duLieuKhachHang = from table in data.KhachHangs select table;
                foreach (var iteam in duLieuKhachHang)
                {
                    if (iteam.MSSV == txtMSSV.Text)
                    {
                        var duLieuKhachHang1 = from table in data.LapTops select table;
                        foreach (var iteam1 in duLieuKhachHang1)
                        {
                            if (iteam1.TenMay == txtTenMay.Text.Trim() && iteam1.NgayNhan == iteam1.NgayGiao)
                            {
                                check = false;
                                MessageBox.Show("Đơn này đã tồn tại", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                break;
                            }
                        }
                        if (check == false)
                            break;
                    }
                }
                if (check)
                {
                    int idMay = 0;
                    NhanVienRoot khachHang = new NhanVienRoot(txtTenKhachHang.Text.Trim(), txtMSSV.Text.Trim(), txtSDT.Text.Trim(),null,null);
                    LaptopRoot mayTinh = new LaptopRoot(txtTenNhanVien.Text.Trim(), txtTenMay.Text.Trim(), txtTenKhachHang.Text.Trim(), timeNgayNhan.Value, new DateTime(), rtbNDSuaChua.Text.Trim(), rtbGhiChu.Text.Trim(), txtThanhTien.Text.Trim());
                    NguoiSuDungRoot.NhapDonHang(khachHang, mayTinh, ref idMay);
                    lblIdMay.Text = "ID máy: " + idMay.ToString();
                    MessageBox.Show("Thêm đơn hàng thành công");
                }
            }
        }
        private void txtIdMayNhan_TextChanged(object sender, EventArgs e)
        {
         //   txtIDMHoacMSSV.SelectAll();
        }

        private void btnLuu_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    bool check = true;
            //    if (txtTenKhachHang.Text.Trim() == "" || txtMSSV.Text.Trim() == "" || txtSDT.Text.Trim() == "null" || txtTenMay.Text.Trim() == "" || rtbNDSuaChua.Text.Trim() == "" || rtbGhiChu.Text.Trim() == "" || txtThanhTien.Text.Trim() == "")
            //        MessageBox.Show("Bạn phải điền hết thông tin chúng tôi yêu cầu", "Lỗi");
            //    else if (!kiemTraSDT(txtSDT.Text.Trim()))
            //        MessageBox.Show("Số điện thoại không hợp lệ", "Lỗi");
            //    else if (!kiemTraTien(txtThanhTien.Text.Trim()))
            //        MessageBox.Show("Số tiền không hợp lệ", "Lỗi");
            //    else
            //    {
            //        DB_QuanLyTTSCMTEntities data = new DB_QuanLyTTSCMTEntities();
            //        var duLieuKhachHang = from table in data.KhachHangs select table;
            //        foreach (var iteam in duLieuKhachHang)
            //        {
            //            if (iteam.MSSV == txtMSSV.Text)
            //            {
            //                var duLieuKhachHang1 = from table in data.LapTops select table;
            //                foreach (var iteam1 in duLieuKhachHang1)
            //                {
            //                    if (iteam1.TenMay == txtTenMay.Text.Trim() && iteam1.NgayNhan == iteam1.NgayGiao)
            //                    {
            //                        check = false;
            //                        MessageBox.Show("Đơn này đã tồn tại", "Lỗi");
            //                        break;
            //                    }
            //                }
            //                if (check == false)
            //                    break;
            //            }
            //        }
            //        if (check)
            //        {
            //            int idMay = 0;
            //            Nguoi khachHang = new Nguoi(txtTenKhachHang.Text.Trim(), txtMSSV.Text.Trim(), txtSDT.Text.Trim(), null, null);
            //            LaptopRoot mayTinh = new LaptopRoot(txtTenNhanVien.Text.Trim(), txtTenMay.Text.Trim(), txtTenKhachHang.Text.Trim(), timeNgayNhan.Value, new DateTime(), rtbNDSuaChua.Text.Trim(), rtbGhiChu.Text.Trim(), txtThanhTien.Text.Trim());
            //            quanLyRoot.NhapDonHang(khachHang, mayTinh, ref idMay);
            //            lblIdMay.Text = "ID máy: " + idMay.ToString();
            //            MessageBox.Show("Thêm đơn hàng thành công");
            //        }
            //    }
            //}

        }
        private void toolStripTextBox1_Click_1(object sender, EventArgs e)
        {
            
            DialogResult kq = MessageBox.Show("Bạn có thật sự muốn đăng xuất không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (kq == DialogResult.Yes)
            {
                this.Hide();
                (new FrmDangNhap()).ShowDialog();
            }
        }

        private void menuTaiKhoan_Click(object sender, EventArgs e)
        {
            if(this.iteamScriptDoiMatKhau.Visible == false)
            {
                this.iteamScriptDoiMatKhau.Visible = true;
                this.iteamScriptDangXuat.Visible = true;
            }
            else
            {
                this.iteamScriptDoiMatKhau.Visible = false;
                this.iteamScriptDangXuat.Visible = false;
            }
        }

        private void iteamScriptDoiMatKhau_Click(object sender, EventArgs e)
        {
            (new FrmDoiMatKhau()).ShowDialog();   
        }

        private void FrmQuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
     
        }
    
        private void FrmQuanLy_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtIdMayNhan_Click(object sender, EventArgs e)
        {
            txtIDMHoacMSSV.SelectAll();
        }

        private void dgvThongTinDonHang_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvThongTinDonHang_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvThongTinDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //dgvThongTinDonHang.Rows[e.RowIndex].Selected = true;
            if (e.RowIndex != -1 && cbBLoaiTimKiem.Text=="MSSV Chủ Máy")//Kiểm tra xem người dùng có chọn hàng nào hay không
            {
                int ID = Convert.ToInt32(NguoiSuDungRoot.timCacIDMayDuaVaoMSSVChuMay(txtIDMHoacMSSV.Text)[e.RowIndex]);
                txtIDMHoacMSSV.Text = ID.ToString();
                cbBLoaiTimKiem.Text = "ID Máy";
                dgvThongTinDonHang.Rows.Clear();
                string tenMay, nDSuaChua, ghiChu, thanhTien;
                DateTime NgayGiao;
                int tinhTrang = NguoiSuDungRoot.timDonHangTheoIDMay(ID, out tenMay, out nDSuaChua, out ghiChu, out thanhTien, out NgayGiao);
                dgvThongTinDonHang.Rows.Add();
                dgvThongTinDonHang.Rows[0].Cells[0].Value = tenMay;
                dgvThongTinDonHang.Rows[0].Cells[1].Value = nDSuaChua;
                dgvThongTinDonHang.Rows[0].Cells[2].Value = ghiChu;
                dgvThongTinDonHang.Rows[0].Cells[3].Value = thanhTien;
                if (tinhTrang == 0)
                    btnTraMay.Visible = true;
                else
                {
                    //  if (tinhTrang == 1)
                    MessageBox.Show("Đơn hàng có ID=" + ID + " đã được giao vào lúc " + NgayGiao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //else
                    //  MessageBox.Show("Không có đơn hàng nào ứng với ID = " + ID, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnTraMay.Visible = false;
                }
            }
        }



        private void iteamScriptDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult luaChon = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(luaChon==DialogResult.Yes)
            {
                this.Hide();
                (new FrmDangNhap()).ShowDialog();
            }

        }

        private void dgvThongTinDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
