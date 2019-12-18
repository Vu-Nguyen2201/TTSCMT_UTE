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
namespace QuanLyTTSCMT
{
    public partial class FrmDangNhap : Form
    {

        public FrmDangNhap()
        {
            InitializeComponent();
        }
        #region Form load
        private void FrmDangNhap_Load(object sender, EventArgs e)
        {

        }
        #endregion
        #region Khi ấn nút đăng nhập
        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            DB_QuanLyTTSCMTEntities CSDL = new DB_QuanLyTTSCMTEntities();
            var duLieuNhanVien = from bang in CSDL.NhanViens select bang;
            bool kiemTra = false;
            foreach (var nhanVien in duLieuNhanVien)
            {
                if (nhanVien.TenTaiKhoan == txtTenTaiKhoan.Text.Trim() && nhanVien.MKTaiKhoan == txtMatKhau.Text.Trim())
                {
                    NguoiSuDung.ID = nhanVien.ID;
                    kiemTra = true;
                    if (nhanVien.LaQuanLy == true)
                    {
                        this.Hide();
                        (new FrmQuanLy()).ShowDialog();
                    }
                    else
                    {
                        this.Hide();
                        (new FrmQuanLy()).ShowDialog();
                        //(new FrmNhanVien()).ShowDialog();
                    }
                    break;
                }
            }
            if (!kiemTra)
            {
                MessageBox.Show("Sai mật khấu hoặc tên tài khoản", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
            }
            if (kiemTra) txtTenTaiKhoan.Focus();
        }
        #endregion
        #region Khi ấn enter
        private void FrmDangNhap_Enter(object sender, EventArgs e)
        {
            btnDangNhap_Click_1(sender, e);
        }
        #endregion
        #region Một số sự kiện hỗ trợ
        private void txtTenTaiKhoan_Click(object sender, EventArgs e)
        {
            txtTenTaiKhoan.SelectAll();
        }
        private void txtMatKhau_Click(object sender, EventArgs e)
        {
            txtMatKhau.SelectAll();
        }
        private void FrmDangNhap_FormClosed(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
