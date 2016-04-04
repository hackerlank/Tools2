using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Tools
{
    class clsDatabase
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        string connectionstring = "";   
        SqlConnection SqlCon;
        SqlCommand SqlCom;
        SqlDataAdapter SqlDta;

        public bool OpenCon()
        {
            try
            {
                if (Server.Trim() == "" || Database.Trim() == "" || User.Trim() == "" || Password.Trim() == "")
                {
                    return false;
                }
                else
                {
                    connectionstring = "Server=" + Server + ";Database=" + Database + ";User Id=" + User + ";Password=" + Password + "; Connection Timeout="+ _connectTimeOut;
                    if (SqlCon == null)
                        SqlCon = new SqlConnection(connectionstring);
                    else
                    {
                        if (SqlCon.State == ConnectionState.Open)
                            SqlCon.Close();
                        SqlCon.ConnectionString = connectionstring;
                    }
                       
                    if(SqlCon.State == ConnectionState.Closed)
                        SqlCon.Open();
                    return true;
                }
                
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Lỗi trong Open connection : " + ex.Message);
                return false;
            }
        }

        public bool TestConnection(string server, string database, string user, string password)
        {
            try
            {
                if (server.Trim() == "" || database.Trim() == "" || user.Trim() == "" || password.Trim() == "")
                {
                    return false;
                }
                else
                {
                    int i = 0;
                    connectionstring = "Server=" + server + ";Database=" + database + ";User Id=" + user + ";Password=" + password + "; Connection Timeout=" + _connectTimeOut;
                    SqlConnection con = new SqlConnection(connectionstring);
                    con.Open();
                    i++;
                    con.Close();
                    if (i > 0)
                        return true;
                    else
                        return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
        } 
        public bool CloseCon()
        {
            try
            {
                if (SqlCon != null)
                {
                    if (SqlCon.State == ConnectionState.Open)
                        SqlCon.Close();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi trong Close connection : " + ex.Message);
                return false;
            }
        }

        public List<string> lstValue(string query, string returnName)
        {
            try
            {
                List<string> result = new List<string>();
                OpenCon();
                SqlCom = SqlCon.CreateCommand();
                SqlCom.CommandText= query;
                SqlDataReader reader = SqlCom.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(reader[returnName].ToString());
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                CloseCon();
                return null;
            }
        }
        public bool ExeSP(string SpName, string[] Paras,string[] Values)
        {
            try
            {

                OpenCon();
                SqlCom = SqlCon.CreateCommand();
                SqlCom.CommandType = CommandType.StoredProcedure;
                SqlCom.CommandText = SpName;

                if (Paras != null && Values != null)
                {
                    if (Paras.Length == Values.Length)
                    {
                        for(int i=0;i<Paras.Length;i++)
                        {
                            SqlParameter para = new SqlParameter(Paras[i], Values[i]);
                            SqlCom.Parameters.Add(para);
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                SqlCom.ExecuteNonQuery();
                CloseCon();
                return true;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                CloseCon();
                return false;
            }
        }
        public string ExeQuery(string Query)
        {
            try
            {
                OpenCon();
                SqlCom = SqlCon.CreateCommand();
                SqlCom.CommandText = Query;
                SqlCom.ExecuteNonQuery();
                CloseCon();
                return "";
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                CloseCon();
                return ex.Message;
            }
        }
        SqlDataReader reader;
        public string GetString(string query, string Output)
        {
            try
            {
                string result = "";
                OpenCon();
                SqlCom = SqlCon.CreateCommand();
                SqlCom.CommandText = query;
                reader = SqlCom.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result += reader[Output] + ",";
                    }
                }
                CloseCon();
                return result.Remove(result.Length-1);
            }
            catch (Exception ex)
            {
                CloseCon();
                return "" ;
            }
        }
        public string ExeQuery2(string Query)
        {
            try
            {
                
                SqlCom = SqlCon.CreateCommand();
                SqlCom.CommandText = Query;
                SqlCom.ExecuteNonQuery();
                return "";
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                CloseCon();
                return ex.Message;
            }
        }
        public DataSet GetData(string Query)
        {
            try
            {
                OpenCon();
                SqlCom = SqlCon.CreateCommand();
                SqlCom.CommandText = Query;                  
                DataSet ds = new DataSet();
                SqlDta = new SqlDataAdapter(SqlCom);
                SqlDta.Fill(ds);                 

                CloseCon();
                return ds;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                CloseCon();
                return null;
            }
        }
        public DataSet GetData(string SPName, string[] Paras, string[] Values)
        {
            try
            {
                _connectTimeOut = 30;
                if(Paras != null && Values != null)
                    if(Paras.Length != Values.Length)
                    {
                        System.Windows.Forms.MessageBox.Show("Tham số truyền vào không khớp.");
                        return null;
                    }
                OpenCon();
                SqlCom = SqlCon.CreateCommand();
                SqlCom.CommandType = CommandType.StoredProcedure;
                SqlCom.CommandText = SPName;
                if (Paras != null && Values != null)
                    if (Paras.Length > 0)
                    {
                        for (int i = 0; i < Paras.Length; i++)
                        {
                            SqlParameter para = new SqlParameter(Paras[i], Values[i]);
                            SqlCom.Parameters.Add(para);
                        }
                    }

                DataSet ds = new DataSet();
                SqlDta = new SqlDataAdapter(SqlCom);
                SqlDta.Fill(ds);    
            

                CloseCon();
                _connectTimeOut = 15;
                return ds;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                CloseCon();
                return null;
            }
        }

        public void SetConnectionString(string Server, string Database, string User, string Password)
        {
            CloseCon();
            this.Server = Server;
            this.Database = Database;
            this.User = User;
            this.Password = Password;
            OpenCon();
        }
        #region
        //public bool CreateSP_DV1(string Server, string Database, string User, string Password)
        //{
        //    string StrCreateSpDV1 =
        //    "CREATE PROCEDURE sp_SMSDichVu1	" +
        //    "AS	" +
        //    "BEGIN	" +
        //    "create table #tamp(SoCMT nvarchar(50), NoiDung nvarchar(Max))	" +
        //    "insert into #tamp(SoCMT,NoiDung)	" +
        //    "select c.SoDinhDanh,(c.HoTen + ', ' + c.DiaChi+ N', số thửa '+ td.SoThua+ N', tờ bản đồ ' + td.ToBanDo +N', diện tích ' + (convert(nvarchar(10),td.DienTich)) + N'm2, số GCN'+ SoPhatHanhGCN) as NoiDung 	" +
        //    "from tblChu as c 	" +
        //    "left join tblChuHoSoCapGCN as chs on c.MaChu = chs.MaChu	" +
        //    "left join tblHoSoCapGCN as hs on chs.MaHoSoCapGCN = hs.MaHoSoCapGCN	" +
        //    "left join tblThuaDatCapGCN as td on hs.MaHoSoCapGCN = td.MaHoSoCapGCN	" +
        //    "left join tblTuDienDonViHanhChinh as dv on td.MaDonViHanhChinh = dv.MaDonViHanhChinh	" +
        //    "where c.SoDinhDanh <> ''	" +
        //    "delete from #tamp where NoiDung is null	" +
        //    "select * from #tamp	" +
        //    "drop table #tamp	" +
        //    "END	";


        //    string StrAlterSpDV1 =
        //   "Alter PROCEDURE sp_SMSDichVu1	" +
        //   "AS	" +
        //   "BEGIN	" +
        //   "create table #tamp(SoCMT nvarchar(50), NoiDung nvarchar(Max))	" +
        //   "insert into #tamp(SoCMT,NoiDung)	" +
        //   "select c.SoDinhDanh,(c.HoTen + ', ' + c.DiaChi+ N', số thửa '+ td.SoThua+ N', tờ bản đồ ' + td.ToBanDo +N', diện tích ' + (convert(nvarchar(10),td.DienTich)) + N'm2, số GCN'+ SoPhatHanhGCN) as NoiDung 	" +
        //   "from tblChu as c 	" +
        //   "left join tblChuHoSoCapGCN as chs on c.MaChu = chs.MaChu	" +
        //   "left join tblHoSoCapGCN as hs on chs.MaHoSoCapGCN = hs.MaHoSoCapGCN	" +
        //   "left join tblThuaDatCapGCN as td on hs.MaHoSoCapGCN = td.MaHoSoCapGCN	" +
        //   "left join tblTuDienDonViHanhChinh as dv on td.MaDonViHanhChinh = dv.MaDonViHanhChinh	" +
        //   "where c.SoDinhDanh <> ''	" +
        //   "delete from #tamp where NoiDung is null	" +
        //   "select * from #tamp	" +
        //   "drop table #tamp	" +
        //   "END	";


        //    try
        //    {
        //        SetConnectionString(Server, Database, User, Password);
        //    }
        //    catch (Exception)
        //    {
        //        CloseCon();
        //        return false;
        //    }


        //    SqlCom = SqlCon.CreateCommand();
        //    try
        //    {

        //        SqlCom.CommandText = StrCreateSpDV1;
        //        SqlCom.ExecuteNonQuery();
        //    }
        //    catch (Exception)
        //    {
        //        try
        //        {
        //            SqlCom.CommandText = StrAlterSpDV1;
        //            SqlCom.ExecuteNonQuery();
        //        }
        //        catch (Exception)
        //        {
        //            CloseCon();
        //            return false;
        //        }
        //    }

        //    CloseCon();
        //    return true;
        //}
        //public bool CreateSP_DV2(string Server, string Database, string User, string Password)
        //{


        //    string StrCreateSpDV2 =
        //    "CREATE PROCEDURE sp_SMSDichVu2	" +
        //    "AS	" +
        //    "BEGIN	" +
        //    "create table #tamp(SoGCN nvarchar(50), NoiDung nvarchar(Max))	" +
        //    "insert into #tamp(SoGCN,NoiDung)	" +
        //    "select hs.SoPhatHanhGCN as SoGCN,(c.HoTen + ', ' + c.DiaChi+ N', số thửa '+ td.SoThua+ N', tờ bản đồ ' + td.ToBanDo +N', diện tích ' + (convert(nvarchar(10),td.DienTich)) + N'm2, số GCN ' + hs.SoPhatHanhGCN) as NoiDung 	" +
        //    "from tblHoSoCapGCN as hs	" +
        //    "left join tblChuHoSoCapGCN as chs on hs.MaHoSoCapGCN = chs.MaHoSoCapGCN	" +
        //    "left join tblChu as c on chs.MaChu = c.MaChu	" +
        //    "left join tblThuaDatCapGCN as td on hs.MaHoSoCapGCN = td.MaHoSoCapGCN	" +
        //    "left join tblTuDienDonViHanhChinh as dv on td.MaDonViHanhChinh = dv.MaDonViHanhChinh	" +
        //    "where hs.SoPhatHanhGCN <> ''	" +
        //    "delete from #tamp where NoiDung is null	" +
        //    "select * from #tamp	" +
        //    "drop table #tamp	" +
        //    "END	";

        //    string StrAlterSpDV2 =
        //    "Alter PROCEDURE sp_SMSDichVu2	" +
        //    "AS	" +
        //    "BEGIN	" +
        //    "create table #tamp(SoGCN nvarchar(50), NoiDung nvarchar(Max))	" +
        //    "insert into #tamp(SoGCN,NoiDung)	" +
        //    "select hs.SoPhatHanhGCN as SoGCN,(c.HoTen + ', ' + c.DiaChi+ N', số thửa '+ td.SoThua+ N', tờ bản đồ ' + td.ToBanDo +N', diện tích ' + (convert(nvarchar(10),td.DienTich)) + N'm2, số GCN ' + hs.SoPhatHanhGCN) as NoiDung 	" +
        //    "from tblHoSoCapGCN as hs	" +
        //    "left join tblChuHoSoCapGCN as chs on hs.MaHoSoCapGCN = chs.MaHoSoCapGCN	" +
        //    "left join tblChu as c on chs.MaChu = c.MaChu	" +
        //    "left join tblThuaDatCapGCN as td on hs.MaHoSoCapGCN = td.MaHoSoCapGCN	" +
        //    "left join tblTuDienDonViHanhChinh as dv on td.MaDonViHanhChinh = dv.MaDonViHanhChinh	" +
        //    "where hs.SoPhatHanhGCN <> ''	" +
        //    "delete from #tamp where NoiDung is null	" +
        //    "select * from #tamp	" +
        //    "drop table #tamp	" +
        //    "END	";

        //    try
        //    {
        //        SetConnectionString(Server, Database, User, Password);
        //    }
        //    catch (Exception)
        //    {
        //        CloseCon();
        //        return false;
        //    }


        //    SqlCom = SqlCon.CreateCommand();
        //    try
        //    {
        //        SqlCom.CommandText = StrCreateSpDV2;
        //        SqlCom.ExecuteNonQuery();
        //    }
        //    catch (Exception)
        //    {
        //        try
        //        {
        //            SqlCom.CommandText = StrAlterSpDV2;
        //            SqlCom.ExecuteNonQuery();
        //        }
        //        catch (Exception)
        //        {
        //            CloseCon();
        //            return false;
        //        }
        //    }

        //    CloseCon();
        //    return true;
        //}
        //public bool CreateSP_DV3(string Server, string Database, string User, string Password)
        //{

        //    string StrCreateSpDV3 =
        //    "create PROCEDURE sp_SMSDichVu3	" +
        //    "AS	" +
        //    "BEGIN	" +
        //    "create table #tamp(ToBanDo nvarchar(50),SoThua nvarchar(50), NoiDung nvarchar(Max))	" +
        //    "insert into #tamp(ToBanDo,SoThua,NoiDung)	" +
        //    "select td.ToBanDo,td.SoThua, (td.DiaChi + N', tờ bản đồ ' + td.ToBanDo + N', số thửa ' + td.SoThua + N', diện tích ' + (convert(nvarchar(10),td.DienTich)) + N'm2') as NoiDung 	" +
        //    "from tblThuaDatCapGCN as td	" +
        //    "left join tblTuDienDonViHanhChinh as dv on td.MaDonViHanhChinh = dv.MaDonViHanhChinh	" +
        //    "delete from #tamp where NoiDung is null	" +
        //    "select * from #tamp	" +
        //    "drop table #tamp	" +
        //    "END	";


        //    string StrAlterSpDV3 =
        //    "Alter PROCEDURE sp_SMSDichVu3	" +
        //    "AS	" +
        //    "BEGIN	" +
        //    "create table #tamp(ToBanDo nvarchar(50),SoThua nvarchar(50), NoiDung nvarchar(Max))	" +
        //    "insert into #tamp(ToBanDo,SoThua,NoiDung)	" +
        //    "select td.ToBanDo,td.SoThua, (td.DiaChi + N', tờ bản đồ ' + td.ToBanDo + N', số thửa ' + td.SoThua + N', diện tích ' + (convert(nvarchar(10),td.DienTich)) + N'm2') as NoiDung 	" +
        //    "from tblThuaDatCapGCN as td	" +
        //    "left join tblTuDienDonViHanhChinh as dv on td.MaDonViHanhChinh = dv.MaDonViHanhChinh	" +
        //    "delete from #tamp where NoiDung is null	" +
        //    "select * from #tamp	" +
        //    "drop table #tamp	" +
        //    "END	";
        //    try
        //    {
        //        SetConnectionString(Server, Database, User, Password);
        //    }
        //    catch (Exception)
        //    {
        //        CloseCon();
        //        return false;
        //    }


        //    SqlCom = SqlCon.CreateCommand();
        //    try
        //    {
        //        SqlCom.CommandText = StrCreateSpDV3;
        //        SqlCom.ExecuteNonQuery();
        //    }
        //    catch (Exception)
        //    {
        //        try
        //        {
        //            SqlCom.CommandText = StrAlterSpDV3;
        //            SqlCom.ExecuteNonQuery();
        //        }
        //        catch (Exception)
        //        {
        //            CloseCon();
        //            return false;
        //        }
        //    }

        //    CloseCon();
        //    return true;
        //}

        //public void CreateSP_DV1_curServer(string Server, string Database, string User, string Password) { }
        //public void CreateSP_DV2_curServer(string Server, string Database, string User, string Password) { }
        //public void CreateSP_DV3_curServer(string Server, string Database, string User, string Password) { }
        #endregion
        public bool CreateSP(string sp_Content,string Server, string Database, string User, string Password)
        {
            try
            {
                SetConnectionString(Server, Database, User, Password);
                
            }
            catch (Exception)
            {
                CloseCon();
                return false;
            }


            SqlCom = SqlCon.CreateCommand();
            try
            {

                SqlCom.CommandText = sp_Content;
                SqlCom.ExecuteNonQuery();
            }
            catch (Exception)
            {
                try
                {
                    sp_Content = sp_Content.Replace("CREATE PROCEDURE", "alter procedure "); 
                    SqlCom.CommandText = sp_Content.Replace("create procedure", "alter procedure "); 
                    SqlCom.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    CloseCon();
                    return false;
                }
            }

            CloseCon();
            return true;
        }

        private int _connectTimeOut;
        public int ConnectTimeOut
        {
            get { return _connectTimeOut; }
            set { _connectTimeOut = value; }
        }

    }
}
