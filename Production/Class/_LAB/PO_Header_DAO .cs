using System;
using System.Data;

namespace Production.Class
{
    public class PO_Header_DAO
    {
        public void PO_Header_INSERT(PO_Header OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_PO_Header_LAB] " +
           " ([SoPO] " +
           " ,[VENDCode] " +
           " ,[VENDName] " +
           " ,[NgayLapPO] " +
           " ,[NgayGiaoHang] " +
           " ,[DiaChiGiaoHang] " +
           " ,[PaymentTerm] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Discount] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + OBJ.SoPO +
           "',N'" + OBJ.VENDCode +
           "',N'" + OBJ.VENDName +
           "',CONVERT(datetime,'" + OBJ.NgayLapPO +
           "',103),CONVERT(datetime,'" + OBJ.NgayGiaoHang +
           "',103),N'" + OBJ.DiaChiGiaoHang +
           "','" + OBJ.PaymentTerm +
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "',N'" + OBJ.Discount +
           "','" + OBJ.Locked +
           "')", CommandType.Text);
        }

        public void PO_Header_UPDATE(PO_Header OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PO_Header_LAB] SET " +
           "[SoPO]                                              = N'" + OBJ.SoPO + "'" +
           "[VENDCode]                                          = N'" + OBJ.VENDCode + "'" +
           ",[VENDName]                                         = N'" + OBJ.VENDName + "'" +
           ",[NgayLapPO]                                        = CONVERT(datetime,'" + OBJ.NgayLapPO + "',103)" +
           ",[NgayGiaoHang]                                     = CONVERT(datetime,'" + OBJ.NgayGiaoHang + "',103)" +
           ",[DiaChiGiaoHang]                                   = N'" + OBJ.DiaChiGiaoHang + "'" +
           ",[PaymentTerm]                                      = N'" + OBJ.PaymentTerm + "'" +
           ",[CreatedDate]                                      = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy]                                        = N'" + OBJ.CreatedBy + "' " +
           ",[Note]                                             = N'" + OBJ.Note + "' " +
           ",[Discount]                                             = N'" + OBJ.Discount + "' " +
           ",[Locked]                                           = '" + OBJ.Locked + "' " +
           " WHERE [ID]                                         = " + OBJ.ID, CommandType.Text);
        }

        public void PO_Header_DELETE(int ID)
        {
            Sql.ExecuteNonQuery("SAP", "   DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_PO_Header_LAB] " +
                                        " WHERE [ID]=" + ID, CommandType.Text);
        }

        public DataTable PO_Header_SELECT(string SoPO)
        {
            return Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_PO_Header_LAB] " +
                                                " WHERE [SoPO]='" + SoPO + "'", CommandType.Text);
        }

        public string Issued_SoPO()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT PONumber FROM [SYNC_NUTRICIEL].[dbo].[tbl_Info] WHERE ID = 1", CommandType.Text);
            return dt.Rows[0]["PONumber"].ToString();
        }

        public void Update_SoPO(string SoPO)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_Info] SET PONumber = '" + SoPO + "'", CommandType.Text);
        }

        public DataTable PO_List_Report(DateTime Stardate, DateTime Enddate)
        {
            return Sql.ExecuteDataTable("SAP", "Select  " +
                                                 " tbl_PO_Header_LAB.SoPO as [Số PO], " +
                                                 " tbl_PO_Header_LAB.NgayLapPO as [Ngày PO], " +
                                                 " tbl_PO_Header_LAB.VENDCode as [MÃ NHÀ CUNG CẤP], " +
                                                 " tbl_PO_Header_LAB.VENDName as [NHÀ CUNG CẤP], " +
                                                 " tbl_KHMau_CTXN_LAB.KHMau as [CODE MẪU], " +
                                                 " tbl_PXN_Header.TenCoSoLayMau as [TÊN KHÁCH HÀNG], " +
                                                 " tbl_ChiTieuXetNghiem_LAB.MaCTXN as [CODE XN], " +
                                                 " tbl_ChiTieuXetNghiem_LAB.CTXN as [TÊN XÉT NGHIỆM], " +
                                                 " tbl_PO_Lines_LAB.DonGia as [Đơn Giá chưa VAT], " +
                                                 " tbl_PO_Lines_LAB.VAT as [VAT %], " +
                                                 " tbl_PO_Lines_LAB.VAT as [Tiền thuế], " +
                                                 " tbl_PO_Lines_LAB.DonGia as [Thành tiền / mẫu], " +
                                                 " tbl_PO_Lines_LAB.ThanhTien as [Tổng tiền] ," +
                                                 " tbl_PO_Header_LAB.Discount as [Giảm giá] " +
                                                " From tbl_PO_Header_LAB " +
                                                " INNER JOIN " +
                                                " tbl_PO_Lines_LAB " +
                                                " ON " +
                                                " tbl_PO_Header_LAB.SoPO = tbl_PO_Lines_LAB.SoPO " +
                                                " INNER JOIN " +
                                                " tbl_KHMau_CTXN_LAB " +
                                                " ON " +
                                                " tbl_PO_Lines_LAB.KHMau_CTXN_LAB_Id = tbl_KHMau_CTXN_LAB.ID " +
                                                " INNER JOIN " +
                                                " tbl_ChiTieuXetNghiem_LAB " +
                                                " ON " +
                                                " tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID " +
                                                " INNER JOIN " +
                                                " tbl_KHMau_LAB " +
                                                " ON " +
                                                " tbl_KHMau_CTXN_LAB.KHMau = tbl_KHMau_LAB.KHMau " +
                                                " INNER JOIN " +
                                                " tbl_PXN_Header " +
                                                " ON " +
                                                " tbl_KHMau_LAB.SoPXN = tbl_PXN_Header.SoPXN " +
                                                " WHERE tbl_PO_Header_LAB.NgayLapPO >= CONVERT(datetime, '" + Stardate + "', 103) " +
                                                " AND tbl_PO_Header_LAB.NgayLapPO <= CONVERT(datetime, '" + Enddate + "', 103) " +
                                                " Order by tbl_PO_Header_LAB.SoPO DESC", CommandType.Text);
        }

        public DataTable PO_List_NotPaymented(DateTime Stardate, DateTime Enddate)
        {
            return Sql.ExecuteDataTable("SAP", "Select  " +
                                                " tbl_PO_Header_LAB.SoPO as [Số PO],  " +
                                                  " tbl_PO_Header_LAB.NgayLapPO as [Ngày PO],  " +
                                                  " tbl_PO_Header_LAB.VENDCode as [MÃ NHÀ CUNG CẤP],  " +
                                                  " tbl_PO_Header_LAB.VENDName as [NHÀ CUNG CẤP],  " +
                                                  " SUM(tbl_PO_Lines_LAB.ThanhTien) as [Tổng tiền],  " +
                                                  " tbl_PO_Header_LAB.Discount as [Giảm giá] " +
                                                 " From tbl_PO_Header_LAB  " +
                                                 " INNER JOIN  " +
                                                 " tbl_PO_Lines_LAB  " +
                                                 " ON  " +
                                                 " tbl_PO_Header_LAB.SoPO = tbl_PO_Lines_LAB.SoPO  " +
                                                 " INNER JOIN  " +
                                                 " tbl_KHMau_CTXN_LAB  " +
                                                 " ON  " +
                                                 " tbl_PO_Lines_LAB.KHMau_CTXN_LAB_Id = tbl_KHMau_CTXN_LAB.ID  " +
                                                 " INNER JOIN  " +
                                                 " tbl_ChiTieuXetNghiem_LAB  " +
                                                 " ON  " +
                                                 " tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID  " +
                                                 " INNER JOIN  " +
                                                 " tbl_KHMau_LAB  " +
                                                 " ON  " +
                                                 " tbl_KHMau_CTXN_LAB.KHMau = tbl_KHMau_LAB.KHMau  " +
                                                 " INNER JOIN  " +
                                                 " tbl_PXN_Header  " +
                                                 " ON  " +
                                                 " tbl_KHMau_LAB.SoPXN = tbl_PXN_Header.SoPXN  " +
                                                 " WHERE tbl_PO_Header_LAB.NgayLapPO >= CONVERT(datetime, '" + Stardate + "', 103)  " +
                                                 " AND tbl_PO_Header_LAB.NgayLapPO <= CONVERT(datetime, '" + Enddate + "', 103)  " +
                                                 " GROUP BY  " +
                                                  " tbl_PO_Header_LAB.SoPO,  " +
                                                  " tbl_PO_Header_LAB.NgayLapPO,  " +
                                                  " tbl_PO_Header_LAB.Discount,  " +
                                                  " tbl_PO_Header_LAB.VENDCode,  " +
                                                  " tbl_PO_Header_LAB.VENDName,  " +
                                                  " tbl_PO_Lines_LAB.DonGia  ", CommandType.Text);
        }
    }
}