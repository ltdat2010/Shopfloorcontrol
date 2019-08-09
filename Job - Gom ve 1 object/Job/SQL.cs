using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using CrystalDecisions;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;
using DevExpress.ClsUser;

namespace DevExpress.ClsSQL
{
        
        #region Connect
        public class Conn
        {
            public static string varConnect = "Data Source= 10.31.1.5;" +
                                                "Database= CM;" +
                                                "User ID= sa;" +
                                                "password= GiangBinh080399";

            //public static string varConnect = "Data Source= DAT;" +
            //                                         "Database= CM;" +
            //                                         "User ID= sa;" +
            //                                         "password= bunjibus";

            public static SqlConnection conn = new SqlConnection(Conn.varConnect);

            public static CrystalDecisions.Shared.ConnectionInfo connect_Info = new CrystalDecisions.Shared.ConnectionInfo();

        }
        #endregion Connect

        #region SQL
        public class Sql
        {
            public static string content;
            public static DataTable ExecuteDataTable(string sql,
                                                    CommandType commtype,
                                                    params object[] pars)
            {
                try
                {
                    if (Conn.conn.State == ConnectionState.Closed)
                    {
                        Conn.conn.Open();
                    }
                    SqlCommand com = new SqlCommand(sql, Conn.conn);
                    com.CommandType = commtype;
                    for (int i = 0; i < pars.Length; i += 2)
                    {
                        SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                        com.Parameters.Add(par);
                    }
                    //MessageBox.Show("com =" + com.CommandText.ToString());
                    content = com.CommandText.ToString();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds.Tables[0];
                }
                catch (Exception e)
                {
                    string _error = e.Message;
                    MessageBox.Show(_error);
                    throw;
                }
                finally
                {
                    if (Conn.conn.State == ConnectionState.Open)
                    {
                        Conn.conn.Close();
                    }
                    //conn.Close();
                }
            }

            public static void ExecuteNonQuery(string sql,
                                                CommandType commtype,
                                                params object[] pars)
            {
                if (Conn.conn.State == ConnectionState.Closed)
                {
                    Conn.conn.Open();
                }
                SqlCommand com = new SqlCommand(sql, Conn.conn);
                com.CommandType = commtype;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    com.Parameters.Add(par);
                }
                content = com.CommandText.ToString();
                //MessageBox.Show("com =" + com.CommandText.ToString());
                com.ExecuteNonQuery();

                if (Conn.conn.State == ConnectionState.Open)
                {
                    Conn.conn.Close();
                }


            }


            public static SqlDataAdapter ExecuteDataAdapter(string sql, 
                                                            CommandType commtype, 
                                                            params object[] pars)
            {
                try
                {
                    if (Conn.conn.State == ConnectionState.Closed)
                    {
                        Conn.conn.Open();
                    }

                    SqlCommand com = new SqlCommand(sql, Conn.conn);
                    com.CommandType = commtype;
                    for (int i = 0; i < pars.Length; i += 2)
                    {
                        SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                        com.Parameters.Add(par);

                    }
                    //MessageBox.Show("com =" + com.CommandText.ToString());
                    content = com.CommandText.ToString();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    //SqlCommandBuilder cmd_bld = new SqlCommandBuilder(da);
                    //cmd_bld.GetUpdateCommand();
                    //cmd_bld.GetDeleteCommand();
                    //cmd_bld.GetInsertCommand();
                    return da;
                }
                catch (Exception e)
                {
                    string _error = e.Message;
                    MessageBox.Show(_error);
                    throw;
                }

                finally
                {
                    if (Conn.conn.State == ConnectionState.Open)
                    {
                        Conn.conn.Close();
                    }
                    //Conn.conn.Close();
                }
            }
            public static DataSet ExecuteDataSet(string sql, 
                                                    CommandType commtype, 
                                                    params object[] pars)
            {

                try
                {
                    if (Conn.conn.State == ConnectionState.Closed)
                    {
                        Conn.conn.Open();
                    }

                    SqlCommand com = new SqlCommand(sql, Conn.conn);
                    com.CommandType = commtype;
                    for (int i = 0; i < pars.Length; i += 2)
                    {
                        SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                        com.Parameters.Add(par);

                    }
                    //MessageBox.Show("com =" + com.CommandText.ToString());
                    content = com.CommandText.ToString();
                    SqlDataAdapter da = new SqlDataAdapter(com);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    return ds;
                }
                catch (Exception e)
                {
                    string _error = e.Message;
                    MessageBox.Show(_error);
                    throw;
                }

                finally
                {
                    if (Conn.conn.State == ConnectionState.Open)
                    {
                        Conn.conn.Close();
                    }
                    //Conn.conn.Close();
                }
            }

