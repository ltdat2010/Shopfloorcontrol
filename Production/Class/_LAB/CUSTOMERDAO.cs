using System;
using System.Data;

namespace Production.Class
{
    public class CUSTOMERDAO
    {
        public void CUSTOMER_INSERT(CUSTOMER CUST)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_CUSTOMER_LAB] " +
           " ([CUSTCODE] " +
           " ,[CUSTNAME] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Locked] " +
           " ,[EMPCode] " +
           " ,[CUSTTYPECode] " +
           " ,[Note] " +
           " ,[ContactName] " +
           " ,[ContactNumber] " +
           " ,[CUSTADDRESS] " +
           " ,[CUSTPHONE] " +
           " ,[TaxCode] " +
           " ,[ProvinceName] " +
           " ,[ContactEmail] " +
           " ,[CUSTViphaLAB] " +
           " ,[ProvinceId] )" +
     " VALUES " +
           "('" + CUST.CUSTCODE +
           "',N'" + CUST.CUSTNAME +
           "',Convert(datetime,'" + DateTime.Today +
           "',103),'" + CUST.CreatedBy +
           "','" + CUST.Locked +
           "',N'" + CUST.EMPCode +
           "','" + CUST.CUSTTYPECode +
           "',N'" + CUST.Note +
           "',N'" + CUST.ContactName +
           "',N'" + CUST.ContactNumber +
           "',N'" + CUST.CUSTADDRESS +
           "',N'" + CUST.CUSTPHONE +
           "',N'" + CUST.TaxCode +
           "',N'" + CUST.ProvinceName +
           "',N'" + CUST.ContactEmail +
           "','" + CUST.CUSTViphaLAB +
           "'," + CUST.ProvinceId +
            ")", CommandType.Text);
        }

        public void CUSTOMER_UPDATE(CUSTOMER CUST)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_CUSTOMER_LAB] SET" +
           "[CUSTNAME] = N'" + CUST.CUSTNAME + "'" +
           //",[LOCCode] = '" + MINStart + "' " +
           ",[CreatedDate] = Convert(datetime,'" + DateTime.Today + "',103)" +
           ",[CreatedBy] = N'" + CUST.CreatedBy + "' " +
           ",[Locked] = '" + CUST.Locked + "' " +
           ",[EMPCode] = N'" + CUST.EMPCode + "' " +
           ",[CUSTTypeCode] = N'" + CUST.CUSTTYPECode + "' " +
           ",[ProvinceId] = " + CUST.ProvinceId +
           ",[Note] = N'" + CUST.Note + "' " +
           ",[ContactName] = N'" + CUST.ContactName + "' " +
           ",[ContactNumber] = '" + CUST.ContactNumber + "' " +
           ",[CUSTADDRESS] = N'" + CUST.CUSTADDRESS + "' " +
           ",[CUSTPHONE] = N'" + CUST.CUSTPHONE + "' " +
           ",[ContactEmail] = N'" + CUST.ContactEmail + "' " +
           ",[ProvinceName] = N'" + CUST.ProvinceName + "' " +
           ",[TaxCode] = N'" + CUST.TaxCode + "' " +
           ",[CUSTViphaLAB] = N'" + CUST.CUSTViphaLAB + "' " +
           " WHERE [CUSTCODE]='" + CUST.CUSTCODE + "'", CommandType.Text);
        }

        public void CUSTOMER_UPDATE_CUSTOMERCODE(CUSTOMER CUST,string CUSTCODE)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_CUSTOMER_LAB] SET" +
           "[CUSTCODE] = N'" + CUSTCODE + "'" +           
           " WHERE [CUSTCODE]='" + CUST.CUSTCODE + "'", CommandType.Text);
        }

        public void CUSTOMER_DELETE(CUSTOMER CUST)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_CUSTOMER_LAB] " +
            " WHERE [CUSTCODE]='" + CUST.CUSTCODE + "'", CommandType.Text);
        }

        public DataTable CUSTOMER_LIST_SAPB1()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "Select CardName,CardCode,Address from [VIPHAVET].[dbo].[OCRD] ", CommandType.Text);
            return dt;
        }

        public int MAX_CUSTOMER_CODE()
        {
            DataTable dt
                = Sql.ExecuteDataTable("SAP", "SELECT MAX(RIGHT([CUSTCODE],LEN(   [CUSTCODE]) -2) ) +1 as CUSTCODE" +
                                                      " FROM[SYNC_NUTRICIEL].[dbo].[tbl_CUSTOMER_LAB]" +
                                                      " WHERE[CUSTCODE] like 'HT%' ", CommandType.Text);
            return int.Parse(dt.Rows[0]["CUSTCODE"].ToString());
        }
    }
}