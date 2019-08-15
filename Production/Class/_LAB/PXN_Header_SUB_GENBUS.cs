namespace Production.Class
{
    public class PXN_Header_SUB_GENBUS
    {
        private PXN_Header_SUB_GENDAO DAO = new PXN_Header_SUB_GENDAO();

        public void PXN_Header_SUB_GENBUS_INSERT(PXN_Header_SUB_GEN OBJ)
        {
            DAO.PXN_Header_SUB_GENDAO_INSERT(OBJ);
        }

        public void PXN_Header_SUB_GENBUS_UPDATE(PXN_Header_SUB_GEN OBJ)
        {
            DAO.PXN_Header_SUB_GENDAO_UPDATE(OBJ);
        }

        public void PXN_Header_SUB_GENDAO_DELETE(PXN_Header_SUB_GEN OBJ)
        {
            DAO.PXN_Header_SUB_GENDAO_DELETE(OBJ);
        }

        public int MAX_PXN_Header_SUB_GENBUS_ID()
        {
            return DAO.MAX_PXN_Header_SUB_GENDAO_ID();
        }
    }
}