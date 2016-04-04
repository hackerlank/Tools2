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
    public partial class Tools : Form
    {
        public Tools()
        {
            InitializeComponent();
        }
        string DiaChiXMLMayDich = Application.StartupPath + @"\DatabaseDest.xml";
        private string _Server="";
        private string _Database = "";
        private string _User = "";
        private string _Pass = "";

        string DiaChiXMLMayNguon = Application.StartupPath + @"\DatabaseSource.xml";
        private string curServer = "";
        private string curDatabase = "";
        private string curUser = "";
        private string curPass = "";
        private string curTenQuan = "";
        private string curMaxID_DV1 = "";
        private string curMaxID_DV2 = "";
        private string curMaxID_DV3 = "";
        private bool curDV1 = false;
        private bool curDV2 = false;
        private bool curDV3 = false;
        private string curThoiDiemTao = "";


        clsDatabase cls = new clsDatabase();
        clsXML xml = new clsXML();

        
        private void Tools_Load(object sender, EventArgs e)
        {
            cls.ConnectTimeOut = 15;
            LayThongTinMayChuLuuDuLieu();
            LoadServer();
            LoadDatabase();
            LoadDistrict();
            LoadThoiDiemTao();
            LoadThongTinDatabaselenTreeView();
            TrangThaiBanDau();

            OnShowInfo += ThongBaoThoiGian;
            OnShowInfo2 += ThongBaoHoatDong;

        }

        #region "Giao Diện"
        private void LoadServer()
        {
            try
            {
                cmbServer.DataSource = xml.getListServer(DiaChiXMLMayNguon);
            }
            catch (Exception)
            {
            }
        }
        private void LoadDatabase()
        {
            try
            {
                cmbDatabase.DataSource = xml.getListDatabase(DiaChiXMLMayNguon);
            }
            catch (Exception)
            {
                
            }
                      
        }
        private void LoadDistrict()
        {
            cmbDistrict.Items.Add("huyện Thanh Trì");
            cmbDistrict.Items.Add("quận Ba Đình");
            cmbDistrict.Items.Add("quận Cầu Giấy");
            cmbDistrict.Items.Add("quận Hoàn Kiếm");
            cmbDistrict.Items.Add("quận Hoàng Mai");
            cmbDistrict.Items.Add("quận Long Biên");
            cmbDistrict.Items.Add("quận Tây Hồ");
            cmbDistrict.Items.Add("quận Thanh Xuân");
            cmbDistrict.Items.Add("....");
        }
        private void LoadThoiDiemTao()
        {
            try
            {
                cmbThoiDiemTao.DataSource = xml.getListThoiDiemTao(DiaChiXMLMayNguon);
            }
            catch (Exception)
            {

            }
        }

        int flag = 0;
        private void TrangThaiBanDau() {
            this.Width=500;
            pnlDetailDatabase.Visible = false;
            cmbDatabase.Enabled = cmbDistrict.Enabled = cmbServer.Enabled = txtUser.Enabled = txtPassword.Enabled = btnOK.Enabled = btnCancel.Enabled = false;
            btnAddDB.Enabled = btnEditDB.Enabled = btnDeleteDB.Enabled = true;
        }
        private void TrangThaiChucNang() {
            this.Width = 700;
            pnlDetailDatabase.Visible = true;
            cmbDatabase.Enabled = cmbDistrict.Enabled = cmbServer.Enabled = txtUser.Enabled = txtPassword.Enabled = btnOK.Enabled = btnCancel.Enabled = true;
            btnAddDB.Enabled = btnEditDB.Enabled = btnDeleteDB.Enabled = false;
        }
        private void TrangThaiKetThuc() {
            this.Width = 500;
            pnlDetailDatabase.Visible = false;
            cmbDatabase.Enabled = cmbDistrict.Enabled = cmbServer.Enabled = txtUser.Enabled = txtPassword.Enabled = btnOK.Enabled = btnCancel.Enabled = false;
            btnAddDB.Enabled = btnEditDB.Enabled = btnDeleteDB.Enabled = true;

            flag = 0;
        }       
        private void btnAddDB_Click(object sender, EventArgs e)
        {
            flag = 1;
            TrangThaiChucNang();
            
        }
        private void btnEditDB_Click(object sender, EventArgs e)
        {
            flag = 2;
            TrangThaiChucNang();
        }
        private void btnDeleteDB_Click(object sender, EventArgs e)
        {
            flag = 3;
            TrangThaiChucNang();
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (flag == 1)
                ThemThongTinDatabase();
            else if (flag == 2)
                CapNhatThongTinDatabase(cmbThoiDiemTao.Text);
            else if (flag == 3)
                XoaThongTinDatabase(cmbThoiDiemTao.Text);
            else
                ShowInfoTime("Không có hành động nào được đề xuất.");


            LoadThongTinDatabaselenTreeView();
            TrangThaiKetThuc();           
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadThongTinDatabaseToTextBox(cmbThoiDiemTao.Text);
            TrangThaiKetThuc();    
        }
        private void btnDB_Click(object sender, EventArgs e)
        {
            DB NoiLuuDuLieu = new DB();
            NoiLuuDuLieu.fileName = DiaChiXMLMayDich;
            NoiLuuDuLieu.ShowDialog();
            LayThongTinMayChuLuuDuLieu();
        }
        private void LayThongTinMayChuLuuDuLieu()
        {
            bool result = xml.GetDatabaseDestInfo(DiaChiXMLMayDich, ref _Database, ref  _Server, ref  _User, ref  _Pass);
            cls.SetConnectionString(_Server, _Database, _User, _Pass);
            // tạo những thủ tục cần thiết trên máy lấy dữ liệu.
            CreateSP_MayChu("spInsertToDinhDanh");
            CreateSP_MayChu("spInsertToHoSo");
            CreateSP_MayChu("spInsertDV3");
        }
        
        private void LoadThongTinDatabaselenTreeView()
        {
            cls.ConnectTimeOut = 1;
            trvDatabase.Nodes.Clear();
            TreeNode root = new TreeNode("Tất cả ");
            trvDatabase.Nodes.Add(root);
            // lấy danh sách thời điểm tạo
            List<string> lstThoiDiemTao = xml.getListThoiDiemTao(DiaChiXMLMayNguon);
            if (lstThoiDiemTao == null)
                return;
            lstThoiDiemTao.Sort();
            // từ từng thời điểm tạo ta lấy thông tin và tạo node cho treeview
            if (lstThoiDiemTao != null)
            {
                if(lstThoiDiemTao.Count>0)
                {
                    for (int i = 0; i < lstThoiDiemTao.Count; i++)
                    {
                        LayThongTinDatabase(lstThoiDiemTao[i]);
                        TreeNode node = new TreeNode(curDatabase);
                        node.Name = curThoiDiemTao;
                        
                        //TreeNode _nodeDV1 = new TreeNode("Dịch vụ 1");// (maxID: " + curMaxID_DV1 + ")");
                        //TreeNode _nodeDV2 = new TreeNode("Dịch vụ 2");//  (maxID: " + curMaxID_DV2 + ")");
                        //TreeNode _nodeDV3 = new TreeNode("Dịch vụ 3");//  (maxID: " + curMaxID_DV3 + ")");
                        //_nodeDV1.Name = "DichVu1";
                        //_nodeDV2.Name = "DichVu2";
                        //_nodeDV3.Name = "DichVu3";
                        //_nodeDV1.Checked = Convert.ToBoolean(curDV1);
                        //_nodeDV2.Checked = Convert.ToBoolean(curDV2);
                        //_nodeDV3.Checked = Convert.ToBoolean(curDV3);

                        //node.Nodes.Add(_nodeDV1);
                        //node.Nodes.Add(_nodeDV2);
                        //node.Nodes.Add(_nodeDV3);

                        root.Nodes.Add(node);

                        if (cls.TestConnection(curServer, curDatabase, curUser, curPass))
                            node.ForeColor = Color.LimeGreen;
                        else
                            node.ForeColor = Color.Red;
                        setParaEmpty();
                    }
                    root.Expand();
                }
            }
            cls.ConnectTimeOut = 15;// default
        }
        private bool LayThongTinDatabase(string ThoiDiemTao) {
            setParaEmpty();
            curThoiDiemTao = ThoiDiemTao;
            return xml.GetDatabaseSourceInfo(DiaChiXMLMayNguon, ref curDatabase, ref curServer, ref curUser, ref curPass, ref curTenQuan, ref curMaxID_DV1, ref curMaxID_DV2, ref curMaxID_DV3, ref curDV1, ref curDV2, ref curDV3, ref curThoiDiemTao);
        }
        private void LoadThongTinDatabaseToTextBox(string ThoiDiemTao)
        {
            LayThongTinDatabase(ThoiDiemTao);
            cmbDatabase.Text = curDatabase;
            cmbServer.Text = curServer;
            cmbDistrict.Text = curTenQuan;
            cmbThoiDiemTao.Text = curThoiDiemTao;
            txtUser.Text = curUser;
            txtPassword.Text = curPass;
        }
        private void cmbThoiDiemTao_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadThongTinDatabaseToTextBox(cmbThoiDiemTao.Text.Trim());
        }

        private void ThemThongTinDatabase()
        {
            bool success = xml.AddDatabaseSourceInfo(DiaChiXMLMayNguon, cmbDatabase.Text, cmbServer.Text, txtUser.Text, txtPassword.Text, cmbDistrict.Text, "0", "0", "0", true, true, true, DateTime.Now.ToString());
            if(success)
            {
                ShowInfoTime("Thêm thành công.");
            }
            else
            {
                ShowInfoTime("Lỗi!");
            }

        }
        private void CapNhatThongTinDatabase(string ThoiDiemTao) {
            bool success = xml.EditDatabaseSourceInfo(DiaChiXMLMayNguon, cmbDatabase.Text, cmbServer.Text, txtUser.Text, txtPassword.Text, cmbDistrict.Text,curMaxID_DV1,curMaxID_DV2,curMaxID_DV3,curDV1,curDV2,curDV3,curThoiDiemTao);
            if (success)
            {
                ShowInfoTime("Thành công.");
            }
            else
            {
                ShowInfoTime("Lỗi!");
            }
            
        }
        private void XoaThongTinDatabase(string ThoiDiemTao) {
            bool success = xml.DeleteDatabaseSourceInfo(DiaChiXMLMayNguon, curThoiDiemTao);
            if (success)
            {
                ShowInfoTime("Thành công.");
            }
            else
            {
                ShowInfoTime("Lỗi!");
            }
        }

        private void trvDatabase_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = e.Node;
            if(selectedNode.Parent == trvDatabase.Nodes[0])
                LoadThongTinDatabaseToTextBox(selectedNode.Name);
        }
        private void setParaEmpty()
        {
            curServer = "";
            curDatabase = "";
            curUser = "";
            curPass = "";
            curTenQuan = "";
            curMaxID_DV1 = "";
            curMaxID_DV2 = "";
            curMaxID_DV3 = "";
            curDV1 = false;
            curDV2 = false;
            curDV3 = false;
            curThoiDiemTao = "";
        }
        #endregion 

        #region "Chạy chương trình"
        private void XoaDuLieuDaLuuTru() { 
            // xoa du lieu da luu tru
            cls.SetConnectionString(_Server, _Database, _User, _Pass); 
            cls.ExeQuery("delete from tblDinhDanh");
            cls.ExeQuery("delete from tblHoSo");
            //cls.ExeQuery("delete from DV3");
            
        }
        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            XoaDuLieuDaLuuTru();
        }
        private void btnGetUpdateData_Click(object sender, EventArgs e)
        {
            ExeDichVu();
        }
        private void ExeDichVu()
        {
            List<string> dsThoiDiemTao = LayDanhSachDatabaseChonTuTreeView();
            if (dsThoiDiemTao != null)
            {
                if (dsThoiDiemTao.Count > 0)
                {
                    for (int i = 0; i < dsThoiDiemTao.Count; i++)
                    {
                        ExeDichVu_Chung(dsThoiDiemTao[i]);
                        ExeDichVu_3(dsThoiDiemTao[i]);
                        LocDuLieuRac();
                    }
                }
            }
        }

        DataSet dsDV1 = new DataSet();
        DataSet dsDV2 = new DataSet();
        DataSet dsDV3 = new DataSet();

        private void ExeDichVu_Chung(string ThoiDiemTao)
        {
            cls.CloseCon();

            if (LayThongTinDatabase(ThoiDiemTao))
            {
                //if (curDV1 == false)
                //    return;
                ShowInfoTime(curDatabase + " Dịch vụ 12 start");

                CreateSP("spLayDuLieu_DinhDanh");
                CreateSP("spLayDuLieu_HoSo");
                
                cls.SetConnectionString(curServer, curDatabase, curUser, curPass);
                try
                {
                    dsDV1.Tables.Clear();
                    dsDV1 = cls.GetData("spLayDuLieu_DinhDanh", null, null);
                    dsDV2.Tables.Clear();
                    dsDV2 = cls.GetData("spLayDuLieu_HoSo", null, null);
                    ShowInfoTime("Xong lấy dữ liệu về dataset");
                    cls.SetConnectionString(_Server, _Database, _User, _Pass);
                    int k = dsDV1.Tables[0].Rows.Count;
                    if (k > 0)
                    {
                        for (int i = 0; i < k; i++)
                        {
                            cls.ExeSP("spInsertToDinhDanh", new string[] { "@SoGCN", "@SoCMT" }, new string[] { LocDau(dsDV1.Tables[0].Rows[i]["SoGCN"].ToString()), LocDau(dsDV1.Tables[0].Rows[i]["SoCMT"].ToString()) });                           
                        }
                    }
                    k = dsDV2.Tables[0].Rows.Count;
                    if (k > 0)
                    {
                        for (int i = 0; i < k; i++)
                        {
                            cls.SetConnectionString(_Server, _Database, _User, _Pass);
                            cls.ExeSP("spInsertToHoSo", new string[] { "@SoGCN", "@NoiDung" }, new string[] { LocDau(dsDV2.Tables[0].Rows[i]["SoGCN"].ToString()), LocDau(dsDV2.Tables[0].Rows[i]["NoiDung"].ToString())});
                        }
                    }
                    cls.CloseCon();
                    
                    ShowInfo("Dịch vụ 12", curDatabase, true);
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    cls.CloseCon();
                    ShowInfo("Dịch vụ 12", curDatabase, false);
                }
                
            }

        }

        private void ExeDichVu_3(string ThoiDiemTao)
        {
            cls.CloseCon();
            if (LayThongTinDatabase(ThoiDiemTao))
            {
                //if (curDV3 == false)
                //    return;
                ShowInfoTime(curDatabase + " Dịch vụ 3 start");
                CreateSP("spLayDuLieuDV3");
                cls.SetConnectionString(curServer, curDatabase, curUser, curPass);
                try
                {
                    dsDV3.Tables.Clear();
                    dsDV3 = cls.GetData("spLayDuLieuDV3", new string[] { "@TenQuan" }, new string[] { curTenQuan });
                    ShowInfoTime("Xong lấy dữ liệu về dataset");
                    cls.SetConnectionString(_Server, _Database, _User, _Pass);

                    int k = dsDV3.Tables[0].Rows.Count;
                    if (k > 0)
                    {
                        for (int i = 0; i < k; i++)
                        {
                            string tbd =LocDau(BoDauNgoac(dsDV3.Tables[0].Rows[i]["ToBanDo"].ToString()));
                                string st=LocDau(BoDauNgoac(dsDV3.Tables[0].Rows[i]["SoThua"].ToString()));
                                    string nd=LocDau(BoDauNgoac(dsDV3.Tables[0].Rows[i]["NoiDung"].ToString()));
                            cls.ExeSP("spInsertDV3", new string[] { "ToBanDo", "SoThua", "NoiDung" }, new string[] { tbd,st ,nd  });
                        }
                    }
                    cls.CloseCon();
                    dsDV3.Tables.Clear();
                    ShowInfo("Dịch vụ 3", curDatabase, true);
                }
                catch (Exception ex)
                {
                    cls.CloseCon();
                    ShowInfo("Dịch vụ 3", curDatabase, false);
                }

            }
        }
        #endregion

        #region "hàm cũ"


        private void ExeDichVu1(string ThoiDiemTao) {
            cls.CloseCon();
           
            if(LayThongTinDatabase(ThoiDiemTao)){
                if (curDV1 == false)
                    return;
                ShowInfoTime(curDatabase+" Dịch vụ 1 start");
            
                CreateSP("DV1");
                //if (curServer == _Server)
                //{
                //    cls.SetConnectionString(_Server, _Database, _User, _Pass);
                //    if (cls.ExeSP("sp_SMSDichVu1", new string[] { "@Database", "@TenQuan", "@MaxID" }, new string[] { curDatabase, curTenQuan, "0" }))
                //        ShowInfo("Dịch vụ 1", curDatabase, true);
                //    else
                //        ShowInfo("Dịch vụ 1", curDatabase, false);
                //}
                //else
                //{
                    cls.SetConnectionString(curServer, curDatabase, curUser, curPass);
                    try
                    {
                        dsDV1.Tables.Clear();
                        dsDV1 = cls.GetData("sp_SMSDichVu1", new string[] { "@TenQuan" }, new string[] { curTenQuan });
                        ShowInfoTime("Xong lấy dữ liệu về dataset");
                        cls.SetConnectionString(_Server, _Database, _User, _Pass);
                        int k = dsDV1.Tables[0].Rows.Count;
                        if (k > 0)
                        {
                            for (int i = 0; i < k; i++)
                            {
                                string query = " insert into DV1(SoCMT, NoiDung) Values (N'" + LocDau(BoDauNgoac(dsDV1.Tables[0].Rows[i][0].ToString())) + "',N'" + LocDau(BoDauNgoac(dsDV1.Tables[0].Rows[i][1].ToString())) + "')";
                                cls.ExeQuery(query);
                            }
                        }
                        cls.CloseCon();
                        dsDV1.Tables.Clear();
                        ShowInfo("Dịch vụ 1", curDatabase, true);
                    }
                    catch (Exception)
                    {

                        cls.CloseCon();
                        ShowInfo("Dịch vụ 1", curDatabase, false);
                    }

               // }
            }
            
        }
        private void ExeDichVu2(string ThoiDiemTao) {
            cls.CloseCon();
            
            if (LayThongTinDatabase(ThoiDiemTao))
            {
                if (curDV2 == false)
                    return;
                ShowInfoTime(curDatabase+" Dịch vụ 2 start");
                CreateSP("DV2");
                //if (curServer == _Server)
                //{
                //    cls.SetConnectionString(_Server, _Database, _User, _Pass);
                //    if (cls.ExeSP("sp_SMSDichVu2", new string[] { "@Database","@TenQuan", "@MaxID" }, new string[] { curDatabase, curTenQuan,"0" }))
                //        ShowInfo("Dịch vụ 2", curDatabase, true);
                //    else
                //        ShowInfo("Dịch vụ 2", curDatabase, false);
                //}
                //else
                //{
                    cls.SetConnectionString(curServer, curDatabase, curUser, curPass);
                    try
                    {
                        dsDV2.Tables.Clear();
                        dsDV2 = cls.GetData("sp_SMSDichVu2", new string[] { "@TenQuan" }, new string[] { curTenQuan });
                        ShowInfoTime("Xong lấy dữ liệu về dataset");
                        cls.SetConnectionString(_Server, _Database, _User, _Pass);

                        int k = dsDV2.Tables[0].Rows.Count;
                        if (k > 0)
                        {
                            for (int i = 0; i < k; i++)
                            {
                                string query = " insert into DV2(SoGCN, NoiDung) Values (N'" + LocDau(BoDauNgoac(dsDV2.Tables[0].Rows[i][0].ToString())) + "',N'" + LocDau(BoDauNgoac(dsDV2.Tables[0].Rows[i][1].ToString())) + "')";
                                cls.ExeQuery(query);
                            }
                        }

                        cls.CloseCon();
                        ShowInfo("Dịch vụ 2", curDatabase, true);


                    }
                    catch (Exception)
                    {

                        cls.CloseCon();
                        ShowInfo("Dịch vụ 2", curDatabase, false);
                    }

                //}
            }
        }
        private void ExeDichVu3(string ThoiDiemTao) {
            cls.CloseCon();
            if (LayThongTinDatabase(ThoiDiemTao))
            {
                if (curDV3 == false)
                    return;
                ShowInfoTime(curDatabase+" Dịch vụ 3 start");
                CreateSP("DV3");
                //if (curServer == _Server)
                //{
                //    cls.SetConnectionString(_Server, _Database, _User, _Pass);
                //    if (cls.ExeSP("sp_SMSDichVu3", new string[] { "@Database", "@TenQuan", "@MaxID" }, new string[] { curDatabase, curTenQuan, "0" }))
                //        ShowInfo("Dịch vụ 3", curDatabase, true);
                //    else
                //        ShowInfo("Dịch vụ 3", curDatabase, false);
                //}
                //else
                //{
                    cls.SetConnectionString(curServer, curDatabase, curUser, curPass);
                    try
                    {
                        dsDV3.Tables.Clear();
                        dsDV3 = cls.GetData("sp_SMSDichVu3", new string[] {"@TenQuan"}, new string[] {curTenQuan});
                        ShowInfoTime("Xong lấy dữ liệu về dataset");
                        cls.SetConnectionString(_Server, _Database, _User, _Pass);

                        int k = dsDV3.Tables[0].Rows.Count;
                        if (k > 0)
                        {
                            for (int i = 0; i < k; i++)
                            {
                                string query = " insert into DV3(ToBanDo,SoThua, NoiDung) Values (N'" + LocDau(BoDauNgoac(dsDV3.Tables[0].Rows[i][0].ToString())) + "',N'" + LocDau(BoDauNgoac(dsDV3.Tables[0].Rows[i][1].ToString())) + "',N'" + LocDau(BoDauNgoac(dsDV3.Tables[0].Rows[i][2].ToString())) + "')";
                                cls.ExeQuery(query);
                            }
                        }
                        cls.CloseCon();
                        dsDV3.Tables.Clear();
                        ShowInfo("Dịch vụ 3", curDatabase, true);
                    }
                    catch (Exception ex)
                    {

                        cls.CloseCon();
                        ShowInfoTime(ex.Message);
                        ShowInfo("Dịch vụ 3", curDatabase, false);
                    }

               // }
                

            }
        }

        //private string XuLyXau(string input)
        //{
        //    return input.Replace("'", "''");

        //}



        #endregion

        #region "hàm bổ sung"
        private string BoDauNgoac(string input)
        {
            
            input = input.Replace('\'',' ');
            
            return input;
        }
        #region "Xử lý treeview"
        private void trvDatabase_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode node = e.Node;
                if (node != null)
                    if (node.Checked == true)
                    {
                        TreenodeCheckAllChild(node);
                    }
                    else
                    {
                        if (node.Parent != null)// node không phải là node gốc (root)
                        {
                            TreenodeUnCheckAllChild(node);
                        }
                    }
            }
            catch (Exception ex)
            {
                ShowInfoTime(ex.Message);
            }
            
        }
        private void TreenodeCheckAllChild(TreeNode parent)
        {
            
            if (parent.Nodes.Count > 0)
            {
                for (int i = 0; i < parent.Nodes.Count; i++)
                {
                    TreeNode child = parent.Nodes[i];
                    string s=child.Text;
                    if(child.Checked== false)
                        child.Checked = true;
                    TreenodeCheckAllChild(child);
                }
            }
        }
        private void TreenodeUnCheckAllChild(TreeNode parent)
        {

            if (parent.Nodes.Count > 0)
            {
                for (int i = 0; i < parent.Nodes.Count; i++)
                {
                    TreeNode child = parent.Nodes[i];
                    string s = child.Text;
                    if (child.Checked == true)
                        child.Checked = false;
                    TreenodeUnCheckAllChild(child);
                }
            }
        }
        private List<string> LayDanhSachDatabaseChonTuTreeView()
        {
            List<string> lstDatabase = new List<string>();
            TreeNode root = trvDatabase.Nodes[0];
            if (root != null)
            {
                if(root.Nodes.Count>0)
                {
                    for (int i = 0; i < root.Nodes.Count; i++)
                    {
                        if (root.Nodes[i].Checked)
                        {
                            CapNhatDichVuTrongDatabaseDaChon(root.Nodes[i]);
                            lstDatabase.Add(root.Nodes[i].Name);
                        }
                    }
                }
            }
            return lstDatabase;
           
        }
        private void CapNhatDichVuTrongDatabaseDaChon(TreeNode node)
        {
            if (node.Parent == trvDatabase.Nodes[0])
            {
                string ThoiDiemTao = node.Name;
                bool ChonDV1=false;
                bool ChonDV2=false;
                bool ChonDV3=false;

                for( int i=0; i< node.Nodes.Count;i++)
                {
                    if (node.Nodes[i].Name == "DichVu1")
                    {
                        if (node.Nodes[i].Checked)
                            ChonDV1 = true;
                        else
                            ChonDV1 = false;
                    }

                    if (node.Nodes[i].Name == "DichVu2")
                    {
                        if (node.Nodes[i].Checked)
                            ChonDV2 = true;
                        else
                            ChonDV2 = false;
                    }

                    if (node.Nodes[i].Name == "DichVu3")
                    {
                        if (node.Nodes[i].Checked)
                            ChonDV3 = true;
                        else
                            ChonDV3 = false;
                    }
                }
                bool success = xml.EditDatabaseSourceInfo(DiaChiXMLMayNguon, ChonDV1, ChonDV2, ChonDV3, ThoiDiemTao);
            }
        }
        #endregion

        delegate void ShowInfoHandler(string s);
        event ShowInfoHandler OnShowInfo;
        private void ShowInfoTime(string s)
        {
            if (OnShowInfo != null)
            {
                OnShowInfo(s);
            }
        }
        delegate void ShowInfoHandler2(string DichVu, string Database, bool TrangThai);
        event ShowInfoHandler2 OnShowInfo2;
        private void ShowInfo(string DichVu, string Database, bool TrangThai)
        {
            if (OnShowInfo2 != null)
            {
                OnShowInfo2(DichVu,Database,TrangThai);
            }
        }
        private void ThongBaoHoatDong(string DichVu,string Database, bool TrangThai) {
            DateTime t = DateTime.Now;
            string status="";
            if(TrangThai)
                status ="Cập nhật thành công.";
            else
                status ="Có lỗi xảy ra!";
            rtbProcess.Text += Database + "   "+DichVu + "......" + status+"   " + t.Hour + "h:" + t.Minute + "m:" + t.Second + "s:" + t.Millisecond + "ms\n----------------------\n";
            Refresh();
            rtbProcess.SelectionStart = rtbProcess.Text.Length;
            rtbProcess.ScrollToCaret();
        }
        private void ThongBaoThoiGian(string s)
        {
            DateTime t = DateTime.Now;
            rtbProcess.Text += s + "   " + t.Hour + "h:" + t.Minute + "m:" + t.Second + "s:" + t.Millisecond + "ms\n";
            Refresh();
            rtbProcess.SelectionStart = rtbProcess.Text.Length;
            rtbProcess.ScrollToCaret();
        }
        private readonly string[] VietNamChar = new string[] 
        { 
            "aAeEoOuUiIdDyY", 
            "áàạảãâấầậẩẫăắằặẳẵ", 
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ", 
            "éèẹẻẽêếềệểễ", 
            "ÉÈẸẺẼÊẾỀỆỂỄ", 
            "óòọỏõôốồộổỗơớờợởỡ", 
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ", 
            "úùụủũưứừựửữ", 
            "ÚÙỤỦŨƯỨỪỰỬỮ", 
            "íìịỉĩ", 
            "ÍÌỊỈĨ", 
            "đ", 
            "Đ", 
            "ýỳỵỷỹ", 
            "ÝỲỴỶỸ" 
        };
        public string LocDau(string str)
        {
            //Thay thế và lọc dấu từng char      
            for (int i = 1; i < VietNamChar.Length; i++)
            {
                for (int j = 0; j < VietNamChar[i].Length; j++)
                    str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
            }
            return BoDauNgoac(str);
        }
        private void XuLyTiengVietChoDichVu()
        {
            DataSet dichvu1 = new DataSet();
            DataSet dichvu2 = new DataSet();
            DataSet dichvu3 = new DataSet();
            cls.SetConnectionString(_Server, _Database, _User, _Pass);

            dichvu1 = cls.GetData("select SoCMT, NoiDung from DV1");
            DataTable tb = dichvu1.Tables[0];
            string qr = "";
            if(tb.Rows.Count>0)
            { 
                for(int i=0;i<tb.Rows.Count;i++)
                {
                    qr = "insert into DVSMS1(SoCMT, NoiDung) values (N'" + LocDau(BoDauNgoac(tb.Rows[i][0].ToString())) + "',N'" + LocDau(BoDauNgoac(tb.Rows[i][1].ToString())) + "')";
                    cls.ExeQuery(qr);
                    ShowInfoTime(DemSoKyTu(LocDau(tb.Rows[i][1].ToString())).ToString());
                }
            }

            dichvu2 = cls.GetData("select SoGCN, NoiDung from DV2");
            tb.Clear();
            tb = dichvu2.Tables[0];
            qr = "";
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    qr = "insert into DVSMS2(SoGCN, NoiDung) values (N'" + LocDau(BoDauNgoac(tb.Rows[i][0].ToString())) + "',N'" + LocDau(BoDauNgoac(tb.Rows[i][1].ToString())) + "')";
                    cls.ExeQuery(qr);
                    //ShowInfoTime(DemSoKyTu(LocDau(tb.Rows[i][1].ToString())).ToString());
                }
            }

            dichvu3 = cls.GetData("select ToBanDo,SoThua,NoiDung from DV3");
            tb.Clear();
            tb = dichvu3.Tables[0];
            qr = "";
            if (tb.Rows.Count > 0)
            {
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    qr = "insert into DVSMS3(ToBanDo,SoThua,NoiDung) values (N'" + LocDau(BoDauNgoac(tb.Rows[i][0].ToString())) + "',N'" + LocDau(BoDauNgoac(tb.Rows[i][1].ToString())) + "',N'" + LocDau(tb.Rows[i][2].ToString()) + "')";
                    cls.ExeQuery(qr);
                    //ShowInfoTime(DemSoKyTu(LocDau(tb.Rows[i][1].ToString())).ToString());
                }
            }

            MessageBox.Show("Xong!");
        }
        private int DemSoKyTu(string input)
        {
            return input.Length;
        }
        
        GanThuTuc sp = new GanThuTuc();
        public void CreateSP(string DichVu)
        {           
            while (sp.ReadFromFile(DichVu).Trim() == "")
            {
                MessageBox.Show("file chưa tạo thủ tục!");
                sp.CSDL = curDatabase;
                sp.ShowDialog();
            }
            while (cls.CreateSP(sp.ReadFromFile(DichVu).Trim(), curServer, curDatabase, curUser, curPass) == false)
            {
                MessageBox.Show("Store Procedure chưa chạy được!");
                sp.CSDL = DichVu;
                sp.ShowDialog();
            }            
        }
        public void CreateSP_MayChu(string DichVu)
        {
            while (sp.ReadFromFile(DichVu).Trim() == "")
            {
                MessageBox.Show("file chưa tạo thủ tục!");
                sp.CSDL = _Database;
                sp.ShowDialog();
            }
            while (cls.CreateSP(sp.ReadFromFile(DichVu).Trim(), _Server, _Database, _User, _Pass) == false)
            {
                MessageBox.Show("Store Procedure chưa chạy được!");
                sp.CSDL = DichVu;
                sp.ShowDialog();
            }
        }
        #region "hàm cũ"
        //public void CreateSP(string DichVu)// đây là trường hợp nếu kèm thêm những database "khác" (tây hồ, thanh trì, hoàng mai, long biên) thì có cấu trúc riêng nên ta sẽ xử lý đầy đủ
        //{
        //        if (curServer == _Server)
        //        {
        //            while (sp.ReadFromFile(curDatabase + "_" + DichVu).Trim() == "")
        //            {
        //                MessageBox.Show("file chưa tạo thủ tục!");
        //                sp.CSDL = curDatabase + "_" + DichVu;
        //                sp.ShowDialog();
        //            }

        //            while (cls.CreateSP(sp.ReadFromFile(curDatabase + "_" + DichVu), _Server, _Database, _User, _Pass) == false)
        //            {
        //                MessageBox.Show("Store Procedure chưa chạy được!");
        //                sp.CSDL = curDatabase;
        //                sp.ShowDialog();
        //            }
        //        }
        //        else
        //        {
        //            while(sp.ReadFromFile(curDatabase + "_"+DichVu+"_KhacServer").Trim() == "")
        //            {
        //                 MessageBox.Show("file chưa tạo thủ tục!");
        //                sp.CSDL = curDatabase;
        //                sp.ShowDialog();
        //            }
        //            while (cls.CreateSP(sp.ReadFromFile(curDatabase + "_" + DichVu + "_KhacServer").Trim(), curServer, curDatabase, curUser, curPass) == false)
        //            {
        //                MessageBox.Show("Store Procedure chưa chạy được!");
        //                sp.CSDL = curDatabase + "_" + DichVu + "_KhacServer";
        //                sp.ShowDialog();
        //            }
        //        }
        //}

        //public void CreateSP(string DichVu)// nếu chỉ dành cho (tây hồ, thanh trì, hoàng mai, long biên) thì ta làm thế này cho đơn giản.
        //{
        //    if (curServer == _Server)
        //    {
        //        while (sp.ReadFromFile(DichVu).Trim() == "")
        //        {
        //            MessageBox.Show("file chưa tạo thủ tục!");
        //            sp.CSDL =DichVu;
        //            sp.ShowDialog();
        //        }

        //        while (cls.CreateSP(sp.ReadFromFile(DichVu), _Server, _Database, _User, _Pass) == false)
        //        {
        //            MessageBox.Show("Store Procedure chưa chạy được!");
        //            sp.CSDL = curDatabase;
        //            sp.ShowDialog();
        //        }
        //    }
        //    else
        //    {
        //        while (sp.ReadFromFile(DichVu + "_KhacServer").Trim() == "")
        //        {
        //            MessageBox.Show("file chưa tạo thủ tục!");
        //            sp.CSDL = curDatabase;
        //            sp.ShowDialog();
        //        }
        //        while (cls.CreateSP(sp.ReadFromFile( DichVu + "_KhacServer").Trim(), curServer, curDatabase, curUser, curPass) == false)
        //        {
        //            MessageBox.Show("Store Procedure chưa chạy được!");
        //            sp.CSDL =DichVu + "_KhacServer";
        //            sp.ShowDialog();
        //        }
        //    }
        //}
        #endregion

        private void btnXemThuTuc_Click(object sender, EventArgs e)
        {
            sp.ShowDialog();
        }
        private void btnXuLyTiengViet_Click(object sender, EventArgs e)
        {
            XuLyTiengVietChoDichVu();
        }
        private void LocDuLieuRac()
        {
            cls.SetConnectionString(_Server, _Database, _User, _Pass);
            CreateSP_MayChu("spLocDuLieuRac");
            cls.ExeSP("spLocDuLieuRac", null, null);
            ShowInfoTime("Xóa dữ liệu rác xong.");
        }

        #endregion

    }
}
