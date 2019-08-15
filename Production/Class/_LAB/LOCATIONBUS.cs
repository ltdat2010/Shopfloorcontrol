namespace Production.Class
{
    public class LOCATIONBUS
    {
        private LOCATIONDAO LOCDAO = new LOCATIONDAO();

        public void LOCATION_INSERT(LOCATION LOC)
        {
            LOCDAO.LOCATION_INSERT(LOC);
        }

        public void LOCATION_UPDATE(LOCATION LOC)
        {
            LOCDAO.LOCATION_UPDATE(LOC);
        }

        public void LOCATION_DELETE(LOCATION LOC)
        {
            LOCDAO.LOCATION_DELETE(LOC);
        }
    }
}