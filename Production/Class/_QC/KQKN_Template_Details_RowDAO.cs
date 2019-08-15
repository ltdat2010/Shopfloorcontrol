using System;
using System.Data;

namespace Production.Class
{
    public class KQKN_Template_Details_RowDAO
    {
        public void KQKN_Template_Details_Row_INSERT(KQKN_Template_Details_Row OBJ)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details] " +
           " ([KQKNTemplateID] " +
           " ,[STT] " +
           " ,[CTPTID] " +
           " ,[TCID] " +
           " ,[PPTID] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(" + OBJ.KQKNTemplateID +
           ",'" + OBJ.STT +
           "'," + OBJ.CTPTID +
           "," + OBJ.TCID +
           "," + OBJ.PPTID +
           ",CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "','" + OBJ.Locked +
           "')", CommandType.Text);
        }

        public void KQKN_Template_Details_Row_UPDATE(KQKN_Template_Details_Row OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details] SET" +
           "[KQKNTemplateID] = " + OBJ.KQKNTemplateID +
           ",[STT] = '" + OBJ.STT + "'" +
           ",[CTPTID] = " + OBJ.CTPTID +
           ",[TCID] = " + OBJ.TCID +
           ",[PPTID] = " + OBJ.PPTID +
           ",[CreatedDate] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public void KQKN_Template_Details_Row_DELETE(KQKN_Template_Details_Row OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details] " +
            " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public DataTable KQKN_Template_Details_Row_SELECT(Result_KQKN_TD OBJ)
        {
            return Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Details] " +
            " WHERE [KQKNTemplateID] =" + OBJ.KQKNTemplateID, CommandType.Text);
        }
    }
}