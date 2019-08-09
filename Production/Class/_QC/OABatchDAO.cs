using System;
using System.Data;

namespace Production.Class
{
    public class OABatchDAO
    {
        //public DataTable Branch_SelectAll()
        //{            
        //    return Sql.ExecuteDataTable("Branch_SelectAll", CommandType.StoredProcedure);            
        //}

        public bool OABatch_Visible(string OABatch)
        {
            DataTable dt = new DataTable();
            dt =Sql.ExecuteDataTable("SAP", "SELECT [OA BATCH] FROM [SYNC_NUTRICIEL].[dbo].[tbl_OABatch] where [OA BATCH]='" + OABatch + "'", CommandType.Text);
            return dt.Rows.Count > 0 ? true : false;       
        }

        public DataTable Lot_Number_Visible(string LotNumber)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT [OA BATCH] FROM [SYNC_NUTRICIEL].[dbo].[tbl_OABatch] where [Lot Number]='" + LotNumber + "'  GROUP BY [OA BATCH]  ", CommandType.Text);
            return dt;
        }

        public DataTable OABatch_Report_byItem(string OABatch)
        {            
            return Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_OABatch] where [OA BATCH]='" + OABatch + "'", CommandType.Text);
        }

        public DataTable OABatch_View()
        {
            return Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_OABatch]", CommandType.Text);
        }

        public DataTable OABatch_Report_byDate(string FrDate, string ToDate)
        {
            return Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_OABatch] where [Received date] between '" + FrDate + "' and '" + ToDate + "'", CommandType.Text);
        }
        

        public void OABatch_INSERT(DataRow dr)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_OABatch]" +
           "([OA BATCH]" +
           ",[Received date]" +
           ",[Times of receiving in day]" +
           ",[Item Code]" +
           ",[Name of Raw material]" +
           ",[Note on name]" +
           ",[Lot number]" +
           ",[Manufacturing date]" +
           ",[Expiry date]" +
           ",[Supplier code]" +
           ",[Name of supplier]" +
           ",[Note]" +
           ",[Quantity]"+
           ")" +
     "VALUES" +
           "(N'" + dr["OA BATCH"].ToString() +
           //"','" + DateTime.Parse(dr["Received date"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")) +
                //--------------------------Lưu ý -------------------------------------------------------
                // Do cell trong file excel import la MM/dd/yyyy nên phải cắt và ghép chuỗi
                //---------------------------------------------------------------------------------------
           "',N'" + (DateTime.Parse(dr["Received date"].ToString()).Month.ToString() +
                            "/" + DateTime.Parse(dr["Received date"].ToString()).Day.ToString() +
                            "/" + DateTime.Parse(dr["Received date"].ToString()).Year.ToString()).ToString() +
           "',N'" + dr["Times of receiving in day"].ToString() +
           "',N'" + dr["Item Code"].ToString() +
           "',N'" + dr["Name of Raw material"].ToString() +
           "',N'" + dr["Note on name"].ToString() +
           "',N'" + dr["Lot number"].ToString() +
           //"','" + DateTime.Parse(dr["Manufacturing date"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")) +
           //"','" + DateTime.Parse(dr["Expiry date"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")) +
           "',N'" + DateTime.Parse((DateTime.Parse(dr["Manufacturing date"].ToString()).Month.ToString() +
                            "/" + DateTime.Parse(dr["Manufacturing date"].ToString()).Day.ToString() +
                            "/" + DateTime.Parse(dr["Manufacturing date"].ToString()).Year.ToString()).ToString()) +
           "',N'" + DateTime.Parse((DateTime.Parse(dr["Expiry date"].ToString()).Month.ToString() +
                            "/" + DateTime.Parse(dr["Expiry date"].ToString()).Day.ToString() +
                            "/" + DateTime.Parse(dr["Expiry date"].ToString()).Year.ToString()).ToString()) +           
           "',N'" + dr["Supplier code"].ToString() +
           "',N'" + dr["Name of supplier"].ToString() +
           "',N'" + dr["Note"].ToString() +
           "'," + float.Parse(dr["Quantity"].ToString().Length == 0 ? "0" : dr["Quantity"].ToString()) + 
           ")", CommandType.Text);
        }
        //public void OF_INSERT(DataRow dr)
        //{
            
        //}

        //public void OF_UPDATE(string CD_OF, float ManufacturedQty, string MINStart, string MAXEnd, string Formula, int TotalBatch)
        //{
        //    Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_OF] SET" +
        //   "[ManufacturedQty] = " + ManufacturedQty  +
        //   ",[Start] = '" + MINStart + "' " +
        //   ",[End] = '" + MAXEnd + "'" +
        //   ",[Formula] = '" + Formula + "' " +
        //   ",[TotalBatch] = " + TotalBatch +
        //   " WHERE [CD_OF]='"+CD_OF+"'", CommandType.Text);
        //}
    }

}


