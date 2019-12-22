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
        #region Form load
        private void FrmQuanLy_Load(object sender, EventArgs e)
        {

            btnThongKe.Visible = false;
            btnTraMay.Visible = false;
            btnHuyDonHang.Visible = false;
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
        #endregion
        #region Nút Lưu trong tab Nhập đơn hàng
        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            #region Chuyển đổi dữ liệu từ form sang dạng string để dễ sử dụng hơn 
            string iDNhanVienSuaMay = txtIDNhanVienSuaMay.Text.Trim();
            string tenKhachHang = txtTenKhachHang.Text.Trim();
            string mSSV = txtMSSV.Text.Trim();
            string sDT = txtSDT.Text.Trim();
            string tenMay = txtTenMay.Text.Trim();
            string nDSuaChua = rtbNDSuaChua.Text.Trim();
            string ghiChu = rtbGhiChu.Text.Trim();
            string thanhTien = txtThanhTien.Text.Trim();
            #endregion
            #region Kiểm tra xem người dùng đã điền đầy đủ thông tin hay chưa ?
            bool kiemTra = true;
            if (iDNhanVienSuaMay == "" || tenKhachHang == "" || mSSV == "" || sDT == "null" || tenMay == "" || nDSuaChua == "" || ghiChu == "" || thanhTien == "")
                MessageBox.Show("Bạn phải điền hết thông tin chúng tôi yêu cầu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!NguoiSuDungRoot.kiemTraSDT(sDT))
                MessageBox.Show("Số điện thoại không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!NguoiSuDungRoot.kiemTraTien(thanhTien))
                MessageBox.Show("Số tiền không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (!NguoiSuDungRoot.kiemTraIDNhanVien(iDNhanVienSuaMay))
                MessageBox.Show("Không có nhân viên nào có ID: " + iDNhanVienSuaMay, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endregion
            #region Kiểm tra xem đơn hàng này có hợp lệ để được thêm vào dữ liệu hay không ?
            else
            {
                DB_QuanLyTTSCMTEntities CSDL = new DB_QuanLyTTSCMTEntities();
                var duLieuKhachHang = from bang in CSDL.KhachHangs select bang;
                foreach (var khachHang in duLieuKhachHang)
                { 
                    if (khachHang.MSSV == mSSV)
                    {
                        var duLieuMayTinh = from bang in CSDL.LapTops select bang;
                        foreach (var mayTinh in duLieuMayTinh)
                        {
                            #region Nếu đơn hàng không hợp lệ thì thông báo cho người dùng biết là đơn hàng này đã tồn tại và chưa được giao
                            if (mayTinh.TenMay == tenMay && mayTinh.NgayNhan == mayTinh.NgayGiao)
                            {
                                kiemTra = false;
                                MessageBox.Show("Đơn này đã tồn tại và chưa được giao", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                            #endregion
                        }
                        if (!kiemTra)
                            break;
                    }
                }

                #region Nếu đơn hàng hợp lệ thì thêm đơn hàng vào dữ liệu
                if (kiemTra)
                {
                    int idMay = 0;
                    NhanVienRoot khachHang = new NhanVienRoot(tenKhachHang, mSSV, sDT, null, null);
                    LaptopRoot mayTinh = new LaptopRoot(Convert.ToInt32(iDNhanVienSuaMay),-1,-1, tenMay,-1, tenKhachHang, timeNgayNhan.Value, new DateTime(), nDSuaChua, ghiChu, thanhTien,"Đang sửa");
                    NguoiSuDungRoot.NhapDonHang(khachHang, mayTinh, ref idMay);
                    lblIdMay.Text = "ID máy: " + idMay.ToString();
                    MessageBox.Show("Thêm đơn hàng thành công");
                }

            }
            #endregion
            #endregion
        }
        #endregion
        #region Nút tìm kiếm trong tab Tìm kiếm đơn hàng
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dgvThongTinDonHang.Rows.Clear();
            btnHuyDonHang.Visible = false;
            btnTraMay.Visible = false;
            #region Kiểm tra xem người dùng đã chọn loại tìm kiếm hay chưa ?
            if (cbBLoaiTimKiem.Text == "")
                MessageBox.Show("Bạn phải chọn loại tìm kiếm", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endregion
            #region Tìm kiếm theo ID của Máy
            else if (cbBLoaiTimKiem.Text == "ID Máy")
            {
                string ID = txtIDMHoacMSSV.Text.Trim();
                if (ID == "")
                    MessageBox.Show("Bạn hãy nhập ID Máy cần tìm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else if (!int.TryParse(ID, out int a))
                {
                    MessageBox.Show("ID không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dgvThongTinDonHang.Rows.Add();
                    string tenMay, nDSuaChua, ghiChu, thanhTien, tinhTrang;
                    DateTime NgayGiao;
                    #region Sử dụng phương thức timDonHangTheoIDMay để tìm đơn hàng theo ID Máy
                    int ketQua = NguoiSuDungRoot.timDonHangTheoIDMay(Convert.ToUInt16(ID), out tenMay, out nDSuaChua, out ghiChu, out thanhTien, out NgayGiao, out tinhTrang);
                    #endregion
                    #region Sử dụng kết quả trả về của phương thức tìm đơn hàng theo ID Máy để đưa dữ liệu lên form
                    dgvThongTinDonHang.Rows[0].Cells[0].Value = tenMay;
                    dgvThongTinDonHang.Rows[0].Cells[1].Value = nDSuaChua;
                    dgvThongTinDonHang.Rows[0].Cells[2].Value = ghiChu;
                    dgvThongTinDonHang.Rows[0].Cells[3].Value = tinhTrang;
                    dgvThongTinDonHang.Rows[0].Cells[4].Value = thanhTien;
                    if (tinhTrang == "Đã hủy")
                    {
                        MessageBox.Show("Đơn hàng này đã bị hủy vào lúc:" + NgayGiao, "Thông báo", MessageBoxButtons.OK
                       , MessageBoxIcon.Information);
                        btnTraMay.Visible = false;
                        btnHuyDonHang.Visible = false;
                    }
                    else if (ketQua == 0)
                    {
                        btnTraMay.Visible = true;
                        btnHuyDonHang.Visible = true;
                    }
                    else
                    {
                        if (ketQua == 1)
                            MessageBox.Show("Đơn hàng có ID=" + ID + " đã được giao vào lúc " + NgayGiao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Không có đơn hàng nào ứng với ID = " + ID, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnTraMay.Visible = false;
                        btnHuyDonHang.Visible = false;
                    }
                    #endregion
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

                    string tenMay, nDSuaChua, ghiChu, thanhTien, tinhTrang;
                    DateTime NgayGiao;
                    int soHang = 0;
                    #region Sử dụng phương thức timDonHangTheoIDMay để tìm các ID của Máy dựa vào MSSV của chủ máy sau đó đưa dữ liệu cần thiết lên form
                    foreach (int ID in NguoiSuDungRoot.timCacIDMayDuaVaoMSSVChuMay(MSSV))
                    {
                        dgvThongTinDonHang.Rows.Add();
                        int ketQua = NguoiSuDungRoot.timDonHangTheoIDMay(ID, out tenMay, out nDSuaChua, out ghiChu, out thanhTien, out NgayGiao, out tinhTrang);
                        dgvThongTinDonHang.Rows[soHang].Cells[0].Value = tenMay;
                        dgvThongTinDonHang.Rows[soHang].Cells[1].Value = nDSuaChua;
                        dgvThongTinDonHang.Rows[soHang].Cells[2].Value = ghiChu;
                        dgvThongTinDonHang.Rows[soHang].Cells[3].Value = tinhTrang;
                        dgvThongTinDonHang.Rows[soHang++].Cells[4].Value = thanhTien;
                    }
                    if (NguoiSuDungRoot.timIDKhachHangDuaVaoMSSV(MSSV) == -1)
                        MessageBox.Show("Không có khách hàng nào có mssv :" + MSSV, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Mời bạn chọn máy tính cần giao", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    #endregion
                }
            }
            #endregion
        }
        #endregion
        #region Nút hủy đơn hàng trong tab Tìm kiếm đơn hàng
        private void btnHuyDonHang_Click(object sender, EventArgs e)
        {
            DialogResult ketQua = MessageBox.Show("Bạn có thật sự muốn hủy đơn hàng không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ketQua == DialogResult.Yes)
            {
                #region Sử dụng phương thức huyDonHang để hủy đơn hàng
                NguoiSuDungRoot.huyDonHang(Convert.ToInt32(txtIDMHoacMSSV.Text.Trim()));
                #endregion
                #region Thông báo lên form là đã hủy đơn hàng thành công
                MessageBox.Show("Hủy đơn hàng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnHuyDonHang.Visible = false;
                btnTraMay.Visible = false;
                #endregion
            }

        }
        #endregion
        #region Nút trả máy trong tab Tìm kiếm đơn hàng
        private void button1_Click(object sender, EventArgs e)
        {
            #region Sử dụng phương thức xacNhanDonHang để xác nhận đơn hàng là đã giao
            NguoiSuDungRoot.xacNhanDonHang(Convert.ToInt32(txtIDMHoacMSSV.Text.Trim()));
            #endregion
            #region Thông báo lên form là đã giao đơn hàng thành công
            MessageBox.Show("Giao đơn hàng thành công", "Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnHuyDonHang.Visible = false;
            btnTraMay.Visible = false;
            #endregion
        }
        #endregion
        #region Nút thêm nhân viên trong tab Thêm nhân viên
        private void btnThemNhanVien_Click(object sender, EventArgs e)
        {
            #region Chuyển đổi dữ liệu từ form sang dạng string để dễ sử dụng hơn 
            string tenNhanVien = txtTenNhanVien.Text.Trim();
            string mSSVNhanVien = txtMSSVNV.Text.Trim();
            string sDTNhanVien = txtSDTNV.Text.Trim();
            string tenTaiKhoan = txtTenTaiKhoan.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();
            string xNMatKhau = txtXNMK.Text.Trim();
            #endregion
            #region Kiểm tra dữ liệu từ người dùng nhập vào
            if (tenNhanVien == "" || mSSVNhanVien == "" || sDTNhanVien == "" || tenTaiKhoan == "" || matKhau == "")
                MessageBox.Show("Bạn phải điền hết thông tin chúng tôi yêu cầu", "Lỗi");
            else if (matKhau != xNMatKhau)
            {
                txtXNMK.Text = "";
                MessageBox.Show("Mời bạn xác nhận lại mật khẩu");
            }
            else if (!NguoiSuDungRoot.kiemTraSDT(sDTNhanVien))
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Lỗi");
            }
            #endregion
            #region Kiểm tra xem dữ liệu từ người dùng nhập vào có hợp lệ hay không để thêm hoặc không thêm nhân viên
            else
            {
                DB_QuanLyTTSCMTEntities CSDL = new DB_QuanLyTTSCMTEntities();
                var duLieuNhanVien = from bang in CSDL.NhanViens select bang;
                bool kiemTra = true;
                foreach (var nhanVien in duLieuNhanVien)
                {
                    #region Kiểm tra xem Nhân viên đã có tài khoản hoặc tài khoản đã tồn tại hay chưa ?
                    if (nhanVien.MSSV == txtMSSVNV.Text || nhanVien.TenTaiKhoan == txtTenTaiKhoan.Text)
                    {
                        kiemTra = false;
                        break;
                    }
                    #endregion
                }
                #region Nếu Nhân viên hoặc tài khoản chưa tồn tại
                if (kiemTra)
                {
                    #region Sử dụng phương thức themNhanVien để thêm nhân viên vào dữ liệu

                    NguoiSuDungRoot.themNhanVien(txtTenNhanVien.Text, txtMSSVNV.Text, txtSDTNV.Text, txtTenTaiKhoan.Text, txtMatKhau.Text, cbQuyenQuanLy.Checked);
                    #endregion
                    #region Thông báo lên form là đã thêm nhân viên thành công thành công
                    MessageBox.Show("Thêm nhân viên thành công:");
                    #endregion
                }
                #endregion
                #region Nếu Nhân viên hoặc tài khoản đã tồn tại thì thông báo lên form rằng Nhân viên hoặc Tài Khoản đã tồn tại
                else
                    MessageBox.Show("Nhân Viên hoặc Tài Khoản đã tồn tại", "Lỗi");
                #endregion
            }
            #endregion
        }
        #endregion
        #region Bảng thống kê trong tab Thống kê
        private void button2_Click(object sender, EventArgs e)
        {
            Double tongTien = 0;
            dataThongKe.Rows.Clear();
            #region Kiểm tra xem dữ liệu từ form có đúng không
            string loaiTinhTrang = cbbLoaiTinhTrang.Text.Trim();

            if (timeTuNgay.Value.Date > timeDenNgay.Value.Date || timeDenNgay.Value.Date > DateTime.Now.Date)
            {
                MessageBox.Show("Số ngày của bạn không hợp lệ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (loaiTinhTrang == "")
                MessageBox.Show("Bạn phải chọn loại tình trạng để thống kê", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            #endregion
            #region Sử dụng phương thức timCacThongTinMayTuNgayBatDauDenNgayKetThuc để tìm các máy trong khoảng cần tìm và đưa dữ liệu lên form
            else
            {
                int i = 0;
                foreach (var mayTinh in NguoiSuDungRoot.timCacThongTinMayTuNgayBatDauDenNgayKetThuc(timeTuNgay.Value.Date, timeDenNgay.Value.Date))
                {
                    int j = 0;
                    if (mayTinh.TinhTrang == loaiTinhTrang || loaiTinhTrang == "Tất cả")
                    {
                        dataThongKe.Rows.Add();
                        dataThongKe.Rows[i].Cells[j++].Value = i + 1;
                        dataThongKe.Rows[i].Cells[j++].Value = mayTinh.TenMayTinh;
                        dataThongKe.Rows[i].Cells[j++].Value = mayTinh.ID;
                        dataThongKe.Rows[i].Cells[j++].Value = mayTinh.NgayNhanMay;
                        dataThongKe.Rows[i].Cells[j++].Value = mayTinh.NgayGiaoMay;
                        dataThongKe.Rows[i].Cells[j++].Value = mayTinh.IDChuMay;
                        dataThongKe.Rows[i].Cells[j++].Value = mayTinh.IDNguoiNhanMay;
                        dataThongKe.Rows[i].Cells[j++].Value = mayTinh.IDNguoiSuaMay;
                        dataThongKe.Rows[i].Cells[j++].Value = mayTinh.ThanhTien;
                        dataThongKe.Rows[i++].Cells[j++].Value = mayTinh.TinhTrang;
                        #region Tính tổng tiền các máy đã giao
                        if (mayTinh.TinhTrang == "Đã giao")
                            tongTien += Convert.ToDouble(mayTinh.ThanhTien);
                        #endregion
                    }
                    

                }
                if (i == 0)
                    if (loaiTinhTrang == "Tất cả")
                        MessageBox.Show("Từ " + timeTuNgay.Value + " đến " + timeDenNgay.Value + " không có đơn hàng nào được thêm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Từ " + timeTuNgay.Value + " đến " + timeDenNgay.Value + " không có đơn hàng nào có loại tình trạng " + loaiTinhTrang, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            #endregion
            #region Xuất ra form tổng tiền các máy đã giao
            lblTongTienValues.Text = tongTien.ToString() + " VND";
            #endregion

        }
        private void cbbLoaiTinhTrang_SelectedValueChanged(object sender, EventArgs e)
        {

            button2_Click(sender, e);
            
        }
        #endregion
        #region Nút tài khoản
        private void menuTaiKhoan_Click(object sender, EventArgs e)
        {
            if (this.iteamScriptDoiMatKhau.Visible == false)
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
        #endregion
        #region Nút đăng xuất
        private void iteamScriptDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult luaChon = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (luaChon == DialogResult.Yes)
            {
                this.Hide();
                (new FrmDangNhap()).ShowDialog();
            }

        }
        
        #endregion
        #region Nút đổi mật khẩu

        private void iteamScriptDoiMatKhau_Click(object sender, EventArgs e)
        {
            (new FrmDoiMatKhau()).ShowDialog();
        }
        #endregion
        #region Khi ấn chọn đơn hàng trong tab Tìm kiếm đơn hàng
        private void dgvThongTinDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1 && cbBLoaiTimKiem.Text == "MSSV Chủ Máy")//Kiểm tra xem người dùng có chọn hàng nào hay không
            {
                int ID = Convert.ToInt32(NguoiSuDungRoot.timCacIDMayDuaVaoMSSVChuMay(txtIDMHoacMSSV.Text)[e.RowIndex]);
                txtIDMHoacMSSV.Text = ID.ToString();
                cbBLoaiTimKiem.Text = "ID Máy";
                dgvThongTinDonHang.Rows.Clear();
                string tenMay, nDSuaChua, ghiChu, thanhTien, tinhTrang;
                DateTime NgayGiao;
                int ketQua = NguoiSuDungRoot.timDonHangTheoIDMay(ID, out tenMay, out nDSuaChua, out ghiChu, out thanhTien, out NgayGiao, out tinhTrang);
                dgvThongTinDonHang.Rows.Add();
                dgvThongTinDonHang.Rows[0].Cells[0].Value = tenMay;
                dgvThongTinDonHang.Rows[0].Cells[1].Value = nDSuaChua;
                dgvThongTinDonHang.Rows[0].Cells[2].Value = ghiChu;
                dgvThongTinDonHang.Rows[0].Cells[3].Value = tinhTrang;
                dgvThongTinDonHang.Rows[0].Cells[4].Value = thanhTien;
                if (tinhTrang == "Đã hủy")
                {
                    btnTraMay.Visible = false;
                    btnHuyDonHang.Visible = false;
                    MessageBox.Show("Đơn hàng này đã bị hủy vào lúc:" + NgayGiao, "Thông báo", MessageBoxButtons.OK
                        , MessageBoxIcon.Information);
                }
                else if (ketQua == 0)
                {
                    btnTraMay.Visible = true;
                    btnHuyDonHang.Visible = true;
                }
                else
                {
                    //  if (tinhTrang == 1)
                    MessageBox.Show("Đơn hàng có ID=" + ID + " đã được giao vào lúc " + NgayGiao, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //else
                    //  MessageBox.Show("Không có đơn hàng nào ứng với ID = " + ID, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnTraMay.Visible = false;
                    btnHuyDonHang.Visible = false;
                }
            }
        }
        #endregion
        #region Khi ấn nút tắt form
        private void FrmQuanLy_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #region Khi thời gian bắt đầu hoặc kết thúc trong tab Thống kê thay đổi
        private void timeDenNgay_ValueChanged(object sender, EventArgs e)
        {
            button2_Click(sender, e);
        }

        private void timeTuNgay_ValueChanged(object sender, EventArgs e)
        {

            button2_Click(sender, e);
        }
        #endregion
        #region Những sự kiện không mong muốn 
        private void cbbLoaiTinhTrang_ValueMemberChanged(object sender, EventArgs e)
        {

        }
        private void dataThongKe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabXacNhanTraMay_Click(object sender, EventArgs e)
        {

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


        private void txtIdMayNhan_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLuu_KeyDown(object sender, KeyEventArgs e)
        {


        }





        private void FrmQuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void txtIdMayNhan_Click(object sender, EventArgs e)
        {

        }

        private void dgvThongTinDonHang_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void dgvThongTinDonHang_Click(object sender, EventArgs e)
        {

        }







        private void dgvThongTinDonHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblTenNguoiSuDung_Click(object sender, EventArgs e)
        {

        }

        private void tabCaNhan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabGioiThieu_Click(object sender, EventArgs e)
        {

        }

        private void lblNguoiNhanMay_Click(object sender, EventArgs e)
        {

        }

        private void lblIdMay_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void rtbGhiChu_TextChanged(object sender, EventArgs e)
        {

        }

        private void grbThongTinDonHang_Enter(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void rtbNDSuaChua_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenMay_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMSSV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenKhachHang_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timeNgayNhan_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblIDMayValue_Click(object sender, EventArgs e)
        {

        }

        private void lblNguoiNhanMayValue_Click(object sender, EventArgs e)
        {

        }

        private void cbBLoaiTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblTimKiemTheo_Click(object sender, EventArgs e)
        {

        }

        private void tabThemNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void txtXNMK_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenTaiKhoan_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSDTNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMSSVNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenNhanVien_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblXacNhanMK_Click(object sender, EventArgs e)
        {

        }

        private void cbQuyenQuanLy_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lblMatKhau_Click(object sender, EventArgs e)
        {

        }

        private void lblTenTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void lblSDT_Click(object sender, EventArgs e)
        {

        }

        private void lblMSSV_Click(object sender, EventArgs e)
        {

        }

        private void lblTenNhanVien_Click(object sender, EventArgs e)
        {

        }

        private void tabThongKe_Click(object sender, EventArgs e)
        {

        }

        private void lblTongTienValues_Click_1(object sender, EventArgs e)
        {

        }

        private void lblTongTien_Click(object sender, EventArgs e)
        {

        }

        private void lblDenNgay_Click(object sender, EventArgs e)
        {

        }

        private void lblTuNgay_Click(object sender, EventArgs e)
        {

        }



        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }



        private void label10_Click(object sender, EventArgs e)
        {

        }

        #endregion


    }
}

