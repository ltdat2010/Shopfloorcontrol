using System;
using System.Data;
using System.IO;

namespace Production.Class
{
    public partial class F_BATCH : UC_Base
    {
        //OF of = new OF();
        private BATCHBUS BTB = new BATCHBUS();

        private OFBUS OFB = new OFBUS();

        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";
        private string Path = Directory.GetCurrentDirectory();

        private CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        //----------------------------End Report parameters declare---------------------------------------------
        private string MINSTart = "";

        private string MAXEnd = "";
        private float ManufacturedQty;
        private string Formula = "";
        private int TotalBatch;

        public F_BATCH()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                //Load xls vào grid
                gridControl1.DataSource = CSVFromToDataTable.XLSToDataTable(@"D:\\Eresis\\EXCHANGES\\OUT\\Batch.xls");

                for (int i = 0; i <= gridView1.DataRowCount - 1; i++)
                {
                    //MessageBox.Show("i : " + i.ToString());
                    //MessageBox.Show("WO : " + gridView1.GetRowCellValue(i, "WO").ToString());
                    if (i == 0)
                    {
                        if (OFB.F_OF_Find(gridView1.GetRowCellValue(i, "WO").ToString()).Rows.Count > 0)
                        {
                            DataTable dt = BTB.MINStart_MAXEnd_Date(gridView1.GetRowCellValue(i, "WO").ToString());
                            MINSTart = dt.Rows[0]["MINStart"].ToString();
                            MAXEnd = dt.Rows[0]["MAXEnd"].ToString();
                            ManufacturedQty = float.Parse(dt.Rows[0]["ManufacturedQty"].ToString());
                            Formula = dt.Rows[0]["Formula"].ToString();
                            TotalBatch = int.Parse(dt.Rows[0]["TotalBatchNb"].ToString());
                            OFB.OF_UPDATE(gridView1.GetRowCellValue(i, "WO").ToString(), ManufacturedQty, MINSTart, MAXEnd, Formula, TotalBatch);
                        }
                    }
                    else if (gridView1.GetRowCellValue(i, "WO").ToString() != gridView1.GetRowCellValue(i - 1, "WO").ToString())
                    {
                        if (OFB.F_OF_Find(gridView1.GetRowCellValue(i, "WO").ToString()).Rows.Count > 0)
                        {
                            DataTable dt = BTB.MINStart_MAXEnd_Date(gridView1.GetRowCellValue(i, "WO").ToString());
                            MINSTart = dt.Rows[0]["MINStart"].ToString();
                            MAXEnd = dt.Rows[0]["MAXEnd"].ToString();
                            ManufacturedQty = float.Parse(dt.Rows[0]["ManufacturedQty"].ToString());
                            Formula = dt.Rows[0]["Formula"].ToString();
                            TotalBatch = int.Parse(dt.Rows[0]["TotalBatchNb"].ToString());
                            OFB.OF_UPDATE(gridView1.GetRowCellValue(i, "WO").ToString(), ManufacturedQty, MINSTart, MAXEnd, Formula, TotalBatch);
                        }
                    }

                    DataRow dr = gridView1.GetDataRow(i);
                    //MessageBox.Show("batch : " + dr["batch"].ToString());
                    //Kiem tra có btach chưa
                    //chưa có thì insert
                    if (!dr["batch"].ToString().Equals("Somme"))
                    {
                        if (BTB.BATCH_Find(dr["batch"].ToString()).Rows.Count <= 0)
                            BTB.BATCH_INSERT(dr);
                    }
                }
                //Update data to tbl_OF

