using System.Data;

namespace Production.Class
{
    public class ChiTieuPhanTichBUS
    {
        //public static OF of = new OF();
        public static ChiTieuPhanTichDAO CTPTDAO = new ChiTieuPhanTichDAO();

        //public void CTPT_Update(DataRow dr)
        //{
        //    CTPTDAO.CTPT_Update(dr);
        //}

        public DataTable CTPT_List()
        {
            return CTPTDAO.CTPT_List();
        }

        public void CTPT_INSERT(ChiTieuPhanTich CTPT)
        {
            CTPTDAO.CTPT_INSERT(CTPT);
        }

        public void CTPT_UPDATE(ChiTieuPhanTich CTPT)
        {
            CTPTDAO.CTPT_UPDATE(CTPT);
        }

        public void CTPT_DELETE(ChiTieuPhanTich CTPT)
        {
            CTPTDAO.CTPT_DELETE(CTPT);
        }
    }
}