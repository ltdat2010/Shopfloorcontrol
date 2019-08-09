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
    public class COA_Template_DetailsDAO
    {
        public void COA_Template_DetailsDAO_INSERT(COA_Template_Details OBJ)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details] " +
           " ([COATemplateID] " +
           " ,[HMKTID] " +
           " ,[Value] " +
           " ,[Tolerance] " +
           " ,[ValueVN] " +
           " ,[ToleranceVN] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(" + OBJ.COATemplateID +
           "," + OBJ.HMKTID +
           ",N'" + OBJ.Value +
           "',N'" + OBJ.Tolerance +
           "',N'" + OBJ.ValueVN +
           "',N'" + OBJ.ToleranceVN +
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "','" + OBJ.Locked +
           "')", CommandType.Text);
        }

        public void COA_Template_DetailsDAO_UPDATE(COA_Template_Details OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details] SET" +
           "[COATemplateID] = " + OBJ.COATemplateID +
           ",[HMKTID] = " + OBJ.HMKTID +
           ",[Value] = N'" + OBJ.Value + "'" +
           ",[Tolerance] = N'" + OBJ.Tolerance + "'" +
           ",[ValueVN] = N'" + OBJ.ValueVN + "'" +
           ",[ToleranceVN] = N'" + OBJ.ToleranceVN + "'" +
           ",[CreatedDate] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public void COA_Template_DetailsDAO_DELETE(COA_Template_Details OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details] " +
            " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public DataTable COA_Template_Details_SELECT(Result_COA_TD OBJ)
        {
            //XtraMessageBox.Show(OBJ.COATemplateID.ToString());
            return Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Details] " +
            " WHERE [COATemplateID] =" + OBJ.COATemplateID, CommandType.Text);
        }

    }

}


