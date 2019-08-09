using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Globalization;
using DevExpress.XtraEditors;

namespace Production.Class
{
    public class CUSTOMERTYPEDAO
    {
        public void CUSTOMERTYPE_INSERT(CUSTOMERTYPE CUSTTYPE)
        {     
            Sql.ExecuteNonQuery("SAP", "INSERT INTO[SYNC_NUTRICIEL].[dbo].[tbl_CUSTOMERTYPE_LAB] " +
           " ([CUSTTYPECode] " +
           " ,[CUSTTYPEName] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "('" + CUSTTYPE.CUSTTYPECode +
           "',N'" + CUSTTYPE.CUSTTYPEName +
           "',Convert(datetime,'" + DateTime.Today +
           "',103),'" + CUSTTYPE.CreatedBy +
           "',N'" + CUSTTYPE.Note +
           "','" + CUSTTYPE.Locked +
            "')", CommandType.Text);
        }

        public void CUSTOMERTYPE_UPDATE(CUSTOMERTYPE CUSTTYPE)
        {		            
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_CUSTOMERTYPE_LAB] SET" +
           "[CUSTTYPEName] = N'" + CUSTTYPE.CUSTTYPEName + "'" +
           //",[LOCCode] = '" + MINStart + "' " +
           ",[CreatedDate] = Convert(datetime,'" + DateTime.Today + "',103)" +
           ",[CreatedBy] = '" + CUSTTYPE.CreatedBy + "' " +
           ",[Note] = N'" + CUSTTYPE.Note + "' " +
           ",[Locked] = '" + CUSTTYPE.Locked + "' " +
           " WHERE [CUSTTYPECode]='" + CUSTTYPE.CUSTTYPECode + "'", CommandType.Text);
        }

        public void CUSTOMERTYPE_DELETE(CUSTOMERTYPE CUSTTYPE)
        {
           Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_CUSTOMERTYPE_LAB] " +
           " WHERE [CUSTTYPECode]='" + CUSTTYPE.CUSTTYPECode + "'", CommandType.Text);
        }


    }

}


