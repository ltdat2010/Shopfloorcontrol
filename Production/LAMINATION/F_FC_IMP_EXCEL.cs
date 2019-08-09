using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Resources;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Threading;
using Production.LAN;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraEditors.Controls;
using Production.Class;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using Microsoft.Office.Interop.Excel;



namespace Production.Class
{
    public partial class F_FC_IMP_EXCEL : UC_Base 
    {
        OABatchBUS OAB = new OABatchBUS();
        CSVFromToDataTable XLSX = new CSVFromToDataTable();

        public F_FC_IMP_EXCEL()
        {           
            InitializeComponent();
            
            Load += (s, e) =>
                {
                    BtnOABATCH.Enabled = false;
                    gridControl2.DataSource = OAB.OABatch_View();
                };                       
            action1.Excel(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Excel));
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
            BtnOABATCH.Click += (s, e) =>
                {
                    //XtraMessageBox.Show("Click");
                    
                    
                    for ( int i = 0 ; i < gridView1.RowCount-1 ; i++)
                    {
                        //XtraMessageBox.Show("i : " + i.ToString());
                        //XtraMessageBox.Show("Item Code :" + gridView1.GetRowCellValue(i, "Item Code").ToString());
                        //XtraMessageBox.Show("Supplier code :" + gridView1.GetRowCellValue(i, "Supplier code").ToString());
                        //XtraMessageBox.Show("Received 's date :" + (DateTime.Parse(gridView1.GetRowCellValue(i, "Received 's date").ToString())).DayOfYear.ToString());
                        //XtraMessageBox.Show("Received 's date # :" + (DateTime.Parse(gridView1.GetRowCellValue(i, "Received 's date").ToString())).Year.ToString().Substring(2, 2));
                        //XtraMessageBox.Show("Times of receiving in day :" + gridView1.GetRowCellValue(i, "Times of receiving in day").ToString());
                        string tmp =
                            gridView1.GetRowCellValue(i, "Item Code").ToString() +
                            gridView1.GetRowCellValue(i, "Supplier code").ToString() +
                            (DateTime.Parse(gridView1.GetRowCellValue(i, "Received date").ToString())).DayOfYear.ToString() +
                            (DateTime.Parse(gridView1.GetRowCellValue(i, "Received date").ToString())).Year.ToString().Substring(2, 2) +
                            gridView1.GetRowCellValue(i, "Times of receiving in day").ToString();
                        //Chua co Lot-Number thi tao moi
                        System.Data.DataTable dtLotNumber = new System.Data.DataTable();
                        dtLotNumber = OAB.Lot_Number_Visible(gridView1.GetRowCellValue(i, "Lot number").ToString());
                        //XtraMessageBox.Show("dtLotNumber rows count : " + OAB.Lot_Number_Visible(gridView1.GetRowCellValue(i, "Lot number").ToString()).Rows.Count.ToString());

                        if (dtLotNumber.Rows.Count <= 0)
                        //{
                            //XtraMessageBox.Show("tmp : " + tmp.ToString());
                            gridView1.SetRowCellValue(i, "OA BATCH", tmp);
                        //}
                            
                            //Ton tao Lot_number thi lay OABatch da co
                        else
                            gridView1.SetRowCellValue(i, "OA BATCH", dtLotNumber.Rows[0]["OA BATCH"].ToString());

                        //XtraMessageBox.Show("OABATCH : " + gridView1.GetRowCellValue(i, "OABATCH").ToString());
                        //XtraMessageBox.Show("Lot number before : " + gridView1.GetRowCellValue(i, "Lot number").ToString()); 
                        //XtraMessageBox.Show("tmp " + tmp);
                        if (gridView1.GetRowCellValue(i, "Lot number").ToString().Length == 0 )
                        {
                            gridView1.SetRowCellValue(i, "Lot number", gridView1.GetRowCellValue(i, "OA BATCH").ToString());
                        }

                        //XtraMessageBox.Show("Lot number after : " + gridView1.GetRowCellValue(i, "Lot number").ToString());    
                        //Kiem tra xem [OA Batch] tồn tại chưa--Update cho trung OA Batch
                        //if (OAB.OABatch_Visible(gridView1.GetRowCellValue(i, "OA BATCH").ToString()) == false)
                        OAB.OABatch_INSERT(gridView1.GetDataRow(i));
                        
                    }
                    
                    gridControl2.DataSource = OAB.OABatch_View();

                    XLSX.WRITE2XSLX(gridView1);
                     
                    gridControl1.DataSource = null;
                };
        }

        private void ItemClickEventHandler_Excel(object sender, EventArgs e)
        {
            try
            {
                XLSX.XLSX2Grid(gridControl1);

                BtnOABATCH.Enabled = true;
            }

            catch(Exception ex)
            {
                string _error = ex.Message;
                MessageBox.Show(_error);
                throw;
            }                        
        }
        private void copyAlltoClipboard()
        {
            //to remove the first blank column from datagridview
            //gridView1.RowHeadersVisible = false;
            gridView1.SelectAll();
            gridView1.CopyToClipboard();            
        }
        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            R_FrDate_ToDate_OABatch RFTOAB = new R_FrDate_ToDate_OABatch();
            RFTOAB.Show();
        }
        
    }
}