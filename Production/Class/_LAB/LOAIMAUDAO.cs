using System;
using System.Data;

namespace Production.Class
{
    public class LOAIMAUDAO
    {
        public void LOAIMAU_INSERT(LOAIMAU LOC)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_LoaiMau_LAB] " +
           " ([MaLoaiMau] " +
           " ,[TenLoaiMau] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + LOC.MaLoaiMau +
           "',N'" + LOC.TenLoaiMau +
           "',Convert(datetime,'" + DateTime.Now +
           "',103),N'" + LOC.CreatedBy +
           "',N'" + LOC.Note +
           "','" + LOC.Locked +
           "')", CommandType.Text);
        }

        public void LOAIMAU_UPDATE(LOAIMAU LOC)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_LoaiMau_LAB] SET" +
           "[MaLoaiMau] = N'" + LOC.MaLoaiMau + "'" +
           ",[TenLoaiMau] = N'" + LOC.TenLoaiMau + "'" +
           ",[CreatedDate] = Convert(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + LOC.CreatedBy + "' " +
           ",[Note] = N'" + LOC.Note + "' " +
           ",[Locked] = '" + LOC.Locked + "' " +
           " WHERE [ID]='" + LOC.ID + "'", CommandType.Text);
        }

        public void LOAIMAU_DELETE(LOAIMAU LOC)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_LoaiMau_LAB] " +
            " WHERE [ID]='" + LOC.ID + "'", CommandType.Text);
        }

        public int MAX_MALOAIMAI()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT ISNULL(MAX(CONVERT(int,RIGHT(MaLoaiMau,LEN(MaLoaiMau) - 2))),'0') as MaLoaiMau FROM [SYNC_NUTRICIEL].[dbo].[tbl_LoaiMau_LAB] ", CommandType.Text);
            return int.Parse(dt.Rows[0]["MaLoaiMau"].ToString()) + 1;
        }
    }
}