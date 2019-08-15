using System.Data;

namespace Production.Class
{
    internal class PRICELIST_DetailsBUS
    {
        private PRICELIST_DetailsDAO DAO = new PRICELIST_DetailsDAO();

        public DataTable PRICELIST_List()
        {
            return DAO.PRICELIST_DetailsDAO_List();
        }

        //public void TC_Insert(TieuChuan tc)
        //{
        //    Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_TieuChuan] " +
        //                                           "([TC] " +
        //                                           ",[TCDG]) " +
        //                                     "VALUES " +
        //                                           "('" + tc.TC +
        //                                           "','" + tc.TCDG + "'", CommandType.Text);
        //    //return dt;
        //}
        //public void PPT_Update(DataRow dr)
        //{
        //    Sql.ExecuteNonQuery("SAP",  "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PhuongPhapThu]" +
        //                                " SET [PPT] ='"+dr["PPT"].ToString() + "'"+
        //                                ",[PPTDG] = '" + dr["PPTDG"].ToString() + "' " +
        //                                "WHERE ID=" + int.Parse(dr["ID"].ToString()), CommandType.Text);
        //    //return dt;
        //}

        public void PRICELIST_INSERT(PRICELIST_Details OBJ)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            DAO.PRICELIST_DetailsDAO_INSERT(OBJ);
        }

        public void PRICELIST_UPDATE(PRICELIST_Details OBJ)
        {
            DAO.PRICELIST_DetailsDAO_UPDATE(OBJ);
        }

        public void PRICELIST_DELETE(PRICELIST_Details OBJ)
        {
            DAO.PRICELIST_DetailsDAO_DELETE(OBJ);
        }

        public DataTable PRICELIST_History(int PLID)
        {
            return DAO.PRICELIST_History(PLID);
        }

        public int PRICELIST_INDENTITY_SELECT()
        {
            return DAO.PRICELIST_INDENTITY_SELECT();
        }
    }
}