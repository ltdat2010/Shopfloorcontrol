using System;
using System.Data;

namespace Production.Class
{
    public class CHITIEUXETNGHIEMDAO
    {
        public void CHITIEUXETNGHIEM_INSERT(CHITIEUXETNGHIEM CTXN)
        {
            
        Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_ChiTieuXetNghiem_LAB] " +
           " ([CTXN] " +
           " ,[MaCTXN] " +
           " ,[CTXNDG] " +
           " ,[CTXNDGTA] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Locked] " +
           //" ,[MuaNgoai] " +
           " ,[NCTXNID] " +
           " ,[PPXNID] " +
           " ,[MinValue] " +
           " ,[MaxValue] " +
           " ,[UnitValue] " +
           " ,[Days] " +
           " ,[Acronym] " +
           " ,[UoM] " +
           " ,[Note] )" +
     " VALUES " +
           "(N'" + CTXN.CTXN +
           "',N'" + CTXN.MaCTXN +
           "',N'" + CTXN.CTXNDG +
           "',N'" + CTXN.CTXNDGTA +
           "',Convert(datetime,'" + DateTime.Today +
           "',103),'" + CTXN.CreatedBy +
           "','" + CTXN.Locked +
           //"','" + CTXN.MuaNgoai +
           "'," + CTXN.NCTXNID +
           "," + CTXN.PPXNID +      
           ",N'" + CTXN.MinValue +
           "',N'" + CTXN.MaxValue +
           "',N'" + CTXN.UnitValue +
           "',N'" + CTXN.Days +
           "',N'" + CTXN.Acronym +
           "',N'" + CTXN.UoM +
           "',N'" + CTXN.Note +
            "')", CommandType.Text);
        }

        public void CHITIEUXETNGHIEM_UPDATE(CHITIEUXETNGHIEM CTXN)
        {		            
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_ChiTieuXetNghiem_LAB] SET" +
           "[CTXN]                      = N'" + CTXN.CTXN + "'" +
           ",[MaCTXN]                   = N'" + CTXN.MaCTXN + "' " +
           //",[LOCCode] = '" + MINStart + "' " +
           ",[CreatedDate]              = Convert(datetime,'" + DateTime.Today + "',103)" +
           ",[CreatedBy]                = N'" + CTXN.CreatedBy + "' " +
           ",[Locked]                   = '" + CTXN.Locked + "' " +
           //",[MuaNgoai]                 = '" + CTXN.MuaNgoai + "' " +
           ",[CTXNDG]                   = N'" + CTXN.CTXNDG + "' " +
           ",[CTXNDGTA]                 = N'" + CTXN.CTXNDGTA + "' " +
           ",[NCTXNID]                  = " + CTXN.NCTXNID + 
           ",[PPXNID]                   = " + CTXN.PPXNID + 
           ",[Note]                     = N'" + CTXN.Note + "' " +
           ",[MinValue]                 = N'" + CTXN.MinValue + "' " +
           ",[MaxValue]                 = '" + CTXN.MaxValue + "' " +
           ",[UnitValue]                = N'" + CTXN.UnitValue + "' " +
           ",[Days]                     = N'" + CTXN.Days + "' " +
           ",[Acronym]                     = N'" + CTXN.Acronym + "' " +
           ",[UoM]                     = N'" + CTXN.UoM + "' " +
           " WHERE [ID]                 ='" + CTXN.ID + "'", CommandType.Text);
        }

        public void CHITIEUXETNGHIEM_DELETE(CHITIEUXETNGHIEM CTXN)
        {
           Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_ChiTieuXetNghiem_LAB] " +
           " WHERE [ID]='" + CTXN.ID + "'", CommandType.Text);
        }

        //public DataTable CUSTOMER_LIST_SAPB1()
        //{
        //    DataTable dt = new DataTable();
        //    dt = Sql.ExecuteDataTable("SAP", "Select CardCode,CardName,Address from [VIPHAVET].[dbo].[OCRD] where CardType ='S' ", CommandType.Text);
        //    return dt;
        //}

        public DataRow TINHGIA_CTXN(DateTime NgayLapPXN, int CTXNID)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", " SELECT " +
                                            "tbl_PXN_Details.ID, " +
                                            "tbl_PXN_Details.SoPXN, " +
                                            "tbl_PXN_Details.CTXNID, " +
                                            "tbl_PXN_Details.SLMau, " +
                                            "tbl_PXN_Details.GhiChu, " +
                                            "tbl_PXN_Details.CreatedDate, " +
                                            "tbl_PXN_Details.CreatedBy, " +
                                            "tbl_PXN_Details.Note, " +
                                            "tbl_PXN_Details.Locked, " +
                                            "tbl_ChiTieuXetNghiem_LAB.CTXN, " +
                                            "tbl_ChiTieuXetNghiem_LAB.MaCTXN, " +
                                            "tbl_ChiTieuXetNghiem_LAB.Days, " +
                                            "--tbl_PhuongPhapXetNghiem_LAB.PPXN, " +
                                            "--tbl_NhomChiTieuXetNghiem_LAB.NCTXN, " +
                                            "--tbl_PriceList_Details_LAB.SoLuong, " +
                                            "T.DonGia, " +
                                            "T.VAT, " +
                                            "T.SoLuong, " +
                                            "T.Giam, " +
                                            "T.UoMGiam, " +
                                            "T.UoM " +
                                            "FROM       tbl_PXN_Details " +
                                                        "LEFT JOIN tbl_ChiTieuXetNghiem_LAB " +
                                                       "ON tbl_PXN_Details.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID " +
                                                       "INNER JOIN( " +
                                                                    "SELECT tbl_PriceList_Details_LAB.DonGia, " +
                                                                    "tbl_PriceList_Details_LAB.VAT, " +
                                                                    "tbl_PriceList_Details_LAB.SoLuong, " +
                                                                    "tbl_PriceList_Details_LAB.Giam, " +
                                                                    "tbl_PriceList_Details_LAB.UoM, " +
                                                                    "tbl_PriceList_Details_LAB.UoMGiam, " +
                                                                    "tbl_PriceList_Details_LAB.CTXNID " +
                                                                    "FROM tbl_PriceList_Details_LAB " +
                                                                    "INNER JOIN tbl_PriceList_LAB " +
                                                                    "ON tbl_PriceList_Details_LAB.PLID = tbl_PriceList_LAB.ID " +
                                                                    "WHERE '"+ NgayLapPXN + "' IN(tbl_PriceList_LAB.EffDate, tbl_PriceList_LAB.ExpDate) and tbl_PXN_Details.CTXNID =" + CTXNID +
                                                                    ") as T " +
                                                                    "ON  tbl_PXN_Details.CTXNID = T.CTXNID ", CommandType.Text);
            return dt.Rows[0] ;
        }

        public int CTXN_CTXNID_SELECT(string acr)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", " SELECT ID " +                                            
                                            "FROM       tbl_ChiTieuXetNghiem_LAB " +                                                       
                                                                    "WHERE Acronym ='"+acr+"' ", CommandType.Text);
            return (int)dt.Rows[0]["ID"];
        }

        public int CTXN_INDENTITY_SELECT()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", " SELECT IDENT_CURRENT( 'tbl_ChiTieuXetNghiem_LAB' ) + 1 as IDENT " , CommandType.Text);
            return int.Parse(dt.Rows[0]["IDENT"].ToString());
        }
    }

}


