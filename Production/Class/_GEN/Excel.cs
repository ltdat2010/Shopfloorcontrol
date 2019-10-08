using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Production.Class._GEN
{
    internal class Excel
    {
        //public void Export2Excel(string filePath, GridView gr, string[] colname)
        //{
        //    //Export to excel -report xlsx
        //    //gridView1.ExportToXlsx(filePath);
        //    System.Diagnostics.Process.Start(filePath);

        //    //Export to excel for update
        //    //string filePath = @"D:\PriceList_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
        //    //Save current layout
        //    //CHEK PC Name
        //    string PCname = System.Environment.MachineName;
        //    if (PCname == "VPV-ASL-SAMPLE")
        //        gr.SaveLayoutToXml(@"D:\SYNC_NUTRICIEL_IMG\tempLayout.xml");
        //    else
        //        gr.SaveLayoutToXml(@"X:\tempLayout.xml");

        //    //Set to visible all column

        //    foreach (GridColumn column in gr.Columns)
        //    {
        //        if (column.Name == "colID")
        //        {
        //            column.VisibleIndex = 0;
        //            column.Visible = true;
        //        }
        //        else if (column.Name == "colMaCTXN")
        //        {
        //            column.VisibleIndex = 1;
        //            column.Visible = true;
        //        }
        //        else if (column.Name == "colCTXN")
        //        {
        //            column.VisibleIndex = 2;
        //            column.Visible = true;
        //        }
        //        else if (column.Name == "colCTXNDG")
        //        {
        //            column.VisibleIndex = 3;
        //            column.Visible = true;
        //        }
        //        else if (column.Name == "colCTXNDGTA")
        //        {
        //            column.VisibleIndex = 4;
        //            column.Visible = true;
        //        }
        //        else if (column.Name == "colPPXNID")
        //        {
        //            column.VisibleIndex = 5;
        //            column.Visible = true;
        //        }
        //        else if (column.Name == "colNCTXNID")
        //        {
        //            column.VisibleIndex = 6;
        //            column.Visible = true;
        //        }
        //        else if (column.Name == "colDays")
        //        {
        //            column.VisibleIndex = 7;
        //            column.Visible = true;
        //        }
        //        else if (column.Name == "colAcronym")
        //        {
        //            column.VisibleIndex = 8;
        //            column.Visible = true;
        //        }                
        //        else
        //            column.Visible = false;
        //    }
        //    //Export
        //    gr.ExportToXlsx(filePath_Upload);

        //    //Restore layout
        //    gr.RestoreLayoutFromXml(@"X:\tempLayout.xml");

        //    System.Diagnostics.Process.Start(filePath_Upload);
        //}
    }
}