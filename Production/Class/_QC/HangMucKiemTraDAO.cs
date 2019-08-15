using System;
using System.Data;

namespace Production.Class
{
    public class HangMucKiemTraDAO
    {
        public void HMKT_INSERT(HangMucKiemTra OBJ)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_HangMucKiemTra] " +
           " ([HMKTVN] " +
           " ,[HMKTEN] " +
           " ,[Characteristic] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + OBJ.HMKT +
           "',N'" + OBJ.HMKTEN +
           "',N'" + OBJ.Characteristic +
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "','" + OBJ.Locked +
           "')", CommandType.Text);
        }

        public void HMKT_UPDATE(HangMucKiemTra OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_HangMucKiemTra] SET" +
           "[HMKTVN] = N'" + OBJ.HMKT + "'" +
           ",[HMKTEN] = N'" + OBJ.HMKTEN + "'" +
           ",[Characteristic] = N'" + OBJ.Characteristic + "'" +
           ",[CreatedDate] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public void HMKT_DELETE(HangMucKiemTra OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_HangMucKiemTra] " +
            " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        //public DataTable Control_List()
        //{
        //    DataTable dt = new DataTable();
        //    dt = Sql.ExecuteDataTable("SAP", "Select ID as ControlID, Control as Control, ControlVN as ControlVN,Characteristic FROM [SYNC_NUTRICIEL].[dbo].tbl_Control ", CommandType.Text);
        //    return dt;
        //}
        //public DataTable Control_List_Characteristic(string Characteristic)
        //{
        //    DataTable dt = new DataTable();
        //    dt = Sql.ExecuteDataTable("SAP", "Select ID as ControlID, Control as Control, ControlVN ans ControlVN FROM [SYNC_NUTRICIEL].[dbo].tbl_Control WHERE Characteristic='" + Characteristic + "' ", CommandType.Text);
        //    return dt;
        //}

        //public int Control_Visible(string control)
        //{
        //    DataTable dt = new DataTable();
        //    dt = Sql.ExecuteDataTable("SAP", "Select * From [SYNC_NUTRICIEL].[dbo].tbl_Control where [Control]='" + control + "'", CommandType.Text);
        //    return dt.Rows.Count;
        //}
        //public void Control_Insert(DataRow dr)
        //{
        //    Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_Control] " +
        //                                           "([Control],[ControlVN],[Characteristic]) " +
        //                                     "VALUES " +
        //                                           "('" + dr["Control"].ToString() + "','" +
        //                                                   dr["ControlVN"].ToString() + "','" +
        //                                                   dr["Characteristic"].ToString() + "'", CommandType.Text);
        //    //return dt;
        //}
        //public void Control_Update(DataRow dr)
        //{
        //    Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_Control]" +
        //                                " SET [Control] ='" + dr["Control"].ToString() + "'," +
        //                                " [ControlVN] ='" + dr["ControlVN"].ToString() + "'," +
        //                                " [Characteristic] ='" + dr["Characteristic"].ToString() + "'" +
        //                                " WHERE ID=" + int.Parse(dr["ID"].ToString()), CommandType.Text);
        //    //return dt;
        //}
    }
}