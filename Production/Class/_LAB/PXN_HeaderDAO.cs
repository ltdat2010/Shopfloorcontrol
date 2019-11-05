using System;
using System.Data;

namespace Production.Class
{
    public class PXN_HeaderDAO
    {
        public void PXN_HeaderDAO_INSERT(PXN_Header OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header] " +
           " ([SoPXN] " +
           " ,[PXNDescription] " +
           " ,[CoSoGuiMau] " +
           " ,[MaCoSoGuiMau] " +
           " ,[TenCoSoGuiMau] " +
           " ,[DCCoSoGuiMau] " +
           " ,[PhoneCoSoGuiMau] " +
           " ,[FaxCoSoGuiMau] " +
           " ,[EmailCoSoGuiMau] " +
           " ,[MSTCoSoGuiMau] " +
           " ,[CoSoLayMau] " +
           " ,[MaCoSoLayMau] " +
           " ,[TenCoSoLayMau] " +
           " ,[DCCoSoLayMau] " +
           " ,[PhoneCoSoLayMau] " +
           " ,[FaxCoSoLayMau] " +
           " ,[EmailCoSoLayMau] " +
           " ,[SendMail] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[NgayNhanMau] " +
           " ,[NgayDuKienTra] " +
           " ,[KHMau] " +
           //" ,[Khac] " +
           " ,[PTNThucHien] " +
           " ,[LoaiXN] " +
           " ,[NgonNgu] " +
           " ,[DichTeDan] " +
           " ,[CUSTCODE_ID] " +
           " ,[DonViXuatHoaDon_ID] " +
           " ,[EMPCode_ID] " +
           " ,[Locked]  " +
           " ,[DaXuatHoaDon]  " +
           " ,[NgayXuatHoaDon]  " +
           " ,[SoHoaDon]  " +
           " ,[DaThuTien]  " +
           " ,[NgayThuTien]  " +
           " ,[SoTienDaThu]  " +
           " ,[SoTienHoaDon]  " +
           " ,[TraTruoc]  " +
           " ,[NgayTraTruoc]  " +
           " ,[SoTienTraTruoc]  " +
           " ,[NoiDungHoaDon]  " +
           " ,[NoiDungTraTruoc]  " +
           " ,[GiaoMau]  " +
          " ,[NgayGiaoMau]  " +
           ") " +
     " VALUES " +
           "(N'" + OBJ.SoPXN +
           "',N'" + OBJ.PXNDescription +
           "',N'" + OBJ.CoSoGuiMau +
           "',N'" + OBJ.MaCoSoGuiMau +
           "',N'" + OBJ.TenCoSoGuiMau +
           "',N'" + OBJ.DCCoSoGuiMau +
           "',N'" + OBJ.PhoneCoSoGuiMau +
           "',N'" + OBJ.FaxCoSoGuiMau +
           "',N'" + OBJ.EmailCoSoGuiMau +
           "',N'" + OBJ.MSTCoSoGuiMau +
           "',N'" + OBJ.CoSoLayMau +
           "',N'" + OBJ.MaCoSoLayMau +
           "',N'" + OBJ.TenCoSoLayMau +
           "',N'" + OBJ.DCCoSoLayMau +
           "',N'" + OBJ.PhoneCoSoLayMau +
           "',N'" + OBJ.FaxCoSoLayMau +
           "',N'" + OBJ.EmailCoSoLayMau +
           "',N'" + OBJ.SendMail +
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "',CONVERT(datetime,'" + OBJ.NgayNhanMau +
           "',103),CONVERT(datetime,'" + OBJ.NgayDuKienTra +
           "',103),N'" + OBJ.KHMau +
           //"',N'" + OBJ.Khac +
           "',N'" + OBJ.PTNThucHien +
           "',N'" + OBJ.LoaiXN +
           "',N'" + OBJ.NgonNgu +
           "',N'" + OBJ.DichTeDan +
           "'," + OBJ.CUSTCODE_ID +
           "," + OBJ.DonViXuatHoaDon_ID +
           "," + OBJ.EMPCode_ID +
           ",'" + OBJ.Locked +
           "',N'" + OBJ.DaXuatHoaDon +
           "',N'" + OBJ.NgayXuatHoaDon +
           "',N'" + OBJ.SoHoaDon +
           "',N'" + OBJ.DaThuTien +
           "',N'" + OBJ.NgayThuTien +
           "'," + OBJ.SoTienDaThu +
           "," + OBJ.SoTienHoaDon +
           ",N'" + OBJ.TraTruoc +
           "',N'" + OBJ.NgayTraTruoc +
           "'," + OBJ.SoTienTraTruoc +
           ",N'" + OBJ.NoiDungHoaDon +
           "',N'" + OBJ.NoiDungTraTruoc +
           "',N'" + false +
           "',CONVERT(datetime,'01/01/2019',103)" +
           ")", CommandType.Text);
        }

        public void PXN_HeaderDAO_UPDATE(PXN_Header OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header] SET " +
           " [SoPXN]                = N'" + OBJ.SoPXN + "'" +
           ",[PXNDescription]       = N'" + OBJ.PXNDescription + "'" +
           ",[CoSoGuiMau]           = N'" + OBJ.CoSoGuiMau + "'" +
           ",[MaCoSoGuiMau]           = N'" + OBJ.MaCoSoGuiMau + "'" +
           ",[TenCoSoGuiMau]        = N'" + OBJ.TenCoSoGuiMau + "'" +
           ",[DCCoSoGuiMau]         = N'" + OBJ.DCCoSoGuiMau + "'" +
           ",[FaxCoSoGuiMau]        = N'" + OBJ.FaxCoSoGuiMau + "'" +
           ",[EmailCoSoGuiMau]      = N'" + OBJ.EmailCoSoGuiMau + "'" +
           ",[MSTCoSoGuiMau]        = N'" + OBJ.MSTCoSoGuiMau + "'" +
           ",[CoSoLayMau]           = N'" + OBJ.CoSoLayMau + "'" +
           ",[DonViXuatHoaDon_ID]   = " + OBJ.DonViXuatHoaDon_ID + 
           ",[MaCoSoLayMau]         = N'" + OBJ.MaCoSoLayMau + "'" +
           ",[TenCoSoLayMau]        = N'" + OBJ.TenCoSoLayMau + "'" +
           ",[DCCoSoLayMau]         = N'" + OBJ.DCCoSoLayMau + "'" +
           ",[PhoneCoSoLayMau]      = N'" + OBJ.PhoneCoSoLayMau + "'" +
           ",[FaxCoSoLayMau]        = N'" + OBJ.FaxCoSoLayMau + "'" +
           ",[EmailCoSoLayMau]      = N'" + OBJ.EmailCoSoLayMau + "'" +
           ",[SendMail]             = N'" + OBJ.SendMail + "'" +
           ",[CreatedDate]          = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy]            = N'" + OBJ.CreatedBy + "' " +
           ",[Note]                 = N'" + OBJ.Note + "' " +
           ",[NgayNhanMau]          = CONVERT(datetime,'" + OBJ.NgayNhanMau + "',103)" +
           ",[NgayDuKienTra]        = CONVERT(datetime,'" + OBJ.NgayDuKienTra + "',103)" +
           ",[KHMau]                = N'" + OBJ.KHMau + "' " +
           //",[Khac]                 = N'" + OBJ.Khac + "' " +
           ",[PTNThucHien]          = N'" + OBJ.PTNThucHien + "' " +
           ",[LoaiXN]               = N'" + OBJ.LoaiXN + "' " +
           ",[NgonNgu]               = N'" + OBJ.NgonNgu + "' " +
           ",[DichTeDan]               = N'" + OBJ.DichTeDan + "' " +
           ",[CUSTCODE_ID]               = N'" + OBJ.CUSTCODE_ID + "' " +
           ",[EMPCode_ID]               = N'" + OBJ.EMPCode_ID + "' " +
           ",[Locked]               = N'" + OBJ.Locked + "' " +
           ",[DaXuatHoaDon]               = N'" + OBJ.DaXuatHoaDon + "' " +
           ",[NgayXuatHoaDon]               = CONVERT(datetime,'" + OBJ.NgayXuatHoaDon + "',103)" +
           ",[SoHoaDon]               = N'" + OBJ.SoHoaDon + "' " +
           ",[DaThuTien]               = N'" + OBJ.DaThuTien + "' " +
           ",[NgayThuTien]               = CONVERT(datetime,'" + OBJ.NgayThuTien + "',103)" +
           ",[SoTienDaThu]               = " + OBJ.SoTienDaThu +
           ",[SoTienHoaDon]               = " + OBJ.SoTienHoaDon +
           ",[TraTruoc]               = N'" + OBJ.TraTruoc + "' " +
           ",[NgayTraTruoc]               = CONVERT(datetime,'" + OBJ.NgayTraTruoc + "',103)" +
           ",[SoTienTraTruoc]               = " + OBJ.SoTienTraTruoc +
           ",[NoiDungHoaDon]               = N'" + OBJ.NoiDungHoaDon + "' " +
           ",[NoiDungTraTruoc]               = N'" + OBJ.NoiDungTraTruoc + "' " +
           ",[NgayGiaoMau]        = CONVERT(datetime,'" + OBJ.NgayGiaoMau + "',103)" +
           ",[GiaoMau]               = N'" + OBJ.GiaoMau + "' " +
           ",[NguoiGiaoMau]               = N'" + OBJ.NguoiGiaoMau + "' " +
           " WHERE [ID]             =" + OBJ.ID, CommandType.Text);
        }

        public DataTable PXN_Header_SELECT()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header] Order By CreatedDate DESC", CommandType.Text);
            return dt;
        }

        public void PXN_HeaderDAO_UPDATE_MaCoSoLayMau(string CUSTCODE_Old,string CUSTCODE_New )
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header] SET " +           
           ",[MaCoSoLayMau]           = N'" + CUSTCODE_New + "'" +
           " WHERE [MaCoSoLayMau]             =" + CUSTCODE_Old, CommandType.Text);
        }

        public void PXN_HeaderDAO_UPDATE_SendMail(int ID, string SendMail)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header] SET " +
           "[SendMail]             = N'" + SendMail + "'" +
           " WHERE [ID]             =" + ID, CommandType.Text);
        }

        public void PXN_HeaderDAO_UPDATE_NgayCoKetQua(int ID, DateTime NgayCoKetQua, bool CoKetQua)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header] SET " +
           "[NgayCoKetQua]        = CONVERT(datetime,'" + NgayCoKetQua + "',103)" +
           ",[CoKetQua]               = N'" + CoKetQua + "' " +
           " WHERE [ID]             =" + ID, CommandType.Text);
        }

        public void PXN_HeaderDAO_UPDATE_NgayTraKetQua(int ID, DateTime NgayTraKetQua, bool TraKetQua)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header] SET " +
           "[NgayTraKetQua]        = CONVERT(datetime,'" + NgayTraKetQua + "',103)" +
           ",[TraKetQua]               = N'" + TraKetQua + "' " +
           " WHERE [ID]             =" + ID, CommandType.Text);
        }

        public void PXN_HeaderDAO_UPDATE_NgayGiaoMau(int ID, DateTime NgayGiaoMau, bool GiaoMau, string NguoiGiaoMau)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header] SET " +
           "[NgayGiaoMau]        = CONVERT(datetime,'" + NgayGiaoMau + "',103)" +
           ",[GiaoMau]               = N'" + GiaoMau + "' " +
           ",[NguoiGiaoMau]               = N'" + NguoiGiaoMau + "' " +
           " WHERE [ID]             =" + ID, CommandType.Text);
        }

        public void PXN_HeaderDAO_DELETE(PXN_Header OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header] " +
            " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public DataTable PXN_HeaderDAO_SELECT(string SoPXN)
        {
            return Sql.ExecuteDataTable("SAP", " SELECT *    " +
                                                " FROM[SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header]  " +
                                                " LEFT JOIN tbl_User ON[tbl_PXN_Header].CreatedBy = tbl_User.UserName  " +
                                                " INNER JOIN tbl_CUSTOMER_LAB  " +
                                                " ON[SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header].CUSTCODE_ID = tbl_CUSTOMER_LAB.ID  " +
                                                " INNER JOIN tbl_EMPLOYEE_LAB ON [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header].EMPCode_ID = tbl_EMPLOYEE_LAB.Id " +
                                                " WHERE [SoPXN]='" + SoPXN + "'", CommandType.Text);
        }

        public int MAX_PXN_HeaderDAO_ID()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT MAX(ID) as ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header]", CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());
        }

        public int PXN_HeaderDAO_ID_bySoPXN(string SoPXN)
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header] WHERE SoPXN ='" + SoPXN + "'", CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());
        }

        public DataTable BaoCaoPXN_Nhan(DateTime Stardate, DateTime Enddate)
        {
            DataTable dt = Sql.ExecuteDataTable("SAP",
                        " SELECT        tbl_PXN_Header.*, tbl_KHMau_LAB.*, tbl_KHMau_CTXN_LAB.* " +
                         " FROM            tbl_PXN_Header INNER JOIN " +
                         " tbl_KHMau_LAB ON tbl_PXN_Header.SoPXN = tbl_KHMau_LAB.SoPXN INNER JOIN " +
                         " tbl_KHMau_CTXN_LAB ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau " +
                        " INNER JOIN tbl_ChiTieuXetNghiem_LAB " +
                        " ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID " +
                        " INNER JOIN tbl_NhomChiTieuXetNghiem_LAB " +
                        " ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID " +
                         " WHERE tbl_PXN_Header.NgayNhanMau >= CONVERT(datetime, '" + Stardate + "', 103) " +
                         " AND tbl_PXN_Header.NgayNhanMau <= CONVERT(datetime, '" + Enddate + "', 103)"
                         , CommandType.Text);
            return dt;
        }

        public DataTable BaoCaoPXN_Nhan_Export2Excel(DateTime Stardate, DateTime Enddate)
        {
            DataTable dt = Sql.ExecuteDataTable("SAP",
                        " SELECT        tbl_PXN_Header.ID, " +
                            " tbl_PXN_Header.NgayNhanMau, " +
                            " tbl_PXN_Header.NgayDuKienTra, " +
                            " tbl_PXN_Header.NgayCoKetQua, " +
                            " tbl_PXN_Header.NgayTraKetQua, " +
                            " tbl_PXN_Header.PTNThucHien, " +
                            " tbl_PXN_Header.SoPXN, " +
                            " tbl_KHMau_LAB.KHMau, " +
                            " tbl_CUSTOMER_LAB.CUSTNAME, " +
                            " tbl_CUSTOMER_LAB.CUSTADDRESS, " +
                            " tbl_EMPLOYEE_LAB.EMPName, " +
                            " tbl_LOCATION_LAB.LOCName, " +
                            " tbl_CUSTOMERTYPE_LAB.CUSTTYPEName, " +
                            " tbl_ChiTieuXetNghiem_LAB.MaCTXN, " +
                            " tbl_ChiTieuXetNghiem_LAB.CTXN, " +
                            " tbl_KHMau_LAB.DonViKHMau, " +
                            " tbl_KHMau_CTXN_LAB.SoLuongXN, " +
                            " tbl_KHMau_CTXN_LAB.DonGia, " +
                            " tbl_KHMau_CTXN_LAB.VAT, " +
                            " tbl_KHMau_CTXN_LAB.ThanhTien, " +
                            " tbl_KHMau_CTXN_LAB.DonGiaMuaNgoai " +
                            " FROM            tbl_PXN_Header " +
                            " INNER JOIN  tbl_KHMau_LAB " +
                            " ON tbl_PXN_Header.SoPXN = tbl_KHMau_LAB.SoPXN " +
                            " INNER JOIN tbl_KHMau_CTXN_LAB " +
                            " ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau " +
                            " INNER JOIN tbl_ChiTieuXetNghiem_LAB " +
                            " ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID " +
                            " INNER JOIN tbl_NhomChiTieuXetNghiem_LAB " +
                            " ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID " +
                            " INNER JOIN tbl_CUSTOMER_LAB " +
                            " ON tbl_PXN_Header.CUSTCODE_Id = tbl_CUSTOMER_LAB.Id " +
                            " INNER JOIN tbl_LOCATION_LAB " +
                            " ON tbl_CUSTOMER_LAB.LOCCode = tbl_LOCATION_LAB.LOCCode " +
                            " INNER JOIN tbl_EMPLOYEE_LAB " +
                            " ON tbl_PXN_Header.EMPCode_Id = tbl_EMPLOYEE_LAB.Id " +
                            " INNER JOIN tbl_CUSTOMERTYPE_LAB " +
                            " ON tbl_CUSTOMER_LAB.CUSTTYPECode = tbl_CUSTOMERTYPE_LAB.CUSTTYPECode   " +
                            " WHERE tbl_PXN_Header.NgayNhanMau >= CONVERT(datetime, '" + Stardate + "', 103) " +
                            " AND tbl_PXN_Header.NgayNhanMau <= CONVERT(datetime, '" + Enddate + "', 103)"
                         , CommandType.Text);
            return dt;
        }

        public DataTable BaoCaoPXN_ChuaTra(DateTime Stardate, DateTime Enddate)
        {
            DataTable dt = Sql.ExecuteDataTable("SAP",
                        " SELECT        tbl_PXN_Header.*, tbl_KHMau_LAB.*, tbl_KHMau_CTXN_LAB.* " +
                         " FROM            tbl_PXN_Header INNER JOIN " +
                         " tbl_KHMau_LAB ON tbl_PXN_Header.SoPXN = tbl_KHMau_LAB.SoPXN INNER JOIN " +
                         " tbl_KHMau_CTXN_LAB ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau " +
                         " INNER JOIN tbl_ChiTieuXetNghiem_LAB " +
                        " ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID " +
                        " INNER JOIN tbl_NhomChiTieuXetNghiem_LAB " +
                        " ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID " +
                         " WHERE tbl_PXN_Header.NgayNhanMau >= CONVERT(datetime, '" + Stardate + "', 103) " +
                         " AND tbl_PXN_Header.NgayNhanMau <= CONVERT(datetime, '" + Enddate + "', 103)" +
                         " AND ( tbl_PXN_Header.NgayTraKetQua > CONVERT(datetime, '" + Enddate + "', 103) " +
                         " OR tbl_PXN_Header.NgayTraKetQua = '01-01-2019')"
                         , CommandType.Text);
            return dt;
        }

        public DataTable BaoCaoPXN_ChuaTra_Export2Excel(DateTime Stardate, DateTime Enddate)
        {
            DataTable dt = Sql.ExecuteDataTable("SAP",
                        " SELECT        tbl_PXN_Header.ID, " +
                            " tbl_PXN_Header.NgayNhanMau, " +
                            " tbl_PXN_Header.NgayDuKienTra, " +
                            " tbl_PXN_Header.NgayCoKetQua, " +
                            " tbl_PXN_Header.NgayTraKetQua, " +
                            " tbl_PXN_Header.PTNThucHien, " +
                            " tbl_PXN_Header.SoPXN, " +
                            " tbl_KHMau_LAB.KHMau, " +
                            " tbl_CUSTOMER_LAB.CUSTNAME, " +
                            " tbl_CUSTOMER_LAB.CUSTADDRESS, " +
                            " tbl_EMPLOYEE_LAB.EMPName, " +
                            " tbl_LOCATION_LAB.LOCName, " +
                            " tbl_CUSTOMERTYPE_LAB.CUSTTYPEName, " +
                            " tbl_ChiTieuXetNghiem_LAB.MaCTXN, " +
                            " tbl_ChiTieuXetNghiem_LAB.CTXN, " +
                            " tbl_KHMau_LAB.DonViKHMau, " +
                            " tbl_KHMau_CTXN_LAB.SoLuongXN, " +
                            " tbl_KHMau_CTXN_LAB.DonGia, " +
                            " tbl_KHMau_CTXN_LAB.VAT, " +
                            " tbl_KHMau_CTXN_LAB.ThanhTien, " +
                            " tbl_KHMau_CTXN_LAB.DonGiaMuaNgoai " +
                            " FROM            tbl_PXN_Header " +
                            " INNER JOIN  tbl_KHMau_LAB " +
                            " ON tbl_PXN_Header.SoPXN = tbl_KHMau_LAB.SoPXN " +
                            " INNER JOIN tbl_KHMau_CTXN_LAB " +
                            " ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau " +
                            " INNER JOIN tbl_ChiTieuXetNghiem_LAB " +
                            " ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID " +
                            " INNER JOIN tbl_NhomChiTieuXetNghiem_LAB " +
                            " ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID " +
                            " INNER JOIN tbl_CUSTOMER_LAB " +
                            " ON tbl_PXN_Header.CUSTCODE_Id = tbl_CUSTOMER_LAB.Id " +
                            " INNER JOIN tbl_LOCATION_LAB " +
                            " ON tbl_CUSTOMER_LAB.LOCCode = tbl_LOCATION_LAB.LOCCode " +
                            " INNER JOIN tbl_EMPLOYEE_LAB " +
                            " ON tbl_PXN_Header.EMPCode_Id = tbl_EMPLOYEE_LAB.Id " +
                            " INNER JOIN tbl_CUSTOMERTYPE_LAB " +
                            " ON tbl_CUSTOMER_LAB.CUSTTYPECode = tbl_CUSTOMERTYPE_LAB.CUSTTYPECode   " +
                         " WHERE tbl_PXN_Header.NgayNhanMau >= CONVERT(datetime, '" + Stardate + "', 103) " +
                         " AND tbl_PXN_Header.NgayNhanMau <= CONVERT(datetime, '" + Enddate + "', 103)" +
                         " AND ( tbl_PXN_Header.NgayTraKetQua > CONVERT(datetime, '" + Enddate + "', 103) " +
                         " OR tbl_PXN_Header.NgayTraKetQua = '01-01-2019')"
                         , CommandType.Text);
            return dt;
        }

        public DataTable BaoCaoPXN_DaTra(DateTime Stardate, DateTime Enddate)
        {
            DataTable dt = Sql.ExecuteDataTable("SAP",
                        " SELECT        tbl_PXN_Header.*, tbl_KHMau_LAB.*, tbl_KHMau_CTXN_LAB.* " +
                         " FROM            tbl_PXN_Header INNER JOIN " +
                         " tbl_KHMau_LAB ON tbl_PXN_Header.SoPXN = tbl_KHMau_LAB.SoPXN INNER JOIN " +
                         " tbl_KHMau_CTXN_LAB ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau " +
                         " INNER JOIN tbl_ChiTieuXetNghiem_LAB " +
                        " ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID " +
                        " INNER JOIN tbl_NhomChiTieuXetNghiem_LAB " +
                        " ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID " +
                         " WHERE tbl_PXN_Header.NgayNhanMau >= CONVERT(datetime, '" + Stardate + "', 103) " +
                         " AND tbl_PXN_Header.NgayNhanMau <= CONVERT(datetime, '" + Enddate + "', 103)" +
                         " AND ( tbl_PXN_Header.NgayTraKetQua <= CONVERT(datetime, '" + Enddate + "', 103) " +
                         " OR tbl_PXN_Header.NgayTraKetQua <> '01-01-2019')"
                         , CommandType.Text);
            return dt;
        }

        public DataTable BaoCaoPXN_DaTra_Export2Excel(DateTime Stardate, DateTime Enddate)
        {
            DataTable dt = Sql.ExecuteDataTable("SAP",
                            " SELECT tbl_PXN_Header.ID, " +
                            " tbl_PXN_Header.NgayNhanMau, " +
                            " tbl_PXN_Header.NgayDuKienTra, " +
                            " tbl_PXN_Header.NgayCoKetQua, " +
                            " tbl_PXN_Header.NgayTraKetQua, " +
                            " tbl_PXN_Header.PTNThucHien, " +
                            " tbl_PXN_Header.SoPXN, " +
                            " tbl_KHMau_LAB.KHMau, " +
                            " tbl_CUSTOMER_LAB.CUSTNAME, " +
                            " tbl_CUSTOMER_LAB.CUSTADDRESS, " +
                            " tbl_EMPLOYEE_LAB.EMPName, " +
                            " tbl_LOCATION_LAB.LOCName, " +
                            " tbl_CUSTOMERTYPE_LAB.CUSTTYPEName, " +
                            " tbl_ChiTieuXetNghiem_LAB.MaCTXN, " +
                            " tbl_ChiTieuXetNghiem_LAB.CTXN, " +
                            " tbl_KHMau_LAB.DonViKHMau, " +
                            " tbl_KHMau_CTXN_LAB.SoLuongXN, " +
                            " tbl_KHMau_CTXN_LAB.DonGia, " +
                            " tbl_KHMau_CTXN_LAB.VAT, " +
                            " tbl_KHMau_CTXN_LAB.ThanhTien, " +
                            " tbl_KHMau_CTXN_LAB.DonGiaMuaNgoai " +
                            " FROM            tbl_PXN_Header " +
                            " INNER JOIN  tbl_KHMau_LAB " +
                            " ON tbl_PXN_Header.SoPXN = tbl_KHMau_LAB.SoPXN " +
                            " INNER JOIN tbl_KHMau_CTXN_LAB " +
                            " ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau " +
                            " INNER JOIN tbl_ChiTieuXetNghiem_LAB " +
                            " ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID " +
                            " INNER JOIN tbl_NhomChiTieuXetNghiem_LAB " +
                            " ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID " +
                            " INNER JOIN tbl_CUSTOMER_LAB " +
                            " ON tbl_PXN_Header.CUSTCODE_Id = tbl_CUSTOMER_LAB.Id " +
                            " INNER JOIN tbl_LOCATION_LAB " +
                            " ON tbl_CUSTOMER_LAB.LOCCode = tbl_LOCATION_LAB.LOCCode " +
                            " INNER JOIN tbl_EMPLOYEE_LAB " +
                            " ON tbl_PXN_Header.EMPCode_Id = tbl_EMPLOYEE_LAB.Id " +
                            " INNER JOIN tbl_CUSTOMERTYPE_LAB " +
                            " ON tbl_CUSTOMER_LAB.CUSTTYPECode = tbl_CUSTOMERTYPE_LAB.CUSTTYPECode   " +
                         " WHERE tbl_PXN_Header.NgayNhanMau >= CONVERT(datetime, '" + Stardate + "', 103) " +
                         " AND tbl_PXN_Header.NgayNhanMau <= CONVERT(datetime, '" + Enddate + "', 103)" +
                         " AND ( tbl_PXN_Header.NgayTraKetQua <= CONVERT(datetime, '" + Enddate + "', 103) " +
                         " OR tbl_PXN_Header.NgayTraKetQua <> '01-01-2019')"
                         , CommandType.Text);
            return dt;
        }

        public DataTable BaoCaoDichTeDan_Thang_xport2Excel(string month, string year)
        {
            DataTable dt = Sql.ExecuteDataTable("SAP",
                        " SELECT   LEFT(tbl_PXN_Header.NgayTraKetQua, 7) as ThangNam, " +
                        " tbl_NhomChiTieuXetNghiem_LAB.NCTXN, " +
                        " tbl_ChiTieuXetNghiem_LAB.CTXN, " +
                        " tbl_PXN_Header.DichTeDan, " +
                         " tbl_LOCATION_LAB.LOCName, " +
                         " tbl_CUSTOMER_LAB.ProvinceName, " +
                         " tbl_KHMau_LAB.DonViKHMau, " +
                         " SUM(CONVERT(float, tbl_KHMau_CTXN_LAB.SoLuongXN)) as SoLuongXN " +
                         "  FROM            tbl_PXN_Header " +
                         "  INNER JOIN  tbl_KHMau_LAB " +
                         "  ON tbl_PXN_Header.SoPXN = tbl_KHMau_LAB.SoPXN " +
                         "  INNER JOIN tbl_KHMau_CTXN_LAB " +
                         "  ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau " +
                         " INNER JOIN tbl_ChiTieuXetNghiem_LAB " +
                         " ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID " +
                         " INNER JOIN tbl_NhomChiTieuXetNghiem_LAB " +
                        "  ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID " +
                         " INNER JOIN tbl_CUSTOMER_LAB " +
                        "  ON tbl_PXN_Header.CUSTCODE_Id = tbl_CUSTOMER_LAB.Id " +
                        "  INNER JOIN tbl_LOCATION_LAB " +
                         " ON tbl_CUSTOMER_LAB.LOCCode = tbl_LOCATION_LAB.LOCCode " +
                        "  INNER JOIN tbl_EMPLOYEE_LAB " +
                        "  ON tbl_PXN_Header.EMPCode_Id = tbl_EMPLOYEE_LAB.Id " +
                        "  INNER JOIN tbl_CUSTOMERTYPE_LAB " +
                        "  ON tbl_CUSTOMER_LAB.CUSTTYPECode = tbl_CUSTOMERTYPE_LAB.CUSTTYPECode " +
                        "  WHERE RIGHT(LEFT(tbl_PXN_Header.NgayTraKetQua, 7), 2) = '" + month + "' " +
                        "  AND         LEFT(tbl_PXN_Header.NgayTraKetQua, 4) = '" + year + "' " +
                        "  GROUP BY LEFT(tbl_PXN_Header.NgayTraKetQua, 7), " +
                        " tbl_NhomChiTieuXetNghiem_LAB.NCTXN, " +
                        " tbl_ChiTieuXetNghiem_LAB.CTXN, " +
                        " tbl_PXN_Header.DichTeDan, " +
                        " tbl_LOCATION_LAB.LOCName, " +
                        "  tbl_CUSTOMER_LAB.ProvinceName, " +
                        "  tbl_KHMau_LAB.DonViKHMau " +
                        "  Order by LEFT(tbl_PXN_Header.NgayTraKetQua, 7), " +
                        " tbl_NhomChiTieuXetNghiem_LAB.NCTXN, " +
                        " tbl_ChiTieuXetNghiem_LAB.CTXN, " +
                        " tbl_PXN_Header.DichTeDan, " +
                        " tbl_LOCATION_LAB.LOCName, " +
                        "  tbl_CUSTOMER_LAB.ProvinceName, " +
                        "  tbl_KHMau_LAB.DonViKHMau "
                         , CommandType.Text);
            return dt;
        }

        public DataTable BaoCaoDoanhSo_Thang(DateTime Stardate, DateTime Enddate)
        {
            DataTable dt = Sql.ExecuteDataTable("SAP",
                            " SELECT " +
                             " tbl_PXN_Header.NgayNhanMau, " +
                             " tbl_PXN_Header.NgayCoKetQua, " +
                             " tbl_PXN_Header.NgayTraKetQua, " +
                             " tbl_PXN_Header.NgayXuatHoaDon, " +
                             " tbl_PXN_Header.NgayThuTien, " +
                             " tbl_PXN_Header.PTNThucHien, " +
                             " tbl_PXN_Header.SoPXN, " +
                             " tbl_CUSTOMER_LAB.CUSTCODE, " +
                             " tbl_CUSTOMER_LAB.CUSTNAME, " +
                             " SUM(tbl_KHMau_CTXN_LAB.ThanhTien) as ThanhTien, " +
                             " tbl_PXN_Header.SoTienTraTruoc, " +
                             " tbl_PXN_Header.SoTienDaThu ," +
                             " tbl_PXN_Header.SoTienHoaDon, " +
                             " SUM(tbl_KHMau_CTXN_LAB.ThanhTien) - (tbl_PXN_Header.SoTienTraTruoc + tbl_PXN_Header.SoTienDaThu) as SoTienPhaiThu" +
                             " FROM            tbl_PXN_Header " +
                             " INNER JOIN  tbl_KHMau_LAB " +
                             " ON tbl_PXN_Header.SoPXN = tbl_KHMau_LAB.SoPXN " +
                             " INNER JOIN tbl_KHMau_CTXN_LAB " +
                             " ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau " +
                             " INNER JOIN tbl_ChiTieuXetNghiem_LAB " +
                             " ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID " +
                             " INNER JOIN tbl_NhomChiTieuXetNghiem_LAB " +
                             " ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID " +
                             " INNER JOIN tbl_CUSTOMER_LAB " +
                             " ON tbl_PXN_Header.CUSTCODE_Id = tbl_CUSTOMER_LAB.Id " +
                             " INNER JOIN tbl_LOCATION_LAB " +
                             " ON tbl_CUSTOMER_LAB.LOCCode = tbl_LOCATION_LAB.LOCCode " +
                             " INNER JOIN tbl_EMPLOYEE_LAB " +
                             " ON tbl_PXN_Header.EMPCode_Id = tbl_EMPLOYEE_LAB.Id " +
                             " INNER JOIN tbl_CUSTOMERTYPE_LAB " +
                             " ON tbl_CUSTOMER_LAB.CUSTTYPECode = tbl_CUSTOMERTYPE_LAB.CUSTTYPECode " +
                             " WHERE tbl_PXN_Header.NgayNhanMau >= CONVERT(datetime, '" + Stardate + "', 103) " +
                             " AND tbl_PXN_Header.NgayNhanMau <= CONVERT(datetime, '" + Enddate + "', 103) " +
                             " GROUP BY " +
                             " tbl_PXN_Header.NgayNhanMau, " +
                             " tbl_PXN_Header.NgayCoKetQua, " +
                             " tbl_PXN_Header.NgayTraKetQua, " +
                             " tbl_PXN_Header.NgayXuatHoaDon, " +
                             " tbl_PXN_Header.NgayThuTien, " +
                             " tbl_PXN_Header.PTNThucHien, " +
                             " tbl_PXN_Header.SoPXN, " +
                             " tbl_CUSTOMER_LAB.CUSTNAME,  " +
                             " tbl_CUSTOMER_LAB.CUSTCODE,  " +
                             " tbl_PXN_Header.SoTienTraTruoc, " +
                             "  tbl_PXN_Header.SoTienDaThu, " +
                             "  tbl_PXN_Header.SoTienHoaDon "
                         , CommandType.Text);
            return dt;
        }

        public DataTable BaoCaoCongNo(DateTime Stardate, DateTime Enddate)
        {
            DataTable dt = Sql.ExecuteDataTable("SAP",
                           //" SELECT " +
                           //" tbl_CUSTOMER_LAB.CUSTCODE, " +
                           //   " tbl_CUSTOMER_LAB.CUSTNAME, " +
                           //   " SUM(tbl_KHMau_CTXN_LAB.ThanhTien) as ThanhTien, " +
                           //   " SUM(tbl_PXN_Header.SoTienTraTruoc) as SoTienTraTruoc, " +
                           //   " SUM(tbl_PXN_Header.SoTienDaThu) as SoTienDaThu, " +
                           //   " SUM(tbl_PXN_Header.SoTienHoaDon) as SoTienHoaDon, " +
                           //   " SUM(tbl_KHMau_CTXN_LAB.ThanhTien) - SUM(tbl_PXN_Header.SoTienTraTruoc)- SUM(tbl_PXN_Header.SoTienDaThu) as PhaiThu " +
                           //   " FROM            tbl_PXN_Header " +
                           //   " INNER JOIN  tbl_KHMau_LAB " +
                           //   " ON tbl_PXN_Header.SoPXN = tbl_KHMau_LAB.SoPXN " +
                           //   " INNER JOIN tbl_KHMau_CTXN_LAB " +
                           //   " ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau " +
                           //   " INNER JOIN tbl_ChiTieuXetNghiem_LAB " +
                           //   " ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID " +
                           //   " INNER JOIN tbl_NhomChiTieuXetNghiem_LAB " +
                           //   " ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID " +
                           //   " INNER JOIN tbl_CUSTOMER_LAB " +
                           //   " ON tbl_PXN_Header.CUSTCODE_Id = tbl_CUSTOMER_LAB.Id " +
                           //   " INNER JOIN tbl_LOCATION_LAB " +
                           //   " ON tbl_CUSTOMER_LAB.LOCCode = tbl_LOCATION_LAB.LOCCode " +
                           //   " INNER JOIN tbl_EMPLOYEE_LAB " +
                           //   " ON tbl_PXN_Header.EMPCode_Id = tbl_EMPLOYEE_LAB.Id " +
                           //   " INNER JOIN tbl_CUSTOMERTYPE_LAB " +
                           //   " ON tbl_CUSTOMER_LAB.CUSTTYPECode = tbl_CUSTOMERTYPE_LAB.CUSTTYPECode " +
                           //   " WHERE tbl_PXN_Header.NgayNhanMau >= CONVERT(datetime, '"+ Stardate + "', 103) " +
                           //   " AND tbl_PXN_Header.NgayNhanMau <= CONVERT(datetime, '"+ Enddate + "', 103) " +
                           //   " GROUP BY " +
                           //   " tbl_CUSTOMER_LAB.CUSTCODE, " +
                           //   " tbl_CUSTOMER_LAB.CUSTNAME " +
                           //   " ORDER BY CUSTCODE,CUSTNAME "
                           " SELECT " +
                              " tbl_CUSTOMER_LAB.CUSTCODE, " +
                              " tbl_CUSTOMER_LAB.CUSTNAME, " +
                              " SUM(tbl_KHMau_CTXN_LAB.ThanhTien) as ThanhTien, " +
                              " SUM(tbl_PXN_Header.SoTienTraTruoc) as SoTienTraTruoc, " +
                              " SUM(tbl_PXN_Header.SoTienDaThu) as SoTienDaThu, " +
                              " SUM(tbl_PXN_Header.SoTienHoaDon) as SoTienHoaDon, " +
                              " SUM(tbl_KHMau_CTXN_LAB.ThanhTien) - SUM(tbl_PXN_Header.SoTienTraTruoc) - SUM(tbl_PXN_Header.SoTienDaThu) as PhaiThu " +
                              " FROM            tbl_PXN_Header " +
                              " INNER JOIN  tbl_KHMau_LAB " +
                              " ON tbl_PXN_Header.SoPXN = tbl_KHMau_LAB.SoPXN " +
                              " INNER JOIN tbl_KHMau_CTXN_LAB " +
                              " ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau " +
                              " INNER JOIN tbl_ChiTieuXetNghiem_LAB " +
                              " ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID " +
                              " INNER JOIN tbl_NhomChiTieuXetNghiem_LAB " +
                              " ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID " +
                              " INNER JOIN tbl_CUSTOMER_LAB " +
                              " ON tbl_PXN_Header.CUSTCODE_Id = tbl_CUSTOMER_LAB.Id " +
                              " INNER JOIN tbl_LOCATION_LAB " +
                              " ON tbl_CUSTOMER_LAB.LOCCode = tbl_LOCATION_LAB.LOCCode " +
                              " INNER JOIN tbl_EMPLOYEE_LAB " +
                              " ON tbl_PXN_Header.EMPCode_Id = tbl_EMPLOYEE_LAB.Id " +
                              " INNER JOIN tbl_CUSTOMERTYPE_LAB " +
                              " ON tbl_CUSTOMER_LAB.CUSTTYPECode = tbl_CUSTOMERTYPE_LAB.CUSTTYPECode " +
                              " WHERE tbl_PXN_Header.NgayNhanMau >= CONVERT(datetime, '01-04-2019', 103) " +
                              " AND tbl_PXN_Header.NgayNhanMau <= CONVERT(datetime, '30-04-2019', 103) " +
                              " GROUP BY " +
                              " tbl_CUSTOMER_LAB.CUSTCODE, " +
                              " tbl_CUSTOMER_LAB.CUSTNAME " +
                              " ORDER BY CUSTCODE, CUSTNAME "
                         , CommandType.Text);
            return dt;
        }

        public int Result_PXN_Header_SoPXN(string LoaiXN)
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT ISNULL(MAX(RIGHT(SoPXN,4)),'0') as SoPXN FROM [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header] WHERE LEFT(SoPXN,3) = '" + LoaiXN + "'AND RIGHT(LEFT(SoPXN,5),2) = RIGHT(YEAR(GETDATE()),2)", CommandType.Text);
            return int.Parse(dt.Rows[0]["SoPXN"].ToString()) + 1;
        }

        public void PXN_HeaderDAO_UPDATE_NgayTraKetQua(string SoPXN)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header] SET " +
            "[NgayTraKetQua]        = CONVERT(datetime,'" + DateTime.Now.ToShortDateString() + "',103)" +
            //",[DaTraKetQua]        = '1' " +
           " WHERE [SoPXN]             ='" + SoPXN + "'", CommandType.Text);
        }

        public DataTable BaoCao_NhanMau_Daily(int i)
        {
            DataTable dt = 
                Sql.ExecuteDataTable("SAP",
                         " SELECT        tbl_KHMau_LAB.LoaiDVMauNuoc, tbl_LoaiDV_LAB.TenLoaiDV, tbl_KHMau_LAB.ID, tbl_KHMau_LAB.SoPXN, tbl_KHMau_LAB.CreatedDate, tbl_KHMau_LAB.CreatedBy, tbl_KHMau_LAB.Locked, tbl_KHMau_LAB.Note, " +
                         " tbl_KHMau_LAB.KHMau, tbl_KHMau_LAB.KHMau_KhachHang, tbl_KHMau_LAB.SoLuongKHMau, tbl_KHMau_LAB.DonViKHMau, tbl_KHMau_LAB.PhuongPhapBaoQuan, tbl_KHMau_LAB.VitriLuuKHMau, " +
                         " tbl_KHMau_LAB.NgayLuuKHMau, tbl_KHMau_LAB.NhanVienLuuKHMau, tbl_KHMau_LAB.NgayHuyKHMau, tbl_KHMau_LAB.TaiLieuHuyKHMau, tbl_KHMau_LAB.NhanVienHuyKHMau, tbl_KHMau_LAB.TrangThaiKHMau, " +
                         " tbl_KHMau_LAB.SoLuongHuyKHMau, tbl_ChiTieuXetNghiem_LAB.CTXN, tbl_ChiTieuXetNghiem_LAB.CTXNDG, tbl_ChiTieuXetNghiem_LAB.CTXNDGTA, tbl_ChiTieuXetNghiem_LAB.MinValue, " +
                         " tbl_ChiTieuXetNghiem_LAB.MaxValue, tbl_ChiTieuXetNghiem_LAB.UnitValue, tbl_NhomChiTieuXetNghiem_LAB.NCTXN, tbl_NhomChiTieuXetNghiem_LAB.NCTXNDG, tbl_NhomChiTieuXetNghiem_LAB.NhomChung, " +
                         " tbl_PhuongPhapXetNghiem_LAB.PPXN, tbl_PhuongPhapXetNghiem_LAB.PPXNDG, tbl_KHMau_CTXN_LAB.KHMau AS Expr1, tbl_KHMau_CTXN_LAB.DonGia, tbl_KHMau_CTXN_LAB.ThanhTien, tbl_KHMau_CTXN_LAB.KetQua, " +
                         " tbl_KHMau_CTXN_LAB.SoLuongDat, tbl_KHMau_CTXN_LAB.VAT, tbl_KHMau_CTXN_LAB.SoLuongXN, tbl_KHMau_LAB.MotaMau, tbl_KHMau_LAB.KHMau_GiaoMau, tbl_KHMau_LAB.TTMauGui, tbl_KHMau_LAB.LoaiMauGui, " +
                         " tbl_KHMau_LAB.NgayLayMau, tbl_KHMau_LAB.VTLayMauDayChuong, tbl_KHMau_LAB.GioLayMauTuoi, tbl_KHMau_LAB.Khac, tbl_KHMau_LAB.SoLuongKHMauKhongDat, tbl_KHMau_LAB.LiDoKHMauKhongDat, " +
                         " tbl_KHMau_CTXN_LAB.NgayTraKetQua, " +
                         " tbl_KHMau_CTXN_LAB.DaTraKetQua, " +
                         " tbl_KHMau_CTXN_LAB.CTXNID, " +
                         " tbl_PXN_Header.NgayNhanMau " +
                         " FROM            tbl_KHMau_LAB " +
                         " INNER JOIN tbl_PXN_Header ON tbl_KHMau_LAB.SoPXN = tbl_PXN_Header.SoPXN LEFT OUTER JOIN " +
                         " tbl_KHMau_CTXN_LAB ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau LEFT OUTER JOIN " +
                         " tbl_LoaiDV_LAB ON tbl_KHMau_LAB.LoaiDVMauNuoc = tbl_LoaiDV_LAB.MaLoaiDV LEFT OUTER JOIN " +
                         " tbl_ChiTieuXetNghiem_LAB ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID LEFT OUTER JOIN " +
                         " tbl_NhomChiTieuXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID LEFT OUTER JOIN " +
                         " tbl_PhuongPhapXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.PPXNID = tbl_PhuongPhapXetNghiem_LAB.ID " +
                         " WHERE DateDiff(dd, getdate(), tbl_PXN_Header.NgayNhanMau) = " + i, CommandType.Text);
            return dt;
        }

        public DataTable BaoCao_NhanMau_Weekly(int i)
        {
            DataTable dt =
                Sql.ExecuteDataTable("SAP",
                         " SELECT        tbl_KHMau_LAB.LoaiDVMauNuoc, tbl_LoaiDV_LAB.TenLoaiDV, tbl_KHMau_LAB.ID, tbl_KHMau_LAB.SoPXN, tbl_KHMau_LAB.CreatedDate, tbl_KHMau_LAB.CreatedBy, tbl_KHMau_LAB.Locked, tbl_KHMau_LAB.Note, " +
                         " tbl_KHMau_LAB.KHMau, tbl_KHMau_LAB.KHMau_KhachHang, tbl_KHMau_LAB.SoLuongKHMau, tbl_KHMau_LAB.DonViKHMau, tbl_KHMau_LAB.PhuongPhapBaoQuan, tbl_KHMau_LAB.VitriLuuKHMau, " +
                         " tbl_KHMau_LAB.NgayLuuKHMau, tbl_KHMau_LAB.NhanVienLuuKHMau, tbl_KHMau_LAB.NgayHuyKHMau, tbl_KHMau_LAB.TaiLieuHuyKHMau, tbl_KHMau_LAB.NhanVienHuyKHMau, tbl_KHMau_LAB.TrangThaiKHMau, " +
                         " tbl_KHMau_LAB.SoLuongHuyKHMau, tbl_ChiTieuXetNghiem_LAB.CTXN, tbl_ChiTieuXetNghiem_LAB.CTXNDG, tbl_ChiTieuXetNghiem_LAB.CTXNDGTA, tbl_ChiTieuXetNghiem_LAB.MinValue, " +
                         " tbl_ChiTieuXetNghiem_LAB.MaxValue, tbl_ChiTieuXetNghiem_LAB.UnitValue, tbl_NhomChiTieuXetNghiem_LAB.NCTXN, tbl_NhomChiTieuXetNghiem_LAB.NCTXNDG, tbl_NhomChiTieuXetNghiem_LAB.NhomChung, " +
                         " tbl_PhuongPhapXetNghiem_LAB.PPXN, tbl_PhuongPhapXetNghiem_LAB.PPXNDG, tbl_KHMau_CTXN_LAB.KHMau AS Expr1, tbl_KHMau_CTXN_LAB.DonGia, tbl_KHMau_CTXN_LAB.ThanhTien, tbl_KHMau_CTXN_LAB.KetQua, " +
                         " tbl_KHMau_CTXN_LAB.SoLuongDat, tbl_KHMau_CTXN_LAB.VAT, tbl_KHMau_CTXN_LAB.SoLuongXN, tbl_KHMau_LAB.MotaMau, tbl_KHMau_LAB.KHMau_GiaoMau, tbl_KHMau_LAB.TTMauGui, tbl_KHMau_LAB.LoaiMauGui, " +
                         " tbl_KHMau_LAB.NgayLayMau, tbl_KHMau_LAB.VTLayMauDayChuong, tbl_KHMau_LAB.GioLayMauTuoi, tbl_KHMau_LAB.Khac, tbl_KHMau_LAB.SoLuongKHMauKhongDat, tbl_KHMau_LAB.LiDoKHMauKhongDat, " +
                         " tbl_KHMau_CTXN_LAB.NgayTraKetQua, " +
                         " tbl_KHMau_CTXN_LAB.DaTraKetQua, " +
                         " tbl_KHMau_CTXN_LAB.CTXNID, " +
                         " tbl_PXN_Header.NgayNhanMau " +
                         " FROM            tbl_KHMau_LAB " +
                         " INNER JOIN tbl_PXN_Header ON tbl_KHMau_LAB.SoPXN = tbl_PXN_Header.SoPXN LEFT OUTER JOIN " +
                         " tbl_KHMau_CTXN_LAB ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau LEFT OUTER JOIN " +
                         " tbl_LoaiDV_LAB ON tbl_KHMau_LAB.LoaiDVMauNuoc = tbl_LoaiDV_LAB.MaLoaiDV LEFT OUTER JOIN " +
                         " tbl_ChiTieuXetNghiem_LAB ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID LEFT OUTER JOIN " +
                         " tbl_NhomChiTieuXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID LEFT OUTER JOIN " +
                         " tbl_PhuongPhapXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.PPXNID = tbl_PhuongPhapXetNghiem_LAB.ID " +
                         " WHERE        DateDiff(wk, getdate(), tbl_PXN_Header.NgayNhanMau) = " + i, CommandType.Text);
            return dt;
        }

        public DataTable BaoCao_NhanMau_Monthly(int i)
        {
            DataTable dt =
                Sql.ExecuteDataTable("SAP",
                         " SELECT        tbl_KHMau_LAB.LoaiDVMauNuoc, tbl_LoaiDV_LAB.TenLoaiDV, tbl_KHMau_LAB.ID, tbl_KHMau_LAB.SoPXN, tbl_KHMau_LAB.CreatedDate, tbl_KHMau_LAB.CreatedBy, tbl_KHMau_LAB.Locked, tbl_KHMau_LAB.Note, " +
                         " tbl_KHMau_LAB.KHMau, tbl_KHMau_LAB.KHMau_KhachHang, tbl_KHMau_LAB.SoLuongKHMau, tbl_KHMau_LAB.DonViKHMau, tbl_KHMau_LAB.PhuongPhapBaoQuan, tbl_KHMau_LAB.VitriLuuKHMau, " +
                         " tbl_KHMau_LAB.NgayLuuKHMau, tbl_KHMau_LAB.NhanVienLuuKHMau, tbl_KHMau_LAB.NgayHuyKHMau, tbl_KHMau_LAB.TaiLieuHuyKHMau, tbl_KHMau_LAB.NhanVienHuyKHMau, tbl_KHMau_LAB.TrangThaiKHMau, " +
                         " tbl_KHMau_LAB.SoLuongHuyKHMau, tbl_ChiTieuXetNghiem_LAB.CTXN, tbl_ChiTieuXetNghiem_LAB.CTXNDG, tbl_ChiTieuXetNghiem_LAB.CTXNDGTA, tbl_ChiTieuXetNghiem_LAB.MinValue, " +
                         " tbl_ChiTieuXetNghiem_LAB.MaxValue, tbl_ChiTieuXetNghiem_LAB.UnitValue, tbl_NhomChiTieuXetNghiem_LAB.NCTXN, tbl_NhomChiTieuXetNghiem_LAB.NCTXNDG, tbl_NhomChiTieuXetNghiem_LAB.NhomChung, " +
                         " tbl_PhuongPhapXetNghiem_LAB.PPXN, tbl_PhuongPhapXetNghiem_LAB.PPXNDG, tbl_KHMau_CTXN_LAB.KHMau AS Expr1, tbl_KHMau_CTXN_LAB.DonGia, tbl_KHMau_CTXN_LAB.ThanhTien, tbl_KHMau_CTXN_LAB.KetQua, " +
                         " tbl_KHMau_CTXN_LAB.SoLuongDat, tbl_KHMau_CTXN_LAB.VAT, tbl_KHMau_CTXN_LAB.SoLuongXN, tbl_KHMau_LAB.MotaMau, tbl_KHMau_LAB.KHMau_GiaoMau, tbl_KHMau_LAB.TTMauGui, tbl_KHMau_LAB.LoaiMauGui, " +
                         " tbl_KHMau_LAB.NgayLayMau, tbl_KHMau_LAB.VTLayMauDayChuong, tbl_KHMau_LAB.GioLayMauTuoi, tbl_KHMau_LAB.Khac, tbl_KHMau_LAB.SoLuongKHMauKhongDat, tbl_KHMau_LAB.LiDoKHMauKhongDat, " +
                         " tbl_KHMau_CTXN_LAB.NgayTraKetQua, " +
                         " tbl_KHMau_CTXN_LAB.DaTraKetQua, " +
                         " tbl_KHMau_CTXN_LAB.CTXNID, " +
                         " tbl_PXN_Header.NgayNhanMau " +
                         " FROM            tbl_KHMau_LAB " +
                         " INNER JOIN tbl_PXN_Header ON tbl_KHMau_LAB.SoPXN = tbl_PXN_Header.SoPXN LEFT OUTER JOIN " +
                         " tbl_KHMau_CTXN_LAB ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau LEFT OUTER JOIN " +
                         " tbl_LoaiDV_LAB ON tbl_KHMau_LAB.LoaiDVMauNuoc = tbl_LoaiDV_LAB.MaLoaiDV LEFT OUTER JOIN " +
                         " tbl_ChiTieuXetNghiem_LAB ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID LEFT OUTER JOIN " +
                         " tbl_NhomChiTieuXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID LEFT OUTER JOIN " +
                         " tbl_PhuongPhapXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.PPXNID = tbl_PhuongPhapXetNghiem_LAB.ID " +
                         " WHERE        DateDiff(mm, getdate(), tbl_PXN_Header.NgayNhanMau) = " + i, CommandType.Text);
            return dt;
        }

        public DataTable BaoCao_NhanMau_Quaterly(int i)
        {
            DataTable dt =
                Sql.ExecuteDataTable("SAP",
                         " SELECT        tbl_KHMau_LAB.LoaiDVMauNuoc, tbl_LoaiDV_LAB.TenLoaiDV, tbl_KHMau_LAB.ID, tbl_KHMau_LAB.SoPXN, tbl_KHMau_LAB.CreatedDate, tbl_KHMau_LAB.CreatedBy, tbl_KHMau_LAB.Locked, tbl_KHMau_LAB.Note, " +
                         " tbl_KHMau_LAB.KHMau, tbl_KHMau_LAB.KHMau_KhachHang, tbl_KHMau_LAB.SoLuongKHMau, tbl_KHMau_LAB.DonViKHMau, tbl_KHMau_LAB.PhuongPhapBaoQuan, tbl_KHMau_LAB.VitriLuuKHMau, " +
                         " tbl_KHMau_LAB.NgayLuuKHMau, tbl_KHMau_LAB.NhanVienLuuKHMau, tbl_KHMau_LAB.NgayHuyKHMau, tbl_KHMau_LAB.TaiLieuHuyKHMau, tbl_KHMau_LAB.NhanVienHuyKHMau, tbl_KHMau_LAB.TrangThaiKHMau, " +
                         " tbl_KHMau_LAB.SoLuongHuyKHMau, tbl_ChiTieuXetNghiem_LAB.CTXN, tbl_ChiTieuXetNghiem_LAB.CTXNDG, tbl_ChiTieuXetNghiem_LAB.CTXNDGTA, tbl_ChiTieuXetNghiem_LAB.MinValue, " +
                         " tbl_ChiTieuXetNghiem_LAB.MaxValue, tbl_ChiTieuXetNghiem_LAB.UnitValue, tbl_NhomChiTieuXetNghiem_LAB.NCTXN, tbl_NhomChiTieuXetNghiem_LAB.NCTXNDG, tbl_NhomChiTieuXetNghiem_LAB.NhomChung, " +
                         " tbl_PhuongPhapXetNghiem_LAB.PPXN, tbl_PhuongPhapXetNghiem_LAB.PPXNDG, tbl_KHMau_CTXN_LAB.KHMau AS Expr1, tbl_KHMau_CTXN_LAB.DonGia, tbl_KHMau_CTXN_LAB.ThanhTien, tbl_KHMau_CTXN_LAB.KetQua, " +
                         " tbl_KHMau_CTXN_LAB.SoLuongDat, tbl_KHMau_CTXN_LAB.VAT, tbl_KHMau_CTXN_LAB.SoLuongXN, tbl_KHMau_LAB.MotaMau, tbl_KHMau_LAB.KHMau_GiaoMau, tbl_KHMau_LAB.TTMauGui, tbl_KHMau_LAB.LoaiMauGui, " +
                         " tbl_KHMau_LAB.NgayLayMau, tbl_KHMau_LAB.VTLayMauDayChuong, tbl_KHMau_LAB.GioLayMauTuoi, tbl_KHMau_LAB.Khac, tbl_KHMau_LAB.SoLuongKHMauKhongDat, tbl_KHMau_LAB.LiDoKHMauKhongDat, " +
                         " tbl_KHMau_CTXN_LAB.NgayTraKetQua, " +
                         " tbl_KHMau_CTXN_LAB.DaTraKetQua, " +
                         " tbl_KHMau_CTXN_LAB.CTXNID, " +
                         " tbl_PXN_Header.NgayNhanMau " +
                         " FROM            tbl_KHMau_LAB " +
                         " INNER JOIN tbl_PXN_Header ON tbl_KHMau_LAB.SoPXN = tbl_PXN_Header.SoPXN LEFT OUTER JOIN " +
                         " tbl_KHMau_CTXN_LAB ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau LEFT OUTER JOIN " +
                         " tbl_LoaiDV_LAB ON tbl_KHMau_LAB.LoaiDVMauNuoc = tbl_LoaiDV_LAB.MaLoaiDV LEFT OUTER JOIN " +
                         " tbl_ChiTieuXetNghiem_LAB ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID LEFT OUTER JOIN " +
                         " tbl_NhomChiTieuXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID LEFT OUTER JOIN " +
                         " tbl_PhuongPhapXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.PPXNID = tbl_PhuongPhapXetNghiem_LAB.ID " +
                         " WHERE        DateDiff(qq, getdate(), tbl_PXN_Header.NgayNhanMau) = " + i, CommandType.Text);
            return dt;
        }

        public DataTable BaoCao_NhanMau_Yearly(int i)
        {
            DataTable dt =
                Sql.ExecuteDataTable("SAP",
                         " SELECT        tbl_KHMau_LAB.LoaiDVMauNuoc, tbl_LoaiDV_LAB.TenLoaiDV, tbl_KHMau_LAB.ID, tbl_KHMau_LAB.SoPXN, tbl_KHMau_LAB.CreatedDate, tbl_KHMau_LAB.CreatedBy, tbl_KHMau_LAB.Locked, tbl_KHMau_LAB.Note, " +
                         " tbl_KHMau_LAB.KHMau, tbl_KHMau_LAB.KHMau_KhachHang, tbl_KHMau_LAB.SoLuongKHMau, tbl_KHMau_LAB.DonViKHMau, tbl_KHMau_LAB.PhuongPhapBaoQuan, tbl_KHMau_LAB.VitriLuuKHMau, " +
                         " tbl_KHMau_LAB.NgayLuuKHMau, tbl_KHMau_LAB.NhanVienLuuKHMau, tbl_KHMau_LAB.NgayHuyKHMau, tbl_KHMau_LAB.TaiLieuHuyKHMau, tbl_KHMau_LAB.NhanVienHuyKHMau, tbl_KHMau_LAB.TrangThaiKHMau, " +
                         " tbl_KHMau_LAB.SoLuongHuyKHMau, tbl_ChiTieuXetNghiem_LAB.CTXN, tbl_ChiTieuXetNghiem_LAB.CTXNDG, tbl_ChiTieuXetNghiem_LAB.CTXNDGTA, tbl_ChiTieuXetNghiem_LAB.MinValue, " +
                         " tbl_ChiTieuXetNghiem_LAB.MaxValue, tbl_ChiTieuXetNghiem_LAB.UnitValue, tbl_NhomChiTieuXetNghiem_LAB.NCTXN, tbl_NhomChiTieuXetNghiem_LAB.NCTXNDG, tbl_NhomChiTieuXetNghiem_LAB.NhomChung, " +
                         " tbl_PhuongPhapXetNghiem_LAB.PPXN, tbl_PhuongPhapXetNghiem_LAB.PPXNDG, tbl_KHMau_CTXN_LAB.KHMau AS Expr1, tbl_KHMau_CTXN_LAB.DonGia, tbl_KHMau_CTXN_LAB.ThanhTien, tbl_KHMau_CTXN_LAB.KetQua, " +
                         " tbl_KHMau_CTXN_LAB.SoLuongDat, tbl_KHMau_CTXN_LAB.VAT, tbl_KHMau_CTXN_LAB.SoLuongXN, tbl_KHMau_LAB.MotaMau, tbl_KHMau_LAB.KHMau_GiaoMau, tbl_KHMau_LAB.TTMauGui, tbl_KHMau_LAB.LoaiMauGui, " +
                         " tbl_KHMau_LAB.NgayLayMau, tbl_KHMau_LAB.VTLayMauDayChuong, tbl_KHMau_LAB.GioLayMauTuoi, tbl_KHMau_LAB.Khac, tbl_KHMau_LAB.SoLuongKHMauKhongDat, tbl_KHMau_LAB.LiDoKHMauKhongDat, " +
                         " tbl_KHMau_CTXN_LAB.NgayTraKetQua, " +
                         " tbl_KHMau_CTXN_LAB.DaTraKetQua, " +
                         " tbl_KHMau_CTXN_LAB.CTXNID, " +
                         " tbl_PXN_Header.NgayNhanMau " +
                         " FROM            tbl_KHMau_LAB " +
                         " INNER JOIN tbl_PXN_Header ON tbl_KHMau_LAB.SoPXN = tbl_PXN_Header.SoPXN LEFT OUTER JOIN " +
                         " tbl_KHMau_CTXN_LAB ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau LEFT OUTER JOIN " +
                         " tbl_LoaiDV_LAB ON tbl_KHMau_LAB.LoaiDVMauNuoc = tbl_LoaiDV_LAB.MaLoaiDV LEFT OUTER JOIN " +
                         " tbl_ChiTieuXetNghiem_LAB ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID LEFT OUTER JOIN " +
                         " tbl_NhomChiTieuXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID LEFT OUTER JOIN " +
                         " tbl_PhuongPhapXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.PPXNID = tbl_PhuongPhapXetNghiem_LAB.ID " +
                         " WHERE        DateDiff(yy, getdate(), tbl_PXN_Header.NgayNhanMau) = " + i, CommandType.Text);
            return dt;
        }

        public DataTable BaoCao_NhanMau_Fr_To_Date(DateTime Stardate , DateTime Enddate)
        {
            DataTable dt =
                Sql.ExecuteDataTable("SAP",
                         " SELECT        tbl_KHMau_LAB.LoaiDVMauNuoc, tbl_LoaiDV_LAB.TenLoaiDV, tbl_KHMau_LAB.ID, tbl_KHMau_LAB.SoPXN, tbl_KHMau_LAB.CreatedDate, tbl_KHMau_LAB.CreatedBy, tbl_KHMau_LAB.Locked, tbl_KHMau_LAB.Note, " +
                         " tbl_KHMau_LAB.KHMau, tbl_KHMau_LAB.KHMau_KhachHang, tbl_KHMau_LAB.SoLuongKHMau, tbl_KHMau_LAB.DonViKHMau, tbl_KHMau_LAB.PhuongPhapBaoQuan, tbl_KHMau_LAB.VitriLuuKHMau, " +
                         " tbl_KHMau_LAB.NgayLuuKHMau, tbl_KHMau_LAB.NhanVienLuuKHMau, tbl_KHMau_LAB.NgayHuyKHMau, tbl_KHMau_LAB.TaiLieuHuyKHMau, tbl_KHMau_LAB.NhanVienHuyKHMau, tbl_KHMau_LAB.TrangThaiKHMau, " +
                         " tbl_KHMau_LAB.SoLuongHuyKHMau, tbl_ChiTieuXetNghiem_LAB.CTXN, tbl_ChiTieuXetNghiem_LAB.CTXNDG, tbl_ChiTieuXetNghiem_LAB.CTXNDGTA, tbl_ChiTieuXetNghiem_LAB.MinValue, " +
                         " tbl_ChiTieuXetNghiem_LAB.MaxValue, tbl_ChiTieuXetNghiem_LAB.UnitValue, tbl_NhomChiTieuXetNghiem_LAB.NCTXN, tbl_NhomChiTieuXetNghiem_LAB.NCTXNDG, tbl_NhomChiTieuXetNghiem_LAB.NhomChung, " +
                         " tbl_PhuongPhapXetNghiem_LAB.PPXN, tbl_PhuongPhapXetNghiem_LAB.PPXNDG, tbl_KHMau_CTXN_LAB.KHMau AS Expr1, tbl_KHMau_CTXN_LAB.DonGia, tbl_KHMau_CTXN_LAB.ThanhTien, tbl_KHMau_CTXN_LAB.KetQua, " +
                         " tbl_KHMau_CTXN_LAB.SoLuongDat, tbl_KHMau_CTXN_LAB.VAT, tbl_KHMau_CTXN_LAB.SoLuongXN, tbl_KHMau_LAB.MotaMau, tbl_KHMau_LAB.KHMau_GiaoMau, tbl_KHMau_LAB.TTMauGui, tbl_KHMau_LAB.LoaiMauGui, " +
                         " tbl_KHMau_LAB.NgayLayMau, tbl_KHMau_LAB.VTLayMauDayChuong, tbl_KHMau_LAB.GioLayMauTuoi, tbl_KHMau_LAB.Khac, tbl_KHMau_LAB.SoLuongKHMauKhongDat, tbl_KHMau_LAB.LiDoKHMauKhongDat, " +
                         " tbl_KHMau_CTXN_LAB.NgayTraKetQua, " +
                         " tbl_KHMau_CTXN_LAB.DaTraKetQua, " +
                         " tbl_KHMau_CTXN_LAB.CTXNID, " +
                         " tbl_PXN_Header.NgayNhanMau " +
                         " FROM            tbl_KHMau_LAB " +
                         " INNER JOIN tbl_PXN_Header ON tbl_KHMau_LAB.SoPXN = tbl_PXN_Header.SoPXN LEFT OUTER JOIN " +
                         " tbl_KHMau_CTXN_LAB ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau LEFT OUTER JOIN " +
                         " tbl_LoaiDV_LAB ON tbl_KHMau_LAB.LoaiDVMauNuoc = tbl_LoaiDV_LAB.MaLoaiDV LEFT OUTER JOIN " +
                         " tbl_ChiTieuXetNghiem_LAB ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID LEFT OUTER JOIN " +
                         " tbl_NhomChiTieuXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID LEFT OUTER JOIN " +
                         " tbl_PhuongPhapXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.PPXNID = tbl_PhuongPhapXetNghiem_LAB.ID " +
                         " WHERE tbl_PXN_Header.NgayNhanMau >= CONVERT(datetime, '" + Stardate + "', 103) " +
                                                " AND tbl_PXN_Header.NgayNhanMau <= CONVERT(datetime, '" + Enddate + "', 103) " , CommandType.Text);
            return dt;
        }
        

    }
}