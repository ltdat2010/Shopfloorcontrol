using Production.Class._LAB.RESULT;
using System;
using System.Data;

namespace Production.Class
{
    public class IBD_RESULT_Header_LABDAO
    {
        public int IBD_RESULT_Header_LABDAO_INSERT(IBD_RESULT_Header_LAB OBJ)
        {
            //if (Sql.ExecuteDataTable("SAP", "SELECT ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_Header_LAB] WHERE FilePath='" + OBJ.FilePath + "'", CommandType.Text).Rows[0]["ID"].ToString().Length == 0)
            //        return 0;
            //else
            //{
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_IBD_RESULT_Header_LAB] " +
               " ([FilePath] " +
               " ,[FileName] " +
               " ,[Date] " +
               " ,[Time] " +
               " ,[Case] " +
               " ,[KHMau_GiaoMau] " +
               " ,[Count] " +
               " ,[GMean] " +
               " ,[Mean] " +
               " ,[SD] " +
               " ,[CV] " +
               " ,[Min] " +
               " ,[Max] " +
               " ,[Tech] " +
               " ,[Neg] " +
               " ,[Pos] " +
               " ,[Sus] " +
               " ,[HUYETTHANHHOC_STD_VALUE_ID] " +
               " ,[CTXN_ID] " +
               " ,[CreatedDate] " +
               " ,[CreatedBy] " +
               " ,[Note] " +
               " ,[Locked]) " +
                " VALUES " +
               "(N'" + OBJ.FilePath +
               "',N'" + OBJ.FileName +
               "',Convert(datetime,N'" + OBJ.Date +
               "',103),N'" + OBJ.Time +
               "',N'" + OBJ.Case +
               "',N'" + OBJ.KHMau_GiaoMau +
               "'," + OBJ.Count +
               "," + OBJ.GMean +
               "," + OBJ.Mean +
               "," + OBJ.SD +
               "," + OBJ.CV +
               "," + OBJ.Min +
               "," + OBJ.Max +
               ",'" + OBJ.Tech +
               "'," + OBJ.Neg +
               "," + OBJ.Pos +
               "," + OBJ.Sus +
               "," + OBJ.HUYETTHANHHOC_STD_VALUE_ID +
               "," + OBJ.CTXN_ID +
               ",Convert(datetime,N'" + DateTime.Now +
               "',103),N'" + OBJ.CreatedBy +
               "',N'" + OBJ.Note +
               "','" + OBJ.Locked +
               "')", CommandType.Text);

            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_IBD_RESULT_Header_LAB] " +
                "WHERE FileName='" + OBJ.FileName + "' and CTXN_ID="+ OBJ.CTXN_ID, CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());
            //}
        }

        public void IBD_RESULT_Header_LABDAO_UPDATE(IBD_RESULT_Header_LAB OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_IBD_RESULT_Header_LAB] SET" +
           "[FilePath]          = N'" + OBJ.FilePath + "'" +
           ",[FileName]          = N'" + OBJ.FileName + "'" +
           ",[Date]             = N'" + OBJ.Date + "'" +
           ",[Time]              = N'" + OBJ.Time + "'" +
           ",[Case]      = N'" + OBJ.Case + "'" +
           ",[KHMau_GiaoMau]      = N'" + OBJ.KHMau_GiaoMau + "'" +
           ",[Count] = " + OBJ.Count +
           ",[GMean] = " + OBJ.GMean +
           ",[Mean] = " + OBJ.Mean +
           ",[SD] = " + OBJ.SD +
           ",[CV] = " + OBJ.CV +
           ",[Min] = " + OBJ.Min +
           ",[Max] = " + OBJ.Max +
           ",[Tech] = " + OBJ.Tech +
           ",[HUYETTHANHHOC_STD_VALUE_ID] = " + OBJ.HUYETTHANHHOC_STD_VALUE_ID +
           ",[CTXN_ID] = " + OBJ.CTXN_ID +
           ",[CreatedDate] = Convert(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           " WHERE [ID]='" + OBJ.ID + "'", CommandType.Text);
        }

        public void IBD_RESULT_Header_LABDAO_DELETE(int ID)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_IBD_RESULT_Header_LAB] " +
            " WHERE [ID]=" + ID, CommandType.Text);
        }

        public DataTable IBD_RESULT_Header_LABDAO_SELECT(string KHMau_GiaoMau, int CTXNID)
        {
            return Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_IBD_RESULT_Header_LAB] " +
                "WHERE KHMau_GiaoMau='" + KHMau_GiaoMau + "' and CTXN_ID=" + CTXNID, CommandType.Text);
        }

        public DataTable BaoCao_HuyetThanhHoc_IBD(string year, int CTXNID)
        {
            return Sql.ExecuteDataTable("SAP", " Select T1.ID as KHMau_CTXN_ID,T1.CTXNID,T1.SoLuongXN,T1.KHMau_GiaoMau,T1.ID,T1.SoPXN,T1.Month,T1.Year,S0.KHMau_GiaoMau,S0.CTXN_ID , " +
                                                " S0.Neg, S0.Pos, S0.Sus, T1.TenLoaiDV,T1.TenCoSoLayMau,T1.LOCCode,T1.ProvinceName,T1.TenCoSoGuiMau " +
                                                    " From " +
                                                        " (" +
                                                            " Select tbl_IBD_RESULT_Header_LAB.KHMau_GiaoMau, tbl_IBD_RESULT_Header_LAB.CTXN_ID, " +
                                                            " tbl_IBD_RESULT_Header_LAB.Neg, tbl_IBD_RESULT_Header_LAB.Pos, tbl_IBD_RESULT_Header_LAB.Sus " +
                                                            " from tbl_IBD_RESULT_Header_LAB " +
                                                            " Inner JOIN tbl_IBD_RESULT_Lines_LAB " +
                                                            " ON tbl_IBD_RESULT_Header_LAB.ID = tbl_IBD_RESULT_Lines_LAB.IBD_RESULT_Header_LAB_ID " +
                                                        " ) as S0 " +
                                                    " INNER JOIN " +
                                                        " (" +
                                                            " Select tbl_KHMau_CTXN_LAB.ID as KHMau_CTXN_ID,tbl_KHMau_CTXN_LAB.CTXNID,tbl_KHMau_CTXN_LAB.SoLuongXN,T0.KHMau_GiaoMau,T0.ID,T0.SoPXN,T0.Month,T0.Year,T0.TenLoaiDV,T0.TenCoSoLayMau,T0.LOCCode,T0.ProvinceName,T0.TenCoSoGuiMau  " +
                                                            " From tbl_KHMau_CTXN_LAB " +
                                                            " INNER JOIN " +
                                                                " (" +
                                                                    " select tbl_CUSTOMER_LAB.LOCCode,tbl_CUSTOMER_LAB.ProvinceName,tbl_PXN_Header.TenCoSoLayMau,tbl_PXN_Header.TenCoSoGuiMau,tbl_LoaiDV_LAB.TenLoaiDV, tbl_KHMau_LAB.KHMau_GiaoMau, tbl_KHMau_LAB.ID, tbl_PXN_Header.SoPXN, MONTH(tbl_PXN_Header.NgayNhanMau) as Month, YEAR(tbl_PXN_Header.NgayNhanMau) as Year " +
                                                                    " from tbl_PXN_Header " +
                                                                    " inner join tbl_KHMau_LAB " +
                                                                    " On  tbl_PXN_Header.SoPXN = tbl_KHMau_LAB.SoPXN " +
                                                                    " inner join tbl_LoaiDV_LAB " +
                                                                    " on tbl_KHMau_LAB.LoaiDVMauNuoc = tbl_LoaiDV_LAB.MaLoaiDV " +
                                                                    " inner join tbl_CUSTOMER_LAB " +
                                                                    " ON tbl_PXN_Header.MaCoSoLayMau = tbl_CUSTOMER_LAB.CUSTCODE " +
                                                                    " Where YEAR(tbl_PXN_Header.NgayNhanMau) = '" + year + "' " +
                                                                " ) as T0 " +
                                                            " ON tbl_KHMau_CTXN_LAB.KHMau_ID = T0.ID " +
                                                            " Where tbl_KHMau_CTXN_LAB.CTXNID = " + CTXNID +
                                                        " ) as T1 " +
                                                    " ON S0.KHMau_GiaoMau = T1.KHMau_GiaoMau and S0.CTXN_ID = T1.CTXNID " +
                                                    " GROUP BY T1.TenLoaiDV,T1.ID,T1.CTXNID,T1.SoLuongXN,T1.KHMau_GiaoMau,T1.ID,T1.SoPXN,T1.Month,T1.Year,S0.KHMau_GiaoMau,S0.CTXN_ID ,S0.Neg, S0.Pos, S0.Sus,T1.TenCoSoLayMau,T1.LOCCode,T1.ProvinceName,T1.TenCoSoGuiMau ", CommandType.Text);
        }
    }
}