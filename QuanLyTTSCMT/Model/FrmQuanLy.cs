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
namespace QuanLyTTSCMT.Model
{

    public partial class FrmQuanLy : Form
    {

        private QuanLyRoot quanLyRoot;
        public FrmQuanLy()
        {
            InitializeComponent();
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
        private void FrmQuanLy_Load(object sender, EventArgs e)
        {
            this.iteamScriptDoiMatKhau.Visible = false;
            this.itemScriptDangXuat.Visible = false;
            DB_QuanLyTTSCMTEntities newDataBase = new DB_QuanLyTTSCMTEntities();
            var select = from table in newDataBase.NhanViens select table;
            foreach (var iteam in select)
                if (iteam.ID == NguoiSuDung.ID)
                {
                    if(iteam.LaQuanLy == true)
                    {
                        quanLyRoot = new QuanLyRoot(iteam.Ten, iteam.MSSV, iteam.SDT, iteam.TenTaiKhoan, iteam.MKTaiKhoan);
                        lblNguoiNhanMay.Text = "Người nhận máy: " + iteam.Ten;
                        //tabQuanLy.TabPages.Remove(tabThongKe);
                        //tabQuanLy.TabPages.Remove(tabThemNhanVien);
                        break;
                    }
                    else
                    {
                        quanLyRoot = new QuanLyRoot(iteam.Ten, iteam.MSSV, iteam.SDT, iteam.TenTaiKhoan, iteam.MKTaiKhoan);
                        lblNguoiNhanMay.Text = "Người nhận máy: " + iteam.Ten;
                        tabCaNhan.TabPages.Remove(tabThongKe);
                        tabCaNhan.TabPages.Remove(tabThemNhanVien);

                        break;
                    }
                }
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
            else if (!quanLyRoot.kiemTraSDT(txtSDTNV.Text.Trim()) || txtSDTNV.TextLength != 10)
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
                    quanLyRoot.themNhanVien(txtTenNhanVien.Text, txtMSSVNV.Text, txtSDTNV.Text, txtTenTaiKhoan.Text, txtMatKhau.Text, cbQuyenQuanLy.Checked);
                    MessageBox.Show("Thêm nhân viên thành công:");
                }
                else
                    MessageBox.Show("Nhân Viên hoặc Tài Khoản đã tồn tại", "Lỗi");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
        }

