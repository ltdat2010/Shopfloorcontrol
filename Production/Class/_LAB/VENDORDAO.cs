using System.Data;

namespace Production.Class
{
    public class VENDORDAO
    {
        public DataTable VENDOR_SELECT()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "Select * from [SYNC_NUTRICIEL].[dbo].[V_VENDOR] ", CommandType.Text);
            return dt;
        }
    }
}