using System;
using System.Data;

namespace Production.Class
{
    public class PRDAO
    {
        //SELECT CODE

        //SELECT ALL

        //INSERT

        //UPDATE

        //DELETE

        public DataTable SP_MAX_PRNO()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT MAX([SYNC_NUTRICIEL].dbo.tbl_PR.PRNO) + 1 as PRNO FROM [SYNC_NUTRICIEL].dbo.tbl_PR ", CommandType.Text);
            return dt;
        }

        public DataTable SP_PR_Detail_parms(string PRNO)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT * 	FROM [SYNC_NUTRICIEL].dbo.tbl_PR_Detail  WHERE PRNO = '" + PRNO + "' ", CommandType.Text);
            return dt;
        }

        public void PR_INSERT(
            string PRNO
           , string RequestDept
           , DateTime RequestDate
           , DateTime DueDate
           , string RequestReason
           , string CreatedBy
           , DateTime CreatedDate
           , string CheckedBy
           , DateTime CheckedDate
           , string ApprovedBy
           , DateTime ApprovedDate)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [dbo].[tbl_PR] " +
           "([PRNO] " +
           ",[RequestDept] " +
           ",[RequestDate] " +
           ",[DueDate] " +
           ",[RequestReason] " +
           ",[CreatedBy] " +
           ",[CreatedDate] " +
           ",[CheckedBy] " +
           ",[CheckedDate] " +
           ",[ApprovedBy] " +
           ",[ApprovedDate]) " +
     "VALUES" +
           "('" + PRNO.ToString() + "'" +
           ",'" + RequestDept.ToString() + "'" +
           ",'" + RequestDate.ToString() + "'" +
           ",'" + DueDate.ToString() + "'" +
           ",'" + RequestReason.ToString() + "'" +
           ",'" + CreatedBy.ToString() + "'" +
           ",'" + CreatedDate.ToString() + "'" +
           ",'" + CheckedBy.ToString() + "'" +
           ",'" + CheckedDate.ToString() + "'" +
           ",'" + ApprovedBy.ToString() + "'" +
           ",'" + ApprovedDate.ToString() + "'" +
            ")", CommandType.Text);
        }

        public void PR_Detail_INSERT(DataRow dr)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [dbo].[tbl_PR_Detail]" +
           "([PRNO] " +
           ",[Line] " +
           ",[ItemCode] " +
           ",[InStock] " +
           ",[Quantity] " +
           ",[UoM] " +
           ",[Note]) " +
     "VALUES " +
           "('" + dr["PRNO"].ToString() + "'" +
           ",'" + dr["Line"].ToString() + "'" +
           ",'" + dr["ItemCode"].ToString() + "'" +
           "," + float.Parse(dr["InStock"].ToString()) +
           "," + float.Parse(dr["Quantity"].ToString()) +
           ",'" + dr["UoM"].ToString() + "'" +
           ",'" + dr["Note"].ToString() + "'" +
           ")", CommandType.Text);
        }

        //public DataTable SP_MAX_PRNO()
        //{
        //    DataTable dt = new DataTable();
        //    dt = Sql.ExecuteDataTable("SAP", "SELECT MAX([SYNC_NUTRICIEL].dbo.tbl_PR.PRNO) + 1 as PRNO FROM [SYNC_NUTRICIEL].dbo.tbl_PR ", CommandType.Text);
        //    return dt;
        //}
        //   public void OF_INSERT(DataRow dr)
        //   {
        //       Sql.ExecuteNonQuery("SAP", "INSERT INTO [dbo].[tbl_OF]" +
        //      "([CD_OF]" +
        //      ",[DT_PREV]" +
        //      ",[CD_MAT]" +
        //      ",[LB_MAT]" +
        //      ",[QT_PREV]" +
        //      ")" +
        //"VALUES" +
        //      "('" + dr["CD_OF"].ToString() +
        //      "','" + DateTime.Parse(dr["DT_PREV"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")) +
        //      "','" + dr["CD_MAT"].ToString() +
        //      "','" + dr["LB_MAT"].ToString() +
        //      "'," + dr["QT_PREV"] +
        //      ")", CommandType.Text);
        //   }
    }
}