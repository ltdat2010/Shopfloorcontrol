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
using Oracle.ManagedDataAccess.Client;

namespace Production.Class
{
    #region Oracle
    public class Oracle
    {
        public static string content;
        public static DataTable ExecuteDataTable(string sql,
                                                CommandType commtype)//,
                                                //params object[] pars)
        {
            try
            {
                
                //Conn.str = StrConn;
                if (Conn.conn_O.State == ConnectionState.Closed)
                {
                    Conn.conn_O.Open();
                }
                OracleCommand com = new OracleCommand(sql, Conn.conn_O);
                com.CommandType = commtype;
                //for (int i = 0; i < pars.Length; i += 2)
                //{
                //    OracleParameter par = new OracleParameter(pars[i].ToString(), pars[i + 1]);
                //    com.Parameters.Add(par);
                //}      
                //MessageBox.Show("com =" + com.CommandText.ToString());
                content = com.CommandText.ToString();
                //MessageBox.Show("com =" + com.CommandText.ToString());

                OracleDataAdapter da = new OracleDataAdapter(com);
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
                if (Conn.conn_O.State == ConnectionState.Open)
                {
                    Conn.conn_O.Close();
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

