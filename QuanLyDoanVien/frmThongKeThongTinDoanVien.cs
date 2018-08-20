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
    public partial class frmThongKeThongTinDoanVien : Form
    {
        public frmThongKeThongTinDoanVien()
        {
            InitializeComponent();
        }

        DataProvider dp = new DataProvider();
        public DataTable dataTable = null;

        private void frmThongKeThongTinDoanVien_Load(object sender, EventArgs e)
        {
            dp.OpenConnection();
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyDoanVien.ReportThongTinDoanVien.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSetThongTinDoanVien";
            rds.Value = dataTable;
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