            public static SqlDataReader ExecuteDataReader(
                                                            string sql,
                                                            CommandType commtype,                                                            
                                                            params object[] pars)
            {
                try
                {
                    if (Conn.conn.State == ConnectionState.Closed)
                    {
                        Conn.conn.Open();
                    }
                    SqlCommand com = new SqlCommand(sql, Conn.conn);
                    com.CommandType = commtype;
                    for (int i = 0; i < pars.Length; i += 2)
                    {
                        SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                        com.Parameters.Add(par);
                    }
                    content = com.CommandText.ToString();
                    SqlDataReader de = com.ExecuteReader();
                    return de;
                }
                catch (Exception e)
                {
                    string _error = e.Message;
                    MessageBox.Show(_error);
                    throw;
                }
                finally
                {
                    if (Conn.conn.State == ConnectionState.Open)
                    {
                        Conn.conn.Close();
                    }
                    //conn.Close();
                }

            }

            //public static int ReturnParameterFromStore(string sql,
            //                                                CommandType commtype,
            //                                                params object[] pars)
            //{
            //    try
            //    {
            //        if (Conn.conn.State == ConnectionState.Closed)
            //        {
            //            Conn.conn.Open();
            //        }
            //        SqlCommand com = new SqlCommand(sql, Conn.conn);
            //        com.CommandType = commtype;
            //        for (int i = 0; i < pars.Length; i += 2)
            //        {
            //            SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
            //            com.Parameters.Add(par);
            //        }
            //        SqlParameter returnValue = new SqlParameter("@ExtNo", SqlDbType.Int);
            //        returnValue.Direction = ParameterDirection.ReturnValue;
            //        com.Parameters.Add(returnValue);
            //        com.ExecuteNonQuery();
            //        return Convert.ToInt32(returnValue.Value);


            //    }
            //    catch (Exception E)
            //    {
            //        string _error = E.Message;
            //        MessageBox.Show(_error);
            //        throw;

            //    }
            //    finally
            //    {
            //        if (Conn.conn.State == ConnectionState.Open)
            //        {
            //            Conn.conn.Close();
            //        }

            //    }


            //}

            public static DataTable ExecuteDataTable_SelectCMD(
                                                            string sql,
                                                            CommandType commtype,
                                                            params object[] pars)
            {
                try
                {
                    if (Conn.conn.State == ConnectionState.Closed)
                    {
                        Conn.conn.Open();
                    }

                    SqlCommand com = new SqlCommand(sql, Conn.conn);
                    com.CommandType = commtype;
                    for (int i = 0; i < pars.Length; i += 2)
                    {
                        SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                        com.Parameters.Add(par);

                    }
                    DataTable dt = new DataTable(); ;
                    SqlDataAdapter da = new SqlDataAdapter();

                    da.SelectCommand = com;
                    da.Fill(dt);
                    return dt;

                }
                catch (Exception e)
                {
                    string _error = e.Message;
                    MessageBox.Show(_error);
                    throw;
                }
                /*
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                //conn.Close();
            }
                 * */



            }
            public static int ReturnParameterFromStore(string sql,
                                                            CommandType commtype,
                                                            params object[] pars)
            {
                try
                {
                    if (Conn.conn.State == ConnectionState.Closed)
                    {
                        Conn.conn.Open();
                    }
                    SqlCommand com = new SqlCommand(sql, Conn.conn);
                    com.CommandType = commtype;

                    for (int i = 0; i < pars.Length; i += 2)
                    {
                        SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                        com.Parameters.Add(par);
                    }
                    SqlParameter returnValue = new SqlParameter("returnVal", SqlDbType.Int);
                    returnValue.Direction = ParameterDirection.Output;
                    com.Parameters.Add(returnValue);
                    com.ExecuteNonQuery();
                    return (int)returnValue.Value;
                }
                catch (Exception E)
                {
                    string _error = E.Message;
                    MessageBox.Show(_error);
                    throw;

                }
                finally
                {
                    if (Conn.conn.State == ConnectionState.Open)
                    {
                        Conn.conn.Close();
                    }

                }


            }            
            public string StrRep(string s)
            {
                return s.Replace('"', ' ');
            }
            
        }
        #endregion SQL
    
}
