using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyDoanVien
{
    public class DataProvider
    {
        private string strConnection = @"Server = DESKTOP-IBJD3JT; Database = QuanLyDoanVien; User ID = sa; Password = nobita12";
        /* Đây là chuỗi kết nối đến cơ sở dữ liệu:
         * - Server = Tên_server_máy_trong_SQL_server
         * - Database = Cơ_sở_dữ_liệu_đã_tạo_cho_bài_này
         * - User ID = sa; Password = ... (Tên tài khoản và mật khẩu đã thiết lập khi đăng nhập vào SQL)
         * Giao diện đăng nhập khi chỉnh Authentication là SQL Server Authentication. 
         * Nếu đăng nhập theo Windows Authentication thì từ chỗ "User ID" cho đến chuỗi cuối cùng
         * thì sửa thành "Integrated Security = true"
         */
        public SqlConnection connection = null; //Tạo kết nối cơ sở dữ liệu
        public void OpenConnection() //Mở kết nối
        {
            if (connection == null) connection = new SqlConnection(strConnection);
            //Kết nối cơ sở dữ liệu với chuỗi kết nối strConnection ở trên
            if (connection.State == ConnectionState.Closed) connection.Open();
            //Trạng thái connection đang đóng thì mở connection
        }
        public void CloseConnection() //Đóng kết nối
        {
            if (connection != null && connection.State == ConnectionState.Open) connection.Close();
            //Đang mở kết nối thì đóng lại
        }
    }
}