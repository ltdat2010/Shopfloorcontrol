using System.Data;

namespace Production.Class
{
    public class PhuongPhapXetNghiemBUS
    {
        //public static OF of = new OF();
        public static PhuongPhapXetNghiemDAO DAO = new PhuongPhapXetNghiemDAO();

        //public void PPT_Update(DataRow dr)
        //{
        //    PPTCB.PPT_Update(dr);

        //}
        public DataTable PPXN_List()
        {
            return DAO.PPXN_List();
        }

        public void PPXN_INSERT(PhuongPhapXetNghiem OBJ)
        {
            DAO.PPXN_INSERT(OBJ);
        }

        public void PPXN_UPDATE(PhuongPhapXetNghiem OBJ)
        {
            DAO.PPXN_UPDATE(OBJ);
        }

        public void PPXN_DELETE(PhuongPhapXetNghiem OBJ)
        {
            DAO.PPXN_DELETE(OBJ);
        }
    }
}