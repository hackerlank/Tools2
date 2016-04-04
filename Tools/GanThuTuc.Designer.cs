namespace Tools
{
    partial class GanThuTuc
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
            this.rtb = new System.Windows.Forms.RichTextBox();
            this.cmbfileName = new System.Windows.Forms.ComboBox();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtb
            // 
            this.rtb.BackColor = System.Drawing.SystemColors.Info;
            this.rtb.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb.Location = new System.Drawing.Point(12, 92);
            this.rtb.Name = "rtb";
            this.rtb.ReadOnly = true;
            this.rtb.Size = new System.Drawing.Size(666, 506);
            this.rtb.TabIndex = 0;
            this.rtb.Text = "";
            // 
            // cmbfileName
            // 
            this.cmbfileName.FormattingEnabled = true;
            this.cmbfileName.Location = new System.Drawing.Point(12, 12);
            this.cmbfileName.Name = "cmbfileName";
            this.cmbfileName.Size = new System.Drawing.Size(206, 22);
            this.cmbfileName.TabIndex = 1;
            this.cmbfileName.SelectedIndexChanged += new System.EventHandler(this.cmbfileName_SelectedIndexChanged);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(558, 11);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(57, 23);
            this.btnSua.TabIndex = 2;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(621, 11);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(57, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "Lưu";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // GanThuTuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(690, 642);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.cmbfileName);
            this.Controls.Add(this.rtb);
            this.Name = "GanThuTuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Áp dụng thủ tục.";
            this.Load += new System.EventHandler(this.GanThuTuc_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb;
        private System.Windows.Forms.ComboBox cmbfileName;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnOK;
    }
}