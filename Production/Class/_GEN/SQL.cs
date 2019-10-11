using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Production.Class
{
    /// <summary>
    /// TIP///
    /// </summary>
    /// Reset ID
    /// DBCC CHECKIDENT ('[tbl_TieuChuan]', RESEED, 0);
    ///

    #region SQL

    public class Sql
    {
        public static string content;

        public static DataTable ExecuteDataTable(string StrConn, string sql,
                                                CommandType commtype,
                                                params object[] pars)
        {
            try
            {
                //Conn.str = StrConn;
                if (Conn.conn_S.State == ConnectionState.Closed)
                {
                    Conn.conn_S.Open();
                }
                SqlCommand com = new SqlCommand(sql, Conn.conn_S);
                com.CommandType = commtype;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    com.Parameters.Add(par);
                }
                //MessageBox.Show("com =" + com.CommandText.ToString());
                content = com.CommandText.ToString();
                //System.IO.File.WriteAllText(@"D:\Exc_DT_CommandText_WriteText.txt", content);
                //MessageBox.Show("com =" + com.CommandText.ToString());
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
                if (Conn.conn_S.State == ConnectionState.Open)
                {
                    Conn.conn_S.Close();
                }
                //conn.Close();
            }
        }

        public static void ExecuteNonQuery(string StrConn, string sql,
                                            CommandType commtype,
                                            params object[] pars)
        {
            //Conn.str = StrConn;
            int interval;
            if (Conn.conn_S.State == ConnectionState.Closed)
            {
                Conn.conn_S.Open();
            }
            SqlCommand com = new SqlCommand(sql, Conn.conn_S);
            com.CommandType = commtype;
            for (int i = 0; i < pars.Length; i += 2)
            {
                SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                com.Parameters.Add(par);
            }
            content = com.CommandText.ToString();
            System.IO.File.WriteAllText(@"D:\Exc_Non_CommandText_WriteText.txt", content);
            //MessageBox.Show("com =" + com.CommandText.ToString());

            interval = com.ExecuteNonQuery();
            //MessageBox.Show("ExecuteNonQueryNO =" + interval.ToString());
            if (Conn.conn_S.State == ConnectionState.Open)
            {
                Conn.conn_S.Close();
            }
        }

        public static SqlDataAdapter ExecuteDataAdapter(string StrConn, string sql,
                                                        CommandType commtype,
                                                        params object[] pars)
        {
            try
            {
                if (Conn.conn_S.State == ConnectionState.Closed)
                {
                    Conn.conn_S.Open();
                }
                SqlCommand com = new SqlCommand(sql, Conn.conn_S);
                com.CommandType = commtype;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    com.Parameters.Add(par);
                }
                //MessageBox.Show("com =" + com.CommandText.ToString());
                content = com.CommandText.ToString();
                //System.IO.File.WriteAllText(@"D:\Exc_SqlDT_CommandText_WriteText.txt", content);
                SqlDataAdapter da = new SqlDataAdapter(com);
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
                if (Conn.conn_S.State == ConnectionState.Open)
                {
                    Conn.conn_S.Close();
                }
                //Conn.conn.Close();
            }
        }

        public static DataSet ExecuteDataSet(string StrConn, string sql,
                                                CommandType commtype,
                                                params object[] pars)
        {
            try
            {
                //Conn.str = StrConn;
                if (Conn.conn_S.State == ConnectionState.Closed)
                {
                    Conn.conn_S.Open();
                }

                SqlCommand com = new SqlCommand(sql, Conn.conn_S);
                com.CommandType = commtype;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    com.Parameters.Add(par);
                }
                //MessageBox.Show("com =" + com.CommandText.ToString());
                content = com.CommandText.ToString();
                //System.IO.File.WriteAllText(@"D:\Exc_DtsetCommandText_WriteText.txt", content);
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
                if (Conn.conn_S.State == ConnectionState.Open)
                {
                    Conn.conn_S.Close();
                }
                //Conn.conn.Close();
            }
        }

        public static SqlDataReader ExecuteDataReader(string StrConn,
                                                        string sql,
                                                        CommandType commtype,
                                                        params object[] pars)
        {
            try
            {
                //Conn.str = StrConn;
                if (Conn.conn_S.State == ConnectionState.Closed)
                {
                    Conn.conn_S.Open();
                }
                SqlCommand com = new SqlCommand(sql, Conn.conn_S);
                com.CommandType = commtype;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    com.Parameters.Add(par);
                }
                content = com.CommandText.ToString();
                //System.IO.File.WriteAllText(@"D:\CommandText_WriteText.txt", content);
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
                if (Conn.conn_S.State == ConnectionState.Open)
                {
                    Conn.conn_S.Close();
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

        public static DataTable ExecuteDataTable_SelectCMD(string StrConn,
                                                        string sql,
                                                        CommandType commtype,
                                                        params object[] pars)
        {
            try
            {
                //Conn.str = StrConn;
                if (Conn.conn_S.State == ConnectionState.Closed)
                {
                    Conn.conn_S.Open();
                }

                SqlCommand com = new SqlCommand(sql, Conn.conn_S);
                com.CommandType = commtype;
                for (int i = 0; i < pars.Length; i += 2)
                {
                    SqlParameter par = new SqlParameter(pars[i].ToString(), pars[i + 1]);
                    com.Parameters.Add(par);
                }
                //System.IO.File.WriteAllText(@"D:\CommandText_WriteText.txt", content);
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

        public static int ReturnParameterFromStore(string StrConn, string sql,
                                                        CommandType commtype,
                                                        params object[] pars)
        {
            try
            {
                //Conn.str = StrConn;
                if (Conn.conn_S.State == ConnectionState.Closed)
                {
                    Conn.conn_S.Open();
                }
                SqlCommand com = new SqlCommand(sql, Conn.conn_S);
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
                if (Conn.conn_S.State == ConnectionState.Open)
                {
                    Conn.conn_S.Close();
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