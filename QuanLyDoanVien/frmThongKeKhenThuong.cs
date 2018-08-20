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
using Microsoft.Reporting.WinForms;

namespace QuanLyDoanVien
{
    public partial class frmThongKeKhenThuong : Form
    {
        public frmThongKeKhenThuong()
        {
            InitializeComponent();
        }

        public DataTable dataTable = null;

        private void frmThongKeKhenThuong_Load(object sender, EventArgs e)
        {
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyDoanVien.ReportThongTinKhenThuongDoanVien.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSetThongTinKhenThuongDoanVien";
            rds.Value = dataTable;
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
