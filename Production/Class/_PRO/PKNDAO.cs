using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Globalization;
using DevExpress.XtraEditors;

namespace Production.Class
{
    public class PKNDAO
    {
        public DataTable PKN_Template(int ID)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT tbl_KQKN_Template_Details.ID, tbl_KQKN_Template_Details.KQKNID, tbl_KQKN_Template_Details.STT, tbl_TieuChuan.TC, tbl_ChiTieuPhanTich.CTPT, tbl_PhuongPhapThu.PPT, tbl_TieuChuan.ID as TCID, tbl_ChiTieuPhanTich.ID as CTPTID, tbl_PhuongPhapThu.ID as PPTID " +
                                             "FROM [SYNC_NUTRICIEL].[dbo].tbl_KQKN_Template_Details LEFT JOIN " +
                                             "[SYNC_NUTRICIEL].[dbo].tbl_TieuChuan ON tbl_KQKN_Template_Details.TCID = tbl_TieuChuan.ID LEFT JOIN " +
                                             "[SYNC_NUTRICIEL].[dbo].tbl_ChiTieuPhanTich ON tbl_KQKN_Template_Details.CTPTID = tbl_ChiTieuPhanTich.ID LEFT JOIN " +
                                             "[SYNC_NUTRICIEL].[dbo].tbl_PhuongPhapThu ON tbl_KQKN_Template_Details.PPTID = tbl_PhuongPhapThu.ID " +
                                             "WHERE tbl_KQKN_Template_Details.KQKNID=" + ID +
            "Order by STT ASC ", CommandType.Text);
            return dt;
        }

        public DataTable PKN_List()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT * " +
                                             "FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD] ", CommandType.Text);
            return dt;
        }        

        public int PKN_Template_Max_KQKNID()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT MAX([ID]) as ID  FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD]", CommandType.Text);
            return (int.Parse(dt.Rows[0]["ID"].ToString().Length == 0 ? "1" : dt.Rows[0]["ID"].ToString())+1) ;
        }

        public DataTable PKN_Template_Search(int ID)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details].ID, " +
                                            "[SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details].STT, " +
                                            "[SYNC_NUTRICIEL].[dbo].tbl_ChiTieuPhanTich.CTPT, "+
                                            "[SYNC_NUTRICIEL].[dbo].tbl_TieuChuan.TC, "+
                                            "[SYNC_NUTRICIEL].[dbo].tbl_PhuongPhapThu.PPT "+
                                            "FROM [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details] " +
                                            "INNER JOIN [SYNC_NUTRICIEL].[dbo].tbl_ChiTieuPhanTich "+
                                            "ON [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details].CTPTID = [SYNC_NUTRICIEL].[dbo].tbl_ChiTieuPhanTich.ID " +
                                            "INNER JOIN [SYNC_NUTRICIEL].[dbo].tbl_TieuChuan "+
                                            "ON [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details].TCID = [SYNC_NUTRICIEL].[dbo].tbl_TieuChuan.ID " +
                                            "INNER JOIN [SYNC_NUTRICIEL].[dbo].tbl_PhuongPhapThu "+
                                            "ON [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details].PPTID = [SYNC_NUTRICIEL].[dbo].tbl_PhuongPhapThu.ID WHERE [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details].KQKNID =" + ID, CommandType.Text);
            return dt;
        }

        public DataTable KQPKN_Search(string SoPKN)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT [SYNC_NUTRICIEL].[dbo].tbl_Result_KQKN_KQTT.ID,[SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details].STT, " +
                                            "[SYNC_NUTRICIEL].[dbo].tbl_ChiTieuPhanTich.CTPT,  "+
                                            "[SYNC_NUTRICIEL].[dbo].tbl_TieuChuan.TC, "+
                                            "[SYNC_NUTRICIEL].[dbo].tbl_Result_KQKN_KQTT.KQTT , " +
                                            "[SYNC_NUTRICIEL].[dbo].tbl_PhuongPhapThu.PPT  "+
                                            "FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_KQTT]  " +
                                            "INNER JOIN [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details]  " +
                                            "ON [SYNC_NUTRICIEL].[dbo].tbl_Result_KQKN_KQTT.KQKN_Detail_ID = [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details].ID  " +
                                            "INNER JOIN [SYNC_NUTRICIEL].[dbo].tbl_ChiTieuPhanTich  "+
                                            "ON [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details].CTPTID = [SYNC_NUTRICIEL].[dbo].tbl_ChiTieuPhanTich.ID  " +                                            
                                            "INNER JOIN [SYNC_NUTRICIEL].[dbo].tbl_TieuChuan  "+
                                            "ON [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details].TCID = [SYNC_NUTRICIEL].[dbo].tbl_TieuChuan.ID  " +
                                            "INNER JOIN [SYNC_NUTRICIEL].[dbo].tbl_PhuongPhapThu  "+
                                            "ON [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details].PPTID = [SYNC_NUTRICIEL].[dbo].tbl_PhuongPhapThu.ID  " +
                                            " WHERE [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_KQTT].SoPKN ='" + SoPKN  +  
                                            "'  ORDER BY tbl_Result_KQKN_KQTT.KQKN_Detail_ID,CAST(LEFT(tbl_KQKN_Template_Details.STT, 1) AS INT)", CommandType.Text);
            return dt;
        }

        public DataTable TDPKN_Search(string SoPKN, int Lan)
        {
            //Lan = 1 ;
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP",    " SELECT * " +
                                                " FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD]  " +
                                                " WHERE [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD].SoPKN ='" + SoPKN + "' and [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD].Lan = " + Lan , CommandType.Text);
            return dt;
        }

        public DataTable TDPKN_Search_Lan(string SoPKN)
        {
            //Lan = 1 ;
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", " SELECT Lan " +
                                                " FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD]  " +
                                                " WHERE [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD].SoPKN ='" + SoPKN + "'", CommandType.Text);
            return dt;
        }

        public DataTable KLPKN_Search(string SoPKN)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT * " +
                                                "FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_KL]  " +
                                                "WHERE [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_KL].SoPKN ='" + SoPKN+"'", CommandType.Text);
            return dt;
        }

        public DataTable TDPKN_Visible(string SoPNK, string Solo)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT * " +
                                            "FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD]   " +
                                            "WHERE [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD].SoPNK ='" + SoPNK+"' and Solo ='"+Solo+"'", CommandType.Text);
            return dt ;
        }

        public DataTable PKN_Template_View()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Header] ", CommandType.Text);
            return dt;
        }
        public int PKN_Template_Visible(int KQKNID, int STT)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT *  FROM [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details] WHERE STT =" + STT+" and KQKNID ="+KQKNID, CommandType.Text);
            //XtraMessageBox.Show("Row count : "+dt.Rows.Count.ToString());
            return dt.Rows.Count;
        }

        public void PKN_Template_Delete(int ID)
        {            
            Sql.ExecuteNonQuery("SAP", "DELETE  FROM [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details] WHERE ID =" + ID, CommandType.Text);
            
        }


        public void PKN_Template_Insert(DataRow dr)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details]" +
           "([KQKNID] "+
           ",[STT] "+
           ",[CTPTID] " +
           ",[TCID] "+
           ",[PPTID]) "+
     "VALUES "+
           "("+ int.Parse(dr["KQKNID"].ToString()) +
           ","+ int.Parse(dr["STT"].ToString()) +
           "," + int.Parse(dr["CTPTID"].ToString().Length == 0 ? "1" : dr["CTPTID"].ToString()) +
           ","+ int.Parse(dr["TCID"].ToString().Length == 0 ? "1" : dr["TCID"].ToString()) +
           "," + int.Parse(dr["PPTID"].ToString().Length == 0 ? "1" : dr["PPTID"].ToString()) + ")", CommandType.Text);
        }

        public void KQPKN_Insert(int SoPKN,DataRow dr)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_KQPKN]" +
           "([SoPKN] " +
           ",[KQKNTemplateID] " +
           //",[KQTT] " +
           ",[NgayTao] " +
           ",[NguoiTao],[Lan]) " +
     "VALUES " +
           "(" + SoPKN +
           "," + int.Parse(dr["ID"].ToString()) +
           //"," + float.Parse(dr["KQTT"].ToString().Length == 0 ? "1" : dr["CTPTID"].ToString()) +
           ",'" + DateTime.Today +
           "','NguoiTao',"+int.Parse(dr["Lan"].ToString())+ ")", CommandType.Text);
        }

        public void KLPKN_Insert(int SoPKN, string KL ,string PassFail,int Lan)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_KL]" +
           "([SoPKN] " +
           ",[KL] " +
           ",[PassFail]) " +
     "VALUES " +
           "(" + SoPKN +
           ",'" + KL +
           "','" + PassFail + "',"+Lan+")", CommandType.Text);
        }

        public void KLPKN_Update(int SoPKN, string KL, string PassFail)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [dbo].[tbl_Result_KQKN_KL] " +
                                       "SET [PassFail] = '" + PassFail +
                                       "',[KL] = '" + KL +
                                       "' WHERE [dbo].[tbl_Result_KQKN_KL].[SoPKN]='" + SoPKN+"'", CommandType.Text);
        }


        //public void KQPKN_Update(DataRow dr)
        //{
        //    Sql.ExecuteNonQuery("SAP", "UPDATE [dbo].[tbl_KQPKN] "+
        //                               "SET [KQTT] = "+ float.Parse(dr["KQTT"].ToString()) +                                      
        //                               "WHERE [dbo].[tbl_KQPKN].[ID]=" + int.Parse(dr["ID"].ToString()), CommandType.Text);
        //}

        public void KQPKN_Update(int ID, float KQTT)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [dbo].[tbl_Result_KQKN_KQTT] " +
                                       "SET [KQTT] = " + KQTT +
                                       "WHERE [dbo].[tbl_Result_KQKN_KQTT].[ID]=" + ID, CommandType.Text);
        }

        public void TDPKN_Insert(string SoPKN
            ,int KQKNTemplateID
            ,string SoPNK
            ,string QCDG
            ,string SLNhan
            ,DateTime NgayNhan
            ,string Solo
            ,DateTime NgaySX
            ,DateTime HSD
            ,DateTime NgayPT
            ,string TenNL
            ,int Lan
            )
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [dbo].[tbl_Result_KQKN_TD] " +
           "([SoPKN] "+
           ",[KQKNTemplateID] "+
           ",[SoPNK] "+
           ",[QCDG] "+
           ",[SLNhan] "+
           ",[NgayNhan] "+
           ",[Solo] "+
           ",[NgaySX] "+
           ",[HSD] "+
           ",[NgayPT] " +
           ",[TenNL] " +
           ",[Lan]) "+
     "VALUES "+
           "('"+ SoPKN +
           "',"+KQKNTemplateID +
           ",'"+SoPNK +
           "','"+QCDG +
           "','"+SLNhan +
           "','"+NgayNhan +
           "','"+Solo +
           "','"+NgaySX +
           "','"+HSD +
           "','" + NgayPT +
           "','" + TenNL +
           "','"+Lan +"')", CommandType.Text);
        }

        //Kiểm tra số lần Mà Lô đ1o đả đc kiểm nghiệm
        //Nếu ko có gán = 0
        public int PKN_Lan(string Solo)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", " SELECT MAX(Lan) as Lan" +
                                             " FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD]  WHERE [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD].[Solo] ='" + Solo+"'", CommandType.Text);
            return dt.Rows[0]["Lan"].ToString().Length > 0 ? int.Parse(dt.Rows[0]["Lan"].ToString()) + 1 : 1 ;
        } 

        
    }

}