        private void tabXacNhanTraMay_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            btnLuu.Show();
            cbTraMay.Show();
            if (txtIdMayNhan.Text.Trim() == "")
                MessageBox.Show("Bạn hãy nhập ID Máy cần tìm", "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            else
            {
                bool check = true;
                DB_QuanLyTTSCMTEntities data = new DB_QuanLyTTSCMTEntities();
                var duLieuKhachHang = from table in data.LapTops select table;
                foreach (var iteam in duLieuKhachHang)
                {
                    if (iteam.ID.ToString() == txtIdMayNhan.Text.Trim())
                        if (iteam.NgayNhan == iteam.NgayGiao)
                        {
                          //  dgvThongTinDonHang.Rows.Add();
                            int i = 0;
                            dgvThongTinDonHang.Rows[0].Cells[i++].Value = iteam.TenMay;
                            dgvThongTinDonHang.Rows[0].Cells[i++].Value = iteam.NDSuaChua;
                            dgvThongTinDonHang.Rows[0].Cells[i++].Value = iteam.GhiChu;
                            dgvThongTinDonHang.Rows[0].Cells[i++].Value = iteam.ThanhTien;
                            check = false;
                            break;
                        }
                        else
                        {
                          //  dgvThongTinDonHang.Rows.Add();
                            int i = 0;
                            dgvThongTinDonHang.Rows[0].Cells[i++].Value = iteam.TenMay;
                            dgvThongTinDonHang.Rows[0].Cells[i++].Value = iteam.NDSuaChua;
                            dgvThongTinDonHang.Rows[0].Cells[i++].Value = iteam.GhiChu;
                            dgvThongTinDonHang.Rows[0].Cells[i++].Value = iteam.ThanhTien;
                            MessageBox.Show("Đơn hàng có ID="+txtIdMayNhan.Text.Trim()+ " đã được giao vào lúc " + iteam.NgayGiao.ToString(),"Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            check = false;
                            break;
                        }
                }
                if (check)
                {
                    int j = 0;
                    dgvThongTinDonHang.Rows[0].Cells[j++].Value = "";
                    dgvThongTinDonHang.Rows[0].Cells[j++].Value = "";
                    dgvThongTinDonHang.Rows[0].Cells[j++].Value = "";
                    dgvThongTinDonHang.Rows[0].Cells[j++].Value = "";
                    MessageBox.Show("Không có đơn hàng nào ứng với ID = " + txtIdMayNhan.Text.Trim(), "Lỗi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbTraMay.Checked)
            {
                DateTime datetime = DateTime.Now;
                DB_QuanLyTTSCMTEntities data = new DB_QuanLyTTSCMTEntities();
                var duLieuKhachHang = from table in data.LapTops select table;
                foreach (var iteam in duLieuKhachHang)
                {

                    if (iteam.ID.ToString() == txtIdMayNhan.Text.Trim())
                        if (iteam.NgayNhan == iteam.NgayGiao)
                        {
                            iteam.NgayGiao = datetime;
                            MessageBox.Show("Lưu thành công");
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Máy này đã được giao, không thể giao lại");
                        }
                }
                data.SaveChanges();
                cbTraMay.Checked = false;
            }
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
                MessageBox.Show("Bạn phải điền hết thông tin chúng tôi yêu cầu", "Lỗi");
            else if (!kiemTraSDT(txtSDT.Text.Trim()))
                MessageBox.Show("Số điện thoại không hợp lệ", "Lỗi");
            else if (!kiemTraTien(txtThanhTien.Text.Trim()))
                MessageBox.Show("Số tiền không hợp lệ", "Lỗi");
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
                    Nguoi khachHang = new Nguoi(txtTenKhachHang.Text.Trim(), txtMSSV.Text.Trim(), txtSDT.Text.Trim(), null, null);
                    LaptopRoot mayTinh = new LaptopRoot(txtTenNhanVien.Text.Trim(), txtTenMay.Text.Trim(), txtTenKhachHang.Text.Trim(), timeNgayNhan.Value, new DateTime(), rtbNDSuaChua.Text.Trim(), rtbGhiChu.Text.Trim(), txtThanhTien.Text.Trim());
                    quanLyRoot.NhapDonHang(khachHang, mayTinh, ref idMay);
                    lblIdMay.Text = "ID máy: " + idMay.ToString();
                    MessageBox.Show("Thêm đơn hàng thành công");
                }
            }
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void txtIdMayNhan_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnLuu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                bool check = true;
                if (txtTenKhachHang.Text.Trim() == "" || txtMSSV.Text.Trim() == "" || txtSDT.Text.Trim() == "null" || txtTenMay.Text.Trim() == "" || rtbNDSuaChua.Text.Trim() == "" || rtbGhiChu.Text.Trim() == "" || txtThanhTien.Text.Trim() == "")
                    MessageBox.Show("Bạn phải điền hết thông tin chúng tôi yêu cầu", "Lỗi");
                else if (!kiemTraSDT(txtSDT.Text.Trim()))
                    MessageBox.Show("Số điện thoại không hợp lệ", "Lỗi");
                else if (!kiemTraTien(txtThanhTien.Text.Trim()))
                    MessageBox.Show("Số tiền không hợp lệ", "Lỗi");
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
                                    MessageBox.Show("Đơn này đã tồn tại", "Lỗi");
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
                        Nguoi khachHang = new Nguoi(txtTenKhachHang.Text.Trim(), txtMSSV.Text.Trim(), txtSDT.Text.Trim(), null, null);
                        LaptopRoot mayTinh = new LaptopRoot(txtTenNhanVien.Text.Trim(), txtTenMay.Text.Trim(), txtTenKhachHang.Text.Trim(), timeNgayNhan.Value, new DateTime(), rtbNDSuaChua.Text.Trim(), rtbGhiChu.Text.Trim(), txtThanhTien.Text.Trim());
                        quanLyRoot.NhapDonHang(khachHang, mayTinh, ref idMay);
                        lblIdMay.Text = "ID máy: " + idMay.ToString();
                        MessageBox.Show("Thêm đơn hàng thành công");
                    }
                }
            }
            
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            //txtDMKMatKhauCu.SelectAll();
       
        }

        private void txtDMKMatKhauMoi_Click(object sender, EventArgs e)
        {
            //txtDMKMatKhauMoi.SelectAll();
        }

        private void txtDMKXacNhanMatKhau_Click(object sender, EventArgs e)
        {
          //  txtDMKXacNhanMatKhau.SelectAll();

        }

        private void txtDMKLuu_Click(object sender, EventArgs e)
        {
            //string mkc = txtDMKMatKhauCu.Text.ToString().Trim();
            //string mkm = txtDMKMatKhauMoi.Text.ToString().Trim();
            //string xnmkm = txtDMKXacNhanMatKhau.Text.ToString().Trim();
            //if (mkc == "" || mkm == "" || xnmkm == "")
            //    MessageBox.Show("Mời bạn điền đầy đủ thông tin", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //else if (quanLyRoot.MKTaiKhoan != mkc)
            //    MessageBox.Show("Mật khẩu cũ không chính xác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //else if (mkm != xnmkm)
            //    MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu mới của bạn không trùng khớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //else
            //{
            //    quanLyRoot.doiMatKhau(mkm);
            //    MessageBox.Show("Đổi mật khẩu thành công", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //txtDMKMatKhauCu.Text = "Mật khẩu cũ";
            //txtDMKMatKhauMoi.Text = "Mật khẩu mới";
            //txtDMKXacNhanMatKhau.Text = "XN mật khẩu";
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
            this.iteamScriptDoiMatKhau.Visible = true;
            this.itemScriptDangXuat.Visible = true;
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
    }
}
