namespace Production.Class
{
    public class EMPLOYEEBUS
    {
        private EMPLOYEEDAO EMPDAO = new EMPLOYEEDAO();

        public void EMPLOYEE_INSERT(EMPLOYEE EMP)
        {
            EMPDAO.EMPLOYEE_INSERT(EMP);
        }

        public void EMPLOYEE_UPDATE(EMPLOYEE EMP)
        {
            EMPDAO.EMPLOYEE_UPDATE(EMP);
        }

        public void EMPLOYEE_DELETE(EMPLOYEE EMP)
        {
            EMPDAO.EMPLOYEE_DELETE(EMP);
        }
    }
}