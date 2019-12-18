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
    public partial class FrmDoiMatKhau : Form
    {
        public FrmDoiMatKhau()
        {
            InitializeComponent();
        }
        #region Form load
        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }
        #endregion
        #region Khi ấn xác nhận đổi mật khẩu
        private void btnXacNhanDoiMatKhau_Click(object sender, EventArgs e)
        {
            string mKC = txtMatKhauCu.Text.Trim();
            string mKM = txtMatKhauMoi.Text.Trim();
            string xNMKM = txtXacNhanMatKhauMoi.Text.Trim();
            int kq = (new NhanVienRoot()).DoiMatKhau(mKC, mKM, xNMKM);
            if (kq == 0)
            {
                MessageBox.Show("Đổi mật khẩu thành công", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else if (kq == 1)
                MessageBox.Show("Xác nhận mật khẩu không trùng khớp", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (kq == 3)
                MessageBox.Show("Mật khẩu mới không được để trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                MessageBox.Show("Mật khẩu không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion
        #region Một số sự kiện hỗ trợ
        private void txtMatKhauCu_Click(object sender, EventArgs e)
        {
            txtMatKhauCu.SelectAll();
        }

        private void txtMatKhauMoi_Click(object sender, EventArgs e)
        {
            txtMatKhauMoi.SelectAll();
        }

        private void txtXacNhanMatKhauMoi_Click(object sender, EventArgs e)
        {
            txtXacNhanMatKhauMoi.SelectAll();
        }
        #endregion
        #region Một số sự kiện ngoài ý muốn
        private void txtMatKhauCu_TextChanged(object sender, EventArgs e)
        {

        }
        private void FrmDoiMatKhau_Enter(object sender, EventArgs e)
        {
            
        }
        #endregion
    }
}
