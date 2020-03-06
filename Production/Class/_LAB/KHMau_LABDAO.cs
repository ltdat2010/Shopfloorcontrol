using System;
using System.Data;

namespace Production.Class
{
    public class KHMau_LABDAO
    {
        public int KHMau_LABDAO_INSERT(KHMau_LAB OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_LAB] " +
           " ([SoPXN] " +
           " ,[KHMau] " +
           " ,[KHMau_GiaoMau] " +
           " ,[KHMau_KhachHang] " +
           " ,[SoLuongKHMau] " +
           " ,[SoLuongKHMauKhongDat] " +
           " ,[LiDoKHMauKhongDat] " +
           " ,[DonViKHMau] " +
           " ,[PhuongPhapBaoQuan] " +
           " ,[VitriLuuKHMau] " +
           " ,[NgayLuuKHMau] " +
           " ,[NhanVienLuuKHMau] " +
           " ,[NgayHuyKHMau] " +
           " ,[TaiLieuHuyKHMau] " +
           " ,[NhanVienHuyKHMau] " +
           " ,[TrangThaiKHMau] " +
           " ,[LuuMau] " +
           " ,[HuyMau] " +
           " ,[SoLuongHuyKHMau] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked] " +
           " ,[LoaiDVMauNuoc] " +
           " ,[NgayLayMau] " +
           " ,[LoaiMauGui] " +
           " ,[TTMauGui] " +
           " ,[VTLayMauDayChuong] " +
           " ,[Khac] " +
           //" ,[BanGiaoMauStatus] " +
           //" ,[NguoiNhanBanGiaoMau] " +
           //" ,[NguoiGiaoBanGiaoMau] " +
           //" ,[NgayBanGiaoMau] " +
           " ,[GioLayMauTuoi] )" +
     " VALUES " +
           "(N'" + OBJ.SoPXN +
           "',N'" + OBJ.KHMau +
           "',N'" + OBJ.KHMau_GiaoMau +
           "',N'" + OBJ.KHMau_KhachHang +
           "',N'" + OBJ.SoLuongKHMau +
           "',N'" + OBJ.SoLuongKHMauKhongDat +
           "',N'" + OBJ.LiDoKHMauKhongDat +
           "',N'" + OBJ.DonViKHMau +
           "',N'" + OBJ.PhuongPhapBaoQuan +
           "',N'" + OBJ.VitriLuuKHMau +
           "',CONVERT(datetime,'" + OBJ.NgayLuuKHMau +
           "',103),N'" + OBJ.NhanVienLuuKHMau +
           "',CONVERT(datetime,'" + OBJ.NgayHuyKHMau +
           "',103),N'" + OBJ.TaiLieuHuyKHMau +
           "',N'" + OBJ.NhanVienHuyKHMau +
           "',N'" + OBJ.TrangThaiKHMau +
           "',N'" + OBJ.LuuMau +
           "',N'" + OBJ.HuyMau +
           "',N'" + OBJ.SoLuongHuyKHMau +
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "','" + OBJ.Locked +
           "',N'" + OBJ.LoaiDVMauNuoc +
           "',CONVERT(datetime,'" + OBJ.NgayLayMau +
           "',103),N'" + OBJ.LoaiMauGui +
           "',N'" + OBJ.TTMauGui +
           "',N'" + OBJ.VTLayMauDayChuong +
           "',N'" + OBJ.Khac +
           //"',N'" + false +
           //"',N'" + OBJ.NguoiNhanBanGiaoMau +
           //"',N'" + OBJ.NguoiGiaoBanGiaoMau +
           //"',CONVERT(datetime,'" + DateTime.Now + "',103)" +
           "',N'" + OBJ.GioLayMauTuoi +
           "')", CommandType.Text);

            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_LAB] WHERE KHMau='" + OBJ.KHMau + "'", CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());
        }

        public void KHMau_LABDAO_UPDATE(KHMau_LAB OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "    UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_LAB] SET " +
           " [SoPXN]                    =   N'" + OBJ.SoPXN + "'" +
           ",[KHMau]                    =   N'" + OBJ.KHMau + "'" +
           //",[KHMau_GiaoMau]                    =   N'" + OBJ.KHMau_GiaoMau + "'" +
           ",[KHMau_KhachHang]          =   N'" + OBJ.KHMau_KhachHang + "'" +
           ",[SoLuongKHMau]             =   N'" + OBJ.SoLuongKHMau + "'" +
           ",[SoLuongKHMauKhongDat]             =   N'" + OBJ.SoLuongKHMauKhongDat + "'" +
           ",[LiDoKHMauKhongDat]             =   N'" + OBJ.LiDoKHMauKhongDat + "'" +
           ",[DonViKHMau]               =   N'" + OBJ.DonViKHMau + "'" +
           ",[PhuongPhapBaoQuan]        =   N'" + OBJ.PhuongPhapBaoQuan + "'" +
           ",[VitriLuuKHMau]            =   N'" + OBJ.VitriLuuKHMau + "'" +
           ",[NgayLuuKHMau]             =   CONVERT(datetime,'" + OBJ.NgayLuuKHMau + "',103)" +
           ",[NhanVienLuuKHMau]         =   N'" + OBJ.NhanVienLuuKHMau + "'" +
           ",[NgayHuyKHMau]             =   CONVERT(datetime,'" + OBJ.NgayHuyKHMau + "',103)" +
           ",[TaiLieuHuyKHMau]          =   N'" + OBJ.TaiLieuHuyKHMau + "'" +
           ",[NhanVienHuyKHMau]         =   N'" + OBJ.NhanVienHuyKHMau + "'" +
           ",[TrangThaiKHMau]           =   N'" + OBJ.TrangThaiKHMau + "'" +
           ",[LuuMau]           =   N'" + OBJ.LuuMau + "'" +
           ",[HuyMau]           =   N'" + OBJ.HuyMau + "'" +
           ",[SoLuongHuyKHMau]          =   N'" + OBJ.SoLuongHuyKHMau + "'" +
           ",[CreatedDate]              =   CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy]                =   N'" + OBJ.CreatedBy + "' " +
           ",[Note]                     =   N'" + OBJ.Note + "'" +
           ",[Locked]                   =   N'" + OBJ.Locked + "'" +
           ",[LoaiDVMauNuoc]            =   N'" + OBJ.LoaiDVMauNuoc + "'" +
           ",[NgayLayMau]               =   CONVERT(datetime,'" + OBJ.NgayLayMau + "',103)" +
           ",[LoaiMauGui]               =   N'" + OBJ.LoaiMauGui + "'" +
           ",[TTMauGui]                 =   N'" + OBJ.TTMauGui + "'" +
           ",[VTLayMauDayChuong]        =   N'" + OBJ.VTLayMauDayChuong + "'" +
           ",[Khac]                     =   N'" + OBJ.Khac + "'" +
           //",[BanGiaoMauStatus]                     =   N'" + true + "'" +
           //",[NguoiNhanBanGiaoMau]                     =   N'" + OBJ.NguoiNhanBanGiaoMau + "'" +
           //",[NguoiGiaoBanGiaoMau]                     =   N'" + OBJ.CreatedBy + "'" +
           //",[NgayBanGiaoMau]                     =   CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[GioLayMauTuoi]            =   N'" + OBJ.GioLayMauTuoi + "'" +
           " WHERE [ID]              =   " + OBJ.ID, CommandType.Text);
        }

        public void KHMau_LABDAO_DELETE(string KHMau)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_LAB] " +
            " WHERE [KHMau]='" + KHMau + "'", CommandType.Text);
        }

        public void KHMau_LABDAO_DELETE_SoPXN(string SoPXN)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_LAB] " +
            " WHERE [SoPXN]='" + SoPXN + "'", CommandType.Text);
        }

        public DataTable KHMau_LABDAO_SELECT(string SoPXN)
        {
            return Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_LAB] " +
                                                " WHERE [SoPXN]='" + SoPXN + "'", CommandType.Text);
        }

        public DataTable KHMau_LABDAO_REPORT_RECEIPT(string SoPXN)
        {
            return Sql.ExecuteDataTable("SAP", " SELECT   tbl_KHMau_LAB.* ,  " +
                                                " CASE WHEN tbl_LoaiDV_LAB.TenLoaiDV is not null THEN tbl_LoaiDV_LAB.TenLoaiDV Else 'NULL' END as TenLoaiDV, " +
                                                " CASE WHEN tbl_MauNuoc_LAB.TenMauNuoc is not null THEN tbl_MauNuoc_LAB.TenMauNuoc Else 'NULL' END as TenMauNuoc, " +
                                                " tbl_LoaiMau_LAB.TenLoaiMau " +
                                                " FROM            tbl_KHMau_LAB  " +
                                                " LEFT JOIN tbl_LoaiDV_LAB ON tbl_KHMau_LAB.LoaiDVMauNuoc = tbl_LoaiDV_LAB.MaLoaiDV " +
                                                " LEFT JOIN tbl_MauNuoc_LAB ON tbl_KHMau_LAB.LoaiDVMauNuoc = tbl_MauNuoc_LAB.MaMauNuoc " +
                                                " LEFT JOIN tbl_LoaiMau_LAB ON tbl_KHMau_LAB.LoaiMauGui = tbl_LoaiMau_LAB.MaLoaiMau " +
                                                " WHERE tbl_KHMau_LAB.SoPXN ='" + SoPXN + "'", CommandType.Text);
        }

        public DataTable KHMau_LABDAO_REPORT_DETAILS(string SoPXN)
        {
            return Sql.ExecuteDataTable("SAP", " SELECT        tbl_KHMau_LAB.LoaiDVMauNuoc,tbl_LoaiDV_LAB.TenLoaiDV,tbl_KHMau_LAB.ID, tbl_KHMau_LAB.SoPXN, tbl_KHMau_LAB.CreatedDate, tbl_KHMau_LAB.CreatedBy, tbl_KHMau_LAB.Locked, tbl_KHMau_LAB.Note, tbl_KHMau_LAB.KHMau,tbl_KHMau_LAB.KHMau_KhachHang, tbl_KHMau_LAB.SoLuongKHMau, " +
                         " tbl_KHMau_LAB.DonViKHMau, tbl_KHMau_LAB.PhuongPhapBaoQuan, tbl_KHMau_LAB.VitriLuuKHMau, tbl_KHMau_LAB.NgayLuuKHMau, tbl_KHMau_LAB.NhanVienLuuKHMau, tbl_KHMau_LAB.NgayHuyKHMau, " +
                         " tbl_KHMau_LAB.TaiLieuHuyKHMau, tbl_KHMau_LAB.NhanVienHuyKHMau, tbl_KHMau_LAB.TrangThaiKHMau, tbl_KHMau_LAB.SoLuongHuyKHMau, tbl_ChiTieuXetNghiem_LAB.CTXN, " +
                         " tbl_ChiTieuXetNghiem_LAB.CTXNDG, tbl_ChiTieuXetNghiem_LAB.CTXNDGTA, tbl_ChiTieuXetNghiem_LAB.MinValue, tbl_ChiTieuXetNghiem_LAB.MaxValue, tbl_ChiTieuXetNghiem_LAB.UnitValue,tbl_ChiTieuXetNghiem_LAB.Acronym, " +
                         " tbl_NhomChiTieuXetNghiem_LAB.NCTXN, tbl_NhomChiTieuXetNghiem_LAB.NCTXNDG, tbl_NhomChiTieuXetNghiem_LAB.NhomChung, tbl_PhuongPhapXetNghiem_LAB.PPXN, tbl_PhuongPhapXetNghiem_LAB.PPXNDG, " +
                         " tbl_KHMau_CTXN_LAB.KHMau AS Expr1, tbl_KHMau_CTXN_LAB.DonGia, tbl_KHMau_CTXN_LAB.ThanhTien, tbl_KHMau_CTXN_LAB.KetQua, tbl_KHMau_CTXN_LAB.SoLuongDat, tbl_KHMau_CTXN_LAB.VAT, tbl_KHMau_CTXN_LAB.SoLuongXN,tbl_KHMau_LAB.LuuMau,tbl_KHMau_LAB.HuyMau " +
                         " FROM            tbl_KHMau_LAB LEFT JOIN " +
                         " tbl_KHMau_CTXN_LAB ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau LEFT JOIN " +
                         " tbl_LoaiDV_LAB ON tbl_KHMau_LAB.LoaiDVMauNuoc = tbl_LoaiDV_LAB.MaLoaiDV LEFT JOIN " +
                         " tbl_ChiTieuXetNghiem_LAB ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID LEFT JOIN " +
                         " tbl_NhomChiTieuXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID LEFT JOIN " +
                         " tbl_PhuongPhapXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.PPXNID = tbl_PhuongPhapXetNghiem_LAB.ID " +
                         " WHERE tbl_KHMau_LAB.SoPXN ='" + SoPXN + "'", CommandType.Text);
        }

        public DataTable KHMau_LABDAO_REPORT_DETROY(string SoPXN)
        {
            //return Sql.ExecuteDataTable("SAP", " SELECT        tbl_KHMau_LAB.ID, tbl_KHMau_LAB.SoPXN, tbl_KHMau_LAB.CreatedDate, tbl_KHMau_LAB.CreatedBy, tbl_KHMau_LAB.Locked, tbl_KHMau_LAB.Note, tbl_KHMau_LAB.KHMau,tbl_KHMau_LAB.KHMau_KhachHang, tbl_KHMau_LAB.SoLuongKHMau, " +
            //             " tbl_KHMau_LAB.DonViKHMau, tbl_KHMau_LAB.PhuongPhapBaoQuan, tbl_KHMau_LAB.VitriLuuKHMau, tbl_KHMau_LAB.NgayLuuKHMau, tbl_KHMau_LAB.NhanVienLuuKHMau, tbl_KHMau_LAB.NgayHuyKHMau, " +
            //             " tbl_KHMau_LAB.TaiLieuHuyKHMau, tbl_KHMau_LAB.NhanVienHuyKHMau, tbl_KHMau_LAB.TrangThaiKHMau, tbl_KHMau_LAB.SoLuongHuyKHMau, tbl_ChiTieuXetNghiem_LAB.CTXN, " +
            //             " tbl_ChiTieuXetNghiem_LAB.CTXNDG, tbl_ChiTieuXetNghiem_LAB.CTXNDGTA, tbl_ChiTieuXetNghiem_LAB.MinValue, tbl_ChiTieuXetNghiem_LAB.MaxValue, tbl_ChiTieuXetNghiem_LAB.UnitValue, " +
            //             " tbl_NhomChiTieuXetNghiem_LAB.NCTXN, tbl_NhomChiTieuXetNghiem_LAB.NCTXNDG, tbl_NhomChiTieuXetNghiem_LAB.NhomChung, tbl_PhuongPhapXetNghiem_LAB.PPXN, tbl_PhuongPhapXetNghiem_LAB.PPXNDG, " +
            //             " tbl_KHMau_CTXN_LAB.KHMau AS Expr1, tbl_KHMau_CTXN_LAB.DonGia, tbl_KHMau_CTXN_LAB.ThanhTien, tbl_KHMau_CTXN_LAB.KetQua, tbl_KHMau_CTXN_LAB.SoLuongDat, tbl_KHMau_CTXN_LAB.VAT " +
            //             " FROM            tbl_KHMau_LAB LEFT JOIN " +
            //             " tbl_KHMau_CTXN_LAB ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau LEFT JOIN " +
            //             " tbl_ChiTieuXetNghiem_LAB ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID LEFT JOIN " +
            //             " tbl_NhomChiTieuXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID LEFT JOIN " +
            //             " tbl_PhuongPhapXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.PPXNID = tbl_PhuongPhapXetNghiem_LAB.ID " +
            //             " WHERE tbl_KHMau_LAB.SoPXN ='" + SoPXN + "' and TrangThaiKHMau = '1'" +
            //             "  GROUP BY tbl_KHMau_LAB.ID, tbl_KHMau_LAB.SoPXN, tbl_KHMau_LAB.CreatedDate, tbl_KHMau_LAB.CreatedBy, tbl_KHMau_LAB.Locked, tbl_KHMau_LAB.Note, tbl_KHMau_LAB.KHMau,tbl_KHMau_LAB.KHMau_KhachHang, tbl_KHMau_LAB.SoLuongKHMau, " +
            //             " tbl_KHMau_LAB.DonViKHMau, tbl_KHMau_LAB.PhuongPhapBaoQuan, tbl_KHMau_LAB.VitriLuuKHMau, tbl_KHMau_LAB.NgayLuuKHMau, tbl_KHMau_LAB.NhanVienLuuKHMau, tbl_KHMau_LAB.NgayHuyKHMau, " +
            //             " tbl_KHMau_LAB.TaiLieuHuyKHMau, tbl_KHMau_LAB.NhanVienHuyKHMau, tbl_KHMau_LAB.TrangThaiKHMau, tbl_KHMau_LAB.SoLuongHuyKHMau, tbl_ChiTieuXetNghiem_LAB.CTXN, " +
            //             " tbl_ChiTieuXetNghiem_LAB.CTXNDG, tbl_ChiTieuXetNghiem_LAB.CTXNDGTA, tbl_ChiTieuXetNghiem_LAB.MinValue, tbl_ChiTieuXetNghiem_LAB.MaxValue, tbl_ChiTieuXetNghiem_LAB.UnitValue, " +
            //             " tbl_NhomChiTieuXetNghiem_LAB.NCTXN, tbl_NhomChiTieuXetNghiem_LAB.NCTXNDG, tbl_NhomChiTieuXetNghiem_LAB.NhomChung, tbl_PhuongPhapXetNghiem_LAB.PPXN, tbl_PhuongPhapXetNghiem_LAB.PPXNDG, " +
            //             " tbl_KHMau_CTXN_LAB.KHMau , tbl_KHMau_CTXN_LAB.DonGia, tbl_KHMau_CTXN_LAB.ThanhTien, tbl_KHMau_CTXN_LAB.KetQua, tbl_KHMau_CTXN_LAB.SoLuongDat, tbl_KHMau_CTXN_LAB.VAT " , CommandType.Text);
            return Sql.ExecuteDataTable("SAP", " SELECT        tbl_KHMau_LAB.ID, tbl_KHMau_LAB.SoPXN, tbl_KHMau_LAB.KHMau, tbl_KHMau_LAB.SoLuongKHMau,   " +
                " tbl_KHMau_LAB.NgayHuyKHMau, tbl_KHMau_LAB.TaiLieuHuyKHMau, tbl_KHMau_LAB.NhanVienHuyKHMau, tbl_KHMau_LAB.TrangThaiKHMau, tbl_KHMau_LAB.SoLuongHuyKHMau,tbl_KHMau_LAB.HuyMau  " +
                " FROM            tbl_KHMau_LAB LEFT JOIN   " +
                " tbl_KHMau_CTXN_LAB ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau  " +
                " WHERE tbl_KHMau_LAB.SoPXN ='" + SoPXN + "' and TrangThaiKHMau = '0'  " +
                " GROUP BY tbl_KHMau_LAB.ID, tbl_KHMau_LAB.SoPXN,  tbl_KHMau_LAB.KHMau, tbl_KHMau_LAB.SoLuongKHMau,   " +
                " tbl_KHMau_LAB.TaiLieuHuyKHMau, tbl_KHMau_LAB.NhanVienHuyKHMau, tbl_KHMau_LAB.TrangThaiKHMau, tbl_KHMau_LAB.NgayHuyKHMau, tbl_KHMau_LAB.SoLuongHuyKHMau,tbl_KHMau_LAB.HuyMau   ", CommandType.Text);
        }

        public DataTable KHMau_LABDAO_REPORT_STORAGE(string SoPXN)
        {
            //return Sql.ExecuteDataTable("SAP", " SELECT        tbl_KHMau_LAB.ID, tbl_KHMau_LAB.SoPXN, tbl_KHMau_LAB.CreatedDate, tbl_KHMau_LAB.CreatedBy, tbl_KHMau_LAB.Locked, tbl_KHMau_LAB.Note, tbl_KHMau_LAB.KHMau,tbl_KHMau_LAB.KHMau_KhachHang, tbl_KHMau_LAB.SoLuongKHMau, " +
            //             " tbl_KHMau_LAB.DonViKHMau, tbl_KHMau_LAB.PhuongPhapBaoQuan, tbl_KHMau_LAB.VitriLuuKHMau, tbl_KHMau_LAB.NgayLuuKHMau, tbl_KHMau_LAB.NhanVienLuuKHMau, tbl_KHMau_LAB.NgayHuyKHMau, " +
            //             " tbl_KHMau_LAB.TaiLieuHuyKHMau, tbl_KHMau_LAB.NhanVienHuyKHMau, tbl_KHMau_LAB.TrangThaiKHMau, tbl_KHMau_LAB.SoLuongHuyKHMau, tbl_KHMau_LAB.KHMau_KhachHang, tbl_ChiTieuXetNghiem_LAB.CTXN, " +
            //             " tbl_ChiTieuXetNghiem_LAB.CTXNDG, tbl_ChiTieuXetNghiem_LAB.CTXNDGTA, tbl_ChiTieuXetNghiem_LAB.MinValue, tbl_ChiTieuXetNghiem_LAB.MaxValue, tbl_ChiTieuXetNghiem_LAB.UnitValue, " +
            //             " tbl_NhomChiTieuXetNghiem_LAB.NCTXN, tbl_NhomChiTieuXetNghiem_LAB.NCTXNDG, tbl_NhomChiTieuXetNghiem_LAB.NhomChung, tbl_PhuongPhapXetNghiem_LAB.PPXN, tbl_PhuongPhapXetNghiem_LAB.PPXNDG, " +
            //             " tbl_KHMau_CTXN_LAB.KHMau AS Expr1, tbl_KHMau_CTXN_LAB.DonGia, tbl_KHMau_CTXN_LAB.ThanhTien, tbl_KHMau_CTXN_LAB.KetQua, tbl_KHMau_CTXN_LAB.SoLuongDat, tbl_KHMau_CTXN_LAB.VAT, tbl_KHMau_CTXN_LAB.SoLuongXN " +
            //             " FROM            tbl_KHMau_LAB LEFT JOIN " +
            //             " tbl_KHMau_CTXN_LAB ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau LEFT JOIN " +
            //             " tbl_ChiTieuXetNghiem_LAB ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID LEFT JOIN " +
            //             " tbl_NhomChiTieuXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID LEFT JOIN " +
            //             " tbl_PhuongPhapXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.PPXNID = tbl_PhuongPhapXetNghiem_LAB.ID " +
            //             " WHERE tbl_KHMau_LAB.SoPXN ='" + SoPXN + "' and TrangThaiKHMau = '0'" +
            //             "  GROUP BY tbl_KHMau_LAB.ID, tbl_KHMau_LAB.SoPXN, tbl_KHMau_LAB.CreatedDate, tbl_KHMau_LAB.CreatedBy, tbl_KHMau_LAB.Locked, tbl_KHMau_LAB.Note, tbl_KHMau_LAB.KHMau,tbl_KHMau_LAB.KHMau_KhachHang, tbl_KHMau_LAB.SoLuongKHMau, " +
            //             " tbl_KHMau_LAB.DonViKHMau, tbl_KHMau_LAB.PhuongPhapBaoQuan, tbl_KHMau_LAB.VitriLuuKHMau, tbl_KHMau_LAB.NgayLuuKHMau, tbl_KHMau_LAB.NhanVienLuuKHMau, tbl_KHMau_LAB.NgayHuyKHMau, " +
            //             " tbl_KHMau_LAB.TaiLieuHuyKHMau, tbl_KHMau_LAB.NhanVienHuyKHMau, tbl_KHMau_LAB.TrangThaiKHMau, tbl_KHMau_LAB.SoLuongHuyKHMau, tbl_ChiTieuXetNghiem_LAB.CTXN, " +
            //             " tbl_ChiTieuXetNghiem_LAB.CTXNDG, tbl_ChiTieuXetNghiem_LAB.CTXNDGTA, tbl_ChiTieuXetNghiem_LAB.MinValue, tbl_ChiTieuXetNghiem_LAB.MaxValue, tbl_ChiTieuXetNghiem_LAB.UnitValue, " +
            //             " tbl_NhomChiTieuXetNghiem_LAB.NCTXN, tbl_NhomChiTieuXetNghiem_LAB.NCTXNDG, tbl_NhomChiTieuXetNghiem_LAB.NhomChung, tbl_PhuongPhapXetNghiem_LAB.PPXN, tbl_PhuongPhapXetNghiem_LAB.PPXNDG, " +
            //             " tbl_KHMau_CTXN_LAB.KHMau , tbl_KHMau_CTXN_LAB.DonGia, tbl_KHMau_CTXN_LAB.ThanhTien, tbl_KHMau_CTXN_LAB.KetQua, tbl_KHMau_CTXN_LAB.SoLuongDat, tbl_KHMau_CTXN_LAB.VAT ", CommandType.Text);
            return Sql.ExecuteDataTable("SAP", " SELECT        tbl_KHMau_LAB.ID, tbl_KHMau_LAB.SoPXN, tbl_KHMau_LAB.KHMau, tbl_KHMau_LAB.SoLuongKHMau,   " +
                " tbl_KHMau_LAB.PhuongPhapBaoQuan, tbl_KHMau_LAB.VitriLuuKHMau, tbl_KHMau_LAB.NhanVienLuuKHMau, tbl_KHMau_LAB.NgayLuuKHMau,tbl_KHMau_LAB.LuuMau  " +
                " FROM            tbl_KHMau_LAB LEFT JOIN   " +
                " tbl_KHMau_CTXN_LAB ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau  " +
                " WHERE tbl_KHMau_LAB.SoPXN ='" + SoPXN + "' and TrangThaiKHMau = '0'  " +
                " GROUP BY tbl_KHMau_LAB.ID, tbl_KHMau_LAB.SoPXN,  tbl_KHMau_LAB.KHMau, tbl_KHMau_LAB.SoLuongKHMau,   " +
                " tbl_KHMau_LAB.PhuongPhapBaoQuan, tbl_KHMau_LAB.VitriLuuKHMau, tbl_KHMau_LAB.NhanVienLuuKHMau, tbl_KHMau_LAB.NgayLuuKHMau,tbl_KHMau_LAB.LuuMau   ", CommandType.Text);
        }

        public DataTable KHMau_LABDAO_REPORT_KHMAU(string SoPXN)
        {
            return Sql.ExecuteDataTable("SAP", " SELECT        tbl_KHMau_LAB.ID,tbl_KHMau_LAB.LoaiDVMauNuoc,tbl_KHMau_LAB.NgayLayMau,tbl_KHMau_LAB.LoaiMauGui,tbl_KHMau_LAB.TTMauGui,tbl_KHMau_LAB.VTLayMauDayChuong,tbl_KHMau_LAB.GioLayMauTuoi ,   " +
                " tbl_KHMau_LAB.SoPXN, tbl_KHMau_LAB.CreatedDate, tbl_KHMau_LAB.CreatedBy, tbl_KHMau_LAB.Locked, tbl_KHMau_LAB.Note, tbl_KHMau_LAB.KHMau,tbl_KHMau_LAB.KHMau_KhachHang, tbl_KHMau_LAB.SoLuongKHMau, " +
                         " tbl_KHMau_LAB.DonViKHMau, tbl_KHMau_LAB.PhuongPhapBaoQuan, tbl_KHMau_LAB.VitriLuuKHMau, tbl_KHMau_LAB.NgayLuuKHMau, tbl_KHMau_LAB.NhanVienLuuKHMau, tbl_KHMau_LAB.NgayHuyKHMau, " +
                         " tbl_KHMau_LAB.TaiLieuHuyKHMau, tbl_KHMau_LAB.NhanVienHuyKHMau, tbl_KHMau_LAB.TrangThaiKHMau, tbl_KHMau_LAB.SoLuongHuyKHMau, tbl_ChiTieuXetNghiem_LAB.CTXN, " +
                         " tbl_ChiTieuXetNghiem_LAB.CTXNDG, tbl_ChiTieuXetNghiem_LAB.CTXNDGTA, tbl_ChiTieuXetNghiem_LAB.MinValue, tbl_ChiTieuXetNghiem_LAB.MaxValue, tbl_ChiTieuXetNghiem_LAB.UnitValue, " +
                         " tbl_NhomChiTieuXetNghiem_LAB.NCTXN, tbl_NhomChiTieuXetNghiem_LAB.NCTXNDG, tbl_NhomChiTieuXetNghiem_LAB.NhomChung, tbl_PhuongPhapXetNghiem_LAB.PPXN, tbl_PhuongPhapXetNghiem_LAB.PPXNDG, " +
                         " tbl_KHMau_CTXN_LAB.KHMau AS Expr1, tbl_KHMau_CTXN_LAB.DonGia, tbl_KHMau_CTXN_LAB.ThanhTien, tbl_KHMau_CTXN_LAB.KetQua, tbl_KHMau_CTXN_LAB.SoLuongDat, tbl_KHMau_CTXN_LAB.VAT,tbl_KHMau_LAB.LuuMau,tbl_KHMau_LAB.HuyMau " +
                         " FROM            tbl_KHMau_LAB LEFT JOIN " +
                         " tbl_KHMau_CTXN_LAB ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau LEFT JOIN " +
                         " tbl_ChiTieuXetNghiem_LAB ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID LEFT JOIN " +
                         " tbl_NhomChiTieuXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID LEFT JOIN " +
                         " tbl_PhuongPhapXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.PPXNID = tbl_PhuongPhapXetNghiem_LAB.ID " +
                         " WHERE tbl_KHMau_LAB.SoPXN ='" + SoPXN + "'", CommandType.Text);
        }

        public DataTable KHMau_LABDAO_REPORT_AnalysisReport(string SoPXN,int CTXNID,string KHMau_GiaoMau)
        {
            return Sql.ExecuteDataTable("SAP", " SELECT        tbl_KHMau_LAB.ID,tbl_KHMau_LAB.LoaiDVMauNuoc,tbl_KHMau_LAB.NgayLayMau,tbl_KHMau_LAB.LoaiMauGui,tbl_KHMau_LAB.TTMauGui,tbl_KHMau_LAB.VTLayMauDayChuong,tbl_KHMau_LAB.GioLayMauTuoi ,   " +
                " tbl_KHMau_LAB.SoPXN, tbl_KHMau_LAB.CreatedDate, tbl_KHMau_LAB.CreatedBy, tbl_KHMau_LAB.Locked, tbl_KHMau_LAB.Note, tbl_KHMau_LAB.KHMau,tbl_KHMau_LAB.KHMau_KhachHang, tbl_KHMau_LAB.SoLuongKHMau, " +
                " tbl_LoaiDV_LAB.TenLoaiDV,tbl_LoaiMau_LAB.TenLoaiMau, " +
                " tbl_KHMau_LAB.DonViKHMau, tbl_KHMau_LAB.PhuongPhapBaoQuan, tbl_KHMau_LAB.VitriLuuKHMau, tbl_KHMau_LAB.NgayLuuKHMau, tbl_KHMau_LAB.NhanVienLuuKHMau, tbl_KHMau_LAB.NgayHuyKHMau,tbl_KHMau_LAB.LuuMau,tbl_KHMau_LAB.HuyMau, " +
                         " tbl_KHMau_LAB.TaiLieuHuyKHMau, tbl_KHMau_LAB.NhanVienHuyKHMau, tbl_KHMau_LAB.TrangThaiKHMau, tbl_KHMau_LAB.SoLuongHuyKHMau, tbl_ChiTieuXetNghiem_LAB.CTXN, " +
                         " tbl_ChiTieuXetNghiem_LAB.CTXNDG, tbl_ChiTieuXetNghiem_LAB.CTXNDGTA, tbl_ChiTieuXetNghiem_LAB.MinValue, tbl_ChiTieuXetNghiem_LAB.MaxValue, tbl_ChiTieuXetNghiem_LAB.UnitValue, " +
                         " tbl_NhomChiTieuXetNghiem_LAB.NCTXN, tbl_NhomChiTieuXetNghiem_LAB.NCTXNDG, tbl_NhomChiTieuXetNghiem_LAB.NhomChung, tbl_PhuongPhapXetNghiem_LAB.PPXN, tbl_PhuongPhapXetNghiem_LAB.PPXNDG, " +
                         " tbl_KHMau_CTXN_LAB.NgayCoKetQua,tbl_KHMau_CTXN_LAB.NgayTraKetQua,tbl_KHMau_CTXN_LAB.SoLuongXN,tbl_KHMau_CTXN_LAB.CTXNID,tbl_KHMau_CTXN_LAB.KHMau AS Expr1, tbl_KHMau_CTXN_LAB.DonGia, tbl_KHMau_CTXN_LAB.ThanhTien, tbl_KHMau_CTXN_LAB.KetQua, tbl_KHMau_CTXN_LAB.SoLuongDat, tbl_KHMau_CTXN_LAB.VAT, " +
                         " tbl_ChiTieuXetNghiem_LAB.Acronym " +
                         " FROM            tbl_KHMau_LAB LEFT JOIN " +
                         " tbl_KHMau_CTXN_LAB ON tbl_KHMau_LAB.KHMau = tbl_KHMau_CTXN_LAB.KHMau LEFT JOIN " +
                         " tbl_ChiTieuXetNghiem_LAB ON tbl_KHMau_CTXN_LAB.CTXNID = tbl_ChiTieuXetNghiem_LAB.ID LEFT JOIN " +
                         " tbl_NhomChiTieuXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.NCTXNID = tbl_NhomChiTieuXetNghiem_LAB.ID LEFT JOIN " +
                         " tbl_PhuongPhapXetNghiem_LAB ON tbl_ChiTieuXetNghiem_LAB.PPXNID = tbl_PhuongPhapXetNghiem_LAB.ID " +
                         " LEFT JOIN tbl_LoaiDV_LAB ON  tbl_KHMau_LAB.LoaiDVMauNuoc = tbl_LoaiDV_LAB.MaLoaiDV " +
                         " LEFT JOIN tbl_LoaiMau_LAB ON tbl_KHMau_LAB.LoaiMauGui = tbl_LoaiMau_LAB.MaLoaiMau " +
                         " WHERE tbl_KHMau_LAB.SoPXN ='" + SoPXN + "' and tbl_KHMau_CTXN_LAB.CTXNID= "+CTXNID+" and tbl_KHMau_LAB.KHMau_GiaoMau = '"+ KHMau_GiaoMau + "'", CommandType.Text);
        }
        public DataTable KHMau_LABDAO_SELECT_KHMau(string SoPXN, string KHMau)
        {
            return Sql.ExecuteDataTable("SAP", " SELECT KHMau " +
                         " FROM            tbl_KHMau_LAB  " +
                         " WHERE tbl_KHMau_LAB.SoPXN ='" + SoPXN + "' and tbl_KHMau_LAB.KHMau <> '" + KHMau + "'", CommandType.Text);
        }

    }
}