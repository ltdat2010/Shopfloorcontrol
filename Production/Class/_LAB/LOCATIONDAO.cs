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
    public class LOCATIONDAO
    {
        public void LOCATION_INSERT(LOCATION LOC)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_LOCATION_LAB] " +
           " ([LOCName] " +
           " ,[LOCCode] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + LOC.LOCName +
           "',N'" + LOC.LOCCode +
           "',Convert(datetime,'" + DateTime.Now +
           "',103),N'" + LOC.CreatedBy +
           "',N'" + LOC.Note +
           "','" + LOC.Locked + 
           "')", CommandType.Text);
        }

        public void LOCATION_UPDATE(LOCATION LOC)
        {		            
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_LOCATION_LAB] SET" +
           "[LOCName] = N'" + LOC.LOCName + "'" +
           ",[LOCCode] = N'" + LOC.LOCCode + "'" +
           ",[CreatedDate] = Convert(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + LOC.CreatedBy + "' " +
           ",[Note] = N'" + LOC.Note + "' " +
           ",[Locked] = '" + LOC.Locked + "' " +
           " WHERE [LOCCode]='" + LOC.LOCCode + "'", CommandType.Text);
        }

        public void LOCATION_DELETE(LOCATION LOC)
        {
           Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_LOCATION_LAB] " +
           " WHERE [LOCCode]='" + LOC.LOCCode + "'", CommandType.Text);
        }


    }

}


