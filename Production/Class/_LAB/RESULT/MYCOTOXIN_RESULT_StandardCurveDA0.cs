using System;
using System.Data;

namespace Production.Class
{
    public class MYCOTOXIN_RESULT_StandardCurveDA0
    {
        public void MYCOTOXIN_RESULT_StandardCurve_INSERT(MYCOTOXIN_RESULT_StandardCurve OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_StandardCurve_LAB] " +
            " ([MYCOTOXIN_RESULT_Header_ID] " +
            " ,[a_SLOPE] " +
            " ,[b_INTERCEPT] " +
            " ,[R_SQUARE] " +
            " ,[CreatedDate] " +
            " ,[CreatedBy] " +
            " ,[Note] " +
            " ,[Acronym] " +
            " ,[Locked]) " +
             " VALUES " +
            "(" + OBJ.MYCOTOXIN_RESULT_Header_ID +
            "," + OBJ.a_SLOPE +
            "," + OBJ.b_INTERCEPT +
            "," + OBJ.R_SQUARE +
            ",Convert(datetime,'" + DateTime.Now +
            "',103),N'" + OBJ.CreatedBy +
            "',N'" + OBJ.Note +
            "',N'" + OBJ.Acronym +
            "','" + OBJ.Locked +
            "')", CommandType.Text);
        }

        public void MYCOTOXIN_RESULT_StandardCurve_UPDATE(MYCOTOXIN_RESULT_StandardCurve OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_StandardCurve_LAB] SET" +
           "[MYCOTOXIN_RESULT_Header_ID]          = " + OBJ.MYCOTOXIN_RESULT_Header_ID +
           ",[a_SLOPE] = " + OBJ.a_SLOPE +
           ",[b_INTERCEPT] = " + OBJ.b_INTERCEPT +
           ",[R_SQUARE] = " + OBJ.R_SQUARE +
           ",[CreatedDate] = Convert(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Acronym] = N'" + OBJ.Acronym + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           " WHERE [ID]='" + OBJ.ID + "'", CommandType.Text);
        }

        public void MYCOTOXIN_RESULT_StandardCurve_DELETE(MYCOTOXIN_RESULT_StandardCurve OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_StandardCurve_LAB] " +
            " WHERE [ID]='" + OBJ.ID + "'", CommandType.Text);
        }

        public DataTable MYCOTOXIN_RESULT_StandardCurve_SELECT(int ID, string acr)
        {
            return Sql.ExecuteDataTable("SAP", " SELECT [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_StandardCurve_LAB].[ID] " +
        " ,[SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_StandardCurve_LAB].[MYCOTOXIN_RESULT_Header_ID] " +
        " ,[SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_StandardCurve_LAB].[CreatedDate] " +
        " ,[SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_StandardCurve_LAB].[CreatedBy] " +
        " ,[SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_StandardCurve_LAB].[Locked] " +
        " ,[SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_StandardCurve_LAB].[Note] " +
        " ,[SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_StandardCurve_LAB].[a_SLOPE] " +
        " ,[SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_StandardCurve_LAB].[b_INTERCEPT] " +
        " ,[SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_StandardCurve_LAB].[R_SQUARE] " +
        " ,[SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_StandardCurve_LAB].[Acronym] " +
        " ,[SYNC_NUTRICIEL].[dbo].[tbl_ChiTieuXetNghiem_LAB].CTXN " +
        " ,[SYNC_NUTRICIEL].[dbo].tbl_MYCOTOXIN_RESULT_Header_LAB.FilePath " +
        " ,[SYNC_NUTRICIEL].[dbo].tbl_MYCOTOXIN_RESULT_Header_LAB.Name " +
        " FROM [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_StandardCurve_LAB] " +
        " INNER JOIN [SYNC_NUTRICIEL].[dbo].[tbl_ChiTieuXetNghiem_LAB] " +
        " ON [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_StandardCurve_LAB].Acronym = [SYNC_NUTRICIEL].[dbo].[tbl_ChiTieuXetNghiem_LAB].Acronym " +
        " INNER JOIN[SYNC_NUTRICIEL].[dbo].tbl_MYCOTOXIN_RESULT_Header_LAB " +
        " ON[SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_StandardCurve_LAB].MYCOTOXIN_RESULT_Header_ID = [SYNC_NUTRICIEL].[dbo].tbl_MYCOTOXIN_RESULT_Header_LAB.ID " +
        "WHERE [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_StandardCurve_LAB].MYCOTOXIN_RESULT_Header_ID = " + ID + " AND [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_StandardCurve_LAB].Acronym ='" + acr + "'", CommandType.Text);
        }
    }
}