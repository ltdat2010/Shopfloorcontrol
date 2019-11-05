using System;
using System.Data;

namespace Production.Class
{
    public class ProvinceDAO
    {
        public void Province_INSERT(Province LOC)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_Province] " +
           " ([ProvinceName] " +
           " ,[ProvinceCode] " +
           " ,[LOCId] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + LOC.ProvinceName +
           "',N'" + LOC.ProvinceCode +
           "'," + LOC.LOCId +
           ",Convert(datetime,'" + DateTime.Now +
           "',103),N'" + LOC.CreatedBy +
           "',N'" + LOC.Note +
           "','" + LOC.Locked +
           "')", CommandType.Text);
        }

        public void Province_UPDATE(Province LOC)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_Province] SET" +
           "[ProvinceName] = N'" + LOC.ProvinceName + "'" +
           ",[ProvinceCode] = N'" + LOC.ProvinceCode + "'" +
           ",[LOCId] = N'" + LOC.LOCId +
           ",[CreatedDate] = Convert(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + LOC.CreatedBy + "' " +
           ",[Note] = N'" + LOC.Note + "' " +
           ",[Locked] = '" + LOC.Locked + "' " +
           " WHERE [Id]='" + LOC.Id + "'", CommandType.Text);
        }

        public void Province_DELETE(Province LOC)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_Province] " +
            " WHERE [Id]='" + LOC.Id + "'", CommandType.Text);
        }
    }
}