                //Show batch data
                gridControl2.DataSource = BTB.BATCH_View();
            };
            //action1.Report += (s, e) =>
            //{
            //    MessageBox.Show("Nhấn Report button");
            //};

            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));

            //simpleButton1.Click += (s, e) =>
            //{
            //    simpleButton1.Enabled = false;
            //    dt = cyn_.Report_DEPT_CM(textEdit1.Text.ToString().Trim(), dateEdit1.Text, dateEdit2.Text);
            //    if (dt.Rows.Count > 0)
            //    {
            //        val = true;
            //        dt.WriteXml(Path + "/../../Xml/CM.xml", System.Data.XmlWriteMode.IgnoreSchema);

            //    }

            //    if (val == true)
            //    {
            //        XtraMessageBox.Show("Path :" + Path.ToString());

            //        rpt.Load(Path + "/../../Report/Rpt_CM_2_2.rpt");
            //        //rpt.Load("C:/CM/Production/Report/Rpt_CM_2_2.rpt");
            //        rpt.SetDatabaseLogon("sa", "GiangBinh080399", "10.31.1.5", "CM");
            //        rpt.SetParameterValue("@Startdate", dateEdit1.Text.ToString());
            //        rpt.SetParameterValue("@Enddate", dateEdit2.Text.ToString());
            //        rpt.SetParameterValue("@Keywords", textEdit1.Text);
            //        crystalReportViewer1.ReportSource = rpt;
            //    }
            //    else
            //        XtraMessageBox.Show("No record can be displayed... ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //};
        }

        //private void gridView1_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        //{
        //    //F_OF_Details F_OFD = new F_OF_Details();
        //    //F_OFD.CDOF = gridView1.GetFocusedRowCellDisplayText(CD_OF).ToString();
        //    //F_OFD.Show();
        //}
        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            R_OF ROF = new R_OF();
            ROF.OF = gridView2.GetFocusedRowCellValue("CD_OF").ToString();
            ROF.TotalBatchNb = gridView2.GetFocusedRowCellValue("TotalBatchNb").ToString();
            ROF.Show();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            //PrintDialog printDialog1 = new PrintDialog();

            //DialogResult result = printDialog1.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    rpt.PrintToPrinter(2, true, 1, 2);
            //}

            //try
            //{
            //    PrintDialog printDialog1 = new PrintDialog();
            //    PrintDocument pd = new PrintDocument();

            //    printDialog1.Document = pd;
            //    printDialog1.ShowNetwork = true;
            //    printDialog1.AllowSomePages = true;
            //    printDialog1.AllowSelection = false;
            //    printDialog1.AllowCurrentPage = false;
            //    printDialog1.PrinterSettings.Copies = 3;
            //    //printDialog1.PrinterSettings.PrinterName = this.PrinterToPrint;
            //    DialogResult result = printDialog1.ShowDialog();
            //    if (result == DialogResult.OK)
            //    {
            //        PrintReport(pd);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        //private void Print_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        PrintDialog printDialog1 = new PrintDialog();
        //        PrintDocument pd = new PrintDocument();

        //        printDialog1.Document = pd;
        //        printDialog1.ShowNetwork = true;
        //        printDialog1.AllowSomePages = true;
        //        printDialog1.AllowSelection = false;
        //        printDialog1.AllowCurrentPage = false;
        //        printDialog1.PrinterSettings.Copies = (short)this.CopiesToPrint;
        //        printDialog1.PrinterSettings.PrinterName = this.PrinterToPrint;
        //        DialogResult result = printDialog1.ShowDialog();
        //        if (result == DialogResult.OK)
        //        {
        //            PrintReport(pd);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void PrintReport(PrintDocument pd)
        //{
        //    ReportDocument rDoc = (ReportDocument)crvReport.ReportSource;
        //    // This line helps, in case user selects a different printer
        //    // other than the default selected.
        //    rDoc.PrintOptions.PrinterName = pd.PrinterSettings.PrinterName;
        //    // In place of Frompage and ToPage put 0,0 to print all pages,
        //    // however in that case user wont be able to choose selection.
        //    rDoc.PrintToPrinter(pd.PrinterSettings.Copies, false, pd.PrinterSettings.FromPage,
        //       pd.PrinterSettings.ToPage);
        //}
    }
}