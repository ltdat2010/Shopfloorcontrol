using System;
using System.Data;
using System.Globalization;

namespace Production.Class
{
    public class RECEIPTDAO
    {
        //public DataTable Branch_SelectAll()
        //{
        //    return Sql.ExecuteDataTable("Branch_SelectAll", CommandType.StoredProcedure);
        //}

        //public DataTable Branch_GetByID(string BranchID)
        //{
        //    return Sql.ExecuteDataTable("Branch_GetByID", CommandType.StoredProcedure, "BranchID", BranchID);
        //}

        public DataTable RECEIPT_List()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "Select [ASIALAND].dbo.OPDN.DocEntry as ECH_RECEPS,[ASIALAND].dbo.OPDN.Comments as ECH_RECEP from [ASIALAND].dbo.OPDN ORDER BY [ASIALAND].dbo.OPDN.DocEntry DESC", CommandType.Text);
            return dt;
        }

        public DataTable RECEIPT_List_4PKN()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "Select [ASIALAND].dbo.OPDN.DocEntry as ECH_RECEPS,[ASIALAND].dbo.OPDN.Comments as ECH_RECEP from [ASIALAND].dbo.OPDN ORDER BY [ASIALAND].dbo.OPDN.DocEntry DESC", CommandType.Text);
            return dt;
        }

        public DataTable RECEIPT_Find(string ECH_RECEPS)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "Select * from [SYNC_NUTRICIEL].dbo.tbl_RECEIPT where  [SYNC_NUTRICIEL].dbo.tbl_RECEIPT.ECH_RECEPS=  " +
 "'" + ECH_RECEPS + "'", CommandType.Text);
            return dt;
        }

        public DataTable RECEIPT_Detail(string ECH_RECEPS)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "Select [ASIALAND].dbo.IBT1.BaseEntry as ECH_RECEPS " +
            " ,(([ASIALAND].dbo.IBT1.BaseLinNum+1)*1000) as ECH_RECEP " +
            " ,CONVERT(varchar(10),[ASIALAND].dbo.IBT1.DocDate,103) as DT_ENT " +
            " ,[ASIALAND].dbo.IBT1.ItemCode as CD_MAT " +
            " ,LEFT([ASIALAND].dbo.IBT1.ItemName,39) as LB_MAT ," +
            //Theo yeu cau moi OABatch chuyen sang batchAtribute1
            //"[ASIALAND].dbo.IBT1.BatchNum  as NO_LOT "+
            "[ASIALAND].dbo.OBTN.MnfSerial  as NO_LOT " +
            ",CAST([ASIALAND].dbo.IBT1.Quantity as numeric(18,3))  as QT_NET " +
            ",CD_UNIT = 'KG' " +
            ",CONVERT(varchar(10),[ASIALAND].dbo.OBTN.ExpDate,103) as DP_PEREMP " +
            //", XHL = 0 "+
            "from [ASIALAND].dbo.IBT1  inner join [ASIALAND].dbo.OBTN  on [ASIALAND].dbo.IBT1.BatchNum =[ASIALAND].dbo.OBTN.DistNumber and [ASIALAND].dbo.IBT1.ItemCode =[ASIALAND].dbo.OBTN.ItemCode   where  [ASIALAND].dbo.IBT1.BaseType= 20 and [ASIALAND].dbo.IBT1.BaseEntry = " +
            "'" + ECH_RECEPS + "' order by  ECH_RECEP,CD_MAT ASC", CommandType.Text);
            return dt;
        }

        public DataTable RECEIPT_Detail_Reload(string ECH_RECEPS)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", " SELECT LINE " +
              " ,ECH_RECEPS " +
              " ,ECH_RECEP " +
              " ,CONVERT(varchar(10),DT_ENT,103) as DT_ENT " +
              " ,CD_MAT " +
              " ,LB_MAT " +
              " ,NO_LOT " +
              " ,QT_NET " +
              " ,CD_UNIT " +
              " ,CONVERT(varchar(10),DP_PEREMP,103) as DP_PEREMP " +
              " ,INSERTDATE " +
              " ,LOSS_COMP " +
            //" ,XHL  "+
            " FROM [SYNC_NUTRICIEL].[dbo].[tbl_RECEIPT_Detail] WHERE [ECH_RECEPS]='" + ECH_RECEPS + "'", CommandType.Text);
            return dt;
        }

        public int MAX_XHL(string ECH_RECEPS)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", " SELECT MAX(XHL) as XHL FROM [SYNC_NUTRICIEL].[dbo].[tbl_RECEIPT_Detail] WHERE [ECH_RECEPS]='" + ECH_RECEPS + "'", CommandType.Text);
            return int.Parse(dt.Rows[0]["XHL"].ToString());
        }

        public DataTable RECEIPT_Lot(string ECH_RECEPS)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "Select [ASIALAND].dbo.IBT1.BatchNum  as NO_LOT from [ASIALAND].dbo.IBT1  where  [ASIALAND].dbo.IBT1.BaseType= 20 and [ASIALAND].dbo.IBT1.BaseEntry = " +
 "'" + ECH_RECEPS + "' order by NO_LOT ASC", CommandType.Text);
            return dt;
        }

        public DataTable RECEIPT_ExpDate_ItemName(string ECH_RECEPS, string NO_LOT)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "Select CONVERT(varchar(10),[ASIALAND].dbo.OBTN.ExpDate,103) as DP_PEREMP,[ASIALAND].dbo.IBT1.ItemName  as LB_MAT  FROM [ASIALAND].dbo.IBT1  inner join [ASIALAND].dbo.OBTN  on [ASIALAND].dbo.IBT1.BatchNum =[ASIALAND].dbo.OBTN.DistNumber and [ASIALAND].dbo.IBT1.ItemCode =[ASIALAND].dbo.OBTN.ItemCode   where  [ASIALAND].dbo.IBT1.BaseType= 20 and [ASIALAND].dbo.IBT1.BaseEntry = " +
 "'" + ECH_RECEPS + "' and [ASIALAND].dbo.IBT1.BatchNum ='" + NO_LOT + "'", CommandType.Text);
            return dt;
        }

        public void OF_Detail_INSERT(DataRow dr)
        {
            //XtraMessageBox.Show("DT_ENT : " + dr["DT_ENT"].ToString());
            //XtraMessageBox.Show("XHL : " + dr["XHL"].ToString());
            //XtraMessageBox.Show("DT_ENT : " + DateTime.Parse(dr["DT_ENT"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")));
            //XtraMessageBox.Show("DP_PEREMP : " + dr["DP_PEREMP"].ToString());
            //XtraMessageBox.Show("DT_ENT : " + DateTime.Parse(dr["DP_PEREMP"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")));
            if (dr["DP_PEREMP"].ToString().Length != 0)
            {
                //XtraMessageBox.Show("DP_PEREMP : " + dr["DP_PEREMP"].ToString());
                Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_RECEIPT_Detail]" +
                                   "([ECH_RECEPS]" +
                                   ",[ECH_RECEP]" +
                                   ",[DT_ENT]" +
                                   ",[CD_MAT]" +
                                   ",[LB_MAT]" +
                                   ",[NO_LOT]" +
                                   ",[QT_NET]" +
                                   ",[CD_UNIT]" +
                                   ",[DP_PEREMP]" +
                //",[XHL]"+
                ")" +
                             "VALUES" +
                                   "('" + dr["ECH_RECEPS"] +
                                   "','" + dr["ECH_RECEP"] +
                                   "',Convert(datetime, '" + dr["DT_ENT"].ToString() + "',103) " +
                                   ",'" + dr["CD_MAT"] +
                                   "','" + dr["LB_MAT"] +
                                   "','" + dr["NO_LOT"] +
                                   "'," + dr["QT_NET"] +
                                   ",'" + dr["CD_UNIT"] +
                                   "',Convert(datetime, '" + dr["DP_PEREMP"].ToString() + "',103) " +
                                   //"'," + int.Parse(dr["XHL"].ToString()) +
                                   ")", CommandType.Text);
            }
            else
                Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_RECEIPT_Detail]" +
                                           "([ECH_RECEPS]" +
                                           ",[ECH_RECEP]" +
                                           ",[DT_ENT]" +
                                           ",[CD_MAT]" +
                                           ",[LB_MAT]" +
                                           ",[NO_LOT]" +
                                           ",[QT_NET]" +
                                           ",[CD_UNIT]" +
                                           ",[DP_PEREMP]" +
                                           //",[XHL]" +
                                           ")" +
                                     "VALUES" +
                                           "('" + dr["ECH_RECEPS"] +
                                           "','" + dr["ECH_RECEP"] +
                                           "','" + DateTime.Parse(dr["DT_ENT"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")) +
                                           "','" + dr["CD_MAT"] +
                                           "','" + dr["LB_MAT"] +
                                           "','" + dr["NO_LOT"] +
                                           "'," + dr["QT_NET"] +
                                           ",'" + dr["CD_UNIT"] +
                                           "','" + DateTime.Now.ToString() +
                                           //"'," + int.Parse(dr["XHL"].ToString()) +
                                           "')", CommandType.Text);
        }

        public void OF_Detail_DELETE(string ECH_RECEPS)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_RECEIPT_Detail] WHERE [ECH_RECEPS] = '" + ECH_RECEPS + "'", CommandType.Text);
        }

        public void OF_DELETE(string ECH_RECEPS)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_RECEIPT] WHERE [ECH_RECEPS] = '" + ECH_RECEPS + "'", CommandType.Text);
        }

        public void OF_INSERT(DataRow dr)
        {
            //XtraMessageBox.Show("DT_ENT : " + dr["DT_ENT"].ToString());
            //XtraMessageBox.Show("DT_ENT : " + DateTime.Parse(dr["DT_ENT"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")));
            //XtraMessageBox.Show("Now : " + DateTime.Parse(DateTime.Now.ToString(), CultureInfo.CreateSpecificCulture("en-GB")));
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_RECEIPT]" +
           "([ECH_RECEPS]" +
           ",[DT_ENT]" +
           ",[INSERTDATE]" +
           ")" +
     "VALUES" +
           "('" + dr["ECH_RECEPS"] +
           "',Convert(datetime, '"+dr["DT_ENT"].ToString() + "',103) " +
           " ,Convert(datetime, '" + DateTime.Now.ToString() + "',103) " +
           ")", CommandType.Text);
        }
    }
}