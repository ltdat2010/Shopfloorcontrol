using System;
using System.Data;

namespace Production.Class
{
    internal class PRICELIST_DetailsDAO
    {
        public DataTable PRICELIST_DetailsDAO_List()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "Select ID , MaPL From [SYNC_NUTRICIEL].[dbo].tbl_PriceList_Details_LAB", CommandType.Text);
            return dt;
        }

        //public void TC_Insert(TieuChuan tc)
        //{
        //    Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_TieuChuan] " +
        //                                           "([TC] " +
        //                                           ",[TCDG]) " +
        //                                     "VALUES " +
        //                                           "('" + tc.TC +
        //                                           "','" + tc.TCDG + "'", CommandType.Text);
        //    //return dt;
        //}
        //public void PPT_Update(DataRow dr)
        //{
        //    Sql.ExecuteNonQuery("SAP",  "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PhuongPhapThu]" +
        //                                " SET [PPT] ='"+dr["PPT"].ToString() + "'"+
        //                                ",[PPTDG] = '" + dr["PPTDG"].ToString() + "' " +
        //                                "WHERE ID=" + int.Parse(dr["ID"].ToString()), CommandType.Text);
        //    //return dt;
        //}

        public void PRICELIST_DetailsDAO_INSERT(PRICELIST_Details OBJ)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_PriceList_Details_LAB] " +
           " ([CTXNID] " +
           " ,[PLID] " +
           " ,[UoM] " +
           " ,[SoLuong] " +
           " ,[DonGia] " +
           " ,[DonGiaMuaNgoai] " +
           " ,[DVMuaNgoaiCode] " +
           " ,[DVMuaNgoaiName] " +
           " ,[Giam] " +
           " ,[UoMGiam] " +
           " ,[VAT] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked] " +
           " ,[MuaNgoai]) " +
            " VALUES " +
           "(N'" + OBJ.CTXNID +
           "'," + OBJ.PLID +
           ",N'" + OBJ.UoM +
           "',N'" + OBJ.SoLuong +
           "',N'" + OBJ.DonGia +
           "',N'" + OBJ.DonGiaMuaNgoai +
           "',N'" + OBJ.DVMuaNgoaiCode +
           "',N'" + OBJ.DVMuaNgoaiName +
           "',N'" + OBJ.Giam +
           "',N'" + OBJ.UoMGiam +
           "',N'" + OBJ.VAT +
           "',Convert(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "','" + OBJ.Locked +
           "','" + OBJ.MuaNgoai +
           "')", CommandType.Text);
        }

        public void PRICELIST_DetailsDAO_UPDATE(PRICELIST_Details OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PriceList_Details_LAB] SET" +
           "[CTXNID] = N'" + OBJ.CTXNID + "'" +
           ",[PLID] = " + OBJ.PLID +
           ",[UoM] = N'" + OBJ.UoM + "'" +
           ",[SoLuong] = N'" + OBJ.SoLuong + "'" +
           ",[DonGia] = N'" + OBJ.DonGia + "'" +
           ",[DonGiaMuaNgoai] = N'" + OBJ.DonGiaMuaNgoai + "'" +
           ",[DVMuaNgoaiCode] = N'" + OBJ.DVMuaNgoaiCode + "'" +
           ",[DVMuaNgoaiName] = N'" + OBJ.DVMuaNgoaiName + "'" +
           ",[Giam] = N'" + OBJ.Giam + "'" +
           ",[UoMGiam] = N'" + OBJ.UoMGiam + "'" +
           ",[VAT] = N'" + OBJ.VAT + "'" +
           ",[CreatedDate] = Convert(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           ",[MuaNgoai] = '" + OBJ.MuaNgoai + "' " +
           " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public void PRICELIST_DetailsDAO_DELETE(PRICELIST_Details OBJ)
        {
            // Cap nhat 2019-07-06
            // Khong cho xoa ma chi set Locked = '1'
            // De luu history price list detail
            //Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_PriceList_Details_LAB] " +
            //" WHERE [ID]=" + OBJ.ID, CommandType.Text);
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PriceList_Details_LAB] SET" +
           "[CreatedDate] = Convert(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Locked] = '1' " +
           " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public DataTable PRICELIST_History(int PLID)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "  SELECT [V_PriceList_History].[ID] " +
                        " ,[V_PriceList_History].[CreatedDate] " +
                        " ,[V_PriceList_History].[CreatedBy] " +
                        " ,[V_PriceList_History].[Locked] " +
                        " ,[V_PriceList_History].[PLID] " +
                        " ,[V_PriceList_History].[CTXNID] " +
                        " ,[tbl_ChiTieuXetNghiem_LAB].[CTXN] " +
                        " ,[V_PriceList_History].[UoM] " +
                        " ,[V_PriceList_History].[SoLuong] " +
                        " ,[V_PriceList_History].[DonGia] " +
                        " ,[V_PriceList_History].[Giam] " +
                        " ,[V_PriceList_History].[UoMGiam] " +
                        " ,[V_PriceList_History].[Note] " +
                        " ,[V_PriceList_History].[VAT] " +
                        " ,[V_PriceList_History].[DonGiaMuaNgoai] " +
                        " ,[V_PriceList_History].[DVMuaNgoaiCode] " +
                        " ,[V_PriceList_History].[DVMuaNgoaiName] " +
                        " ,[V_PriceList_History].[MuaNgoai] " +
                        " FROM[SYNC_NUTRICIEL].[dbo].[V_PriceList_History] " +
                        " INNER JOIN tbl_ChiTieuXetNghiem_LAB " +
                        " ON[V_PriceList_History].CTXNID = tbl_ChiTieuXetNghiem_LAB.ID " +
                        " WHERE [PLID]=" + PLID +
                        " Order by [V_PriceList_History].[CTXNID],[V_PriceList_History].[CreatedDate] DESC", CommandType.Text);
            return dt;
        }

        public int PRICELIST_INDENTITY_SELECT()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", " SELECT IDENT_CURRENT( 'tbl_PriceList_Details_LAB' ) + 1 as IDENT ", CommandType.Text);
            return int.Parse(dt.Rows[0]["IDENT"].ToString());
        }
    }
}