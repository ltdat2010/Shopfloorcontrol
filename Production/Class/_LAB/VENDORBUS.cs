using System.Data;

namespace Production.Class
{
    public class VENDORBUS
    {
        private VENDORDAO DAO = new VENDORDAO();

        public DataTable VENDOR_SELECT()
        {
            return DAO.VENDOR_SELECT();
        }
    }
}