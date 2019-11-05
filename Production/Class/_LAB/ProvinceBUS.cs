namespace Production.Class
{
    public class ProvinceBUS
    {
        private ProvinceDAO LOCDAO = new ProvinceDAO();

        public void Province_INSERT(Province LOC)
        {
            LOCDAO.Province_INSERT(LOC);
        }

        public void Province_UPDATE(Province LOC)
        {
            LOCDAO.Province_UPDATE(LOC);
        }

        public void Province_DELETE(Province LOC)
        {
            LOCDAO.Province_DELETE(LOC);
        }
    }
}