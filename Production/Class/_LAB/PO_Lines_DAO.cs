using System;
using System.Data;

namespace Production.Class
{
    public class PO_Lines_DAO
    {
        public void PO_Lines_INSERT(PO_Lines OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_PO_Lines_LAB] " +
           " ([SoPO] " +
           " ,[MaCTXN] " +
           " ,[PriceList_Details_LAB_Id] " +
           " ,[KHMau_CTXN_LAB_Id] " +
           " ,[CTXN] " +
           " ,[UoM] " +
           " ,[SoLuongXN] " +
           " ,[DonGia] " +
           " ,[VAT] " +
           " ,[ThanhTien] " +
           " ,[GhiChu] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + OBJ.SoPO +
           "','" + OBJ.MaCTXN +
           "'," + OBJ.PriceList_Details_LAB_Id +
           "," + OBJ.KHMau_CTXN_LAB_Id +
           ",N'" + OBJ.CTXN +
           "',N'" + OBJ.UoM +
           "',N'" + OBJ.SoLuongXN +
           "'," + OBJ.DonGia +
           "," + OBJ.VAT +
           "," + OBJ.ThanhTien +
           ",N'" + OBJ.GhiChu +
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "','" + OBJ.Locked +
           "')", CommandType.Text);
            //XtraMessageBox.Show(CommandType.Text.ToString());
        }

        public void PO_Lines_UPDATE(PO_Lines OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PO_Lines_LAB] SET " +
           "[SoPO]                                          = N'" + OBJ.SoPO + "'" +
           "[MaCTXN]                                        = N'" + OBJ.MaCTXN + "'" +
           ",[PriceList_Details_LAB_Id]                     = " + OBJ.PriceList_Details_LAB_Id +
           ",[KHMau_CTXN_LAB_Id]                            = " + OBJ.KHMau_CTXN_LAB_Id +
           ",[CTXN]                                       = N'" + OBJ.CTXN + "'" +
           ",[UoM]                                          = N'" + OBJ.UoM + "'" +
           ",[SoLuongXN]                                          = N'" + OBJ.SoLuongXN + "'" +
           ",[DonGia]                                       = " + OBJ.DonGia +
           ",[VAT]                                          = " + OBJ.VAT +
           ",[ThanhTien]                                    = " + OBJ.ThanhTien +
           ",[GhiChu]                                       = N'" + OBJ.GhiChu + "'" +
           ",[CreatedDate]                                  = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy]                                    = N'" + OBJ.CreatedBy + "' " +
           ",[Note]                                         = N'" + OBJ.Note + "' " +
           ",[Locked]                                       = '" + OBJ.Locked + "' " +
           " WHERE [ID]                                     =" + OBJ.ID, CommandType.Text);
        }

        public void PO_Lines_DELETE(int ID)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_PO_Lines_LAB] " +
            " WHERE [ID]=" + ID, CommandType.Text);
        }

        public DataTable PO_Lines_SELECT(string SoPO)
        {
            return Sql.ExecuteDataTable("   SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_PO_Lines_LAB] " +
                                        " WHERE [SoPO]='" + SoPO + "'", CommandType.Text);
        }
    }
}