namespace QuanLyDoanVien
{
    partial class frmQuanLyTaiKhoan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTenDangNhap = new System.Windows.Forms.TextBox();
            this.txtMatKhau = new System.Windows.Forms.TextBox();
            this.cbQuyen = new System.Windows.Forms.ComboBox();
            this.btnXoaTaiKhoan = new System.Windows.Forms.Button();
            this.btnSuaTaiKhoan = new System.Windows.Forms.Button();
            this.btnTaoTaiKhoan = new System.Windows.Forms.Button();
            this.dgvTaiKhoan = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTenDangNhap = new System.Windows.Forms.Label();
            this.llblDangXuat = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(715, 61);
            this.label1.TabIndex = 0;
            this.label1.Text = "HỆ THỐNG QUẢN LÝ TÀI KHOẢN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Tên đăng nhập:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mật khẩu:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Quyền:";
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.Location = new System.Drawing.Point(176, 103);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(460, 20);
            this.txtTenDangNhap.TabIndex = 4;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(176, 139);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Size = new System.Drawing.Size(460, 20);
            this.txtMatKhau.TabIndex = 6;
            // 
            // cbQuyen
            // 
            this.cbQuyen.FormattingEnabled = true;
            this.cbQuyen.Items.AddRange(new object[] {
            "Quản trị",
            "Nhân viên"});
            this.cbQuyen.Location = new System.Drawing.Point(176, 175);
            this.cbQuyen.Name = "cbQuyen";
            this.cbQuyen.Size = new System.Drawing.Size(460, 21);
            this.cbQuyen.TabIndex = 8;
            // 
            // btnXoaTaiKhoan
            // 
            this.btnXoaTaiKhoan.Image = global::QuanLyDoanVien.Properties.Resources.Delete;
            this.btnXoaTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaTaiKhoan.Location = new System.Drawing.Point(499, 215);
            this.btnXoaTaiKhoan.Name = "btnXoaTaiKhoan";
            this.btnXoaTaiKhoan.Size = new System.Drawing.Size(102, 23);
            this.btnXoaTaiKhoan.TabIndex = 11;
            this.btnXoaTaiKhoan.Text = "Xóa tài khoản";
            this.btnXoaTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaTaiKhoan.UseVisualStyleBackColor = true;
            this.btnXoaTaiKhoan.Click += new System.EventHandler(this.btnXoaTaiKhoan_Click);
            // 
            // btnSuaTaiKhoan
            // 
            this.btnSuaTaiKhoan.Image = global::QuanLyDoanVien.Properties.Resources.Edit;
            this.btnSuaTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaTaiKhoan.Location = new System.Drawing.Point(300, 215);
            this.btnSuaTaiKhoan.Name = "btnSuaTaiKhoan";
            this.btnSuaTaiKhoan.Size = new System.Drawing.Size(101, 23);
            this.btnSuaTaiKhoan.TabIndex = 10;
            this.btnSuaTaiKhoan.Text = "Sửa tài khoản";
            this.btnSuaTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaTaiKhoan.UseVisualStyleBackColor = true;
            this.btnSuaTaiKhoan.Click += new System.EventHandler(this.btnSuaTaiKhoan_Click);
            // 
            // btnTaoTaiKhoan
            // 
            this.btnTaoTaiKhoan.Image = global::QuanLyDoanVien.Properties.Resources.Add;
            this.btnTaoTaiKhoan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaoTaiKhoan.Location = new System.Drawing.Point(105, 215);
            this.btnTaoTaiKhoan.Name = "btnTaoTaiKhoan";
            this.btnTaoTaiKhoan.Size = new System.Drawing.Size(97, 23);
            this.btnTaoTaiKhoan.TabIndex = 9;
            this.btnTaoTaiKhoan.Text = "Tạo tài khoản";
            this.btnTaoTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTaoTaiKhoan.UseVisualStyleBackColor = true;
            this.btnTaoTaiKhoan.Click += new System.EventHandler(this.btnTaoTaiKhoan_Click);
            // 
            // dgvTaiKhoan
            // 
            this.dgvTaiKhoan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTaiKhoan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaiKhoan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTaiKhoan.Location = new System.Drawing.Point(0, 270);
            this.dgvTaiKhoan.Name = "dgvTaiKhoan";
            this.dgvTaiKhoan.Size = new System.Drawing.Size(715, 195);
            this.dgvTaiKhoan.TabIndex = 12;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblTenDangNhap);
            this.panel1.Controls.Add(this.llblDangXuat);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 30);
            this.panel1.TabIndex = 13;
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.Location = new System.Drawing.Point(416, 5);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(226, 21);
            this.lblTenDangNhap.TabIndex = 1;
            this.lblTenDangNhap.Text = "Tên tài khoản";
            this.lblTenDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // llblDangXuat
            // 
            this.llblDangXuat.AutoSize = true;
            this.llblDangXuat.Location = new System.Drawing.Point(648, 9);
            this.llblDangXuat.Name = "llblDangXuat";
            this.llblDangXuat.Size = new System.Drawing.Size(56, 13);
            this.llblDangXuat.TabIndex = 0;
            this.llblDangXuat.TabStop = true;
            this.llblDangXuat.Text = "Đăng xuất";
            this.llblDangXuat.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblDangXuat_LinkClicked);
            // 
            // frmQuanLyTaiKhoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 465);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvTaiKhoan);
            this.Controls.Add(this.btnXoaTaiKhoan);
            this.Controls.Add(this.btnSuaTaiKhoan);
            this.Controls.Add(this.btnTaoTaiKhoan);
            this.Controls.Add(this.cbQuyen);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.txtTenDangNhap);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "frmQuanLyTaiKhoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý tài khoản";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQuanLyTaiKhoan_FormClosing);
            this.Load += new System.EventHandler(this.frmQuanLyTaiKhoan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaiKhoan)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.ComboBox cbQuyen;
        private System.Windows.Forms.Button btnTaoTaiKhoan;
        private System.Windows.Forms.Button btnSuaTaiKhoan;
        private System.Windows.Forms.Button btnXoaTaiKhoan;
        private System.Windows.Forms.DataGridView dgvTaiKhoan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel llblDangXuat;
        internal System.Windows.Forms.Label lblTenDangNhap;
    }
}