using System;
using System.Data;

namespace Production.Class
{
    public class LOAIDVDAO
    {
        public void LOAIDV_INSERT(LOAIDV LOC)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_LoaiDV_LAB] " +
           " ([MaLoaiDV] " +
           " ,[TenLoaiDV] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + LOC.MaLoaiDV +
           "',N'" + LOC.TenLoaiDV +
           "',Convert(datetime,'" + DateTime.Now +
           "',103),N'" + LOC.CreatedBy +
           "',N'" + LOC.Note +
           "','" + LOC.Locked +
           "')", CommandType.Text);
        }

        public void LOAIDV_UPDATE(LOAIDV LOC)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_LoaiDV_LAB] SET" +
           "[MaLoaiDV] = N'" + LOC.MaLoaiDV + "'" +
           ",[TenLoaiDV] = N'" + LOC.TenLoaiDV + "'" +
           ",[CreatedDate] = Convert(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + LOC.CreatedBy + "' " +
           ",[Note] = N'" + LOC.Note + "' " +
           ",[Locked] = '" + LOC.Locked + "' " +
           " WHERE [ID]='" + LOC.ID + "'", CommandType.Text);
        }

        public void LOAIDV_DELETE(LOAIDV LOC)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_LoaiDV_LAB] " +
            " WHERE [ID]='" + LOC.ID + "'", CommandType.Text);
        }

        public int MAX_MALOAIDV()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT ISNULL(MAX(CONVERT(int,RIGHT(MaLoaiDV,(LEN(MaLoaiDV)-2)))),'0') as MaLoaiDV FROM [SYNC_NUTRICIEL].[dbo].[tbl_LoaiDV_LAB] ", CommandType.Text);
            return int.Parse(dt.Rows[0]["MaLoaiDV"].ToString()) + 1;
        }
    }
}