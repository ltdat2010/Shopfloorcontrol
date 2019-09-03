using System;
using System.Data;
using Production.Class._LAB.RESULT;

namespace Production.Class
{
    public class IBD_RESULT_Header_LABBUS
    {
        IBD_RESULT_Header_LABDAO DAO = new IBD_RESULT_Header_LABDAO();
        public int IBD_RESULT_Header_LABDAO_INSERT(IBD_RESULT_Header_LAB OBJ)
        {
            return DAO.IBD_RESULT_Header_LABDAO_INSERT(OBJ);
        }

        public void IBD_RESULT_Header_LABDAO_UPDATE(IBD_RESULT_Header_LAB OBJ)
        {
            DAO.IBD_RESULT_Header_LABDAO_UPDATE(OBJ);
        }

        public void IBD_RESULT_Header_LABDAO_DELETE(int ID)
        {
            DAO.IBD_RESULT_Header_LABDAO_DELETE(ID);
        }

        //public int MYCOTOXIN_RESULT_Header_ID(string FilePath)
        //{
        //    DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_Header_LAB] " +
        //        "WHERE FilePath='" + FilePath + "'", CommandType.Text);
        //    return int.Parse(dt.Rows[0]["ID"].ToString());
        //}

        public DataTable IBD_RESULT_Header_LABDAO_SELECT(string KHMau_BanGiao, int CTXNID)
        {
            return DAO.IBD_RESULT_Header_LABDAO_SELECT(KHMau_BanGiao, CTXNID);
        }

        public DataTable BaoCao_HuyetThanhHoc_IBD(string year, int CTXNID)
        {
            return DAO.BaoCao_HuyetThanhHoc_IBD(year, CTXNID);
        }
    }
}