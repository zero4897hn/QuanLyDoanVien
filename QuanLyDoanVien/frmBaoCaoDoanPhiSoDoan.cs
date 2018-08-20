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
    public partial class frmBaoCaoDoanPhiSoDoan : Form
    {
        public frmBaoCaoDoanPhiSoDoan()
        {
            InitializeComponent();
        }

        DataProvider dp = new DataProvider();

        private void frmBaoCaoDoanPhiSoDoan_Load(object sender, EventArgs e)
        {
            dp.OpenConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from TrangThaiPhiVaSoDoan", dp.connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "TrangThaiPhiVaSoDoan");
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyDoanVien.ReportPhiVaSoDoan.rdlc";
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSetPhiVaSoDoan";
            rds.Value = ds.Tables["TrangThaiPhiVaSoDoan"];
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
