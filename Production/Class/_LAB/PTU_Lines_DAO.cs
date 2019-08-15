using System;
using System.Data;

namespace Production.Class
{
    public class PTU_Lines_DAO
    {
        public void PTU_Lines_INSERT(PTU_Lines OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_PTU_Lines_LAB] " +
           " ([SoPTU] " +
           " ,[NoiDung] " +
           " ,[TAMUNG_ID] " +
           " ,[SoHD] " +
           " ,[SoTien] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + OBJ.SoPTU +
           "','" + OBJ.NoiDung +
           "'," + OBJ.TAMUNG_ID +
           ",N'" + OBJ.SoHD +
           "'," + OBJ.SoTien +
           ",CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "','" + OBJ.Locked +
           "')", CommandType.Text);
            //XtraMessageBox.Show(CommandType.Text.ToString());
        }

        public void PTU_Lines_UPDATE(PTU_Lines OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PTU_Lines_LAB] SET " +
           "[SoPTU]                                             = N'" + OBJ.SoPTU + "'" +
           "[NoiDung]                                           = N'" + OBJ.NoiDung + "'" +
           ",[TAMUNG_ID]                                        = " + OBJ.TAMUNG_ID +
           ",[SoHD]                                             = N'" + OBJ.SoHD + "'" +
           ",[SoTien]                                           = " + OBJ.SoTien +
           ",[CreatedDate]                                      = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy]                                        = N'" + OBJ.CreatedBy + "' " +
           ",[Note]                                             = N'" + OBJ.Note + "' " +
           ",[Locked]                                           = '" + OBJ.Locked + "' " +
           " WHERE [ID]                                         =" + OBJ.ID, CommandType.Text);
        }

        public void PTU_Lines_DELETE(int ID)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_PTU_Lines_LAB] " +
            " WHERE [ID]=" + ID, CommandType.Text);
        }

        public DataTable PTU_Lines_SELECT(string SoPTU)
        {
            return Sql.ExecuteDataTable("   SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_PTU_Lines_LAB] " +
                                        " WHERE [SoPTU]='" + SoPTU + "'", CommandType.Text);
        }
    }
}