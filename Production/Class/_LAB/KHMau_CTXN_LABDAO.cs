﻿using System;
using System.Data;

namespace Production.Class
{
    public class KHMau_CTXN_LABDAO
    {
        public void KHMau_CTXN_LABDAO_INSERT(KHMau_CTXN_LAB OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_CTXN_LAB] " +
           " ([KHMau] " +
           " ,[KHMau_ID] " +
           " ,[PriceList_Details_LAB_Id] " +
           //_PriceList_Details_LAB_Id
           " ,[CTXNID] " +
           //" ,[NCTXNID] " +
           " ,[DonGia] " +
           " ,[DonGiaMuaNgoai] " +
           " ,[Discount] " +
           " ,[LoaiDiscount] " +
           " ,[DonGiaSauDiscount] " +
           " ,[ThanhTien] " +
           //" ,[KetQua] " +
           " ,[SoLuongDat] " +
           " ,[SoLuongXN] " +
           " ,[VAT] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + OBJ.KHMau +
           "'," + OBJ.KHMau_ID +
           "," + OBJ.PriceList_Details_LAB_Id +
           "," + OBJ.CTXNID +
           "," + OBJ.DonGia +
           "," + OBJ.DonGiaMuaNgoai +
           "," + OBJ.Discount +
           ",'" + OBJ.LoaiDiscount +
           "'," + OBJ.DonGiaSauDiscount +
           "," + OBJ.ThanhTien +
           //"," + OBJ.KetQua +
           ",'" + OBJ.SoLuongDat +
           "','" + OBJ.SoLuongXN +
           "'," + OBJ.VAT +
           //"," + OBJ.NCTXNID +
           ",CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "','" + OBJ.Locked +
           "')", CommandType.Text);
        }

        public void KHMau_CTXN_LABDAO_UPDATE(KHMau_CTXN_LAB OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_CTXN_LAB] SET " +
           "[KHMau_ID]                    = " + OBJ.KHMau_ID +
           "[PriceList_Details_LAB_Id]                    = " + OBJ.PriceList_Details_LAB_Id +
           ",[CTXNID]                    = " + OBJ.CTXNID +
           ",[DonGia]                    = " + OBJ.DonGia +
           ",[DonGiaMuaNgoai]                    = " + OBJ.DonGiaMuaNgoai +
           ",[Discount]                    = " + OBJ.Discount +
           ",[LoaiDiscount]                    = N'" + OBJ.LoaiDiscount + "'" +
           ",[DonGiaSauDiscount]                    = " + OBJ.DonGiaSauDiscount +
           ",[ThanhTien]                    = " + OBJ.ThanhTien +
           ",[SoLuongDat]                    = N'" + OBJ.SoLuongDat + "'" +
           ",[SoLuongXN]                    = N'" + OBJ.SoLuongXN + "'" +
           ",[VAT]                    = " + OBJ.VAT +
           //"[NCTXNID]                    = " + OBJ.NCTXNID +
           ",[CreatedDate]              = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy]                = N'" + OBJ.CreatedBy + "' " +
           ",[Note]                     = N'" + OBJ.Note + "' " +
           ",[Locked]                   = '" + OBJ.Locked + "' " +
           " WHERE [ID]                 =" + OBJ.ID, CommandType.Text);
        }

        public void KHMau_CTXN_LABDAO_DELETE(int ID)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_CTXN_LAB] " +
            " WHERE [ID]=" + ID, CommandType.Text);
        }

        public void KHMau_CTXN_LABDAO_DELETE_ByKHMau(string KHMau)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_CTXN_LAB] " +
            " WHERE [KHMau]='" + KHMau + "'", CommandType.Text);
        }

        public DataTable KHMau_CTXN_LABDAO_SELECT(int KHMau_ID)
        {
            return Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_CTXN_LAB] " +
                                                " WHERE [ID]=" + KHMau_ID, CommandType.Text);
        }

        public int MAX_KHMau_CTXN_LABDAO_ID()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT MAX(ID) as ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_CTXN_LAB]", CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());
        }
    }
}