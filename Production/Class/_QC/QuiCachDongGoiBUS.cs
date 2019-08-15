using System.Data;

namespace Production.Class
{
    public class QuiCachDongGoiBUS
    {
        //public static OF of = new OF();
        public static QuiCachDongGoiDAO QCDGD = new QuiCachDongGoiDAO();

        //public void QCDG_Update(DataRow dr)
        //{
        //    QCDGD.QCDG_Update(dr);

        //}

        public DataTable QCDG_List()
        {
            return QCDGD.QCDG_List();
        }

        public void QCDG_INSERT(QuiCachDongGoi OBJ)
        {
            QCDGD.QCDG_INSERT(OBJ);
        }

        public void QCDG_UPDATE(QuiCachDongGoi OBJ)
        {
            QCDGD.QCDG_UPDATE(OBJ);
        }

        public void QCDG_DELETE(QuiCachDongGoi OBJ)
        {
            QCDGD.QCDG_DELETE(OBJ);
        }
    }
}