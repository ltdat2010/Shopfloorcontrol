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
    public class OABatchBUS
    {
        //public static OF of = new OF();
        public static OABatchDAO OAD = new OABatchDAO();

        public void OABatch_INSERT(DataRow dr)
        {
            OAD.OABatch_INSERT(dr);
        }
        public bool OABatch_Visible(string OABatch)
        {
            return OAD.OABatch_Visible(OABatch);
        }

        public DataTable Lot_Number_Visible(string LotNumber)
        {
            return OAD.Lot_Number_Visible(LotNumber);
        }

        public DataTable OABatch_View()
        {
            return OAD.OABatch_View();
        }

        public DataTable OABatch_Report_byDate( string FrDate, string ToDate)
        {
            return OAD.OABatch_Report_byDate(FrDate, ToDate);
        }

    }
}
