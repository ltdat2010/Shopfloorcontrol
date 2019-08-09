using System;
using System.Data;

namespace Production.Class
{
    public class VENDORBUS
    {
        VENDORDAO DAO = new VENDORDAO();

        public DataTable VENDOR_SELECT()
        {
             return DAO.VENDOR_SELECT();
        }

    }

}


