using System.Data;

namespace Production.Class
{
    public class PhuongPhapThuBUS
    {
        //public static OF of = new OF();
        public static PhuongPhapThuDAO PPTCB = new PhuongPhapThuDAO();

        //public void PPT_Update(DataRow dr)
        //{
        //    PPTCB.PPT_Update(dr);

        //}

        public DataTable PPT_List()
        {
            return PPTCB.PPT_List();
        }

        public void PPT_INSERT(PhuongPhapThu PPT)
        {
            PPTCB.PPT_INSERT(PPT);
        }

        public void PPT_UPDATE(PhuongPhapThu PPT)
        {
            PPTCB.PPT_UPDATE(PPT);
        }

        public void PPT_DELETE(PhuongPhapThu PPT)
        {
            PPTCB.PPT_DELETE(PPT);
        }
    }
}