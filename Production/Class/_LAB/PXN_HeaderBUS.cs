using System;
using System.Data;

namespace Production.Class
{
    public class PXN_HeaderBUS
    {
        private PXN_HeaderDAO DAO = new PXN_HeaderDAO();

        public void PXN_HeaderBUS_INSERT(PXN_Header OBJ)
        {
            DAO.PXN_HeaderDAO_INSERT(OBJ);
        }

        public void PXN_HeaderBUS_UPDATE(PXN_Header OBJ)
        {
            DAO.PXN_HeaderDAO_UPDATE(OBJ);
        }

        public DataTable PXN_Header_SELECT()
        {
            return DAO.PXN_Header_SELECT();
        }

        public void PXN_HeaderDAO_UPDATE_SendMail(int ID, string SendMail)
        {
            DAO.PXN_HeaderDAO_UPDATE_SendMail(ID, SendMail);
        }

        public void PXN_HeaderDAO_UPDATE_NgayCoKetQua(int ID, DateTime NgayCoKetQua, bool CoKetQua)
        {
            DAO.PXN_HeaderDAO_UPDATE_NgayCoKetQua(ID, NgayCoKetQua, CoKetQua);
        }

        public void PXN_HeaderDAO_UPDATE_NgayTraKetQua(int ID, DateTime NgayTraKetQua, bool TraKetQua)
        {
            DAO.PXN_HeaderDAO_UPDATE_NgayTraKetQua(ID, NgayTraKetQua, TraKetQua);
        }

        public void PXN_HeaderBUS_DELETE(PXN_Header OBJ)
        {
            DAO.PXN_HeaderDAO_DELETE(OBJ);
        }

        public DataTable PXN_HeaderBUS_SELECT(string SoPXN)
        {
            return DAO.PXN_HeaderDAO_SELECT(SoPXN);
        }

        public int MAX_PXN_HeaderBUS_ID()
        {
            return DAO.MAX_PXN_HeaderDAO_ID();
        }

        public int PXN_HeaderDAO_ID_bySoPXN(string SoPXN)
        {
            return DAO.PXN_HeaderDAO_ID_bySoPXN(SoPXN);
        }

        public DataTable BaoCaoPXN_Nhan(DateTime Stardate, DateTime Enddate)
        {
            return DAO.BaoCaoPXN_Nhan(Stardate, Enddate);
        }

        public DataTable BaoCaoPXN_Nhan_Export2Excel(DateTime Stardate, DateTime Enddate)
        {
            return DAO.BaoCaoPXN_Nhan_Export2Excel(Stardate, Enddate);
        }

        public DataTable BaoCaoPXN_ChuaTra(DateTime Stardate, DateTime Enddate)
        {
            return DAO.BaoCaoPXN_ChuaTra(Stardate, Enddate);
        }

        public DataTable BaoCaoPXN_ChuaTra_Export2Excel(DateTime Stardate, DateTime Enddate)
        {
            return DAO.BaoCaoPXN_ChuaTra_Export2Excel(Stardate, Enddate);
        }

        public DataTable BaoCaoPXN_DaTra(DateTime Stardate, DateTime Enddate)
        {
            return DAO.BaoCaoPXN_DaTra(Stardate, Enddate);
        }

        public DataTable BaoCaoPXN_DaTra_Export2Excel(DateTime Stardate, DateTime Enddate)
        {
            return DAO.BaoCaoPXN_DaTra_Export2Excel(Stardate, Enddate);
        }

        public DataTable BaoCaoDichTeDan_Thang_xport2Excel(string month, string year)
        {
            return DAO.BaoCaoDichTeDan_Thang_xport2Excel(month, year);
        }

        public DataTable BaoCaoDoanhSo_Thang(DateTime Stardate, DateTime Enddate)
        {
            return DAO.BaoCaoDoanhSo_Thang(Stardate, Enddate);
        }

        public DataTable BaoCaoCongNo(DateTime Stardate, DateTime Enddate)
        {
            return DAO.BaoCaoCongNo(Stardate, Enddate);
        }

        public int Result_PXN_Header_SoPXN(string LoaiXN)
        {
            return DAO.Result_PXN_Header_SoPXN(LoaiXN);
        }

        public void PXN_HeaderDAO_UPDATE_NgayTraKetQua(string SoPXN)
        {
            DAO.PXN_HeaderDAO_UPDATE_NgayTraKetQua(SoPXN);
        }

        public void PXN_HeaderDAO_UPDATE_MaCoSoLayMau(string CUSTCODE_Old, string CUSTCODE_New)
        {
            DAO.PXN_HeaderDAO_UPDATE_MaCoSoLayMau(CUSTCODE_Old, CUSTCODE_New);
        }

        public DataTable BaoCao_NhanMau_Daily(int i)
        {
            return DAO.BaoCao_NhanMau_Daily(i);
        }

        public DataTable BaoCao_NhanMau_Weekly(int i)
        {
            return DAO.BaoCao_NhanMau_Weekly(i);
        }

        public DataTable BaoCao_NhanMau_Monthly(int i)
        {
            return DAO.BaoCao_NhanMau_Monthly(i);
        }

        public DataTable BaoCao_NhanMau_Quaterly(int i)
        {
            return DAO.BaoCao_NhanMau_Quaterly(i);
        }

        public DataTable BaoCao_NhanMau_Yearly(int i)
        {
            return DAO.BaoCao_NhanMau_Yearly(i);
        }

        public DataTable BaoCao_NhanMau_Fr_To_Date(DateTime Stardate, DateTime Enddate)
        {
            return DAO.BaoCao_NhanMau_Fr_To_Date(Stardate, Enddate);
        }

        public void PXN_HeaderDAO_UPDATE_NgayGiaoMau(int ID, DateTime NgayGiaoMau, bool GiaoMau, string NguoiGiaoMau)
        {
            DAO.PXN_HeaderDAO_UPDATE_NgayGiaoMau(ID, NgayGiaoMau, GiaoMau, NguoiGiaoMau);
        }
    }
}