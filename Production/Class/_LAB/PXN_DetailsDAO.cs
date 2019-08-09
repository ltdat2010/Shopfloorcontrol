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
    public class PXN_DetailsDAO
    {
        public void PXN_DetailsDAO_INSERT(PXN_Details OBJ)
        {
            
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Details] " +
           " ([SoPXN] " +
           " ,[CTXNID] " +
           " ,[SLMau] " +
           " ,[GhiChu] " +
           " ,[DonGia] " +
           " ,[ThanhTien] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + OBJ.SoPXN + 
           "'," + OBJ.CTXNID +
           ",N'" + OBJ.SLMau +
           "',N'" + OBJ.GhiChu +
           "',N'" + OBJ.DonGia +
           "',N'" + OBJ.ThanhTien +
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "','" + OBJ.Locked +
           "')", CommandType.Text);
        }

        public void PXN_DetailsDAO_UPDATE(PXN_Details OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Details] SET " +
           " [SoPXN] = N'" + OBJ.SoPXN + "'" +
           ",[CTXNID] = " + OBJ.CTXNID  +
           ",[SLMau] = N'" + OBJ.SLMau + "'" +
           ",[GhiChu] = N'" + OBJ.GhiChu + "'" +
           ",[DonGia] = N'" + OBJ.DonGia + "'" +
           ",[ThanhTien] = N'" + OBJ.ThanhTien + "'" +
           ",[CreatedDate] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public void PXN_DetailsDAO_DELETE(PXN_Details OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Details] " +
            " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public DataTable PXN_DetailsDAO_SELECT(string SoPXN)
        {
                return Sql.ExecuteDataTable("SAP", "SELECT    " +
                                                    " tbl_PXN_Details.ID, " +
                                                    " tbl_PXN_Details.SoPXN, " +
                                                    " tbl_PXN_Details.CTXNID, " +
                                                    " tbl_PXN_Details.SLMau, " +
                                                    " tbl_PXN_Details.GhiChu, " +
                                                    " tbl_PXN_Details.CreatedDate, " +
                                                    " tbl_PXN_Details.CreatedBy, " +
                                                    " tbl_PXN_Details.Note,  " +
                                                    " tbl_PXN_Details.Locked,   " +
                                                    " tbl_ChiTieuXetNghiem_LAB.CTXN, " +
                                                    " tbl_PhuongPhapXetNghiem_LAB.PPXN, " +
                                                    " tbl_NhomChiTieuXetNghiem_LAB.NCTXN, " +
                                                    " tbl_PXN_Details.DonGia,   " +
                                                    " tbl_PXN_Details.ThanhTien, " +
                                                    " tbl_PXN_Details.KetQua, " +
                                                    " tbl_PXN_Details.SLDat, " +
                                                    " tbl_PXN_Result.ResultValue" +
                                                    " FROM              " +
                                                    " tbl_PXN_Details   " +
                                                    " LEFT OUTER JOIN " +
                                                    " tbl_ChiTieuXetNghiem_LAB   " +
                                                    " ON tbl_PXN_Details.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID   " +
                                                    " LEFT OUTER JOIN " +
                                                    " tbl_PhuongPhapXetNghiem_LAB   " +
                                                    " ON tbl_ChiTieuXetNghiem_LAB.PPXNID = tbl_PhuongPhapXetNghiem_LAB.ID   " +
                                                    " LEFT OUTER JOIN " +
                                                    " tbl_NhomChiTieuXetNghiem_LAB   " +
                                                    " ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID " +
                                                    " LEFT OUTER JOIN " +
                                                    " tbl_PXN_Result   " +
                                                    " ON tbl_PXN_Details.ID = tbl_PXN_Result.PXN_Details_ID " +
                                                    " WHERE tbl_PXN_Details.[SoPXN]='" + SoPXN +"'", CommandType.Text);
        }

        public int MAX_PXN_DetailsDAO_ID()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT MAX(ID) as ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Details]", CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());

        }

        public int PXN_DetailsDAO_SELECT_ID_BY_SoPXN_CTXNID(string SoPXN, int CTXNID)
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT MAX(ID) as ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Details] WHERE SoPXN='"+SoPXN+"' and CTXNID ="+CTXNID, CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());

        }
    }

}


