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

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            
        }

        private void FrmDangNhap_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                DB_QuanLyTTSCMTEntities newDataBase = new DB_QuanLyTTSCMTEntities();
                var select = from table in newDataBase.NhanViens select table;
                bool check = false;
                foreach (var iteam in select)
                {
                    if (iteam.TenTaiKhoan.ToString() == txtTenTaiKhoan.Text && iteam.MKTaiKhoan.ToString() == txtMatKhau.Text)
                    {
                        NguoiSuDung.ID = iteam.ID;
                        check = true;
                        if (iteam.LaQuanLy == true)
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
                if (!check)
                    MessageBox.Show("Sai mật khấu hoặc tên tài khoản", "Lỗi");
                if (check)
                    this.Close();
            }
        }

        private void FrmDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DB_QuanLyTTSCMTEntities newDataBase = new DB_QuanLyTTSCMTEntities();
                var select = from table in newDataBase.NhanViens select table;
                bool check = false;
                foreach (var iteam in select)
                {
                    if (iteam.TenTaiKhoan.ToString() == txtTenTaiKhoan.Text && iteam.MKTaiKhoan.ToString() == txtMatKhau.Text)
                    {
                        NguoiSuDung.ID = iteam.ID;
                        check = true;
                        if (iteam.LaQuanLy == true)
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
                if (!check)
                    MessageBox.Show("Sai mật khấu hoặc tên tài khoản", "Lỗi");
                if (check)
                    this.Close();
            }
        }

        private void btnDangNhap_Click_1(object sender, EventArgs e)
        {
            DB_QuanLyTTSCMTEntities newDataBase = new DB_QuanLyTTSCMTEntities();
            var select = from table in newDataBase.NhanViens select table;
            bool check = false;
            foreach (var iteam in select)
            {
                if (iteam.TenTaiKhoan.ToString() == txtTenTaiKhoan.Text && iteam.MKTaiKhoan.ToString() == txtMatKhau.Text)
                {
                    NguoiSuDung.ID = iteam.ID;
                    check = true;
                    if (iteam.LaQuanLy == true)
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
            if (!check)
                MessageBox.Show("Sai mật khấu hoặc tên tài khoản", "Lỗi");
            if (check)
                this.Close();
        }

        private void btnDangNhap_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DB_QuanLyTTSCMTEntities newDataBase = new DB_QuanLyTTSCMTEntities();
                var select = from table in newDataBase.NhanViens select table;
                bool check = false;
                foreach (var iteam in select)
                {
                    if (iteam.TenTaiKhoan.ToString() == txtTenTaiKhoan.Text && iteam.MKTaiKhoan.ToString() == txtMatKhau.Text)
                    {
                        NguoiSuDung.ID = iteam.ID;
                        check = true;
                        if (iteam.LaQuanLy == true)
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
                if (!check)
                    MessageBox.Show("Sai mật khấu hoặc tên tài khoản", "Lỗi");
                if (check)
                    this.Close();
            }
        }

        private void btnDangNhap_Enter(object sender, EventArgs e)
        {
            DB_QuanLyTTSCMTEntities newDataBase = new DB_QuanLyTTSCMTEntities();
            var select = from table in newDataBase.NhanViens select table;
            bool check = false;
            foreach (var iteam in select)
            {
                if (iteam.TenTaiKhoan.ToString() == txtTenTaiKhoan.Text && iteam.MKTaiKhoan.ToString() == txtMatKhau.Text)
                {
                    NguoiSuDung.ID = iteam.ID;
                    check = true;
                    if (iteam.LaQuanLy == true)
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
            if (!check)
                MessageBox.Show("Sai mật khấu hoặc tên tài khoản", "Lỗi");
            if (check)
                this.Close();
        }

        private void lblTenTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void txtTenTaiKhoan_Click(object sender, EventArgs e)
        {
            txtTenTaiKhoan.SelectAll();
        }

        private void txtMatKhau_Click(object sender, EventArgs e)
        {
            txtMatKhau.SelectAll();
        }
    }
}
