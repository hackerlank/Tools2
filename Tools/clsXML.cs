using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace Tools
{
    class clsXML
    {

        //"Xử lý những Xml chứa thông tin các database "

        #region "XML đối với các file dữ liệu nguồn."
        private XmlDocument getXMLDocument(string fileName)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(fileName);
                return doc;
            }
            catch (Exception)
            {
                try
                {
                    doc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?> " +
                                "<root> " +
                                "  <Database Name=\"georgetown_ThanhTri\">  " +
                                "    <Server>TIENTHANH-PC\\SQLEXPRESS</Server> " +
                                "    <User>thanhlogin</User> " +
                                "    <Password>Thanh1</Password> " +
                                "    <TenQuan>huyện Thanh Trì</TenQuan> " +
                                "    <DichVu1 MaxID=\"150\">false</DichVu1> " +
                                "    <DichVu2 MaxID=\"250\">true</DichVu2> " +
                                "    <DichVu3 MaxID=\"350\">true</DichVu3> " +
                                "    <ThoiDiemTao>10/8/2015</ThoiDiemTao> " +
                                "  </Database> " +
                                "</root>");
                    return doc;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi! không có cơ sở dữ liệu để lưu vào.\n" + ex.Message);
                    return null;
                }
            }
        }
        public bool AddDatabaseSourceInfo(string fileName,string Database, string Server, string User, string Password, string TenQuan, string MaxID_DichVu1, string MaxID_DichVu2, string MaxID_DichVu3, bool DV1, bool DV2, bool DV3, string ThoiDiemTao)
        {
            try
            {
                XmlDocument doc = getXMLDocument(fileName);

                XmlNode root = doc.DocumentElement;

                XmlElement elmDatabase = doc.CreateElement("Database");

                XmlAttribute atbDatabaseName = doc.CreateAttribute("Name");
                atbDatabaseName.InnerXml = Database;
                elmDatabase.SetAttributeNode(atbDatabaseName);



                XmlElement elmServer = doc.CreateElement("Server");
                elmServer.InnerText = Server;

                XmlElement elmUser = doc.CreateElement("User");
                elmUser.InnerText = User;

                XmlElement elmPassword = doc.CreateElement("Password");
                elmPassword.InnerText = Password;

                XmlElement elmTenQuan = doc.CreateElement("TenQuan");
                elmTenQuan.InnerText = TenQuan;

                XmlElement elmThoiDiemTao = doc.CreateElement("ThoiDiemTao");
                elmThoiDiemTao.InnerText = ThoiDiemTao;


                XmlElement elmDichVu1 = doc.CreateElement("DichVu1");
                elmDichVu1.InnerText = XmlConvert.ToString(DV1);

                XmlAttribute atbMaxID1 = doc.CreateAttribute("MaxID");
                atbMaxID1.InnerXml = MaxID_DichVu1;
                elmDichVu1.SetAttributeNode(atbMaxID1);

                XmlElement elmDichVu2 = doc.CreateElement("DichVu2");
                elmDichVu2.InnerText = XmlConvert.ToString(DV2);

                XmlAttribute atbMaxID2 = doc.CreateAttribute("MaxID");
                atbMaxID2.InnerXml = MaxID_DichVu2;
                elmDichVu2.SetAttributeNode(atbMaxID2);

                XmlElement elmDichVu3 = doc.CreateElement("DichVu3");
                elmDichVu3.InnerText = XmlConvert.ToString(DV3);

                XmlAttribute atbMaxID3 = doc.CreateAttribute("MaxID");
                atbMaxID3.InnerXml = MaxID_DichVu3;
                elmDichVu3.SetAttributeNode(atbMaxID3);


                elmDatabase.AppendChild(elmServer);
                elmDatabase.AppendChild(elmUser);
                elmDatabase.AppendChild(elmPassword);
                elmDatabase.AppendChild(elmTenQuan);
                elmDatabase.AppendChild(elmDichVu1);
                elmDatabase.AppendChild(elmDichVu2);
                elmDatabase.AppendChild(elmDichVu3);
                elmDatabase.AppendChild(elmThoiDiemTao);
                root.AppendChild(elmDatabase);


                doc.Save(fileName);

                return true;
                //có thời gian sẽ thử.... XmlDocumentFragment DocFrag = doc.CreateDocumentFragment();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool EditDatabaseSourceInfo(string fileName, string Database, string Server, string User, string Password, string TenQuan, string MaxID_DichVu1, string MaxID_DichVu2, string MaxID_DichVu3, bool DV1, bool DV2, bool DV3, string ThoiDiemTao)
        {
            try
            {
                XmlDocument doc = getXMLDocument(fileName);
                
                XmlNode root = doc.DocumentElement;
                string xPathString = "//root/Database[ThoiDiemTao='"+ThoiDiemTao+"']";
                XmlNode elm = doc.SelectSingleNode(xPathString);
                if (elm != null)
                {
                    elm.Attributes["Name"].Value = Database;
                    XmlNodeList nodelist = elm.ChildNodes;
                    if (nodelist.Count > 0)
                    {                        
                        for(int i =0;i< nodelist.Count;i++)
                        {
                            XmlElement _elm = (XmlElement)nodelist[i];
                            switch (_elm.Name)
                            {                                
                                case "Server":
                                    _elm.InnerXml=Server;
                                    break;
                                case "User":
                                    _elm.InnerXml=User;
                                    break;
                                case "Password":
                                    _elm.InnerXml=Password;
                                    break;
                                case "TenQuan":
                                    _elm.InnerXml = TenQuan;
                                    break;

                                case "DichVu1":
                                    _elm.InnerText = XmlConvert.ToString(DV1);
                                    XmlAttribute atb1 = _elm.GetAttributeNode("MaxID");
                                    atb1.InnerXml = MaxID_DichVu1;
                                    break;
                                case "DichVu2":
                                    _elm.InnerText = XmlConvert.ToString(DV2);
                                    XmlAttribute atb2 = _elm.GetAttributeNode("MaxID");
                                    atb2.InnerXml = MaxID_DichVu2;
                                    break;
                                case "DichVu3":
                                    _elm.InnerText = XmlConvert.ToString(DV3);
                                    XmlAttribute atb3 = _elm.GetAttributeNode("MaxID");
                                    atb3.InnerXml = MaxID_DichVu3;
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }

                doc.Save(fileName);

                return true;
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool EditDatabaseSourceInfo(string fileName, bool DV1, bool DV2, bool DV3, string ThoiDiemTao)
        {
            try
            {
                XmlDocument doc = getXMLDocument(fileName);

                XmlNode root = doc.DocumentElement;
                string xPathString = "//root/Database[ThoiDiemTao='" + ThoiDiemTao + "']";
                XmlNode elm = doc.SelectSingleNode(xPathString);
                if (elm != null)
                {
                    XmlNodeList nodelist = elm.ChildNodes;
                    if (nodelist.Count > 0)
                    {
                        for (int i = 0; i < nodelist.Count; i++)
                        {
                            XmlElement _elm = (XmlElement)nodelist[i];
                            switch (_elm.Name)
                            {
                                
                                case "DichVu1":
                                    _elm.InnerText = XmlConvert.ToString(DV1);                                    
                                    break;
                                case "DichVu2":
                                    _elm.InnerText = XmlConvert.ToString(DV2);
                                    break;
                                case "DichVu3":
                                    _elm.InnerText = XmlConvert.ToString(DV3);
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    return false;
                }

                doc.Save(fileName);

                return true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        
        public bool GetDatabaseSourceInfo(string fileName,ref string Database,ref string Server,ref string User,ref string Password, ref string TenQuan,ref string MaxID_DichVu1,ref string MaxID_DichVu2,ref string MaxID_DichVu3,ref bool DV1,ref bool DV2,ref bool DV3,ref string ThoiDiemTao)
        {
            try
            {
                XmlDocument doc = getXMLDocument(fileName);

                XmlNode root = doc.DocumentElement;
                string xPathString = "//root/Database[ThoiDiemTao='" + ThoiDiemTao + "']";
                XmlNode node = doc.SelectSingleNode(xPathString);

                if (node != null)
                {
                    XmlElement elm = (XmlElement)node;
                    Database = elm.GetAttributeNode("Name").InnerXml;

                    XmlNode firstChild = elm.FirstChild;

                    XmlNodeList nodelist = elm.ChildNodes;
                    for(int i=0;i<nodelist.Count;i++)
                    {
                        XmlElement _elm = (XmlElement)nodelist[i];
                        switch (_elm.Name)
                        {
                            case "Server":
                                Server = _elm.InnerText;
                                break;
                            case "User":
                                User = _elm.InnerText;
                                break;
                            case "Password":
                                Password = _elm.InnerText;
                                break;
                            case "TenQuan":
                                TenQuan = _elm.InnerText;
                                break;
                            case "DichVu1":
                                DV1 = XmlConvert.ToBoolean(_elm.InnerText);
                                XmlAttribute atb1 = _elm.GetAttributeNode("MaxID");
                                MaxID_DichVu1 = atb1.InnerXml;
                                break;
                            case "DichVu2":
                                DV2 = XmlConvert.ToBoolean(_elm.InnerText);
                                XmlAttribute atb2 = _elm.GetAttributeNode("MaxID");
                                MaxID_DichVu2 = atb2.InnerXml;
                                break;
                            case "DichVu3":
                                DV3 = XmlConvert.ToBoolean(_elm.InnerText);
                                XmlAttribute atb3 = _elm.GetAttributeNode("MaxID");
                                MaxID_DichVu3 = atb3.InnerXml;
                                break;

                            case "ThoiDiemTao":
                                ThoiDiemTao = _elm.InnerText;
                                break;
                        }
                    }
                }

                doc.Save(fileName);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool DeleteDatabaseSourceInfo(string fileName, string ThoiDiemTao)
        {
            try
            {
                XmlDocument doc =getXMLDocument(fileName);
                XmlNode root = doc.DocumentElement;

                string xPathString = "//root/Database[ThoiDiemTao='" + ThoiDiemTao + "']";

                XmlNode elm = doc.SelectSingleNode(xPathString);
                if(elm != null)
                    root.RemoveChild(elm);
                doc.Save(fileName);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }



        public List<string> getListDatabase(string fileName)
        {
            try
            {
                List<string> dsDatabase = new List<string>();
                XmlDocument doc = getXMLDocument(fileName);

                XmlNode root = doc.DocumentElement;

                XmlNodeList nodelist = root.ChildNodes;
                if (nodelist != null)
                {
                    if (nodelist.Count > 0)
                    {
                        for (int i = 0; i < nodelist.Count; i++)
                        {
                            string database = ((XmlElement)nodelist[i]).Attributes["Name"].InnerXml;
                            if (database.Trim() != "")
                                if (!dsDatabase.Contains(database))
                                    dsDatabase.Add(database);
                        }
                        return dsDatabase;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public List<string> getListServer(string fileName)
        {
            try
            {
                List<string> dsServer = new List<string>();
                XmlDocument doc = getXMLDocument(fileName);

                XmlNode root = doc.DocumentElement;

                XmlNodeList nodelist = root.ChildNodes;
                if (nodelist != null)
                {
                    if (nodelist.Count > 0)
                    {
                        for (int i = 0; i < nodelist.Count; i++)
                        {
                            XmlElement elmServer = (XmlElement)nodelist[i].SelectSingleNode("Server");
                            string Server = elmServer.InnerText;
                            if (Server.Trim() != "")
                                if (!dsServer.Contains(Server))
                                    dsServer.Add(Server);
                        }
                        return dsServer;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }
        public List<string> getListThoiDiemTao(string fileName)
        {
            try
            {
                List<string> dsThoiDiemTao = new List<string>();
                XmlDocument doc = getXMLDocument(fileName);

                XmlNode root = doc.DocumentElement;

                XmlNodeList nodelist = root.ChildNodes;
                if (nodelist != null)
                {
                    if (nodelist.Count > 0)
                    {
                        for (int i = 0; i < nodelist.Count; i++)
                        {
                            XmlElement curDB = (XmlElement)nodelist[i];
                            string ThoiDiemTao = curDB.SelectSingleNode("ThoiDiemTao").InnerText;
                            if (ThoiDiemTao.Trim() != "")
                                if (!dsThoiDiemTao.Contains(ThoiDiemTao))
                                    dsThoiDiemTao.Add(ThoiDiemTao);
                        }
                        return dsThoiDiemTao;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

            #region "hàm phụ phát sinh"
        //public string layThoiDiemTaoMoiNhat(string fileName)
        //{
        //    try
        //    {
        //        List<string> dsDatabase = new List<string>();
        //        XmlDocument doc = getXMLDocument(fileName);

        //        XmlNode root = doc.DocumentElement;

        //    }
        //    catch (Exception)
        //    {

        //        return "";
        //    }
        //}

            #endregion
        #endregion
        #region "XML đối với database lưu trữ phiên bản rút gọn"
        public bool AddDatabaseDestInfo(string fileName, string Database, string Server, string User, string Password)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);

                XmlNode root = doc.DocumentElement;

                XmlElement elmDatabase = doc.CreateElement("Database");

                XmlAttribute atbDatabaseName = doc.CreateAttribute("Name");
                atbDatabaseName.InnerXml = Database;
                elmDatabase.SetAttributeNode(atbDatabaseName);


                XmlElement elmServer = doc.CreateElement("Server");
                elmServer.InnerText = Server;

                XmlElement elmUser = doc.CreateElement("User");
                elmUser.InnerText = User;

                XmlElement elmPassword = doc.CreateElement("Password");
                elmPassword.InnerText = Password;

               
                elmDatabase.AppendChild(elmServer);
                elmDatabase.AppendChild(elmUser);
                elmDatabase.AppendChild(elmPassword);
                
                root.AppendChild(elmDatabase);


                doc.Save(fileName);

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool EditDatabaseDestInfo(string fileName, string Database, string Server, string User, string Password)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);

                XmlNode root = doc.DocumentElement;
                string xPathString = "//root/Database[@Name='" + Database + "']";
                XmlNode elm = doc.SelectSingleNode(xPathString);
                if (elm != null)
                {
                    XmlNodeList nodelist = elm.ChildNodes;
                    if (nodelist.Count > 0)
                    {
                        for (int i = 0; i < nodelist.Count; i++)
                        {
                            XmlElement _elm = (XmlElement)nodelist[i];
                            switch (_elm.Name)
                            {
                                case "Server":
                                    _elm.InnerXml = Server;
                                    break;
                                case "User":
                                    _elm.InnerXml = User;
                                    break;
                                case "Password":
                                    _elm.InnerXml = Password;
                                    break;

                            }
                        }
                    }
                }
                else
                {
                    return false;
                }

                doc.Save(fileName);

                return true;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool GetDatabaseDestInfo(string fileName, ref string Database, ref string Server, ref string User, ref string Password)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                try
                {
                    doc.Load(fileName);
                }
                catch (Exception)
                {
                    try
                    {
                        doc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?> "+
                                    "    <root> "+
                                    "      <Database Name=\"DichVu_DB\"> "+
                                    "        <Server>SERVER-PC</Server> "+
                                    "        <User>sa</User> "+
                                    "        <Password>1</Password> "+
                                    "      </Database>   "+
                                    "    </root>");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi! không có cơ sở dữ liệu để lưu vào.\n"+ex.Message);
                    }
                }
                

                XmlNode root = doc.DocumentElement;
                string xPathString = "//root/Database";
                XmlNode node = doc.SelectSingleNode(xPathString);

                if (node != null)
                {
                    XmlElement elm = (XmlElement)node;
                    Database = elm.GetAttributeNode("Name").InnerXml;

                    XmlNode firstChild = elm.FirstChild;

                    XmlNodeList nodelist = elm.ChildNodes;
                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        XmlElement _elm = (XmlElement)nodelist[i];
                        switch (_elm.Name)
                        {
                            case "Server":
                                Server = _elm.InnerXml;
                                break;
                            case "User":
                                User = _elm.InnerXml;
                                break;
                            case "Password":
                                Password = _elm.InnerXml;
                                break;

                        }
                    }
                }

                doc.Save(fileName);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        #endregion
        #region "XML đối với database lưu trữ phiên bản mở rộng (tạm thời không cần thiết nên không dùng bản này, chỉ dùng bản rút gọn.) nên nếu dùng thì thêm: btnChon, btnThem, cmbThoiDiemTao va cac sukien thich hop."
        //public bool AddDatabaseDestInfo(string fileName, string Database, string Server, string User, string Password, string ThoiDiemTao)
        //{
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        doc.Load(fileName);

        //        XmlNode root = doc.DocumentElement;

        //        XmlElement elmDatabase = doc.CreateElement("Database");

        //        XmlAttribute atbDatabaseName = doc.CreateAttribute("Name");
        //        atbDatabaseName.InnerXml = Database;
        //        elmDatabase.SetAttributeNode(atbDatabaseName);


        //        XmlElement elmServer = doc.CreateElement("Server");
        //        elmServer.InnerText = Server;

        //        XmlElement elmUser = doc.CreateElement("User");
        //        elmUser.InnerText = User;

        //        XmlElement elmPassword = doc.CreateElement("Password");
        //        elmPassword.InnerText = Password;

        //        XmlElement elmThoiDiemTao = doc.CreateElement("ThoiDiemTao");
        //        elmThoiDiemTao.InnerText = ThoiDiemTao;


        //        elmDatabase.AppendChild(elmServer);
        //        elmDatabase.AppendChild(elmUser);
        //        elmDatabase.AppendChild(elmPassword);
        //        elmDatabase.AppendChild(elmThoiDiemTao);
        //        root.AppendChild(elmDatabase);


        //        doc.Save(fileName);

        //        return true;

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}
        //public bool EditDatabaseDestInfo(string fileName, string Database, string Server, string User, string Password, string ThoiDiemTao)
        //{
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        doc.Load(fileName);

        //        XmlNode root = doc.DocumentElement;
        //        string xPathString = "//root/Database[ThoiDiemTao='"+ThoiDiemTao+"']";
        //        XmlNode elm = doc.SelectSingleNode(xPathString);
        //        if (elm != null)
        //        {
        //            XmlNodeList nodelist = elm.ChildNodes;
        //            if (nodelist.Count > 0)
        //            {
        //                for (int i = 0; i < nodelist.Count; i++)
        //                {
        //                    XmlElement _elm = (XmlElement)nodelist[i];
        //                    switch (_elm.Name)
        //                    {
        //                        case "Server":
        //                            _elm.InnerXml = Server;
        //                            break;
        //                        case "User":
        //                            _elm.InnerXml = User;
        //                            break;
        //                        case "Password":
        //                            _elm.InnerXml = Password;
        //                            break;
                                
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //        doc.Save(fileName);

        //        return true;


        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}
        //public bool GetDatabaseDestInfo(string fileName, ref string Database, ref string Server, ref string User, ref string Password, string ThoiDiemTao)
        //{
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        doc.Load(fileName);

        //        XmlNode root = doc.DocumentElement;
        //        string xPathString = "//root/Database[ThoiDiemTao='" + ThoiDiemTao+"']";
        //        XmlNode node = doc.SelectSingleNode(xPathString);

        //        if (node != null)
        //        {
        //            XmlElement elm = (XmlElement)node;
        //            Database = elm.GetAttributeNode("Name").InnerXml;

        //            XmlNode firstChild = elm.FirstChild;
                    
        //            XmlNodeList nodelist = elm.ChildNodes;
        //            for (int i = 0; i < nodelist.Count; i++)
        //            {
        //                XmlElement _elm = (XmlElement)nodelist[i];
        //                switch (_elm.Name)
        //                {
        //                    case "Server":
        //                        Server = _elm.InnerXml;
        //                        break;
        //                    case "User":
        //                        User = _elm.InnerXml;
        //                        break;
        //                    case "Password":
        //                        Password = _elm.InnerXml;
        //                        break;
                            
        //                }
        //            }
        //        }

        //        doc.Save(fileName);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}
        //public bool DeleteDatabaseDestInfo(string fileName, string Database, string ThoiDiemTao)
        //{
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        doc.Load(fileName);

        //        XmlNode root = doc.DocumentElement;

        //        string xPathString = "//root/Database[ThoiDiemTao=" + ThoiDiemTao+"]";

        //        XmlNode elm = doc.SelectSingleNode(xPathString);
        //        if (elm != null)
        //            root.RemoveChild(elm);
        //        doc.Save(fileName);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}

        //public string LayThongTinNgayTaoMoiNhat(string fileName)
        //{
        //    try
        //    {
        //        XmlDocument doc = new XmlDocument();
        //        doc.Load(fileName);

        //        XmlNode root = doc.DocumentElement;

        //        XmlElement elm = (XmlElement)root.LastChild;
        //        if(elm != null)
        //        {
        //            if (elm.ChildNodes.Count > 0)
        //            {
        //                for(int i=0;i<elm.ChildNodes.Count;i++)
        //                {
        //                    if (elm.ChildNodes[i].Name == "ThoiDiemTao")
        //                    {
        //                        return elm.ChildNodes[i].InnerText;
        //                    }
        //                }
        //            }
        //        }
                
        //        return "";
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return "";
        //    }
        //}
        #endregion


        
        
       
    }
}
