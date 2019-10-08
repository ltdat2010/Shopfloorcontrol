using System.Data;

namespace Production.Class._LAB.RESULT
{
    internal class HUYETTHANHHOC_STD_VALUEDAO
    {
        public DataTable IBD_RESULT_Header_LABDAO_SELECT()
        {
            return Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_HUYETTHANHHOC_STD_VALUE] ", CommandType.Text);
        }

        public DataTable IBD_RESULT_Header_LABDAO_SELECT_ByCTXNID(int CTXNID)
        {
            return Sql.ExecuteDataTable("SAP", "SELECT TEST_SOFTWARE_CTXN_NAME FROM [SYNC_NUTRICIEL].[dbo].[tbl_HUYETTHANHHOC_STD_VALUE] " +
                "WHERE CTXN_ID=" + CTXNID + " GROUP BY TEST_SOFTWARE_CTXN_NAME", CommandType.Text);
        }
    }
}