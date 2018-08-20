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
    public partial class frmQuanLyTaiKhoan : Form
    {
        public frmQuanLyTaiKhoan()
        {
            InitializeComponent();
            //Khởi tạo các dữ liệu đã thiết kế.
        }

        DataProvider dp = new DataProvider();
        /* Khởi tạo để tái sử dụng. Chuột phải vào 
         * dòng chữ DataProvider màu xanh lam ở trên, chọn "Go to Definition"
         * để biết thêm chi tiết.
         */

        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                dp.OpenConnection();//Mở kết nối. Chuột phải và chọn "Go to Definition" để biết thêm chi tiết
                SqlCommand command = new SqlCommand("insert into DangNhap values (@username, @pass, @quyen)", dp.connection);
                command.Parameters.AddWithValue("@username", txtTenDangNhap.Text);
                command.Parameters.AddWithValue("@pass", txtMatKhau.Text);
                command.Parameters.AddWithValue("@quyen", cbQuyen.SelectedItem.ToString());
                /* Cả 4 dòng trên có thể gõ code thay thế là:
                 * SqlCommand command = new SqlCommand("Insert into DangNhap values (N'" + txtTenDangNhap.Text + "', N'" + txtMatKhau.Text + "', N'" + cbQuyen.SelectedItem + "')", dp.connection);
                 * Thấy rất là khó kiềm chế khi phải phân biệt dấu ' với dấu " phải không? =))
                 * Parameters đã giải thích ở form Đăng Nhập
                 */
                int kq = command.ExecuteNonQuery(); //command.ExecuteNonQuery(): Trả về số dòng bị ảnh hưởng (... row effected)
                if (kq > 0)
                {
                    HienThiDuLieuLenBangTaiKhoan();
                    MessageBox.Show("Tạo tài khoản thành công.");
                }
                else MessageBox.Show("Tạo thất bại.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSuaTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                dp.OpenConnection();
                SqlCommand command = new SqlCommand("update DangNhap set MatKhau = @pass, Quyen = @quyen where TenDangNhap = @username", dp.connection);
                command.Parameters.AddWithValue("@username", txtTenDangNhap.Text);
                command.Parameters.AddWithValue("@pass", txtMatKhau.Text);
                command.Parameters.AddWithValue("@quyen", cbQuyen.SelectedItem.ToString());
                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    HienThiDuLieuLenBangTaiKhoan();
                    MessageBox.Show("Sửa tài khoản thành công.");
                }
                else MessageBox.Show("Sửa tài khoản thất bại.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            DialogResult ret = MessageBox.Show("Thím chắc chắn muốn xóa tài khoản " + txtTenDangNhap.Text + "?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //Hiện bảng thông báo.
            if (ret == DialogResult.Yes)
            {
                if (cbQuyen.Text == "Quản trị" && SoTaiKhoanAdmin() < 2) //Quản trị đi hết thì ai sẽ quản lý tài khoản??
                {
                    MessageBox.Show("Không thể xóa thêm tài khoản quyền quản trị nữa.");
                }
                else ThucHienXoa(txtTenDangNhap.Text);
            }
        }

        private void ThucHienXoa(string username)
        {
            try
            {
                dp.OpenConnection();
                SqlCommand command = new SqlCommand("delete from DangNhap where TenDangNhap = N'" + username + "'", dp.connection);
                int kq = command.ExecuteNonQuery();
                if (kq > 0)
                {
                    HienThiDuLieuLenBangTaiKhoan();
                    MessageBox.Show("Xóa tài khoản thành công.");
                }
                else MessageBox.Show("Xóa tài khoản thất bại.");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int SoTaiKhoanAdmin()
        {
            dp.OpenConnection();
            SqlCommand command = new SqlCommand("select COUNT(*) from DangNhap where Quyen = N'Quản trị'", dp.connection);
            return (int)command.ExecuteScalar();
        }

        /// <summary>
        /// Hiển thị dữ liệu lên bảng Tài Khoản
        /// </summary>
        private void HienThiDuLieuLenBangTaiKhoan()
        {
            try
            {
                dp.OpenConnection();
                SqlCommand command = new SqlCommand("select * from DangNhap", dp.connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataSet dataSet = new DataSet();
                //DataSet: Một thể hiện của dữ liệu trong bộ nhớ
                adapter.Fill(dataSet, "TaiKhoan");
                //Đổ một table vào một dataset
                dgvTaiKhoan.DataSource = dataSet.Tables["TaiKhoan"];
                //Đưa DataSet nên nguồn dữ liệu của dataGirdView (Hiển thị bảng và dữ liệu)
                BindingDuLieu("TaiKhoan", dataSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Databinding là một chức năng cho phép
        /// gắn kết nguồn dữ liệu với một control và
        /// điều khiển tự động hiển thị dữ liệu trên giao diện
        /// </summary>
        /// <param name="tenbang"></param>
        /// <param name="dataSet"></param>
        private void BindingDuLieu(string tenbang, DataSet dataSet)
        {
            txtTenDangNhap.DataBindings.Clear();
            txtTenDangNhap.DataBindings.Add("Text", dataSet.Tables[tenbang], "TenDangNhap");
                                            //(Thuộc tính, DataTable, Tên cột trong DataTable)
            txtMatKhau.DataBindings.Clear();
            txtMatKhau.DataBindings.Add("Text", dataSet.Tables[tenbang], "MatKhau");
            cbQuyen.DataBindings.Clear();
            cbQuyen.DataBindings.Add("Text", dataSet.Tables[tenbang], "Quyen");
        }

        private void frmQuanLyTaiKhoan_FormClosing(object sender, FormClosingEventArgs e)
        {
            dp.CloseConnection();
            Application.Exit();
        }

        private void llblDangXuat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Thao tác này sẽ đăng xuất tài khoản của thím.\nThím có chắc chắn muốn đăng xuất không?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) //Nếu ấn nút Yes
            {
                frmDangNhap login = new frmDangNhap();
                login.Show();
                this.Hide();
            }
        }

        private void frmQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            HienThiDuLieuLenBangTaiKhoan();
        }
    }
}
