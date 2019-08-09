using System.Data;

namespace Production.Class
{
    public class CUSTOMERBUS
    {

        CUSTOMERDAO CUSTDAO = new CUSTOMERDAO();
        public void CUSTOMER_INSERT(CUSTOMER CUST)
        {
            CUSTDAO.CUSTOMER_INSERT(CUST);
        }

        public void CUSTOMER_UPDATE(CUSTOMER CUST)
        {
            CUSTDAO.CUSTOMER_UPDATE(CUST);
        }

        public void CUSTOMER_DELETE(CUSTOMER CUST)
        {
            CUSTDAO.CUSTOMER_DELETE(CUST);
        }

        public DataTable CUSTOMER_LIST_SAPB1()
        {
            return CUSTDAO.CUSTOMER_LIST_SAPB1();
        }

        public int MAX_CUSTOMER_CODE()
        {
            return CUSTDAO.MAX_CUSTOMER_CODE();

        }

    }

        
}



