using System;
using System.Collections.Generic;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;
using System.Text;
using Production.Class;
using System.IO;
using System.Data;
using System.Windows;

namespace Production.Class
{
    public class RMUSEDBUS
    {
        //public static OF of = new OF();
        public static RMUSEDDAO RMD = new RMUSEDDAO();
        
        public DataTable RMUSED_Find(string CD_OF)
        {
            return RMD.RMUSED_Find(CD_OF);
        }

        public DataTable RMUSED_View()
        {
            return RMD.RMUSED_View();
        }

        public void RMUSED_INSERT(DataRow dr)
        {
            RMD.RMUSED_INSERT(dr);
        }
        public DataTable RMUsed_Report(string Prefix_RM)
        {
            return RMD.RMUsed_Report(Prefix_RM);
        }

        public DataTable RMUsed_Report_Simple(string Prefix_RM)
        {
            return RMD.RMUsed_Report_Simple(Prefix_RM);
        }

    }
}
