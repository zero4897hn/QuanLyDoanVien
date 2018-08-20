using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyDoanVien
{
    public partial class frmQuanLyDoanVien : Form
    {
        public frmQuanLyDoanVien() //Hàm tạo
        {
            InitializeComponent(); 
            //Hàm này chứa các công cụ đã được thiết kế
        }

        DataProvider dp = new DataProvider();
        //Khởi tạo để tái sử dụng. Chuột phải vào dòng chữ DataProvider màu xanh lam ở trên, chọn "Go to Definition"
        //dp.OpenConnection()
        DataTable dataTableThongTinDoanVien = new DataTable();
        DataTable dataTableKhenThuong = new DataTable();

        private void frmQuanLyDoanVien_Load(object sender, EventArgs e)
        {
            //Di chuột lên mỗi hàm để xem chức năng
            HienThiTruongLenCombobox(cboTruong);
            NapDuLieu();
            NapQuanLyTrangThaiPhiVaSoDoan();
            TaiMaDoanVienLenCombobox(cboMaDoanVien);
            NapDuLieuTuTabKhenThuong();
            TaiMaDoanVienLenCombobox(cboMaDoanVien4);
            HienThiTruongLenCombobox(cboTruong4);
        }

        /// <summary>
        /// Hiển thị trường đã tạo trên SQL Server lên Combobox
        /// </summary>
        private void HienThiTruongLenCombobox(ComboBox cboTruong)
        {
            dp.OpenConnection(); //Mở kết nối. Chuột phải chọn "Go to Definition" để biết thêm chi tiết
            string sql = "Select * from Truong";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dp.connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Truong"); //Đổ một table vào Dataset, và đặt tên là Truong
            cboTruong.DataSource = dataSet.Tables["Truong"];
            cboTruong.DisplayMember = "TenTruong";
            cboTruong.ValueMember = "MaTruong";
        }

        /// <summary>
        /// Có sự thay đổi trong cboTruong, ở đây sử dụng binding đến cboKhoa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTruong_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiKhoaLenCombobox(cboKhoa, cboTruong);
        }

        private void HienThiKhoaLenCombobox(ComboBox cboKhoa, ComboBox cboTruong)
        {
            if (cboTruong.SelectedIndex == -1) return;
            string MaTruong = cboTruong.SelectedValue + "";
            string sql = "Select * from Khoa where MaTruong = '" + MaTruong + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dp.connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Khoa");
            cboKhoa.DataSource = dataSet.Tables["Khoa"];
            cboKhoa.DisplayMember = "TenKhoa";
            cboKhoa.ValueMember = "MaKhoa";
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiLopLenCombobox(cboLop, cboKhoa);
        }

        private void HienThiLopLenCombobox(ComboBox cboLop, ComboBox cboKhoa)
        {
            if (cboKhoa.SelectedIndex == -1) return;
            string MaKhoa = cboKhoa.SelectedValue + "";
            string sql = "Select * from Lop where MaKhoa = '" + MaKhoa + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dp.connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Lop");
            cboLop.DataSource = dataSet.Tables["Lop"];
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
        }

        /// <summary>
        /// Nạp tất cả các dữ liệu từ SQL vào DataGirdView (bảng bên dưới phần design)
        /// </summary>
        private void NapDuLieu()
        {
            dp.OpenConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from ThongTinDoanVien", dp.connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "ThongTinDoanVien"); //đổ một table vào dataset
            dgvDoanVien.DataSource = dataSet.Tables["ThongTinDoanVien"];
            BindingDuLieu(dataSet.Tables["ThongTinDoanVien"]);
            dataTableThongTinDoanVien = dataSet.Tables["ThongTinDoanVien"];
        }

        /// <summary>
        /// Databinding là một chức năng cho phép
        /// gắn kết nguồn dữ liệu với một control và
        /// điều khiển tự động hiển thị dữ liệu trên giao diện
        /// </summary>
        /// <param name="TenBang"></param>
        /// <param name="dataSet"></param>
        private void BindingDuLieu(DataTable dataTable)
        {
            txtMaDoanVien.DataBindings.Clear();
            txtMaDoanVien.DataBindings.Add("Text", dataTable, "MaDoanVien");
            txtHoVaTen.DataBindings.Clear();
            txtHoVaTen.DataBindings.Add("Text", dataTable, "TenDoanVien");
            dtpNgaySinh.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Add("Value", dataTable, "NgaySinh");
            cboGioiTinh.DataBindings.Clear();
            cboGioiTinh.DataBindings.Add("Text", dataTable, "GioiTinh");
            txtNoiSinh.DataBindings.Clear();
            txtNoiSinh.DataBindings.Add("Text", dataTable, "NoiSinh");
            cboTruong.DataBindings.Clear();
            cboTruong.DataBindings.Add("Text", dataTable, "TenTruong");
            cboKhoa.DataBindings.Clear();
            cboKhoa.DataBindings.Add("Text", dataTable, "TenKhoa");
            cboLop.DataBindings.Clear();
            cboLop.DataBindings.Add("Text", dataTable, "TenLop");
            txtNangKhieu.DataBindings.Clear();
            txtNangKhieu.DataBindings.Add("Text", dataTable, "NangKhieu");
            cboHocLuc.DataBindings.Clear();
            cboHocLuc.DataBindings.Add("Text", dataTable, "HocLuc");
            cboHanhKiem.DataBindings.Clear();
            cboHanhKiem.DataBindings.Add("Text", dataTable, "HanhKiem");
        }

        /// <summary>
        /// Tải tất cả mã đoàn viên có trong cơ sở dữ liệu đã tạo lên combobox
        /// </summary>
        private void TaiMaDoanVienLenCombobox(ComboBox cboMaDoanVien)
        {
            dp.OpenConnection();
            string sql = "select * from PhiVaSoDoan";
            SqlCommand command = new SqlCommand(sql, dp.connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) cboMaDoanVien.Items.Add(reader.GetString(0) + "");
            reader.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            dp.OpenConnection();
            string sql = "Select * from ThongTinDoanVien where TenDoanVien like @ten";
            SqlCommand command = new SqlCommand(sql, dp.connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = "%" + txtTimDoanVien.Text + "%";
            DataSet dataSet = new DataSet("TimDoanVien");
            adapter.Fill(dataSet);
            dgvDoanVien.DataSource = dataSet.Tables["TimDoanVien"];
            BindingDuLieu(dataSet.Tables["TimDoanVien"]);
            dataTableThongTinDoanVien = dataSet.Tables["TimDoanVien"];
        }

        private void txtTimDoanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnTimKiem.PerformClick();
        }

        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoai.SelectedIndex == -1) return;
            if (cboLoai.SelectedIndex == 0)
            {
                dp.OpenConnection();
                string sql = "Select * from Lop";
                SqlCommand command = new SqlCommand(sql, dp.connection);
                SqlDataReader reader = command.ExecuteReader();
                cboTen.Items.Clear();
                while (reader.Read()) cboTen.Items.Add(reader.GetString(1) + "");
                reader.Close();
            }
            if (cboLoai.SelectedIndex == 1)
            {
                dp.OpenConnection();
                string sql = "Select * from Khoa";
                SqlCommand command = new SqlCommand(sql, dp.connection);
                SqlDataReader reader = command.ExecuteReader();
                cboTen.Items.Clear();
                while (reader.Read()) cboTen.Items.Add(reader.GetString(1) + "");
                reader.Close();
            }
            if (cboLoai.SelectedIndex == 2)
            {
                dp.OpenConnection();
                string sql = "Select * from Truong";
                SqlCommand command = new SqlCommand(sql, dp.connection);
                SqlDataReader reader = command.ExecuteReader();
                cboTen.Items.Clear();
                while (reader.Read()) cboTen.Items.Add(reader.GetString(1) + "");
                reader.Close();
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            txtTimDoanVien.Text = "";
            if (cboLoai.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn thì làm sao lọc hả thím?");
                return;
            }
            if (cboLoai.SelectedIndex == 0)
            {
                dp.OpenConnection();
                string sql = "Select * from ThongTinDoanVien where TenLop = N'" + cboTen.SelectedItem + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dp.connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Loc");
                dgvDoanVien.DataSource = dataSet.Tables["Loc"];
                BindingDuLieu(dataSet.Tables["Loc"]);

                dataTableThongTinDoanVien = dataSet.Tables["Loc"];
            }
            if (cboLoai.SelectedIndex == 1)
            {
                dp.OpenConnection();
                string sql = "Select * from ThongTinDoanVien where TenKhoa = N'" + cboTen.SelectedItem + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dp.connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Loc");
                dgvDoanVien.DataSource = dataSet.Tables["Loc"];
                BindingDuLieu(dataSet.Tables["Loc"]);

                dataTableThongTinDoanVien = dataSet.Tables["Loc"];
            }
            if (cboLoai.SelectedIndex == 2)
            {
                dp.OpenConnection();
                string sql = "Select * from ThongTinDoanVien where TenTruong = N'" + cboTen.SelectedItem + "'";
                SqlDataAdapter adapter = new SqlDataAdapter(sql, dp.connection);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, "Loc");
                dgvDoanVien.DataSource = dataSet.Tables["Loc"];
                BindingDuLieu(dataSet.Tables["Loc"]);

                dataTableThongTinDoanVien = dataSet.Tables["Loc"];
            }
        }

        private void btnCapNhatLaiDuLieu_Click(object sender, EventArgs e)
        {
            NapDuLieu();
        }

        private void llblDangXuat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Thao tác này sẽ đăng xuất tài khoản của thím.\nThím có chắc chắn muốn đăng xuất không?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                frmDangNhap login = new frmDangNhap();
                login.Show();
                this.Hide();
            }
        }

        private void frmQuanLyDoanVien_FormClosing(object sender, FormClosingEventArgs e)
        {
            dp.CloseConnection();
            Application.Exit();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                dp.OpenConnection();
                string sql = "insert into DoanVien values(@madoanvien, @tendoanvien, @ngaysinh, @gioitinh, @noisinh, @malop, @nangkhieu, @hocluc, @hanhkiem)"
                    + "insert into PhiVaSoDoan values (@madoanvien, @dongdoanphi, @sodoan)";
                SqlCommand command = new SqlCommand(sql, dp.connection);
                command.Parameters.AddWithValue("@madoanvien", txtMaDoanVien.Text);
                command.Parameters.AddWithValue("@tendoanvien", txtHoVaTen.Text);
                command.Parameters.AddWithValue("@ngaysinh", dtpNgaySinh.Value);
                command.Parameters.AddWithValue("@gioitinh", cboGioiTinh.SelectedItem + "");
                command.Parameters.AddWithValue("@noisinh", txtNoiSinh.Text);
                command.Parameters.AddWithValue("@malop", cboLop.SelectedValue + "");
                command.Parameters.AddWithValue("@nangkhieu", txtNangKhieu.Text);
                command.Parameters.AddWithValue("@hocluc", cboHocLuc.SelectedItem + "");
                command.Parameters.AddWithValue("@hanhkiem", cboHanhKiem.SelectedItem + "");
                command.Parameters.AddWithValue("@dongdoanphi", 0);
                command.Parameters.AddWithValue("@sodoan", "Chưa thu");
                /* Vào formQuanLyTaiKhoan dòng thứ 37 để xem cách code thay thế.
                 * Lý do mình không code ở đây vì code như vậy đòi hói phải có sự kiềm chế rất là cao.
                 * Note: Lý do mình không insert vào bảng ThongTinDoanVien với bảng TrangThaiPhiVaSoDoan
                 * là vì hai bảng đó là khung nhìn (view), mà khung nhìn thì tức là chỉ cho phép nhìn,
                 * chỉ truy cập được bằng lệnh truy vấn SQL, tức là chỉ dùng được Select, from, where...
                 * Hay nói cách khác, đã là bảng view thì không bao giờ insert được.
                 */
                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    NapDuLieu();
                    NapQuanLyTrangThaiPhiVaSoDoan();
                    TaiMaDoanVienLenCombobox(cboMaDoanVien);
                    TaiMaDoanVienLenCombobox(cboMaDoanVien4);
                    MessageBox.Show("Thêm thành công.");
                }
                else MessageBox.Show("Thêm thất bại.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                dp.OpenConnection();
                string sql = "update DoanVien set TenDoanVien = @tendoanvien, NgaySinh = @ngaysinh, GioiTinh = @gioitinh, NoiSinh = @noisinh, MaLop = @malop, NangKhieu = @nangkhieu, HocLuc = @hocluc, HanhKiem = @hanhkiem where MaDoanVien = @madoanvien";
                SqlCommand command = new SqlCommand(sql, dp.connection);
                command.Parameters.AddWithValue("@madoanvien", txtMaDoanVien.Text);
                command.Parameters.AddWithValue("@tendoanvien", txtHoVaTen.Text);
                command.Parameters.AddWithValue("@ngaysinh", dtpNgaySinh.Value);
                command.Parameters.AddWithValue("@gioitinh", cboGioiTinh.SelectedItem + "");
                command.Parameters.AddWithValue("@noisinh", txtNoiSinh.Text);
                command.Parameters.AddWithValue("@malop", cboLop.SelectedValue + "");
                command.Parameters.AddWithValue("@nangkhieu", txtNangKhieu.Text);
                command.Parameters.AddWithValue("@hocluc", cboHocLuc.SelectedItem + "");
                command.Parameters.AddWithValue("@hanhkiem", cboHanhKiem.SelectedItem + "");
                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    NapDuLieu();
                    MessageBox.Show("Sửa thành công.");
                }
                else MessageBox.Show("Sửa thất bại.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                dp.OpenConnection();
                string sql = "delete from KhenThuongDoanVien where MaDoanVien = @madoanvien "
                    + "delete from LichSuChuyenDiaDiem where MaDoanVien = @madoanvien "
                    + "delete from PhiVaSoDoan where MaDoanVien = @madoanvien " 
                    + "delete from DoanVien where MaDoanVien = @madoanvien";
                SqlCommand command = new SqlCommand(sql, dp.connection);
                command.Parameters.AddWithValue("@madoanvien", txtMaDoanVien.Text);
                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    NapDuLieu();
                    NapQuanLyTrangThaiPhiVaSoDoan();
                    TaiMaDoanVienLenCombobox(cboMaDoanVien);
                    TaiMaDoanVienLenCombobox(cboMaDoanVien4);
                    MessageBox.Show("Xóa thành công.");
                }
                else MessageBox.Show("Xóa thất bại.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Tải dữ liệu lên DataGridView trong tab "Quản lý phí và sổ Đoàn"
        /// </summary>
        private void NapQuanLyTrangThaiPhiVaSoDoan()
        {
            dp.OpenConnection();
            string sql = "select * from TrangThaiPhiVaSoDoan";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dp.connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "TrangThaiPhiVaSoDoan");
            dgvDoanPhi.DataSource = dataSet.Tables["TrangThaiPhiVaSoDoan"];
            BindingDoanPhi(dataSet.Tables["TrangThaiPhiVaSoDoan"]);
        }

        /// <summary>
        /// Databinding là một chức năng cho phép
        /// gắn kết nguồn dữ liệu với một control và
        /// điều khiển tự động hiển thị dữ liệu trên giao diện
        /// </summary>
        /// <param name="tenbang"></param>
        /// <param name="dataSet"></param>
        private void BindingDoanPhi(DataTable dataTable)
        {
            txtMaDoanVien2.DataBindings.Clear();
            txtMaDoanVien2.DataBindings.Add("Text", dataTable, "MaDoanVien");
            txtTenDoanVien.DataBindings.Clear();
            txtTenDoanVien.DataBindings.Add("Text", dataTable, "TenDoanVien");
            cbDaDong.DataBindings.Clear();
            cbDaDong.DataBindings.Add("Checked", dataTable, "DongDoanPhi");
            cboSoDoan.DataBindings.Clear();
            cboSoDoan.DataBindings.Add("Text", dataTable, "SoDoan");
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                dp.OpenConnection();
                string sql = "Update PhiVaSoDoan set DongDoanPhi = @dongdoanphi, SoDoan = @sodoan where MaDoanVien = @madoanvien";
                SqlCommand command = new SqlCommand(sql, dp.connection);
                command.Parameters.AddWithValue("@dongdoanphi", cbDaDong.CheckState);
                command.Parameters.AddWithValue("@sodoan", cboSoDoan.SelectedItem + "");
                command.Parameters.AddWithValue("@madoanvien", txtMaDoanVien2.Text);
                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    NapQuanLyTrangThaiPhiVaSoDoan();
                    MessageBox.Show("Cập nhật thành công.");
                }
                else MessageBox.Show("Cập nhật thất bại.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimKiemMaDoanVien_Click(object sender, EventArgs e)
        {
            dp.OpenConnection();
            string sql = "Select * from TrangThaiPhiVaSoDoan where MaDoanVien like @ma";
            SqlCommand command = new SqlCommand(sql, dp.connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            command.Parameters.AddWithValue("@ma", "%" + txtTimMaDoanVien.Text + "%");
            DataSet dataSet = new DataSet("TrangThaiPhiVaSoDoan");
            adapter.Fill(dataSet, "TrangThaiPhiVaSoDoan");
            dgvDoanPhi.DataSource = dataSet.Tables["TrangThaiPhiVaSoDoan"];
            BindingDoanPhi(dataSet.Tables["TrangThaiPhiVaSoDoan"]);
        }

        private void txtTimMaDoanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnTimKiemMaDoanVien.PerformClick();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            frmThongKeThongTinDoanVien frmTKTTDV = new frmThongKeThongTinDoanVien();
            frmTKTTDV.dataTable = dataTableThongTinDoanVien;
            frmTKTTDV.Show();
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            frmBaoCaoDoanPhiSoDoan frmBCDPSD = new frmBaoCaoDoanPhiSoDoan();
            frmBCDPSD.Show();
        }

        private void NapDuLieuTuTabKhenThuong()
        {
            dp.OpenConnection();
            string sql = "select * from ThongTinKhenThuongDoanVien";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dp.connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "ThongTinKhenThuongDoanVien");
            dgvKhenThuong.DataSource = dataSet.Tables["ThongTinKhenThuongDoanVien"];
            BindingKhenThuong(dataSet.Tables["ThongTinKhenThuongDoanVien"]);
            dataTableKhenThuong = dataSet.Tables["ThongTinKhenThuongDoanVien"];
        }

        private void BindingKhenThuong(DataTable dataTable)
        {
            cboMaDoanVien.DataBindings.Clear();
            cboMaDoanVien.DataBindings.Add("Text", dataTable, "MaDoanVien");
            txtTieuDeKhenThuong.DataBindings.Clear();
            txtTieuDeKhenThuong.DataBindings.Add("Text", dataTable, "TieuDeKhenThuong");
            txtNoiDungKhenThuong.DataBindings.Clear();
            txtNoiDungKhenThuong.DataBindings.Add("Text", dataTable, "NoiDungKhenThuong");
            dtpNgayKhenThuong.DataBindings.Clear();
            dtpNgayKhenThuong.DataBindings.Add("Value", dataTable, "NgayKhenThuong");
        }

        private void cboMaDoanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenDoanVien3.Text = LayTenDoanVien(cboMaDoanVien.SelectedItem.ToString());
        }

        private string LayTenDoanVien(string madoanvien)
        {
            dp.OpenConnection();
            string sql = "select TenDoanVien from DoanVien where MaDoanVien = '" + madoanvien + "'";
            SqlCommand command = new SqlCommand(sql, dp.connection);
            return command.ExecuteScalar() + "";
        }

        private void btnThemKhenThuong_Click(object sender, EventArgs e)
        {
            dp.OpenConnection();
            string sql = "insert into KhenThuongDoanVien values (@madoanvien, @tieude, @noidung, @ngaykhen)";
            SqlCommand command = new SqlCommand(sql, dp.connection);
            command.Parameters.AddWithValue("@madoanvien", cboMaDoanVien.SelectedItem + "");
            command.Parameters.AddWithValue("@tieude", txtTieuDeKhenThuong.Text);
            command.Parameters.AddWithValue("@noidung", txtNoiDungKhenThuong.Text);
            command.Parameters.AddWithValue("@ngaykhen", dtpNgayKhenThuong.Value);
            int kq = command.ExecuteNonQuery();
            if (kq > 0)
            {
                NapDuLieuTuTabKhenThuong();
                MessageBox.Show("Thêm thành công.");
            }
            else MessageBox.Show("Thêm thất bại.");
        }

        private void btnXoaKhenThuong_Click(object sender, EventArgs e)
        {
            dp.OpenConnection();
            string sql = "delete from KhenThuongDoanVien where MaDoanVien = @madoanvien and TieuDeKhenThuong = @tieudekhenthuong and NoiDungKhenThuong = @noidungkhenthuong and NgayKhenThuong = @ngaykhenthuong";
            SqlCommand command = new SqlCommand(sql, dp.connection);
            command.Parameters.AddWithValue("@madoanvien", cboMaDoanVien.SelectedItem + "");
            command.Parameters.AddWithValue("@tieudekhenthuong", txtTieuDeKhenThuong.Text);
            command.Parameters.AddWithValue("@noidungkhenthuong", txtNoiDungKhenThuong.Text);
            command.Parameters.AddWithValue("@ngaykhenthuong", dtpNgayKhenThuong.Value);
            int kq = command.ExecuteNonQuery();
            if (kq > 0)
            {
                NapDuLieuTuTabKhenThuong();
                MessageBox.Show("Xóa thành công.");
            }
            else MessageBox.Show("Xóa thất bại.");
        }

        private void btnTimKiemKhenThuong_Click(object sender, EventArgs e)
        {
            dp.OpenConnection();
            string sql = "select * from ThongTinKhenThuongDoanVien where MaDoanVien = @ma";
            SqlCommand command = new SqlCommand(sql, dp.connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            command.Parameters.AddWithValue("@ma", txtTimMaDoanVienKhenThuong.Text);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "TimKiemKhenThuong");
            dgvKhenThuong.DataSource = dataSet.Tables["TimKiemKhenThuong"];
            BindingKhenThuong(dataSet.Tables["TimKiemKhenThuong"]);
            dataTableKhenThuong = dataSet.Tables["TimKiemKhenThuong"];
        }

        private void txtTimMaDoanVienKhenThuong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnTimKiemKhenThuong.PerformClick();
        }

        private void btnThongKeKhenThuong_Click(object sender, EventArgs e)
        {
            frmThongKeKhenThuong frmTKKT = new frmThongKeKhenThuong();
            frmTKKT.dataTable = dataTableKhenThuong;
            frmTKKT.Show();
        }

        private void cboMaDoanVien4_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenDoanVien4.Text = LayTenDoanVien(cboMaDoanVien4.SelectedItem.ToString());
            dp.OpenConnection();
            string sql = "select TenLop, TenKhoa, TenTruong from ThongTinDoanVien where MaDoanVien = '" + cboMaDoanVien4.SelectedItem + "'";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, dp.connection);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            txtTruongHienTai.DataBindings.Clear();
            txtTruongHienTai.DataBindings.Add("Text", dataSet.Tables[0], "TenTruong");
            txtKhoaHienTai.DataBindings.Clear();
            txtKhoaHienTai.DataBindings.Add("Text", dataSet.Tables[0], "TenKhoa");
            txtLopDangHoc.DataBindings.Clear();
            txtLopDangHoc.DataBindings.Add("Text", dataSet.Tables[0], "TenLop");
        }

        private void cboTruong4_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiKhoaLenCombobox(cboKhoa4, cboTruong4);
        }

        private void cboKhoa4_SelectedIndexChanged(object sender, EventArgs e)
        {
            HienThiLopLenCombobox(cboLop4, cboKhoa4);
        }

        private void btnChuyen_Click(object sender, EventArgs e)
        {
            if (txtLopDangHoc.Text.Equals(cboLop4.Text))
            {
                MessageBox.Show("Chuyển lớp ảo diệu thế?");
                return;
            }
            dp.OpenConnection();
            string sql = "insert into LichSuChuyenDiaDiem values (@madoanvien, @thoigian, @malop, @thoigianchuyen)"
                + "update DoanVien set MaLop = @malop where MaDoanVien = @madoanvien";
            SqlCommand command = new SqlCommand(sql, dp.connection);
            command.Parameters.AddWithValue("@madoanvien", cboMaDoanVien4.SelectedItem + "");
            command.Parameters.AddWithValue("@thoigian", DateTime.Now);
            command.Parameters.AddWithValue("@malop", cboLop4.SelectedValue + "");
            command.Parameters.AddWithValue("@thoigianchuyen", dtpThoiGianChuyen.Value);
            int kq = command.ExecuteNonQuery();
            if (kq > 0)
            {
                NapDuLieu();
                MessageBox.Show("Chuyển thành công.");
            }
            else MessageBox.Show("Chuyển thất bại.");
        }

        private void btnXemLichSuChuyenDiaDiem_Click(object sender, EventArgs e)
        {
            frmXemLichSuChuyenDiaDiem frmLS = new frmXemLichSuChuyenDiaDiem();
            frmLS.Show();
        }
    }
}
