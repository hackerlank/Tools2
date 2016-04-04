namespace Tools
{
    partial class Tools
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
            this.cmbDatabase = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDistrict = new System.Windows.Forms.ComboBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnAddDB = new System.Windows.Forms.Button();
            this.btnEditDB = new System.Windows.Forms.Button();
            this.btnDeleteDB = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDB = new System.Windows.Forms.Button();
            this.pnlDetailDatabase = new System.Windows.Forms.Panel();
            this.cmbServer = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbThoiDiemTao = new System.Windows.Forms.ComboBox();
            this.trvDatabase = new System.Windows.Forms.TreeView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXemThuTuc = new System.Windows.Forms.Button();
            this.btnXoaSach = new System.Windows.Forms.Button();
            this.btnGetUpdateData = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.rtbProcess = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.pnlDetailDatabase.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbDatabase
            // 
            this.cmbDatabase.FormattingEnabled = true;
            this.cmbDatabase.Location = new System.Drawing.Point(20, 144);
            this.cmbDatabase.Name = "cmbDatabase";
            this.cmbDatabase.Size = new System.Drawing.Size(149, 22);
            this.cmbDatabase.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cơ sở dữ liệu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(17, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Tên Quận/Huyện";
            // 
            // cmbDistrict
            // 
            this.cmbDistrict.FormattingEnabled = true;
            this.cmbDistrict.Location = new System.Drawing.Point(20, 186);
            this.cmbDistrict.Name = "cmbDistrict";
            this.cmbDistrict.Size = new System.Drawing.Size(149, 22);
            this.cmbDistrict.TabIndex = 5;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(20, 66);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(103, 20);
            this.txtUser.TabIndex = 8;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(20, 105);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(103, 20);
            this.txtPassword.TabIndex = 9;
            // 
            // btnAddDB
            // 
            this.btnAddDB.ForeColor = System.Drawing.Color.Black;
            this.btnAddDB.Location = new System.Drawing.Point(42, 253);
            this.btnAddDB.Name = "btnAddDB";
            this.btnAddDB.Size = new System.Drawing.Size(50, 23);
            this.btnAddDB.TabIndex = 10;
            this.btnAddDB.Text = "Thêm";
            this.btnAddDB.UseVisualStyleBackColor = true;
            this.btnAddDB.Click += new System.EventHandler(this.btnAddDB_Click);
            // 
            // btnEditDB
            // 
            this.btnEditDB.ForeColor = System.Drawing.Color.Black;
            this.btnEditDB.Location = new System.Drawing.Point(98, 253);
            this.btnEditDB.Name = "btnEditDB";
            this.btnEditDB.Size = new System.Drawing.Size(39, 23);
            this.btnEditDB.TabIndex = 11;
            this.btnEditDB.Text = "Sửa";
            this.btnEditDB.UseVisualStyleBackColor = true;
            this.btnEditDB.Click += new System.EventHandler(this.btnEditDB_Click);
            // 
            // btnDeleteDB
            // 
            this.btnDeleteDB.ForeColor = System.Drawing.Color.Black;
            this.btnDeleteDB.Location = new System.Drawing.Point(143, 253);
            this.btnDeleteDB.Name = "btnDeleteDB";
            this.btnDeleteDB.Size = new System.Drawing.Size(39, 23);
            this.btnDeleteDB.TabIndex = 12;
            this.btnDeleteDB.Text = "Xóa";
            this.btnDeleteDB.UseVisualStyleBackColor = true;
            this.btnDeleteDB.Click += new System.EventHandler(this.btnDeleteDB_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(17, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 14);
            this.label3.TabIndex = 13;
            this.label3.Text = "Máy chủ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 14);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tài khoản SQL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(17, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 14);
            this.label5.TabIndex = 15;
            this.label5.Text = "Mật khẩu";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnlDetailDatabase);
            this.panel1.Controls.Add(this.trvDatabase);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnDeleteDB);
            this.panel1.Controls.Add(this.btnEditDB);
            this.panel1.Controls.Add(this.btnAddDB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 288);
            this.panel1.TabIndex = 16;
            // 
            // btnDB
            // 
            this.btnDB.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDB.ForeColor = System.Drawing.Color.Gray;
            this.btnDB.Location = new System.Drawing.Point(175, 3);
            this.btnDB.Name = "btnDB";
            this.btnDB.Size = new System.Drawing.Size(144, 22);
            this.btnDB.TabIndex = 6;
            this.btnDB.Text = "Cài đặt server";
            this.btnDB.UseVisualStyleBackColor = true;
            this.btnDB.Click += new System.EventHandler(this.btnDB_Click);
            // 
            // pnlDetailDatabase
            // 
            this.pnlDetailDatabase.Controls.Add(this.cmbServer);
            this.pnlDetailDatabase.Controls.Add(this.txtPassword);
            this.pnlDetailDatabase.Controls.Add(this.label7);
            this.pnlDetailDatabase.Controls.Add(this.txtUser);
            this.pnlDetailDatabase.Controls.Add(this.cmbThoiDiemTao);
            this.pnlDetailDatabase.Controls.Add(this.cmbDistrict);
            this.pnlDetailDatabase.Controls.Add(this.label3);
            this.pnlDetailDatabase.Controls.Add(this.label2);
            this.pnlDetailDatabase.Controls.Add(this.label4);
            this.pnlDetailDatabase.Controls.Add(this.cmbDatabase);
            this.pnlDetailDatabase.Controls.Add(this.label1);
            this.pnlDetailDatabase.Controls.Add(this.label5);
            this.pnlDetailDatabase.Location = new System.Drawing.Point(477, 7);
            this.pnlDetailDatabase.Name = "pnlDetailDatabase";
            this.pnlDetailDatabase.Size = new System.Drawing.Size(200, 262);
            this.pnlDetailDatabase.TabIndex = 24;
            // 
            // cmbServer
            // 
            this.cmbServer.FormattingEnabled = true;
            this.cmbServer.Location = new System.Drawing.Point(21, 25);
            this.cmbServer.Name = "cmbServer";
            this.cmbServer.Size = new System.Drawing.Size(148, 22);
            this.cmbServer.TabIndex = 23;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(17, 211);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 14);
            this.label7.TabIndex = 21;
            this.label7.Text = "Thời điểm tạo kết nối";
            // 
            // cmbThoiDiemTao
            // 
            this.cmbThoiDiemTao.FormattingEnabled = true;
            this.cmbThoiDiemTao.Location = new System.Drawing.Point(20, 227);
            this.cmbThoiDiemTao.Name = "cmbThoiDiemTao";
            this.cmbThoiDiemTao.Size = new System.Drawing.Size(149, 22);
            this.cmbThoiDiemTao.TabIndex = 22;
            this.cmbThoiDiemTao.SelectedIndexChanged += new System.EventHandler(this.cmbThoiDiemTao_SelectedIndexChanged);
            // 
            // trvDatabase
            // 
            this.trvDatabase.CheckBoxes = true;
            this.trvDatabase.Font = new System.Drawing.Font("Times New Roman", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvDatabase.Location = new System.Drawing.Point(42, 30);
            this.trvDatabase.Name = "trvDatabase";
            this.trvDatabase.Size = new System.Drawing.Size(398, 217);
            this.trvDatabase.TabIndex = 20;
            this.trvDatabase.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.trvDatabase_AfterCheck);
            this.trvDatabase.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvDatabase_AfterSelect);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(162, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 16);
            this.label6.TabIndex = 19;
            this.label6.Text = "Danh sách Database";
            // 
            // btnCancel
            // 
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Location = new System.Drawing.Point(279, 253);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(39, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Location = new System.Drawing.Point(220, 253);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(53, 23);
            this.btnOK.TabIndex = 16;
            this.btnOK.Text = "Đồng ý";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDB);
            this.panel2.Controls.Add(this.btnXemThuTuc);
            this.panel2.Controls.Add(this.btnXoaSach);
            this.panel2.Controls.Add(this.btnGetUpdateData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 288);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(684, 94);
            this.panel2.TabIndex = 17;
            // 
            // btnXemThuTuc
            // 
            this.btnXemThuTuc.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemThuTuc.ForeColor = System.Drawing.Color.Gray;
            this.btnXemThuTuc.Location = new System.Drawing.Point(42, 3);
            this.btnXemThuTuc.Name = "btnXemThuTuc";
            this.btnXemThuTuc.Size = new System.Drawing.Size(134, 22);
            this.btnXemThuTuc.TabIndex = 25;
            this.btnXemThuTuc.Text = "Sửa store procedure";
            this.btnXemThuTuc.UseVisualStyleBackColor = true;
            this.btnXemThuTuc.Click += new System.EventHandler(this.btnXemThuTuc_Click);
            // 
            // btnXoaSach
            // 
            this.btnXoaSach.Font = new System.Drawing.Font("Times New Roman", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaSach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnXoaSach.Location = new System.Drawing.Point(42, 40);
            this.btnXoaSach.Name = "btnXoaSach";
            this.btnXoaSach.Size = new System.Drawing.Size(121, 37);
            this.btnXoaSach.TabIndex = 6;
            this.btnXoaSach.Text = "Xóa dữ liệu";
            this.btnXoaSach.UseVisualStyleBackColor = true;
            this.btnXoaSach.Click += new System.EventHandler(this.btnXoaSach_Click);
            // 
            // btnGetUpdateData
            // 
            this.btnGetUpdateData.Font = new System.Drawing.Font("Times New Roman", 15.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetUpdateData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnGetUpdateData.Location = new System.Drawing.Point(182, 40);
            this.btnGetUpdateData.Name = "btnGetUpdateData";
            this.btnGetUpdateData.Size = new System.Drawing.Size(258, 37);
            this.btnGetUpdateData.TabIndex = 5;
            this.btnGetUpdateData.Text = "Cập nhật dữ liệu";
            this.btnGetUpdateData.UseVisualStyleBackColor = true;
            this.btnGetUpdateData.Click += new System.EventHandler(this.btnGetUpdateData_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.rtbProcess);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 382);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(684, 186);
            this.panel3.TabIndex = 18;
            // 
            // rtbProcess
            // 
            this.rtbProcess.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.rtbProcess.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbProcess.ForeColor = System.Drawing.Color.White;
            this.rtbProcess.Location = new System.Drawing.Point(0, 0);
            this.rtbProcess.Name = "rtbProcess";
            this.rtbProcess.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbProcess.Size = new System.Drawing.Size(684, 186);
            this.rtbProcess.TabIndex = 0;
            this.rtbProcess.Text = "";
            this.rtbProcess.WordWrap = false;
            // 
            // Tools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.ClientSize = new System.Drawing.Size(684, 568);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Tools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lấy dữ liệu...";
            this.Load += new System.EventHandler(this.Tools_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlDetailDatabase.ResumeLayout(false);
            this.pnlDetailDatabase.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDistrict;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnAddDB;
        private System.Windows.Forms.Button btnEditDB;
        private System.Windows.Forms.Button btnDeleteDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TreeView trvDatabase;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox rtbProcess;
        private System.Windows.Forms.Button btnDB;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbThoiDiemTao;
        private System.Windows.Forms.ComboBox cmbServer;
        private System.Windows.Forms.Panel pnlDetailDatabase;
        private System.Windows.Forms.Button btnGetUpdateData;
        private System.Windows.Forms.Button btnXoaSach;
        private System.Windows.Forms.Button btnXemThuTuc;
    }
}

