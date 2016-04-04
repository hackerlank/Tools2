using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Tools
{
    /// <summary>
    ///  CHƯƠNG TRÌNH CHO PHÉP GHI LẠI NHỮNG THỦ THỤC ĐỔI VỚI TỪNG CƠ SỞ DỮ LIỆU CỤ THỂ.
    /// </summary>
    public partial class GanThuTuc : Form
    {
        public GanThuTuc()
        {
            InitializeComponent();
        }
        private string csdl;
        public string CSDL
        {
            get { return csdl; }
            set { csdl = value; }
        }
        public FileStream GetFile(string fileName)
        {
            try
            {
                if (fileName.Trim() == "")
                    return null;
                FileStream file;
                string path = Application.StartupPath + "\\StoreProcedure\\" + fileName + ".txt";

                if (!File.Exists(path))
                {
                    file = File.Create(path);
                }
                else
                {
                    file = File.Open(path, FileMode.Open);
                }
                return file;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public string ReadFromFile(string fileName)
        {
            try
            {

                rtb.Text = "";
                FileStream file = GetFile(fileName);
                TextReader rd = new StreamReader(file);
                rtb.Text = rd.ReadToEnd();
                string result = XuLyNhungKyTuDacBiet(rtb.Text);
                rd.Close();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return "";
            }
        }
        public void WriteToFile(string fileName)
        {
            try
            {               
                string path = Application.StartupPath + "\\StoreProcedure\\" + fileName + ".txt";
                TextWriter wr = new StreamWriter(path,false);
               
                for(int i=0;i<rtb.Lines.Length;i++)
                {
                    wr.WriteLine(rtb.Lines[i]);
                }
                wr.Flush();
                wr.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbfileName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReadFromFile(cmbfileName.Text.Trim());
        }

        private void GanThuTuc_Load(object sender, EventArgs e)
        {
            rtb.ReadOnly = true;
            rtb.BackColor = SystemColors.Info;
            btnSua.Enabled = true;
            btnOK.Enabled = false;
            LoadcmbfileName();
            cmbfileName.Text = csdl;
        }
        private void LoadcmbfileName()
        {
            cmbfileName.Items.Clear();
            string path = Application.StartupPath + "\\StoreProcedure";
            DirectoryInfo dirInfo;
            if (Directory.Exists(path))
                dirInfo = new DirectoryInfo(path);
            else 
                dirInfo = Directory.CreateDirectory(path);

            FileInfo[] lstFile= dirInfo.GetFiles();
            if(lstFile.Length >0)
            {
                for(int i=0;i<lstFile.Length;i++)
                {
                    cmbfileName.Items.Add( lstFile[i].Name.Replace(".txt",""));
                }
            }
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            rtb.ReadOnly = false;
            rtb.BackColor = Color.White;
            btnSua.Enabled = false;
            btnOK.Enabled = true;
            cmbfileName.Enabled = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            WriteToFile(cmbfileName.Text.Trim());
            rtb.ReadOnly = true;
            rtb.BackColor = SystemColors.Info;
            cmbfileName.Enabled = true;
            LoadcmbfileName();
            btnSua.Enabled = true;
            btnOK.Enabled = false;
        }
        public string XuLyNhungKyTuDacBiet(string Input)
        {
            Input = Input.Replace("\n", " ");
            Input = Input.Replace("\r", " ");
            Input = Input.Replace("\t", " ");
            return Input;
        }
    }
}
