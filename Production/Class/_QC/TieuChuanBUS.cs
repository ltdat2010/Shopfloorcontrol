using System.Data;

namespace Production.Class
{
    public class TieuChuanBUS
    {
        //public static OF of = new OF();
        public static TieuChuanDAO TCB = new TieuChuanDAO();

        public DataTable TC_List()
        {
            return TCB.TC_List();
        }

        public void TC_INSERT(TieuChuan TC)
        {
            TCB.TC_INSERT(TC);
        }

        public void TC_UPDATE(TieuChuan TC)
        {
            TCB.TC_UPDATE(TC);
        }

        public void TC_DELETE(TieuChuan TC)
        {
            TCB.TC_DELETE(TC);
        }
    }
}