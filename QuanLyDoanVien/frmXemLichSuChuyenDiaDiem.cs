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
    public partial class frmXemLichSuChuyenDiaDiem : Form
    {
        public frmXemLichSuChuyenDiaDiem()
        {
            InitializeComponent();
        }

        DataProvider dp = new DataProvider();

        private void frmXemLichSuChuyenDiaDiem_Load(object sender, EventArgs e)
        {
            cboXem.Items.Clear();
            cboXem.Items.Add("Tất cả");
            dp.OpenConnection();
            string sql = "select distinct CONVERT(varchar, ThoiGianChuyen, 103) from ThongTinLichSuChuyenDiaDiem order by CONVERT(varchar, ThoiGianChuyen, 103) asc";
            SqlCommand command = new SqlCommand(sql, dp.connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) cboXem.Items.Add(reader.GetString(0));
            reader.Close();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            if (cboXem.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn thì làm sao xem hả thím?");
            }
            if (cboXem.SelectedIndex == 0)
            {
                HienThiToanBoLichSuLenListView();
            }
            else
            {
                HienThiLichSuLenListView(cboXem.SelectedItem.ToString());
            }
        }

        private void HienThiLichSuLenListView(string NgayChuyen)
        {
            lvLichSu.Groups.Clear();
            lvLichSu.Items.Clear();
            string sql = "select * from ThongTinLichSuChuyenDiaDiem where CONVERT(varchar, ThoiGianChuyen, 103) = CONVERT(varchar, @thoigianchuyen, 103)";
            SqlCommand command = new SqlCommand(sql, dp.connection);
            command.Parameters.AddWithValue("@thoigianchuyen", NgayChuyen);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string MaDoanVien = reader.GetString(0);
                string TenDoanVien = reader.GetString(1);
                DateTime ThoiGian = reader.GetDateTime(2);
                string LopChuyen = reader.GetString(3);
                string KhoaChuyen = reader.GetString(4);
                string TruongChuyen = reader.GetString(5);
                DateTime ThoiGianChuyen = reader.GetDateTime(6);
                ListViewItem lvi = new ListViewItem(MaDoanVien);
                lvi.SubItems.Add(TenDoanVien);
                lvi.SubItems.Add(ThoiGian.ToString("dd/MM/yyyy HH:mm"));
                lvi.SubItems.Add(LopChuyen);
                lvi.SubItems.Add(KhoaChuyen);
                lvi.SubItems.Add(TruongChuyen);
                lvi.SubItems.Add(ThoiGianChuyen.ToString("dd/MM/yyyy HH:mm"));
                lvLichSu.Items.Add(lvi);
            }
            reader.Close();
        }

        private void HienThiToanBoLichSuLenListView()
        {
            dp.OpenConnection();
            string sqlNgayChuyen = "select distinct CONVERT(varchar, ThoiGianChuyen, 103) from ThongTinLichSuChuyenDiaDiem order by CONVERT(varchar, ThoiGianChuyen, 103) asc";
            SqlCommand commandNgayChuyen = new SqlCommand(sqlNgayChuyen, dp.connection);
            lvLichSu.Groups.Clear();
            lvLichSu.Items.Clear();
            SqlDataReader readerNgayChuyen = commandNgayChuyen.ExecuteReader();
            while (readerNgayChuyen.Read())
            {
                ListViewGroup lvg = new ListViewGroup(readerNgayChuyen.GetString(0));
                lvLichSu.Groups.Add(lvg);
            }
            readerNgayChuyen.Close();
            foreach (ListViewGroup lvg in lvLichSu.Groups)
            {
                string sql = "select * from ThongTinLichSuChuyenDiaDiem where CONVERT(varchar, ThoiGianChuyen, 103) = CONVERT(varchar, @thoigianchuyen, 103)";
                SqlCommand command = new SqlCommand(sql, dp.connection);
                command.Parameters.AddWithValue("@thoigianchuyen", lvg.ToString());
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string MaDoanVien = reader.GetString(0);
                    string TenDoanVien = reader.GetString(1);
                    DateTime ThoiGian = reader.GetDateTime(2);
                    string LopChuyen = reader.GetString(3);
                    string KhoaChuyen = reader.GetString(4);
                    string TruongChuyen = reader.GetString(5);
                    DateTime ThoiGianChuyen = reader.GetDateTime(6);
                    ListViewItem lvi = new ListViewItem(MaDoanVien);
                    lvi.SubItems.Add(TenDoanVien);
                    lvi.SubItems.Add(ThoiGian.ToString("dd/MM/yyyy HH:mm"));
                    lvi.SubItems.Add(LopChuyen);
                    lvi.SubItems.Add(KhoaChuyen);
                    lvi.SubItems.Add(TruongChuyen);
                    lvi.SubItems.Add(ThoiGianChuyen.ToString("dd/MM/yyyy HH:mm"));
                    lvLichSu.Items.Add(lvi);
                    lvi.Group = lvg;
                }
                reader.Close();
            }
            
        }
    }
}
