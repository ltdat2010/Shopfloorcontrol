using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Globalization;
using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace Production.Class
{
    public class COADAO
    {
        public DataTable COA_Template(int ID)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", " SELECT tbl_COATemplate.ID as ID,  " +
                                             " tbl_COA_Template_Details.COATemplateID as COAID,  " +
                                             " tbl_COA_Template_Details.Value,  " +
                                             " tbl_COA_Template_Details.Tolerance,  " +
                                             " tbl_COA_Template_Details.HMKTID as ControlID,  " +
                                             " tbl_HangMucKiemTra.HMKTEN as Control " +
                                             " FROM [SYNC_NUTRICIEL].[dbo].tbl_COA_Template_Details  " +
                                             " LEFT JOIN [SYNC_NUTRICIEL].[dbo].tbl_HangMucKiemTra " +
                                             " ON tbl_COA_Template_Details.ControlID = tbl_Control.ID " +
                                             " WHERE tbl_COA_Template_Details.COAID=" + ID , CommandType.Text);
            return dt;
        }

        public DataTable COA_List()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT * " +
                                             "FROM [SYNC_NUTRICIEL].[dbo].[tbl_TDCOA] ", CommandType.Text);
            return dt;
        }

        public DataTable COA_Search_ByWO(string WO)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", " SELECT [WO],[SoCOA],[LB_MAT] " +
                                             " FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD] WHERE [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD].[WO]='" + WO+"' ", CommandType.Text);
            return dt;
        }

        public int COA_Template_Max_COAID()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", " SELECT MAX([SoCOA]) as SoCOA  FROM [SYNC_NUTRICIEL].[dbo].[tbl_TDCOA]", CommandType.Text);
            return (int.Parse(dt.Rows[0]["SoCOA"].ToString().Length == 0 ? "1" : dt.Rows[0]["SoCOA"].ToString()) + 1);
        }

        public DataTable COA_Template_Search(int ID)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP"," SELECT [SYNC_NUTRICIEL].[dbo].[tbl_COATemplate].ID, "+
                                            " [SYNC_NUTRICIEL].[dbo].[tbl_COATemplate].ControlID, " +
                                            " [SYNC_NUTRICIEL].[dbo].[tbl_Control].Control, " +
                                            " [SYNC_NUTRICIEL].[dbo].[tbl_COATemplate].Value, " +
                                            " [SYNC_NUTRICIEL].[dbo].[tbl_COATemplate].Tolerance " +
                                            " FROM [SYNC_NUTRICIEL].[dbo].[tbl_COATemplate] " +
                                            " INNER JOIN [SYNC_NUTRICIEL].[dbo].tbl_Control "+
                                            " ON [SYNC_NUTRICIEL].[dbo].[tbl_COATemplate].ControlID = [SYNC_NUTRICIEL].[dbo].tbl_Control.ID " +
                                            " WHERE [SYNC_NUTRICIEL].[dbo].[tbl_COATemplate].COAID =" + ID, CommandType.Text);
            return dt;
        }

        public DataTable KQCOA_Search(string SoCOA, string Characteristic)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", " SELECT [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_KQ].ID, " +
                                            " [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details].HMKTID,  "+
                                            " [SYNC_NUTRICIEL].[dbo].[tbl_HangMucKiemTra].HMKTEN, "+
                                            " [SYNC_NUTRICIEL].[dbo].[tbl_HangMucKiemTra].HMKTVN, " +
                                            " [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details].Value , " +
                                            " [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details].Tolerance,  " +
                                            " [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_KQ].Result  " +
                                            " FROM [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details] " +
                                            " LEFT JOIN [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_KQ]    " +
                                            " ON [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details].ID= [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_KQ].COA_Template_Details_ID  " +
                                            " INNER JOIN [SYNC_NUTRICIEL].[dbo].[tbl_HangMucKiemTra]  " +
                                            " ON [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details].HMKTID = [SYNC_NUTRICIEL].[dbo].[tbl_HangMucKiemTra].ID  " +
                                            " WHERE [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_KQ].SoCOA ='"+ SoCOA +"' AND  [SYNC_NUTRICIEL].[dbo].[tbl_HangMucKiemTra].Characteristic='" + Characteristic +"'", CommandType.Text);
            return dt;
        }

        public DataTable KQCOA_Search_COAID(int COAID, string Characteristic)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP"," SELECT [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_KQ].ID, " +
                                            " [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details].HMKTID,  " +
                                            " [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details].ID as COATemplateID,  " +
                                            " [SYNC_NUTRICIEL].[dbo].[tbl_HangMucKiemTra].HMKTEN, " +
                                            " [SYNC_NUTRICIEL].[dbo].[tbl_HangMucKiemTra].HMKTVN, " +
                                            " [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details].Value , " +
                                            " [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details].Tolerance,  " +
                                            " [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_KQ].Result  " +
                                            " FROM [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details] " +
                                            " LEFT JOIN [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_KQ]    " +
                                            " ON [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details].ID= [SYNC_NUTRICIEL].[dbo].tbl_Result_COA_KQ.COATemplateID  " +
                                            " INNER JOIN [SYNC_NUTRICIEL].[dbo].[tbl_HangMucKiemTra]  " +
                                            " ON [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details].HMKTID = [SYNC_NUTRICIEL].[dbo].tbl_HangMucKiemTra.ID  " +
                                            " WHERE [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details].COAID =" + COAID + 
                                            " AND [SYNC_NUTRICIEL].[dbo].tbl_HangMucKiemTra.Characteristic='" + Characteristic + "'", CommandType.Text);
            return dt;
        }



        public DataTable TDCOA_Search(string SoCOA)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD].[ID] " +
                                                ", [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD].[SoCOA] " +
                                                ", [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD].[COATemplateID]"  +
                                                ", [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD].[WO] " +
                                                ", [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD].[ManfBy] " +
                                                ", [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD].[SmpDate] " +
                                                ", [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD].[ExpDate] " +
                                                ", [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD].[AnlDate] " +
                                                ", [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD].[ManfDate] " +
                                                ", [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD].[LB_MAT] " +
                                                ", [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD].[CreatedBy] " +
                                                ", [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD].[CreatedDate] " +
                                                ", [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD].[Locked] " +
                                                ", [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD].[Note] " +
                                                ", [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Header].[IMGCOA] " +
                                                "FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD]  " +
                                                "INNER JOIN [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Header]  " +
                                                "ON [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD].[COATemplateID] =  [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Header].[ID]  " +
                                                "WHERE [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD].SoCOA ='" + SoCOA+"'" , CommandType.Text);
            return dt;
        }

        //public DataTable KLPKN_Search(int SoPKN)
        //{
        //    DataTable dt = new DataTable();
        //    dt = Sql.ExecuteDataTable("SAP", "SELECT * " +
        //                                        "FROM [SYNC_NUTRICIEL].[dbo].[tbl_KLPKN]  " +
        //                                        "WHERE [SYNC_NUTRICIEL].[dbo].[tbl_KLPKN].SoPKN =" + SoPKN, CommandType.Text);
        //    return dt;
        //}

        public DataTable TDCOA_Visible(string WO)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT * " +
                                            "FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD]   " +
                                            "WHERE [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD].WO ='" + WO+"'", CommandType.Text);
            return dt ;
        }

        public DataTable COA_Template_View()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details] ", CommandType.Text);
            return dt;
        }
        public int COA_Template_Visible(int COAID, int ControlID)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT *  FROM [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details] WHERE COAID =" + COAID+" and ControlID = "+ControlID, CommandType.Text);
            //XtraMessageBox.Show("Row count : "+dt.Rows.Count.ToString());
            return dt.Rows.Count;
        }

        public void COA_Template_Delete(int ID)
        {
            if (XtraMessageBox.Show("Do you want to delete the COA template no = '"+ID.ToString()+"'?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //e.Cancel = true;
                Sql.ExecuteNonQuery("SAP", "DELETE  FROM [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details] WHERE COAID =" + ID, CommandType.Text);
                Sql.ExecuteNonQuery("SAP", "DELETE  FROM [SYNC_NUTRICIEL].[dbo].[tbl_COA] WHERE ID =" + ID, CommandType.Text);
                XtraMessageBox.Show("Delete successfull ");
            }
            
        }


        public void COA_Template_Insert(DataRow dr)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details]" +
           "([COAID] " +
           ",[ControlID] " +
           ",[Value] " +
           ",[Tolerance]) "+
     "VALUES "+
           "(" + int.Parse(dr["COAID"].ToString()) +
           "," + int.Parse(dr["ControlID"].ToString()) +
           ",'" + dr["Value"].ToString() +
           "','" + dr["Tolerance"].ToString() + "')", CommandType.Text);
        }

        public void KQCOA_Insert(int SoCOA,DataRow dr)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_KQCOA]" +
           "([SoCOA] " +
           ",[COATemplateID] " +
           //",[KQTT] " +
           ",[NgayTao] " +
           ",[NguoiTao]) " +
     "VALUES " +
           "(" + SoCOA +
           "," + int.Parse(dr["COATemplateID"].ToString()) +
           //"," + float.Parse(dr["KQTT"].ToString().Length == 0 ? "1" : dr["CTPTID"].ToString()) +
           ",'" + DateTime.Today +
           "','NguoiTao')", CommandType.Text);
        }

     //   public void KLPKN_Insert(int SoPKN, string KL ,string PassFail)
     //   {
     //       Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_KLPKN]" +
     //      "([SoPKN] " +
     //      ",[KL] " +
     //      ",[PassFail]) " +
     //"VALUES " +
     //      "(" + SoPKN +
     //      ",'" + KL +
     //      "','" + PassFail + "')", CommandType.Text);
     //   }

        //public void KLPKN_Update(int SoPKN, string KL, string PassFail)
        //{
        //    Sql.ExecuteNonQuery("SAP", "UPDATE [dbo].[tbl_KLPKN] " +
        //                               "SET [PassFail] = '" + PassFail +
        //                               "',[KL] = '" + KL +
        //                               "' WHERE [dbo].[tbl_KQPKN].[SoPKN]=" + SoPKN, CommandType.Text);
        //}


        //public void KQPKN_Update(DataRow dr)
        //{
        //    Sql.ExecuteNonQuery("SAP", "UPDATE [dbo].[tbl_KQPKN] "+
        //                               "SET [KQTT] = "+ float.Parse(dr["KQTT"].ToString()) +                                      
        //                               "WHERE [dbo].[tbl_KQPKN].[ID]=" + int.Parse(dr["ID"].ToString()), CommandType.Text);
        //}

        public void KQCOA_Update(int ID, string Result)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [dbo].[tbl_KQCOA] " +
                                       "SET [Result] = '" + Result +
                                       "' WHERE [dbo].[tbl_KQCOA].[ID]=" + ID, CommandType.Text);
        }

        public void TDCOA_Insert(int SoCOA
            , int COATemplateID
            , string WO
            , string Manufacturedby
            //,string SLNhan
            , DateTime SmpDate
            //,string Solo
            , DateTime ExpDate
            , DateTime AnlDate
            , DateTime ManfDate
            , string LB_MAT
            )
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [dbo].[tbl_TDCOA] "+
           "([SoCOA] " +
           ",[COATemplateID] " +
           ",[WO] " +
           ",[Manufacturedby] " +
           ",[SmpDate] " +
           ",[ExpDate] " +
           ",[AnlDate] " +
           ",[ManfDate] "+
           ",[LB_MAT]) " +
     "VALUES "+
           "('" + SoCOA +
           "'," + COATemplateID +
           ",'" + WO +
           "','" + Manufacturedby +
           "','" + SmpDate +
           "','" + ExpDate +
           "','" + AnlDate +
           "','" + ManfDate + 
           "','" + LB_MAT  +"')", CommandType.Text);
        }

        
    }

}


