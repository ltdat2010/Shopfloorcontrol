using System.Data;

namespace Production.Class
{
    public class ControlBUS
    {
        //public static OF of = new OF();
        public static ControlDAO COD = new ControlDAO();

        public DataTable Control_List()
        {
            return COD.Control_List();
        }

        public void Control_Insert(DataRow dr)
        {
            COD.Control_Insert(dr);
        }

        public void Control_Update(DataRow dr)
        {
            COD.Control_Update(dr);
        }

        public int Control_Visible(string control)
        {
            return COD.Control_Visible(control);
        }
    }
}