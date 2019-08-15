using System.Data;

namespace Production.Class
{
    public class BATCHDAO
    {
        //public DataTable Branch_SelectAll()
        //{
        //    return Sql.ExecuteDataTable("Branch_SelectAll", CommandType.StoredProcedure);
        //}

        //public DataTable Branch_GetByID(string BranchID)
        //{
        //    return Sql.ExecuteDataTable("Branch_GetByID", CommandType.StoredProcedure, "BranchID", BranchID);
        //}

        public DataTable BATCH_List()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", " SELECT [SYNC_NUTRICIEL].dbo.tbl_BATCH.[No]" +
                                                      ",[SYNC_NUTRICIEL].dbo.tbl_BATCH.[CD_OF]" +
                                                      ",[SYNC_NUTRICIEL].dbo.tbl_BATCH.[Batch]" +
                                                      ",[SYNC_NUTRICIEL].dbo.tbl_BATCH.[Start]" +
                                                      ",[SYNC_NUTRICIEL].dbo.tbl_BATCH.[End]" +
                                                      ",[SYNC_NUTRICIEL].dbo.tbl_BATCH.[ItemCode]" +
                                                      ",[SYNC_NUTRICIEL].dbo.tbl_BATCH.[ItemDescription]" +
                                                      ",[SYNC_NUTRICIEL].dbo.tbl_BATCH.[Formula]" +
                                                      ",[SYNC_NUTRICIEL].dbo.tbl_BATCH.[Version]" +
                                                      ",[SYNC_NUTRICIEL].dbo.tbl_BATCH.[PlannedQty]" +
                                                      ",[SYNC_NUTRICIEL].dbo.tbl_BATCH.[ManufacturedQty]" +
                                                      ",[SYNC_NUTRICIEL].dbo.tbl_BATCH.[Destination]" +
                                                      ",[SYNC_NUTRICIEL].dbo.tbl_BATCH.[PrepareBatchNb]" +
                                                      ",[SYNC_NUTRICIEL].dbo.tbl_BATCH.[TotalBatchNb]" +
                                                  "FROM [SYNC_NUTRICIEL].dbo.tbl_BATCH ", CommandType.Text);
            return dt;
        }

        public DataTable MINStart_MAXEnd_Date(string CD_OF)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", " SELECT MIN([SYNC_NUTRICIEL].dbo.tbl_BATCH.[Start]) as MINStart " +
                                                     ",MAX([SYNC_NUTRICIEL].dbo.tbl_BATCH.[End]) as MAXEnd " +
                                                     ",SUM([SYNC_NUTRICIEL].dbo.tbl_BATCH.[ManufacturedQty]) as ManufacturedQty " +
                                                     ",[SYNC_NUTRICIEL].dbo.tbl_BATCH.Formula " +
                                                     ",[SYNC_NUTRICIEL].dbo.tbl_BATCH.TotalBatchNb " +
                                                    " FROM [SYNC_NUTRICIEL].dbo.tbl_BATCH " +
                                                    " WHERE [SYNC_NUTRICIEL].dbo.tbl_BATCH.[CD_OF]='" + CD_OF + "' GROUP BY [SYNC_NUTRICIEL].dbo.tbl_BATCH.Formula ,[SYNC_NUTRICIEL].dbo.tbl_BATCH.TotalBatchNb ", CommandType.Text);
            return dt;
        }

        public DataTable BATCH_Details(string CD_OF)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "select [ASIALAND].dbo.OWOR.DocNum as CD_OF,FG_STATUS = '1', CONVERT(varchar(10),[ASIALAND].dbo.OWOR.DueDate,103) as DT_PREV,CD_DEPOT='891',[ASIALAND].dbo.OWOR.ItemCode as CD_MAT,[ASIALAND].dbo.OITM.ItemName as LB_MAT,CAST([ASIALAND].dbo.OWOR.PlannedQty as numeric(18,0)) as QT_PREV, [ASIALAND].dbo.OITM.InvntryUom as CD_UNIT,NO_ORDRE='1000',T.CD_MAT1 AS CD_MAT1 ,CAST(T.QT_DOSE as numeric(18,0)) AS QT_DOSE,CD_VER ='89' from [ASIALAND].dbo.OWOR inner join [ASIALAND].dbo.OITM on [ASIALAND].dbo.OWOR.ItemCode = [ASIALAND].dbo.OITM.ItemCode inner join (select [ASIALAND].dbo.WOR1.DocEntry,[ASIALAND].dbo.WOR1.ItemCode as CD_MAT1,CAST([ASIALAND].dbo.WOR1.PlannedQty as numeric(18,0)) as QT_DOSE, [ASIALAND].dbo.WOR1.U_NBS_LossRow as LOSS_COMP from [ASIALAND].dbo.WOR1 inner join [ASIALAND].dbo.OITM on [ASIALAND].dbo.WOR1.ItemCode = [ASIALAND].dbo.OITM.ItemCode where OITM.InvntryUom ='KG' ) as T on [ASIALAND].dbo.OWOR.DocNum = T.DocEntry Where [ASIALAND].dbo.OWOR.DocNum = '" + CD_OF + "'", CommandType.Text);
            return dt;
        }

        public DataTable BATCH_Find(string BATCH)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", " SELECT [CD_OF],[Batch] FROM [SYNC_NUTRICIEL].[dbo].[tbl_BATCH] Where [Batch] =  '" + BATCH + "'", CommandType.Text);
            return dt;
        }

        public DataTable BATCH_View()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "SELECT [CD_OF],[Batch],[Start],[End],[ItemCode],[ItemDescription],[Formula],[Version],[PlannedQty],[ManufacturedQty],[Destination],[PrepareBatchNb],[TotalBatchNb] FROM [SYNC_NUTRICIEL].[dbo].[tbl_BATCH] ORDER BY [CD_OF] DESC", CommandType.Text);
            return dt;
        }

        public void BATCH_INSERT(DataRow dr)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_BATCH]" +
           "([CD_OF]" +
           ",[Batch]" +
           ",[Start]" +
           ",[End]" +
           ",[ItemCode]" +
           ",[ItemDescription]" +
           ",[Formula]" +
           ",[Version]" +
           ",[PlannedQty]" +
           ",[ManufacturedQty]" +
           ",[Destination]" +
           ",[PrepareBatchNb]" +
           ",[TotalBatchNb])" +
     "VALUES " +
           "('" + dr["WO"].ToString() +
           "','" + dr["Batch"].ToString() +
           "','" + dr["Start"].ToString() +
           "','" + dr["End"].ToString() +
           "','" + dr["Code"].ToString() +
           "','" + dr["Product"].ToString() +
           "','" + dr["Formula"].ToString() +
           "','" + dr["Version"].ToString() +
           "'," + dr["Planned Qty"] +
           "," + dr["Manufactured Qty"] +
           ",'" + dr["Destination"].ToString() +
           "'," + dr["Prepare Batch Nb"] +
           "," + dr["Total Batch Nb"] + ")", CommandType.Text);
            //       Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_OF_Detail]" +
            //      "([CD_OF]" +
            //      ",[FG_STATUS]" +
            //      ",[DT_PREV]" +
            //      ",[CD_DEPOT]" +
            //      ",[CD_MAT]" +
            //      ",[LB_MAT]" +
            //      ",[QT_PREV]" +
            //      ",[CD_UNIT]" +
            //      ",[NO_ORDRE]" +
            //      ",[CD_MAT1]" +
            //      ",[QT_DOSE]" +
            //      ",[CD_VER]" +
            //      ",[LOSS_COMP])" +
            //"VALUES" +
            //      "(" + dr["CD_OF"] +
            //      ",'" + 1 +
            //      "','" + DateTime.Parse(dr["DT_PREV"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")) +
            //      "','" + 891 +
            //      "','" + dr["CD_MAT"].ToString() +
            //      "','" + dr["LB_MAT"].ToString() +
            //      "'," + dr["QT_PREV"] +
            //      ",'" + dr["CD_UNIT"].ToString() +
            //      "','" + 1000 +
            //      "','" + dr["CD_MAT1"].ToString() +
            //      "'," + dr["QT_DOSE"] +
            //      ",'" + 89 +
            //      "'," + dr["LOSS_COMP"]+
            //      ")", CommandType.Text);
        }

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