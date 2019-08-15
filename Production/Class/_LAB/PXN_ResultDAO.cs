using System;
using System.Data;

namespace Production.Class
{
    public class PXN_ResultDAO
    {
        public void PXN_ResultDAO_INSERT(PXN_Result OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Result] " +
           " ([SoPXN] " +
           " ,[CTXNID] " +
           " ,[UnitTestCode] " +
           " ,[PXN_Details_ID] " +
           " ,[ResultLine] " +
           " ,[ResultValue] " +
           " ,[Positive] " +
           " ,[ResultUoM] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + OBJ.SoPXN +
           "'," + OBJ.CTXNID +
           ",N'" + OBJ.UnitTestCode +
           "'," + OBJ.PXN_Details_ID +
           ",N'" + OBJ.ResultLine +
           "',N'" + OBJ.ResultValue +
           "',N'" + OBJ.Positive +
           "',N'" + OBJ.ResultUoM +
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "','" + OBJ.Locked +
           "')", CommandType.Text);
        }

        public void PXN_ResultDAO_UPDATE(PXN_Result OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Result] SET " +
           " [SoPXN] = N'" + OBJ.SoPXN + "'" +
           ",[CTXNID] = " + OBJ.CTXNID +
           ",[UnitTestCode] = N'" + OBJ.UnitTestCode + "'" +
           //",[PXN_Details_ID] = " + OBJ.PXN_Details_ID +
           ",[ResultLine] = N'" + OBJ.ResultLine + "'" +
           ",[ResultValue] = N'" + OBJ.ResultValue + "'" +
           ",[Positive] = N'" + OBJ.Positive + "'" +
           ",[ResultUoM] = N'" + OBJ.ResultUoM + "'" +
           ",[CreatedDate] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public void PXN_ResultDAO_DELETE(PXN_Result OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Result] " +
            " WHERE [SoPXN]='" + OBJ.SoPXN + "' and [ResultLine]='" + OBJ.ResultLine + "'", CommandType.Text);
        }

        public DataTable PXN_ResultDAO_SELECT(string SoPXN)
        {
            return Sql.ExecuteDataTable("SAP", "SELECT    " +
                                                " tbl_PXN_Result.ID, " +
                                                " tbl_PXN_Result.SoPXN, " +
                                                " tbl_PXN_Result.CTXNID, " +
                                                " tbl_PXN_Result.ResultLine, " +
                                                " tbl_PXN_Result.ResultValue, " +
                                                " tbl_PXN_Result.Positive, " +
                                                " tbl_PXN_Result.ResultUoM, " +
                                                " tbl_PXN_Result.CreatedBy, " +
                                                " tbl_PXN_Result.Note,  " +
                                                " tbl_PXN_Result.Locked,   " +
                                                " tbl_PXN_Result.UnitTestCode,   " +
                                                " tbl_ChiTieuXetNghiem_LAB.CTXN, " +
                                                " tbl_PhuongPhapXetNghiem_LAB.PPXN, " +
                                                " tbl_NhomChiTieuXetNghiem_LAB.NCTXN, " +
                                                //" tbl_PXN_Details.DonGia,   " +
                                                //" tbl_PXN_Details.ThanhTien, " +
                                                //" tbl_PXN_Details.KetQua, " +
                                                //" tbl_PXN_Details.SLDat " +
                                                " FROM              " +
                                                " tbl_PXN_Result   " +
                                                " LEFT OUTER JOIN " +
                                                " tbl_ChiTieuXetNghiem_LAB   " +
                                                " ON tbl_PXN_Result.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID   " +
                                                " LEFT OUTER JOIN " +
                                                " tbl_PhuongPhapXetNghiem_LAB   " +
                                                " ON tbl_ChiTieuXetNghiem_LAB.PPXNID = tbl_PhuongPhapXetNghiem_LAB.ID   " +
                                                " LEFT OUTER JOIN " +
                                                " tbl_NhomChiTieuXetNghiem_LAB   " +
                                                " ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID " +
                                                " WHERE tbl_PXN_Result.[SoPXN]='" + SoPXN + "'", CommandType.Text);
        }

        public int MAX_PXN_ResultDAO_ID()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT MAX(ID) as ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Result]", CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());
        }
    }
}