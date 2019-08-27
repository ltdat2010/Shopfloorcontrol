using System;
using System.Collections.Generic;
using System.Data;
using Production.Class._LAB.RESULT;

namespace Production.Class
{
    public class IBD_RESULT_Lines_LABDAO
    {
        public void IBD_RESULT_Lines_LABDAO_INSERT(IBD_RESULT_Lines_LAB OBJ)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_IBD_RESULT_Lines_LAB] " +
           " ([Line_No] " +
           " ,[IBD_RESULT_Header_LAB_ID] " +
           " ,[CTXN_ID] " +
           " ,[OD] " +
           " ,[SP] " +
           " ,[Titer] " +
           " ,[GroupTiter] " +
           " ,[Row] " +
           " ,[Col] " +
           " ,[Result] " +
           " ,[KHMau_BanGiao] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + OBJ.Line_No +
           "'," + OBJ.IBD_RESULT_Header_LAB_ID +
           "," + OBJ.CTXN_ID +
           "," + OBJ.OD +
           "," + OBJ.SP +
           "," + OBJ.Titer +
           "," + OBJ.GroupTiter +
           ",N'" + OBJ.Row +
           "',N'" + OBJ.Col +
           "',N'" + OBJ.Result +
           "',N'" + OBJ.KHMau_BanGiao +
           "',Convert(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "','" + OBJ.Locked +
           "')", CommandType.Text);
        }

        public void IBD_RESULT_Lines_LABDAO_UPDATE(IBD_RESULT_Lines_LAB OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_IBD_RESULT_Lines_LAB] SET" +
           "[Line_No]                               = N'" + OBJ.Line_No + "'" +
           ",[IBD_RESULT_Header_LAB_ID]             =" + OBJ.IBD_RESULT_Header_LAB_ID +
           ",[CTXN_ID]                              =" + OBJ.CTXN_ID +
           ",[OD]                                   =" + OBJ.OD +
           ",[SP]                                   = " + OBJ.SP +
           ",[Titer]                                = " + OBJ.Titer +
           ",[GroupTiter]                           = " + OBJ.GroupTiter +
           ",[Row]                                  = N'" + OBJ.Row + "'" +
           ",[Col]                                  = N'" + OBJ.Col + "'" +
           ",[Result]                               = N'" + OBJ.Result + "'" +
           ",[KHMau_BanGiao]                        = N'" + OBJ.KHMau_BanGiao + "'" +
           ",[CreatedDate]                          = Convert(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy]                            = N'" + OBJ.CreatedBy + "' " +
           ",[Note]                                 = N'" + OBJ.Note + "' " +
           ",[Locked]                               = '" + OBJ.Locked + "' " +
           " WHERE [ID]                             =" + OBJ.ID , CommandType.Text);
        }

        public void IBD_RESULT_Lines_LABDAO_DELETE(int ID)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_IBD_RESULT_Lines_LAB] " +
            " WHERE [IBD_RESULT_Header_LAB_ID]=" + ID, CommandType.Text);
        }

        //public List<string> MYCOTOXIN_RESULT_Lines_List_Acronym(int ID)
        //{
        //    List<string> Lst = new List<string>();
        //    DataTable dt = Sql.ExecuteDataTable("SAP", "Select Acronym FROM [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_Lines_LAB] Where MYCOTOCXIN_RESULT_Header_LAB_ID = " + ID + " GROUP BY Acronym Order by Acronym ASC", CommandType.Text);
        //    foreach (DataRow row in dt.Rows)
        //        Lst.Add(row["Acronym"].ToString());
        //    return Lst;
        //}

        //public DataTable MYCOTOXIN_RESULT_Lines_STD_SELECT(int ID, string acr)
        //{
        //    return Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_Lines_LAB] " +
        //     " WHERE [MYCOTOCXIN_RESULT_Header_LAB_ID]=" + ID + " AND Acronym='" + acr + "' AND KHMau like'STD%' ", CommandType.Text);
        //}

        //public DataTable MYCOTOXIN_RESULT_Lines_StandardCurve_Graph(int ID, string acr)
        //{
        //    return Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_Lines_LAB] " +
        //     " WHERE [MYCOTOCXIN_RESULT_Header_LAB_ID]=" + ID + " AND Acronym='" + acr + "' AND KHMau like'STD%'  AND KHMau not like'STD1'", CommandType.Text);
        //}

        //public DataTable MYCOTOXIN_RESULT_Lines_ACR_SELECT(int ID, string acr)
        //{
        //    return Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_Lines_LAB] " +
        //     " WHERE [MYCOTOCXIN_RESULT_Header_LAB_ID]=" + ID + " AND Acronym='" + acr + "' AND KHMau not like'STD%'", CommandType.Text);
        //}

        public DataTable IBD_RESULT_Lines_LABDAO_SELECT(int ID)
        {
            return Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_IBD_RESULT_Lines_LAB] " +
             " WHERE [MYCOTOCXIN_RESULT_Header_LAB_ID]=" + ID, CommandType.Text);
        }

        //Report trả kết quả cho khách hàng
        //public DataTable MYCOTOXIN_RESUTL_Lines_AnalysisReport(string SoPXN)
        //{
        //    return Sql.ExecuteDataTable("SAP", "SELECT T3.*,tbl_PhuongPhapXetNghiem_LAB.PPXN " +
        //    " FROM tbl_PhuongPhapXetNghiem_LAB " +
        //    " INNER JOIN  " +
        //    " (  SELECT tbl_ChiTieuXetNghiem_LAB.CTXN,tbl_ChiTieuXetNghiem_LAB.MaCTXN,tbl_ChiTieuXetNghiem_LAB.Acronym,tbl_ChiTieuXetNghiem_LAB.UoM,tbl_ChiTieuXetNghiem_LAB.PPXNID,T2.* " +
        //    " FROM tbl_ChiTieuXetNghiem_LAB " +
        //    "   INNER JOIN " +
        //    "   ( " +
        //    "       SELECT T1.*, tbl_KHMau_CTXN_RESULT_DETAILS_LAB.Custom1 " +
        //    "       FROM tbl_KHMau_CTXN_RESULT_DETAILS_LAB " +
        //    "           INNER JOIN " +
        //    "           (" +
        //    "               SELECT tbl_KHMau_CTXN_LAB.ID as KHMau_CTXN_LAB_ID, T.*, tbl_KHMau_CTXN_LAB.CTXNID " +
        //    "               FROM tbl_KHMau_CTXN_LAB " +
        //    "                   INNER JOIN " +
        //    "                   ( " +
        //    "                       Select tbl_PXN_Header.SoPXN, tbl_KHMau_LAB.ID, tbl_KHMau_LAB.KHMau, tbl_KHMau_LAB.KHMau_KhachHang,tbl_PXN_Header.NgayNhanMau,tbl_PXN_Header.NgayTraKetQua " +
        //    "                       FROM tbl_PXN_Header " +
        //    "                       INNER JOIN " +
        //    "                       tbl_KHMau_LAB " +
        //    "                       ON tbl_PXN_Header.SoPXN = tbl_KHMau_LAB.SoPXN " +
        //    "                       WHERE tbl_PXN_Header.SoPXN = '" + SoPXN + "' " +
        //    "                   ) as T " +
        //    "               ON tbl_KHMau_CTXN_LAB.KHMau = T.KHMau " +
        //    "           ) as T1 " +
        //    "       ON tbl_KHMau_CTXN_RESULT_DETAILS_LAB.KHMau_CTXN_ID = T1.KHMau_CTXN_LAB_ID " +
        //    "   ) as T2 " +
        //    " ON tbl_ChiTieuXetNghiem_LAB.ID = T2.CTXNID " +
        //    " ) as T3 " +
        //    " ON tbl_PhuongPhapXetNghiem_LAB.ID = T3.PPXNID " +
        //    " ORDER BY T3.MaCTXN ASC ", CommandType.Text);
        //}
    }
}