using System;
using System.Data;

namespace Production.Class
{
    public class MYCOTOXIN_ConCDAO
    {
        public void MYCOTOXIN_ConC_INSERT(MYCOTOXIN_ConC LOC)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_ConC] " +
           " ([CTXN_ID] " +
           " ,[ConC] " +
           " ,[KHMau] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(" + LOC.CTXN_ID +
           "," + LOC.ConC +
           ",N'" + LOC.KHMau +
           "',Convert(datetime,'" + DateTime.Now +
           "',103),N'" + LOC.CreatedBy +
           "',N'" + LOC.Note +
           "','" + LOC.Locked +
           "')", CommandType.Text);
        }

        public void MYCOTOXIN_ConC_UPDATE(MYCOTOXIN_ConC LOC)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_ConC] SET" +
           "[CTXN_ID] = " + LOC.CTXN_ID +
           ",[ConC] = " + LOC.ConC +
           ",[KHMau] = N'" + LOC.KHMau + "'" +
           ",[CreatedDate] = Convert(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + LOC.CreatedBy + "' " +
           ",[Note] = N'" + LOC.Note + "' " +
           ",[Locked] = '" + LOC.Locked + "' " +
           " WHERE [ID]='" + LOC.ID + "'", CommandType.Text);
        }

        public void MYCOTOXIN_ConC_DELETE(MYCOTOXIN_ConC LOC)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_ConC] " +
            " WHERE [ID]='" + LOC.ID + "'", CommandType.Text);
        }
    }
}