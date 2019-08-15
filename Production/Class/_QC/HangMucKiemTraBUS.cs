namespace Production.Class
{
    public class HangMucKiemTraBUS
    {
        private HangMucKiemTraDAO DAO = new HangMucKiemTraDAO();

        public void HMKT_INSERT(HangMucKiemTra OBJ)
        {
            DAO.HMKT_INSERT(OBJ);
        }

        public void HMKT_UPDATE(HangMucKiemTra OBJ)
        {
            DAO.HMKT_UPDATE(OBJ);
        }

        public void HMKT_DELETE(HangMucKiemTra OBJ)
        {
            DAO.HMKT_DELETE(OBJ);
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