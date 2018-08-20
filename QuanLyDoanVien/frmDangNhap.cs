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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        DataProvider dp = new DataProvider();
        /// <summary>
        /// Khi Click vào bút đăng nhập thì đăng nhập vào tài khoản đã được tạo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                dp.OpenConnection();
                string sql = "Select TenDangNhap, Quyen from DangNhap where TenDangNhap = @username and MatKhau = @pass";
                //Tạo chuỗi câu lệnh truy vấn SQL
                SqlCommand command = new SqlCommand(sql, dp.connection);
                /* Tạo hàm để thực hiện câu truy vấn SQL. SQL Command là quá trình tương tác với CSDL
                 * cần biết hành động nào muốn xảy ra
                 */
                command.Parameters.AddWithValue("@username", txtTenDangNhap.Text);
                //Gán những gì đã nhập ở ô Tên Đăng Nhập vào biến Parameter @username
                command.Parameters.AddWithValue("@pass", txtMatKhau.Text);
                SqlDataReader reader = command.ExecuteReader();
                //Vế trái: Khởi tạo hàm đọc dữ liệu. Vế phải: Thực thi lệnh truy vấn SQL ở trên.
                if (reader.Read())
                {
                    string tendangnhap = reader.GetString(0);
                    string quyen = reader.GetString(1);
                    /* Biến quyen được lấy từ dữ liệu trong bảng thực hiện truy vấn sql ở trên. 
                     * Ở bảng đã được thực hiện câu lệnh truy vấn trên đó, cột "quyen" ở vị trí thứ 1. 
                     */
                    if (quyen == "Quản trị")
                    {
                        frmQuanLyTaiKhoan TK = new frmQuanLyTaiKhoan(); //Khởi tạo form frmQuanLyTaiKhoan
                        TK.Show(); //Mở frmQuanLyTaiKhoan
                        TK.lblTenDangNhap.Text = tendangnhap; //Hiển thị tên đăng nhập lên form QuanLyTaiKhoan
                        this.Hide();
                    }
                    else if (quyen == "Nhân viên")
                    {
                        frmQuanLyDoanVien DV = new frmQuanLyDoanVien();
                        DV.Show(); //Mở frmQuanLyDoanVien
                        DV.lblTaiKhoan.Text = tendangnhap; //Hiển thị tên đăng nhập lên form QuanLyDoanVien
                        this.Hide(); //Ẩn form hiện tại
                    }
                }
                else //Nếu không có dữ liệu ở trong bảng sau khi truy vấn SQL (sai tên đăng nhập hoặc mật khẩu)
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reader.Close(); //Dừng việc đọc dữ liệu lại
            }
            catch (Exception ex)
            {
                //Đoạn code trong try có lỗi gì xảy ra trong quá trình chạy thì nhảy vào đây
                MessageBox.Show(ex.Message);
                //Hiện bảng thông báo lỗi (thường là Tiếng Anh, nếu tự tạo ra lỗi thì có thể thiết lập bằng tiếng Việt)
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close(); //Đóng
        }

        private void frmDangNhap_FormClosed(object sender, FormClosedEventArgs e)
        {
            dp.CloseConnection();
            Application.Exit();
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnDangNhap.PerformClick();
            //Ấn Enter khi đang nhập ở ô Mật khẩu thì sẽ tự động vào nút Đăng nhập
        }

        private void txtTenDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) btnDangNhap.PerformClick();
            //Ấn Enter khi đang nhập ở ô Tên Đăng nhập thì sẽ tự động vào nút Đăng nhập
        }
    }
}
