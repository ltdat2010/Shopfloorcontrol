namespace Production.Class
{
    public class PXN_Header_SUB_HTHBUS
    {
        private PXN_Header_SUB_HTHDAO DAO = new PXN_Header_SUB_HTHDAO();

        public void PXN_Header_SUB_HTHBUS_INSERT(PXN_Header_SUB_HTH OBJ)
        {
            DAO.PXN_Header_SUB_HTHDAO_INSERT(OBJ);
        }

        public void PXN_Header_SUB_HTHBUS_UPDATE(PXN_Header_SUB_HTH OBJ)
        {
            DAO.PXN_Header_SUB_HTHDAO_UPDATE(OBJ);
        }

        public void PXN_Header_SUB_HTHBUS_DELETE(PXN_Header_SUB_HTH OBJ)
        {
            DAO.PXN_Header_SUB_HTHDAO_DELETE(OBJ);
        }

        public int MAX_PXN_Header_SUB_HTHBUS_ID()
        {
            return DAO.MAX_PXN_Header_SUB_HTHDAO_ID();
        }
    }
}