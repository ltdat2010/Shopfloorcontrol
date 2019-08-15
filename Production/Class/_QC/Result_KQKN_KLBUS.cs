namespace Production.Class
{
    public class Result_KQKN_KLBUS
    {
        private Result_KQKN_KLDAO DAO = new Result_KQKN_KLDAO();

        public void Result_KQKN_KLBUS_INSERT(Result_KQKN_KL OBJ)
        {
            DAO.Result_KQKN_KLDAO_INSERT(OBJ);
        }

        public void Result_KQKN_KLBUS_UPDATE(Result_KQKN_KL OBJ)
        {
            DAO.Result_KQKN_KLDAO_UPDATE(OBJ);
        }

        public void Result_KQKN_KLBUS_DELETE(Result_KQKN_TD OBJ)
        {
            DAO.Result_KQKN_KLDAO_DELETE(OBJ);
        }

        public Result_KQKN_KL Result_KQKN_KLBUS_SELECT_SoPKN(Result_KQKN_TD OBJ)
        {
            return DAO.Result_KQKN_KLDAO_SELECT_SoPKN(OBJ);
        }
    }
}