namespace Production.Class
{
    public class Result_COA_KQBUS
    {
        private Result_COA_KQDAO DAO = new Result_COA_KQDAO();

        public void Result_COA_KQDAO_INSERT(Result_COA_KQ OBJ)
        {
            DAO.Result_COA_KQDAO_INSERT(OBJ);
        }

        public void Result_COA_KQDAO_UPDATE(Result_COA_KQ OBJ)
        {
            DAO.Result_COA_KQDAO_UPDATE(OBJ);
        }

        public void Result_COA_KQDAO_UPDATE_VALUE(Result_COA_KQ OBJ)
        {
            DAO.Result_COA_KQDAO_UPDATE_VALUE(OBJ);
        }

        public void Result_COA_KQDAO_DELETE(Result_COA_TD OBJ)
        {
            DAO.Result_COA_KQDAO_DELETE(OBJ);
        }

        public int MAX_Result_COA_TD_ID()
        {
            return DAO.MAX_Result_COA_TD_ID();
        }

        //public int Result_COA_TD_SoCOA()
        //{
        //    DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT ISNULL(MAX(RIGHT(SoPKN,4)),'0') as SoPKN FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD]", CommandType.Text);
        //    return int.Parse(dt.Rows[0]["SoPKN"].ToString())+1;

        //}
    }
}