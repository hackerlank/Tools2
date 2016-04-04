using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tools
{
    public partial class DB : Form
    {
        public DB()
        {
            InitializeComponent();
        }
        private void DB_Load(object sender, EventArgs e)
        {
            
            _Database = "DICHVUDB";
            LayThongTinDatabase();
            TrangThaiBanDau();
        }

        private void LoadCmb()
        {
            cmbDatabase.DataSource = cls.getListDatabase(_fileName);
            cmbServer.DataSource = cls.getListServer(_fileName);
        }

        clsXML cls = new clsXML();
        
        private string _fileName = "";
        private string _Database = "";
        private string _Server = "";
        private string _User = "";
        private string _Password = "";

        public string fileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }
        public string Database {
            get { return _Database; }
            set { _Database=value; }
        }
        public string Server
        {
            get { return _Server; }
            set { _Server = value; }
        }
        public string User {
            get { return _User; }
            set { _User = value; }
        } 
            
        public string Password  {
            get { return _Password; }
            set { _Password = value; }
        }
  

        private void LayThongTinDatabase() {           
            bool result = cls.GetDatabaseDestInfo(_fileName,ref _Database,ref _Server,ref _User,ref _Password);
            if(result)
            {
                cmbServer.Text = _Server;
                txtUser.Text = _User;
                txtPass.Text = _Password;
                cmbDatabase.Text = _Database;
            }
        }
        //private void ThemThongTinDatabase()
        //{
        //    bool result = cls.AddDatabaseDestInfo(_fileName, cmbDatabase.Text, cmbServer.Text, txtUser.Text, txtPass.Text);
        //    if (result)
        //    {
        //        MessageBox.Show("Thêm thành công!");
        //        LayThongTinDatabase();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Thất bại.");
        //    }
        //}
        private void CapNhatThongTinDatabase() {
            bool result = cls.EditDatabaseDestInfo(_fileName, cmbDatabase.Text, cmbServer.Text, txtUser.Text, txtPass.Text);
            if(result)
            {
                MessageBox.Show("Cập nhật thành công!");
                LayThongTinDatabase();
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại.");
                LayThongTinDatabase();
            }
        }
        private void TrangThaiBanDau() {
            btnSave.Enabled = false;
            btnEdit.Enabled= true;
            cmbServer.Enabled = txtUser.Enabled = txtPass.Enabled=cmbDatabase.Enabled = false;
        }
        private void TrangThaiChucNang() {
            btnSave.Enabled = true;
            btnEdit.Enabled =false;
            cmbServer.Enabled = txtUser.Enabled = txtPass.Enabled = cmbDatabase.Enabled = true;
        }
    
        private void btnEdit_Click(object sender, EventArgs e)
        {
            TrangThaiChucNang();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                CapNhatThongTinDatabase();
                TrangThaiBanDau();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                TrangThaiBanDau();
            }
            
        }

    }
}
